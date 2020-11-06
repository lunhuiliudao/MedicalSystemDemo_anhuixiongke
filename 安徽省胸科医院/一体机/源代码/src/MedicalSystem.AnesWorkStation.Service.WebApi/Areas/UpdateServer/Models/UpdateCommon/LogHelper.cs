using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UpdateCommon
{
    public class LogHelper
    {
        public static void writeLog(string log)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\Log\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = @"\Log\" + DateTime.Now.ToString("yyyy-MM-dd") + "Log.txt";
            String logFilePath = AppDomain.CurrentDomain.BaseDirectory + fileName;

            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                fs = new FileStream(logFilePath, FileMode.Append);
                if (fs.Length > 1000 * 1000 * 3)
                {
                    if (sw != null)
                    {
                        sw.Flush();

                        sw.Close();
                    }

                    if (fs != null)
                    {
                        fs.Close();
                    }

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    File.Move(logFilePath,
                              path + DateTime.Now.ToString("yyyyMMddmm") +
                              "_" + fileName);
                    fs = new FileStream(logFilePath, FileMode.Append);
                }
                sw = new StreamWriter(fs);

                sw.WriteLine(DateTime.Now.ToString() + " :    " + log);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();

                    sw.Close();
                }

                if (fs != null)
                {
                    fs.Close();
                }
            }
        }
    }
}
