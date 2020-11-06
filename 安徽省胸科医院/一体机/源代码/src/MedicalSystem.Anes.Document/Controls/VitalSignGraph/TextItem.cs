using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{

    public class TextItem
    {
        private string _text;
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }
        private bool _isChinese = false;
        public bool IsChinese
        {
            get
            {
                return _isChinese;
            }
            set
            {
                _isChinese = value;
            }
        }
        public TextItem(string text, bool isChinese)
            : this(text)
        {
            _isChinese = isChinese;
        }
        public TextItem(string text)
        {
            _text = text;
        }
    }

}
