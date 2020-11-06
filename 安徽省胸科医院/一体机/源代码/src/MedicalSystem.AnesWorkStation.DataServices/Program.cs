using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    class Program
    {
        static void Main(string[] args)
        {
            // 客户端采用动态代理方式调用。
            var a = CommonService.ClientInstance.TestNet();
            var b = CommonService.ClientInstance.TestDbConn();
            var user = AccountService.ClientInstance.Login("2771246", "C4CA4238A0B923820DCC509A6F75849B");
            var changePWD = AccountService.ClientInstance.ChangePwd("2771246", "C4CA4238A0B923820DCC509A6F75849B", "C4CA4238A0B923820DCC509A6F75849B");

            Console.Read();
        }

    }

}
