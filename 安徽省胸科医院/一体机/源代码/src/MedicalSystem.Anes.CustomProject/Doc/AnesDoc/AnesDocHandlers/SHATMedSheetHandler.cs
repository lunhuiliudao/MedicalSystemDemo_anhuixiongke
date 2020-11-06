using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using System.Data;
using MedicalSystem.AnesWorkStation.Model.InOperationModel;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;

namespace MedicalSystem.Anes.Custom.CustomProject
{
    public class SHATMedSheetHandler : UIElementHandler<MedSheet>
    {
        protected MTextBox _textBox = new MTextBox();
        protected int _eventNo = 0;
        DataTable dtSP02CVPTRUEDATE = null;

        public SHATMedSheetHandler(int evo)
        {
            _textBox.Visible = false;
            _textBox.BorderStyle = BorderStyle.FixedSingle;
            _textBox.LostFocus += new EventHandler(TextBox_LostFocus);
            _textBox.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            _eventNo = 0;
        }

        private MED_PATIENT_MONITOR_CONFIG GetPatientMonitorConfigDataTable(string eventNo)
        {
            MED_PATIENT_MONITOR_CONFIG config = null;
            if (ExtendAppContext.Current.PatientInformationExtend != null)//出手术室时候为Null 异常

                config = AnesInfoService.ClientInstance.GetPatientMonitorConfig(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID, ExtendAppContext.Current.PatientInformationExtend.VISIT_ID
                    , ExtendAppContext.Current.PatientInformationExtend.OPER_ID, eventNo);

            if (config == null)
            {
                config = AnesInfoService.ClientInstance.GetPatientMonitorConfig("999", 0, 0, eventNo);
            }
            return config;
        }

        protected List<MedVitalSignCurveDetail> GetUserVitalShowSet(string eventNo)
        {
            List<MedVitalSignCurveDetail> list = new List<MedVitalSignCurveDetail>();
            MED_PATIENT_MONITOR_CONFIG config = GetPatientMonitorConfigDataTable(eventNo);
            if (config != null && !string.IsNullOrEmpty(config.CONTENT.ToString()))
            {
                System.IO.MemoryStream stream = new System.IO.MemoryStream(config.CONTENT);
                stream.Position = 0;
                DataSet ds = new DataSet();
                ds.ReadXml(stream);
                if (ds.Tables.Count > 0)
                {
                    string tableName = "UserVitalShowSet" + ((Convert.ToInt32(eventNo) < 0) ? "0" : eventNo);
                    DataTable dataTable = ds.Tables[tableName];
                    ListFromTable(list, typeof(MedVitalSignCurveDetail), dataTable);
                }
                ds.Dispose();
                stream.Close();
                stream.Dispose();
            }

            // 获取用药图表控件，去掉重复的药
            MedVitalSignGraph vitalSignGraph = null;
            foreach (IUIElementHandler handler in MedicalPaperUIElementHandlers)
            {
                if (handler.GetControlType == typeof(MedVitalSignGraph) && handler.GetCurrentControl != null)
                {
                    vitalSignGraph = handler.GetCurrentControl as MedVitalSignGraph;
                    break;
                }
            }

            if (null != vitalSignGraph)
            {
                foreach (MedVitalSignCurveDetail detail in vitalSignGraph.CurveDetails)
                {
                    if (!string.IsNullOrEmpty(detail.CurveCode) && !list.Contains(detail))
                    {
                        list.Add(detail);
                    }
                }
            }

            return list;
        }


