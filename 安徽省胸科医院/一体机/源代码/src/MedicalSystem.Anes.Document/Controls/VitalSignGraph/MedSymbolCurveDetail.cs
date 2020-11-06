using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace MedicalSystem.Anes.Document.Controls
{
    [Serializable]
    public class MedSymbolCurveDetail
    {
        private string _text;
        [DisplayName("文本")]
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

        protected MedSymbolType _symbolType = MedSymbolType.Circle;
        [Description("标识类型")]
        public MedSymbolType SymbolType
        {
            get
            {
                return _symbolType;
            }
            set
            {
                _symbolType = value;
            }
        }

        protected string _symbolEntry = null;
        [Description("标识实体")]
        public string SymbolEntry
        {
            get
            {
                return _symbolEntry;
            }
            set
            {
                _symbolEntry = value;
            }
        }

        protected Color _color = Color.Red;
        [Description("颜色")]
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public override string ToString()
        {
            return _text;
        }

    }
}
