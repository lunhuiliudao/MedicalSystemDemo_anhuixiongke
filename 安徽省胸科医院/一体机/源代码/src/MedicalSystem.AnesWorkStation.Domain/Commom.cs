using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public static class Commom
    {
        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="Source">待加密的串</param>
        /// <returns>经过加密的串</returns>
        public static string MD5Encry(string Source)
        {
            byte[] bt = UTF8Encoding.UTF8.GetBytes(Source);//UTF8需要对Text的引用
            MD5CryptoServiceProvider objMD5;
            objMD5 = new MD5CryptoServiceProvider();
            byte[] output = objMD5.ComputeHash(bt);

            string[] password = BitConverter.ToString(output).Split(new char[] { '-' });
            string returnValue = "";
            for (int index = 0; index < password.Length; index++)
                returnValue += password[index];
            returnValue = returnValue.ToUpper();
            return returnValue;
        }


        /// <summary>
        /// base64编码
        /// </summary>
        /// <returns></returns>
        public static string Base64Encode(string value)
        {
            string result = Convert.ToBase64String(Encoding.Default.GetBytes(value));
            return result;
        }
        /// <summary>
        /// base64解码
        /// </summary>
        /// <returns></returns>
        public static string Base64Decode(string value)
        {
            string result = Encoding.Default.GetString(Convert.FromBase64String(value));
            return result;
        }

    }
}
