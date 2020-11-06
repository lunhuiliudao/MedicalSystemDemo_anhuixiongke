using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace MedicalSystem.Anes.FrameWork
{
    /// <summary>
    /// 加解密类
    /// </summary>
    public class DesSecurity
    {

        /// <summary>
        /// 加密原函数
        /// </summary>
        /// <param name="pToEncrypt">明文</param>
        /// <param name="sKey">密钥</param>
        /// <returns>返回密文</returns>
        public static string DesEncrypt(string pToEncrypt, string sKey)
        {
            if (string.IsNullOrEmpty(pToEncrypt) || string.IsNullOrEmpty(sKey))
                return null;
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Key = Encoding.ASCII.GetBytes(sKey.Substring(0, 8));
            des.IV = Encoding.ASCII.GetBytes(sKey.Substring(sKey.Length < 9 ? 0 : sKey.Length - 9, 8));
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            byte[] enc = des.CreateEncryptor().TransformFinalBlock(inputByteArray, 0, inputByteArray.Length);
            string sEnc = Convert.ToBase64String(enc);
            return sEnc;
        }

        /// <summary>
        /// 解密原函数
        /// </summary>
        /// <param name="pToDecrypt">密文</param>
        /// <param name="sKey">密钥</param>
        /// <returns>返回明文</returns>
        public static string DesDecrypt(string pToDecrypt, string sKey)
        {
            if (string.IsNullOrEmpty(pToDecrypt) || string.IsNullOrEmpty(sKey))
                return null;
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Key = Encoding.ASCII.GetBytes(sKey.Substring(0, 8));
            des.IV = Encoding.ASCII.GetBytes(sKey.Substring(sKey.Length < 9 ? 0 : sKey.Length - 9, 8));
            byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);
            byte[] dec = des.CreateDecryptor().TransformFinalBlock(inputByteArray, 0, inputByteArray.Length);
            return Encoding.Default.GetString(dec);
        }

        /// <summary>
        /// 对字符串进行Base64编码
        /// </summary>
        /// <param name="data">明文</param>
        /// <returns>Base64编码后的字符串</returns>
        public static string Encrypt(string data)
        {
            byte[] inputByteArray = Encoding.Default.GetBytes(data);
            byte[] enc = Encryptor.TransformFinalBlock(inputByteArray, 0, inputByteArray.Length);
            string sEnc = Convert.ToBase64String(enc);
            return sEnc;
        }

        /// <summary>
        /// 对Base64编码的字符串进行解码
        /// </summary>
        /// <param name="data">待解码的字符串</param>
        /// <returns>若为Base64编码，则解码后返回明文；否则直接返回参数data</returns>
        public static string Decrypt(string data)
        {
            if (IsBase64Encoded(data))
            {
                byte[] inputByteArray = Convert.FromBase64String(data);
                byte[] dec = Decryptor.TransformFinalBlock(inputByteArray, 0, inputByteArray.Length);
                return Encoding.Default.GetString(dec);
            }
            else
                return data;
        }

        /// <summary>
        /// 判断字符串是不是Base64编码
        /// </summary>
        /// <param name="Message">待判断的字符串</param>
        /// <returns>若为Base64编码，则返回true；否则返回false</returns>
        public static bool IsBase64Encoded(string Message)
        {
            if ((Message.Length % 4) != 0)
                return false;
            if (!System.Text.RegularExpressions.Regex.IsMatch(Message, "^[A-Z0-9/+=]*$", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                return false;
            return true;
        }

        private static DESCryptoServiceProvider desCSP;
        private static ICryptoTransform encryptor;
        private static ICryptoTransform decryptor;

        /// <summary>
        /// 返回对称加密器对象
        /// </summary>
        public static ICryptoTransform Encryptor
        {
            get
            {
                if (desCSP == null)
                {
                    desCSP = new DESCryptoServiceProvider();
                    if (desCSP.ValidKeySize(128) && Key.Length > 17)
                    {
                        desCSP.BlockSize = 128;
                        desCSP.Key = Encoding.ASCII.GetBytes(Key.Substring(0, 16));
                        desCSP.IV = Encoding.ASCII.GetBytes(Key.Substring(Key.Length - 17, 16));
                    }
                    else
                    {
                        desCSP.Key = Encoding.ASCII.GetBytes(Key.Substring(0, 8));
                        desCSP.IV = Encoding.ASCII.GetBytes(Key.Substring(Key.Length - 9, 8));
                    }
                }
                if (encryptor == null)
                {
                    encryptor = desCSP.CreateEncryptor();
                }
                return encryptor;
            }
        }

        /// <summary>
        /// 返回对称解密器对象
        /// </summary>
        public static ICryptoTransform Decryptor
        {
            get
            {
                if (desCSP == null)
                {
                    desCSP = new DESCryptoServiceProvider();
                    if (desCSP.ValidKeySize(128) && Key.Length > 17)
                    {
                        desCSP.BlockSize = 128;
                        desCSP.Key = Encoding.ASCII.GetBytes(Key.Substring(0, 16));
                        desCSP.IV = Encoding.ASCII.GetBytes(Key.Substring(Key.Length - 17, 16));
                    }
                    else
                    {
                        desCSP.Key = Encoding.ASCII.GetBytes(Key.Substring(0, 8));
                        desCSP.IV = Encoding.ASCII.GetBytes(Key.Substring(Key.Length - 9, 8));
                    }
                }
                if (decryptor == null)
                {
                    decryptor = desCSP.CreateDecryptor();
                }
                return decryptor;
            }
        }

        private static string key;

        /// <summary>
        /// 获取密钥
        /// </summary>
        public static string Key
        {
            get
            {
                if (string.IsNullOrEmpty(key))
                    key = KeyString();
                return key;
            }
        }

        public static string authFileName = System.Environment.SystemDirectory + @"\heightsoft.key";
        /// <summary>
        /// 获取解密密码
        /// </summary>
        /// <returns>若授权正常，则返回密钥；否则返回null</returns>
        public static string KeyString()
        {
            string fileName = authFileName;
            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string encCode = sr.ReadLine();
                    string savedhdSN = sr.ReadLine();
                    string hdSN = GetHDSerialNumber();
                    string check = sr.ReadLine();
                    string Datetimes = sr.ReadLine();
                    if (string.IsNullOrEmpty(hdSN) || hdSN == savedhdSN)
                    {
                        string code = DesDecrypt(encCode, hdSN);
                        Datetimes = DesDecrypt(Datetimes, hdSN);
                        if (DesDecrypt(check, code) == hdSN)
                        {
                            if (Convert.ToDateTime(Datetimes) < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                            {
                                return code = "old";
                            }
                            return code;
                        }
                    }
                    return null;
                }
            }
            else
                // 处理没有配置文件的情况
                return null;
        }

        public static void WriteAuthenticationFile(string code)
        {

            string fileName = authFileName;
            string hdSN = DesSecurity.GetHDSerialNumber();
            if (string.IsNullOrEmpty(hdSN))
                hdSN = "Abc23l1z";
            string enc = DesSecurity.DesEncrypt(code, hdSN);
            string check = DesSecurity.DesEncrypt(hdSN, code);
            string datetimes = DesSecurity.DesEncrypt("2110-3-31", hdSN);
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine(enc);
                sw.WriteLine(hdSN);
                sw.WriteLine(check);
                sw.WriteLine(datetimes);
            }
        }

        /// <summary>
        /// 获取C盘的卷标号
        /// </summary>
        /// <returns>返回C盘的卷标号</returns>
        public static string GetHDSerialNumber()
        {
            string str = "";
            ManagementClass mcHD = new ManagementClass("win32_logicaldisk");
            ManagementObjectCollection mocHD = mcHD.GetInstances();
            foreach (ManagementObject m in mocHD)
            {
                if (m["DeviceID"].ToString() == "C:")
                {
                    str = m["VolumeSerialNumber"].ToString();
                    break;
                }
            }
            return "11111111";
        }
    }
}
