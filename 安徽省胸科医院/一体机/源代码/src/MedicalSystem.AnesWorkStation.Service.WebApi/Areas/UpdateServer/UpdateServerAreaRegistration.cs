using System.Web.Mvc;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Areas.UpdateServer
{
    public class UpdateServerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "UpdateServer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "UpdateServer_default",
                "UpdateServer/{controller}/{action}/{id}",
                new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
