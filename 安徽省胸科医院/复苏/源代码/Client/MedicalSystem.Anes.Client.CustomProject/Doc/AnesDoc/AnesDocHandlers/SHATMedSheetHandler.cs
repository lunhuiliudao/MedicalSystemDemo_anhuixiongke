using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork.Documents;
using MedicalSystem.Anes.Client.FrameWork.Controls;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.FrameWork.Configurations;

namespace MedicalSystem.Anes.Client.CustomProject
{
    public class SHATMedSheetHandler : UIElementHandler<MedSheet>
    {
        CommonDA cda = new CommonDA();
        protected MTextBox _textBox = new MTextBox();
        protected int _eventNo = 0;
        DataTable dtSP02CVPTRUEDATE = null;
        string MedSheetContinue = CustomSetting.CustomSetting.MedSheetContinue;

        public SHATMedSheetHandler(int evo)
        {
            _textBox.Visible = false;
            _textBox.BorderStyle = BorderStyle.FixedSingle;
            _textBox.LostFocus += new EventHandler(TextBox_LostFocus);
            _textBox.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            _eventNo = 0;
        }

        public override void BindDataToUI(MedSheet control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            if (!dataSources.ContainsKey("VitalSignData"))
                throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表AnesInformations.VitalSignDataTable,请添加此绑定数据源!", "VitalSignData"));

            AnesInformations.VitalSignDataTable vitalSignData = dataSources["VitalSignData"] as AnesInformations.VitalSignDataTable;
            AnesInformations.OperationMasterDataTable operationMasterDataTable = dataSources["MED_OPERATION_MASTER"] as AnesInformations.OperationMasterDataTable;
            DataTable dtMonitorEx = dataSources["MED_PAT_MONITOR_DATA_EXT"];
            AnesInformations.AnesthesiaEventDataTable anesEventTable = dataSources["AnesthesiaEvent"] as AnesInformations.AnesthesiaEventDataTable;

            var startTime = PagerSetting.PageTimeSpan.StartDateTime;
            var endTime = PagerSetting.PageTimeSpan.EndDateTime;
            DateTime dtOpertionEnd = endTime < System.DateTime.Now ? endTime : System.DateTime.Now;
            if (!operationMasterDataTable[0].IsOUT_DATE_TIMENull())//手术结束
            {
                dtOpertionEnd = operationMasterDataTable[0].OUT_DATE_TIME;
            }

            #region 这个是杀么东须捏，这是用来处理 SP02 或者　CVP　这种采集数据的修改，而存放的临时ＤＡＴＡＴＡＢＬＥ
            DataTable dtak880 = new DataTable();
            dtak880.Columns.Add("TIME_POINT");
            dtak880.Columns.Add("VALUE");
            dtak880.Columns.Add("getway");
            #endregion


            #region 右击麻醉单上的曲线区域，对其进行个性化的修改, 把其中用数字显示的都写到麻醉单上“监测项目”中的2行空白处，2行写不下后写到曲线区域的上方
            List<MedVitalSignCurveDetail> list = GetUserVitalShowSet(_eventNo);
            Dictionary<string, MedVitalSignCurveDetail> dict = new Dictionary<string, MedVitalSignCurveDetail>();
            AnesInformations.VitalSignDataTable _VitalSignData = base.DataSource["VitalSignData"] as AnesInformations.VitalSignDataTable;
            foreach (MedVitalSignCurveDetail vitalSet in list)
            {
                if (!string.IsNullOrEmpty(vitalSet.CurveCode) && !dict.ContainsKey(vitalSet.CurveCode))
                {
                    if (vitalSet.Visible) // 不显示，ＴＭＤ就不要加进去了。
                    {
                        dict.Add(vitalSet.CurveCode, vitalSet);
                    }
                }
                else if (string.IsNullOrEmpty(vitalSet.CurveCode) && !string.IsNullOrEmpty(vitalSet.CurveName))
                {
                    foreach (AnesInformations.VitalSignRow vrow in _VitalSignData.Rows)
                    {
                        if (vrow.ITEM_NAME.Equals(vitalSet.CurveName) && !dict.ContainsKey(vrow.ITEM_CODE))
                        {
                            dict.Add(vrow.ITEM_CODE, vitalSet);
                            break;
                        }
                    }
                }
            }
            MedVitalSignGraph _vitalGraph = null;
            foreach (Medicalsystem.Anes.Framework.Doc.IUIElementHandler handler in MedicalPaperUIElementHandlers)
            {
                if (handler.GetControlType == typeof(MedVitalSignGraph) && handler.GetCurrentControl != null)
                    _vitalGraph = handler.GetCurrentControl as MedVitalSignGraph;
            }
            foreach (MedVitalSignCurve curve in _vitalGraph.Curves)
            {
                //_vitalGraph.CurveDetails
                if (!string.IsNullOrEmpty(curve.Code) && !dict.ContainsKey(curve.Code))
                {
                    MedVitalSignCurveDetail vitalSet = new MedVitalSignCurveDetail();
                    vitalSet.CurveName = curve.Text;
                    vitalSet.CurveCode = string.IsNullOrEmpty(curve.Code) ? curve.Text : curve.Code;
                    vitalSet.Color = curve.Color;
                    if (GetVitalSignDetail(_vitalGraph, vitalSet.CurveCode) != null)
                    {
                        vitalSet.ShowTimeInterval = GetVitalSignDetail(_vitalGraph, vitalSet.CurveCode).ShowTimeInterval;
                    }
                    if (curve.IsDigit) vitalSet.ShowType = MedCurveShowType.Digit;
                    vitalSet.SymbolType = curve.Symbol.SymbolType;
                    if (vitalSet.SymbolType == MedSymbolType.Text)
                    {
                        vitalSet.SymbolEntry = curve.Symbol.Text;
                    }
                    vitalSet.YAxisIndex = curve.YAxisIndex;
                    vitalSet.DotNumber = curve.DotNumber;
                    if (!dict.ContainsKey(vitalSet.CurveCode))
                    {
                        dict.Add(vitalSet.CurveCode, vitalSet);
                        list.Add(vitalSet);
                    }
                }
            }

            #region 2013-06-05 周青 麻醉单数值型体征显示异常

            //MedVitalSignGraph _vitalGraph1 = new MedVitalSignGraph();
            //_vitalGraph1 = _vitalGraph;
            //DataView dv = new DataView(vitalSignData);
            //DataTable vitalSignData1 = dv.ToTable(true, "ITEM_CODE");
            //foreach (MedVitalSignCurveDetail detail in _vitalGraph1.CurveDetails)
            //{
            //    if (detail.ShowType == MedCurveShowType.Digit)
            //    {
            //        DataRow[] rows = vitalSignData1.Select("ITEM_CODE='" + detail.CurveCode + "'");
            //        if (rows.Length > 0)
            //        {
            //            list.Add(detail);
            //        }
            //    }
            //}

            #endregion

            string tableName = "UserVitalShowSet" + ((_eventNo < 0) ? 0 : _eventNo).ToString();
            DataTable dataTable = new DataTable(tableName);//复苏单可约定数据表名称为UserVitalShowSet1,末尾与EventNo关联
            System.Reflection.PropertyInfo[] propertyInfos = typeof(MedVitalSignCurveDetail).GetProperties();
            foreach (System.Reflection.PropertyInfo propertyInfo in propertyInfos)
            {
                dataTable.Columns.Add(propertyInfo.Name);
            }
            foreach (MedVitalSignCurveDetail obj in list)
            {
                DataRow row = dataTable.NewRow();
                foreach (System.Reflection.PropertyInfo propertyInfo in propertyInfos)
                {
                    row[propertyInfo.Name] = Medicalsystem.Anes.Framework.Controls.Base.AssemblyHelper.GetPropertyValue(propertyInfo, obj);
                }
                dataTable.Rows.Add(row);
            }


            DataRow[] ak47 = dataTable.Select("ShowType='Digit' AND visible='true' AND curveName<>'SpO2' AND curveName<>'EtCO2' AND curveName<>'体温' ");  // 要求将数字类型的抓取出来
            string strcurvenamelist = "";
            string codecodecode = "";
            for (int i = 0; i < ak47.Length; i++)
            {
                if (i < 2) // 只要求加入2个
                {
                    strcurvenamelist += ak47[i]["curveName"].ToString() + ",";
                    codecodecode += ak47[i]["curveCode"].ToString() + ",";
                }
            }

            // 插入病人填充监测项目表
            //if (strcurvenamelist.Trim().Length != 0)
            //{
            //    string deleteSql = "delete from MED_PATIENT_FILL_MONITORING WHERE 病人号='" + ExtendApplicationContext.Current.PatientContext.PatientID + "' AND 住院号=" + ExtendApplicationContext.Current.PatientContext.VisitID +
            //                       " AND 手术号=" + ExtendApplicationContext.Current.PatientContext.OperID;
            //    cda.ExecuteNonQuery(deleteSql);
            //    string insertSql = "insert into  MED_PATIENT_FILL_MONITORING (病人号,住院号,手术号,监测项目,备注,创建人,创建日期) " +
            //                       " values ('" + ExtendApplicationContext.Current.PatientContext.PatientID + "'," + ExtendApplicationContext.Current.PatientContext.VisitID + "," +
            //                        ExtendApplicationContext.Current.PatientContext.OperID + ",'" + strcurvenamelist + "','" + codecodecode + "','" + ExtendApplicationContext.Current.LoginUserContext.LoginName + "','" + System.DateTime.Now + "')";
            //    cda.ExecuteNonQuery(insertSql);
            //}
            // end ----

            string[] arryFillMonitoringList = strcurvenamelist.Split(',');
            string[] arryFillMonitoringListCode = codecodecode.Split(',');
            int ifiimonStep = 0;
            #endregion

            for (int n = 0; n < control.Rows.Count; n++)
            {
                var item = control.Rows[n];
                //根据当前页的开始时间，结束时间，配置的行体症项，取数据，按时间做升序排序
                string itemCode = string.IsNullOrEmpty(item.ItemCode) ? item.Title : item.ItemCode;
                DataRow[] rows = null;
                DataRow[] dtMonitorExrows = null;

                if (item.IsGdShow)
                //if (item.Title != "")
                {
                    #region 这部分代码是自动从个性化表中加载过来的数据．
                    if (GetStringValue(item.ItemCode).Trim().Length == 0)
                    {
                        item.Title = GetStringValue(arryFillMonitoringList[ifiimonStep]);
                        if (GetStringValue(item.Title).Trim().Length != 0)
                        {
                            #region 拼装数据
                            dtak880.Clear();
                            dtak880.Dispose();

                            dtMonitorExrows = dtMonitorEx.Select("ITEM_NAME = '" + item.Title + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");
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
                            rows = vitalSignData.Select("ITEM_NAME = '" + item.Title + "' and TIME_POINT>='" + startTime + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");
                            if (rows.Length != 0)
                            {
                                control.Rows[n].ItemCode = rows[0]["ITEM_CODE"].ToString();
                                foreach (var r in rows)
                                {
                                    DataRow dt = dtak880.NewRow();
                                    dt["TIME_POINT"] = r["TIME_POINT"];
                                    dt["VALUE"] = r["VALUE"];
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
                            #region 显示数据
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
                                            if (timePoint == time || (timePoint < time && time < timePoint.AddMinutes((int)item.ShowTimeInterval)))
                                            {

                                                item.Cells[i].Value = r["VALUE"] != null ? r["VALUE"].ToString() : string.Empty;

                                                if (item.Cells[i].Value.Equals("0")) item.Cells[i].Value = string.Empty;
                                                item.Cells[i].TimePoint = time;
                                                break;
                                            }
                                        }
                                    }
                                }

                            }
                            #endregion
                        }
                        ifiimonStep++;
                    }
                    #endregion

                    // ECG
                    if (item.Title == "ECG")
                    {
                        rows = dtMonitorEx.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");
                    }
                    // SP02
                    if (item.Title == "SPO2")
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
                                dt["VALUE"] = r["VALUE"];
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
                    if (item.Title == "EtCO2")
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
                                dt["VALUE"] = r["VALUE"];
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
                    //TVE
                    if (item.Title == "TVE")
                    {
                        rows = dtMonitorEx.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");
                    }
                    //I:E
                    if (item.Title == "I:E")
                    {
                        rows = dtMonitorEx.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");
                    }
                    // f
                    if (item.Title.ToUpper() == "F")
                    {
                        rows = dtMonitorEx.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");
                    }


                    /************************************************************************************************
                     *  这是根据上面匹配到的条件，得到的数据进行填充列表*********************************************
                     ***********************************************************************************************/

                    if (item.Title == "ECG")
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

                                    item.Cells[i].Value = r["ITEM_VALUE"] != null ? r["ITEM_VALUE"].ToString() : string.Empty;

                                    if (item.Cells[i].Value.Equals("0")) item.Cells[i].Value = string.Empty;
                                    item.Cells[i].TimePoint = time;

                                    break;
                                }
                            }


                        }
                    }
                    else if (item.Title == "TVE")
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
                                    item.Cells[i].Value = r["ITEM_VALUE"] != null ? r["ITEM_VALUE"].ToString() : string.Empty;
                                    if (item.Cells[i].Value.Equals("0")) item.Cells[i].Value = string.Empty;
                                    item.Cells[i].TimePoint = time;


