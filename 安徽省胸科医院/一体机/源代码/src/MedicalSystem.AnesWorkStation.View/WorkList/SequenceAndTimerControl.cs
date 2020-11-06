// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      SequenceAndTimerControl.cs
// 功能描述(Description)：    患者的台次和时间集成显示控件
// 数据表(Tables)：		      无
// 作者(Author)：             许文龙、孙家富
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.Model.WorkListModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MedicalSystem.AnesWorkStation.View.WorkList
{
    public class SequenceAndTimerControl : Grid
    {
        /// <summary>
        /// 患者信息
        /// </summary>
        public static readonly DependencyProperty CurPatientModelProperty = DependencyProperty.Register("CurPatientModel",
                                                                                                        typeof(PatientModel),
                                                                                                        typeof(SequenceAndTimerControl),
                                                                                                        new PropertyMetadata(defaultValue:null,
                                                                                                                             propertyChangedCallback: CurPatientModelPropertyChangedCallback));

        /// <summary>
        /// 台次文本框
        /// </summary>
        private TextBlock sequenceText = null;

        /// <summary>
        /// 根据Oper_status_code 现实对应的时间
        /// </summary>
        private TextBlock timeInfoText = null;

        /// <summary>
        /// 患者信息
        /// </summary>
        public PatientModel CurPatientModel
        {
            get { return (PatientModel)GetValue(CurPatientModelProperty);  }
            set 
            { 
                SetValue(CurPatientModelProperty, value);
            }
        }

        /// <summary>
        /// 无参构造
        /// </summary>
        public SequenceAndTimerControl()
        {
            this.sequenceText = new TextBlock()
            {
                FontSize = 20,
                Margin = new Thickness(8, 0, 0, 0),
                Foreground=new SolidColorBrush(Color.FromRgb(93,93,93)),
                VerticalAlignment=VerticalAlignment.Center,
                Text= "01"
            };

            this.timeInfoText= new TextBlock() 
            { 
                FontSize=16,
                Margin=new Thickness(35,0,0,0),
                Foreground=new SolidColorBrush(Color.FromRgb(255,255,255)),
                Text= "07:35",
                VerticalAlignment=VerticalAlignment.Center
            };

           this.Children.Add(sequenceText);
           this.Children.Add(timeInfoText);
        }

        /// <summary>
        /// 依赖属性更改响应事件
        /// </summary>
        private static void CurPatientModelPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as SequenceAndTimerControl;
            if (control.CurPatientModel != null)
            {
                control.sequenceText.Text = control.CurPatientModel.Sequence;
                control.ConvertOperStatus(control.CurPatientModel);
            }
        }

        /// <summary>
        /// 根据患者手术状态显示对应的时间
        /// </summary>
        private void ConvertOperStatus(PatientModel patModel)
        {
            DateTime result = DateTime.MinValue;
            switch (patModel.OperStatusCode)
            {
                case OperationStatus.IsReady:
                    result = patModel.ScheduledDateTime;
                    break;

                case OperationStatus.OperScheduled:
                    result = patModel.ScheduledDateTime;
                    break;

                case OperationStatus.InOperationRoom:
                    result = patModel.InDateTime;
                    break;

                case OperationStatus.AnesthesiaStart:
                    result = patModel.AnesStartTime;
                    break;

                case OperationStatus.OperationStart:
                    result = patModel.StartDateTime;
                    break;

                case OperationStatus.OperationEnd:
                    result = patModel.EndDateTime;
                    break;

                case OperationStatus.AnesthesiaEnd:
                    result = patModel.AnesEndTime;
                    break;

                case OperationStatus.OutOperationRoom:
                    result = patModel.OutDateTime;
                    break;

                default:
                    break;
            }

            if (result != DateTime.MinValue)
            {
                this.timeInfoText.Text = result.ToString("HH:mm");
            }
            else
            {
                this.timeInfoText.Text = string.Empty;
            }
        }
    }
}