        public override void BindDataToUI(MedSheet control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            if (!dataSources.ContainsKey("VitalSignData"))
            {
                throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表AnesInformations.VitalSignDataTable,请添加此绑定数据源!", "VitalSignData"));
            }

            DataTable vitalSignData = dataSources["VitalSignData"];
            DataTable operationMasterDataTable = dataSources["MED_OPERATION_MASTER"];
            DataTable dtMonitorEx = dataSources["MED_PAT_MONITOR_DATA_EXT"];
            for (int i = 0; i < dtMonitorEx.Rows.Count; i++)
            {
                if (!dtMonitorEx.Rows[i].IsNull("ITEM_VALUE") && dtMonitorEx.Rows[i]["ITEM_VALUE"].ToString().Equals("/"))
                {
                    dtMonitorEx.Rows[i]["ITEM_VALUE"] = "";
                }
            }
            DataTable anesEventTable = dataSources["AnesthesiaEvent"];

            var startTime = PagerSetting.PageTimeSpan.StartDateTime;
            var endTime = PagerSetting.PageTimeSpan.EndDateTime;
            if (!operationMasterDataTable.Rows[0].IsNull("OUT_DATE_TIME"))
            {
                DateTime outDateTime = (DateTime)operationMasterDataTable.Rows[0]["OUT_DATE_TIME"];
                if (outDateTime < endTime)
                {
                    endTime = outDateTime;
                }
            }

            #region 这个是杀么东须捏，这是用来处理 SP02 或者　CVP　这种采集数据的修改，而存放的临时ＤＡＴＡＴＡＢＬＥ
            DataTable dtak880 = new DataTable();
            dtak880.Columns.Add("TIME_POINT");
            dtak880.Columns.Add("VALUE");
            dtak880.Columns.Add("getway");
            #endregion

            List<MedVitalSignCurveDetail> curveDetail = this.GetUserVitalShowSet(_eventNo.ToString());

            for (int n = 0; n < control.Rows.Count; n++)
            {
                var item = control.Rows[n];
                //根据当前页的开始时间，结束时间，配置的行体症项，取数据，按时间做升序排序
                string itemCode = string.IsNullOrEmpty(item.ItemCode) ? item.Title : item.ItemCode;
                DataRow[] rows = null;
                DataRow[] dtMonitorExrows = null;

                if (item.Title.Trim().Length != 0)
                {
                    // ECT
                    if (item.Title == "ECG")
                    {
                        rows = dtMonitorEx.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");
                    }

                    // SP02
                    if (item.Title == "SpO2")
                    {
                        dtak880.Clear();
                        dtak880.Dispose();

                        dtMonitorExrows = dtMonitorEx.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");
                        if (dtMonitorExrows.Length != 0)
                        {
                            foreach (var r in dtMonitorExrows)
                            {
                                DataRow dt = dtak880.NewRow();
                                dt["TIME_POINT"] = r["TIME_POINT"];
                                dt["VALUE"] = r["ITEM_VALUE"];
                                dt["getway"] = "MonitorEx";
                                dtak880.Rows.Add(dt);

                            }
                        }
                        rows = vitalSignData.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT>='" + startTime + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");
                        if (rows.Length != 0)
                        {
                            foreach (var r in rows)
                            {
                                DataRow dt = dtak880.NewRow();
                                dt["TIME_POINT"] = r["TIME_POINT"];
                                dt["VALUE"] = r["ITEM_VALUE"];
                                dt["getway"] = "vitalSignData";
                                dtak880.Rows.Add(dt);

                            }
                        }

                        if (dtak880.Rows.Count != 0)
                        {
                            // 合并，将相同时候项合并掉，取 MonitorEx 中的数据
                            dtSP02CVPTRUEDATE = dtak880.Clone();
                            foreach (DataRowView row in dtak880.DefaultView)
                            {
                                string sAddr = row["TIME_POINT"].ToString().Trim();
                                if (dtSP02CVPTRUEDATE.Select("TIME_POINT='" + sAddr + "'").Length == 0)
                                {
                                    dtSP02CVPTRUEDATE.Rows.Add(sAddr, GetStringValue(row["value"]), GetStringValue(row["getway"]));
                                }
                            }
                        }
                        else
                        {
                            if (dtSP02CVPTRUEDATE != null)
                            {
                                if (dtSP02CVPTRUEDATE.Rows.Count != 0)
                                {
                                    dtSP02CVPTRUEDATE.Clear();
                                    dtSP02CVPTRUEDATE.Dispose();
                                }
                            }
                        }
                    }

                    // BIS
                    if (item.Title == "BIS")
                    {
                        #region 拼装数据


                        dtak880.Clear();
                        dtak880.Dispose();

                        dtMonitorExrows = dtMonitorEx.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");
                        if (dtMonitorExrows.Length != 0)
                        {
                            foreach (var r in dtMonitorExrows)
                            {
                                DataRow dt = dtak880.NewRow();
                                dt["TIME_POINT"] = r["TIME_POINT"];
                                dt["VALUE"] = r["ITEM_VALUE"];
                                dt["getway"] = "MonitorEx";
                                dtak880.Rows.Add(dt);

                            }
                        }
                        rows = vitalSignData.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT>='" + startTime + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");
                        if (rows.Length != 0)
                        {
                            foreach (var r in rows)
                            {
                                DataRow dt = dtak880.NewRow();
                                dt["TIME_POINT"] = r["TIME_POINT"];
                                dt["VALUE"] = r["ITEM_VALUE"];
                                dt["getway"] = "vitalSignData";
                                dtak880.Rows.Add(dt);

                            }
                        }


                        if (dtak880.Rows.Count != 0)
                        {
                            // 合并，将相同时候项合并掉，取 MonitorEx 中的数据
                            dtSP02CVPTRUEDATE = dtak880.Clone();
                            foreach (DataRowView row in dtak880.DefaultView)
                            {
                                string sAddr = row["TIME_POINT"].ToString().Trim();
                                if (dtSP02CVPTRUEDATE.Select("TIME_POINT='" + sAddr + "'").Length == 0)
                                {
                                    dtSP02CVPTRUEDATE.Rows.Add(sAddr, GetStringValue(row["value"]), GetStringValue(row["getway"]));
                                }
                            }
                        }
                        else
                        {
                            if (dtSP02CVPTRUEDATE != null)
                            {
                                if (dtSP02CVPTRUEDATE.Rows.Count != 0)
                                {
                                    dtSP02CVPTRUEDATE.Clear();
                                    dtSP02CVPTRUEDATE.Dispose();
                                }
                            }
                        }
                        #endregion
                    }

                    //ECT02
                    if (item.Title == "EtCO2" || item.Title == "ETCO2" || item.Title == "活动" || item.Title == "意识" || item.Title == "OOA/S")
                    {
                        //rows = dtMonitorEx.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");

                        #region 拼装数据

                        dtak880.Clear();
                        dtak880.Dispose();

                        dtMonitorExrows = dtMonitorEx.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");
                        if (dtMonitorExrows.Length != 0)
                        {
                            foreach (var r in dtMonitorExrows)
                            {
                                DataRow dt = dtak880.NewRow();
                                dt["TIME_POINT"] = r["TIME_POINT"];
                                dt["VALUE"] = r["ITEM_VALUE"];
                                dt["getway"] = "MonitorEx";
                                dtak880.Rows.Add(dt);

                            }
                        }
                        rows = vitalSignData.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT>='" + startTime + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");
                        if (rows.Length != 0)
                        {
                            foreach (var r in rows)
                            {
                                DataRow dt = dtak880.NewRow();
                                dt["TIME_POINT"] = r["TIME_POINT"];
                                dt["VALUE"] = r["ITEM_VALUE"];
                                dt["getway"] = "vitalSignData";
                                dtak880.Rows.Add(dt);
                            }
                        }

                        if (dtak880.Rows.Count != 0)
                        {
                            // 合并，将相同时候项合并掉，取 MonitorEx 中的数据
                            dtSP02CVPTRUEDATE = dtak880.Clone();
                            foreach (DataRowView row in dtak880.DefaultView)
                            {
                                string sAddr = row["TIME_POINT"].ToString().Trim();
                                if (dtSP02CVPTRUEDATE.Select("TIME_POINT='" + sAddr + "'").Length == 0)
                                {
                                    dtSP02CVPTRUEDATE.Rows.Add(sAddr, GetStringValue(row["value"]), GetStringValue(row["getway"]));
                                }
                            }
                        }
                        else
                        {
                            if (dtSP02CVPTRUEDATE != null)
                            {
                                if (dtSP02CVPTRUEDATE.Rows.Count != 0)
                                {
                                    dtSP02CVPTRUEDATE.Clear();
                                    dtSP02CVPTRUEDATE.Dispose();
                                }
                            }
                        }
                        #endregion
                    }

                    //Peak
                    if (item.Title == "Peak")
                    {
                        rows = dtMonitorEx.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");
                    }

                    //CVP
                    if (item.Title == "CVP")
                    {
                        #region 拼装数据

                        dtak880.Clear();
                        dtak880.Dispose();

                        dtMonitorExrows = dtMonitorEx.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");
                        if (dtMonitorExrows.Length != 0)
                        {
                            foreach (var r in dtMonitorExrows)
                            {
                                DataRow dt = dtak880.NewRow();
                                dt["TIME_POINT"] = r["TIME_POINT"];
                                dt["VALUE"] = r["ITEM_VALUE"];
                                dt["getway"] = "MonitorEx";
                                dtak880.Rows.Add(dt);
                            }
                        }
                        rows = vitalSignData.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT>='" + startTime + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");
                        if (rows.Length != 0)
                        {
                            foreach (var r in rows)
                            {
                                DataRow dt = dtak880.NewRow();
                                dt["TIME_POINT"] = r["TIME_POINT"];
                                dt["VALUE"] = r["ITEM_VALUE"];
                                dt["getway"] = "vitalSignData";
                                dtak880.Rows.Add(dt);

                            }
                        }


                        if (dtak880.Rows.Count != 0)
                        {
                            // 合并，将相同时候项合并掉，取 MonitorEx 中的数据
                            dtSP02CVPTRUEDATE = dtak880.Clone();
                            foreach (DataRowView row in dtak880.DefaultView)
                            {
                                string sAddr = row["TIME_POINT"].ToString().Trim();
                                if (dtSP02CVPTRUEDATE.Select("TIME_POINT='" + sAddr + "'").Length == 0)
                                {
                                    dtSP02CVPTRUEDATE.Rows.Add(sAddr, GetStringValue(row["value"]), GetStringValue(row["getway"]));
                                }
                            }
                        }
                        else
                        {
                            if (dtSP02CVPTRUEDATE != null)
                            {
                                if (dtSP02CVPTRUEDATE.Rows.Count != 0)
                                {
                                    dtSP02CVPTRUEDATE.Clear();
                                    dtSP02CVPTRUEDATE.Dispose();
                                }
                            }
                        }
                        #endregion
                    }

                    // 体温
                    if (item.ItemCode.Equals("100") || item.ItemCode.Equals("50006"))
                    {
                        dtak880.Clear();
                        dtak880.Dispose();

                        dtMonitorExrows = dtMonitorEx.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");
                        if (dtMonitorExrows.Length != 0)
                        {
                            foreach (var r in dtMonitorExrows)
                            {
                                DataRow dt = dtak880.NewRow();
                                dt["TIME_POINT"] = r["TIME_POINT"];
                                dt["VALUE"] = r["ITEM_VALUE"];
                                dt["getway"] = "MonitorEx";
                                dtak880.Rows.Add(dt);
                            }
                        }
                        rows = vitalSignData.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT>='" + startTime + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");
                        if (rows.Length != 0)
                        {
                            foreach (var r in rows)
                            {
                                DataRow dt = dtak880.NewRow();
                                dt["TIME_POINT"] = r["TIME_POINT"];
                                dt["VALUE"] = r["ITEM_VALUE"];
                                dt["getway"] = "vitalSignData";
                                dtak880.Rows.Add(dt);

                            }
                        }


                        if (dtak880.Rows.Count != 0)
                        {
                            // 合并，将相同时候项合并掉，取 MonitorEx 中的数据
                            dtSP02CVPTRUEDATE = dtak880.Clone();
                            foreach (DataRowView row in dtak880.DefaultView)
                            {
                                string sAddr = row["TIME_POINT"].ToString().Trim();
                                if (dtSP02CVPTRUEDATE.Select("TIME_POINT='" + sAddr + "'").Length == 0)
                                {
                                    dtSP02CVPTRUEDATE.Rows.Add(sAddr, GetStringValue(row["value"]), GetStringValue(row["getway"]));
                                }
                            }
                        }
                        else
                        {
                            if (dtSP02CVPTRUEDATE != null)
                            {
                                if (dtSP02CVPTRUEDATE.Rows.Count != 0)
                                {
                                    dtSP02CVPTRUEDATE.Clear();
                                    dtSP02CVPTRUEDATE.Dispose();
                                }
                            }
                        }
                    }

                    //Vt/R
                    if (item.Title.ToUpper() == "Vt/R".ToUpper())
                    {
                        #region 拼装数据

                        dtak880.Clear();
                        dtak880.Dispose();

                        dtMonitorExrows = dtMonitorEx.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");
                        if (dtMonitorExrows.Length != 0)
                        {
                            foreach (var r in dtMonitorExrows)
                            {
                                DataRow dt = dtak880.NewRow();
                                dt["TIME_POINT"] = r["TIME_POINT"];
                                dt["VALUE"] = r["ITEM_VALUE"];
                                dt["getway"] = "MonitorEx";
                                dtak880.Rows.Add(dt);

                            }
                        }
                        rows = vitalSignData.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT>='" + startTime + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");
                        if (rows.Length != 0)
                        {
                            foreach (var r in rows)
                            {
                                DataRow dt = dtak880.NewRow();
                                dt["TIME_POINT"] = r["TIME_POINT"];
                                dt["VALUE"] = r["ITEM_VALUE"];
                                dt["getway"] = "vitalSignData";
                                dtak880.Rows.Add(dt);

                            }
                        }


                        if (dtak880.Rows.Count != 0)
                        {
                            // 合并，将相同时候项合并掉，取 MonitorEx 中的数据
                            dtSP02CVPTRUEDATE = dtak880.Clone();
                            foreach (DataRowView row in dtak880.DefaultView)
                            {
                                string sAddr = row["TIME_POINT"].ToString().Trim();
                                if (dtSP02CVPTRUEDATE.Select("TIME_POINT='" + sAddr + "'").Length == 0)
                                {
                                    dtSP02CVPTRUEDATE.Rows.Add(sAddr, GetStringValue(row["value"]), GetStringValue(row["getway"]));
                                }
                            }
                        }
                        else
                        {
                            if (dtSP02CVPTRUEDATE != null)
                            {
                                if (dtSP02CVPTRUEDATE.Rows.Count != 0)
                                {
                                    dtSP02CVPTRUEDATE.Clear();
                                    dtSP02CVPTRUEDATE.Dispose();
                                }
                            }
                        }
                        #endregion
                    }

                    // 尿累
                    if (itemCode == "D")
                    {
                        rows = anesEventTable.Select("ITEM_CLASS = '" + item.ItemCode + "' AND ITEM_NAME='尿量' and START_TIME>='" + startTime + "' and START_TIME<='" + endTime + "'", "START_TIME ASC");
                    }

                    if (itemCode == "D")  // 出液 - 尿量
                    {
                        //分别计算每行每列的值
                        for (int i = 0; i < control.Cols.Count; i++)
                        {
                            //根据时间间隔，设置行单元格的时间点
                            var timePoint = startTime.AddMinutes(((int)item.ShowTimeInterval) * i);
                            item.Cells[i].Value = string.Empty;
                            item.Cells[i].TimePoint = timePoint;

                            float ak47Val = 0;

                            foreach (var r in rows)
                            {
                                var time = Convert.ToDateTime(r["START_TIME"]);

                                //根据时间点取值
                                if (timePoint == time || (timePoint < time && time < timePoint.AddMinutes((int)item.ShowTimeInterval)))
                                {
                                    ak47Val += r["DOSAGE"] != null ? float.Parse(r["DOSAGE"].ToString()) : 0;
                                    item.Cells[i].Value = ak47Val.ToString();
                                    //item.Cells[i].Value = r["DOSAGE"] != null ? r["DOSAGE"].ToString() : string.Empty;
                                    if (item.Cells[i].Value.Equals("0")) item.Cells[i].Value = string.Empty;
                                    item.Cells[i].TimePoint = time;
                                    //break;
                                }
                            }
                        }
                    }
                    else if (item.Title == "ECG")
                    {
                        //分别计算每行每列的值
                        for (int i = 0; i < control.Cols.Count; i++)
                        {
                            //根据时间间隔，设置行单元格的时间点
                            var timePoint = startTime.AddMinutes(((int)item.ShowTimeInterval) * i);
                            item.Cells[i].Value = string.Empty;
                            item.Cells[i].TimePoint = timePoint;
                            foreach (var r in rows)
                            {
                                var time = Convert.ToDateTime(r["TIME_POINT"]);

                                //根据时间点取值
                                if (timePoint == time || (timePoint < time && time < timePoint.AddMinutes((int)item.ShowTimeInterval)))
                                {
                                    string showValue = this.CustomShowValue(curveDetail, item, r["ITEM_VALUE"]);
                                    item.Cells[i].Value = showValue;
                                    item.Cells[i].TimePoint = time;
                                    break;
                                }
                            }
                        }
                    }
                    else if (item.Title == "Peak")
                    {
                        //分别计算每行每列的值
                        for (int i = 0; i < control.Cols.Count; i++)
                        {
                            //根据时间间隔，设置行单元格的时间点
                            var timePoint = startTime.AddMinutes(((int)item.ShowTimeInterval) * i);
                            item.Cells[i].Value = string.Empty;
                            item.Cells[i].TimePoint = timePoint;
                            foreach (var r in rows)
                            {
                                var time = Convert.ToDateTime(r["TIME_POINT"]);

                                //根据时间点取值
                                if (timePoint == time || (timePoint < time && time < timePoint.AddMinutes((int)item.ShowTimeInterval)))
                                {
                                    string showValue = this.CustomShowValue(curveDetail, item, r["ITEM_VALUE"]);
                                    item.Cells[i].Value = showValue;
                                    item.Cells[i].TimePoint = time;
                                    break;
                                }
                            }
                        }
                    }
                    else    //  SP02 或者　CVP  或者  EtCO2  在这里处理的
                    {
                        DataRow[] ak704 = null;
                        if (dtSP02CVPTRUEDATE != null)
                        {
                            if (dtSP02CVPTRUEDATE.Rows.Count != 0)
                            {
                                ak704 = dtSP02CVPTRUEDATE.Select("1=1", "TIME_POINT ASC");
                            }
                        }

                        //分别计算每行每列的值
                        for (int i = 0; i < control.Cols.Count; i++)
                        {
                            //根据时间间隔，设置行单元格的时间点
                            var timePoint = startTime.AddMinutes(((int)item.ShowTimeInterval) * i);
                            item.Cells[i].Value = string.Empty;
                            item.Cells[i].TimePoint = timePoint;

                            if (ak704 != null)
                            {
                                if (ak704.Length != 0)
                                {
                                    foreach (var r in ak704)
                                    {
                                        var time = Convert.ToDateTime(r["TIME_POINT"]);

                                        //根据时间点取值
                                        // if (timePoint == time || (timePoint < time && time < timePoint.AddMinutes((int)item.ShowTimeInterval)))
                                        if(timePoint == time)
                                        {
                                            string showValue = this.CustomShowValue(curveDetail, item, r["VALUE"]);
                                            item.Cells[i].Value = showValue;
                                            item.Cells[i].TimePoint = time;
                                            break;
                                        }
                                    }
                                }
                            }

                        }
                    }
                    control.Invalidate();
                }

                #region　ＥＣＧ特殊处理，持续显示，至手术结束时间

                //{获取原有ECG初始值,并取在数组中}
                //string[] ak46 = new string[control.Cols.Count];
                //for (int ii = 0; ii < control.Cols.Count; ii++)
                //{
                //    string itemTrueVal = GetStringValue(control.Rows[control.Rows.Count - control.Rows.Count].Cells[ii].Value);
                //    if (itemTrueVal.Trim().Length == 0)
                //    {
                //        ak46[ii] = "X-X-FUCK-JAPAN";
                //    }
                //    else
                //    {
                //        ak46[ii] = itemTrueVal;
                //    }

                //}

                //var itemECG = control.Rows[0];
                //if (itemECG.Title.ToUpper() == "ECG")
                //{
                //    for (int i = 0; i < control.Cols.Count; i++)
                //    {
                //        var timePoint = startTime.AddMinutes(((int)itemECG.ShowTimeInterval) * i);
                //        if (timePoint <= dtOpertionEnd)
                //        {
                //            itemECG.Cells[i].Value = GetStringValue(ak46[i]);
                //            if (i != 0)
                //            {
                //                if (GetStringValue(itemECG.Cells[i].Value).Trim() == "X-X-FUCK-JAPAN")
                //                {
                //                    string strItemqECG = GetStringValue(itemECG.Cells[i - 1].Value).Trim();
                //                    itemECG.Cells[i].Value = strItemqECG;
                //                }
                //            }
                //            else
                //            {
                //                if (GetStringValue(itemECG.Cells[i].Value).Trim() == "X-X-FUCK-JAPAN")
                //                {
                //                    itemECG.Cells[i].Value = "";
                //                }
                //            }

                //        }
                //    }
                //}

                #endregion



            }
        }

