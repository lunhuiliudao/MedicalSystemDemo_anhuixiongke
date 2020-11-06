using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// �ַ�������
    /// </summary>
    public class StringManage
    {
        /// <summary>
        /// ����תƴ����д        
        /// </summary>
        /// <param name="str">Ҫת���ĺ����ַ���</param>
        /// <returns>ƴ����д</returns>
        public static String GetPYString(String str)
        {
            String TempStr = "";
            foreach (char Chr in str)
            {
                if ((int)Chr >= 33 && (int)Chr <= 126)
                {
                    //��ĸ�ͷ���ԭ������
                    TempStr += Chr.ToString();
                }
                else if ((int)Chr == 12288)
                {
                    //��ȫ�ǿո�ת��Ϊ��ǿո�
                    TempStr += (char)32;
                }
                else if ((int)Chr > 65280 && (int)Chr < 65375)
                {
                    //��ȫ�Ƿ���ת��Ϊ��Ƿ���
                    TempStr += (char)((int)Chr - 65248);
                }
                else
                {//�ۼ�ƴ����ĸ
                    TempStr += GetPYChar(Chr.ToString());
                }
            }
            return TempStr;
        }
        /// <summary>
        /// ����תƴ����д        
        /// </summary>
        /// <param name="str">Ҫת���ĺ����ַ���</param>
        /// <param name="maxLength">ת������󳤶�</param>
        /// <returns>ƴ����д</returns>
        public static String GetPYString(String str, int maxLength)
        {
            String TempStr = "";
            TempStr = GetPYString(str);
            if (TempStr.Length > maxLength)
            {
                TempStr = TempStr.Substring(0, 8);
            }
            return TempStr;
        }

        public static bool IsChinese(string str)
        {
            return str.CompareTo("߹") >= 0;
        }

        /// <summary>
        /// ȡ�����ַ���ƴ����ĸ        
        /// </summary>
        /// <param name="c">Ҫת���ĵ�������</param>
        /// <returns>ƴ����ĸ</returns>
        public static String GetPYChar(String str)
        {
            if (str.CompareTo("߹") < 0) return str;
            if (str.CompareTo("��") < 0) return "A";
            if (str.CompareTo("��") < 0) return "B";
            if (str.CompareTo("��") < 0) return "C";
            if (str.CompareTo("��") < 0) return "D";
            if (str.CompareTo("��") < 0) return "E";
            if (str.CompareTo("�") < 0) return "F";
            if (str.CompareTo("��") < 0) return "G";
            if (str.CompareTo("��") < 0) return "H";
            if (str.CompareTo("��") < 0) return "J";
            if (str.CompareTo("��") < 0) return "K";
            if (str.CompareTo("�`") < 0) return "L";
            if (str.CompareTo("��") < 0) return "M";
            if (str.CompareTo("��") < 0) return "N";
            if (str.CompareTo("�r") < 0) return "O";
            if (str.CompareTo("��") < 0) return "P";
            if (str.CompareTo("��") < 0) return "Q";
            if (str.CompareTo("��") < 0) return "R";
            if (str.CompareTo("��") < 0) return "S";
            if (str.CompareTo("��") < 0) return "T";
            if (str.CompareTo("Ϧ") < 0) return "W";
            if (str.CompareTo("Ѿ") < 0) return "X";
            if (str.CompareTo("��") < 0) return "Y";
            if (str.CompareTo("��") < 0) return "Z";
            return str;
        }
        #region ��ȡ�ַ�����ʵ���ֽڳ��ȵķ���
        /// <summary>
        /// ��ȡ�ַ�����ʵ���ֽڳ��ȵķ���
        /// </summary>
        /// <param name="source">�ַ���</param>
        /// <returns>ʵ�ʳ���</returns>
        public static int GetRealLength(string source)
        {
            return Encoding.Default.GetByteCount(source);
        }
        #endregion

        #region ���ֽ�����ȡ�ַ����ķ���
        /// <summary>
        /// ���ֽ�����ȡ�ַ����ķ���
        /// </summary>
        /// <param name="source">Ҫ��ȡ���ַ���</param>
        /// <param name="n">Ҫ��ȡ���ֽ���</param>
        /// <param name="needEndDot">�Ƿ���Ҫ��β��ʡ�Ժ�</param>
        /// <returns>��ȡ����ַ���</returns>
        public static string SubString(string source, int n, bool needEndDot)
        {
            string Result = string.Empty;
            if (GetRealLength(source) <= n)//������ȱ���Ҫ�ĳ���nС,����ԭ�ַ���
            {
                return source;
            }
            else
            {
                int j = 0;
                char[] ChrList = source.ToCharArray();
                for (int i = 0; i < ChrList.Length && j < n; i++)
                {

                    if ((int)ChrList[i] > 127)//�Ƿ���
                    {
                        Result += ChrList[i];
                        j += 2;
                    }
                    else
                    {
                        Result += ChrList[i];
                        j++;
                    }
                }
                if (GetRealLength(Result) > n)
                {
                    Result = Result.Remove(Result.Length - 1, 1);
                }
                if (needEndDot)
                    Result += "...";
                return Result;
            }
        }
        #endregion
    }
}
