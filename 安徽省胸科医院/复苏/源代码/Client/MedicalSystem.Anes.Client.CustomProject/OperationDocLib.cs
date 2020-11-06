using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.Client.CustomProject;
using System.Drawing;
using System.Configuration;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document.Configurations;
using System.IO;

namespace MedicalSystem.Anes.Client.CustomProject
{
    public class OperationDocLib
    {
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
            ExtendApplicationContext.Current.CurrentDocName = docName;
            baseDoc.Initial();
            long l1 = System.DateTime.Now.Ticks;
            string path = null;
            if (MedicalDocSettings.GetMedicalDocNameAndPath().ContainsKey(docName))
            {
                path = MedicalDocSettings.GetMedicalDocNameAndPath()[docName].Path;
                baseDoc.LoadReport(Path.Combine(ExtendApplicationContext.Current.AppPath, path));
            }
            // baseDoc.LoadReport(ExtendApplicationContext.Current.AppPath + "\\DocTemplate\\客户化医院\\" + docName + ".xml");
            long l2 = System.DateTime.Now.Ticks;
            Console.WriteLine((l2 - l1) / 1000000);
            List<Image> list = baseDoc.ExportJPG();
            return list;
        }

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
                baseDoc.LoadReport(Path.Combine(ExtendApplicationContext.Current.AppPath, path));
            }
            return baseDoc;
        }

    }
}