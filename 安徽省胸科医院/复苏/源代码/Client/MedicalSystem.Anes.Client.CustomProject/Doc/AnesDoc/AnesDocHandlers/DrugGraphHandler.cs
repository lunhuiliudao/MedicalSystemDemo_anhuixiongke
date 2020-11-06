// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      DrugGraphHandler.cs
// 功能描述(Description)：    麻醉单用药栏对应的Handler
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document.Controls.Base;
using MedicalSystem.Anes.Client.Repository;
using MedicalSystem.Services;

namespace MedicalSystem.Anes.Client.CustomProject
{
    public class DrugGraphHandler : UIElementHandler<MedDrugGraph>
    {
        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        AnesEventRepository anesEventRepository = new AnesEventRepository();

        protected MedDrugPoint Selectpt = null;
        protected MedDrugGraph _currentGraph = null;
        protected DateTime _currentTime = DateTime.MinValue;
        protected Dictionary<MedDrugPoint, MED_ANESTHESIA_EVENT> _drugRows = new Dictionary<MedDrugPoint, MED_ANESTHESIA_EVENT>();
        public Dictionary<int, Dictionary<MedDrugCurve, double>> dosageList = new Dictionary<int, Dictionary<MedDrugCurve, double>>();

        /// <summary>
        /// 绑定数据源数据到控件
        /// </summary>
        public override void BindDataToUI(MedDrugGraph control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            if (!dataSources.ContainsKey("AnesthesiaEvent"))
            {
                throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表AnesInformations.AnesthesiaEventDataTable,请添加此绑定数据源!", "AnesthesiaEvent"));
            }

            bool isEndAnes = false;
            DateTime dtEndAnes = DateTime.Now;
            List<MED_ANESTHESIA_EVENT> anesEvent = ModelHelper<MED_ANESTHESIA_EVENT>.ConvertDataTableToList(dataSources["AnesthesiaEvent"]);

            // 针对麻醉系统：持续用药随手术状态自动结束
            if (ApplicationConfiguration.DrugAutoStop && ExtendAppContext.Current.EventNo == "0")
            {
                string operText = ApplicationConfiguration.DrugAutoStopOperationStatus;
                OperationStatus operStatus = OperationStatusHelper.OperationStatusFromString(operText);
                if (operStatus != OperationStatus.None)
                {
                    string timeField = OperationStatusHelper.GetTimeFieldName(operStatus);
                    DataTable dtMaster = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER");
                    if (dtMaster != null && dtMaster.Rows.Count > 0 && !dtMaster.Rows[0].IsNull(timeField))
                    {
                        int status = 0;
                        if (!dtMaster.Rows[0].IsNull("OPER_STATUS_CODE"))
                        {
                            status = Convert.ToInt32(dtMaster.Rows[0]["OPER_STATUS_CODE"]);
                        }

                        // 出手术室 35
                        // 时如果没有持续用药没有自动结束的话，会按照配置的时间自动结束
                        if (status >= (int)operStatus)
                        {
                            dtEndAnes = (DateTime)dtMaster.Rows[0][timeField];
                            isEndAnes = true;

                            bool changed = false;
                            if (anesEvent != null)
                            {
                                anesEvent.ForEach(row =>
                                {
                                    if (row.DURATIVE_INDICATOR.HasValue && row.DURATIVE_INDICATOR == 1 && !row.END_TIME.HasValue)
                                    {
                                        row.END_TIME = dtEndAnes;
                                        changed = true;
                                    }
                                });
                            }

                            if (changed)
                            {
                                operationInfoRepository.SaveAnesthesiaEventList(anesEvent);
                            }
                        }
                    }
                }
            }
            else if (ExtendApplicationContext.Current.EventNo == "1")
            {
                DataTable dtMaster = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER");
                if (dtMaster != null && dtMaster.Rows.Count > 0 && !dtMaster.Rows[0].IsNull("OUT_PACU_DATE_TIME"))
                {
                    dtEndAnes = (DateTime)dtMaster.Rows[0]["OUT_PACU_DATE_TIME"];
                    isEndAnes = true;
                    bool changed = false;
                    if (anesEvent != null)
                    {
                        anesEvent.ForEach(row =>
                        {
                            if (row.DURATIVE_INDICATOR.HasValue && row.DURATIVE_INDICATOR == 1 && !row.END_TIME.HasValue)
                            {
                                row.END_TIME = dtEndAnes;
                                changed = true;
                            }
                        });
                    }

                    if (changed)
                    {
                        operationInfoRepository.SaveAnesthesiaEventList(anesEvent);
                    }
                }
            }

            control.Curves.Clear();
            control.ProLongedDrugShowType = (ProLongedDrugUnitShowType)ApplicationConfiguration.ProLonged;
            control.DrugShowType = (NormalDrugUnitShowType)ApplicationConfiguration.DrugShow;
            control.StartTime = PagerSetting.PageTimeSpan.StartDateTime;
            control.EndTime = PagerSetting.PageTimeSpan.EndDateTime;
            control.MinStartDateTime = PagerSetting.PageTimeSpan.OrigiStartDateTime;
            control.MaxEndDateTime = PagerSetting.PageTimeSpan.OrigiEndDateTime;

            //joysola测试用

            //ApplicationConfiguration.PassedDrugPointFormat = "DOSAGE;DOSAGE_UNITS;(;PERFORM_SPEED;SPEED_UNIT;+;CONCENTRATION;CONCENTRATION_UNIT;\r\n;ADMINISTRATOR;)";//DOSAGE_UNITS,ADMINISTRATOR
            //ApplicationConfiguration.PassedDrugNameFormat = "EVENT_ITEM_NAME;(;DOSAGE_UNITS;);SPEED_UNIT;CONCENTRATION_UNIT;ADMINISTRATOR";//SPEED_UNIT

            //ApplicationConfiguration.DrugPointShowFormat = "DOSAGE;;PERFORM_SPEED;SPEED_UNIT;CONCENTRATION;CONCENTRATION_UNIT;";//DOSAGE_UNITS,ADMINISTRATOR
            //ApplicationConfiguration.DrugNameShowFormat = "EVENT_ITEM_NAME;DOSAGE_UNITS;;CONCENTRATION_UNIT;ADMINISTRATOR";//SPEED_UNIT
            //ApplicationConfiguration.DrugPointMarkFormat = "(;);+;\r\n;";
            //ApplicationConfiguration.DrugNameMarkFormat = "(;)";

            //modified by joysola on 2018-2-26、3-5、4-8 新增获取用药显示、持续用药显示、药名显示
            control.DrugPointShowFormatType = ShowHelper.GetDrugPointShowFormat(ApplicationConfiguration.PassedDrugPointFormat);
            control.DrugProLongedShowFormatType = ShowHelper.GetDrugPointShowFormat(ApplicationConfiguration.PassedDrugProLongedFormat);
            control.DrugNameShowFormatType = ShowHelper.GetDrugNameShowFormat(ApplicationConfiguration.PassedDrugNameFormat);

            control.PointMarkFormat = ShowHelper.GetDrugPointMarkFormat(ApplicationConfiguration.PassedDrugPointFormat);
            control.ProLongedMarkFormat = ShowHelper.GetDrugPointMarkFormat(ApplicationConfiguration.PassedDrugProLongedFormat);
            control.NameMarkFormat = ShowHelper.GetDrugNameMarkFormat(ApplicationConfiguration.PassedDrugNameFormat);
            //modified end
            string itemClass = "," + GetAnesClassTypeString(AnesClassType.InOxygen) + ",";
            List<string> titles = new List<string>();
            if (anesEvent != null)
            {
                anesEvent.ForEach(row =>
                {
                    if (!string.IsNullOrEmpty(row.EVENT_CLASS_CODE) &&
                        !string.IsNullOrEmpty(row.EVENT_ITEM_NAME) &&
                        itemClass.Contains("," + row.EVENT_CLASS_CODE + ",") &&
                        !titles.Contains(row.EVENT_ITEM_NAME))
                    {
                        // 只显示持续用药
                        if (control.IsOnlyLine)
                        {
                            if (row.DURATIVE_INDICATOR.HasValue && row.DURATIVE_INDICATOR == 1)
                            {
                                titles.Add(row.EVENT_ITEM_NAME);
                            }
                        }
                        else
                        {
                            titles.Add(row.EVENT_ITEM_NAME);
                        }
                    }
                });

                itemClass += this.GetAnesClassTypeString(AnesClassType.AnesDrug) + "," + this.GetAnesClassTypeString(AnesClassType.MixLiquid) + ",";
                anesEvent.ForEach(row =>
                {
                    if (!string.IsNullOrEmpty(row.EVENT_CLASS_CODE) &&
                        !string.IsNullOrEmpty(row.EVENT_ITEM_NAME) &&
                        itemClass.Contains("," + row.EVENT_CLASS_CODE + ",") &&
                        !titles.Contains(row.EVENT_ITEM_NAME))
                    {
                        // 只显示持续用药
                        if (control.IsOnlyLine)
                        {
                            if (row.DURATIVE_INDICATOR.HasValue && row.DURATIVE_INDICATOR == 1)
                            {
                                titles.Add(row.EVENT_ITEM_NAME);
                            }
                        }
                        else
                        {
                            titles.Add(row.EVENT_ITEM_NAME);
                        }
                    }
                });

                itemClass += "C,";// 用药
                // 泵注用药部分暂时隐藏，请勿删除
                //anesEvent.ForEach(row =>
                //{
                //    if (!string.IsNullOrEmpty(row.EVENT_CLASS_CODE) && 
                //        !string.IsNullOrEmpty(row.EVENT_ITEM_NAME) && 
                //        row.EVENT_CLASS_CODE.Equals("C") && 
                //        !titles.Contains(row.EVENT_ITEM_NAME)
                //        && !string.IsNullOrEmpty(row.ADMINISTRATOR) && row.ADMINISTRATOR.Equals("泵注"))
                //    {
                //        if (control.IsOnlyLine)
                //        {
                //            if (row.DURATIVE_INDICATOR.HasValue && row.DURATIVE_INDICATOR == 1)
                //            {
                //                titles.Add(row.EVENT_ITEM_NAME);
                //            }
                //        }
                //        else
                //        {
                //            titles.Add(row.EVENT_ITEM_NAME);
                //        }
                //    }
                //});

                anesEvent.ForEach(row =>
                {
                    if (!string.IsNullOrEmpty(row.EVENT_CLASS_CODE) &&
                        !string.IsNullOrEmpty(row.EVENT_ITEM_NAME) &&
                        row.EVENT_CLASS_CODE.Equals("C") &&
                        !titles.Contains(row.EVENT_ITEM_NAME))
                    {
                        if (control.IsOnlyLine)
                        {
                            if (row.DURATIVE_INDICATOR.HasValue && row.DURATIVE_INDICATOR == 1)
                            {
                                titles.Add(row.EVENT_ITEM_NAME);
                            }
                        }
                        else
                        {
                            titles.Add(row.EVENT_ITEM_NAME);
                        }
                    }
                });

                // 只显示持续用药时进行排序
                //if (control.IsOnlyLine && titles.Count < control.LineParameters.Count)
                //{
                //    anesEvent.OrderBy(x => x.START_TIME).ToList().ForEach(row =>
                //      {
                //          if (!string.IsNullOrEmpty(row.EVENT_CLASS_CODE) &&
                //              !string.IsNullOrEmpty(row.EVENT_ITEM_NAME) &&
                //              itemClass.Contains("," + row.EVENT_CLASS_CODE + ",") &&
                //              !titles.Contains(row.EVENT_ITEM_NAME))
                //          {
                //              if (row.DURATIVE_INDICATOR == null || row.DURATIVE_INDICATOR != 1)
                //              {
                //                  titles.Add(row.EVENT_ITEM_NAME);
                //              }
                //          }
                //      });
                //}
            }

            // 最多只能显示 drugGraph.LineParameters.Count 行，多的显示在明细中
            int index = 0;
            if (titles.Count > 0)
            {
                DateTime sysDatetTime = this.GetSysDateTime();
                foreach (string title in titles)
                {
                    index++;

                    // 目前为 行
                    if (index > control.LineParameters.Count)
                    {
                        break;
                    }

                    MedDrugCurve curve = new MedDrugCurve(title, GetRandomColor());
                    List<MED_ANESTHESIA_EVENT> eventRows = anesEvent.Where(x => !string.IsNullOrEmpty(x.EVENT_ITEM_NAME) &&
                                                                                x.EVENT_ITEM_NAME.Equals(title)).ToList();
                    if (eventRows != null && eventRows.Count > 0)
                    {
                        eventRows.ForEach(row =>
                        {
                            if (row.START_TIME.HasValue &&
                                !string.IsNullOrEmpty(row.EVENT_CLASS_CODE) &&
                                itemClass.Contains("," + row.EVENT_CLASS_CODE + ","))
                            {
                                DateTime dt;
                                bool isArrow = false;
                                PointType pointType = this.GetDecimalValue(row.DURATIVE_INDICATOR) == 1 ?
                                                      PointType.ProLonged : PointType.SinglePoint;
                                if (row.END_TIME.HasValue)
                                {
                                    dt = row.END_TIME.Value;
                                }
                                else if (pointType == PointType.ProLonged)
                                {
                                    DateTime dtUse = isEndAnes ? dtEndAnes : sysDatetTime;
                                    dt = (dtUse > PagerSetting.PageTimeSpan.OrigiEndDateTime) ? dtUse : PagerSetting.PageTimeSpan.OrigiEndDateTime;
                                    isArrow = !isEndAnes;
                                }
                                else
                                {
                                    dt = row.START_TIME.Value;
                                }

                                MedDrugPoint point = curve.AddPoint(row.START_TIME.Value, this.GetDoubleValue(row.DOSAGE),
                                                                    this.GetStringValue(row.DOSAGE_UNITS),
                                                                    this.GetDoubleValue(row.CONCENTRATION),
                                                                    this.GetStringValue(row.CONCENTRATION_UNIT),
                                                                    this.GetStringValue(row.ADMINISTRATOR),
                                                                    dt,
                                                                    this.GetDoubleValue(row.PERFORM_SPEED),
                                                                    this.GetStringValue(row.SPEED_UNIT), pointType);
                                point.IsArrow = isArrow;
                                _drugRows.Add(point, row);
                            }
                        });

                        control.Curves.Add(curve);
                    }
                }
            }
        }

