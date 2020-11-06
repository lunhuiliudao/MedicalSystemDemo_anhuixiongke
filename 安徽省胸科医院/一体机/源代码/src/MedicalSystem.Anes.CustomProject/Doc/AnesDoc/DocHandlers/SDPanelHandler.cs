// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      SDPanelHandler.cs
// 功能描述(Description)：    用于显示麻醉单上的麻醉医生信息
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
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace MedicalSystem.Anes.CustomProject
{
    public class SDPanelHandler : UIElementHandler<MPanel>
    {
        /// <summary>
        /// 重写事件绑定方法
        /// </summary>
        public override void ControlSetting(MPanel control)
        {
            if (control.Name == "MPanelAnesDoctor")
            {
                control.CustomDraw += Control_CustomDraw;
            }
        }

        /// <summary>
        /// 自定义绘制事件
        /// </summary>
        private void Control_CustomDraw(object sender, PaintEventArgs e)
        {
            MPanel mPanel = sender as MPanel;
            List<MED_OPERATION_MASTER> operMaster = new ModelHandler<MED_OPERATION_MASTER>().FillModel(DataSource["MED_OPERATION_MASTER"]);
            List<MED_OPERATION_SHIFT_RECORD> shiftRecordList = 
                AnesInfoService.ClientInstance.GetOperShiftRecord(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID, 
                                                                  ExtendAppContext.Current.PatientInformationExtend.VISIT_ID, 
                                                                  ExtendAppContext.Current.PatientInformationExtend.OPER_ID);
            string ANES_DOCTOR = ShowUserName(operMaster[0].ANES_DOCTOR);
            string FIRST_ANES_ASSISTANT = ShowUserName(operMaster[0].FIRST_ANES_ASSISTANT);
            string SECOND_ANES_ASSISTANT = ShowUserName(operMaster[0].SECOND_ANES_ASSISTANT);
            string THIRD_ANES_ASSISTANT = ShowUserName(operMaster[0].THIRD_ANES_ASSISTANT);
            string FOURTH_ANES_ASSISTANT = ShowUserName(operMaster[0].FOURTH_ANES_ASSISTANT);

            string AnesDoctorList = ANES_DOCTOR + "," + 
                                    FIRST_ANES_ASSISTANT + "," + 
                                    SECOND_ANES_ASSISTANT + "," + 
                                    THIRD_ANES_ASSISTANT + "," + 
                                    FOURTH_ANES_ASSISTANT;
            string[] AnesDocDutyList = new string[] { "主麻", "麻醉助手1", "麻醉助手2", "麻醉助手3", "麻醉助手4" };
            var anesDoctorShiftList = shiftRecordList.Where(x => AnesDocDutyList.Contains(x.SHIFT_DUTY));
            var shiftTimes = anesDoctorShiftList.GroupBy(x => x.START_DATE_TIME).
                                                 Select(g => (new { start_date_time = g.Key })).
                                                 OrderBy(x => x.start_date_time).
                                                 ToList();
            Dictionary<DateTime, string> shiftRecord = new Dictionary<DateTime, string>();
            shiftRecord.Add(operMaster[0].IN_DATE_TIME.HasValue ? operMaster[0].IN_DATE_TIME.Value : DateTime.MinValue, AnesDoctorList);
            if (shiftTimes.Count() > 1)
            {
                for (int i = 1; i < shiftTimes.Count(); i++)
                {
                    var shiftItems = anesDoctorShiftList.Where(x => x.START_DATE_TIME == shiftTimes[i].start_date_time);
                    foreach (var item in shiftItems)
                    {
                        switch (item.SHIFT_DUTY)
                        {
                            case "主麻":
                                ANES_DOCTOR = ShowUserName(item.PERSON);
                                break;
                            case "麻醉助手1":
                                FIRST_ANES_ASSISTANT = ShowUserName(item.PERSON);
                                break;
                            case "麻醉助手2":
                                SECOND_ANES_ASSISTANT = ShowUserName(item.PERSON);
                                break;
                            case "麻醉助手3":
                                THIRD_ANES_ASSISTANT = ShowUserName(item.PERSON);
                                break;
                            case "麻醉助手4":
                                FOURTH_ANES_ASSISTANT = ShowUserName(item.PERSON);
                                break;
                            default:
                                break;
                        }
                    }

                    AnesDoctorList = ANES_DOCTOR + "," + 
                                     FIRST_ANES_ASSISTANT + "," + 
                                     SECOND_ANES_ASSISTANT + "," + 
                                     THIRD_ANES_ASSISTANT + "," + 
                                     FOURTH_ANES_ASSISTANT;

                    shiftRecord.Add(shiftTimes[i].start_date_time, AnesDoctorList);
                }
            }

            float nextStartX = 0;
            for (int i = 0; i < shiftRecord.Count; i++)
            {
                Font font = mPanel.Font;
                if (i == 0)
                {
                    string text = shiftRecord.Values.ToList()[i].TrimEnd(',');
                    e.Graphics.DrawString(text, font, Brushes.Blue, 0, mPanel.Location.Y);
                    nextStartX = e.Graphics.MeasureString(text, font).Width;
                }
                else
                {
                    Pen pen1 = new Pen(Color.Black);
                    e.Graphics.DrawLine(pen1, 
                                        new Point((int)(nextStartX + 3), mPanel.Location.Y + 6), 
                                        new Point((int)(nextStartX + 35), mPanel.Location.Y + 6));
                    e.Graphics.DrawString(">", font, Brushes.Black, nextStartX + 35, mPanel.Location.Y);
                    string time = shiftRecord.Keys.ToList()[i].ToString("HH:mm");
                    e.Graphics.DrawString(time, font, Brushes.Black, nextStartX - 4, mPanel.Location.Y - 10);
                    string text = shiftRecord.Values.ToList()[i].TrimEnd(',');
                    e.Graphics.DrawString(text, font, Brushes.Blue, nextStartX + 45, mPanel.Location.Y);
                    nextStartX += 45 + e.Graphics.MeasureString(text, font).Width;
                }
            }

            Pen p = new Pen(Color.Black, 1);
            p.DashStyle = DashStyle.Dash;
            e.Graphics.DrawLine(p, 0, mPanel.Height - 1, mPanel.Width, mPanel.Height - 1);
        }

        /// <summary>
        /// 根据Code返回Name
        /// </summary>
        public string ShowUserName(string code)
        {
            string value = code;
            List<MED_HIS_USERS> hisUserList = new ModelHandler<MED_HIS_USERS>().FillModel(ExtendAppContext.Current.CodeTables["MED_HIS_USERS"]);
            foreach (MED_HIS_USERS user in hisUserList)
            {
                if (user.USER_JOB_ID == code) { value = user.USER_NAME; break; }
            }

            return value;
        }
    }
}
