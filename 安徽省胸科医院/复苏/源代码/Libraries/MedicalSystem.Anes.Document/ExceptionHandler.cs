using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Document
{
   public class ExceptionHandler
    {

       
       public static void Handle(Exception e)
       {
           Handle(e,true);
       }

       public static void Handle(Exception e,bool showError)
       {

       }
       public static string ExtractLogEntityFromException(Exception e)
       {
           StringBuilder stringBuilder = new StringBuilder();

           stringBuilder.AppendLine(string.Format("Time:{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
           stringBuilder.AppendLine(string.Format("Message:{0}",e.Message));
           stringBuilder.AppendLine(string.Format("Source:{0}", e.Source));
           stringBuilder.AppendLine(string.Format("StackTrace:{0}", e.StackTrace));
           stringBuilder.AppendLine("=========================================================================");

           if (e.InnerException != null)
           {
               stringBuilder.AppendLine(ExtractLogEntityFromException(e.InnerException));
           }
           return stringBuilder.ToString();
           
           

       }
    }
}
