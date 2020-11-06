using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MedicalSystem.Anes.Document.Controls
{
    [ToolboxItem(true),Description("按钮")]
    public partial class MedButton : DevExpress.XtraEditors.SimpleButton
    {
        public MedButton(string text, string imageFileName, string actionName)
            : this()
        {
            _actionName = actionName;
            Text = text;
        }

        public MedButton()
        {
            //_autoWidth = false;
            //_hasBorder = true;
            Dock = DockStyle.None;
            //Cursor = Cursors.Hand;
        }

        public override string ToString()
        {
            return base.ToString() + "(" + Text + ")";
        }

        public const string SPLITSTRING = "[]{}";
        private string _shortcutKeys;
        public string ShortcutKeys
        {
            get
            {
                return _shortcutKeys;
            }
            set
            {
                _shortcutKeys = value;
            }
        }

        private string _parameters;
        public string Parameters
        {
            get
            {
                return _parameters;
            }
            set
            {
                _parameters = value;
            }
        }

        private System.Windows.Forms.FlatStyle _flatStyle;
        public System.Windows.Forms.FlatStyle FlatStyle
        {
            get
            {
                return _flatStyle;
            }
            set
            {
                _flatStyle = value;
            }
        }

        private bool _useVisualStyleBackColor = true;
        public bool UseVisualStyleBackColor
        {
            get
            {
                return _useVisualStyleBackColor;
            }
            set
            {
                _useVisualStyleBackColor = value;
            }
        }

        private System.Drawing.ContentAlignment _textAlign = System.Drawing.ContentAlignment.MiddleCenter;
        public System.Drawing.ContentAlignment TextAlign
        {
            get
            {
                return _textAlign;
            }
            set
            {
                _textAlign = value;
            }
        }


        private System.Windows.Forms.AutoSizeMode _autoSizeMode;
        public System.Windows.Forms.AutoSizeMode AutoSizeMode
        {
            get
            {
                return _autoSizeMode;
            }
            set
            {
                _autoSizeMode = value;
            }
        }
        private string _bindControl;
        public string BindControl
        {
            get
            {
                return _bindControl;
            }
            set
            {
                _bindControl = value;
            }
        }

        private bool _isMenu = false;
        public bool IsMenu
        {
            get
            {
                return _isMenu;
            }
            set
            {
                _isMenu = value;
                //SetWidth();
            }
        }

        private int _menuIndex = 0;
        public int MenuIndex
        {
            get
            {
                return _menuIndex;
            }
            set
            {
                _menuIndex = value;
            }
        }

        /// <summary>
        /// 是否显示文本
        /// </summary>
        private bool _showText = true;
        public bool ShowText
        {
            get
            {
                return _showText;
            }
            set
            {
                _showText = value;
                //SetWidth();
            }
        }

        /// <summary>
        /// 自动按图形大小
        /// </summary>
        private bool _autoImage = false;
        public bool AutoImage
        {
            get
            {
                return _autoImage;
            }
            set
            {
                _autoImage = value;
                //SetWidth();
            }
        }

        protected bool _hasBorder = false;
        /// <summary>
        /// 是否画边框
        /// </summary>
        public bool HasBorder
        {
            get
            {
                return _hasBorder;
            }
            set
            {
                _hasBorder = value;
            }
        }

        protected bool _autoWidth = true;

        private bool _mouseHover = true;
        public bool IsMouseHover
        {
            get
            {
                return _mouseHover;
            }
            set
            {
                _mouseHover = value;
            }
        }

        private string _actionName;
        public string ActionName
        {
            get
            {
                return _actionName;
            }
            set
            {
                _actionName = value;
            }
        }

        private string _pageName = null;
        public string PageName
        {
            get
            {
                return _pageName;
            }
            set
            {
                _pageName = value;
            }
        }
    }

}
