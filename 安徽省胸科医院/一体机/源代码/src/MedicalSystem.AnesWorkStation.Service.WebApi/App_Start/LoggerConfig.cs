using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MedicalSystem.AnesWorkStation.Service.WebApi
{
    public class LoggerConfig : ILog
    {
        #region Log4net

        private const string AppSettingsKey = "Logger";
        private static LoggerConfig log = null;
        private ILog Logger { get; set; }

        public static LoggerConfig GetLogger(Type type)
        {
            if (log == null)
            {
                log = new LoggerConfig();
            }
            if (log.Logger == null)
            {
                bool flag;
                if (ConfigurationManager.AppSettings != null
                    && ConfigurationManager.AppSettings[AppSettingsKey] != null
                    && bool.TryParse(ConfigurationManager.AppSettings[AppSettingsKey], out flag)
                    && flag)
                {
                    log.Logger = LogManager.GetLogger(type);
                }
            }

            return log;
        }

        #region Method


        public void Debug(object message, Exception exception)
        {
            if (Logger != null)
            {
                Logger.Debug(message, exception);
            }
        }

        public void Debug(object message)
        {
            if (Logger != null)
            {
                Logger.Debug(message);
            }
        }

        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (Logger != null)
            {
                Logger.DebugFormat(provider, format, args);
            }
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            if (Logger != null)
            {
                Logger.DebugFormat(format, arg0, arg1, arg2);
            }
        }

        public void DebugFormat(string format, object arg0, object arg1)
        {
            if (Logger != null)
            {
                Logger.DebugFormat(format, arg0, arg1);
            }
        }

        public void DebugFormat(string format, object arg0)
        {
            if (Logger != null)
            {
                Logger.DebugFormat(format, arg0);
            }
        }

        public void DebugFormat(string format, params object[] args)
        {
            if (Logger != null)
            {
                Logger.DebugFormat(format, args);
            }
        }

        public void Error(object message, Exception exception)
        {
            if (Logger != null)
            {
                Logger.Error(message, exception);
            }
        }

        public void Error(object message)
        {
            if (Logger != null)
            {
                Logger.Error(message);
            }
        }

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (Logger != null)
            {
                Logger.ErrorFormat(provider, format, args);
            }
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            if (Logger != null)
            {
                Logger.ErrorFormat(format, arg0, arg1, arg2);
            }
        }

        public void ErrorFormat(string format, object arg0, object arg1)
        {
            if (Logger != null)
            {
                Logger.ErrorFormat(format, arg0, arg1);
            }
        }

        public void ErrorFormat(string format, object arg0)
        {
            if (Logger != null)
            {
                Logger.ErrorFormat(format, arg0);
            }
        }

        public void ErrorFormat(string format, params object[] args)
        {
            if (Logger != null)
            {
                Logger.ErrorFormat(format, args);
            }
        }

        public void Fatal(object message, Exception exception)
        {
            if (Logger != null)
            {
                Logger.Fatal(message, exception);
            }
        }

        public void Fatal(object message)
        {
            if (Logger != null)
            {
                Logger.Fatal(message);
            }
        }

        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (Logger != null)
            {
                Logger.FatalFormat(provider, format, args);
            }
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            if (Logger != null)
            {
                Logger.FatalFormat(format, arg0, arg1, arg2);
            }
        }

        public void FatalFormat(string format, object arg0, object arg1)
        {
            if (Logger != null)
            {
                Logger.FatalFormat(format, arg0, arg1);
            }
        }

        public void FatalFormat(string format, object arg0)
        {
            if (Logger != null)
            {
                Logger.FatalFormat(format, arg0);
            }
        }

        public void FatalFormat(string format, params object[] args)
        {
            if (Logger != null)
            {
                Logger.FatalFormat(format, args);
            }
        }

        public void Info(object message, Exception exception)
        {
            if (Logger != null)
            {
                Logger.Info(message, exception);
            }
        }

        public void Info(object message)
        {
            if (Logger != null)
            {
                Logger.Info(message);
            }
        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (Logger != null)
            {
                Logger.InfoFormat(provider, format, args);
            }
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            if (Logger != null)
            {
                Logger.InfoFormat(format, arg0, arg1, arg2);
            }
        }

        public void InfoFormat(string format, object arg0, object arg1)
        {
            if (Logger != null)
            {
                Logger.InfoFormat(format, arg0, arg1);
            }
        }

        public void InfoFormat(string format, object arg0)
        {
            if (Logger != null)
            {
                Logger.InfoFormat(format, arg0);
            }
        }

        public void InfoFormat(string format, params object[] args)
        {
            if (Logger != null)
            {
                Logger.InfoFormat(format, args);
            }
        }

        public bool IsDebugEnabled
        {
            get
            {
                if (Logger != null)
                {
                    return Logger.IsDebugEnabled;
                }
                return false;
            }
        }

        public bool IsErrorEnabled
        {
            get
            {
                if (Logger != null)
                {
                    return Logger.IsErrorEnabled;
                }
                return false;
            }
        }

        public bool IsFatalEnabled
        {
            get
            {
                if (Logger != null)
                {
                    return Logger.IsFatalEnabled;
                }
                return false;
            }
        }

        public bool IsInfoEnabled
        {
            get
            {
                if (Logger != null)
                {
                    return Logger.IsInfoEnabled;
                }
                return false;
            }
        }

        public bool IsWarnEnabled
        {
            get
            {
                if (Logger != null)
                {
                    return Logger.IsWarnEnabled;
                }
                return false;
            }
        }

        public void Warn(object message, Exception exception)
        {
            if (Logger != null)
            {
                Logger.Warn(message, exception);
            }
        }

        public void Warn(object message)
        {
            if (Logger != null)
            {
                Logger.Warn(message);
            }
        }

        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (Logger != null)
            {
                Logger.WarnFormat(provider, format, args);
            }
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            if (Logger != null)
            {
                Logger.WarnFormat(format, arg0, arg1, arg2);
            }
        }

        public void WarnFormat(string format, object arg0, object arg1)
        {
            if (Logger != null)
            {
                Logger.WarnFormat(format, arg0, arg1);
            }
        }

        public void WarnFormat(string format, object arg0)
        {
            if (Logger != null)
            {
                Logger.WarnFormat(format, arg0);
            }
        }

        public void WarnFormat(string format, params object[] args)
        {
            if (Logger != null)
            {
                Logger.WarnFormat(format, args);
            }
        }

        log4net.Core.ILogger log4net.Core.ILoggerWrapper.Logger
        {
            get
            {
                if (Logger != null)
                {
                    return Logger.Logger;
                }
                return null;
            }
        }

        #endregion

        #endregion

    }
}