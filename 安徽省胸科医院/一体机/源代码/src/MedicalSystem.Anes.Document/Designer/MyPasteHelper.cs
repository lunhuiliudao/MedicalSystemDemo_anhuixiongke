/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MyPasteHelper.cs
      // 文件功能描述：粘贴辅助类
      //
      // 
      // 创建标识：戴呈祥-2010-12-13
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Controls;

namespace MedicalSystem.Anes.Document.Designer
{
    public class MyPasteHelper
    {
        private static bool _isPaste = false;
        public static bool IsPaste
        {
            get
            {
                return _isPaste;
            }
            set
            {
                _isPaste = value;
            }
        }

        private static int _pasteIndex = -1;
        public static int PasteIndex
        {
            get
            {
                return _pasteIndex;
            }
            set
            {
                _pasteIndex = value;
            }
        }

        public static List<object> PasteList
        {
            get
            {
                if (MyClipBoard.Data != null && MyClipBoard.Data is List<object>)
                {
                    return MyClipBoard.Data as List<object>;
                }
                return null;
            }
        }

        private static IDesignerHost _designerHost;
        public static IDesignerHost DesignerHost
        {
            get
            {
                return _designerHost;
            }
            set
            {
                _designerHost = value;
            }
        }

        public static void StartPaste()
        {
            _isPaste = true;
            _pasteIndex = 0;
            Paste();
        }

        public static void Paste()
        {
            List<object> list = PasteList;
            if (list != null)
            {
                if (_designerHost != null)
                {
                    IToolboxUser tbu = _designerHost.GetDesigner(_designerHost.RootComponent as System.ComponentModel.IComponent) as IToolboxUser;

                    if (tbu != null)
                    {
                        tbu.ToolPicked(new System.Drawing.Design.ToolboxItem(list[_pasteIndex].GetType()));
                    }
                }
            }
        }

        public static void CloneControl(Control source,  Control target)
        {
            target.Font = source.Font;
            target.Text = source.Text;
            target.Top = source.Top;
            target.Left = source.Left;
            target.Width = source.Width;
            target.Height = source.Height;
            target.ForeColor = source.ForeColor;
            target.BackColor = source.BackColor;
    
        }

        public static void CloneMedLabel(MedLabel source,  MedLabel target)
        {
            CloneControl(source, target);
            target.AutoSizeMode = source.AutoSizeMode;
        }
        public static void CloneMLabel(MLabel source, MLabel target)
        {
            CloneControl(source, target);
            target.AutoSize = source.AutoSize;
        }
        public static void CloneMedTextBox(MedTextBox source, MedTextBox target)
        {
            CloneControl(source, target);
            target.SourceFieldName = source.SourceFieldName;
            target.SourceTableName = source.SourceTableName;
            target.DictTableName = source.DictTableName;
            target.DictValueFieldName = source.DictValueFieldName;
            target.DictWhereString = source.DictWhereString;
            target.DisplayFieldName = source.DisplayFieldName;
        }
        public static void CloneMTextBox(MTextBox source, MTextBox target)
        {
            CloneControl(source, target);
            target.BorderStyle = source.BorderStyle;
            target.SourceFieldName = source.SourceFieldName;
            target.SourceTableName = source.SourceTableName;
            target.DictTableName = source.DictTableName;
            target.DictValueFieldName = source.DictValueFieldName;
            target.DictWhereString = source.DictWhereString;
            target.DisplayFieldName = source.DisplayFieldName;
        }
        public static void CloneMedMyLine(MedMyLine source, MedMyLine target)
        {
            CloneControl(source, target);
            target.LineType = source.LineType;
        }
        public static void CloneCustomControl(CustomControl source, CustomControl target)
        {
            CloneControl(source, target);
            target.AutoSize = source.AutoSize;
            target.DictTableName = source.DictTableName;
            target.DictValueFieldName = source.DictValueFieldName;
            target.SourceFieldName = source.SourceFieldName;
            target.SourceTableName = source.SourceTableName;
            target.DisplayFieldName = source.DisplayFieldName;
            target.DictWhereString = source.DictWhereString;
            target.DefaultItems = source.DefaultItems;
            target.Size = source.Size;
        }
        public static Control CloneControl(Control source)
        {
            Control target = new Control();
            CloneControl(source,  target);
            return target;
        }

        public static MedLabel CloneMedLabel(MedLabel source)
        {
            MedLabel target = new MedLabel();
            CloneMedLabel(source,  target);
            return target;
        }
        public static MLabel CloneMedLabel(MLabel source)
        {
            MLabel target = new MLabel();
            CloneMLabel(source, target);
            return target;
        }
        public static MedTextBox CloneMedTextBox(MedTextBox source)
        {
            MedTextBox target = new MedTextBox();
            CloneMedTextBox(source, target);
            return target;
        }
        public static MTextBox CloneMTextBox(MTextBox source)
        {
            MTextBox target = new MTextBox();
            CloneMTextBox(source, target);
            return target;
        }
        public static MedMyLine CloneMedMyLine(MedMyLine source)
        {
            MedMyLine target = new MedMyLine();
            CloneMedMyLine(source, target);
            return target;
        }
        public static CustomControl CloneCustomControl(CustomControl source)
        {
            CustomControl target = new CustomControl();
            CloneCustomControl(source, target);
            return target;
        }
        
    }
}
