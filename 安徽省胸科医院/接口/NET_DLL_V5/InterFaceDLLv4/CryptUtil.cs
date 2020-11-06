using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using InterFaceV5;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO; 

namespace InterFaceV5
{
    public class CryptUtil
    {
        /// <summary>
        /// 密码解密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string DecryptString(string input)
        {
            if (input.Equals(string.Empty))
            {
                return input;
            } 
            byte[] byKey = { 0x63, 0x68, 0x65, 0x6E, 0x79, 0x75, 0x61, 0x6E };
            byte[] IV = { 0xFE, 0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x10 };
            byte[] inputByteArray = new Byte[input.Length];
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(input);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            Encoding encoding = new UTF8Encoding();
            return encoding.GetString(ms.ToArray());
        }
        /// <summary>
        /// 密码加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string EncryptString(string input)
        {
            if (input.Equals(string.Empty))
            {
                return input;
            }

            byte[] byKey = { 0x63, 0x68, 0x65, 0x6E, 0x79, 0x75, 0x61, 0x6E };
            byte[] IV = { 0xFE, 0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x10 };
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(input);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
        /**/
        /// <summary>
        /// DES + Base64 加密
        /// </summary>
        /// <param name="input">明文字符串</param>
        /// <returns>已加密字符串</returns>
        public static string DesBase64Encrypt(string input)
        {
            System.Security.Cryptography.DES des = System.Security.Cryptography.DES.Create();
            des.Mode = System.Security.Cryptography.CipherMode.ECB;
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;
            byte[] Key = new byte[8] { 56, 50, 55, 56, 56, 55, 49, 49 };
            byte[] IV = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

            ct = des.CreateEncryptor(Key, IV);

            byt = Encoding.GetEncoding("GB2312").GetBytes(input); //根据 GB2312 编码对字符串处理，转换成 byte 数组

            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();

            cs.Close();

            byte[] answer = ms.ToArray();
            for (int j = 0; j < answer.Length; j++)
            {
                Console.Write(answer[j].ToString() + " ");
            }
            Console.WriteLine();
            return Convert.ToBase64String(ms.ToArray()); // 将加密的 byte 数组依照 Base64 编码转换成字符串
        }

        /**/
        /// <summary>
        /// DES + Base64 解密
        /// </summary>
        /// <param name="input">密文字符串</param>
        /// <returns>解密字符串</returns>
        public static string DesBase64Decrypt(string input)
        {
            System.Security.Cryptography.DES des = System.Security.Cryptography.DES.Create();
            des.Mode = System.Security.Cryptography.CipherMode.ECB;
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;
            byte[] Key = new byte[8] { 56, 50, 55, 56, 56, 55, 49, 49 };
            byte[] IV = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

            ct = des.CreateDecryptor(Key, IV);
            byt = Convert.FromBase64String(input); // 将 密文 以 Base64 编码转换成 byte 数组

            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();

            cs.Close();

            return Encoding.GetEncoding("GB2312").GetString(ms.ToArray()); // 将 明文 以 GB2312 编码转换成字符串
        }

 

        /**/
        /// <summary>
        /// DES + Base64 加密
        /// </summary>
        /// <param name="input">明文字符串</param>
        /// <returns>已加密字符串</returns>
        public static string DesBase64EncryptForID5(string input)
        {
            System.Security.Cryptography.DES des = System.Security.Cryptography.DES.Create();
            des.Mode = System.Security.Cryptography.CipherMode.CBC;
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;
            byte[] Key = new byte[8] { 56, 50, 55, 56, 56, 55, 49, 49 };
            byte[] IV = new byte[8] { 56, 50, 55, 56, 56, 55, 49, 49 };

            ct = des.CreateEncryptor(Key, IV);

            byt = Encoding.GetEncoding("GB2312").GetBytes(input); //根据 GB2312 编码对字符串处理，转换成 byte 数组

            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();

            cs.Close();

            byte[] answer = ms.ToArray();
            for (int j = 0; j < answer.Length; j++)
            {
                Console.Write(answer[j].ToString() + " ");
            }
            Console.WriteLine();
            return Convert.ToBase64String(ms.ToArray()); // 将加密的 byte 数组依照 Base64 编码转换成字符串
        }

        /**/
        /// <summary>
        /// DES + Base64 解密
        /// </summary>
        /// <param name="input">密文字符串</param>
        /// <returns>解密字符串</returns>
        public static string DesBase64DecryptForID5(string input)
        {
            System.Security.Cryptography.DES des = System.Security.Cryptography.DES.Create();
            des.Mode = System.Security.Cryptography.CipherMode.CBC;
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;
            byte[] Key = new byte[8] { 56, 50, 55, 56, 56, 55, 49, 49 };
            byte[] IV = new byte[8] { 56, 50, 55, 56, 56, 55, 49, 49 };

            ct = des.CreateDecryptor(Key, IV);
            byt = Convert.FromBase64String(input); // 将 密文 以 Base64 编码转换成 byte 数组

            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();

            cs.Close();

            return Encoding.GetEncoding("GB2312").GetString(ms.ToArray()); // 将 明文 以 GB2312 编码转换成字符串
        }

        /**/
        /// <summary>
        /// 3DES 加密 Byte[] to HEX string
        /// </summary>
        /// <param name="input">明文字符串</param>
        /// <returns>已加密字符串</returns>
        public static string ThreeDesEncryptHEX(string input)
        {
            string result = "";
            System.Security.Cryptography.TripleDES des = System.Security.Cryptography.TripleDES.Create();
            des.Mode = System.Security.Cryptography.CipherMode.CBC;
            des.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;
            byte[] Key = new byte[24]{
                                       1,2,3,4,5,6,
                                       1,2,3,4,5,6,
                                       1,2,3,4,5,6,
                                       1,2,3,4,5,6
                                   };
            byte[] IV = new byte[8] { 1, 2, 3, 4, 5, 6, 1, 2 };

            ct = des.CreateEncryptor(Key, IV);

            byt = Encoding.GetEncoding("GB2312").GetBytes(input); //根据 GB2312 编码对字符串处理，转换成 byte 数组

            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();

            cs.Close();

            byte[] answer = ms.ToArray();
            for (int j = 0; j < answer.Length; j++)
            {
                result += answer[j].ToString("x").PadLeft(2, '0');
            }
            return result;
        }

        /**/
        /// <summary>
        /// 3DES + HEX to byte[] 解密
        /// </summary>
        /// <param name="input">密文字符串</param>
        /// <returns>解密字符串</returns>
        public static string ThreeDesDecryptHEX(string input)
        {
            System.Security.Cryptography.TripleDES des = System.Security.Cryptography.TripleDES.Create();
            des.Mode = System.Security.Cryptography.CipherMode.CBC;
            des.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] Key = new byte[24]{
                                       1,2,3,4,5,6,
                                       1,2,3,4,5,6,
                                       1,2,3,4,5,6,
                                       1,2,3,4,5,6
                                   };
            byte[] IV = new byte[8] { 1, 2, 3, 4, 5, 6, 1, 2 };

            ct = des.CreateDecryptor(Key, IV);
            //byt = Convert.FromBase64String(input); // 将 密文 以 HEX to byte[]编码转换成 byte 数组
            if (input.Length <= 1)
            {
                throw new Exception("encrypted HEX string is too short!");
            }
            byte[] byt = new byte[input.Length / 2];
            for (int i = 0; i < byt.Length; i++)
            {
                //Console.WriteLine(input.Substring(i*2,2));
                byt[i] = Convert.ToByte(input.Substring(i * 2, 2), 16);
            }

            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();

            cs.Close();

            return Encoding.GetEncoding("GB2312").GetString(ms.ToArray()); // 将 明文 以 GB2312 编码转换成字符串
        }
        /**/
        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="base64Str"></param>
        /// <returns></returns>
        public static string DecodingFromBase64(string base64Str)
        {
            Byte[] bytes = Convert.FromBase64String(base64Str);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }
        /**/
        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EncodingToBase64(string str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }
        /**/
        /// <summary>
        /// 根据指定的编码方式Base64解码
        /// </summary>
        /// <param name="base64Str"></param>
        /// <param name="strEncoding"></param>
        /// <returns></returns>
        public static string DecodingFromBase64(string base64Str, System.Text.Encoding strEncoding)
        {
            Byte[] bytes = Convert.FromBase64String(base64Str);
            return strEncoding.GetString(bytes);
        }
        /**/
        /// <summary>
        /// 根据指定的编码方式Base64编码
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strEncoding"></param>
        /// <returns></returns>
        public static string EncodingToBase64(string str, System.Text.Encoding strEncoding)
        {
            return Convert.ToBase64String(strEncoding.GetBytes(str));
        }
    }
 
}
