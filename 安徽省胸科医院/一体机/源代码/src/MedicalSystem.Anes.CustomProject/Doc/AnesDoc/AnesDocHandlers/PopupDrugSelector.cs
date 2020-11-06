// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      PopupDrugSelector.cs
// 功能描述(Description)：    麻醉单上弹出Popup控件
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MedicalSystem.Anes.CustomProject
{
    public class PopupDrugSelector
    {
        protected static string _title;                                        // 标题
        protected static string _eventNo;                                      // 系统类型：麻醉OR复苏OR诱导
        protected static Control _parent;                                      // 当前弹出框的父控件
        protected static IUIElementHandler _handler;                           // 对应的Handler
        protected static DateTime _currentTime = DateTime.MinValue;            // 当前世家你

        /// <summary>
        /// 显示弹出框信息
        /// </summary>
        /// <param name="sourceTable">数据源：固定MED_EVENT_DICT</param>
        /// <param name="parent">当前弹出框的父控件</param>
        /// <param name="location">弹出框的位置</param>
        /// <param name="dt">对应的时间点</param>
        /// <param name="handler">父控件对应的Handler</param>
        /// <param name="title">弹出框标题</param>
        /// <param name="eveNo">系统类型：麻醉OR复苏OR诱导</param>
        public static void ShowSelector(DataTable sourceTable, Control parent, Point location, DateTime dt, 
                                        IUIElementHandler handler, string title, string eveNo)
        {
            _currentTime = dt;
            _parent = parent;
            _handler = handler;
            _title = title;
            _eventNo = eveNo;
            if (title.Equals("事件"))
            {
                Dialog.ShowDataTableSelection(sourceTable, "EVENT_ITEM_NAME", parent, location, new Size(150, 200),
                                 new EventHandler(PopDrugItem_Selected), false, false, null);
            }
            else
            {
                Dialog.ShowDataTableSelection(sourceTable, "EVENT_ITEM_NAME", parent, location, new Size(175, 225),
                                  new EventHandler(PopDrugItem_Selected), false, false, null);
            }
        }

        /// <summary>
        /// Popup选择项事件
        /// </summary>
        protected static void PopDrugItem_Selected(object s1, EventArgs e1)
        {
            try
            {
                DataRow row = s1 as DataRow;
                if (row == null)
                {
                    return;
                }

                List<MED_ANESTHESIA_EVENT> anesEvent = new ModelHandler<MED_ANESTHESIA_EVENT>().FillModel(_handler.DataSource["AnesAllEvent"]);
                if (anesEvent == null)
                {
                    anesEvent = new List<MED_ANESTHESIA_EVENT>();
                }

                MED_ANESTHESIA_EVENT eventRow = DataContext.GetCurrent().NewAnesthesiaEventRow(anesEvent, _eventNo);
                eventRow.EVENT_CLASS_CODE = row["EVENT_CLASS_CODE"].ToString();
                eventRow.EVENT_ITEM_NAME = row["EVENT_ITEM_NAME"].ToString();
                eventRow.EVENT_ITEM_SPEC = row["EVENT_ITEM_SPEC"].ToString();
                eventRow.EVENT_ITEM_CODE = row["EVENT_ITEM_CODE"].ToString();
                eventRow.START_TIME = _currentTime;

                if (!row.IsNull("ADMINISTRATOR"))
                {
                    eventRow.ADMINISTRATOR = row["ADMINISTRATOR"].ToString();
                }

                if (!row.IsNull("CONCENTRATION_UNIT"))
                {
                    eventRow.CONCENTRATION_UNIT = row["CONCENTRATION_UNIT"].ToString();
                }

                if (!row.IsNull("DOSAGE_UNITS"))
                {
                    eventRow.DOSAGE_UNITS = row["DOSAGE_UNITS"].ToString();
                }

                if (!row.IsNull("SPEED_UNIT"))
                {
                    eventRow.SPEED_UNIT = row["SPEED_UNIT"].ToString();
                }

                if (!row.IsNull("SUPPLIER_NAME"))
                {
                    eventRow.SUPPLIER_NAME = row["SUPPLIER_NAME"].ToString();
                }

                if (!row.IsNull("CONCENTRATION"))
                {
                    eventRow.CONCENTRATION = Convert.ToDecimal(row["CONCENTRATION"]);
                }

                if (!row.IsNull("DOSAGE"))
                {
                    eventRow.DOSAGE = Convert.ToDecimal(row["DOSAGE"]);
                }

                if (!row.IsNull("PERFORM_SPEED"))
                {
                    eventRow.PERFORM_SPEED = Convert.ToDecimal(row["PERFORM_SPEED"]);
                }

                if (!row.IsNull("DURATIVE_INDICATOR"))
                {
                    eventRow.DURATIVE_INDICATOR = Convert.ToInt32(row["DURATIVE_INDICATOR"]);
                }

                EditEventItem editItem = new EditEventItem();
                editItem.DataSource = eventRow;
                editItem.ItemType = _title == "事件" ? EditEventItem.ItemTypes.EventItem : EditEventItem.ItemTypes.MedicineItem;
                DialogHostFormPC dialogHostForm = new DialogHostFormPC(editItem.Caption, editItem.Width, editItem.Height);
                dialogHostForm.Child = editItem;
                dialogHostForm.Text = _title;
                editItem.TitleColor = Color.Blue;
                DialogResult result = dialogHostForm.ShowDialog(_parent);
                if (result == DialogResult.OK)
                {
                    anesEvent.Add(eventRow);
                    AnesInfoService.ClientInstance.UpadteAnesthesiaEvent(anesEvent);
                    if (_handler.AttatchDoc != null)
                    {
                        _handler.AttatchDoc.RefreshData();
                    }
                }
            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }
        }
    }
}