        private string CustomShowValue(List<MedVitalSignCurveDetail> curveDetail, MedSheetRow item, object rowValue)
        {
            string showValue = string.Empty;
            double tempValue = -1.0;
            if (rowValue != null && double.TryParse(rowValue.ToString(), out tempValue) && tempValue > 0)
            {
                MedVitalSignCurveDetail tempCurveDetail = curveDetail.Find(x => x.CurveCode.Equals(item.ItemCode));
                if (null != tempCurveDetail)
                {
                    showValue = tempValue.ToString(string.Format("F{0}", tempCurveDetail.DotNumber));
                }
                else
                {
                    showValue = tempValue.ToString(string.Format("F{0}", 0));
                }
            }
            else
            {
                showValue = rowValue == null ? string.Empty : rowValue.ToString();
            }

            return showValue;
        }
        public override void BindUIToData(MedSheet control, Dictionary<string, System.Data.DataTable> dataSources)
        {

        }

        public override void ControlSetting(MedSheet control)
        {
            _textBox.Font = control.Font;
            // control.Click += new EventHandler(MedSheet_Click);
        }

        private void MedSheet_Click(object sender, EventArgs e)
        {
            MouseEventArgs arg = e as MouseEventArgs;
            if (arg == null || (arg.X == 0 && arg.Y == 0))
                return;

            MedSheet control = base.GetCurrentControl as MedSheet;

            if (arg.Button == MouseButtons.Right)
            {
                foreach (MedSheetRow row in control.Rows)
                {
                    foreach (MedSheetCell cell in row.Cells)
                    {
                        if (cell.DrawRectangel.Contains(arg.X, arg.Y))
                        {
                            EditValue(cell);
                            RefreshData();
                            return;
                        }
                    }
                }
            }
            else if (arg.Button == MouseButtons.Left)
            {
                if (_textBox.Visible)
                {
                    TextBox_LostFocus(null, null);
                }
            }

        }

