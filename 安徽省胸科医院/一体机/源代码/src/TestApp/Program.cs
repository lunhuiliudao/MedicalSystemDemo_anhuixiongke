using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Components.DictionaryAdapter;
using Castle.DynamicProxy;

namespace TestApp
{
    class Program
    {
        public Program()
        {
            ProxyGenerator generator = new ProxyGenerator();//实例化【代理类生成器】  
            SimpleInterceptor interceptor = new SimpleInterceptor();//实例化【拦截器】  

            //使用【代理类生成器】创建Person对象，而不是使用new关键字来实例化  
            Program person = generator.CreateClassProxy<Program>(interceptor);
            person = this;
            if (person.SayHello == "aaa")
            {
                Console.Write("aaa");
            }

        }
        static void Main(string[] args)
        {
            Console.Read();
        }


    }

    public class Person
    {
        public virtual string SayHello { get; set; }

    }

    public class SimpleInterceptor : IInterceptor
    {
        #region IInterceptor 成员

        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            //if (invocation.ReturnValue == null)
            //{
            //    invocation.ReturnValue = "123";
            //}
        }

        #endregion
    }
}
