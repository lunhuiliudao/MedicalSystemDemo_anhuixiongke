using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Threading;
using MedicalSystem.AnesIcuQuery.Network;

namespace MedicalSystem.MedScreen.Network
{
    public class NetChecking
    {

        public static void CheckNet()
        {
            if (ExtendAppContext.Current.ThreadNetCheck == null)
            {
                ExtendAppContext.Current.ThreadNetCheck = new Thread(new ThreadStart(DataBaseNetChecking));
                ExtendAppContext.Current.ThreadNetCheck.Name = "NetCheckingThread";
                ExtendAppContext.Current.ThreadNetCheck.IsBackground = true;
                ExtendAppContext.Current.ThreadNetCheck.Start();
            }
            else
            {
                if (ExtendAppContext.Current.ThreadNetCheck.IsAlive)
                {
                    ExtendAppContext.Current.ThreadNetCheck.Resume();
                }
            }
        }
        public static bool CheckDataBaseNetImmediately()
        {
            try
            {
                DateTime now = DataOperator.HttpWebApi<DateTime>(ApiUrlEnum.GetServerDateTime, null);
                long l1 = now.Millisecond;
                DataOperator.HttpWebApi<bool>(ApiUrlEnum.TestNet, null);
                ExtendAppContext.Current.NetStatus = NetStatus.Connected;
                long l2 = now.Millisecond;
                Console.WriteLine("CheckDataBaseNetImmediately 耗时 "+ (l2 - l1).ToString()  + "毫秒 ");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("网络连接测试，异常：" + ex.ToString());
                ExtendAppContext.Current.NetStatus = NetStatus.DisConnected;
                return false ;
            }
        }

        private static void DataBaseNetChecking()
        {
            bool bNeedTest = true;
            int iNetConnectedCount = 0;
            while (bNeedTest)
            {
                try
                {
                    NetCheck check = new NetCheck();
                    check.ShowDialog();
                    DataOperator.HttpWebApi<bool>(ApiUrlEnum.TestNet, null);
                    iNetConnectedCount += 1;
                    if (iNetConnectedCount >= 2)
                    {
                        ExtendAppContext.Current.NetStatus = NetStatus.Connected;
                        bNeedTest = false;
                        Thread.CurrentThread.Suspend();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("网络连接测试，异常：" + ex.ToString());
                    ExtendAppContext.Current.NetStatus = NetStatus.DisConnected;
                    iNetConnectedCount = 0;
                    bNeedTest = true;
                    Thread.Sleep(5000);
                }
            }
        }
    }
}
