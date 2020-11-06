//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      ShowPopupAction.cs
//功能描述(Description)：    打开弹出窗口，如术中登记切换手术间
//数据表(Tables)：		    无
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/26 14:58
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.Model;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;

namespace MedicalSystem.AnesWorkStation.View.Actions
{
    public class ShowPopupAction : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
            // 术中界面中切换手术间
            if (ExtendAppContext.Current.IsModify || ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE < (int)OperationStatus.OutOperationRoom)
            {
                if (ExtendAppContext.Current.IsPermission)
                {
                    var control = AssociatedObject as FrameworkElement;
                    if (control != null)
                    {
                        Popup pup = control.Tag as Popup;
                        if (pup != null)
                        {
                            pup.MouseEnter += pup_MouseEnter;
                            pup.IsOpen = true;
                            pup.StaysOpen = true;
                        }
                    }
                }
            }
        }

        void pup_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Popup pup = sender as Popup;
            pup.StaysOpen = false;
        }
    }
}
