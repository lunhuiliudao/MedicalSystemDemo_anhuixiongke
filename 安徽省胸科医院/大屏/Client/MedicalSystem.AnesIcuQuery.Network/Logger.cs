using System;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.MedScreen.Controls;
using MedicalSystem.AnesIcuQuery.Network;

namespace MedicalSystem.MedScreen.Network
{
    public class Logger
    {
        private static object _object = new object();

        public static void Write(string logEntity)
        {
            if (!System.IO.Directory.Exists(string.Format(@"{0}\Log", Application.StartupPath)))
                System.IO.Directory.CreateDirectory(string.Format(@"{0}\Log", Application.StartupPath));
            SyncLoggerWriter logWriter = new SyncLoggerWriter(WriteLog);
            logWriter.BeginInvoke(logEntity, new AsyncCallback(CallBack), logWriter);
        }

        private static void CallBack(IAsyncResult result)
        {
            SyncLoggerWriter writer = result.AsyncState as SyncLoggerWriter;
            writer.EndInvoke(result);
        }

        private static void WriteLog(string logEntity)
        {
            try
            {
                lock (_object)
                {
                    //DateTime now = MedicalSystem.AnesIcuQuery.Network.DataOperator.HttpWebApi<DateTime>(ApiUrlEnum.GetServerDateTime, null);
                    DateTime now = DateTime.Now;
                    DateTime today = Convert.ToDateTime(now.ToString("yyyy-MM-dd"));
                    System.IO.File.AppendAllText(string.Format(@"{0}\Log\{1}.txt", Application.StartupPath,
                               today.ToString("yyyyMMdd")), logEntity + Environment.NewLine, Encoding.Default);
                }
            }
            catch (Exception e)
            {
                AutoClosedMsgBox.Show(e.Message, "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        delegate void SyncLoggerWriter(string logEntity);
    }
}
