using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClientScreens.Properties;
using DotNetSpeech;
using MedicalSystem.MedScreen.Network;
using MedicalSystem.AnesIcuQuery.Models;
using MedicalSystem.AnesIcuQuery.Network;
using MedicalSystem.AnesIcuQuery.Common;
using ClientScreens;

namespace MedicalSystem.MedScreen.Client.PatDocScreen
{
    [ToolboxItem(false), Description("手术排班大屏界面")]
    public partial class OperScheduleScreen : DevExpress.XtraEditors.XtraUserControl
    {
        #region 变量
        /// <summary>
        /// 当前时间，星期x xx年xx月xx日 xx:xx
        /// </summary>
        string curnt_time = "";
        /// <summary>
        /// 大屏标题字体
        /// </summary>
        Font LabelFont = null;
        /// <summary>
        /// 时间字体
        /// </summary>
        Font DateTimeFont = null;

        /// <summary>
        /// 常规列的列表
        /// 包含列名和宽度
        /// </summary>
        Dictionary<string, double> normalColsList = new Dictionary<string, double>();
        /// <summary>
        /// 接台列的列表
        /// </summary>
        Dictionary<string, double> seqColsList = new Dictionary<string, double>();
        /// <summary>
        /// 常规大屏视图表
        /// </summary>
        DataTable viewOperList = null;
        /// <summary>
        /// 已完成和未完成的手术台数
        /// </summary>
        string finishStr = "已完成{0}台";
        string totalStr = "共{0}台";
        /// <summary>
        /// 总页数
        /// </summary>
        int TotalPage = 1;
        /// <summary>
        /// 当前页码
        /// </summary>
        int CurntPageIndex = 0;
        /// <summary>
        /// 通告信息字体
        /// </summary>
        Font MsgFont = null;
        /// <summary>
        /// 通告信息起始位置
        /// </summary>
        float msgStartX = 0;
        float msgCurntX = 0;
        float msgCurntY = 0;
        /// <summary>
        /// 移动速度
        /// </summary>
        float msgStep = 5;
        /// <summary>
        /// 静态信息索引
        /// </summary>
        int msgIndex = 0;
        /// <summary>
        /// 当前通告信息
        /// </summary>
        string curntMsg = "";
        /// <summary>
        /// 是否是紧急公告
        /// </summary>
        bool isEmgrcMsg = false;
        /// <summary>
        /// 语音播报
        /// </summary>
        string noticeMsg = "";
        SpeechVoiceSpeakFlags SpFlags;
        SpVoice Voice;
        /// <summary>
        /// 手术间字典
        /// </summary>
        DataTable operRoomDictDT;
        //正常显示信息和接台信息
        DataTable normalData;
        DataTable seqData;
        /// <summary>
        /// 收到的通信
        /// </summary>
        Dictionary<string, string> noticeMsgDict;
        #endregion


        /// <summary>
        /// 手术排班大屏
        /// </summary>
        public OperScheduleScreen()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            InitializeComponent();

            TransMessageManager.Instance.SendClientMessage += SendClientMessage;
        }

