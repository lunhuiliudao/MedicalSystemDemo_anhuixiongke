using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace MedicalSystem.Anes.Document.Controls
{

    [Serializable]
    public class LastColumnLineItem
    {
        public LastColumnLineItem(string text, Font font)
        {
            _text = text;
            _font = font;
        }

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

        private Font _font = new Font("宋体", 9);
        public Font Font
        {
            get
            {
                return _font;
            }
            set
            {
                _font = value;
            }
        }
    }
}