        protected void EditValue(MedSheetCell cell)
        {
            MedSheet control = base.GetCurrentControl as MedSheet;
            _textBox.Text = "";
            _textBox.Location = cell.DrawRectangel.Location;
            _textBox.Width = cell.DrawRectangel.Width;
            _textBox.Height = cell.DrawRectangel.Height;
            _textBox.Parent = control;

            MedSheetRow row = control.Rows[cell.RowIndex];



            if (!string.IsNullOrEmpty(row.DictTableName) && !string.IsNullOrEmpty(row.DictValueFieldName))
            {
                DataRow[] rows = BuildPopupItemsData(row.DictTableName, row.DictWhereString);
                string displayName = !string.IsNullOrEmpty(row.DisplayFieldName) ? row.DisplayFieldName.ToUpper() : row.DictValueFieldName.ToUpper();
                //Dialog.ShowCustomSelection(rows, displayName, _textBox,
                //   new System.Drawing.Size(_textBox.Width, 300), new EventHandler(delegate(object sender1, EventArgs e1)
                //   {
                //       if (sender1 is int)
                //       {
                //           int result = (int)sender1;
                //           if (result > -1)
                //           {
                //               _textBox.Text = rows[result][row.DisplayFieldName].ToString();
                //               _textBox.Tag = cell;
                //               TextBox_LostFocus(null, null);
                //           }
                //       }
                //   }));
            }
            else
            {
                _textBox.BorderStyle = BorderStyle.FixedSingle;
                _textBox.Text = cell.Value == null ? "" : cell.Value.ToString();
                _textBox.Tag = cell;
                _textBox.Visible = true;
                _textBox.Focus();


            }
        }


        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            _textBox.Visible = false;
            _textBox.Parent = null;

