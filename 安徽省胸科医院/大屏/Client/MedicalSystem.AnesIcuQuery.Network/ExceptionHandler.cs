using MedicalSystem.AnesIcuQuery.Network;
using MedicalSystem.MedScreen.Controls;
using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net.Http;
using System.Net;

namespace MedicalSystem.MedScreen.Network
{
    public class ExceptionHandler
    {
        public static void Handle(Exception e)
        {
            Handle(e, true);
        }

        public static void Handle(Exception e, bool showError)
        {
            //Oracle SQL Server
            if (e.Message.Contains("ORA-12560") || e.Message.Contains("ORA-03113") || e.Message.Contains("ORA-12170") || e.Message.Contains("ORA-12571") || e.Message.Contains("指定的网络名不再可用"))
            {

                ExtendAppContext.Current.NetStatus = NetStatus.DisConnected;

                NetCheckExceptionHandler.Handle(e, showError);

            }
            else if (e.Message.Contains("在位置 0 处没有任何行") || e.Message.Contains("ORA-12514: TNS: 监听程序当前无法识别连接描述符中请求的服务")
                || e.Message.Contains("ORA-03135: 连接失去联系") || e.Message.Contains("ORA-03114: 未连接到 ORALCE"))
            {
                //判断是否是网络中断之后造成的
                NetChecking.CheckDataBaseNetImmediately();

                if (ExtendAppContext.Current.NetStatus == NetStatus.Connected)
                {
                    if (showError)
                    {
                        //AutoClosedMsgBox.Show(e.Message, "提示信息",3000, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                string logEntity = ExtractLogEntityFromException(e);
                Logger.Write(logEntity);
            }
            else if (e.Message.Contains("发生一个或多个错误") || e.Message.Contains("One or more errors occurred")
                || e is HttpRequestException || e is WebException || e is SocketException
                || e.InnerException != null && (e.InnerException is HttpRequestException || e.InnerException is WebException || e.InnerException is SocketException))
            {
                //AutoClosedMsgBox.Show(e.Message + "\r\n发生该错误的原因可能是:\r\n1、表或视图不存在。\r\n2、无法连接到Web服务。\r\n3、网络不稳定导致网络中断。", "提示信息",3000, MessageBoxButtons.OK, MessageBoxIcon.Error);
                string logEntity = ExtractLogEntityFromException(e);
                Logger.Write(logEntity);
            }
            else
            {
                if (showError)
                {
                    //AutoClosedMsgBox.Show(e.Message, "提示信息", 3000,MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string logEntity = ExtractLogEntityFromException(e);
                Logger.Write(logEntity);
            }

        }
        public static string ExtractLogEntityFromException(Exception e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(string.Format("Time:{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            stringBuilder.AppendLine(string.Format("Message:{0}", e.Message));
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
