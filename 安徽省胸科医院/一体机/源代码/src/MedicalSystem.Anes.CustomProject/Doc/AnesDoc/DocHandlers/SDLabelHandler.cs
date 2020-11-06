// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      SDLabelHandler.cs
// 功能描述(Description)：    用于显示文书第几页的Label
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.FrameWork;
using System.Collections.Generic;

namespace MedicalSystem.Anes.Custom.CustomProject
{
    public class SDLabelHandler : LabelHandler
    {
        /// <summary>
        /// 当Label为PageIndex时，则显示页码信息
        /// </summary>
        public override void BindDataToUI(MLabel control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            base.BindDataToUI(control, dataSources);

            if (control.Name == "PageIndex")
            {
                control.Text = string.Format("第{0}页/共{1}页", PagerSetting.CurrentPageIndex + 1, PagerSetting.TotalPageCount);
            }
        }
        
        /// <summary>
        /// 控件属性事件设置
        /// </summary>
        public override void ControlSetting(MLabel control)
        {
            base.ControlSetting(control);
        }
    }
}
