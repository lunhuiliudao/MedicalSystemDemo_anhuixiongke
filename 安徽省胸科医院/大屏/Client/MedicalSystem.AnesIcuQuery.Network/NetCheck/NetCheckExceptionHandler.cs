using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Data.Common;

namespace MedicalSystem.MedScreen.Network
{
    public class NetCheckExceptionHandler
    {
        public static bool IsNetCheckShowFlag = false;

        public static void Handle(Exception e, bool showError)
        {
            string logEntity = ExceptionHandler.ExtractLogEntityFromException(e);
            Logger.Write(logEntity);
            if (!IsNetCheckShowFlag)
            {
                IsNetCheckShowFlag = true;
                NetChecking.CheckNet();
                IsNetCheckShowFlag = false;
            }
        }
    }
}
