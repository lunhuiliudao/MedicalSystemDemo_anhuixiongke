using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.FrameWork
{
    /// <summary>
    /// 界面导航事件参数
    /// </summary>
   public class ViewChangedEventArgs:EventArgs
    {
       private string _name = string.Empty;
       private Type _viewType = null;
       private bool _isDialogMode = false;

       public ViewChangedEventArgs(string name)
       {
           this._name = name;
       }
       public ViewChangedEventArgs(string name, Type type, bool isDialogMode)
        {
            this._name = name;
            this._viewType = type;
            this._isDialogMode = isDialogMode;
        }
        /// <summary>
        /// 界面名称
        /// </summary>
        public string ViewName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
       /// <summary>
       /// 界面的类型名称
       /// </summary>
        public Type ViewType
        {
            get
            {
                return _viewType;
            }
            set
            {
                _viewType = value;
            }
        }
        /// <summary>
        /// 是否按模式窗口显示
        /// </summary>
        public bool IsDialogMode
        {
            get
            {
                return _isDialogMode;
            }
            set
            {
                _isDialogMode = value;
            }
        }
    }
}
