//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      ClosePopupAction.cs
//功能描述(Description)：    关闭弹出窗口，如术中登记切换手术间
//数据表(Tables)：		    无
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/26 14:58
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;

namespace MedicalSystem.AnesWorkStation.View.Actions
{
    public class ClosePopupAction : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
            var control = AssociatedObject as FrameworkElement;
            if (control != null)
            {
                Popup pup = control.Tag as Popup;
                if (pup != null)
                {
                    pup.IsOpen = false;
                }
            }
        }
    }
}
