using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using MedicalSystem.Anes.Document;

namespace MedicalSystem.Anes.Document.Documents
{
    public interface IUIElementHandler
    {
        /// <summary>
        /// 从数据源中绑定数据到界面控件设置界面元素的属性和事件
        /// </summary>
        void Handle();
        /// <summary>
        /// 根据控件的类型,加载控件到UIElementHandler中去
        /// </summary>
        /// <param name="control"></param>
        void AddControlByType(Control control);
        /// <summary>
        /// 刷新数据
        /// </summary>
        void RefreshData();
        /// <summary>
        /// 数据源
        /// </summary>
        Dictionary<string, DataTable> DataSource{get;set;}
        /// <summary>
        /// 验证数据提示控件
        /// </summary>
        ErrorProvider ErrorProvider {get;set;}
        /// <summary>
        /// 获取或者设置当前文书包含的其它IUIElementHandler集合
        /// </summary>
        List<IUIElementHandler> MedicalPaperUIElementHandlers {get;set;}
        /// <summary>
        /// 是否含有脏数据
        /// </summary>
        bool HasDirty { get; set; }
        
        /// <summary>
        /// 结束当前编辑
        /// </summary>
        void EndCurrentEdit();
        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        bool Validate();

        /// <summary>
        /// 清除错误显示
        /// </summary>
        /// <returns></returns>
        void ClearError();
        
        /// <summary>
        /// 分页设置
        /// </summary>
        PagerSetting PagerSetting { get; set; }
        /// <summary>
        /// 获取控件类型
        /// </summary>
        Type GetControlType { get;}
        /// <summary>
        /// 设置控件是否可见
        /// </summary>
        /// <param name="isVisible"></param>
        void SetControlVisible(bool isVisible);
        /// <summary>
        /// 设置控件的停靠位置和方式
        /// </summary>
        /// <param name="dock"></param>
        void SetControlDockStyle(DockStyle dock);
        /// <summary>
        /// 获取当前的控件
        /// </summary>
        Control GetCurrentControl { get; }
        List<Control> GetAllControls { get; }
        /// <summary>
        /// 设置控件是否可编辑
        /// </summary>
        /// <param name="canEdit"></param>
        void SetAllControlEditable(bool canEdit);
        BaseDoc AttatchDoc { get; set; }

        string DocName { get; set; }
    }
}
