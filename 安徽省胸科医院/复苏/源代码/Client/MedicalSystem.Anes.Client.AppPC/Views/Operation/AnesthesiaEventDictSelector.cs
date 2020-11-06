using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Domain;
using Med.OpetationSchedule.Common;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.FrameWork.Enum;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.FrameWork.InputMethod;
using MedicalSystem.Anes.Client.AppPC.Properties;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    [ToolboxItem(true)]
    public partial class AnesthesiaEventDictSelector : BaseView
    {

        CommonRepository commonRepository = new CommonRepository();

        ComnDictRepository comnDictRepository = new ComnDictRepository();

        PatientInfoRepository patientInfoRepository = new PatientInfoRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        AccountRepository accountRepository = new AccountRepository();

        OperationScheduleRepository operationScheduleRepository = new OperationScheduleRepository();

        SyncInfoRepository syncInfoRepository = new SyncInfoRepository();


        public static string EventName = string.Empty;
        public AnesthesiaEventsEditor _anesthesiaEventsEditor = null;
        public AnesthesiaEventDictSelector(string eventName, AnesthesiaEventsEditor anesthesiaEventsEditor)
        {
            EventName = eventName;
            _anesthesiaEventsEditor = anesthesiaEventsEditor;
            dataSet = new DataSet();
            SetAnesClassTypes();
            InitializeComponent();
            if (ExtendApplicationContext.Current.SystemStatus == ProgramStatus.PACURecord)
            {
                eventNo = "1";
            }
            else if (ExtendApplicationContext.Current.SystemStatus == ProgramStatus.CPBReport)
            {
                eventNo = "2";
            }
            else if (ApplicationConfiguration.IsYouDaoProgram)
            {
                eventNo = "3";
            }
            string[] eventStr = ApplicationConfiguration.AnesEventButtons.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            cboEventType.Items.Clear();
            // cboEventType.Items.Add("选择事件分类");
            foreach (var str in eventStr)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    cboEventType.Items.Add(str);
                    if (str.Equals("麻药"))
                    {
                        cboEventType.SelectedIndex = 0;
                        EventName = str;
                    }

                }

            }
            AnesthesiaEventDictSelectorLoad();
        }
        private Dictionary<string, string> anesClassTypes = null;
        public static bool isFloat;
        public static Point floatLocation;
        private int pages = 0;
        private int page = 0;
        private DataSet dataSet;
        private List<MED_ANESTHESIA_EVENT> eventTable = null;
        /// <summary>
        /// 要传送的麻醉事件信息泛型集合
        /// </summary>
        private List<EventInfo> items = new List<EventInfo>();
        List<MED_EVENT_SORT> listEventSortList = new List<MED_EVENT_SORT>();
        // private List<SimpleButton> _pageIndexButtons = new List<SimpleButton>();
        private List<Label> _pageIndexButtons = new List<Label>();
        private EventInfo eventInfo = null;
        private string eventNo = "0";
        private static readonly object addEvent = new object();
        public event EventHandler AddEvent
        {
            add
            {
                Events.AddHandler(addEvent, value);
            }
            remove
            {
                Events.RemoveHandler(addEvent, value);
            }
        }
        private void SetEvent()
        {
            EventHandler eventHandle = Events[addEvent] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(eventTable, null);
            }
        }

        /// <summary>
        /// 初始化Key对应相应的值
        /// </summary>
        private void SetAnesClassTypes()
        {
            anesClassTypes = new Dictionary<string, string>();
            anesClassTypes.Add("事件", "1");
            anesClassTypes.Add("麻药", "2");
            anesClassTypes.Add("输液", "3");
            anesClassTypes.Add("出量", "D");
            anesClassTypes.Add("输氧", "4");
            anesClassTypes.Add("手术", "5");
            anesClassTypes.Add("麻醉", "6");
            anesClassTypes.Add("插管", "7");
            anesClassTypes.Add("拔管", "8");
            anesClassTypes.Add("辅助呼吸", "9");
            anesClassTypes.Add("控制呼吸", "A");
            anesClassTypes.Add("输血", "B");
            anesClassTypes.Add("用药", "C");
            anesClassTypes.Add("混合液", "X");
            anesClassTypes.Add("呼吸", "Y");
            anesClassTypes.Add("附记项目", "O");//ECG
            anesClassTypes.Add("镇痛泵", "W");
            anesClassTypes.Add("其他", "Z");
            anesClassTypes.Add("置管", "~");
        }

        private int _pageLines = 3;
        private int _rowButtons = 2;
        private bool _isEvent = false;
        private int _buttonWidth = 206;
        private int _pageButtonWidth = 30;
        private List<int> _dictIndexList = new List<int>();
        private void AnesthesiaEventDictSelectorLoad()
        {
            // this.Location = floatLocation;
            EventName = string.IsNullOrEmpty(EventName) ? "ALL" : EventName;
            ClearButton();
            if (anesClassTypes.ContainsKey(EventName) || AnesEventType.CPBEventType.ContainsKey(EventName) || EventName.Equals("ALL"))// 
            {
                if (ExtendApplicationContext.Current.SystemStatus == ProgramStatus.CPBReport)
                {
                    _isEvent = EventName.Equals("事件");
                }
                else if (EventName.Equals("ALL"))
                {
                    _isEvent = true;
                }
                else
                {
                    _isEvent = ("234BCX".IndexOf(anesClassTypes[EventName]) < 0);
                }
                // timeEvent.Value = DateTime.Now;
                listEventSortList = ExtendApplicationContext.Current.CommDict.EventSortDict;
                if (listEventSortList.Count == 0)
                {
                    listEventSortList = comnDictRepository.GetEventSortList("MDSD").Data;
                    ExtendApplicationContext.Current.CommDict.EventSortDict = listEventSortList;
                }
                if (!dataSet.Tables.Contains(EventName))
                {
                    string itemClass = "";
                    DataTable dataTable = null;
                    if (EventName.Equals("呼吸"))
                    {
                        dataTable = ModelHelper<MED_EVENT_DICT>.ConvertListToDataTable(new AnesEventRepository().GetAnesEventDictByhuxi().Data);
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            if (dataTable.Rows[i]["EVENT_ITEM_NAME"].ToString() == "辅助呼吸")
                            {
                                dataTable.Rows[i]["EVENT_CLASS_CODE"] = "9";
                            }
                            else if (dataTable.Rows[i]["EVENT_ITEM_NAME"].ToString() == "控制呼吸")
                            {
                                dataTable.Rows[i]["EVENT_CLASS_CODE"] = "A";
                            }
                            else if (dataTable.Rows[i]["EVENT_ITEM_NAME"].ToString() == "自主呼吸")
                            {
                                dataTable.Rows[i]["EVENT_CLASS_CODE"] = "Y";
                            }
                        }
                    }
                    else if (EventName.Equals("ALL"))
                    {
                        List<MED_EVENT_DICT> eventList = ExtendApplicationContext.Current.CommDict.EventDict.OrderByDescending(p => p.SORT_NO).ToList();
                        dataTable = ModelHelper<MED_EVENT_DICT>.ConvertListToDataTable(eventList);
                    }
                    else
                    {
                        itemClass = anesClassTypes[EventName];
                        List<MED_EVENT_DICT> eventList = ExtendApplicationContext.Current.CommDict.EventDict.Where(p => p.EVENT_CLASS_CODE == itemClass).ToList();
                        eventList = AILearnInputUtil.GetSortedList(eventList, ExtendApplicationContext.Current.CommDict.EventSortDict, itemClass);
                        dataTable = ModelHelper<MED_EVENT_DICT>.ConvertListToDataTable(eventList);
                    }
                    dataSet.Tables.Add(dataTable);
                    dataTable.TableName = EventName;
                }
                ReSetDictIndexList(searchTextBox.CurrentText);
                // 
                CalcPage();
                AddDosageButton(0);
                if (!EventName.Equals("ALL"))
                {

                    AddPageButton();
                }

                foreach (Control control in panelBody.Controls)
                {
                    if (control is Button && !control.Text.Equals("?"))
                    {
                        control.Visible = true;
                    }
                }
            }
        }
        private void ReSetDictIndexList(string var)
        {
            _dictIndexList.Clear();

            for (int i = 0; i < dataSet.Tables[EventName].Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(var))
                {
                    _dictIndexList.Add(i);
                }
                else
                {
                    string itemName = "";
                    if (dataSet.Tables[EventName].Rows[i]["EVENT_ITEM_NAME"] != System.DBNull.Value)
                    {
                        itemName = dataSet.Tables[EventName].Rows[i]["EVENT_ITEM_NAME"].ToString();
                        if (!string.IsNullOrEmpty(itemName))
                        {
                            itemName = StringManage.GetPYString(itemName);
                        }
                    }
                    if (itemName.ToLower().Contains(var.ToLower()))
                    {
                        _dictIndexList.Add(i);
                    }
                }
            }
        }

        /// <summary>
        /// 获取常用量按钮
        /// </summary>
        /// <param name="pageIndex">当前页索引</param>
        private void AddDosageButton(int pageIndex)
        {
            ClearButton();
            if (pages == 0) return;
            int t = 10;
            int count = 0;
            int left = 5;
            _dosageButtons.Clear();
            _dosageLabel.Clear();
            int roundIndex = 0;
            int startIndex = pageIndex * _pageLines * 2;
            if (_isEvent)
            {
                startIndex = pageIndex * _pageLines * _rowButtons;
            }
            Button simpleButton = null;
            for (int i = startIndex; i < _dictIndexList.Count; i++)
            {
                if (!_isEvent)
                {
                    int l = 5;
                    if (i % 3 != 0)
                    {
                        l = 5 + _buttonWidth * (i % 3) + 10 * (i % 3);
                    }
                    simpleButton = CreateButton(dataSet.Tables[EventName].Rows[_dictIndexList[i]]["EVENT_ITEM_NAME"].ToString());
                    if (!_dosageButtons.Contains(simpleButton))
                    {
                        _dosageButtons.Add(simpleButton);
                    }
                    simpleButton.Location = new Point(l, t);
                    simpleButton.Width = _buttonWidth;
                    simpleButton.Height = 30;
                    // simpleButton.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    simpleButton.Tag = i;
                    simpleButton.MouseDown += new MouseEventHandler(btnDosage_Click);
                    l = l + simpleButton.Width;
                    bool check = false;
                    double selectedDosage = SelectedDosage(dataSet.Tables[EventName].Rows[_dictIndexList[i]]["EVENT_ITEM_CODE"].ToString(), dataSet.Tables[EventName].Rows[_dictIndexList[i]]["EVENT_CLASS_CODE"].ToString());
                    string itemClass = dataSet.Tables[EventName].Rows[_dictIndexList[i]]["EVENT_CLASS_CODE"].ToString();
                    string itemCode = dataSet.Tables[EventName].Rows[_dictIndexList[i]]["EVENT_ITEM_CODE"].ToString();
                    List<MED_EVENT_DICT_EXT> eventExtList = ExtendApplicationContext.Current.CommDict.EventDictExt.
                        Where(x => x.EVENT_CLASS_CODE == itemClass && x.EVENT_ITEM_CODE == itemCode).ToList();
                    if (eventExtList != null && eventExtList.Count > 0)
                    {
                        foreach (MED_EVENT_DICT_EXT eventExt in eventExtList)
                        {
                            if (eventExt.STANDARD_DOSAGE.HasValue)
                            {
                                string text = Round(double.Parse(eventExt.STANDARD_DOSAGE.ToString()), 2).ToString();
                                Label lbl = CreateLabel(text, true);
                                ////Button button = CreateButton(text, false);
                                //Graphics graphics = CreateGraphics();
                                //SizeF sizeF = graphics.MeasureString(text, lbl.Font);
                                lbl.Size = lblDosage1.Size;
                                //if ((sizeF.Width + 5) > button.Width)
                                //    button.Width = Convert.ToInt32(sizeF.Width) + 15;
                                if (!_dosageLabel.Contains(lbl))
                                {
                                    _dosageLabel.Add(lbl);
                                }
                                lbl.Tag = i;
                                lbl.MouseDown += new MouseEventHandler(lblDosage_Click);
                                l = l - lbl.Width - 5;
                                lbl.Location = new Point(l, t + 5);

                                if (selectedDosage != 999999)
                                {
                                    if (selectedDosage.Equals(double.Parse(lbl.Text)))
                                    {
                                        lbl.ForeColor = Color.Chocolate;
                                        check = true;
                                    }
                                }
                            }
                        }
                    }
                    if ((i + 1) % 3 == 0)
                        t = t + simpleButton.Height + 8;
                    if (selectedDosage != 999999 && !check)
                    {
                        if (selectedDosage == 0)
                        {
                            simpleButton = CreateButton("+");
                        }
                        else
                        {
                            simpleButton = CreateButton(Round(selectedDosage, 2).ToString());
                        }
                        simpleButton.ForeColor = Color.Chocolate;
                    }
                    else
                    {
                        simpleButton = CreateButton("?");
                    }
                    simpleButton.Tag = i;
                    simpleButton.Click += new EventHandler(btn_Click);
                    simpleButton.Location = new Point(l, t);

                    if (!_dosageButtons.Contains(simpleButton))
                    {
                        _dosageButtons.Add(simpleButton);
                    }
                    count = count + 1;
                    if (count >= _pageLines * 2)
                    {
                        return;
                    }
                }
                else
                {
                    simpleButton = CreateButton(dataSet.Tables[EventName].Rows[_dictIndexList[i]]["EVENT_ITEM_NAME"].ToString());
                    if (!_dosageButtons.Contains(simpleButton))
                    {
                        _dosageButtons.Add(simpleButton);
                    }
                    left = 5;
                    if (i % 3 != 0)
                    {
                        left = 5 + _buttonWidth * (i % 3) + 10 * (i % 3);
                    }
                    simpleButton.Location = new Point(left, t);
                    simpleButton.Width = _buttonWidth;
                    simpleButton.MouseDown += new MouseEventHandler(btnDosage_Click);
                    simpleButton.Tag = i;
                    if (!_dosageButtons.Contains(simpleButton))
                    {
                        _dosageButtons.Add(simpleButton);
                    }
                    count = count + 1;
                    if (count >= _pageLines * _rowButtons)
                    {
                        return;
                    }
                    roundIndex++;
                    if (roundIndex == _pageLines)
                    {
                        roundIndex = 0;
                        t = t + simpleButton.Height + 8;
                    }
                }
            }
            foreach (Control control in panelBody.Controls)
            {
                if (control is Button && control.Text.Equals("?"))
                {
                    control.Visible = false;
                }
            }
        }

        private List<Button> _dosageButtons = new List<Button>();
        private List<Label> _dosageLabel = new List<Label>();
        private void CalcPage()
        {
            int rowsCount = _dictIndexList.Count;
            int bn = _pageLines;//行数
            if (_isEvent)
            {
                bn = bn * _rowButtons;
            }
            else
            {
                bn = _pageLines * 2;
            }

            pages = rowsCount % bn == 0 ? rowsCount / bn : rowsCount / bn + 1;
        }
        //private int ButtonAreaWidth = 330;
        /// <summary>
        /// 获取页码按钮
        /// </summary>
        private void AddPageButton()
        {
            // if (pages < 2) return;
            int t = lblPage.Top;
            int l = 2;// ButtonAreaWidth - (_pageButtonWidth + 4) * pages;
            foreach (Label button in _pageIndexButtons)
            {
                if (panelPage.Controls.Contains(button))
                {
                    panelPage.Controls.Remove(button);
                }
            }
            _pageIndexButtons.Clear();
            int firstLeft = panelBody.Size.Width - (lblPage.Size.Width + 2) * pages;
            for (int i = 1; i <= pages; i++)
            {
                Label label = CreateLabel(i.ToString(), false);
                label.Size = lblPage.Size;
                label.Location = new Point(firstLeft + (label.Width + 2) * (i - 1), t);
                label.Click += new EventHandler(btnPage_Click);
                t = i / 15 * (label.Height + 3) + t;
                _pageIndexButtons.Add(label);
            }
        }

        /// <summary>
        /// 产生按钮方法
        /// </summary>
        /// <param name="text">按钮显示文本</param>
        private Button CreateButton(string text)
        {//panelBody
            Button button = new Button();
            button.Visible = false;
            button.TextAlign = ContentAlignment.MiddleLeft;

            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.Cursor = System.Windows.Forms.Cursors.Hand;
            button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            // button.BackgroundImage = Resources.事件未选中;
            button.BackgroundImage = Resources.事件未选中;
            //button.BackgroundImageLayout = ImageLayout.Zoom;
            button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(75)))), ((int)(((byte)(77)))));
            button.Size = new Size(40, 30);
            button.MouseEnter += button_MouseEnter;
            button.MouseLeave += button_MouseLeave;
            button.Paint += button_Pain;
            button.Text = text;
            panelBody.Controls.Add(button);
            button.BringToFront();
            return button;
        }

        void button_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).BackgroundImage = Resources.事件未选中;//BackgroundImage
            (sender as Button).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(75)))), ((int)(((byte)(77)))));
        }

        void button_MouseEnter(object sender, EventArgs e)
        {
            (sender as Button).BackgroundImage = Resources.事件选中;
            (sender as Button).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
        }
        void button_MouseLeave1(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(103)))), ((int)(((byte)(104)))));
            (sender as Label).BackColor = Color.White;
        }

        void button_MouseEnter1(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            (sender as Label).BackColor = Color.White;
        }
        private Label CreateLabel(string text, bool isDosage)
        {
            Label label = new Label();
            label.Visible = true;
            label.Text = text;
            if (isDosage)
            {
                label.Font = lblDosage1.Font;
                label.TextAlign = lblDosage1.TextAlign;
                label.BackColor = Color.White;
                label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(103)))), ((int)(((byte)(104)))));
                label.MouseEnter += button_MouseEnter1;
                label.MouseLeave += button_MouseLeave1;
                label.Paint += button_Pain1;
                panelBody.Controls.Add(label);
            }
            else
            {
                label.Font = lblPage.Font;
                label.ForeColor = lblPage.ForeColor;
                label.MouseEnter += label_MouseEnter;
                label.MouseLeave += label_MouseLeave;
                panelPage.Controls.Add(label);
            }
            label.BringToFront();
            return label;
        }

        void label_MouseLeave(object sender, EventArgs e)
        {
            (sender as Label).Font = new Font(lblPage.Font, FontStyle.Regular);
            (sender as Label).ForeColor = lblPage.ForeColor;
        }

        void label_MouseEnter(object sender, EventArgs e)
        {
            (sender as Label).Font = new Font(lblPage.Font, FontStyle.Bold | FontStyle.Underline);
            (sender as Label).Width = 30;
            (sender as Label).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(202)))));
        }
        void simpleButton_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Resources.按钮样式1, e.ClipRectangle);

            // throw new NotImplementedException();
        }

        /// <summary>
        /// 清除窗体动态生产的按钮
        /// </summary>
        /// <param name="isCleanAll">是否全部清除，false则保留页码按钮</param>
        private void ClearButton()
        {
            foreach (Control ct in _dosageButtons)
            {
                this.panelBody.Controls.Remove(ct);
            }
            foreach (Control ct in _dosageLabel)
            {
                this.panelBody.Controls.Remove(ct);
            }
        }

        /// <summary>
        /// 返回当前事件已选择的常用量
        /// </summary>
        /// <param name="itemno">事件itemno</param>
        /// <param name="itemclass">事件itemclass</param>
        /// <returns>返回选择常用量，若当前行未选择返回0</returns>
        private double SelectedDosage(string itemno, string itemclass)
        {
            if (items.Count > 0)
            {
                foreach (EventInfo item in items)
                {
                    if (item.ItemNo.Equals(itemno) && item.ItemClass.Equals(itemclass))
                    {
                        return item.Dosage;
                    }
                }
            }
            return 999999;
        }

        /// <summary>
        /// 对小数四舍五入
        /// </summary>
        /// <param name="d">要处理的小数</param>
        /// <param name="i">要保留的小数位数</param>
        /// <returns>返回处理后值</returns>
        private double Round(double d, int i)
        {
            if (d >= 0)
            {
                d += 5 * Math.Pow(10, -(i + 1));
            }
            else
            {
                d += -5 * Math.Pow(10, -(i + 1));
            }
            string str = d.ToString();
            string[] strs = str.Split('.');
            int idot = str.IndexOf('.');
            string prestr = strs[0];
            string poststr = strs[1];
            if (poststr.Length > i)
            {
                poststr = str.Substring(idot + 1, i);
            }
            string strd = prestr + "." + poststr;
            d = Double.Parse(strd);
            return d;
        }

        private void ItemAdd(int tag, string text)
        {
            eventInfo = new EventInfo();
            DataRow row = dataSet.Tables[EventName].Rows[_dictIndexList[tag]];
            eventInfo.ItemNo = row["EVENT_ITEM_CODE"].ToString();
            eventInfo.ItemClass = row["EVENT_CLASS_CODE"].ToString();
            eventInfo.ItemName = row["EVENT_ITEM_NAME"].ToString();
            eventInfo.ItemSpec = row["EVENT_ITEM_SPEC"] == DBNull.Value ? null : row["EVENT_ITEM_SPEC"].ToString();
            eventInfo.Event_Attr = row["EVENT_ATTR"] == DBNull.Value ? null : row["EVENT_ATTR"].ToString();  //add by xiaopei.y@2014-11-14 14:19:51  添加属性字段
            if (!_isEvent)
            {
                double dosage = 0;
                if (!double.TryParse(text, out dosage))
                {
                    dosage = 0;
                }
                eventInfo.Dosage = dosage;
                eventInfo.DosageUnits = row["DOSAGE_UNITS"] == DBNull.Value ? null : row["DOSAGE_UNITS"].ToString();
                eventInfo.Administrator = row["ADMINISTRATOR"] == DBNull.Value ? null : row["ADMINISTRATOR"].ToString();
                if (row["PERFORM_SPEED"] != DBNull.Value)
                {
                    eventInfo.PerformSpeed = double.Parse(row["PERFORM_SPEED"].ToString());
                }
                eventInfo.SpeedUnit = row["SPEED_UNIT"] == DBNull.Value ? null : row["SPEED_UNIT"].ToString();
                if (row["CONCENTRATION"] != DBNull.Value)
                {
                    eventInfo.Concentration = double.Parse(row["CONCENTRATION"].ToString());
                }
                eventInfo.ConcentrationUnit = row["CONCENTRATION_UNIT"] == DBNull.Value ? null : row["CONCENTRATION_UNIT"].ToString();

            }
            if (row["DURATIVE_INDICATOR"] != DBNull.Value)
            {
                eventInfo.DuractiveIndicator = double.Parse(row["DURATIVE_INDICATOR"].ToString());
            }
            // eventInfo.StartTime = timeEvent.Value;
            items.Add(eventInfo);
        }

        private void ItemRemove(Button simpleButton)
        {
            foreach (EventInfo item in items)
            {
                if (item.ItemNo.Equals(dataSet.Tables[EventName].Rows[_dictIndexList[(int)(simpleButton.Tag)]]["EVENT_ITEM_CODE"].ToString()) &&
                    item.ItemClass.Equals(dataSet.Tables[EventName].Rows[_dictIndexList[(int)(simpleButton.Tag)]]["EVENT_CLASS_CODE"].ToString()))
                {
                    items.Remove(item);
                    break;
                }
            }
        }
        /// <summary>
        /// 设置麻醉事件排序值
        /// </summary>
        private void SetEventSortValue(MED_ANESTHESIA_EVENT row)
        {
            // MED_EVENT_DICT tempEventData = listInfo.Where(p => p.EVENT_ITEM_CODE == this.selectEvent.EVENT_ITEM_CODE && p.EVENT_CLASS_CODE == _strClassCode).FirstOrDefault();
            MED_EVENT_SORT tempSortData = ExtendApplicationContext.Current.CommDict.EventSortDict.Where(p => p.EVENT_ITEM_CODE == row.EVENT_ITEM_CODE && p.EVENT_CLASS_CODE == row.EVENT_CLASS_CODE).FirstOrDefault();
            // if (tempEventData != null) tempEventData.SORT_NO += 1;EVENT_ITEM_CODE EVENT_ITEM_NAME USER_ID SORT_NO
            if (tempSortData != null) tempSortData.SORT_NO += 1;
            else
            {
                tempSortData = new MED_EVENT_SORT();
                tempSortData.EVENT_CLASS_CODE = row.EVENT_CLASS_CODE;
                tempSortData.EVENT_ITEM_CODE = row.EVENT_CLASS_CODE;
                tempSortData.EVENT_ITEM_NAME = row.EVENT_ITEM_NAME;
                tempSortData.USER_ID = ExtendApplicationContext.Current.LoginUser.USER_JOB_ID;
                tempSortData.SORT_NO = 1;
                ExtendApplicationContext.Current.CommDict.EventSortDict.Add(tempSortData);
            }
        }
        private void btnPage_Click(object sender, EventArgs e)
        {
            //timeEvent.Value = DateTime.Now;
            ReSetDictIndexList(searchTextBox.CurrentText);
            page = int.Parse((sender as Label).Text);
            AddDosageButton(page - 1);
            AddPageButton();
            foreach (Control control in panelBody.Controls)
            {
                if (control is Button && !control.Text.Equals("?"))
                {
                    control.Visible = true;
                }
            }
        }
        private void lblDosage_Click(object sender, MouseEventArgs e)
        {
            Label lbl = sender as Label;
            if (!lbl.Text.Equals("?"))
            {
                ItemAdd(Convert.ToInt32(lbl.Tag), lbl.Text);
                if (items.Count > 0)
                {
                    foreach (EventInfo info in items)
                    {
                        MED_ANESTHESIA_EVENT row = _anesthesiaEventsEditor.AddRow(info.ItemClass, info.ItemName, info.ItemSpec, info.ItemCode, info.Administrator, (decimal)info.Concentration
                            , info.ConcentrationUnit, (decimal)info.Dosage, info.DosageUnits, (decimal)info.PerformSpeed, info.SpeedUnit, ExtendApplicationContext.Current.LoginUser.USER_JOB_ID, info.Event_Attr, (int)info.DuractiveIndicator);
                        SetEventSortValue(row);
                    }
                    items.Clear();
                }
            }
        }
        private void btnDosage_Click(object sender, MouseEventArgs e)
        {
            Button simpleButton = sender as Button;
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                ToolStripMenuItem item = new ToolStripMenuItem("药品查询");
                item.Click += new EventHandler(delegate(object sender1, EventArgs e1)
                {
                    AcsContent acsContent = new AcsContent();
                    string strSearch = "";
                    DataRow row = dataSet.Tables[EventName].Rows[_dictIndexList[(int)(simpleButton.Tag)]];
                    strSearch = row["EVENT_ITEM_NAME"].ToString();
                    acsContent.SetContextKeyWords(strSearch);
                    DialogHostFormPC dialog = new DialogHostFormPC("临床麻醉知识查询", acsContent.Width, acsContent.Height);
                    dialog.ShowDialog();
                });
                menu.Items.Add(item);
                menu.Show(Control.MousePosition);
            }
            else
            {
                if (!simpleButton.Text.Equals("?"))
                {
                    ItemAdd(Convert.ToInt32(simpleButton.Tag), simpleButton.Text);
                    if (items.Count > 0)
                    {
                        foreach (EventInfo info in items)
                        {
                            MED_ANESTHESIA_EVENT row = _anesthesiaEventsEditor.AddRow(info.ItemClass, info.ItemName, info.ItemSpec, info.ItemCode, info.Administrator, (decimal)info.Concentration
                                , info.ConcentrationUnit, (decimal)info.Dosage, info.DosageUnits, (decimal)info.PerformSpeed, info.SpeedUnit, ExtendApplicationContext.Current.LoginUser.USER_JOB_ID, info.Event_Attr, (int)info.DuractiveIndicator);
                            SetEventSortValue(row);
                        }
                        items.Clear();
                    }
                }
            }

        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button simpleButton = sender as Button;
            if (!simpleButton.Text.Equals("?"))
            {
                ItemAdd(Convert.ToInt32(simpleButton.Tag), simpleButton.Text);
            }
        }
        private void txtPinYing_EditValueChanged(object sender, string var)
        {
            ReSetDictIndexList(var);
            CalcPage();
            AddDosageButton(0);
            AddPageButton();
            foreach (Control control in panelBody.Controls)
            {
                if (control is Button && !control.Text.Equals("?"))
                {
                    control.Visible = true;
                }
            }
            //if (string.IsNullOrEmpty(txtPinYing.Text.Trim()))
            //    lblSeach.Visible = true;
        }

        private void panelTime_Paint(object sender, PaintEventArgs e)
        {
            Color border = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(186)))), ((int)(((byte)(230)))));
            ControlPaint.DrawBorder(e.Graphics, searchTextBox.ClientRectangle,
            border, 1, ButtonBorderStyle.Solid, //左边
            border, 1, ButtonBorderStyle.Solid, //上边
            border, 1, ButtonBorderStyle.Solid, //右边
            border, 1, ButtonBorderStyle.Solid);//底边
        }

        private void panelSearch_Paint(object sender, PaintEventArgs e)
        {
            Color border = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(186)))), ((int)(((byte)(230)))));
            ControlPaint.DrawBorder(e.Graphics, searchTextBox.ClientRectangle,
            border, 1, ButtonBorderStyle.Solid, //左边
            border, 1, ButtonBorderStyle.Solid, //上边
            border, 1, ButtonBorderStyle.Solid, //右边
            border, 1, ButtonBorderStyle.Solid);//底边
        }

        private void panelBody_Paint(object sender, PaintEventArgs e)
        {
            Color border = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            ControlPaint.DrawBorder(e.Graphics, panelBody.ClientRectangle,
            border, 1, ButtonBorderStyle.Solid, //左边
            border, 1, ButtonBorderStyle.Solid, //上边
            border, 1, ButtonBorderStyle.Solid, //右边
            border, 1, ButtonBorderStyle.Solid);//底边
        }
        private void button_Pain(object sender, PaintEventArgs e)
        {
            Color border = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(193)))), ((int)(((byte)(200)))));
            ControlPaint.DrawBorder(e.Graphics, panelBody.ClientRectangle,
            border, 1, ButtonBorderStyle.Solid, //左边
            border, 1, ButtonBorderStyle.Solid, //上边
            border, 1, ButtonBorderStyle.Solid, //右边
            border, 1, ButtonBorderStyle.Solid);//底边
        }
        private void button_Pain1(object sender, PaintEventArgs e)
        {
            Color border = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            ControlPaint.DrawBorder(e.Graphics, panelBody.ClientRectangle,
            border, 1, ButtonBorderStyle.Solid, //左边
            border, 1, ButtonBorderStyle.Solid, //上边
            border, 1, ButtonBorderStyle.Solid, //右边
            border, 1, ButtonBorderStyle.Solid);//底边
        }
        private void panelBody_SizeChanged(object sender, EventArgs e)
        {
            int firstLeft = panelBody.Size.Width - (lblPage.Size.Width + 2) * pages;
            for (int i = 0; i < _pageIndexButtons.Count; i++)
            {
                _pageIndexButtons[i].Location = new Point(firstLeft + (_pageIndexButtons[i].Width + 2) * i, _pageIndexButtons[i].Top);
            }
        }

        private void lblSeach_Click(object sender, EventArgs e)
        {
            // lblSeach.Visible = false;
        }

        private void cboEventType_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchTextBox.ClearTextBox();
            if (cboEventType.SelectedIndex >= 0)
            {
                EventName = cboEventType.Text;
                AnesthesiaEventDictSelectorLoad();
            }
            else
            {
                EventName = "ALL";
            }
        }

        private void panelType_Paint(object sender, PaintEventArgs e)
        {
            Color border = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(186)))), ((int)(((byte)(230)))));
            ControlPaint.DrawBorder(e.Graphics, searchTextBox.ClientRectangle,
            border, 1, ButtonBorderStyle.Solid, //左边
            border, 1, ButtonBorderStyle.Solid, //上边
            border, 1, ButtonBorderStyle.Solid, //右边
            border, 1, ButtonBorderStyle.Solid);//底边
        }
    }
    /// <summary>
    /// 麻醉事件信息类
    /// </summary>
    [Serializable]
    public class EventInfo
    {
        private string itemNo;

        public string ItemNo
        {
            get { return itemNo; }
            set { itemNo = value; }
        }

        private string itemClass;

        public string ItemClass
        {
            get { return itemClass; }
            set { itemClass = value; }
        }

        private string itemName;

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        private string itemCode;

        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }

        private string itemSpec;

        public string ItemSpec
        {
            get { return itemSpec; }
            set { itemSpec = value; }
        }

        private double dosage;

        public double Dosage
        {
            get { return dosage; }
            set { dosage = value; }
        }

        private string dosageUnits;

        public string DosageUnits
        {
            get { return dosageUnits; }
            set { dosageUnits = value; }
        }

        private DateTime startTime;

        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        private string administrator;

        public string Administrator
        {
            get { return administrator; }
            set { administrator = value; }
        }

        private double performSpeed;

        public double PerformSpeed
        {
            get { return performSpeed; }
            set { performSpeed = value; }
        }

        private string speedUnit;

        public string SpeedUnit
        {
            get { return speedUnit; }
            set { speedUnit = value; }
        }

        private double concentration;

        public double Concentration
        {
            get { return concentration; }
            set { concentration = value; }
        }

        private string concentrationUnit;

        public string ConcentrationUnit
        {
            get { return concentrationUnit; }
            set { concentrationUnit = value; }
        }

        private double duractiveIndicator;

        public double DuractiveIndicator
        {
            get { return duractiveIndicator; }
            set { duractiveIndicator = value; }
        }
        private string event_Attr;

        public string Event_Attr
        {
            get { return event_Attr; }
            set { event_Attr = value; }
        }
    }
}
