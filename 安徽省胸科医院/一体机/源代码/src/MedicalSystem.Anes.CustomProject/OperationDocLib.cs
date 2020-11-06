// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      OperationDocLib.cs
// 功能描述(Description)：    文书加载的逻辑处理类
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.Document.Configurations;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.FrameWork;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace MedicalSystem.Anes.CustomProject
{
    public class OperationDocLib
    {
        /// <summary>
        /// 根据文书名称获取文书的PDF图片
        /// </summary>
        /// <param name="docName">文书名称</param>
        public List<Image> GetAnesDocImageList(string docName)
        {
            Dictionary<string, MedicalDocElement> docs = MedicalDocSettings.GetMedicalDocNameAndPath();
            KeyValuePair<string, MedicalDocElement> keyValuePairDoc = new KeyValuePair<string, MedicalDocElement>();
            foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docs)
            {
                if (keyValuePair.Key.Trim() == docName.Trim())
                {
                    keyValuePairDoc = keyValuePair;
                    break;
                }
            }

            Type t = Type.GetType(keyValuePairDoc.Value.Type);
            BaseDoc baseDoc = Activator.CreateInstance(t) as BaseDoc;
            baseDoc.BackColor = Color.White;
            baseDoc.Name = docName;
            ExtendAppContext.Current.CurrentDocName = docName;
            baseDoc.Initial();
            long l1 = System.DateTime.Now.Ticks;
            string path = null;
            if (MedicalDocSettings.GetMedicalDocNameAndPath().ContainsKey(docName))
            {
                path = MedicalDocSettings.GetMedicalDocNameAndPath()[docName].Path;
                baseDoc.LoadReport(Path.Combine(ExtendAppContext.Current.AppPath, path));
            }
            
            long l2 = System.DateTime.Now.Ticks;
            Console.WriteLine((l2 - l1) / 1000000);
            List<Image> list = baseDoc.ExportJPG();
            return list;
        }

        /// <summary>
        /// 根据文书名加载文书
        /// </summary>
        public BaseDoc GetAnesDoc(string docName)
        {
            Dictionary<string, MedicalDocElement> docs = MedicalDocSettings.GetMedicalDocNameAndPath();
            KeyValuePair<string, MedicalDocElement> keyValuePairDoc = new KeyValuePair<string, MedicalDocElement>();
            foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docs)
            {
                if (keyValuePair.Key.Trim() == docName.Trim())
                {
                    keyValuePairDoc = keyValuePair;
                    break;
                }
            }

            Type t = Type.GetType(keyValuePairDoc.Value.Type);
            BaseDoc baseDoc = Activator.CreateInstance(t) as BaseDoc;
            baseDoc.BackColor = Color.White;
            baseDoc.Name = docName;
            baseDoc.Initial();
            string path = null;
            if (MedicalDocSettings.GetMedicalDocNameAndPath().ContainsKey(docName))
            {
                path = MedicalDocSettings.GetMedicalDocNameAndPath()[docName].Path;
                baseDoc.LoadReport(Path.Combine(ExtendAppContext.Current.AppPath, path));
            }

            return baseDoc;
        }
    }
}