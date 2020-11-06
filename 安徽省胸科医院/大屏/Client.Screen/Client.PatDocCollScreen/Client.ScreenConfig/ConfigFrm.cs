
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using MedicalSystem.MedScreen.Controls;
using MedicalSystem.MedScreen.Common;
using MedicalSystem.AnesIcuQuery.Models.Tables;
using MedicalSystem.AnesIcuQuery.Models;
using MedicalSystem.AnesIcuQuery.Network;
using MedicalSystem.MedScreen.Network;

namespace MedicalSystem.MedScreen.Client.ScreenConfig
{
    public partial class ConfigFrm : DevExpress.XtraEditors.XtraForm
    {
        #region 构造函数
        public ConfigFrm()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            if (this.xtraTabControl.SelectedTabPage == xtraTabPageScreenSet)
            {
                RefreshScreenDict();
                pnlTop.Visible = false;
                btnAdd.Visible = true;
            }
            else pnlTop.Visible = true;
            screenCtrContainer.ScreenSelectChanged += screenCtrContainer_ScreenSelectChanged;
        }
        #endregion

        #region 变量
        /// <summary>
        /// 枚举编辑模式，无、增、删、改
        /// </summary>
        enum EditMode
        {
            None = 0,
            Add = 1,
            Modify = 2,
            Delete = 3,
            Cancel = 4,
        }
        //当前编辑模式
        EditMode curntMode = EditMode.None;

        /// <summary>
        /// 大屏字典表
        /// </summary>
        private DataTable screenDictDT = null;
        /// <summary>
        /// 当前选中的大屏对象，
        /// 包含大屏编号、标签、类型、分辨率
        /// </summary>
        private ScreenDictDT _curntScreen = null;
        /// <summary>
        /// 当前大屏的常规配置表
        /// </summary>
        private DataTable screenConfigDT = null;

        /// <summary>
        /// 大屏字段参照字典
        /// </summary>
        Dictionary<string, string> fieldsDict = new Dictionary<string, string>();
        /// <summary>
        /// 大屏视图字段列表
        /// </summary>
        List<string> colsList = new List<string>();
        /// <summary>
        /// 已分配的显示字段
        /// </summary>
        DataTable fieldData = null;
        /// <summary>
        /// 大屏通告信息
        /// </summary>
        DataTable msgData = null;

        #endregion

        #region 自定义函数

        /// <summary>
        /// 刷新大屏配置Tab页右侧的大屏详细信息
        /// </summary>
        private void RefreshRightScreenDetailInfo()
        {
            //选中大屏组件的编辑状态
            if (_curntScreen != null)
            {
                pnlEditScreen.Enabled = true;
                txtScreenNo.Text = _curntScreen.SCREEN_NO;
                txtScreenLabel.Text = _curntScreen.SCREEN_LABEL;
                cmbScreenType.SelectedItem = _curntScreen.SCREEN_TYPE;
                chkFullScreen.Checked = _curntScreen.FULL_SCREEN == 1 ? true : false;

                txtWidth.Text = _curntScreen.SCREEN_WIDTH.ToString();
                txtHeight.Text = _curntScreen.SCREEN_HEIGHT.ToString();
            }
        }

        /// <summary>
        /// 取消选中，清空右侧编辑栏的内容
        /// </summary>
        private void ClearRightScreenDetailInfo()
        {
            _curntScreen = null;
            screenCtrContainer.SelectedScreen = null;
            txtScreenNo.Text = "";
            txtScreenLabel.Text = "";
            cmbScreenType.SelectedIndex = -1;
            chkFullScreen.Checked = false;

            txtWidth.Text = "";
            txtHeight.Text = "";
        }

