using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.FrameWork
{
    /// <summary>
    /// 自定义控件基类
    /// </summary>
    public interface IBaseView
    {
        /// <summary>
        /// 是否已修改数据
        /// </summary>
        bool IsDirty { get; set; }

        /// <summary>
        /// 通过热键注册控件
        /// </summary>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        bool RegisterControlByHotKey(string keyCode);


        /// <summary>
        /// 通过热键注册控件
        /// </summary>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        bool RegisterControlByHotKey(Keys keyCode);

        /// <summary>
        /// 设置默认的DataGridView的样式
        /// </summary>
        /// <param name="dgv"></param>
        void SetDefaultGridViewStyle(DataGridView dgv, int RowHeight = 40, int ColumnHeight = 50);





    }
}