        /// <summary>
        /// 绑定控件内容到数据源
        /// </summary>
        public override void BindUIToData(MedDrugGraph control, Dictionary<string, System.Data.DataTable> dataSources)
        {
        }

        /// <summary>
        ///  重写：控件设置
        /// </summary>
        public override void ControlSetting(MedDrugGraph control)
        {
            _currentGraph = control;
            control.OriginWidth = control.Width;
            control.OriginHeight = control.Height;
            // 鼠标事件个性化实现暂时隐藏，请勿删除
            //control.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(MedDrugGraph_MouseDoubleClick);
            //control.MouseDown += new MouseEventHandler(MedDrugGraph_MouseDown);
            //control.MouseUp += new MouseEventHandler(MedDrugGraph_MouseLeave);
            //control.MouseClick += new MouseEventHandler(MedDrugGraph_MouseClick);
        }

        /// <summary>
        /// 鼠标单击事件
        /// </summary>
        protected void MedDrugGraph_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                RectangleF rectf = _currentGraph.GetMainRect();
                if (!rectf.Contains(e.Location.X, e.Location.Y))
                    return;

                if (e.Button == MouseButtons.Right)
                {
                    _currentGraph.SetMousePosition(e.Location);
                    string eventNo = ExtendApplicationContext.Current.EventNo;
                    if (_currentGraph.MouseTime > DateTime.MinValue)
                    {
                        MedDrugPoint pt = _currentGraph.SelectedPoint;
                        _currentTime = _currentGraph.MouseTime;
                        if (pt == null)
                        {
                            List<MED_EVENT_DICT> eventOpenTable = ExtendApplicationContext.Current.CommDict.EventDict;

                            List<MED_ANESTHESIA_EVENT> anesEvent = ModelHelper<MED_ANESTHESIA_EVENT>.ConvertDataTableToList(this.DataSource["AnesthesiaEvent"]);
                            int Line = (int)Math.Ceiling(((double)e.Location.Y - _currentGraph.TopOffSet) / _currentGraph.Height * _currentGraph.LineParameters.Count);
                            double locationH = (double)e.Location.Y - _currentGraph.TopOffSet;
                            double rowH = _currentGraph.Height / _currentGraph.LineParameters.Count;
                            for (int i = 1; i <= _currentGraph.LineParameters.Count; i++)
                            {
                                if (rowH * i > locationH)
                                {
                                    Line = i; break;
                                }
                            }
                            if (_currentGraph.Curves.Count < Line)
                            {
                                DataTable sourceTable = ModelHelper<MED_EVENT_DICT>.ConvertListToDataTable(eventOpenTable.Where(x => x.EVENT_CLASS_CODE == "2" || x.EVENT_CLASS_CODE == "C").ToList());

                                PopupDrugSelector.ShowSelector(sourceTable, _currentGraph, e.Location, _currentTime != DateTime.MinValue ? _currentTime : DateTime.Now, this, "麻药及用药", eventNo);
                            }
                            else
                            {
                                if (_currentGraph.GetMainRect().X > e.Location.X) return;
                                List<MED_EVENT_DICT> eventDict = eventOpenTable.Where(x => x.EVENT_ITEM_NAME == _currentGraph.Curves[Line - 1].Text).ToList();
                                MED_EVENT_DICT row = new MED_EVENT_DICT();
                                if (eventDict != null && eventDict.Count > 0)
                                {
                                    row = eventDict[0];
                                }
                                MED_ANESTHESIA_EVENT eventRow = DataContext.GetCurrent().NewAnesthesiaEventRow(anesEvent, eventNo);
                                eventRow.EVENT_CLASS_CODE = row.EVENT_CLASS_CODE;
                                eventRow.EVENT_ITEM_NAME = row.EVENT_ITEM_NAME;
                                eventRow.EVENT_ITEM_SPEC = row.EVENT_ITEM_SPEC;
                                eventRow.EVENT_ITEM_CODE = row.EVENT_ITEM_CODE;
                                eventRow.START_TIME = _currentTime;
                                if (!string.IsNullOrEmpty(row.EVENT_ATTR))
                                    eventRow.EVENT_ATTR = row.EVENT_ATTR;
                                if (!string.IsNullOrEmpty(_currentGraph.Curves[Line - 1].Points[0].Route))
                                    eventRow.ADMINISTRATOR = _currentGraph.Curves[Line - 1].Points[0].Route;

                                if (!string.IsNullOrEmpty(_currentGraph.Curves[Line - 1].Points[0].ThickNessUnit))
                                    eventRow.CONCENTRATION_UNIT = _currentGraph.Curves[Line - 1].Points[0].ThickNessUnit;

                                if (!string.IsNullOrEmpty(_currentGraph.Curves[Line - 1].Points[0].Unit))
                                    eventRow.DOSAGE_UNITS = _currentGraph.Curves[Line - 1].Points[0].Unit;

                                if (!string.IsNullOrEmpty(_currentGraph.Curves[Line - 1].Points[0].SpeedUnit))
                                    eventRow.SPEED_UNIT = _currentGraph.Curves[Line - 1].Points[0].SpeedUnit;

                                if (!string.IsNullOrEmpty(row.SUPPLIER_NAME))
                                    eventRow.SUPPLIER_NAME = row.SUPPLIER_NAME;

                                if (!string.IsNullOrEmpty(_currentGraph.Curves[Line - 1].Points[0].ThickNess.ToString()))
                                    eventRow.CONCENTRATION = (decimal)_currentGraph.Curves[Line - 1].Points[0].ThickNess;

                                if (!string.IsNullOrEmpty(_currentGraph.Curves[Line - 1].Points[0].Value.ToString()))
                                    eventRow.DOSAGE = Convert.ToDecimal(_currentGraph.Curves[Line - 1].Points[0].Value);

                                if (!string.IsNullOrEmpty(_currentGraph.Curves[Line - 1].Points[0].Speed.ToString()))
                                    eventRow.PERFORM_SPEED = (decimal)_currentGraph.Curves[Line - 1].Points[0].Speed;

                                if (row.DURATIVE_INDICATOR.HasValue)
                                    eventRow.DURATIVE_INDICATOR = row.DURATIVE_INDICATOR;
                                EditEventItem editItem = new EditEventItem();
                                editItem.DataSource = eventRow;
                                editItem.ItemType = EditEventItem.ItemTypes.MedicineItem;
                                DialogHostFormPC dialogHostForm = new DialogHostFormPC(editItem.Caption, editItem.Width, editItem.Height);
                                dialogHostForm.Child = editItem;
                                dialogHostForm.Text = "新增麻药用药数据";
                                editItem.TitleColor = Color.Blue;
                                DialogResult result = dialogHostForm.ShowDialog();
                                if (result == DialogResult.OK)
                                {
                                    eventRow.ITEM_NO = DataContext.GetCurrent().GetMaxItemNO(anesEvent);
                                    anesEvent.Add(eventRow);
                                    operationInfoRepository.SaveAnesthesiaEventList(anesEvent);
                                    RefreshData();
                                    _currentGraph.Refresh();
                                }
                            }

                        }
                        else
                        {
                            MED_ANESTHESIA_EVENT row = _drugRows[pt];
                            List<MED_ANESTHESIA_EVENT> anesEvent = ModelHelper<MED_ANESTHESIA_EVENT>.ConvertDataTableToList(this.DataSource["AnesthesiaEvent"]);
                            EditEventItem editItem = new EditEventItem();
                            editItem.DataSource = row;
                            editItem.ItemType = EditEventItem.ItemTypes.MedicineItem;
                            editItem.IsAllowDel = true;
                            DialogHostFormPC dialogHostForm = new DialogHostFormPC("修改麻药用药数据", editItem.Width, editItem.Height);
                            dialogHostForm.Child = editItem;
                            editItem.TitleColor = Color.DarkOrange;
                            if (dialogHostForm.ShowDialog() == DialogResult.OK)
                            {
                                if (editItem != null && editItem.IsDelete)
                                {
                                    if (MessageBoxFormPC.Show("是否确定要删除选中事件？", "操作提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        List<MED_ANESTHESIA_EVENT> allEvent = ModelHelper<MED_ANESTHESIA_EVENT>.ConvertDataTableToList(this.DataSource["AnesAllEvent"]);
                                        List<MED_ANESTHESIA_EVENT> rows = allEvent.Where(x => x.EVENT_CLASS_CODE == row.EVENT_CLASS_CODE && x.ITEM_NO == row.ITEM_NO).ToList();
                                        if (rows.Count > 0)
                                        {
                                            allEvent.Remove(rows[0]);
                                        }
                                        //  OperationLogger.WriteOperate("文书用药模块", "右键删除", "右键用药模块弹出药品界面，勾选删除选择项，点确定进行删除保存，事件名称【" + row["ITEM_NAME"].ToString() + "】", false, OperationLogKind.Other);
                                        anesEventRepository.DelAnesEvent(row);
                                    }

                                }
                                else
                                {
                                    List<MED_ANESTHESIA_EVENT> eventList = new List<MED_ANESTHESIA_EVENT>();
                                    eventList.Add(row);
                                    operationInfoRepository.SaveAnesthesiaEventList(eventList);
                                }
                                RefreshData();
                                _currentGraph.Refresh();
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Logger.Error(err.Message);
            }
        }

        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        private void MedDrugGraph_MouseDown(object sender, MouseEventArgs e)
        {
            RectangleF rectf = _currentGraph.GetMainRect();
            if (!rectf.Contains(e.Location.X, e.Location.Y))
            {
                return;
            }

            if (_currentGraph.MouseTime > DateTime.MinValue)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Selectpt = _currentGraph.SelectedPoint;
                    _currentGraph.Cursor = Cursors.Hand;
                }
            }
        }

        /// <summary>
        /// 鼠标Leave事件
        /// </summary>
        private void MedDrugGraph_MouseLeave(object sender, MouseEventArgs e)
        {
            RectangleF rectf = _currentGraph.GetMainRect();
            if (!rectf.Contains(e.Location.X, e.Location.Y))
                return;
            _currentGraph.SetMousePosition(e.Location);
            string eventNo = ExtendApplicationContext.Current.EventNo;
            if (Selectpt != null)
            {
                _currentTime = _currentGraph.MouseTime;
                MED_ANESTHESIA_EVENT eventRow = null;
                int Line = (int)Math.Ceiling(((double)e.Location.Y - _currentGraph.TopOffSet) / _currentGraph.Height * _currentGraph.LineParameters.Count);
                List<MED_ANESTHESIA_EVENT> anesEvent = ModelHelper<MED_ANESTHESIA_EVENT>.ConvertDataTableToList(this.DataSource["AnesthesiaEvent"]);
                foreach (MED_ANESTHESIA_EVENT row in anesEvent)
                {
                    if (row.EVENT_ITEM_NAME.Equals(_currentGraph.Curves[Line - 1].Text) && row.START_TIME.HasValue && row.START_TIME == Selectpt.StartTime)
                    {
                        eventRow = row;
                        break;
                    }
                }
                if (eventRow != null)
                {
                    if (eventRow.DURATIVE_INDICATOR.HasValue && eventRow.DURATIVE_INDICATOR == 1)
                    {
                        eventRow.END_TIME = _currentTime;
                    }
                    else
                    {
                        eventRow.START_TIME = _currentTime;
                    }
                }
                operationInfoRepository.SaveAnesthesiaEventList(anesEvent);
                RefreshData();
                _currentGraph.Refresh();

            }
            Selectpt = null;
            _currentGraph.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 鼠标双击事件
        /// </summary>
        protected void MedDrugGraph_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RectangleF rectf = _currentGraph.GetMainRect();
            _currentGraph.SetMouseDoubleClick(e.Location);
            if (!rectf.Contains(e.Location.X, e.Location.Y))
            {
                return;
            }

            if (_currentGraph.MouseTime > DateTime.MinValue)
            {
            }
        }
    }
}