        /// <summary>
        /// 切换大屏编号后，刷新对应的Tab页的数据
        /// </summary>
        private void RefreshXtraTableData()
        {
            if (cmbScreenNo.SelectedIndex == -1) return;
            //常规设置
            if (xtraTabControl.SelectedTabPage == xtraTabPageNormal)
            {
                try
                {
                    RefreshNormalSetting();
                    btnSave.Visible = true;
                    btnCancel.Visible = true;
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex);
                }
            }
            //显示内容设置
            else if (xtraTabControl.SelectedTabPage == xtraTabPageField)
            {
                try
                {
                    GetFieldListData();
                    RefreshFieldSetting();
                    CalculateFieldPercent();
                    if (lblScreenType.Text.Equals("手术排班"))
                        SEQ_SHOW.Visible = true;
                    else SEQ_SHOW.Visible = false;
                    btnSave.Visible = true;
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex);
                }
            }
            //公告信息设置
            else if (xtraTabControl.SelectedTabPage == xtraTabPageMsg)
            {
                try
                {
                    RefreshMsgData();
                    btnSave.Visible = true;
                    btnAdd.Visible = true;
                    btnDlt.Visible = gridViewMsg.FocusedRowHandle > -1;
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex);

                }
            }
        }
        /// <summary>
        /// 刷新顶部显示的信息
        /// </summary>
        private void RefreshTopPnlData()
        {
            if (cmbScreenNo.SelectedIndex == -1)
            {
                cmbScreenNo.EditValue = null;
                lblScreenType.Text = "请选择大屏编号";
                lblScreenLabel.Text = "请选择大屏编号";
                SetTabPageVisible(false);
                return;
            }
            try
            {
                QueryParams queryParams = new QueryParams();
                queryParams.AddQueryDefines("ScreenNo", OperationEnum.Equal, cmbScreenNo.SelectedItem.ToString());
                DataTable screenDictData = DataOperator.HttpWebApi<DataResult>(ApiUrlEnum.GetScreenDict, queryParams).ToDataTable();
                if (screenDictData != null && screenDictData.Rows.Count > 0)
                {
                    lblScreenType.Text = screenDictData.Rows[0]["SCREEN_TYPE"].ToString();
                    lblScreenLabel.Text = screenDictData.Rows[0]["SCREEN_LABEL"].ToString();
                    SetTabPageVisible(true);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);

            }
        }

        private void SetTabPageVisible(bool isVisible)
        {
            ToolBarLayoutPanel.Visible = isVisible;
            pnlContent.Visible = isVisible;
            pnlMsgInfo.Visible = isVisible;
        }
        /// <summary>
        /// 设置提示信息
        /// </summary>
        private void InitialToolTips()
        {
            toolTip.SetToolTip(cmbScreenNo, "设置当前的大屏类型,\r\n手术排班大屏或家属等待大屏");
            toolTip.SetToolTip(grpFilterSet, "设置筛选大屏显示的手术信息的筛选项");
            toolTip.SetToolTip(txtOperDeptCode, "设置手术科室代码筛选大屏显示的手术信息");
            toolTip.SetToolTip(txtOperRooms, "设置手术间号来筛选大屏显示的手术信息,\r\n默认不筛选请填*,多手术间筛选用逗号分隔");
            toolTip.SetToolTip(grpResolutionSet, "设置大屏显示的分辨率");
            toolTip.SetToolTip(chkFullScreen, "设置大屏是否全屏显示");
            toolTip.SetToolTip(txtWidth, "设置大屏的显示宽度");
            toolTip.SetToolTip(txtHeight, "设置大屏的显示高度");
            toolTip.SetToolTip(grpRefreshSet, "设置大屏的刷新方式");
            toolTip.SetToolTip(numRefreshTime, "设置大屏的翻页时间间隔，\r\n最少10秒，最大3600秒");
            toolTip.SetToolTip(grpLayoutSet, "设置大屏的显示布局");
            toolTip.SetToolTip(numPerPageRows, "设置大屏每页的显示行数，\r\n最少5行，最大50行");
            toolTip.SetToolTip(grpBroadcastSet, "设置是否进行语音播报");
            toolTip.SetToolTip(grpShowStyle, "设置手术排班大屏的展现方式,\r\n手术信息较多的建议采用接台形式展现");
            toolTip.SetToolTip(grpVideoSet, "设置家属等待大屏是否显示视频");
            toolTip.SetToolTip(grpPrivateSet, "设置家属等待大屏是否隐藏患者隐私,\r\n进行隐私保护的患者名字打*");
            toolTip.SetToolTip(grpSkinSet, "设置大屏的皮肤,\r\n不同的皮肤下字体和背景图的搭配亦不同");
            toolTip.SetToolTip(txtSkin, "设置大屏的皮肤");
            toolTip.SetToolTip(btnAddToShow, "新增为显示内容");
            toolTip.SetToolTip(btnDleNoShow, "从显示内容中移除");
            toolTip.SetToolTip(btnAdd, "新增公告内容");
            toolTip.SetToolTip(btnDlt, "删除公告内容");
            toolTip.SetToolTip(btnAutoFilter, "自适应百分比");
        }

        /// <summary>
        /// 初始化下拉框
        /// </summary>
        private void InitialComBox()
        {
            cmbScreenNo.Properties.Items.Clear();
            //cmbScreenType.Items.Clear();
            ////初始化大屏类型下拉框
            //foreach (string screenType in ScreenTypeHelper.ScreenTypeNameList)
            //{
            //    cmbScreenType.Items.Add(screenType);
            //}
            //初始化大屏编号下拉框
            if (screenDictDT != null)
            {
                foreach (DataRow dr in screenDictDT.Rows)
                {
                    cmbScreenNo.Properties.Items.Add(dr["SCREEN_NO"].ToString());
                }
            }
        }

        /// <summary>
        /// 初始化大屏默认设置项
        /// </summary>
        private void InitialDefaultNormalSetting()
        {
            if (lblScreenType.Text.Equals("家属等待"))
            {
                txtOperDeptCode.Text = "1020800";
                txtOperRooms.Text = "*";
                numRefreshTime.Value = 30;
                numPerPageRows.Value = 12;
                radVoiceYes.Checked = true;
                radShowSimp.Checked = true;
                chkShowSpec.Checked = false;
                radTvYes.Checked = true;
                radPrivateYes.Checked = true;
                txtSkin.Text = "默认";
            }
            else if (lblScreenType.Text.Equals("手术排班"))
            {
                txtOperDeptCode.Text = "1020800";
                txtOperRooms.Text = "*";
                numRefreshTime.Value = 30;
                numPerPageRows.Value = 18;
                radVoiceYes.Checked = true;
                radShowSimp.Checked = true;
                chkShowSpec.Checked = false;
                radTvNo.Checked = true;
                radPrivateNo.Checked = true;
                txtSkin.Text = "默认";
            }
        }

        /// <summary>
        /// 刷新常规设置
        /// </summary>
        private void RefreshNormalSetting()
        {
            try
            {
                QueryParams queryParams = new QueryParams();
                queryParams.AddQueryDefines("ScreenNo", OperationEnum.Equal, cmbScreenNo.SelectedItem.ToString());
                screenConfigDT = DataOperator.HttpWebApi<DataResult>(ApiUrlEnum.GetScreenConfig, queryParams).ToDataTable();
                if (screenConfigDT.Rows.Count == 0)
                {
                    InitialDefaultNormalSetting();
                    AutoClosedMsgBox.Show("未获取到配置信息，请点击【保存】按钮，保存系统的默认配置。", "大屏配置提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);

            }
            //家属等待
            if (lblScreenType.Text.Equals(ScreenTypeHelper.GetScreenNameByType(ScreenType.FamilyWaitScreen)))
            {
                grpShowStyle.Enabled = false;
                grpShowSpec.Enabled = false;
                grpVideoSet.Enabled = true;
                grpPrivateSet.Enabled = true;
            }
            //手术排班
            else if (lblScreenType.Text.Equals(ScreenTypeHelper.GetScreenNameByType(ScreenType.OperScheduleScreen)))
            {
                grpShowStyle.Enabled = true;
                grpShowSpec.Enabled = true;
                grpVideoSet.Enabled = false;
                grpPrivateSet.Enabled = false;
            }
            if (screenConfigDT != null && screenConfigDT.Rows.Count > 0)
            {
                DataRow dr = screenConfigDT.Rows[0];
                txtOperDeptCode.Text = dr["OPER_DEPT_CODE"].ToString();
                txtOperRooms.Text = dr["OPERROOM_FILTER"].ToString();
                numRefreshTime.Value = decimal.Parse(dr["REFRESH_TIME"].ToString());
                numPerPageRows.Value = decimal.Parse(dr["ROW_COUNT"].ToString());
                if (decimal.Parse(dr["VOICE_BROADCAST"].ToString()) == 1)
                {
                    radVoiceYes.Checked = true;
                }
                else radVoiceNo.Checked = true;
                if (dr["SHOW_MODE"].ToString().Equals("Simple"))
                {
                    radShowSimp.Checked = true;
                }
                else radShowSeq.Checked = true;
                chkShowSpec.Checked = decimal.Parse(dr["MARK_SPEC"].ToString()) == 1;
                if (decimal.Parse(dr["SHOW_TV"].ToString()) == 1)
                {
                    radTvYes.Checked = true;
                }
                else radTvNo.Checked = true;
                if (decimal.Parse(dr["PROTECT_PRIVATE"].ToString()) == 1)
                {
                    radPrivateYes.Checked = true;
                }
                else radPrivateNo.Checked = true;
                txtSkin.Text = dr["SKIN"].ToString();
            }
            else
            {
            }
        }

        /// <summary>
        /// 刷新显示内容配置界面
        /// </summary>
        private void RefreshFieldSetting()
        {
            try
            {
                QueryParams queryParams = new QueryParams();
                queryParams.AddQueryDefines("ScreenNo", cmbScreenNo.SelectedItem.ToString());

                //获取已分配的列表
                fieldData = DataOperator.HttpWebApi<DataResult>(ApiUrlEnum.GetScreenFieldsData, queryParams).ToDataTable();
                gridControlField.DataSource = fieldData;
                RefreshUnAllocateList();
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);

            }
        }

        private void RefreshUnAllocateList()
        {
            List<string> allocatedList = new List<string>();
            foreach (DataRow dr in fieldData.Rows)
            {
                allocatedList.Add(dr["FIELD_NAME"].ToString());
            }
            listBoxUnAllocate.Items.Clear();
            foreach (string key in fieldsDict.Keys)
            {
                if (!allocatedList.Contains(key))
                    listBoxUnAllocate.Items.Add(fieldsDict[key]);
            }
        }
        /// <summary>
        /// 获取可选字段列表
        /// </summary>
        private void GetFieldListData()
        {
            try
            {
                QueryParams queryParams = new QueryParams();
                //读取xml文档，获取字段参照字典
                fieldsDict = DataOperator.HttpWebApi<Dictionary<string, string>>(ApiUrlEnum.GetAllFields, queryParams);
                //获取大屏视图中字段列表
                colsList = DataOperator.HttpWebApi<List<string>>(ApiUrlEnum.GetViewColumnList, queryParams);
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);

            }
            //将无法对照的字段去掉
            Dictionary<string, string> tempDict = new Dictionary<string, string>();
            foreach (string key in fieldsDict.Keys)
            {
                if (colsList.Contains(key))
                    tempDict.Add(key, fieldsDict[key]);
            }
            fieldsDict = tempDict;
        }

        /// <summary>
        /// 获取语音播报信息
        /// </summary>
        private void RefreshMsgData()
        {
            try
            {
                QueryParams queryParams = new QueryParams();
                queryParams.AddQueryDefines("ScreenNo", cmbScreenNo.SelectedItem.ToString());
                //获取大屏通告信息
                msgData = DataOperator.HttpWebApi<DataResult>(ApiUrlEnum.GetMsgData, queryParams).ToDataTable();
                gridControlMsg.DataSource = msgData;
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        /// <summary>
        /// 刷新大屏字典
        /// </summary>
        private void RefreshScreenDict()
        {
            try
            {
                QueryParams queryParams = new QueryParams();
                screenDictDT = DataOperator.HttpWebApi<DataResult>(ApiUrlEnum.GetScreenDict, queryParams).ToDataTable();
                if (screenDictDT != null && screenDictDT.Rows.Count > 0)
                {
                    this.screenCtrContainer.ScreenDictDT = screenDictDT;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);

            }
            finally
            {
            }
        }

        /// <summary>
        /// 获取大屏字典表参数值
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GentScreenDictData()
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret.Add("SCREEN_NO", txtScreenNo.Text);
            ret.Add("SCREEN_TYPE", cmbScreenType.SelectedItem.ToString());
            ret.Add("SCREEN_LABEL", txtScreenLabel.Text);
            ret.Add("FULL_SCREEN", chkFullScreen.Checked ? "1" : "0");
            ret.Add("SCREEN_WIDTH", txtWidth.Text);
            ret.Add("SCREEN_HEIGHT", txtHeight.Text);
            return ret;
        }
        /// <summary>
        /// 获取大屏常规设置参数
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GentScreenConfigData()
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret.Add("SCREEN_NO", cmbScreenNo.SelectedItem.ToString());
            ret.Add("SCREEN_TYPE", lblScreenType.Text);
            ret.Add("OPER_DEPT_CODE", txtOperDeptCode.Text.Trim());
            ret.Add("OPERROOM_FILTER", txtOperRooms.Text.Trim());
            ret.Add("REFRESH_TIME", numRefreshTime.Value.ToString());
            ret.Add("ROW_COUNT", numPerPageRows.Value.ToString());
            ret.Add("VOICE_BROADCAST", radVoiceYes.Checked ? "1" : "0");
            ret.Add("SHOW_MODE", radShowSeq.Checked ? "Sequence" : "Simple");
            ret.Add("MARK_SPEC", chkShowSpec.Checked ? "1" : "0");
            ret.Add("SHOW_TV", radTvYes.Checked ? "1" : "0");
            ret.Add("PROTECT_PRIVATE", radPrivateYes.Checked ? "1" : "0");
            ret.Add("SKIN", txtSkin.Text.Trim());
            return ret;
        }

        /// <summary>
        /// 获取大屏显示字段设置参数
        /// </summary>
        /// <param name="updateRow"></param>
        /// <returns></returns>
        private Dictionary<string, string> GentScreenFieldData(DataRow updateRow)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret.Add("SCREEN_NO", updateRow["SCREEN_NO"].ToString());
            ret.Add("ORDER_NO", updateRow["ORDER_NO"].ToString());
            ret.Add("FIELD_NAME", updateRow["FIELD_NAME"].ToString());
            ret.Add("CAPTION", updateRow["CAPTION"].ToString());
            ret.Add("COL_PERCENT", updateRow["COL_PERCENT"].ToString());
            ret.Add("SEQ_SHOW", updateRow["SEQ_SHOW"].ToString());
            return ret;
        }

        /// <summary>
        /// 获取大屏通告信息更新参数列表
        /// </summary>
        /// <param name="updateRow"></param>
        /// <returns></returns>
        private Dictionary<string, string> GentScreenMsgData(DataRow updateRow)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret.Add("SCREEN_NO", updateRow["SCREEN_NO"].ToString());
            ret.Add("MSG_ID", updateRow["MSG_ID"].ToString());
            ret.Add("SEQ_NO", updateRow["SEQ_NO"].ToString());
            ret.Add("MSG_CONTENT", updateRow["MSG_CONTENT"].ToString());
            ret.Add("IS_USE", updateRow["IS_USE"].ToString());
            return ret;
        }
        /// <summary>
        /// 保存前检查数据完整性
        /// </summary>
        /// <returns></returns>
        private bool CheckBeforeSave()
        {
            bool ret = false;
            //大屏配置
            if (xtraTabControl.SelectedTabPage == xtraTabPageScreenSet)
            {
                if (!string.IsNullOrEmpty(txtScreenNo.Text.Trim()) && !string.IsNullOrEmpty(txtScreenLabel.Text.Trim())
                    && cmbScreenType.SelectedIndex != -1 && (chkFullScreen.Checked || (!string.IsNullOrEmpty(txtHeight.Text.Trim()) && !string.IsNullOrEmpty(txtWidth.Text.Trim()))))
                {
                    ret = true;
                }
                else { ret = false; }
            }
            //常规设置
            else if (xtraTabControl.SelectedTabPage == xtraTabPageNormal)
            {
                if (!string.IsNullOrEmpty(txtOperDeptCode.Text.Trim()) && !string.IsNullOrEmpty(txtOperRooms.Text.Trim()))
                {
                    ret = true;
                }
                else { ret = false; }
            }
            //显示内容
            else if (xtraTabControl.SelectedTabPage == xtraTabPageField)
            {
                if (gridViewField.RowCount > 0)
                {
                    ret = true;
                    foreach (DataRow dr in fieldData.Rows)
                    {
                        if (dr.IsNull("CAPTION") || string.IsNullOrEmpty(dr["CAPTION"].ToString())
                            || dr.IsNull("COL_PERCENT") || string.IsNullOrEmpty(dr["COL_PERCENT"].ToString())
                            || decimal.Parse(dr["COL_PERCENT"].ToString()) <= 0)
                        {
                            ret = false; break;
                        }
                    }
                    int totalPer = CalculateFieldPercent();
                    if (totalPer < 100)
                    {
                        if (AutoClosedMsgBox.Show("已分配的百分比不足100%，是否继续保存？", "大屏显示内容保存提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        { }
                        else { ret = false; return ret; }
                    }
                    else if (totalPer > 100)
                    {
                        AutoClosedMsgBox.Show("已分配的百分比超出100%，请重新配置后再保存。", "大屏显示内容保存提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ret = false;
                        return ret;
                    }
                }
                else { ret = false; }
            }
            //公告信息
            else if (xtraTabControl.SelectedTabPage == xtraTabPageMsg)
            {
                if (gridViewMsg.RowCount > 0)
                {
                    ret = true;
                    foreach (DataRow dr in msgData.Rows)
                    {
                        if (dr.IsNull("MSG_ID") || string.IsNullOrEmpty(dr["MSG_ID"].ToString())
                            || dr.IsNull("MSG_CONTENT") || string.IsNullOrEmpty(dr["MSG_CONTENT"].ToString()))
                        {
                            ret = false; break;
                        }
                    }
                }
                else { ret = false; }
            }
            if (!ret)
                AutoClosedMsgBox.Show("请输入完整后再保存。", "大屏配置提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return ret;
        }

        /// <summary>
        /// 各Tab页对新增按钮的响应
        /// </summary>
        private void SetAddBehaviour()
        {
            //大屏字典设置
            if (xtraTabControl.SelectedTabPage == xtraTabPageScreenSet)
            {
                ClearRightScreenDetailInfo();
                pnlEditScreen.Enabled = true;
                int screenNo = 0;
                foreach (DataRow dr in screenDictDT.Rows)
                {
                    if (screenNo < int.Parse(dr["SCREEN_NO"].ToString()))
                    {
                        screenNo = int.Parse(dr["SCREEN_NO"].ToString());
                    }
                }
                screenNo++;
                txtScreenNo.Text = screenNo.ToString();
                cmbScreenType.SelectedIndex = 0;
                btnAdd.Visible = false;
                btnCancel.Visible = true;
                btnSave.Visible = true;
            }
            //大屏公告信息设置
            if (xtraTabControl.SelectedTabPage == xtraTabPageMsg)
            {
                DataRow newRow = msgData.NewRow();
                decimal num = 0;
                foreach (DataRow dr in msgData.Rows)
                {
                    if (num < decimal.Parse(dr["SEQ_NO"].ToString()))
                    {
                        num = decimal.Parse(dr["SEQ_NO"].ToString());
                    }
                }
                num++;
                newRow["SCREEN_NO"] = cmbScreenNo.SelectedItem.ToString();
                newRow["MSG_ID"] = cmbScreenNo.SelectedItem.ToString() + "-" + num.ToString();
                newRow["SEQ_NO"] = num;
                newRow["IS_USE"] = 1;
                msgData.Rows.Add(newRow);
                gridControlMsg.DataSource = msgData;
                if (gridViewMsg.RowCount > 0)
                    btnDlt.Visible = true;
            }
        }

        /// <summary>
        /// 各Tab页对删除按钮的响应
        /// </summary>
        private void SetDltBehaviour()
        {
            if (xtraTabControl.SelectedTabPage == xtraTabPageScreenSet)
            {
                if (_curntScreen == null) return;
                try
                {
                    int ret = DeleteScreenDictInfo();
                    if (ret > 0)
                    {
                        btnDlt.Visible = false;
                        btnSave.Visible = false;
                        btnAdd.Visible = true;
                        curntMode = EditMode.None;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex);

                }
            }
            else if (xtraTabControl.SelectedTabPage == xtraTabPageMsg)
            {
                if (gridViewMsg.FocusedRowHandle == -1) return;
                try
                {
                    DataRow focusRow = gridViewMsg.GetFocusedDataRow();
                    msgData.Rows.Remove(focusRow);
                    int index = 1;
                    foreach (DataRow dr in msgData.Rows)
                    {
                        dr["SEQ_NO"] = index++;
                    }
                    msgData.AcceptChanges();

                    int result = UpdateScreenMsg();
                    if (result > 0)
                    {
                        AutoClosedMsgBox.Show("数据删除成功。", "大屏配置提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshMsgData();
                        curntMode = EditMode.None;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex);

                }
            }
        }

        /// <summary>
        /// 各Tab页对保存按钮的响应
        /// </summary>
        private void SetSaveBehaviour()
        {
            int result = -1;
            //大屏字典维护
            if (xtraTabControl.SelectedTabPage == xtraTabPageScreenSet)
            {
                try
                {
                    switch (curntMode)
                    {
                        case EditMode.Add:
                            result = AddScreenDictInfo(); break;
                        case EditMode.Modify:
                            result = UpdateScreenDictInfo(); break;
                    }
                    if (result > 0)
                    {
                        AutoClosedMsgBox.Show("数据保存成功。", "大屏配置提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSave.Visible = false;
                        btnCancel.Visible = false;
                        btnDlt.Visible = false;
                        btnAdd.Visible = true;
                        curntMode = EditMode.None;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex);

                }
            }
            //常规设置
            else if (xtraTabControl.SelectedTabPage == xtraTabPageNormal)
            {
                curntMode = EditMode.Modify;
                if (!CheckBeforeSave())
                {
                    result = 0;
                    return;
                }
                try
                {
                    result = UpdateScreenNormalConfig();
                    if (result > 0)
                    {
                        AutoClosedMsgBox.Show("数据保存成功。", "大屏配置提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        curntMode = EditMode.None;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex);

                }
            }
            //显示内容设置
            else if (xtraTabControl.SelectedTabPage == xtraTabPageField)
            {
                if (!CheckBeforeSave())
                {
                    result = 0;
                    return;
                }
                try
                {
                    result = UpdateScreenFieldsSet();
                    if (result > 0)
                    {
                        AutoClosedMsgBox.Show("数据保存成功。", "大屏配置提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshFieldSetting();
                        curntMode = EditMode.None;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex);

                }
            }
            //公告信息设置
            else if (xtraTabControl.SelectedTabPage == xtraTabPageMsg)
            {
                if (!CheckBeforeSave())
                {
                    result = 0;
                    return;
                }
                try
                {
                    result = UpdateScreenMsg();
                    if (result > 0)
                    {
                        AutoClosedMsgBox.Show("数据保存成功。", "大屏配置提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshMsgData();
                        curntMode = EditMode.None;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex);

                }
            }

        }

        /// <summary>
        /// 各Tab页对取消按钮的响应
        /// </summary>
        private void SetCancelBehaviour()
        {
            if (xtraTabControl.SelectedTabPage == xtraTabPageScreenSet)
            {
                CancelScreenDictEdit();
                btnCancel.Visible = false;
                btnSave.Visible = false;
                btnDlt.Visible = false;
                btnAdd.Visible = true;
                curntMode = EditMode.None;
            }
            else if (xtraTabControl.SelectedTabPage == xtraTabPageNormal)
            {
                RefreshNormalSetting();
                curntMode = EditMode.None;
            }
        }
        #region 大屏字典的增删改
        /// <summary>
        /// 新增大屏信息
        /// </summary>
        private int AddScreenDictInfo()
        {
            int ret = -1;
            if (!CheckBeforeSave())
            {
                ret = 0;
                return ret;
            }
            try
            {
                Dictionary<string, string> resultData = GentScreenDictData();
                QueryParams queryParam = new QueryParams();
                foreach (string key in resultData.Keys)
                {
                    queryParam.AddQueryDefines(key, resultData[key]);
                }
                ret = DataOperator.HttpWebApi<int>(ApiUrlEnum.InsertScreenDict, queryParam);
                ClearRightScreenDetailInfo();
                pnlEditScreen.Enabled = false;
                RefreshScreenDict();
                screenCtrContainer.RefreshControls();
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);

            }
            return ret;
        }

        /// <summary>
        /// 修改大屏信息
        /// </summary>
        private int UpdateScreenDictInfo()
        {
            int ret = -1;
            if (!CheckBeforeSave())
            {
                ret = 0;
                return ret;
            }
            try
            {
                //更新大屏字典表
                Dictionary<string, string> resultData = GentScreenDictData();
                QueryParams queryParam = new QueryParams();
                foreach (string key in resultData.Keys)
                {
                    queryParam.AddQueryDefines(key, resultData[key]);
                }
                ret = DataOperator.HttpWebApi<int>(ApiUrlEnum.UpdateScreenDict, queryParam);
                ClearRightScreenDetailInfo();
                pnlEditScreen.Enabled = false;
                RefreshScreenDict();
                screenCtrContainer.RefreshControls();
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);

            }
            return ret;
        }

        /// <summary>
        /// 删除大屏信息
        /// </summary>
        private int DeleteScreenDictInfo()
        {
            int ret = -1;
            if (_curntScreen == null)
            {
                ret = 0;
                AutoClosedMsgBox.Show("请先选中一个大屏组件后再点击删除按钮。", "大屏配置提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ret;
            }
            try
            {
                QueryParams queryParam = new QueryParams();
                queryParam.AddQueryDefines("SCREEN_NO", _curntScreen.SCREEN_NO);
                ret = DataOperator.HttpWebApi<int>(ApiUrlEnum.DeleteScreenDict, queryParam);
                ClearRightScreenDetailInfo();
                pnlEditScreen.Enabled = false;
                RefreshScreenDict();
                screenCtrContainer.RefreshControls();
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);

            }
            return ret;
        }

        private void CancelScreenDictEdit()
        {
            screenCtrContainer.ClearSelectScreen();
            _curntScreen = null;
            ClearRightScreenDetailInfo();
            pnlEditScreen.Enabled = false;
        }
        #endregion

        #region 大屏常规设置
        /// <summary>
        /// 修改大屏常规设置
        /// </summary>
        private int UpdateScreenNormalConfig()
        {
            int ret = -1;
            Dictionary<string, string> resultData = GentScreenConfigData();
            QueryParams queryParam = new QueryParams();
            foreach (string key in resultData.Keys)
            {
                queryParam.AddQueryDefines(key, resultData[key]);
            }
            //新增或修改
            if (screenConfigDT == null || screenConfigDT.Rows.Count == 0)
            {
                try
                {
                    ret = DataOperator.HttpWebApi<int>(ApiUrlEnum.InsertScreenNormalConfig, queryParam);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex);

                }
            }
            else
            {
                try
                {
                    ret = DataOperator.HttpWebApi<int>(ApiUrlEnum.UpdateScreenNormalConfig, queryParam);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex);

                }
            }
            RefreshNormalSetting();
            return ret;
        }
        #endregion

        #region 大屏显示内容设置
        /// <summary>
        /// 修改大屏显示内容设置
        /// </summary>
        private int UpdateScreenFieldsSet()
        {
            int ret = 0;
            QueryParams queryParams = new QueryParams();
            queryParams.AddQueryDefines("ScreenNo", cmbScreenNo.SelectedItem.ToString());
            //获取已分配的字段，参照表，判断更新时应该新增、修改还是删除
            DataTable refTable = DataOperator.HttpWebApi<DataResult>(ApiUrlEnum.GetScreenFieldsData, queryParams).ToDataTable();
            //首次新增
            if (refTable.Rows.Count == 0)
            {
                foreach (DataRow dr in fieldData.Rows)
                {
                    Dictionary<string, string> resultData = GentScreenFieldData(dr);
                    queryParams = new QueryParams();
                    foreach (string key in resultData.Keys)
                    {
                        queryParams.AddQueryDefines(key, resultData[key]);
                    }
                    try
                    {
                        ret += DataOperator.HttpWebApi<int>(ApiUrlEnum.InsertScreenFields, queryParams);
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.Handle(ex);

                    }

                }
            }
            else
            {
                //删除
                foreach (DataRow dr in refTable.Rows)
                {
                    DataRow[] compRows = fieldData.Select(string.Format("SCREEN_NO = '{0}' AND FIELD_NAME = '{1}'",
                        dr["SCREEN_NO"].ToString(), dr["FIELD_NAME"].ToString()));
                    if (compRows.Length == 0)
                    {
                        Dictionary<string, string> resultData = GentScreenFieldData(dr);
                        queryParams = new QueryParams();
                        foreach (string key in resultData.Keys)
                        {
                            queryParams.AddQueryDefines(key, resultData[key]);
                        }
                        try
                        {
                            ret += DataOperator.HttpWebApi<int>(ApiUrlEnum.DeleteScreenFields, queryParams);
                        }
                        catch (Exception ex)
                        {
                            ExceptionHandler.Handle(ex);
                        }
                    }
                }
                //新增和修改
                foreach (DataRow dr in fieldData.Rows)
                {
                    DataRow[] compRows = refTable.Select(string.Format("SCREEN_NO = '{0}' AND FIELD_NAME = '{1}'",
                        dr["SCREEN_NO"].ToString(), dr["FIELD_NAME"].ToString()));
                    Dictionary<string, string> resultData = GentScreenFieldData(dr);
                    queryParams = new QueryParams();
                    foreach (string key in resultData.Keys)
                    {
                        queryParams.AddQueryDefines(key, resultData[key]);
                    }
                    //新增
                    if (compRows.Length == 0)
                    {
                        try
                        {
                            ret += DataOperator.HttpWebApi<int>(ApiUrlEnum.InsertScreenFields, queryParams);
                        }
                        catch (Exception ex)
                        {
                            ExceptionHandler.Handle(ex);
                        }
                    }
                    //修改
                    else
                    {
                        try
                        {
                            ret += DataOperator.HttpWebApi<int>(ApiUrlEnum.UpdateScreenFields, queryParams);
                        }
                        catch (Exception ex)
                        {
                            ExceptionHandler.Handle(ex);
                        }
                    }
                }
            }
            return ret;
        }
        #endregion

        #region 大屏公告信息

        /// <summary>
        /// 更新大屏通告信息
        /// </summary>
        /// <returns></returns>
        private int UpdateScreenMsg()
        {
            int ret = 0;
            QueryParams queryParams = new QueryParams();
            queryParams.AddQueryDefines("ScreenNo", cmbScreenNo.SelectedItem.ToString());
            //获取已维护的大屏公告信息，参照表，判断更新时应该新增、修改还是删除
            DataTable refTable = DataOperator.HttpWebApi<DataResult>(ApiUrlEnum.GetMsgData, queryParams).ToDataTable();
            //首次新增
            if (refTable.Rows.Count == 0)
            {
                foreach (DataRow dr in msgData.Rows)
                {
                    Dictionary<string, string> resultData = GentScreenMsgData(dr);
                    queryParams = new QueryParams();
                    foreach (string key in resultData.Keys)
                    {
                        queryParams.AddQueryDefines(key, resultData[key]);
                    }
                    try
                    {
                        ret += DataOperator.HttpWebApi<int>(ApiUrlEnum.InsertScreenMsg, queryParams);
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.Handle(ex);
                    }
                }
            }
            else
            {
                //删除
                foreach (DataRow dr in refTable.Rows)
                {
                    DataRow[] compRows = msgData.Select(string.Format("SCREEN_NO = '{0}' AND MSG_ID = '{1}'",
                        dr["SCREEN_NO"].ToString(), dr["MSG_ID"].ToString()));
                    if (compRows.Length == 0)
                    {
                        Dictionary<string, string> resultData = GentScreenMsgData(dr);
                        queryParams = new QueryParams();
                        foreach (string key in resultData.Keys)
                        {
                            queryParams.AddQueryDefines(key, resultData[key]);
                        }
                        try
                        {
                            ret += DataOperator.HttpWebApi<int>(ApiUrlEnum.DeleteScreenMsg, queryParams);
                        }
                        catch (Exception ex)
                        {
                            ExceptionHandler.Handle(ex);
                        }
                    }
                }
                //新增和修改
                foreach (DataRow dr in msgData.Rows)
                {
                    DataRow[] compRows = refTable.Select(string.Format("SCREEN_NO = '{0}' AND MSG_ID = '{1}'",
                        dr["SCREEN_NO"].ToString(), dr["MSG_ID"].ToString()));
                    Dictionary<string, string> resultData = GentScreenMsgData(dr);
                    queryParams = new QueryParams();
                    foreach (string key in resultData.Keys)
                    {
                        queryParams.AddQueryDefines(key, resultData[key]);
                    }
                    //新增
                    if (compRows.Length == 0)
                    {
                        try
                        {
                            ret += DataOperator.HttpWebApi<int>(ApiUrlEnum.InsertScreenMsg, queryParams);
                        }
                        catch (Exception ex)
                        {
                            ExceptionHandler.Handle(ex);
                        }
                    }
                    //修改
                    else
                    {
                        try
                        {
                            ret += DataOperator.HttpWebApi<int>(ApiUrlEnum.UpdateScreenMsg, queryParams);
                        }
                        catch (Exception ex)
                        {
                            ExceptionHandler.Handle(ex);
                        }
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// 计算大屏各字段已分配的百分比
        /// </summary>
        /// <returns></returns>
        private int CalculateFieldPercent()
        {
            if (fieldData.Rows.Count == 0)
            {
                lblTotalPercent.Text = string.Format("已分配{0}%", "0");
                return 0;
            }
            //同标题不重复计算
            Dictionary<string, int> refDict = new Dictionary<string, int>();
            int totalPercent = 0;
            foreach (DataRow dr in fieldData.Rows)
            {
                if (!refDict.ContainsKey(dr["CAPTION"].ToString()))
                {
                    int percent = 0;
                    if (!dr.IsNull("COL_PERCENT") && !string.IsNullOrEmpty(dr["COL_PERCENT"].ToString())
                        && int.TryParse(dr["COL_PERCENT"].ToString(), out percent))
                    {
                        totalPercent += percent;
                    }
                    refDict.Add(dr["CAPTION"].ToString(), percent);
                }
                else
                {
                    dr["COL_PERCENT"] = refDict[dr["CAPTION"].ToString()];
                    gridControlField.RefreshDataSource();
                }
            }
            lblTotalPercent.Text = string.Format("已分配{0}%", totalPercent.ToString());
            return totalPercent;
        }

        #endregion

        #endregion

        #region 事件
        /// <summary>
        /// 界面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigFrm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                InitialToolTips();
                InitialComBox();
                itemCheckEditSeq.QueryCheckStateByValue += itemCheckEdit_QueryCheckStateByValue;
                itemCheckEditUsed.QueryCheckStateByValue += itemCheckEdit_QueryCheckStateByValue;
            }
        }

        private void itemCheckEdit_QueryCheckStateByValue(object sender, DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventArgs e)
        {
            string val = "";
            if (e.Value != null)
            {
                val = e.Value.ToString();
            }
            else
            {
                val = "False";//默认为选中 
            }
            switch (val)
            {
                case "True":
                    e.CheckState = CheckState.Checked;
                    break;
                case "False":
                    e.CheckState = CheckState.Unchecked;
                    break;
                case "1":
                    goto case "True";
                case "0":
                    goto case "False";
                default:
                    e.CheckState = CheckState.Unchecked;
                    break;
            }
            e.Handled = true;
        }

        /// <summary>
        /// 新增显示字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddToShow_Click(object sender, EventArgs e)
        {
            if (listBoxUnAllocate.SelectedIndex == -1)
                return;
            int index = listBoxUnAllocate.SelectedIndex;
            foreach (string key in fieldsDict.Keys)
            {
                if (fieldsDict[key].Equals(listBoxUnAllocate.SelectedItem.ToString()))
                {
                    DataRow newRow = fieldData.NewRow();
                    newRow["SCREEN_NO"] = cmbScreenNo.SelectedItem.ToString();
                    newRow["ORDER_NO"] = fieldData.Rows.Count + 1;
                    newRow["FIELD_NAME"] = key;
                    newRow["CAPTION"] = fieldsDict[key];
                    newRow["COL_PERCENT"] = 10;
                    newRow["SEQ_SHOW"] = 0;
                    fieldData.Rows.Add(newRow);
                }
            }
            gridControlField.DataSource = fieldData;
            CalculateFieldPercent();
            RefreshUnAllocateList();
            listBoxUnAllocate.SelectedIndex = index;
            gridViewField.FocusedRowHandle = fieldData.Rows.Count - 1;
        }
        /// <summary>
        /// 删除显示字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDleNoShow_Click(object sender, EventArgs e)
        {
            if (gridViewField.FocusedRowHandle == -1)
                return;
            DataRow dr = gridViewField.GetFocusedDataRow();
            int focusIndex = gridViewField.FocusedRowHandle;
            fieldData.Rows.Remove(dr);
            int order = 1;
            foreach (DataRow row in fieldData.Rows)
            {
                row["ORDER_NO"] = order;
                order++;
            }
            fieldData.AcceptChanges();
            gridControlField.DataSource = fieldData;
            CalculateFieldPercent();
            RefreshUnAllocateList();
            gridViewField.FocusedRowHandle = focusIndex - 1;
        }

        //排序向上
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (gridViewField.FocusedRowHandle == -1 || gridViewField.FocusedRowHandle == 0) return;
            int focusIndex = gridViewField.FocusedRowHandle;
            DataRow curnt_dr = gridViewField.GetFocusedDataRow();
            DataRow rep_dr = gridViewField.GetDataRow(gridViewField.FocusedRowHandle - 1);
            curnt_dr["ORDER_NO"] = decimal.Parse(curnt_dr["ORDER_NO"].ToString()) - 1;
            rep_dr["ORDER_NO"] = decimal.Parse(rep_dr["ORDER_NO"].ToString()) + 1;
            fieldData.DefaultView.Sort = "ORDER_NO";
            fieldData = fieldData.DefaultView.ToTable();
            fieldData.AcceptChanges();
            gridControlField.DataSource = fieldData;
            gridViewField.FocusedRowHandle = focusIndex - 1;
        }
        //排序向下
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (gridViewField.FocusedRowHandle == -1 || gridViewField.FocusedRowHandle == fieldData.Rows.Count - 1) return;
            int focusIndex = gridViewField.FocusedRowHandle;
            DataRow curnt_dr = gridViewField.GetFocusedDataRow();
            DataRow rep_dr = gridViewField.GetDataRow(gridViewField.FocusedRowHandle + 1);
            curnt_dr["ORDER_NO"] = decimal.Parse(curnt_dr["ORDER_NO"].ToString()) + 1;
            rep_dr["ORDER_NO"] = decimal.Parse(rep_dr["ORDER_NO"].ToString()) - 1;
            fieldData.DefaultView.Sort = "ORDER_NO";
            fieldData = fieldData.DefaultView.ToTable();
            fieldData.AcceptChanges();
            gridControlField.DataSource = fieldData;
            gridViewField.FocusedRowHandle = focusIndex + 1;
        }
        /// <summary>
        /// 自适应大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoFilter_Click(object sender, EventArgs e)
        {
            if (fieldData.Rows.Count == 0) return;
            double dev = 0;
            decimal TotalPercent = 0;
            //同标题合并
            Dictionary<string, int> refDict = new Dictionary<string, int>();
            foreach (DataRow row in fieldData.Rows)
            {
                if (!refDict.ContainsKey(row["CAPTION"].ToString()))
                {
                    refDict.Add(row["CAPTION"].ToString(), int.Parse(row["COL_PERCENT"].ToString()));
                    TotalPercent += decimal.Parse(row["COL_PERCENT"].ToString());
                }
                else
                {
                    row["COL_PERCENT"] = refDict[row["CAPTION"].ToString()];
                    fieldData.AcceptChanges();
                }
            }
            if (TotalPercent != 100 && TotalPercent != 0)
            {
                dev = (double)TotalPercent / 100;
            }
            else return;
            double accutPercent = 0;
            refDict = new Dictionary<string, int>();
            for (int i = 0; i < fieldData.Rows.Count; i++)
            {
                DataRow curntRow = fieldData.Rows[i];
                if (!refDict.ContainsKey(curntRow["CAPTION"].ToString()))
                {
                    if (i == fieldData.Rows.Count - 1)
                    {
                        curntRow["COL_PERCENT"] = 100 - accutPercent;
                        refDict.Add(curntRow["CAPTION"].ToString(), int.Parse(curntRow["COL_PERCENT"].ToString()));
                        break;
                    }
                    double d = Math.Floor(double.Parse(curntRow["COL_PERCENT"].ToString()) / dev);
                    curntRow["COL_PERCENT"] = d;
                    refDict.Add(curntRow["CAPTION"].ToString(), int.Parse(curntRow["COL_PERCENT"].ToString()));
                    accutPercent += d;
                }
                else
                {
                    curntRow["COL_PERCENT"] = refDict[curntRow["CAPTION"].ToString()];
                }
            }
            gridControlField.DataSource = fieldData;
            lblTotalPercent.Text = string.Format("已分配{0}%", "100");
        }

        private void gridViewField_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == COL_PERCENT)
            {
                CalculateFieldPercent();
            }
        }
        /// <summary>
        /// 数字输入限制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
            else e.Handled = false;
        }

        /// <summary>
        /// 防止输入012等数字，自动转化为正常数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox.Text.Trim() != "")
            {
                int number = int.Parse(txtBox.Text.Trim());
                txtBox.Text = number.ToString();
            }
        }

        /// <summary>
        /// 选择是否全屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkFullScreen_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlScreenSize.Enabled = !chkFullScreen.Checked;
            if (chkFullScreen.Checked)
            {
                Rectangle rect = System.Windows.Forms.SystemInformation.VirtualScreen;
                int width = rect.Width;
                int height = rect.Height;
                txtWidth.Text = rect.Width.ToString();
                txtHeight.Text = rect.Height.ToString();
            }
        }

        private void cmbScreenNo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (curntMode != EditMode.None)
            {
                AutoClosedMsgBox.Show("当前有未保存的数据，请保存后选择其他大屏进行配置。", "大屏配置提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }
        /// <summary>
        /// 选择大屏编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbScreenNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTopPnlData();
            RefreshXtraTableData();
        }


        /// <summary>
        /// 切换Tab页前判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabControl_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (curntMode != EditMode.None)
            {
                AutoClosedMsgBox.Show("请确认完成当前操作后再切换页面。", "大屏配置提示", 5000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
            if ((sender as XtraTabControl).SelectedTabPage == xtraTabPageScreenSet)
            {
                //以防更新了大屏字典，而下拉内容没改变
                RefreshScreenDict();
                InitialComBox();
                RefreshTopPnlData();
            }
        }

        /// <summary>
        /// Tab页切换后控件可见性处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            pnlTop.Visible = !(xtraTabControl.SelectedTabPage == xtraTabPageScreenSet || xtraTabControl.SelectedTabPage == xtraTabPageAbout);
            pnlBottom.Visible = !(xtraTabControl.SelectedTabPage == xtraTabPageAbout);
            if (xtraTabControl.SelectedTabPage == xtraTabPageScreenSet)
            {
                btnAdd.Visible = true;
                btnDlt.Visible = false;
                btnSave.Visible = false;
                btnCancel.Visible = false;
            }
            else if (xtraTabControl.SelectedTabPage == xtraTabPageNormal)
            {
                btnAdd.Visible = false;
                btnDlt.Visible = false;
                btnSave.Visible = cmbScreenNo.SelectedIndex != -1;
                btnCancel.Visible = false;
                RefreshXtraTableData();
            }
            else if (xtraTabControl.SelectedTabPage == xtraTabPageField)
            {
                btnAdd.Visible = false;
                btnDlt.Visible = false;
                btnSave.Visible = cmbScreenNo.SelectedIndex != -1;
                btnCancel.Visible = false;
                RefreshXtraTableData();
            }
            else if (xtraTabControl.SelectedTabPage == xtraTabPageMsg)
            {
                btnAdd.Visible = cmbScreenNo.SelectedIndex != -1;
                btnDlt.Visible = gridViewMsg.FocusedRowHandle > -1;
                btnSave.Visible = cmbScreenNo.SelectedIndex != -1;
                btnCancel.Visible = false;
                RefreshXtraTableData();
            }
            else if (xtraTabControl.SelectedTabPage == xtraTabPageAbout)
            {
                btnAdd.Visible = false;
                btnDlt.Visible = false;
                btnSave.Visible = false;
                btnCancel.Visible = false;
            }
        }

        /// <summary>
        /// 切换选中的大屏组件事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void screenCtrContainer_ScreenSelectChanged(object sender, EventArgs e)
        {
            if (curntMode == EditMode.None)
            {
                screenCtr curntScreenCtr = screenCtrContainer.SelectedScreen;
                _curntScreen = curntScreenCtr.selectedScreen;
                curntMode = EditMode.Modify;
                RefreshRightScreenDetailInfo();
                //选中大屏组件即开启编辑模式
                btnAdd.Visible = false;
                btnDlt.Visible = true;
                btnSave.Visible = true;
                btnCancel.Visible = true;
            }
            else
            {
                screenCtrContainer.ClearSelectScreen();
                AutoClosedMsgBox.Show("当前状态下无法编辑其他大屏。", "大屏配置提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (xtraTabControl.SelectedTabPage == xtraTabPageScreenSet)
            {
                if (curntMode == EditMode.None)
                {
                    curntMode = EditMode.Add;
                    SetAddBehaviour();
                }
                else
                {
                    AutoClosedMsgBox.Show("当前有未保存的数据，请保存后再新增。", "大屏配置提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (xtraTabControl.SelectedTabPage == xtraTabPageMsg)
            {
                curntMode = EditMode.Add;
                SetAddBehaviour();
            }
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDlt_Click(object sender, EventArgs e)
        {
            if (AutoClosedMsgBox.Show("您是否确定要删除所选的内容？", "大屏配置提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                curntMode = EditMode.Delete;
                SetDltBehaviour();
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            SetSaveBehaviour();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (AutoClosedMsgBox.Show("您是否确定要取消当前操作？", "大屏配置提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                curntMode = EditMode.Cancel;
                SetCancelBehaviour();

            }
        }
        /// <summary>
        /// 关闭配置界面前判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (curntMode != EditMode.None)
            {
                if (AutoClosedMsgBox.Show("当前操作还未完成是否关闭页面?", "大屏配置提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else e.Cancel = true;
            }
        }

        #endregion


    }
}