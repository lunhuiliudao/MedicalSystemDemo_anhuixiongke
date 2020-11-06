using System;
using System.Collections.Generic;
using System.Text;
using MedicalSytem.Soft.DAL;
using MedicalSytem.Soft.Model;
using System.IO;

 
/// <summary>
/// 公用类
/// </summary>
namespace InitDocare
{
    public class LogA
    {
 
        
      
        #region Debug

        public static void InsertDB(string title, string module, string grade, string content, string source, string category, string currentUser)
        {
            MedIfLog log = new MedIfLog();
            log.Title = title;
            log.Module = module;
            log.Grade = grade;
            log.Content = content;
            log.Source = source;
            log.Category = category;
            log.IsShow = false.GetHashCode().ToString();
            log.Category = currentUser;
        }

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string  message)
        {
            string current = System.AppDomain.CurrentDomain.BaseDirectory + "\\sqllog\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "\\sqllog\\"))
            {
                Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "\\sqllog\\");
            }
            if (!File.Exists(current))
            {
                FileStream fs = new FileStream(current, FileMode.Create, FileAccess.Write);//创建写入文件      
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("-----------------------------------------------------------");
                sw.WriteLine("接口日志：时间 " + DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));
                sw.Write(message + "");
                sw.Close();
                fs.Close();
            }
            else
            {
                using (StreamWriter sw = File.AppendText(current))
                {
                    sw.WriteLine("-----------------------------------------------------------");
                    sw.WriteLine("接口日志：时间 " + DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));
                    sw.Write(message + "");
                    sw.Close();
                }
            }
           
        }

        public static void Debug(Exception ex)
        {
            string mes = ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n";
             Debug(mes);
        }

        public static void Debug(object message, Exception exp)
        {
           // log.Debug(message, exp);
        }

        public static void DebugFormat(string format, object arg0)
        {
           // log.DebugFormat(format, arg0);
        }

        public static void DebugFormat(string format, params object[] args)
        {
           // log.DebugFormat(format, args);
        }

        public static void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            //log.DebugFormat(provider, format, args);
        }

        public static void DebugFormat(string format, object arg0, object arg1)
        {
            //log.DebugFormat(format, arg0, arg1);
        }

        public static void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
          //  log.DebugFormat(format, arg0, arg1, arg2);
        }
        #endregion

        #region Error
        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message"></param>
        public static void Error(object message)
        {
           // log.Error(message);
        }

        public static void Error(object message, Exception exception)
        {
          //  log.Error(message, exception);
        }

        public static void ErrorFormat(string format, object arg0)
        {
           // log.ErrorFormat(format, arg0);
        }

        public static void ErrorFormat(string format, params object[] args)
        {
          //  log.ErrorFormat(format, args);
        }

        public static void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
          //  log.ErrorFormat(provider, format, args);
        }

        public static void ErrorFormat(string format, object arg0, object arg1)
        {
          //  log.ErrorFormat(format, arg0, arg1);
        }

        public static void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
          //  log.ErrorFormat(format, arg0, arg1, arg2);
        }
        #endregion

        #region Fatal
        /// <summary>
        /// 致命的,毁灭性的
        /// </summary>
        /// <param name="message"></param>
        public static void Fatal(object message)
        {
          //  log.Fatal(message);
        }

        public static void Fatal(object message, Exception exception)
        {
           // log.Fatal(message, exception);
        }

        public static void FatalFormat(string format, object arg0)
        {
           // log.FatalFormat(format, arg0);
        } 

        public static void FatalFormat(string format, params object[] args)
        {
           // log.FatalFormat(format, args);
        }

        public static void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
           // log.FatalFormat(provider, format, args);
        }

        public static void FatalFormat(string format, object arg0, object arg1)
        {
           // log.FatalFormat(format, arg0, arg1);
        }

        public static void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
           // log.FatalFormat(format, arg0, arg1, arg2);
        }
        #endregion

        #region Info

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message"></param>
        public static void Info(object message)
        {
            //log.Info(message);
        }

        public static void Info(object message, Exception exception)
        {
            //log.Info(message, exception);
        }

        public static void InfoFormat(string format, object arg0)
        {
           // log.InfoFormat(format, arg0);
        }

        public static void InfoFormat(string format, params object[] args)
        {
           // log.InfoFormat(format, args);
        }

        public static void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            //log.InfoFormat(provider, format, args);
        }

        public static void InfoFormat(string format, object arg0, object arg1)
        {
           // log.InfoFormat(format, arg0, arg1);
        }

        public static void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
           // log.InfoFormat(format, arg0, arg1, arg2);
        }
        #endregion

        #region Warn

        /// <summary>
        /// 警告,注意,通知
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(object message)
        {
           // log.Warn(message);
        }

        public static void Warn(object message, Exception exception)
        {
           // log.Warn(message, exception);
        }

        public static void WarnFormat(string format, object arg0)
        {
           // log.WarnFormat(format, arg0);
        }

        public static void WarnFormat(string format, params object[] args)
        {
           // log.WarnFormat(format, args);
        }

        public static void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
          //  log.WarnFormat(provider, format, args);
        }

        public static void WarnFormat(string format, object arg0, object arg1)
        {
           // log.WarnFormat(format, arg0, arg1);
        }

        public static void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
           // log.WarnFormat(format, arg0, arg1, arg2);
        }
        #endregion

        private static List<MedIfLog> logEntityList
        {
            get;
            set;
        }

        /// <summary>
        /// 新增一条日期记录
        /// </summary>
        /// <param name="category"></param>
        /// <param name="grade"></param>
        /// <param name="module"></param>
        /// <param name="coruce"></param>
        /// <param name="content"></param>
        /// <param name="currentUser"></param>
        /// <param name="title"></param>
        public static void ToLogCache(EmunLog.EnumTypeCategory category, EmunLog.EnumTypeGrade grade, EmunLog.EnumTypeModule module, InitDocare.EmunLog.EnumTypeSource source, string content, string currentUser, string title)
        {

            MedIfLog logEntity = new MedIfLog();
            logEntity.Category = category.ToString();
            logEntity.Content = content;
            logEntity.Date = DateTime.Now.ToString("yyyy-MM-dd");
            logEntity.Grade = grade.ToString();
            logEntity.Id = Guid.NewGuid().ToString();
            logEntity.IsShow = false.GetHashCode().ToString();
            logEntity.Module = module.ToString();
            logEntity.Source = source.ToString();
            logEntity.Time = DateTime.Now.ToString("HH:mm:ss");
            logEntity.Title = title;
            logEntity.CurrentUser = currentUser;

            List<MedIfLog> logEntityListTemp = logEntityList;
            if (logEntityListTemp == null)
            {
                logEntityListTemp = new List<MedIfLog>();
            }
            logEntityListTemp.Add(logEntity);
            logEntityList = logEntityListTemp;
        }

        /// <summary>
        /// 写入数据库
        /// </summary>
        public static void LogCommit()
        {
            if (logEntityList == null || logEntityList.Count == 0)
            {
                return;
            }
            string DateType = PublicA.GetConfig("DataServerType");
            try
            {
                //foreach (MedIfLog entity in logEntityList)
                //{
                //    if (DateType.Contains("OLE"))
                //    {
                //        MedicalSytem.Soft.DAL.DALMedIFLog.InsertMedifLogOleDb(entity);
                //    }
                //    else if (DateType.ToUpper().Contains("SQLSERVER"))
                //    {
                //        MedicalSytem.Soft.DAL.DALMedIFLog.InsertMedifLogSQL(entity);
                //    }
                //    else if (DateType.ToUpper().Contains("ORACLE"))
                //    {
                //        MedicalSytem.Soft.DAL.DALMedIFLog.InsertMedifLog(entity);
                //    }
                //}
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n");
            }
            ///插入完数据清理属性记录
            logEntityList = null;
        }
    }

}