                                    break;
                                }
                            }
                        }

                    }
                    else if (item.Title == "I:E")
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
                                    item.Cells[i].Value = r["ITEM_VALUE"] != null ? r["ITEM_VALUE"].ToString() : string.Empty;
                                    if (item.Cells[i].Value.Equals("0")) item.Cells[i].Value = string.Empty;
                                    item.Cells[i].TimePoint = time;


                                    break;
                                }
                            }
                        }

                    }
                    else if (item.Title.ToUpper() == "F")
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
                                    item.Cells[i].Value = r["ITEM_VALUE"] != null ? r["ITEM_VALUE"].ToString() : string.Empty;
                                    if (item.Cells[i].Value.Equals("0")) item.Cells[i].Value = string.Empty;
                                    item.Cells[i].TimePoint = time;


                                    break;
                                }
                            }
                        }

                    }
                    else if (item.Title.Trim().Equals("SPO2") || item.Title.Trim().Equals("EtCO2"))   //  SP02  或者  EtCO2  在这里处理的
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
                                        if (timePoint == time || (timePoint < time && time < timePoint.AddMinutes((int)item.ShowTimeInterval)))
                                        {

                                            item.Cells[i].Value = r["VALUE"] != null ? r["VALUE"].ToString() : string.Empty;

                                            if (item.Cells[i].Value.Equals("0")) item.Cells[i].Value = string.Empty;
                                            item.Cells[i].TimePoint = time;
                                            break;
                                        }
                                    }
                                }
                            }

                        }

                    }
                    else
                    {
                        if (vitalSignData.Select("ITEM_NAME = '" + item.Title + "' and TIME_POINT>='" + startTime + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC").Length == 0
                            && dtMonitorEx.Select("ITEM_NAME = '" + item.Title + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC").Length == 0)
                        {
                            control.Rows[n].ItemCode = "";
                            foreach (MedSheetCell scell in control.Rows[n].Cells)
                            {
                                scell.Value = "";
                            }
                        }
                    }
                }
                else  // 为空的时候,自动加载
                {
                    try
                    {
                        item.Title = GetStringValue(arryFillMonitoringList[ifiimonStep]);
                        item.ItemCode = GetStringValue(arryFillMonitoringListCode[ifiimonStep]);
                        if (item.Title.Trim().Length != 0)
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
                            rows = vitalSignData.Select("ITEM_NAME = '" + item.Title + "' and TIME_POINT>='" + startTime + "' and TIME_POINT<='" + endTime + "'", "TIME_POINT ASC");
                            if (rows.Length != 0)
                            {
                                foreach (var r in rows)
                                {
                                    DataRow dt = dtak880.NewRow();
                                    dt["TIME_POINT"] = r["TIME_POINT"];
                                    dt["VALUE"] = r["VALUE"];
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
                            #region 显示数据
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
                                            if (timePoint == time || (timePoint < time && time < timePoint.AddMinutes((int)item.ShowTimeInterval)))
                                            {

                                                item.Cells[i].Value = r["VALUE"] != null ? r["VALUE"].ToString() : string.Empty;

                                                if (item.Cells[i].Value.Equals("0")) item.Cells[i].Value = string.Empty;
                                                item.Cells[i].TimePoint = time;
                                                break;
                                            }
                                        }
                                    }
                                }

                            }
                            #endregion
                        }
                        ifiimonStep++;

                    }
                    catch { }

                }

                control.Invalidate();
            }

            //2013-12-11 周青 监测项目个性化设置
            List<MedSheetDetail> medSheetSets = GetUserMedSheetShowSet(_eventNo);

            if (medSheetSets.Count > 0)
            {
                foreach (MedSheetDetail detail in medSheetSets)
                {
                    for (int n = 0; n < control.Rows.Count; n++)
                    {
                        var item = control.Rows[n];

                        if (item.Title.ToUpper() == detail.CurveName.ToUpper() && detail.Visible == true)
                        {
                            string[] akTVE = new string[control.Cols.Count];
                            for (int ii = 0; ii < control.Cols.Count; ii++)
                            {
                                string itemTrueVal = GetStringValue(item.Cells[ii].Value);
                                if (itemTrueVal.Trim().Length == 0)
                                {
                                    akTVE[ii] = "X-X-FUCK-KOREA";
                                }
                                else
                                {
                                    akTVE[ii] = itemTrueVal;
                                }
                            }


                            #region 如果是翻页，则第一个值获取前一个值
                            try
                            {
                                if (PagerSetting.PageTimeSpan.StartDateTime > operationMasterDataTable[0].IN_DATE_TIME && PagerSetting.PageTimeSpan.StartDateTime <= dtOpertionEnd)
                                {
                                    DataRow[] ckckckckck = dtMonitorEx.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT<='" + PagerSetting.PageTimeSpan.StartDateTime + "'", "TIME_POINT ASC");
                                    int iaklent = ckckckckck.Length;
                                    DataRow ckLastrow = ckckckckck[iaklent - 1];
                                    akTVE.SetValue(GetStringValue(ckLastrow["item_value"]), 0);
                                }
                            }
                            catch { }
                            #endregion

                            for (int i = 0; i < control.Cols.Count; i++)
                            {
                                var timePoint = startTime.AddMinutes(((int)item.ShowTimeInterval) * i);
                                if (timePoint <= dtOpertionEnd)
                                {
                                    item.Cells[i].Value = GetStringValue(akTVE[i]);
                                    if (i != 0)
                                    {
                                        if (GetStringValue(item.Cells[i].Value).Trim() == "X-X-FUCK-KOREA")
                                        {
                                            string strItemqECG = GetStringValue(item.Cells[i - 1].Value).Trim();
                                            item.Cells[i].Value = strItemqECG;
                                        }
                                    }
                                    else
                                    {
                                        if (GetStringValue(item.Cells[i].Value).Trim() == "X-X-FUCK-KOREA")
                                        {
                                            item.Cells[i].Value = "";
                                        }
                                    }

                                }
                            }

                        }
                    }
                }
            }
            else
            {
                string[] MedSheetContinueList = MedSheetContinue.Split(',');
                if (MedSheetContinueList.Length > 0)
                {
                    foreach (string str in MedSheetContinueList)
                    {
                        for (int n = 0; n < control.Rows.Count; n++)
                        {
                            var item = control.Rows[n];
                            if (str.ToString().Trim().ToUpper() != item.Title.ToUpper())
                            {
                                continue;
                            }
                            string[] akTVE = new string[control.Cols.Count];
                            for (int ii = 0; ii < control.Cols.Count; ii++)
                            {
                                string itemTrueVal = GetStringValue(item.Cells[ii].Value);
                                if (itemTrueVal.Trim().Length == 0)
                                {
                                    akTVE[ii] = "X-X-FUCK-KOREA";
                                }
                                else
                                {
                                    akTVE[ii] = itemTrueVal;
                                }
                            }

                            #region 如果是翻页，则第一个值获取前一个值
                            try
                            {
                                if (PagerSetting.PageTimeSpan.StartDateTime > operationMasterDataTable[0].IN_DATE_TIME && PagerSetting.PageTimeSpan.StartDateTime <= dtOpertionEnd)
                                {
                                    DataRow[] ckckckckck = dtMonitorEx.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT<='" + PagerSetting.PageTimeSpan.StartDateTime + "'", "TIME_POINT ASC");
                                    int iaklent = ckckckckck.Length;
                                    DataRow ckLastrow = ckckckckck[iaklent - 1];
                                    akTVE.SetValue(GetStringValue(ckLastrow["item_value"]), 0);
                                }
                            }
                            catch { }
                            #endregion

                            for (int i = 0; i < control.Cols.Count; i++)
                            {
                                var timePoint = startTime.AddMinutes(((int)item.ShowTimeInterval) * i);
                                if (timePoint <= dtOpertionEnd)
                                {
                                    item.Cells[i].Value = GetStringValue(akTVE[i]);
                                    if (i != 0)
                                    {
                                        if (GetStringValue(item.Cells[i].Value).Trim() == "X-X-FUCK-KOREA")
                                        {
                                            string strItemqECG = GetStringValue(item.Cells[i - 1].Value).Trim();
                                            item.Cells[i].Value = strItemqECG;
                                        }
                                    }
                                    else
                                    {
                                        if (GetStringValue(item.Cells[i].Value).Trim() == "X-X-FUCK-KOREA")
                                        {
                                            item.Cells[i].Value = "";
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }

            #region
            //2013-11-29 20：24 周青 紧急修改 注释 不自动延续
            // --- 特殊要求
            //for (int n = 0; n < control.Rows.Count; n++)
            //{
            //    var item = control.Rows[n];

            //    #region　ＥＣＧ特殊处理，持续显示，至手术结束时间
            //    if (item.Title == "ECG")
            //    {
            //        //{获取原有ECG初始值,并取在数组中}
            //        string[] ak46 = new string[control.Cols.Count];
            //        for (int ii = 0; ii < control.Cols.Count; ii++)
            //        {
            //            string itemTrueVal = GetStringValue(item.Cells[ii].Value);
            //            if (itemTrueVal.Trim().Length == 0)
            //            {
            //                ak46[ii] = "X-X-FUCK-JAPAN";
            //            }
            //            else
            //            {
            //                ak46[ii] = itemTrueVal;
            //            }

            //        }

            //        for (int i = 0; i < control.Cols.Count; i++)
            //        {
            //            var timePoint = startTime.AddMinutes(((int)item.ShowTimeInterval) * i);
            //            if (timePoint <= dtOpertionEnd)
            //            {
            //                item.Cells[i].Value = GetStringValue(ak46[i]);
            //                if (i != 0)
            //                {
            //                    if (GetStringValue(item.Cells[i].Value).Trim() == "X-X-FUCK-JAPAN")
            //                    {
            //                        string strItemqECG = GetStringValue(item.Cells[i - 1].Value).Trim();
            //                        item.Cells[i].Value = strItemqECG;
            //                    }
            //                }
            //                else
            //                {
            //                    if (GetStringValue(item.Cells[i].Value).Trim() == "X-X-FUCK-JAPAN")
            //                    {
            //                        item.Cells[i].Value = "";
            //                    }
            //                }

            //            }
            //        }
            //    }
            //    #endregion

            //    #region　EtCO2 特殊处理，持续显示，至手术结束时间
            //    if (item.Title == "EtCO2")
            //    {
            //        //{获取原有ECG初始值,并取在数组中}
            //        string[] ak46 = new string[control.Cols.Count];
            //        for (int ii = 0; ii < control.Cols.Count; ii++)
            //        {
            //            string itemTrueVal = GetStringValue(item.Cells[ii].Value);
            //            if (itemTrueVal.Trim().Length == 0)
            //            {
            //                ak46[ii] = "X-X-FUCK-JAPAN2";
            //            }
            //            else
            //            {
            //                ak46[ii] = itemTrueVal;
            //            }

            //        }

            //        for (int i = 0; i < control.Cols.Count; i++)
            //        {
            //            var timePoint = startTime.AddMinutes(((int)item.ShowTimeInterval) * i);
            //            if (timePoint <= dtOpertionEnd)
            //            {
            //                item.Cells[i].Value = GetStringValue(ak46[i]);
            //                if (i != 0)
            //                {
            //                    if (GetStringValue(item.Cells[i].Value).Trim() == "X-X-FUCK-JAPAN2")
            //                    {
            //                        string strItemqEtCO2 = GetStringValue(item.Cells[i - 1].Value).Trim();
            //                        item.Cells[i].Value = strItemqEtCO2;
            //                    }
            //                }
            //                else
            //                {
            //                    if (GetStringValue(item.Cells[i].Value).Trim() == "X-X-FUCK-JAPAN2")
            //                    {
            //                        item.Cells[i].Value = "";
            //                    }
            //                }

            //            }
            //        }
            //    }
            //    #endregion

            //    #region　TVE 特殊处理，持续显示，至手术结束时间
            //    if (item.Title.ToUpper() == "TVE")
            //    {

            //        //{获取原有ECG初始值,并取在数组中}
            //        string[] akTVE = new string[control.Cols.Count];
            //        for (int ii = 0; ii < control.Cols.Count; ii++)
            //        {
            //            string itemTrueVal = GetStringValue(item.Cells[ii].Value);
            //            if (itemTrueVal.Trim().Length == 0)
            //            {
            //                akTVE[ii] = "X-X-FUCK-KOREA";
            //            }
            //            else
            //            {
            //                akTVE[ii] = itemTrueVal;
            //            }
            //        }


            //        #region 如果是翻页，则第一个值获取前一个值
            //        try
            //        {
            //            if (PagerSetting.PageTimeSpan.StartDateTime > operationMasterDataTable[0].IN_DATE_TIME && PagerSetting.PageTimeSpan.StartDateTime <= dtOpertionEnd)
            //            {
            //                DataRow[] ckckckckck = dtMonitorEx.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT<='" + PagerSetting.PageTimeSpan.StartDateTime + "'", "TIME_POINT ASC");
            //                int iaklent = ckckckckck.Length;
            //                DataRow ckLastrow = ckckckckck[iaklent - 1];
            //                akTVE.SetValue(GetStringValue(ckLastrow["item_value"]), 0);
            //            }
            //        }
            //        catch { }
            //        #endregion

            //        for (int i = 0; i < control.Cols.Count; i++)
            //        {
            //            var timePoint = startTime.AddMinutes(((int)item.ShowTimeInterval) * i);
            //            if (timePoint <= dtOpertionEnd)
            //            {
            //                item.Cells[i].Value = GetStringValue(akTVE[i]);
            //                if (i != 0)
            //                {
            //                    if (GetStringValue(item.Cells[i].Value).Trim() == "X-X-FUCK-KOREA")
            //                    {
            //                        string strItemqECG = GetStringValue(item.Cells[i - 1].Value).Trim();
            //                        item.Cells[i].Value = strItemqECG;
            //                    }
            //                }
            //                else
            //                {
            //                    if (GetStringValue(item.Cells[i].Value).Trim() == "X-X-FUCK-KOREA")
            //                    {
            //                        item.Cells[i].Value = "";
            //                    }
            //                }

            //            }
            //        }

            //    }
            //    #endregion

            //    #region　IE 特殊处理，持续显示，至手术结束时间
            //    if (item.Title.ToUpper() == "I:E")
            //    {
            //        //{获取原有ECG初始值,并取在数组中}
            //        string[] akIE = new string[control.Cols.Count];
            //        for (int ii = 0; ii < control.Cols.Count; ii++)
            //        {
            //            string itemTrueVal = GetStringValue(item.Cells[ii].Value);
            //            if (itemTrueVal.Trim().Length == 0)
            //            {
            //                akIE[ii] = "X-X-FUCK-Vietnam";
            //            }
            //            else
            //            {
            //                akIE[ii] = itemTrueVal;
            //            }

            //        }

            //        #region 如果是翻页，则第一个值获取前一个值
            //        try
            //        {
            //            if (PagerSetting.PageTimeSpan.StartDateTime > operationMasterDataTable[0].IN_DATE_TIME && PagerSetting.PageTimeSpan.StartDateTime <= dtOpertionEnd)
            //            {
            //                DataRow[] ckckckckck = dtMonitorEx.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT<='" + PagerSetting.PageTimeSpan.StartDateTime + "'", "TIME_POINT ASC");
            //                int iaklent = ckckckckck.Length;
            //                DataRow ckLastrow = ckckckckck[iaklent - 1];
            //                akIE.SetValue(GetStringValue(ckLastrow["item_value"]), 0);
            //            }
            //        }
            //        catch { }
            //        #endregion

            //        for (int i = 0; i < control.Cols.Count; i++)
            //        {
            //            var timePoint = startTime.AddMinutes(((int)item.ShowTimeInterval) * i);
            //            if (timePoint <= dtOpertionEnd)
            //            {
            //                item.Cells[i].Value = GetStringValue(akIE[i]);
            //                if (i != 0)
            //                {
            //                    if (GetStringValue(item.Cells[i].Value).Trim() == "X-X-FUCK-Vietnam")
            //                    {
            //                        string strItemqECG = GetStringValue(item.Cells[i - 1].Value).Trim();
            //                        item.Cells[i].Value = strItemqECG;
            //                    }
            //                }
            //                else
            //                {
            //                    if (GetStringValue(item.Cells[i].Value).Trim() == "X-X-FUCK-Vietnam")
            //                    {
            //                        item.Cells[i].Value = "";
            //                    }
            //                }

            //            }
            //        }

            //    }
            //    #endregion

            //    #region　f 特殊处理，持续显示，至手术结束时间
            //    if (item.Title.ToUpper() == "F")
            //    {
            //        //{获取原有ECG初始值,并取在数组中}
            //        string[] akf = new string[control.Cols.Count];
            //        for (int ii = 0; ii < control.Cols.Count; ii++)
            //        {
            //            string itemTrueVal = GetStringValue(item.Cells[ii].Value);
            //            if (itemTrueVal.Trim().Length == 0)
            //            {
            //                akf[ii] = "X-X-FUCK-India";
            //            }
            //            else
            //            {
            //                akf[ii] = itemTrueVal;
            //            }

            //        }

            //        #region 如果是翻页，则第一个值获取前一个值
            //        try
            //        {
            //            if (PagerSetting.PageTimeSpan.StartDateTime > operationMasterDataTable[0].IN_DATE_TIME && PagerSetting.PageTimeSpan.StartDateTime <= dtOpertionEnd)
            //            {
            //                DataRow[] ckckckckck = dtMonitorEx.Select("ITEM_CODE = '" + item.ItemCode + "' and TIME_POINT<='" + PagerSetting.PageTimeSpan.StartDateTime + "'", "TIME_POINT ASC");
            //                int iaklent = ckckckckck.Length;
            //                DataRow ckLastrow = ckckckckck[iaklent - 1];
            //                akf.SetValue(GetStringValue(ckLastrow["item_value"]), 0);
            //            }
            //        }
            //        catch { }
            //        #endregion

            //        for (int i = 0; i < control.Cols.Count; i++)
            //        {
            //            var timePoint = startTime.AddMinutes(((int)item.ShowTimeInterval) * i);
            //            if (timePoint <= dtOpertionEnd)
            //            {
            //                item.Cells[i].Value = GetStringValue(akf[i]);
            //                if (i != 0)
            //                {
            //                    if (GetStringValue(item.Cells[i].Value).Trim() == "X-X-FUCK-India")
            //                    {
            //                        string strItemqECG = GetStringValue(item.Cells[i - 1].Value).Trim();
            //                        item.Cells[i].Value = strItemqECG;
            //                    }
            //                }
            //                else
            //                {
            //                    if (GetStringValue(item.Cells[i].Value).Trim() == "X-X-FUCK-India")
            //                    {
            //                        item.Cells[i].Value = "";
            //                    }
            //                }

            //            }
            //        }


            //    }
            //    #endregion

            //}
            #endregion

        }
        public override void BindUIToData(MedSheet control, Dictionary<string, System.Data.DataTable> dataSources)
        {

        }

        public override void ControlSetting(MedSheet control)
        {
            _textBox.Font = control.Font;

            //2013-12-11 周青 监测项目个性化设置
            if (AccessControl.CheckModifyRightForOperator("麻醉记录单") || ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
            {
                control.MouseDoubleClick -= new MouseEventHandler(MedSheet_DoubleClick);
                control.MouseDoubleClick += new MouseEventHandler(MedSheet_DoubleClick);
            }

            control.Click -= new EventHandler(MedSheet_Click);
            control.Click += new EventHandler(MedSheet_Click);
        }

        //2013-12-11 周青 监测项目个性化设置
        private void MedSheetShowSet()
        {
            List<MedSheetDetail> list = GetUserMedSheetShowSet(_eventNo);
            Dictionary<string, MedSheetDetail> dict = new Dictionary<string, MedSheetDetail>();
            AnesInformations.VitalSignDataTable _VitalSignData = base.DataSource["VitalSignData"] as AnesInformations.VitalSignDataTable;
            foreach (MedSheetDetail vitalSet in list)
            {
                if (!string.IsNullOrEmpty(vitalSet.CurveCode) && !dict.ContainsKey(vitalSet.CurveCode))
                {
                    dict.Add(vitalSet.CurveCode, vitalSet);
                }
                else if (string.IsNullOrEmpty(vitalSet.CurveCode) && !string.IsNullOrEmpty(vitalSet.CurveName))
                {
                    foreach (AnesInformations.VitalSignRow vrow in _VitalSignData.Rows)
                    {
                        if (vrow.ITEM_NAME.Equals(vitalSet.CurveName) && !dict.ContainsKey(vrow.ITEM_CODE))
                        {
                            dict.Add(vrow.ITEM_CODE, vitalSet);
                            break;
                        }
                    }
                }
            }
            MedSheet _vitalGraph = null;
            foreach (IUIElementHandler handler in MedicalPaperUIElementHandlers)
            {
                if (handler.GetControlType == typeof(MedSheet) && handler.GetCurrentControl != null)
                    _vitalGraph = handler.GetCurrentControl as MedSheet;
            }
            if (_vitalGraph != null)
            {
                foreach (MedSheetRow curve in _vitalGraph.Rows)
                {
                    if (!string.IsNullOrEmpty(curve.ItemCode) && !dict.ContainsKey(curve.ItemCode))
                    {
                        MedSheetDetail vitalSet = new MedSheetDetail();
                        vitalSet.CurveName = curve.Title;
                        vitalSet.CurveCode = string.IsNullOrEmpty(curve.ItemCode) ? curve.Title : curve.ItemCode;
                        vitalSet.Color = curve.Color;

                        if (!dict.ContainsKey(vitalSet.CurveCode))
                        {
                            dict.Add(vitalSet.CurveCode, vitalSet);
                            list.Add(vitalSet);
                        }
                    }
                }
            }
            XtraForm form = new XtraForm();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Width = 1000;
            form.Height = 600;
            MedSheetShowEditor medSheetShowEditor = new MedSheetShowEditor(list);
            medSheetShowEditor.Dock = DockStyle.Fill;
            form.Controls.Add(medSheetShowEditor);
            form.Text = "个性化监测显示设置";

            object result = form.ShowDialog();
            if (result != null && (DialogResult)result == DialogResult.OK)
            {
                string tableName = "UserMedSheetShowSet" + ((_eventNo < 0) ? 0 : _eventNo).ToString();
                DataTable dataTable = new DataTable(tableName);//复苏单可约定数据表名称为UserVitalShowSet1,末尾与EventNo关联
                System.Reflection.PropertyInfo[] propertyInfos = typeof(MedSheetDetail).GetProperties();
                foreach (System.Reflection.PropertyInfo propertyInfo in propertyInfos)
                {
                    dataTable.Columns.Add(propertyInfo.Name);
                }
                foreach (MedSheetDetail obj in list)
                {
                    DataRow row = dataTable.NewRow();
                    foreach (System.Reflection.PropertyInfo propertyInfo in propertyInfos)
                    {
                        row[propertyInfo.Name] = AssemblyHelper.GetPropertyValue(propertyInfo, obj);
                    }
                    dataTable.Rows.Add(row);
                }


                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                dataTable.WriteXml(stream);
                stream.Position = 0;
                byte[] bytes = FileHelper.StreamToBytes(stream);

                ConfigurationDA configurationDA = new ConfigurationDA();
                Configuration.PatientMonitorConfigDataTable configTable = configurationDA.GetPatientJianCeConfigDataTable(
                    ExtendApplicationContext.Current.PatientContext.PatientID,
                    ExtendApplicationContext.Current.PatientContext.VisitID,
                    ExtendApplicationContext.Current.PatientContext.OperID);

                if (configTable == null || configTable.Count == 0)
                {
                    configTable = new Configuration.PatientMonitorConfigDataTable();
                    Configuration.PatientMonitorConfigRow newRow = configTable.NewPatientMonitorConfigRow();
                    newRow.PATIENT_ID = ExtendApplicationContext.Current.PatientContext.PatientID;
                    newRow.VISIT_ID = ExtendApplicationContext.Current.PatientContext.VisitID;
                    newRow.OPER_ID = ExtendApplicationContext.Current.PatientContext.OperID;
                    configTable.AddPatientMonitorConfigRow(newRow);
                }
                configTable[0].CONTENT = bytes;
                if (configurationDA.UpdatePatientJianCeConfigDataTable(configTable) > 0)
                {
                    RefreshData();
                    _vitalGraph.Invalidate();

                }
                stream.Close();
                stream.Dispose();
            }
        }

        //2013-12-11 周青 监测项目个性化设置
        private void MedSheet_DoubleClick(object sender, MouseEventArgs e)
        {
            MedSheetShowSet();
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
                Dialog.ShowCustomSelection(rows, displayName, _textBox,
                   new System.Drawing.Size(_textBox.Width, 300), new EventHandler(delegate(object sender1, EventArgs e1)
                   {
                       if (sender1 is int)
                       {
                           int result = (int)sender1;
                           if (result > -1)
                           {
                               _textBox.Text = rows[result][row.DisplayFieldName].ToString();
                               _textBox.Tag = cell;
                               TextBox_LostFocus(null, null);
                           }
                       }
                   }));
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
                    ExceptionHandler.Handle(err);
                }
            }

            _textBox.Tag = null;
        }
        protected void SaveEditData(MedSheetCell cell, MedSheetRow sheetRow)
        {
            DataTable dtMonitorEx = base.DataSource["MED_PAT_MONITOR_DATA_EXT"];
            dtMonitorEx.TableName = "MED_PAT_MONITOR_DATA_EXT";

            AnesInformations.AnesthesiaEventDataTable anesEventTable = DataContext.GetCurrent().GetAnesthesiaEvent(_eventNo);
            //base.DataSource["AnesthesiaEvent"] as AnesInformations.AnesthesiaEventDataTable;

            if (sheetRow.ItemCode == "D")  // 出量 -尿量
            {
                string itemname = "尿量";
                DataRow[] rows = anesEventTable.Select("ITEM_NAME = '" + itemname + "' and START_TIME='" + cell.TimePoint + "'", "START_TIME");
                if (rows.Length == 0 && !string.IsNullOrEmpty(_textBox.Text))
                {
                    AnesInformations.AnesthesiaEventRow eventRow = DataContext.GetCurrent().NewAnesthesiaEventRow(anesEventTable, 0);
                    eventRow.ITEM_CLASS = "D";
                    eventRow.ITEM_NAME = itemname;
                    eventRow.DOSAGE_UNITS = "ml";
                    eventRow.START_TIME = cell.TimePoint;
                    eventRow.DOSAGE = Convert.ToDecimal(_textBox.Text);
                    anesEventTable.Rows.Add(eventRow);
                    DataContext.GetCurrent().UpdateAnesthesiaEvent(anesEventTable);


                }
                else if (rows.Length > 0)
                {
                    if (string.IsNullOrEmpty(_textBox.Text))
                        rows[0].Delete();
                    else
                        rows[0]["DOSAGE"] = Convert.ToDecimal(_textBox.Text);

                    DataContext.GetCurrent().UpdateAnesthesiaEvent(anesEventTable);
                }
            }
            else
            {
                double min = 0;
                switch (sheetRow.ShowTimeInterval)
                {
                    case MedShowTimeInterval.Fifiteen:
                        min = 15;
                        break;
                    case MedShowTimeInterval.Five:
                        min = 5;
                        break;
                    case MedShowTimeInterval.HalfHour:
                        min = 15;
                        break;
                    case MedShowTimeInterval.Hour:
                        min = 60;
                        break;
                    case MedShowTimeInterval.Ten:
                        min = 10;
                        break;
                    case MedShowTimeInterval.Twenty:
                        min = 20;
                        break;
                }
                DateTime dt = cell.TimePoint.AddMinutes(min);
                DataRow[] rows = dtMonitorEx.Select("ITEM_CODE = '" + sheetRow.ItemCode + "' and TIME_POINT >='" + cell.TimePoint + "' and TIME_POINT < '" + dt + "'", "TIME_POINT ASC");
                #region 特殊处理，是从个性化表中数字类型的数据
                if (rows.Length == 0)
                {
                    rows = dtMonitorEx.Select("ITEM_NAME = '" + sheetRow.Title + "' and TIME_POINT >='" + cell.TimePoint + "' and TIME_POINT < '" + dt + "'", "TIME_POINT ASC");
                }
                #endregion
                if (rows.Length == 0 && !string.IsNullOrEmpty(_textBox.Text))
                {
                    string patientId = ExtendApplicationContext.Current.PatientContext.PatientID;
                    decimal visitId = ExtendApplicationContext.Current.PatientContext.VisitID;
                    decimal operId = ExtendApplicationContext.Current.PatientContext.OperID;

                    DataRow row = dtMonitorEx.NewRow();
                    row["PATIENT_ID"] = patientId;
                    row["VISIT_ID"] = visitId;
                    row["OPER_ID"] = operId;
                    row["TIME_POINT"] = cell.TimePoint;
                    row["ITEM_CODE"] = sheetRow.ItemCode;
                    row["ITEM_VALUE"] = _textBox.Text;
                    row["RECORDING_DATE"] = System.DateTime.Now;
                    dtMonitorEx.Rows.Add(row);

                    new CommonDA().UpdateDataTable(dtMonitorEx);
                }
                else if (rows.Length > 0)
                {
                    if (string.IsNullOrEmpty(_textBox.Text))
                        rows[0].Delete();
                    else
                    {
                        //MessageBox.Show(string.Format("{0}~{1},{2} Text is {3}",cell.TimePoint, dt, sheetRow.ItemCode, _textBox.Text));
                        for (int i = 0; i < rows.Length; i++)
                        {
                            if (i == 0)  //周青
                            {
                                rows[i]["ITEM_VALUE"] = _textBox.Text;
                                rows[i]["RECORDING_DATE"] = System.DateTime.Now;
                            }
                        }
                    }

                    int result = new CommonDA().UpdateDataTable(dtMonitorEx);
                    //MessageBox.Show("result is " + result.ToString());
                }
            }

        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox_LostFocus(sender, e);
            }
        }
        /// <summary>
        /// 从曲线明细设置集合读取曲线明细
        /// </summary>
        /// <param name="vitalSignGraph"></param>
        /// <param name="itemName"></param>
        /// <returns></returns>
        private MedVitalSignCurveDetail GetVitalSignDetail(MedVitalSignGraph vitalSignGraph, string itemCode)
        {
            foreach (MedVitalSignCurveDetail detail in vitalSignGraph.CurveDetails)
            {
                if (!string.IsNullOrEmpty(detail.CurveCode))
                {
                    if (detail.CurveCode.ToLower().Trim().Equals(itemCode.ToLower().Trim()))
                    {
                        return detail;
                    }
                }
                else
                {
                    if (detail.CurveName.ToLower().Trim().Equals(itemCode.ToLower().Trim()))//兼容以前曲线以Name为唯一标示
                    {
                        return detail;
                    }
                }
            }
            return null;
        }

    }
}