            if (_textBox.Tag != null)
            {
                try
                {
                    MedSheet control = base.GetCurrentControl as MedSheet;
                    MedSheetCell cell = _textBox.Tag as MedSheetCell;
                    MedSheetRow row = control.Rows[cell.RowIndex];

                    if ((cell.Value != null && cell.Value.ToString() != _textBox.Text) || (cell.Value == null && !string.IsNullOrEmpty(_textBox.Text.Trim())))
                    {
                        cell.Value = _textBox.Text;
                        if (cell.TimePoint.Date == DateTime.MinValue.Date)
                            throw new Exception("表格时间发生错误");

                        SaveEditData(cell, row);


                        RefreshData();
                    }
                }
                catch (Exception err)
                {
                    // ExceptionHandler.Handle(err);
                }
            }

            _textBox.Tag = null;
        }

        protected void SaveEditData(MedSheetCell cell, MedSheetRow sheetRow)
        {
            //DataTable dtMonitorEx = base.DataSource["MED_PAT_MONITOR_DATA_EXT"];
            //dtMonitorEx.TableName = "MED_PAT_MONITOR_DATA_EXT";

            //AnesInformations.AnesthesiaEventDataTable anesEventTable = DataContext.GetCurrent().GetAnesthesiaEvent(_eventNo);
            ////base.DataSource["AnesthesiaEvent"] as AnesInformations.AnesthesiaEventDataTable;

            //if (sheetRow.ItemCode == "D")  // 出液 -尿量
            //{
            //    string itemname = "尿量";
            //    DataRow[] rows = anesEventTable.Select("ITEM_NAME = '" + itemname + "' and START_TIME='" + cell.TimePoint + "'", "START_TIME");
            //    if (rows.Length == 0 && !string.IsNullOrEmpty(_textBox.Text))
            //    {
            //        AnesInformations.AnesthesiaEventRow eventRow = DataContext.GetCurrent().NewAnesthesiaEventRow(anesEventTable, 0);
            //        eventRow.ITEM_CLASS = "D";
            //        eventRow.ITEM_NAME = itemname;
            //        eventRow.DOSAGE_UNITS = "ml";
            //        eventRow.START_TIME = cell.TimePoint;
            //        eventRow.DOSAGE = Convert.ToDecimal(_textBox.Text);
            //        anesEventTable.Rows.Add(eventRow);
            //        DataContext.GetCurrent().UpdateAnesthesiaEvent(anesEventTable);


            //    }
            //    else if (rows.Length > 0)
            //    {
            //        if (string.IsNullOrEmpty(_textBox.Text))
            //            rows[0].Delete();
            //        else
            //            rows[0]["DOSAGE"] = Convert.ToDecimal(_textBox.Text);

            //        DataContext.GetCurrent().UpdateAnesthesiaEvent(anesEventTable);
            //    }
            //}
            //else
            //{
            //    double min = 0;
            //    switch (sheetRow.ShowTimeInterval)
            //    {
            //        case MedShowTimeInterval.Fifiteen:
            //            min = 15;
            //            break;
            //        case MedShowTimeInterval.Five:
            //            min = 5;
            //            break;
            //        case MedShowTimeInterval.HalfHour:
            //            min = 15;
            //            break;
            //        case MedShowTimeInterval.Hour:
            //            min = 60;
            //            break;
            //        case MedShowTimeInterval.Ten:
            //            min = 10;
            //            break;
            //        case MedShowTimeInterval.Twenty:
            //            min = 20;
            //            break;
            //    }
            //    DateTime dt = cell.TimePoint.AddMinutes(min);
            //    DataRow[] rows = dtMonitorEx.Select("ITEM_CODE = '" + sheetRow.ItemCode + "' and TIME_POINT >='" + cell.TimePoint + "' and TIME_POINT < '" + dt + "'", "TIME_POINT ASC");
            //    if (rows.Length == 0 && !string.IsNullOrEmpty(_textBox.Text))
            //    {
            //        string patientId = ExtendApplicationContext.Current.PatientContext.PatientID;
            //        decimal visitId = ExtendApplicationContext.Current.PatientContext.VisitID;
            //        decimal operId = ExtendApplicationContext.Current.PatientContext.OperID;

            //        DataRow row = dtMonitorEx.NewRow();
            //        row["PATIENT_ID"] = patientId;
            //        row["VISIT_ID"] = visitId;
            //        row["OPER_ID"] = operId;
            //        row["TIME_POINT"] = cell.TimePoint;
            //        row["ITEM_CODE"] = sheetRow.ItemCode;
            //        row["ITEM_VALUE"] = _textBox.Text;
            //        row["RECORDING_DATE"] = System.DateTime.Now;
            //        dtMonitorEx.Rows.Add(row);

            //        new CommonDA().UpdateDataTable(dtMonitorEx);
            //    }
            //    else if (rows.Length > 0)
            //    {
            //        if (string.IsNullOrEmpty(_textBox.Text))
            //            rows[0].Delete();
            //        else
            //        {
            //            //MessageBox.Show(string.Format("{0}~{1},{2} Text is {3}",cell.TimePoint, dt, sheetRow.ItemCode, _textBox.Text));
            //            for (int i = 0; i < rows.Length; i++)
            //            {
            //                rows[i]["ITEM_VALUE"] = _textBox.Text;
            //                rows[i]["RECORDING_DATE"] = System.DateTime.Now;
            //            }
            //        }

            //        int result = new CommonDA().UpdateDataTable(dtMonitorEx);
            //        //MessageBox.Show("result is " + result.ToString());
            //    }
            //}

        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox_LostFocus(sender, e);
            }
        }
    }
}