// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      GridGraphHandler.cs
// 功能描述(Description)：    麻醉单输液栏对应的Handler
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.CustomProject
{
    public class GridGraphHandler : UIElementHandler<MedGridGraph>
    {
        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        AnesEventRepository anesEventRepository = new AnesEventRepository();

        public AnesDoc _anesDoc = null;
        protected MedGridPoint Selectpt = null;
        protected MedGridGraph _currentGraph = null;
        protected Dictionary<MedGridPoint, MED_ANESTHESIA_EVENT> _gridRows = new Dictionary<MedGridPoint, MED_ANESTHESIA_EVENT>();
        protected DateTime _currentTime = DateTime.MinValue;
        public Dictionary<int, Dictionary<MedGridGraphRow, double>> dosageList = new Dictionary<int, Dictionary<MedGridGraphRow, double>>();

        /// <summary>
        /// 绑定数据源数据到控件
        /// </summary>
        public override void BindDataToUI(MedGridGraph control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            if (!dataSources.ContainsKey("AnesthesiaEvent"))
            {
                throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表AnesInformations.AnesthesiaEventDataTable,请添加此绑定数据源!", "AnesthesiaEvent"));
            }

            MedGridGraphRow row;
            Dictionary<string, GridRowAliasName> aNames = new Dictionary<string, GridRowAliasName>();
            List<MED_ANESTHESIA_EVENT> anesEvent = ModelHelper<MED_ANESTHESIA_EVENT>.ConvertDataTableToList(dataSources["AnesthesiaEvent"]);
            control.Rows.Clear();
            _gridRows.Clear();
            control.StartTime = PagerSetting.PageTimeSpan.StartDateTime;
            control.EndTime = PagerSetting.PageTimeSpan.EndDateTime;
            control.MinStartDateTime = PagerSetting.PageTimeSpan.OrigiStartDateTime;
            control.MaxEndDateTime = PagerSetting.PageTimeSpan.OrigiEndDateTime;
            // 行参数设置
            if (control.RowSettings != null)
            {
                foreach (GridRowAliasName aname in control.RowSettings)
                {
                    if (aname.AlwaysNeeded && !aNames.ContainsKey(aname.Alias))
                    {
                        aNames.Add(aname.Alias, aname);
                        row = new MedGridGraphRow(aname.Alias, Color.Black);
                        row.IsAverage = true;
                        row.DotNumber = aname.DotNumber;
                        control.Rows.Add(row);
                    }
                }
            }

            int indext = 0;
            if (anesEvent != null && anesEvent.Count > 0)
            {
                foreach (MED_ANESTHESIA_EVENT anes in anesEvent)
                {
                    indext++;
                    if (string.IsNullOrEmpty(anes.EVENT_ITEM_NAME))
                    {
                        continue;
                    }

                    bool find = false;
                    string rowName = anes.EVENT_ITEM_NAME;
                    if (control.RowSettings != null)
                    {
                        foreach (GridRowAliasName aname in control.RowSettings)
                        {
                            if (aname.Name.ToLower().Trim().Equals(rowName.ToLower().Trim()))
                            {
                                find = true;
                                rowName = aname.Alias;
                                break;
                            }
                        }
                    }

                    if (find)
                    {
                        row = control.GetRow(rowName);
                        double value = (double)anes.DOSAGE;
                        row.AddPoint(anes.START_TIME.Value, indext, rowName, value);
                    }
                }
            }

            // 显示其他事件信息，暂时注释，请勿删除
            //if (control.HasDrug)
            //{
            //    AddGraphRow(control, anesEvent, new AnesClassType[] { AnesClassType.Drug }, "用药", Color.Black);
            //}
            //if (control.HasLiquid)
            //{
            //    AddGraphRow(control, anesEvent, new AnesClassType[] { AnesClassType.InLiquid }, "", Color.Black);
            //}
            //while (control.Rows.Count < control.MinRowCount)
            //{
            //    control.Rows.Add(new MedGridGraphRow("", Color.Black));
            //}
            //while (control.Rows.Count > control.MinRowCount)
            //{
            //    control.Rows.RemoveAt(control.Rows.Count - 1);
            //}
            //AddGraphRow(control, anesEvent, new AnesClassType[] { AnesClassType.InBlood }, "输血液制品", Color.Black);
            //if (control.Rows.Count > control.MinRowCount)
            //{
            //    control.Rows.RemoveAt(control.Rows.Count - 2);
            //}


            //joysola 测试用
            //ApplicationConfiguration.PassedInLiquidInBloodFormat = "Liquid6Blood3";//"Liquid6Blood3","BloodInOne","Mix"
            //modified by joysola on 2018-3-6 修改输血输液显示，通过前台的字符串进行判断
            switch (ApplicationConfiguration.PassedInLiquidInBloodFormat)
            {
                case "Mix":
                    // 显示输液
                    if (control.HasLiquid)
                    {
                        this.AddGraphRow(control, anesEvent, new AnesClassType[] { AnesClassType.InLiquid }, "", Color.Black);
                    }
                    // 显示输血
                    this.AddGraphRow(control, anesEvent, new AnesClassType[] { AnesClassType.InBlood }, "", Color.Black);
                    // 排序，方便后续增删操作
                    control.Sort();

                    // 行数不够用空行补充
                    while (control.Rows.Count < control.MinRowCount)
                    {
                        control.Rows.Add(new MedGridGraphRow("", Color.Black));
                    }

                    // 行数太多删除最后行
                    while (control.Rows.Count > control.MinRowCount)
                    {
                        control.Rows.RemoveAt(control.Rows.Count - 1);
                    }
                    break;
                case "BloodInThree":
                    // 显示输液
                    if (control.HasLiquid)
                    {
                        this.AddGraphRow(control, anesEvent, new AnesClassType[] { AnesClassType.InLiquid }, "", Color.Black);
                        control.Sort();

                        while (control.Rows.Count < control.MinRowCount - 3)//-3 为输血留三行
                            control.Rows.Add(new MedGridGraphRow("", Color.Black));
                        while (control.Rows.Count > control.MinRowCount - 3)//-3 为输血留三行
                            control.Rows.RemoveAt(control.Rows.Count - 1);

                    }
                    // 显示输血
                    this.AddGraphRow(control, anesEvent, new AnesClassType[] { AnesClassType.InBlood }, "", Color.Black);
                    // 排序，方便后续增删操作
                    //control.Sort();
                    while (control.Rows.Count < control.MinRowCount)//默认9
                        control.Rows.Add(new MedGridGraphRow("", Color.Black));
                    while (control.Rows.Count > control.MinRowCount)//默认9
                        control.Rows.RemoveAt(control.Rows.Count - 1);


                    // 行数不够用空行补充
                    while (control.Rows.Count < control.MinRowCount)
                    {
                        control.Rows.Add(new MedGridGraphRow("", Color.Black));
                    }

                    // 行数太多删除最后行
                    while (control.Rows.Count > control.MinRowCount)
                    {
                        control.Rows.RemoveAt(control.Rows.Count - 1);
                    }
                    break;
                case "BloodInOne":
                    if (control.HasLiquid)
                    {
                        this.AddGraphRow(control, anesEvent, new AnesClassType[] { AnesClassType.InLiquid }, "", Color.Black);
                        while (control.Rows.Count < control.MinRowCount - 1)//-3空三行，-1不留行
                            control.Rows.Add(new MedGridGraphRow("", Color.Black));
                        while (control.Rows.Count > control.MinRowCount - 1)//-3空三行
                            control.Rows.RemoveAt(control.Rows.Count - 1);
                    }
                    // 显示输血
                    while (control.Rows.Count < control.MinRowCount - 1)//默认9
                        control.Rows.Add(new MedGridGraphRow("", Color.Black));
                    while (control.Rows.Count > control.MinRowCount - 1)//默认9
                        control.Rows.RemoveAt(control.Rows.Count - 1);
                    this.AddGraphRow(control, anesEvent, new AnesClassType[] { AnesClassType.InBlood }, "输血制品", Color.Black);
                    if (control.Rows.Count > control.MinRowCount)//第7行
                    {
                        control.Rows.RemoveAt(control.Rows.Count - 1);
                    }
                    // 排序，方便后续增删操作
                    //control.Sort();


                    break;
            }



            //// 显示输液
            //if (control.HasLiquid)
            //{
            //    this.AddGraphRow(control, anesEvent, new AnesClassType[] { AnesClassType.InLiquid }, "", Color.Black);
            //}

            //// 显示输血
            //this.AddGraphRow(control, anesEvent, new AnesClassType[] { AnesClassType.InBlood }, "", Color.Black);
            //// 排序，方便后续增删操作
            //control.Sort();

            //// 行数不够用空行补充
            //while (control.Rows.Count < control.MinRowCount)
            //{
            //    control.Rows.Add(new MedGridGraphRow("", Color.Black));
            //}

            //// 行数太多删除最后行
            //while (control.Rows.Count > control.MinRowCount)
            //{
            //    control.Rows.RemoveAt(control.Rows.Count - 1);
            //}


            //modified end


            // 显示出液出量信息
            this.AddGraphRow(control, anesEvent, new AnesClassType[] { AnesClassType.OutLiquid }, "", Color.Black);
            // 行数不够用空行补充
            while (control.Rows.Count < control.MaxRowCount)
            {
                control.Rows.Add(new MedGridGraphRow("", Color.Black));
            }

            // 行数太多删除最后行
            while (control.Rows.Count > control.MaxRowCount)
            {
                control.Rows.RemoveAt(control.Rows.Count - 1);
            }

            List<MedGridGraphRow> rows = new List<MedGridGraphRow>();
            foreach (MedGridGraphRow row1 in control.Rows)
            {
                if (!aNames.ContainsKey(row1.Text))
                {
                    rows.Add(row1);
                }
            }

            foreach (MedGridGraphRow row1 in control.Rows)
            {
                if (aNames.ContainsKey(row1.Text))
                {
                    rows.Add(row1);
                }
            }

            control.Rows = rows;
        }

        /// <summary>
        /// 绑定控件内容到数据源
        /// </summary>
        public override void BindUIToData(MedGridGraph control, Dictionary<string, System.Data.DataTable> dataSources)
        {
        }

        /// <summary>
        /// 重写方法：设置控件的属性和事件
        /// </summary>
        public override void ControlSetting(MedGridGraph control)
        {
            control.OriginWidth = control.Width;
            control.OriginHeight = control.Height;
            control.CustomDraw -= new System.Windows.Forms.PaintEventHandler(MedGridGraph_CustomDraw);
            control.CustomDraw += new System.Windows.Forms.PaintEventHandler(MedGridGraph_CustomDraw);
            _currentGraph = control;
            //control.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(MedGridGraph_MouseDoubleClick);
            //control.MouseDown += new MouseEventHandler(MedGridGraph_MouseDown);
            //control.MouseUp += new MouseEventHandler(MedGridGraph_MouseLeave);
            //control.MouseClick += new MouseEventHandler(MedGridGraph_MouseClick);
        }

        /// <summary>
        /// 自定义绘制事件，个性化操作，暂时注释，请勿删除
        /// </summary>
        private void MedGridGraph_CustomDraw(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            MedGridGraph gridgraph = sender as MedGridGraph;
            Graphics g = e.Graphics;
            //Font font = new Font("宋体", 12);
            //Brush brush = Brushes.Black;
            //g.FillRectangle(Brushes.White, new Rectangle(gridgraph.OriginRect.X + (int)gridgraph.TitleWidth, 1, 16, gridgraph.OriginRect.Height * 6 / 9 - 2));
            //g.DrawString("输", font, brush, gridgraph.OriginRect.X + (int)gridgraph.TitleWidth - 2, 30);
            //g.DrawString("液", font, brush, gridgraph.OriginRect.X + (int)gridgraph.TitleWidth - 2, 45);
            //g.DrawLine(new Pen(gridgraph.RowGridColor), gridgraph.OriginRect.X + 1 + (int)gridgraph.TitleWidth + 16, 1, gridgraph.OriginRect.X + 1 + (int)gridgraph.TitleWidth + 16, gridgraph.OriginRect.Height * 6 / 9 - 2);
            //g.DrawLine(new Pen(gridgraph.BorderColor), gridgraph.OriginRect.X + 1, gridgraph.OriginRect.Height * 6 / 9 - 1, gridgraph.OriginRect.X + (int)gridgraph.TitleWidth - 1, gridgraph.OriginRect.Height * 6 / 9 - 1);
            //g.FillRectangle(Brushes.White, new Rectangle(gridgraph.OriginRect.X + 1, gridgraph.OriginRect.Y - 1, gridgraph.OriginRect.X + (int)gridgraph.TitleWidth - 2, 2));
            //font.Dispose();
        }

        /// <summary>
        /// 根据标题从MedGridGraph中寻找MedGridGraphRow
        /// </summary>
        private MedGridGraphRow FindGridRow(MedGridGraph gridGraph, string rowTitle)
        {
            foreach (MedGridGraphRow row in gridGraph.Rows)
            {
                if (row.Text.Equals(rowTitle))
                {
                    return row;
                }
            }

            return null;
        }

        /// <summary>
        /// 添加新行到MedGridGraph
        /// </summary>
        /// <param name="gridGraph">MedGridGraph控件</param>
        /// <param name="anesEventTable">事件数据</param>
        /// <param name="anesClasses">事件类型：用药OR麻药OR输液OR输血......</param>
        /// <param name="rowTitle">行标题</param>
        /// <param name="rowColor">行颜色</param>
        private void AddGraphRow(MedGridGraph gridGraph,
                                 List<MED_ANESTHESIA_EVENT> anesEventTable,
                                 AnesClassType[] anesClasses,
                                 string rowTitle,
                                 Color rowColor)
        {
            var anesClassList = anesClasses.Select(clas => this.GetAnesClassTypeString(clas)).ToList();
            if (anesEventTable != null && anesEventTable.Count > 0)
            {
                anesEventTable = anesEventTable.Where(x => anesClassList.Contains(x.EVENT_CLASS_CODE))
                                               .OrderBy(x => x.START_TIME).ToList();
                if (anesEventTable != null && anesEventTable.Count > 0)
                {
                    MedGridGraphRow row = null;
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    List<MED_EVENT_DICT> eventDict = ExtendApplicationContext.Current.CommDict.EventDict;

                    if (!string.IsNullOrEmpty(rowTitle))//有行标题时
                    {
                        row = new MedGridGraphRow(rowTitle, rowColor);
                        row.IsDetail = gridGraph.IsLiquidDetail;
                        gridGraph.Rows.Add(row);
                    }

                    int index = 0;
                    DateTime sysDateTime = this.GetSysDateTime();
                    foreach (MED_ANESTHESIA_EVENT dataRow in anesEventTable)
                    {
                        index++;
                        if (dataRow.START_TIME.HasValue &&
                            !string.IsNullOrEmpty(dataRow.EVENT_ITEM_NAME) &&
                            !IsTimeEvent(dataRow.EVENT_ITEM_NAME))
                        {
                            string itemName = dataRow.EVENT_ITEM_NAME;
                            double value = 0;
                            if (dataRow.DOSAGE.HasValue)
                            {
                                value = GetDoubleValue(dataRow.DOSAGE);
                            }

                            if (dict.Count > 0)
                            {
                                if (string.IsNullOrEmpty(dataRow.EVENT_ATTR) || !dict.ContainsKey(dataRow.EVENT_ATTR))
                                {
                                    continue;
                                }

                                row = this.FindGridRow(gridGraph, dict[dataRow.EVENT_ATTR]);
                                if (null != row)
                                {
                                    MedGridPoint point = row.AddPoint(dataRow.START_TIME.Value, index, itemName, value);
                                    _gridRows.Add(point, dataRow);
                                }

                                continue;
                            }
                            else if (string.IsNullOrEmpty(rowTitle))
                            {
                                if (string.IsNullOrEmpty(itemName))
                                {
                                    continue;
                                }

                                row = this.FindGridRow(gridGraph, itemName);
                                if (row == null)
                                {
                                    row = new MedGridGraphRow(itemName, rowColor);
                                    // 判断是否是持续
                                    if (dataRow.END_TIME.HasValue || dataRow.DURATIVE_INDICATOR.HasValue && dataRow.DURATIVE_INDICATOR == 1)
                                    {
                                        row.IsLine = true;
                                    }
                                    else
                                    {
                                        row.IsLine = false;
                                    }

                                    gridGraph.Rows.Add(row);
                                }
                            }

                            bool find = false;
                            if ((anesClasses[0] == AnesClassType.InBlood || anesClasses[0] == AnesClassType.InLiquid) &&
                                eventDict != null && eventDict.Count > 0)
                            {
                                eventDict = eventDict.Where(x => x.EVENT_ITEM_NAME.Equals(itemName)).ToList();
                                foreach (MED_EVENT_DICT dictRow in eventDict)
                                {
                                    if (!string.IsNullOrEmpty(dictRow.EVENT_ATTR2))
                                    {
                                        MedGridPoint point = null;
                                        if (row.IsLine)
                                        {
                                            DateTime dt = DateTime.MinValue;
                                            bool isArrow = false;
                                            if (dataRow.END_TIME.HasValue)
                                            {
                                                dt = dataRow.END_TIME.Value;
                                            }
                                            else
                                            {
                                                dt = (sysDateTime < gridGraph.MaxEndDateTime) ? sysDateTime : gridGraph.MaxEndDateTime;
                                                isArrow = true;
                                            }

                                            point = row.AddPoint(dataRow.START_TIME.Value, dt, index, itemName, value, dictRow.EVENT_ATTR2);
                                            row.Points[row.Points.Count - 1].IsArrow = isArrow;
                                            row.Points[row.Points.Count - 1].Unit = string.IsNullOrEmpty(dataRow.DOSAGE_UNITS) ? "" : dataRow.DOSAGE_UNITS;//自动加单位
                                        }
                                        else
                                        {
                                            point = row.AddPoint(dataRow.START_TIME.Value, index, itemName, value, dictRow.EVENT_ATTR2);
                                            row.Points[row.Points.Count - 1].Unit = string.IsNullOrEmpty(dataRow.DOSAGE_UNITS) ? "" : dataRow.DOSAGE_UNITS;//自动加单位
                                        }

                                        point.Route = string.IsNullOrEmpty(dataRow.ADMINISTRATOR) ? "" : dataRow.ADMINISTRATOR;
                                        _gridRows.Add(point, dataRow);
                                        find = true;
                                    }
                                }
                            }

                            if (!find)
                            {
                                MedGridPoint point = null;
                                if (row.IsLine)
                                {
                                    DateTime dt = DateTime.MinValue;
                                    bool isArrow = false;
                                    if (dataRow.END_TIME.HasValue)
                                    {
                                        dt = dataRow.END_TIME.Value;
                                        isArrow = false;
                                    }
                                    else
                                    {
                                        dt = (sysDateTime < gridGraph.MaxEndDateTime) ? sysDateTime : gridGraph.MaxEndDateTime;
                                        isArrow = true;
                                    }

                                    point = row.AddPoint(dataRow.START_TIME.Value, dt, index, itemName, value, "");
                                    row.Points[row.Points.Count - 1].IsArrow = isArrow;
                                    row.Points[row.Points.Count - 1].Unit = string.IsNullOrEmpty(dataRow.DOSAGE_UNITS) ? "" : dataRow.DOSAGE_UNITS;//自动加单位
                                }
                                else
                                {
                                    point = row.AddPoint(dataRow.START_TIME.Value, index, itemName, value);
                                    row.Points[row.Points.Count - 1].Unit = string.IsNullOrEmpty(dataRow.DOSAGE_UNITS) ? "" : dataRow.DOSAGE_UNITS;//自动加单位
                                }

                                point.Route = string.IsNullOrEmpty(dataRow.ADMINISTRATOR) ? "" : dataRow.ADMINISTRATOR;
                                _gridRows.Add(point, dataRow);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 鼠标按下事件：响应右键
        /// </summary>
        protected void MedGridGraph_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                RectangleF rectf = _currentGraph.GetMainRect();
                if (!rectf.Contains(e.Location.X, e.Location.Y))
                {
                    return;
                }

                if (e.Button == MouseButtons.Right)
                {
                    _currentGraph.SetMousePosition(e.Location);
                    if (_currentGraph.MouseTime > DateTime.MinValue)
                    {
                        MedGridPoint pt = _currentGraph.SelectedPoint;
                        _currentTime = _currentGraph.MouseTime;
                        string eventNo = ExtendAppContext.Current.EventNo;
                        if (pt == null)
                        {
                            List<MED_EVENT_DICT> eventOpenTable = ExtendApplicationContext.Current.CommDict.EventDict;
                            List<MED_ANESTHESIA_EVENT> anesEvent = ModelHelper<MED_ANESTHESIA_EVENT>.ConvertDataTableToList(this.DataSource["AnesthesiaEvent"]);
                            int Line = (int)Math.Ceiling((double)e.Location.Y / _currentGraph.Height * _currentGraph.Rows.Count);
                            if (_currentGraph.Rows[Line - 1].Points.Count == 0 || Line == 7 || Line == 8 || Line == 9)
                            {
                                List<MED_EVENT_DICT> eventDict = null;
                                if (Line == 6)
                                {
                                    eventDict = eventOpenTable.Where(x => x.EVENT_CLASS_CODE == "B").ToList();
                                }
                                else if (Line == 7 || Line == 8 || Line == 9)
                                {
                                    eventDict = eventOpenTable.Where(x => x.EVENT_CLASS_CODE == "D").ToList();
                                }
                                else
                                {
                                    eventDict = eventOpenTable.Where(x => x.EVENT_CLASS_CODE == "3").ToList();
                                }

                                DataTable sourceTable = ModelHelper<MED_EVENT_DICT>.ConvertListToDataTable(eventDict);
                                DateTime tempDt = _currentTime != DateTime.MinValue ? _currentTime : DateTime.Now;
                                PopupDrugSelector.ShowSelector(sourceTable, _currentGraph, e.Location, tempDt, this, "输血及输液", eventNo);
                            }
                            else
                            {
                                if (_currentGraph.GetMainRect().X > e.Location.X)
                                {
                                    return;
                                }

                                List<MED_EVENT_DICT> eventDict = eventOpenTable.Where(x => x.EVENT_CLASS_CODE == _currentGraph.Rows[Line - 1].Text &&
                                                                                          (x.EVENT_CLASS_CODE == "B" ||
                                                                                           x.EVENT_CLASS_CODE == "D" ||
                                                                                           x.EVENT_CLASS_CODE == "3")).ToList();
                                if (eventDict.Count == 0)
                                {
                                    return;
                                }

                                MED_EVENT_DICT row = eventDict[0];
                                MED_ANESTHESIA_EVENT eventRow = DataContext.GetCurrent().NewAnesthesiaEventRow(anesEvent, eventNo);
                                eventRow.EVENT_CLASS_CODE = row.EVENT_CLASS_CODE;
                                eventRow.EVENT_ITEM_NAME = row.EVENT_ITEM_NAME;
                                eventRow.EVENT_ITEM_SPEC = row.EVENT_ITEM_SPEC;
                                eventRow.EVENT_ITEM_CODE = row.EVENT_ITEM_CODE;
                                eventRow.START_TIME = _currentTime;
                                if (!string.IsNullOrEmpty(row.EVENT_ATTR))
                                {
                                    eventRow.EVENT_ATTR = row.EVENT_ATTR;
                                }

                                MED_ANESTHESIA_EVENT firstrow = _gridRows[_currentGraph.Rows[Line - 1].Points[0]];
                                if (!string.IsNullOrEmpty(firstrow.ADMINISTRATOR))
                                {
                                    eventRow.ADMINISTRATOR = firstrow.ADMINISTRATOR;
                                }

                                if (!string.IsNullOrEmpty(_currentGraph.Rows[Line - 1].Points[0].ThickNessUnit))
                                {
                                    eventRow.CONCENTRATION_UNIT = _currentGraph.Rows[Line - 1].Points[0].ThickNessUnit;
                                }

                                if (!string.IsNullOrEmpty(_currentGraph.Rows[Line - 1].Points[0].Unit))
                                {
                                    eventRow.DOSAGE_UNITS = _currentGraph.Rows[Line - 1].Points[0].Unit;
                                }

                                if (!string.IsNullOrEmpty(_currentGraph.Rows[Line - 1].Points[0].SpeedUnit))
                                {
                                    eventRow.SPEED_UNIT = _currentGraph.Rows[Line - 1].Points[0].SpeedUnit;
                                }

                                if (!string.IsNullOrEmpty(row.SUPPLIER_NAME))
                                {
                                    eventRow.SUPPLIER_NAME = row.SUPPLIER_NAME;
                                }

                                if (!string.IsNullOrEmpty(_currentGraph.Rows[Line - 1].Points[0].ThickNess.ToString()))
                                {
                                    eventRow.CONCENTRATION = (decimal)_currentGraph.Rows[Line - 1].Points[0].ThickNess;
                                }

                                if (!string.IsNullOrEmpty(_currentGraph.Rows[Line - 1].Points[0].Value.ToString()))
                                {
                                    eventRow.DOSAGE = Convert.ToDecimal(_currentGraph.Rows[Line - 1].Points[0].Value);
                                }

                                if (!string.IsNullOrEmpty(_currentGraph.Rows[Line - 1].Points[0].Speed.ToString()))
                                {
                                    eventRow.PERFORM_SPEED = (decimal)_currentGraph.Rows[Line - 1].Points[0].Speed;
                                }

                                if (row.DURATIVE_INDICATOR.HasValue)
                                {
                                    eventRow.DURATIVE_INDICATOR = row.DURATIVE_INDICATOR;
                                }

                                EditEventItem editItem = new EditEventItem();
                                editItem.DataSource = eventRow;
                                editItem.ItemType = EditEventItem.ItemTypes.MedicineItem;
                                DialogHostForm dialogHostForm = new DialogHostForm(editItem.Caption, 320, 300);
                                dialogHostForm.Child = editItem;
                                dialogHostForm.Text = "新增输血及输液数据";
                                DialogResult result = dialogHostForm.ShowDialog();
                                if (result == DialogResult.OK)
                                {
                                    eventRow.ITEM_NO = DataContext.GetCurrent().GetMaxItemNO(anesEvent);
                                    anesEvent.Add(eventRow);
                                    operationInfoRepository.SaveAnesthesiaEventList(anesEvent);
                                    this.RefreshData();
                                    this._currentGraph.Refresh();
                                }
                            }
                        }
                        else
                        {
                            MED_ANESTHESIA_EVENT row = _gridRows[pt];
                            List<MED_ANESTHESIA_EVENT> anesEvent = ModelHelper<MED_ANESTHESIA_EVENT>.ConvertDataTableToList(this.DataSource["AnesthesiaEvent"]);
                            EditEventItem editItem = new EditEventItem();
                            editItem.DataSource = row;
                            editItem.ItemType = EditEventItem.ItemTypes.MedicineItem;
                            editItem.IsAllowDel = true;
                            editItem.TitleColor = Color.DarkOrange;
                            DialogHostFormPC dialogHostForm = new DialogHostFormPC("修改输血及输液数据", 320, 300);
                            dialogHostForm.Child = editItem;
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
                                        // OperationLogger.WriteOperate("文书液体模块", "右键删除", "右键液体模块弹出药品界面，勾选删除选择项，点确定进行删除保存，事件名称【" + row["ITEM_NAME"].ToString() + "】", false, OperationLogKind.Other);
                                        anesEventRepository.DelAnesEvent(row);
                                    }

                                }
                                operationInfoRepository.SaveAnesthesiaEventList(anesEvent);
                                RefreshData();
                                _currentGraph.Refresh();
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }
        }

        /// <summary>
        /// 鼠标双击事件：暂无逻辑操作
        /// </summary>
        protected void MedGridGraph_MouseDoubleClick(object sender, MouseEventArgs e)
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

        /// <summary>
        /// 鼠标按下事件，获取当前选中的节点
        /// </summary>
        private void MedGridGraph_MouseDown(object sender, MouseEventArgs e)
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
                }
            }
        }

        /// <summary>
        /// 鼠标Leave事件：响应当前时间设置成开始时间和结束时间
        /// </summary>
        private void MedGridGraph_MouseLeave(object sender, MouseEventArgs e)
        {
            RectangleF rectf = _currentGraph.GetMainRect();
            if (!rectf.Contains(e.Location.X, e.Location.Y))
            {
                return;
            }

            _currentGraph.SetMousePosition(e.Location);
            string eventNo = ExtendApplicationContext.Current.EventNo;
            if (Selectpt != null)
            {
                _currentTime = _currentGraph.MouseTime;
                MED_ANESTHESIA_EVENT eventRow = null;
                int Line = (int)Math.Ceiling((double)e.Location.Y / _currentGraph.Height * _currentGraph.Rows.Count);
                List<MED_ANESTHESIA_EVENT> anesEvent = ModelHelper<MED_ANESTHESIA_EVENT>.ConvertDataTableToList(this.DataSource["AnesthesiaEvent"]);
                foreach (MED_ANESTHESIA_EVENT row in anesEvent)
                {
                    if (row.EVENT_ITEM_NAME.Equals(_currentGraph.Rows[Line - 1].Text) && row.START_TIME.HasValue && row.START_TIME == Selectpt.Time)
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
        }
    }
}
