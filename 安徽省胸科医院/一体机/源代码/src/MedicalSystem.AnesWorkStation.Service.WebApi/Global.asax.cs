using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Dapper.Data;
using MedicalSystem.AnesWorkStation.DataServices;
using Newtonsoft.Json.Converters;
using MedicalSystem.Services;
using System.Web.Http.Validation;

namespace MedicalSystem.AnesWorkStation.Service.WebApi
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            Permission.DataServices.PermissionInstaller.RegistConfig();//权限注册

            //只支持JSON，去掉xml格式返回
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            //Web API 自動忽略所有參考循環的處理
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.IgnoreAndPopulate;
            // Nullable<DateTime> 序列化时需要特殊处理
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.Indent = false;
            json.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new IsoDateTimeConverter()
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
            });
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Converters.Add(DataTableJsonConverter.Current);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Converters.Add(DataSetJsonConverter.Current);
            //GlobalConfiguration.Configuration.Services.Replace(typeof(IBodyModelValidator), new DataTableModelValidator(GlobalConfiguration.Configuration));

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //RegisterWebApi();
            ConfigureWindsor(GlobalConfiguration.Configuration);
        }

        #region RegisterWebApi

        private static IWindsorContainer _container;
        public static void ConfigureWindsor(HttpConfiguration configuration)
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This());
            _container.Kernel.Resolver.AddSubResolver(new CollectionResolver(_container.Kernel, true));
            var dependencyResolver = new WindsorDependencyResolver(_container);
            configuration.DependencyResolver = dependencyResolver;
        }

        ///// <summary>
        ///// Webapi依赖注入
        ///// </summary>
        //private void RegisterWebApi()
        //{
        //    var configuration = GlobalConfiguration.Configuration;
        //    var builder = new ContainerBuilder();

        //    //Dapper相关
        //    builder.Register<IDapperContext>(c => new DapperContext()).InstancePerApiRequest();

        //    //MedicalSystem.Anes.Service.DataServices 自动注入
        //    builder.RegisterAssemblyTypes(BaseService.GetExecutingAssembly()).AsImplementedInterfaces().InstancePerDependency();

        //    //控制器注入
        //    builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

        //    var container = builder.Build();
        //    //设置WebApi依赖解释器    
        //    //DependencyResolver.SetResolver(new AutofacWebApiDependencyResolver(container));
        //    GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        //}

        #endregion

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
            {
                Response.End();
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码 
            Exception ex = Server.GetLastError().GetBaseException();
            Logger.Fatal("系统出错", ex);
        }

    }

    #region Castle.Windsor

    internal sealed class WindsorDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IWindsorContainer _container;

        public WindsorDependencyResolver(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            _container = container;
        }
        public object GetService(Type t)
        {
            return _container.Kernel.HasComponent(t) ? _container.Resolve(t) : null;
        }

        public IEnumerable<object> GetServices(Type t)
        {
            return _container.ResolveAll(t).Cast<object>().ToArray();
        }

        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(_container);
        }

        public void Dispose()
        {

        }
    }

    internal class WindsorDependencyScope : IDependencyScope
    {
        private readonly IWindsorContainer _container;
        private readonly IDisposable _scope;

        public WindsorDependencyScope(IWindsorContainer container)
        {
            this._container = container;
            this._scope = container.BeginScope();
        }

        public object GetService(Type serviceType)
        {
            if (_container.Kernel.HasComponent(serviceType))
                return _container.Resolve(serviceType);
            else
                return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this._container.ResolveAll(serviceType).Cast<object>();
        }

        public void Dispose()
        {
            this._scope.Dispose();
        }
    }

    public class WebApiInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                               .BasedOn<IHttpController>()
                               .LifestylePerWebRequest());
            container.Register(
                Component.For<IDapperContext>()
                .UsingFactoryMethod(x => new DapperContext())
                .LifestylePerWebRequest());
            container.Register(
                Classes.FromAssembly(AnesWorkStationInstaller.GetExecutingAssembly())
                .Pick()
                .WithServiceAllInterfaces()
                .LifestylePerWebRequest());
        }
    }

    #endregion

}