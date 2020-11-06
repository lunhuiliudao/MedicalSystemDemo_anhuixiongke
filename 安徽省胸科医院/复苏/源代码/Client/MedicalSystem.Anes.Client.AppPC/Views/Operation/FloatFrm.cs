using DevExpress.XtraEditors;
using Med.OpetationSchedule.Common;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.FrameWork.Enum;
using MedicalSystem.Anes.Client.Service;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class FloatFrm : XtraForm
    {
        private AnesthesiaEventsEditor _anesthesiaEventsEditor = null;
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
        private List<SimpleButton> _pageIndexButtons = new List<SimpleButton>();
        private EventInfo eventInfo = null;
        private string  eventNo = "0";
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

        #region 方法

        /// <summary>
        /// 构造方法
        /// </summary>
        public FloatFrm()
        {
            dataSet = new DataSet();
            SetAnesClassTypes();
            InitializeComponent();
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

        private int _pageLines = 9;
        private int _rowButtons = 2;
        private bool _isEvent = false;
        private int _buttonWidth = 130;
        private int _pageButtonWidth = 30;
        private List<int> _dictIndexList = new List<int>();

        private void ReSetDictIndexList()
        {
            _dictIndexList.Clear();
            for (int i = 0; i < dataSet.Tables[Text].Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(txtPinYing.Text))
                {
                    _dictIndexList.Add(i);
                }
                else
                {
                    string itemName = "";
                    if (dataSet.Tables[Text].Rows[i]["ITEM_NAME"] != System.DBNull.Value)
                    {
                        itemName = dataSet.Tables[Text].Rows[i]["ITEM_NAME"].ToString();
                        if (!string.IsNullOrEmpty(itemName))
                        {
                            itemName = StringManage.GetPYString(itemName);
                        }
                    }
                    if (itemName.ToLower().Contains(txtPinYing.Text.ToLower()))
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
           // textEdit1.Visible = false;
            ClearButton();
            if (pages == 0) return;
            int t = 45;
            int count = 0;
            int left = 25;
            _dosageButtons.Clear();

            int roundIndex = 0;
            int startIndex = pageIndex * _pageLines;
            if (_isEvent)
            {
                startIndex = pageIndex * _pageLines * _rowButtons;
            }
            SimpleButton simpleButton = null;
            for (int i = startIndex; i < _dictIndexList.Count; i++)
            {
                if (!_isEvent)
                {
                    int l = 15;
                    simpleButton = CreateButton(dataSet.Tables[Text].Rows[_dictIndexList[i]]["EVENT_ITEM_NAME"].ToString());
                    if (!_dosageButtons.Contains(simpleButton))
                    {
                        _dosageButtons.Add(simpleButton);
                    }
                    simpleButton.Location = new Point(l, t);
                    simpleButton.Width = _buttonWidth;
                    simpleButton.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    simpleButton.Tag = i;
                    simpleButton.Click += new EventHandler(btnDosage_Click);
                    l = l + simpleButton.Width + 5;
                    bool check = false;
                    double selectedDosage = SelectedDosage(dataSet.Tables[Text].Rows[_dictIndexList[i]]["EVENT_ITEM_CODE"].ToString(), dataSet.Tables[Text].Rows[_dictIndexList[i]]["EVENT_CLASS_CODE"].ToString());
                    string itemClass = dataSet.Tables[Text].Rows[_dictIndexList[i]]["EVENT_CLASS_CODE"].ToString();
                    string itemCode = dataSet.Tables[Text].Rows[_dictIndexList[i]]["EVENT_ITEM_CODE"].ToString();
                    List<MED_EVENT_DICT_EXT> eventExtList = ExtendApplicationContext.Current.CommDict.EventDictExt.
                        Where(x => x.EVENT_CLASS_CODE == itemClass && x.EVENT_ITEM_CODE == itemCode).ToList();
                    if (eventExtList != null && eventExtList.Count > 0)
                    {
                        foreach (MED_EVENT_DICT_EXT eventExt in eventExtList)
                        {
                            if (eventExt.STANDARD_DOSAGE.HasValue)
                            {
                                simpleButton = CreateButton(Round(double.Parse(eventExt.STANDARD_DOSAGE.ToString()), 2).ToString());
                                if (!_dosageButtons.Contains(simpleButton))
                                {
                                    _dosageButtons.Add(simpleButton);
                                }
                                simpleButton.Tag = i;
                                simpleButton.Click += new EventHandler(btnDosage_Click);
                                simpleButton.Location = new Point(l, t);
                                l = l + simpleButton.Width + 5;
                                if (selectedDosage != 999999)
                                {
                                    if (selectedDosage.Equals(double.Parse(simpleButton.Text)))
                                    {
                                        simpleButton.ForeColor = Color.Chocolate;
                                        check = true;
                                    }
                                }
                            }
                        }
                    }
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

                    t = t + simpleButton.Height + 8;
                    if (!_dosageButtons.Contains(simpleButton))
                    {
                        _dosageButtons.Add(simpleButton);
                    }
                    count = count + 1;
                    if (count >= _pageLines)
                    {
                        return;
                    }
                }
                else
                {
                    simpleButton = CreateButton(dataSet.Tables[Text].Rows[_dictIndexList[i]]["EVENT_ITEM_NAME"].ToString());
                    if (!_dosageButtons.Contains(simpleButton))
                    {
                        _dosageButtons.Add(simpleButton);
                    }
                    simpleButton.Location = new Point(left, t);
                    simpleButton.Width = _buttonWidth;
                    simpleButton.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    simpleButton.Click += new EventHandler(btnDosage_Click);
                    left = left + simpleButton.Width + 25;
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
                    if (roundIndex == _rowButtons)
                    {
                        roundIndex = 0;
                        t = t + simpleButton.Height + 8;
                        left = 25;
                    }
                }
            }
            foreach (Control control in Controls)
            {
                if (control is SimpleButton && control.Text.Equals("?"))
                {
                    control.Visible = false;
                }
            }
        }

        private List<SimpleButton> _dosageButtons = new List<SimpleButton>();

        private void ResetButtons(int pageIndex)
        {
            ReSetDictIndexList();
            AddDosageButton(pageIndex);
            AddPageButton();
            foreach (Control control in Controls)
            {
                if (control is SimpleButton && !control.Text.Equals("?"))
                {
                    control.Visible = true;
                }
            }
        }

        private void CalcPage()
        {
            int rowsCount = _dictIndexList.Count;
            int bn = _pageLines;
            if (_isEvent)
            {
                bn = bn * _rowButtons;
            }

            pages = rowsCount % bn == 0 ? rowsCount / bn : rowsCount / bn + 1;
        }

        /// <summary>
        /// 获取页码按钮
        /// </summary>
        private void AddPageButton()
        {
            if (pages < 2) return;
            int t = 400;
            int l = ButtonAreaWidth - (_pageButtonWidth + 4) * pages;
            foreach (SimpleButton button in _pageIndexButtons)
            {
                if (Controls.Contains(button))
                {
                    Controls.Remove(button);
                }
            }
            _pageIndexButtons.Clear();
            for (int i = 1; i <= pages; i++)
            {
                SimpleButton simpleButton = CreateButton(i.ToString());
                simpleButton.Size = new Size(_pageButtonWidth, _pageButtonWidth);
                simpleButton.Location = new Point(l + (simpleButton.Width + 4) * (i - 1), t);
                simpleButton.Click += new EventHandler(btnPage_Click);
                t = i / 15 * (simpleButton.Height + 4) + t;
                _pageIndexButtons.Add(simpleButton);
            }
        }

        /// <summary>
        /// 产生按钮方法
        /// </summary>
        /// <param name="text">按钮显示文本</param>
        private SimpleButton CreateButton(string text)
        {
            SimpleButton simpleButton = new SimpleButton();
            simpleButton.Visible = false;
            simpleButton.ForeColor = Color.Black;
            simpleButton.Cursor = System.Windows.Forms.Cursors.Hand;
            simpleButton.Size = new Size(40, 30);
            simpleButton.Text = text;
            simpleButton.ToolTip = text;
            this.Controls.Add(simpleButton);
            simpleButton.BringToFront();
            return simpleButton;
        }

        /// <summary>
        /// 清除窗体动态生产的按钮
        /// </summary>
        /// <param name="isCleanAll">是否全部清除，false则保留页码按钮</param>
        private void ClearButton()
        {
            foreach (Control ct in _dosageButtons)
            {
                this.Controls.Remove(ct);
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

        private void ItemAdd(SimpleButton simpleButton)
        {
            eventInfo = new EventInfo();
            DataRow row = dataSet.Tables[Text].Rows[_dictIndexList[(int)(simpleButton.Tag)]];
            eventInfo.ItemNo = row["EVENT_ITEM_CODE"].ToString();
            eventInfo.ItemClass = row["EVENT_CLASS_CODE"].ToString();
            eventInfo.ItemName = row["EVENT_ITEM_NAME"].ToString();
           // eventInfo.ItemCode = row["ITEM_CODE"] == DBNull.Value ? null : row["ITEM_CODE"].ToString();
            eventInfo.ItemSpec = row["EVENT_ITEM_SPEC"] == DBNull.Value ? null : row["EVENT_ITEM_SPEC"].ToString();
            eventInfo.Event_Attr = row["EVENT_ATTR"] == DBNull.Value ? null : row["EVENT_ATTR"].ToString();  //add by xiaopei.y@2014-11-14 14:19:51  添加属性字段
            if (!_isEvent)
            {
                double dosage = 0;
                if (!double.TryParse(simpleButton.Text, out dosage))
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
            eventInfo.StartTime = timeEvent.Value;
            items.Add(eventInfo);
        }

        private void ItemRemove(SimpleButton simpleButton)
        {
            foreach (EventInfo item in items)
            {
                if (item.ItemNo.Equals(dataSet.Tables[Text].Rows[_dictIndexList[(int)(simpleButton.Tag)]]["EVENT_ITEM_CODE"].ToString()) &&
                    item.ItemClass.Equals(dataSet.Tables[Text].Rows[_dictIndexList[(int)(simpleButton.Tag)]]["EVENT_CLASS_CODE"].ToString()))
                {
                    items.Remove(item);
                    break;
                }
            }
        }

        private void TextVisible()
        {
          //  textEdit1.Visible = false; 
        }

        #endregion

        #region 事件
        private int ButtonAreaWidth = 330;
        private void FloatFrm_Load(object sender, EventArgs e)
        {
           if (!AccessControl.CheckModifyRight(PermissionContext.ANESRECORDOPER))
            {
                if (_anesthesiaEventsEditor != null)
                {
                    _anesthesiaEventsEditor.SetReadOnly(true);
                }
            }
            btnOK.Top = 2000;
            btnCancel.Top = 2000;
            btnOK.Enabled = false;
            btnCancel.Enabled = false;
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
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
            this.Location = floatLocation;
            eventTable = OperationInfoService.GetAnesEventList(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID, eventNo).ToList();
            InitEventList(); 
        }

        void FloatFrm_Deactivate(object sender, EventArgs e)
        {
            //Close();
        }

        private void InitEventList()
        {
            if (_anesthesiaEventsEditor == null)
            {
                _anesthesiaEventsEditor = new AnesthesiaEventsEditor(ExtendApplicationContext.Current.PatientInformationExtend, eventNo);
                Controls.Add(_anesthesiaEventsEditor);
                _anesthesiaEventsEditor.Left = ButtonAreaWidth + 8;
                _anesthesiaEventsEditor.panelControl.Dock = DockStyle.Bottom;
                _anesthesiaEventsEditor.Width = Width - _anesthesiaEventsEditor.Left - 10;
                _anesthesiaEventsEditor.Top = 0;
                _anesthesiaEventsEditor.Height = 438;
                _anesthesiaEventsEditor.SaveHandle += new EventHandler(_anesthesiaEventsEditor_SaveHandle);
            }
            if (!string.IsNullOrEmpty(Text))
            {
                _anesthesiaEventsEditor.SetType(Text);
            }
            else
            {
                _anesthesiaEventsEditor.SetType("全部");
            }
        }

        void _anesthesiaEventsEditor_SaveHandle(object sender, EventArgs e)
        {
            SetEvent();
        }

        private void FloatFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            isFloat = false;
        }

        private void FloatFrm_TextChanged(object sender, EventArgs e)
        {
            this.Location = floatLocation;
            ClearButton();
            if (anesClassTypes.ContainsKey(Text) || AnesEventType.CPBEventType.ContainsKey(Text))
            {
                if (ExtendApplicationContext.Current.SystemStatus == ProgramStatus.CPBReport)
                {
                    _isEvent = Text.Equals("事件");
                }
                else
                {
                    _isEvent = ("234BCX".IndexOf(anesClassTypes[Text]) < 0);
                } 
                timeEvent.Value = DateTime.Now;

                if (!dataSet.Tables.Contains(Text))
                {
                    string itemClass = "";
                    DataTable dataTable = null;
                    //if (ExtendApplicationContext.Current.SystemStatus == ProgramStatus.CPBReport)
                    //{
                    //    itemClass = AnesEventType.CPBEventType[Text];
                    //    dataTable = CPBProxy.GetCPBEventOpen(itemClass);
                    //}
                    //else
                    {
                        if (Text.Equals("呼吸"))
                        {
                         dataTable = new ModelHandler<MED_EVENT_DICT>().FillDataTable(AnesEventService.GetAnesEventDictByhuxi()) ;
                          for (int i = 0; i < dataTable.Rows.Count ; i++)
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
                        else
                        {
                            itemClass = anesClassTypes[Text];
                            List<MED_EVENT_DICT> eventList = ExtendApplicationContext.Current.CommDict.EventDict.Where(p => p.EVENT_CLASS_CODE == itemClass).ToList();
                            dataTable = new ModelHandler<MED_EVENT_DICT>().FillDataTable(eventList);
                        }
                    }
                    dataSet.Tables.Add(dataTable);
                    dataTable.TableName = Text;
                }
                ReSetDictIndexList();
                CalcPage();
                AddDosageButton(0);
                AddPageButton();
                foreach (Control control in Controls)
                {
                    if (control is SimpleButton && !control.Text.Equals("?"))
                    {
                        control.Visible = true;
                    }
                }
            }
            if (_anesthesiaEventsEditor != null)
            {
                if (!string.IsNullOrEmpty(Text))
                {
                    _anesthesiaEventsEditor.SetType(Text);
                }
                else
                {
                    _anesthesiaEventsEditor.SetType("全部");
                }
            }
        }

        private void btnPage_Click(object sender, EventArgs e)
        {
            timeEvent.Value = DateTime.Now;
            ReSetDictIndexList();
            page = int.Parse((sender as SimpleButton).Text);
            AddDosageButton(page - 1);
            AddPageButton();
            foreach (Control control in Controls)
            {
                if (control is SimpleButton && !control.Text.Equals("?"))
                {
                    control.Visible = true;
                }
            }
        }

        private void btnDosage_Click(object sender, EventArgs e)
        {
            SimpleButton simpleButton = sender as SimpleButton;
            if (!simpleButton.Text.Equals("?"))
            {
                ItemAdd(simpleButton);
               // OperationLogger.WriteOperate("事件登记", "添加", "大事件界面中从事件常用量字典点击添加", false, OperationLogKind.Other);

                btnOK_Click(null, null);

            }
        }

        private void textEdit1_Leave(object sender, EventArgs e)
        {

        }

        private void FloatFrm_Resize(object sender, EventArgs e)
        {
            if (_anesthesiaEventsEditor != null && Width > 0)
            {
                _anesthesiaEventsEditor.Width = Width - _anesthesiaEventsEditor.Left - 10;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (items.Count > 0)
                {
                    foreach (EventInfo info in items)
                    {
                        MED_ANESTHESIA_EVENT row = _anesthesiaEventsEditor.AddRow(info.ItemClass, info.ItemName, info.ItemSpec, info.ItemCode, info.Administrator, (decimal)info.Concentration
                            , info.ConcentrationUnit, (decimal)info.Dosage, info.DosageUnits, (decimal)info.PerformSpeed, info.SpeedUnit, ExtendApplicationContext.Current.LoginUser.USER_JOB_ID, info.Event_Attr);
                        if (row != null)
                        {
                            row.START_TIME = timeEvent.Value;
                            row.DURATIVE_INDICATOR = (int)info.DuractiveIndicator;
                        }
                    }
                    items.Clear();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
            SimpleButton simpleButton = sender as SimpleButton;
            if (!simpleButton.Text.Equals("?"))
            {
                ItemAdd(simpleButton);

               // OperationLogger.WriteOperate("事件登记", "添加", "大事件界面中从事件字典点击添加", false, OperationLogKind.Other);

                btnOK_Click(null, null);
            }
        }

        #endregion

        private void txtPinYing_EditValueChanged(object sender, EventArgs e)
        {
            ReSetDictIndexList();
            CalcPage();
            AddDosageButton(0);
            AddPageButton();
            foreach (Control control in Controls)
            {
                if (control is SimpleButton && !control.Text.Equals("?"))
                {
                    control.Visible = true;
                }
            }
        }

        private bool CheckSave()
        {
            if (_anesthesiaEventsEditor != null && _anesthesiaEventsEditor.IsDirty)
            {
                DialogResult result = Dialog.MessageBox("输入未保存，现在保存吗?", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                Application.DoEvents();
                if (result == DialogResult.No)
                {
                    return true;
                }
                else if (result == DialogResult.Cancel)
                {
                    return false;
                }
                else
                {
                    return _anesthesiaEventsEditor.Save();
                }
            }
            return true;
        }

        private void FloatFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CheckSave())
            {
               // OperationLogger.WriteOperate("事件登记", "关闭", "大事件界面关闭前数据保存检查未通过，进行阻止关闭", false, OperationLogKind.Other);

                e.Cancel = true;
                return;
            } 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = panel1.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;
            e.Graphics.DrawRectangle(Pens.Silver, rect);
        }

    }

    ///// <summary>
    ///// 麻醉事件信息类
    ///// </summary>
    //[Serializable]
    //public class EventInfo
    //{
    //    private string itemNo;

    //    public string ItemNo
    //    {
    //        get { return itemNo; }
    //        set { itemNo = value; }
    //    }

    //    private string itemClass;

    //    public string ItemClass
    //    {
    //        get { return itemClass; }
    //        set { itemClass = value; }
    //    }

    //    private string itemName;

    //    public string ItemName
    //    {
    //        get { return itemName; }
    //        set { itemName = value; }
    //    }

    //    private string itemCode;

    //    public string ItemCode
    //    {
    //        get { return itemCode; }
    //        set { itemCode = value; }
    //    }

    //    private string itemSpec;

    //    public string ItemSpec
    //    {
    //        get { return itemSpec; }
    //        set { itemSpec = value; }
    //    }

    //    private double dosage;

    //    public double Dosage
    //    {
    //        get { return dosage; }
    //        set { dosage = value; }
    //    }

    //    private string dosageUnits;

    //    public string DosageUnits
    //    {
    //        get { return dosageUnits; }
    //        set { dosageUnits = value; }
    //    }

    //    private DateTime startTime;

    //    public DateTime StartTime
    //    {
    //        get { return startTime; }
    //        set { startTime = value; }
    //    }

    //    private string administrator;

    //    public string Administrator
    //    {
    //        get { return administrator; }
    //        set { administrator = value; }
    //    }

    //    private double performSpeed;

    //    public double PerformSpeed
    //    {
    //        get { return performSpeed; }
    //        set { performSpeed = value; }
    //    }

    //    private string speedUnit;

    //    public string SpeedUnit
    //    {
    //        get { return speedUnit; }
    //        set { speedUnit = value; }
    //    }

    //    private double concentration;

    //    public double Concentration
    //    {
    //        get { return concentration; }
    //        set { concentration = value; }
    //    }

    //    private string concentrationUnit;

    //    public string ConcentrationUnit
    //    {
    //        get { return concentrationUnit; }
    //        set { concentrationUnit = value; }
    //    }

    //    private double duractiveIndicator;

    //    public double DuractiveIndicator
    //    {
    //        get { return duractiveIndicator; }
    //        set { duractiveIndicator = value; }
    //    } 
    //    private string event_Attr;

    //    public string Event_Attr
    //    {
    //        get { return event_Attr; }
    //        set { event_Attr = value; }
    //    }
    //}
}
