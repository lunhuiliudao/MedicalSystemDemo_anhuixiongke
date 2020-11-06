using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{
    [Serializable]
    public class MedSheetCol
    {
        private string _title="";
        [DisplayName("标题")]
        public string Title
        {
            get
            {
                return GetLineString(_title);
            }
            set
            {
                _title = GetLineString(value);
            }
        }

        private string GetLineString(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }
            else
            {
                return text.Replace(@"\r\n", "\r\n");
            }
        }
    }
}