        private void SendClientMessage(string message)
        {
            if (noticeMsgDict == null) noticeMsgDict = new Dictionary<string, string>();
            string[] messageList = message.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < messageList.Length; i += 3)
            {
                noticeMsgDict.Add(messageList[i], messageList[i + 1] + "," + messageList[i + 2]);
            }
        }

        public EventHandler parentDoubleClick = null;

        /// <summary>
        /// 设置手术排班大屏显示布局
        /// </summary>
        private void SetScreenLayout()
        {
            System.Windows.Forms.Screen scr = System.Windows.Forms.Screen.PrimaryScreen;
            Rectangle rc = scr.Bounds;
            screenPnlSequence.Visible = ExtendAppContext.Current.SeqMode;
            //计算并设置各控件的高度
            ScreenCtrHelper.CalculateCtrsHeight(rc.Height);
            screenTopPnl.Height = ExtendAppContext.Current.TopBottomHeight;
            screenBottomPnl.Height = ExtendAppContext.Current.TopBottomHeight;
            normalPnlTop.Height = ExtendAppContext.Current.RowHeight;
            normalContentTitle.Height = ExtendAppContext.Current.RowHeight;
            seqPnlTop.Height = ExtendAppContext.Current.RowHeight;
            seqContentTitle.Height = ExtendAppContext.Current.RowHeight;

            //若接台展示
            if (ExtendAppContext.Current.SeqMode)
            {
                screenPnlSequence.Width = rc.Width / 3;
                seqColsList = ScreenCtrHelper.GetSeqColumnList(this.seqContentArea.Width * 0.95);
            }
            //一般显示内容
            normalColsList = ScreenCtrHelper.GetNormalColumnList(this.screenPnlNormal.Width * 0.95);
            //手术信息显示字体大小
            ExtendAppContext.Current.ContentFontSize = ExtendAppContext.Current.SeqMode ?
                MedicalSystem.MedScreen.Controls.ControlHelper.GetFontSizeByHeight(ExtendAppContext.Current.RowHeight * 0.5F, "微软雅黑") : MedicalSystem.MedScreen.Controls.ControlHelper.GetFontSizeByHeight(ExtendAppContext.Current.RowHeight * 0.6F, "微软雅黑");

            //大屏标签（标题）字体
            LabelFont = new Font("微软雅黑", MedicalSystem.MedScreen.Controls.ControlHelper.GetFontSizeByHeight(screenPnlLabel.Height * 0.8F, "微软雅黑"));
            screenPnlLabel.Width = (int)(this.CreateGraphics().MeasureString(ExtendAppContext.Current.ScreenLabel, LabelFont).Width * 1.1);
            //日期时间显示字体
            DateTimeFont = new Font("微软雅黑", MedicalSystem.MedScreen.Controls.ControlHelper.GetFontSizeByHeight(screenPnlTime.Height * 0.5F, "微软雅黑"));
            //公告信息
            MsgFont = new Font("微软雅黑", MedicalSystem.MedScreen.Controls.ControlHelper.GetFontSizeByHeight((float)ExtendAppContext.Current.TopBottomHeight * 0.7F, "微软雅黑"));
            msgStartX = rc.Width * 5 / 6;
            msgCurntX = msgStartX;
            msgCurntY = (ExtendAppContext.Current.TopBottomHeight - this.CreateGraphics().MeasureString("我", MsgFont).Height) / 2;
            msgStep = this.CreateGraphics().MeasureString("1", MsgFont).Width / 4;

        }

        /// <summary>
        /// 获取分页信息
        /// </summary>
        private void GetPageInfo()
        {
            try
            {
                QueryParams queryParams = new QueryParams();
                queryParams.AddQueryDefines("OperDept", ExtendAppContext.Current.OperDeptCode);
                string roomFilter = "";
                if (!ExtendAppContext.Current.OperRoomFilter.Equals("*"))
                {
                    string[] rooms = ExtendAppContext.Current.OperRoomFilter.Split(',');
                    roomFilter = "(";
                    foreach (string room in rooms)
                    {
                        roomFilter += "'" + room + "'" + ",";
                    }
                    roomFilter = roomFilter.TrimEnd(',');
                    roomFilter += ")";

                }
                //获取大屏常规视图中的数据
                viewOperList = DataOperator.HttpWebApi<DataResult>(ApiUrlEnum.GetScreenViewNormal, queryParams).ToDataTable();

                if (!ExtendAppContext.Current.SeqMode)
                {
                    if (!string.IsNullOrEmpty(roomFilter))
                    {
                        viewOperList.DefaultView.RowFilter = "OPERATING_ROOM_NO IN " + roomFilter;
                        viewOperList = viewOperList.DefaultView.ToTable();
                    }
                    int dataRows = viewOperList.Rows.Count;
                    int temp = dataRows / ExtendAppContext.Current.RowCount;
                    if (temp * ExtendAppContext.Current.RowCount < dataRows)
                        temp += 1;
                    TotalPage = temp == 0 ? 1 : temp;
                    CurntPageIndex = 0;
                }
                else
                {
                    //获取手术间字典表数据
                    operRoomDictDT = DataOperator.HttpWebApi<DataResult>(ApiUrlEnum.GetOperRoomDict, queryParams).ToDataTable();
                    if (!string.IsNullOrEmpty(roomFilter))
                    {
                        operRoomDictDT.DefaultView.RowFilter = "ROOM_NO IN " + roomFilter;
                        operRoomDictDT = operRoomDictDT.DefaultView.ToTable();
                    }
                    int dataRows = operRoomDictDT.Rows.Count;
                    int temp = dataRows / ExtendAppContext.Current.RowCount;
                    if (temp * ExtendAppContext.Current.RowCount < dataRows)
                        temp += 1;
                    TotalPage = temp;
                    CurntPageIndex = 0;

                }
                //获取已完成和未完成的手术例数统计
                DataTable todayOperData = DataOperator.HttpWebApi<DataResult>(ApiUrlEnum.GetTodayInfo, queryParams).ToDataTable();
                DataRow[] rows = todayOperData.Select(" OPER_STATUS_CODE >= 35 ");
                finishStr = "已完成{0}台";
                totalStr = "共{0}台";
                finishStr = string.Format(finishStr, rows.Length.ToString());
                totalStr = string.Format(totalStr, todayOperData.Rows.Count.ToString());
                normalPnlTop.Refresh();
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }
        /// <summary>
        /// 获取当前的日期和时间
        /// </summary>
        private void GetCurrentTime()
        {
            try
            {
                DateTime now = DataOperator.HttpWebApi<DateTime>(ApiUrlEnum.GetServerDateTime, null); ;
                string en_week = now.DayOfWeek.ToString();
                string week = "";
                switch (en_week)
                {
                    case "Monday": week = "星期一"; break;
                    case "Tuesday": week = "星期二"; break;
                    case "Wednesday": week = "星期三"; break;
                    case "Thursday": week = "星期四"; break;
                    case "Friday": week = "星期五"; break;
                    case "Saturday": week = "星期六"; break;
                    case "Sunday": week = "星期日"; break;
                }
                curnt_time = week + " " + now.ToString("yyyy年MM月dd日 HH:mm");
                screenPnlTime.Refresh();
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex, false);
            }
        }

        /// <summary>
        /// 每分钟刷新一次时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTime_Tick(object sender, EventArgs e)
        {
            GetCurrentTime();
        }

        private void OperScheduleScreen_Load(object sender, EventArgs e)
        {
            //设置大屏布局
            SetScreenLayout();
            //获取页码信息
            GetPageInfo();
            //刷新频率
            timerRefreshPage.Interval = ExtendAppContext.Current.RefreshTime * 1000;
            timerRefreshPage.Start();
            //显示当前时间
            GetCurrentTime();
            dateTime.Start();
            //通告信息滚动
            msgTimer.Start();
        }

        private void screenPnlTime_DoubleClick(object sender, EventArgs e)
        {
            if (parentDoubleClick != null)
                parentDoubleClick(sender, e);
        }

        /// <summary>
        /// 画标题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void normalContentTitle_Paint(object sender, PaintEventArgs e)
        {
            if (normalColsList.Count != 0)
            {
                DrawNormalColsTitle(e.Graphics);
            }
        }

        /// <summary>
        /// 画接台标题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seqContentTitle_Paint(object sender, PaintEventArgs e)
        {
            DrawSeqColsTitle(e.Graphics);
        }

        private void DrawNormalColsTitle(Graphics g)
        {
            Rectangle rect = normalContentTitle.ClientRectangle;
            Font drawFont = new System.Drawing.Font("微软雅黑", ExtendAppContext.Current.ContentFontSize, FontStyle.Bold);
            float curntLet = 0;
            foreach (string title in normalColsList.Keys)
            {
                float col_width = float.Parse(Math.Floor(normalColsList[title]).ToString());
                float col_height = ExtendAppContext.Current.RowHeight;
                float str_height = g.MeasureString("我屮艸芔茻", drawFont).Height;
                float str_width = g.MeasureString(title, drawFont).Width;
                float startLeft = (col_width - str_width) / 2, startTop = (col_height - str_height) / 2;
                if (startLeft < 0) startLeft = 0;
                g.DrawString(title, drawFont, Brushes.Black, curntLet + startLeft, startTop);
                curntLet += col_width;
            }

        }

        private void DrawSeqColsTitle(Graphics g)
        {
            Rectangle rect = seqContentTitle.ClientRectangle;
            Font drawFont = new System.Drawing.Font("微软雅黑", ExtendAppContext.Current.ContentFontSize, FontStyle.Bold);
            float curntLet = 0;
            foreach (string title in seqColsList.Keys)
            {
                float col_width = float.Parse(Math.Floor(seqColsList[title]).ToString());
                float col_height = ExtendAppContext.Current.RowHeight;
                float str_height = g.MeasureString("我屮艸芔茻", drawFont).Height;
                float str_width = g.MeasureString(title, drawFont).Width;
                float startLeft = (col_width - str_width) / 2, startTop = (col_height - str_height) / 2;
                if (startLeft < 0) startLeft = 0;
                g.DrawString(title, drawFont, Brushes.Black, curntLet + startLeft, startTop);
                curntLet += col_width;
            }

        }

        private void normalContentArea_Paint(object sender, PaintEventArgs e)
        {
            if (viewOperList != null && viewOperList.Rows.Count > 0)
            {
                Font drawFont = new System.Drawing.Font("微软雅黑", ExtendAppContext.Current.ContentFontSize);
                float str_height = e.Graphics.MeasureString("我屮艸芔茻", drawFont).Height;
                float col_height = ExtendAppContext.Current.RowHeight;
                float startTop = (col_height - str_height) / 2;
                float curntTop = startTop;

                Image img = Resources.透明文字格;
                if (!ExtendAppContext.Current.SeqMode)
                {
                    for (int i = CurntPageIndex * ExtendAppContext.Current.RowCount; i < viewOperList.Rows.Count; i++)
                    {
                        if (i >= (CurntPageIndex + 1) * ExtendAppContext.Current.RowCount) break;
                        if ((i - CurntPageIndex * ExtendAppContext.Current.RowCount) % 2 == 0)
                        {
                            Rectangle rect = new Rectangle(0, ExtendAppContext.Current.RowHeight * (i - CurntPageIndex * ExtendAppContext.Current.RowCount), normalContentArea.Width, ExtendAppContext.Current.RowHeight * 2);
                            e.Graphics.DrawImage(img, rect);
                        }
                        DataRow curntRow = viewOperList.Rows[i];

                        DrawNormalContentRow(curntRow, e.Graphics, curntTop, startTop, drawFont, i);
                        curntTop += col_height;
                    }
                }
                else
                {
                    for (int i = CurntPageIndex * ExtendAppContext.Current.RowCount; i < operRoomDictDT.Rows.Count; i++)
                    {
                        if (i >= (CurntPageIndex + 1) * ExtendAppContext.Current.RowCount) break;
                        if ((i - CurntPageIndex * ExtendAppContext.Current.RowCount) % 2 == 0)
                        {
                            Rectangle rect = new Rectangle(0, ExtendAppContext.Current.RowHeight * (i - CurntPageIndex * ExtendAppContext.Current.RowCount), normalContentArea.Width, ExtendAppContext.Current.RowHeight * 2);
                            e.Graphics.DrawImage(img, rect);
                        }

                        DataRow curntRow = operRoomDictDT.Rows[i];
                        DataRow drawRow = viewOperList.NewRow();
                        drawRow["OPERATING_ROOM_NO"] = curntRow["ROOM_NO"].ToString();
                        drawRow["BED_LABEL"] = curntRow["BED_LABEL"].ToString();

                        foreach (DataRow viewRow in viewOperList.Rows)
                        {
                            int state = Convert.ToInt32(viewRow["OPER_STATUS"].ToString());
                            if (curntRow["ROOM_NO"].ToString().Equals(viewRow["OPERATING_ROOM_NO"].ToString()) &&
                                state < 35)
                            {
                                drawRow = viewRow;
                                break;
                            }
                        }
                        DrawNormalContentRow(drawRow, e.Graphics, curntTop, startTop, drawFont, i);
                        curntTop += col_height;
                    }
                }
            }
        }

        private void DrawNormalContentRow(DataRow dr, Graphics g, float y, float y_offset, Font drawFont, int index)
        {
            string errorValue = "", errorCol = "";
            float errorColWidth = 0, valueWidth = 0;
            try
            {
                float curntLet = 0;
                foreach (string cap in normalColsList.Keys)
                {
                    errorCol = cap;
                    DataRow[] drs = ExtendAppContext.Current.FieldData.Select(string.Format("CAPTION = '{0}'", cap));
                    string colValue = "", fieldName = "";
                    if (drs.Length > 0)
                    {
                        foreach (DataRow row in drs)
                        {
                            fieldName = row["FIELD_NAME"].ToString();
                            if (!dr.IsNull(fieldName) && !string.IsNullOrEmpty(dr[fieldName].ToString().Trim()))
                                colValue += dr[fieldName] + "/";
                        }
                        colValue = colValue.TrimEnd('/').Replace("\n", "").Replace("\t", "").Replace("\r", "");
                        errorValue = colValue;
                    }
                    float str_width = g.MeasureString(colValue, drawFont).Width;
                    float col_width = float.Parse(Math.Floor(normalColsList[cap]).ToString());
                    errorColWidth = col_width;
                    float startLeft = (col_width - str_width) / 2 < 0 ? 0 : (col_width - str_width) / 2;
                    valueWidth = g.MeasureString(colValue, drawFont).Width;
                    //单元格无法显示完，需要分割为多行显示
                    //超出10%则换行，默认分为2行，不宜做太多复杂的计算
                    if (g.MeasureString(colValue, drawFont).Width >= col_width * 1.1F)
                    {
                        Font smallFont = new Font("微软雅黑", MedicalSystem.MedScreen.Controls.ControlHelper.GetFontSizeByHeight(ExtendAppContext.Current.RowHeight * 0.45F, "微软雅黑"));
                        if (g.MeasureString(colValue, drawFont).Width >= col_width * 2F)
                        {
                            int subLength = Convert.ToInt32(col_width / g.MeasureString("我", smallFont).Width) * 2;
                            if (subLength == 0 && colValue.Length > 0)
                                subLength = 1;
                            else if (subLength > colValue.Length)
                            { subLength = colValue.Length; }
                            colValue = colValue.Substring(0, subLength);
                        }

                        int splitIndex = colValue.Length / 2 + 1;
                        str_width = g.MeasureString(colValue.Substring(0, splitIndex), smallFont).Width;
                        startLeft = (col_width - str_width) / 2 < 0 ? 0 : (col_width - str_width) / 2;
                        g.DrawString(colValue.Substring(0, splitIndex), smallFont, Brushes.White, curntLet + startLeft, y - y_offset);
                        float newHeight = g.MeasureString(colValue, smallFont).Height;
                        g.DrawString(colValue.Substring(splitIndex, colValue.Length - splitIndex), smallFont, Brushes.White, curntLet + startLeft, y - y_offset + newHeight);
                    }
                    else
                    {
                        g.DrawString(colValue, drawFont, Brushes.White, curntLet + startLeft, y);
                    }
                    //画手术状态颜色标示
                    if (fieldName.ToUpper().Equals("TYPE") && colValue != "")
                    {
                        Brush stateBrush = Brushes.Blue;
                        curntLet += g.MeasureString("术前", drawFont).Width + 2;
                        switch (colValue)
                        {
                            case "术前": stateBrush = Brushes.Blue; break;
                            case "术中": stateBrush = Brushes.Red; break;
                            case "术后": stateBrush = Brushes.GreenYellow; break;
                            case "复苏":
                            case "复苏室": stateBrush = Brushes.Yellow; break;
                        }
                        g.FillRectangle(stateBrush, new RectangleF(curntLet + startLeft, y, ExtendAppContext.Current.RowHeight / 2f, ExtendAppContext.Current.RowHeight / 2f));
                        curntLet += ExtendAppContext.Current.RowHeight / 2f;
                    }
                    curntLet += col_width;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
                Logger.Write(string.Format("绘制列:{0}出错，列宽:{1}，实际值:{2}，实际宽:{3}", errorCol, errorColWidth.ToString(), errorValue, valueWidth.ToString()));
            }
        }

        private void seqContentArea_Paint(object sender, PaintEventArgs e)
        {
            if (viewOperList != null && viewOperList.Rows.Count > 0)
            {
                Font drawFont = new System.Drawing.Font("微软雅黑", ExtendAppContext.Current.ContentFontSize);
                float str_height = e.Graphics.MeasureString("我屮艸芔茻", drawFont).Height;
                float col_height = ExtendAppContext.Current.RowHeight;
                float startTop = (col_height - str_height) / 2;
                float curntTop = startTop;

                Image img = Resources.透明文字格;
                for (int i = CurntPageIndex * ExtendAppContext.Current.RowCount; i < operRoomDictDT.Rows.Count; i++)
                {
                    if (i >= (CurntPageIndex + 1) * ExtendAppContext.Current.RowCount) break;
                    if ((i - CurntPageIndex * ExtendAppContext.Current.RowCount) % 2 == 0)
                    {
                        Rectangle rect = new Rectangle(0, ExtendAppContext.Current.RowHeight * (i - CurntPageIndex * ExtendAppContext.Current.RowCount), normalContentArea.Width, ExtendAppContext.Current.RowHeight * 2);
                        e.Graphics.DrawImage(img, rect);
                    }

                    DataRow curntRow = operRoomDictDT.Rows[i];
                    DataRow preOperRow = null;
                    DataRow drawRow = viewOperList.NewRow();
                    drawRow["OPERATING_ROOM_NO"] = curntRow["ROOM_NO"].ToString();
                    foreach (DataRow viewRow in viewOperList.Rows)
                    {
                        if (curntRow["ROOM_NO"].ToString().Equals(viewRow["OPERATING_ROOM_NO"].ToString())
                            && preOperRow != null)
                        { drawRow = viewRow; break; }
                        int state = Convert.ToInt32(viewRow["OPER_STATUS"].ToString());
                        if (curntRow["ROOM_NO"].ToString().Equals(viewRow["OPERATING_ROOM_NO"].ToString()) &&
                            state < 35)
                        {
                            preOperRow = viewRow; continue;
                        }
                    }
                    DrawSequenceRow(drawRow, e.Graphics, curntTop, startTop, drawFont, i);
                    curntTop += col_height;
                }
            }
        }

        private void DrawSequenceRow(DataRow dr, Graphics g, float y, float y_offset, Font drawFont, int index)
        {
            string errorValue = "", errorCol = "";
            float errorColWidth = 0, valueWidth = 0;
            try
            {
                float curntLet = 0;
                foreach (string cap in seqColsList.Keys)
                {
                    errorCol = cap;
                    DataRow[] drs = ExtendAppContext.Current.SeqFieldData.Select(string.Format("CAPTION = '{0}'", cap));
                    string colValue = "", fieldName = "";
                    if (drs.Length > 0)
                    {
                        foreach (DataRow row in drs)
                        {
                            fieldName = row["FIELD_NAME"].ToString();
                            if (!dr.IsNull(fieldName) && !string.IsNullOrEmpty(dr[fieldName].ToString().Trim()))
                                colValue += dr[fieldName] + "/";
                        }
                        colValue = colValue.TrimEnd('/').Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
                        errorValue = colValue;
                    }
                    float str_width = g.MeasureString(colValue, drawFont).Width;
                    float col_width = float.Parse(Math.Floor(seqColsList[cap]).ToString());
                    errorColWidth = col_width;
                    float startLeft = (col_width - str_width) / 2 < 0 ? 0 : (col_width - str_width) / 2;
                    valueWidth = g.MeasureString(colValue, drawFont).Width;
                    //单元格无法显示完，需要分割为多行显示
                    //超出10%则换行，默认分为2行，不宜做太多复杂的计算
                    if (g.MeasureString(colValue, drawFont).Width >= col_width * 1.1F)
                    {
                        Font smallFont = new Font("微软雅黑", MedicalSystem.MedScreen.Controls.ControlHelper.GetFontSizeByHeight(ExtendAppContext.Current.RowHeight * 0.45F, "微软雅黑"));
                        if (g.MeasureString(colValue, drawFont).Width >= col_width * 2F)
                        {
                            int subLength = Convert.ToInt32(col_width / g.MeasureString("我", smallFont).Width) * 2;
                            if (subLength == 0 && colValue.Length > 0)
                                subLength = 1;
                            else if (subLength > colValue.Length)
                            { subLength = colValue.Length; }
                            colValue = colValue.Substring(0, subLength);
                        }

                        int splitIndex = colValue.Length / 2 + 1;
                        str_width = g.MeasureString(colValue.Substring(0, splitIndex), smallFont).Width;
                        startLeft = (col_width - str_width) / 2 < 0 ? 0 : (col_width - str_width) / 2;
                        g.DrawString(colValue.Substring(0, splitIndex), smallFont, Brushes.White, curntLet + startLeft, y - y_offset);
                        float newHeight = g.MeasureString(colValue, smallFont).Height;
                        g.DrawString(colValue.Substring(splitIndex, colValue.Length - splitIndex), smallFont, Brushes.White, curntLet + startLeft, y - y_offset + newHeight);
                    }
                    else
                    {
                        g.DrawString(colValue, drawFont, Brushes.White, curntLet + startLeft, y);
                    }
                    //画手术状态颜色标示
                    if (fieldName.ToUpper().Equals("TYPE") && colValue != "")
                    {
                        Brush stateBrush = Brushes.Blue;
                        curntLet += g.MeasureString("术前", drawFont).Width + 2;
                        switch (colValue)
                        {
                            case "术前": stateBrush = Brushes.Blue; break;
                            case "术中": stateBrush = Brushes.Red; break;
                            case "术后": stateBrush = Brushes.GreenYellow; break;
                            case "复苏":
                            case "复苏室": stateBrush = Brushes.Yellow; break;
                        }
                        g.FillRectangle(stateBrush, new RectangleF(curntLet + startLeft, y, ExtendAppContext.Current.RowHeight / 2f, ExtendAppContext.Current.RowHeight / 2f));
                        curntLet += ExtendAppContext.Current.RowHeight / 2f;
                    }
                    curntLet += col_width;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
                Logger.Write(string.Format("绘制列:{0}出错，列宽:{1}，实际值:{2}，实际宽:{3}", errorCol, errorColWidth.ToString(), errorValue, valueWidth.ToString()));
            }
        }
        private void timerRefreshPage_Tick(object sender, EventArgs e)
        {
            //翻页
            NextPage();
        }

        private void NextPage()
        {
            //若已翻过一遍，则重新获取数据，并返回第一页
            if (CurntPageIndex == TotalPage - 1)
            {
                GetPageInfo();
            }
            else CurntPageIndex += 1;

            normalContentArea.Refresh();
            if (ExtendAppContext.Current.SeqMode)
            {
                seqContentArea.Refresh();
            }
        }

        private void screenPnlLabel_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = screenPnlLabel.ClientRectangle;
            float str_height = e.Graphics.MeasureString("我屮艸芔茻", LabelFont).Height;
            e.Graphics.DrawString(ExtendAppContext.Current.ScreenLabel, LabelFont, Brushes.White, 5, screenPnlLabel.Height - str_height);
        }

        private void screenPnlTime_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = screenPnlTime.ClientRectangle;
            float str_height = e.Graphics.MeasureString("我屮艸芔茻", DateTimeFont).Height;
            float start_x = rect.Right - e.Graphics.MeasureString(curnt_time, DateTimeFont).Width;
            float start_y = (screenPnlTime.Height - str_height) / 2 - 5;
            if (start_y <= 0) start_y = 2;
            e.Graphics.DrawString(curnt_time, DateTimeFont, Brushes.Black, start_x, start_y);
        }

        private void screenBottomPnl_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = screenBottomPnl.ClientRectangle;
            e.Graphics.DrawString(curntMsg, MsgFont, Brushes.White, msgCurntX, msgCurntY);
        }


        private void msgTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                //显示的字数长度
                int length = (int)((msgStartX - msgCurntX) / (msgStep * 4));

                if (ExtendAppContext.Current.StaticMsgList == null)
                {
                    ExtendAppContext.Current.StaticMsgList = new List<string>();
                    ExtendAppContext.Current.StaticMsgList.Add("暂无公告信息。");
                }
                string msg = "";
                //非紧急公告，即静态公告
                if (!isEmgrcMsg)
                {
                    if (msgIndex == ExtendAppContext.Current.StaticMsgList.Count)
                    {
                        msgIndex = 0;
                        msgCurntX = msgStartX;
                    }
                    msg = ExtendAppContext.Current.StaticMsgList[msgIndex];
                    //修正起始位置偏移的问题
                    while ((length <= msg.Length) &&
                    (this.CreateGraphics().MeasureString(msg.Substring(0, length), MsgFont).Width < (msgStartX - msgCurntX)))
                    {
                        length++;
                    }
                    if (length > ExtendAppContext.Current.StaticMsgList[msgIndex].Length)
                        length = ExtendAppContext.Current.StaticMsgList[msgIndex].Length;
                    //截取需要显示的字符串
                    curntMsg = ExtendAppContext.Current.StaticMsgList[msgIndex].Substring(0, length);
                }
                else
                {
                    //修正起始位置偏移的问题
                    while ((length <= noticeMsg.Length) &&
                    (this.CreateGraphics().MeasureString(noticeMsg.Substring(0, length), MsgFont).Width < (msgStartX - msgCurntX)))
                    {
                        length++;
                    }
                    if (length > noticeMsg.Length)
                        length = noticeMsg.Length;
                    //截取需要显示的字符串
                    curntMsg = noticeMsg.Substring(0, length);
                }
                //计算需要显示的字符长度
                int msgLength = (int)this.CreateGraphics().MeasureString(curntMsg, MsgFont).Width;
                if (msgCurntX + msgLength > 0)
                {
                    screenBottomPnl.Refresh();
                    msgCurntX -= msgStep;
                }
                //转完一圈，重新获取公告信息
                if (msgCurntX + msgLength <= 0)
                {
                    //msgTimer.Stop();
                    if (!isEmgrcMsg)
                    {
                        //重新获取静态播报信息列表
                        QueryParams queryParams = new QueryParams();
                        queryParams.AddQueryDefines("ScreenNo", OperationEnum.Equal, ExtendAppContext.Current.CurntScreenNo);
                        DataTable staticMsgTable = DataOperator.HttpWebApi<DataResult>(ApiUrlEnum.GetValidMsgData, queryParams).ToDataTable();
                        List<string> staticListMsg = new List<string>();
                        if (staticMsgTable != null && staticMsgTable.Rows.Count > 0)
                        {
                            foreach (DataRow row in staticMsgTable.Rows)
                            {
                                if (!row.IsNull("MSG_CONTENT") && !string.IsNullOrEmpty(row["MSG_CONTENT"].ToString()))
                                    staticListMsg.Add(row["MSG_CONTENT"].ToString());
                            }
                            ExtendAppContext.Current.StaticMsgList = staticListMsg;
                        }
                        msgIndex++;
                    }
                    //Dictionary<string, string> noticeMsgDict = GetMsgNoticInfo();
                    if (noticeMsgDict.Count > 0 && ExtendAppContext.Current.IsBroadCast)
                    {
                        isEmgrcMsg = true;
                        foreach (KeyValuePair<string, string> kvp in noticeMsgDict)
                        {
                            string[] Info_Count = kvp.Value.Split(',');//通告信息，播报次数
                            string msgID = kvp.Key;
                            noticeMsg = Info_Count[0];
                            int count = Convert.ToInt32(Info_Count[1]);
                            SpFlags = DotNetSpeech.SpeechVoiceSpeakFlags.SVSFlagsAsync;
                            Voice = new SpVoice();
                            Voice.Rate = -4;
                            Voice.Speak(noticeMsg, SpFlags);
                            //Voice.WaitUntilDone(System.Threading.Timeout.Infinite);
                            //可播报次数-1
                            count -= 1;
                            //更新剩余可播报次数
                            UpdateMsgDataTable(msgID, count);
                            if (count == 0)
                                noticeMsgDict.Remove(msgID);
                            else
                                noticeMsgDict[msgID] = noticeMsg + "," + count;
                            // noticeMsgDict.Add(msgID, noticeMsg + "," + count);
                            break;//一次只播一条
                        }
                    }
                    else isEmgrcMsg = false;
                    msgCurntX = msgStartX;
                    //msgTimer.Start();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        private Dictionary<string, string> GetMsgNoticInfo()
        {
            Dictionary<string, string> msg_dict = new Dictionary<string, string>();
            try
            {
                QueryParams queryParams = new QueryParams();
                queryParams.AddQueryDefines("OperDept", ExtendAppContext.Current.OperDeptCode);
                queryParams.AddQueryDefines("Type", 1);
                DataTable NoticMsgTable = DataOperator.HttpWebApi<DataResult>(ApiUrlEnum.GetNoticeMsgData, queryParams).ToDataTable();

                if (NoticMsgTable.Rows.Count > 0)
                {
                    foreach (DataRow dr in NoticMsgTable.Rows)
                    {
                        if (!msg_dict.ContainsKey(dr["ID"].ToString()))
                        {
                            msg_dict.Add(dr["ID"].ToString(), dr["MSG"].ToString() + "," + dr["COUNTS"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
            return msg_dict;
        }

        private int UpdateMsgDataTable(string id, int count)
        {
            int ret = -1;
            try
            {
                QueryParams queryParams = new QueryParams();
                queryParams.AddQueryDefines("ID", id);
                queryParams.AddQueryDefines("COUNTS", count);
                ret = DataOperator.HttpWebApi<int>(ApiUrlEnum.UpdateNoticeMsgData, queryParams);
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
            return ret;
        }

        private void normalPnlTop_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = normalPnlTop.ClientRectangle;
            Font drawFont = new System.Drawing.Font("微软雅黑", ExtendAppContext.Current.ContentFontSize);
            float str_height = e.Graphics.MeasureString("我屮艸芔茻", drawFont).Height;
            float col_height = ExtendAppContext.Current.RowHeight;
            float y = (col_height - str_height) / 2;
            float x = 0;
            string drawStr = "";

            drawStr = finishStr + "/" + totalStr;

            x = rect.Right - e.Graphics.MeasureString(drawStr, drawFont).Width;
            e.Graphics.DrawString(drawStr, drawFont, Brushes.White, x, y);
        }
    }
}
