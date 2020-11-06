using System;
using System.Collections.Generic;
using System.Data;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document;
using System.Threading;
using System.Reflection;
using System.Collections;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Services;

namespace MedicalSystem.Anes.Client.AppPC
{
    /// <summary>
    /// 加载等待框
    /// </summary>
    public partial class LoadingFrm : BaseForm
    {
        public LoadingFrm()
        {
            InitializeComponent();
            this.IsMainForm = true;
        }
        //public override bool RegisterHotKey
        //{
        //    get
        //    {
        //        return false;
        //    }
        //}

        private System.Windows.Forms.Timer t = null;
        private Thread thread = null;
        /// <summary>
        /// 主窗口是否加载结束
        /// </summary>
        public static bool EndWithMainFrm = false;
        public static bool EndOfTask = false;

        protected override void OnActivated(EventArgs e)
        {
            //取消加载窗口的注册键盘事件
            //base.OnActivated(e);
        }
        private void LoadingFrm_Load(object sender, EventArgs e)
        {
            LoadingFrm_Resize(sender, e);

            this.label1.Text = "";

            //进度条设置
            InitTaskList();

            if (taskList.Count > 0)
            {
                string format = "f2";
                if (100f / taskList.Count == 100 / taskList.Count)
                {
                    format = "f0";
                }

                t = new System.Windows.Forms.Timer() { Interval = 1000 };
                t.Tick += (s, d) =>
                {
                    if (resultList.Count < taskList.Count)
                    {
                        this.label1.Text = "数据加载进度["
                            + (resultList.Count * 100f / taskList.Count).ToString(format)
                            + "%]";
                    }
                    else
                    {
                        EndOfTask = true;
                    }

                    if (EndOfTask)
                    {
                        if (!EndWithMainFrm)
                        {

                            this.label1.Text = "等待加载主窗口";
                        }
                        else
                        {
                            if (resultList.Contains(false))
                            {
                                taskList.Clear();
                                resultList.Clear();
                                MessageBoxFormPC.Show("加载字典时出错，请检查日志。");
                            }
                            this.Close();
                            this.Dispose(true);
                        }
                    }
                };
                t.Start();

                thread = new Thread(new ThreadStart(BackgroudRunTask));
                thread.Start();
            }
        }
        protected override void OnDeactivate(EventArgs e)
        {
            //取消加载窗口的注册键盘事件
            //base.OnDeactivate(e);
        }

        private Dictionary<string, Func<bool>> taskList = new Dictionary<string, Func<bool>>();
        private List<bool> resultList = new List<bool>();

        const string errorTitle = "错误信息";

        private void InitTaskList()
        {
            //获取权限
            taskList.Add("获取用户权限", () =>
            {
                try
                {
                    if (ExtendApplicationContext.Current.LoginUser.MDSD_APPLICATION != null && ExtendApplicationContext.Current.LoginUser.MDSD_APPLICATION.MENU_LIST.Count > 0)
                    {
                        foreach (MDSD.Permission.Domain.MDSD_MENU menuList in ExtendApplicationContext.Current.LoginUser.MDSD_APPLICATION.MENU_LIST)
                        {
                            if (menuList.SUB_MENU_LIST.Count > 0)
                            {
                                foreach (MDSD.Permission.Domain.MDSD_MENU menu in menuList.SUB_MENU_LIST)
                                {
                                    AccessControl.AddPermission(menu.MENU_KEY, menuList.MENU_KEY);
                                }
                            }
                        }
                    }
                    //ExtendApplicationContext.Current.PermissionsList =
                    //    AccountService.GetPermission(
                    //        ExtendApplicationContext.Current.ApplicationID,
                    //        ExtendApplicationContext.Current.LoginUser.LOGIN_NAME);
                    return true;
                }
                catch (Exception ex)
                {
                    Logger.Error(errorTitle, ex);
                    return false;
                }
            });
            //#region 所有字典，聚合一起请求获取
            //taskList.Add("所有字典，聚合一起请求获取", () =>
            //{
            //    try
            //    {
            //        dynamic data = CommDictService
            //            .GetAllDictList(ExtendApplicationContext.Current.LoginUser.LOGIN_NAME);
            //        if (data.EventDict != null) //录入字典表
            //        {
            //            string value = data.EventDict.ToString();
            //            ExtendApplicationContext.Current.CommDict.EventDict
            //                = JsonConvert.DeserializeObject<List<Domain.MED_EVENT_DICT>>(value);
            //        }
            //        if (data.EventDictExt != null) //麻醉事件字典扩展表
            //        {
            //            string value = data.EventDictExt.ToString();
            //            ExtendApplicationContext.Current.CommDict.EventDictExt
            //                = JsonConvert.DeserializeObject<List<Domain.MED_EVENT_DICT_EXT>>(value);
            //        }
            //        if (data.UnitDictExt != null) //属性单位字典表
            //        {
            //            string value = data.UnitDictExt.ToString();
            //            ExtendApplicationContext.Current.CommDict.UnitDictExt
            //                = JsonConvert.DeserializeObject<List<Domain.MED_UNIT_DICT>>(value);
            //        }
            //        if (data.AdministrationDictExt != null) //给药途径字典表
            //        {
            //            string value = data.AdministrationDictExt.ToString();
            //            ExtendApplicationContext.Current.CommDict.AdministrationDictExt
            //                = JsonConvert.DeserializeObject<List<Domain.MED_ADMINISTRATION_DICT>>(value);
            //        }
            //        if (data.EventSortDict != null) //麻醉事件排序字典表
            //        {
            //            string value = data.EventSortDict.ToString();
            //            ExtendApplicationContext.Current.CommDict.EventSortDict
            //                = JsonConvert.DeserializeObject<List<Domain.MED_EVENT_SORT>>(value);
            //        }
            //        if (data.HisUsersDict != null) //用户字典表
            //        {
            //            string value = data.HisUsersDict.ToString();
            //            ExtendApplicationContext.Current.CommDict.HisUsersDict
            //                = JsonConvert.DeserializeObject<List<Domain.MED_HIS_USERS>>(value);
            //        }
            //        if (data.DeptDict != null) //科室字典表
            //        {
            //            string value = data.DeptDict.ToString();
            //            ExtendApplicationContext.Current.CommDict.DeptDict
            //                = JsonConvert.DeserializeObject<List<Domain.MED_DEPT_DICT>>(value);
            //        }
            //        if (data.MonitorFuntionDict != null) //检测项目字典表
            //        {
            //            string value = data.MonitorFuntionDict.ToString();
            //            ExtendApplicationContext.Current.CommDict.MonitorFuntionDict
            //                = JsonConvert.DeserializeObject<List<Domain.MED_MONITOR_FUNCTION_CODE>>(value);
            //        }
            //        if (data.OperationRoomDict != null) //手术室字典表
            //        {
            //            string value = data.OperationRoomDict.ToString();
            //            ExtendApplicationContext.Current.CommDict.OperationRoomDict
            //                = JsonConvert.DeserializeObject<List<Domain.MED_OPERATING_ROOM>>(value);
            //        }
            //        if (data.AnesInputDictDict != null) //通用项目字典表
            //        {
            //            string value = data.AnesInputDictDict.ToString();
            //            ExtendApplicationContext.Current.CommDict.AnesInputDictDict
            //                = JsonConvert.DeserializeObject<List<Domain.MED_ANESTHESIA_INPUT_DICT>>(value);
            //        }
            //        if (data.BloodGasDict != null) //血气字典表
            //        {
            //            string value = data.BloodGasDict.ToString();
            //            ExtendApplicationContext.Current.CommDict.BloodGasDict
            //                = JsonConvert.DeserializeObject<List<Domain.MED_BLOOD_GAS_DICT>>(value);
            //        }
            //        if (data.WardDict != null) //病区字典表
            //        {
            //            string value = data.WardDict.ToString();
            //            ExtendApplicationContext.Current.CommDict.WardDict
            //                = JsonConvert.DeserializeObject<List<Domain.MED_WARD_DICT>>(value);
            //        }
            //        if (data.AnesMethodDict != null) //麻醉方法字典表
            //        {
            //            string value = data.AnesMethodDict.ToString();
            //            ExtendApplicationContext.Current.CommDict.AnesMethodDict
            //                = JsonConvert.DeserializeObject<List<Domain.MED_ANESTHESIA_DICT>>(value);
            //        }
            //        if (data.MonitorDict != null) //麻醉方法字典表
            //        {
            //            string value = data.MonitorDict.ToString();
            //            ExtendApplicationContext.Current.CommDict.MonitorDict
            //                = JsonConvert.DeserializeObject<List<Domain.MED_MONITOR_DICT>>(value);
            //        }
            //        if (data.HosotalConfigDict != null) //获取医院抬头
            //        {
            //            string value = data.HosotalConfigDict.ToString();
            //            ExtendApplicationContext.Current.CommDict.HosotalConfigDict
            //                = JsonConvert.DeserializeObject<List<Domain.MED_HOSPITAL_CONFIG>>(value);
            //        }
            //        if (data.ConfigDict != null)
            //        {
            //            string value = data.ConfigDict.ToString();
            //            ExtendApplicationContext.Current.CommDict.ConfigDict
            //                = JsonConvert.DeserializeObject<List<Domain.MED_CONFIG>>(value);
            //        }
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.WriteErrLog(errorTitle, ex);
            //        return false;
            //    }
            //});
            //#endregion
            //#region 所有字典，聚合一起请求获取

            ///*
            //#region 录入字典表
            //taskList.Add("麻醉事件字典表", () =>
            //{
            //    try
            //    {
            //        ExtendApplicationContext.Current.CommDict.EventDict
            //            = CommDictService.GetEventDictList();
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.WriteErrLog(errorTitle, ex);
            //        return false;
            //    }
            //});
            //#endregion
            //#region 麻醉事件字典扩展表
            //taskList.Add("麻醉事件字典扩展表", () =>
            //{
            //    try
            //    {
            //        ExtendApplicationContext.Current.CommDict.EventDictExt
            //            = CommDictService.GetAnesEventDictExt();
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.WriteErrLog(errorTitle, ex);
            //        return false;
            //    }
            //});
            //#endregion
            //#region 属性单位字典表
            //taskList.Add("属性单位字典表", () =>
            //{
            //    try
            //    {
            //        ExtendApplicationContext.Current.CommDict.UnitDictExt
            //            = CommDictService.GetUnitDictList();
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.WriteErrLog(errorTitle, ex);
            //        return false;
            //    }
            //});
            //#endregion
            //#region 给药途径字典表
            //taskList.Add("给药途径字典表", () =>
            //{
            //    try
            //    {
            //        ExtendApplicationContext.Current.CommDict.AdministrationDictExt
            //            = CommDictService.GetAdminstrationDictList();
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.WriteErrLog(errorTitle, ex);
            //        return false;
            //    }
            //});
            //#endregion
            //#region 麻醉事件排序字典表
            //taskList.Add("麻醉事件排序字典表", () =>
            //{
            //    try
            //    {
            //        ExtendApplicationContext.Current.CommDict.EventSortDict
            //            = CommDictService.GetEventSortList(ExtendApplicationContext.Current.LoginUser.LOGIN_NAME);
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.WriteErrLog(errorTitle, ex);
            //        return false;
            //    }
            //});
            //#endregion
            //#region 用户字典表
            //taskList.Add("用户字典表", () =>
            //{
            //    try
            //    {
            //        ExtendApplicationContext.Current.CommDict.HisUsersDict
            //            = CommDictService.GetHisUsersList();
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.WriteErrLog(errorTitle, ex);
            //        return false;
            //    }
            //});
            //#endregion
            //#region 科室字典表
            //taskList.Add("科室字典表", () =>
            //{
            //    try
            //    {
            //        ExtendApplicationContext.Current.CommDict.DeptDict
            //            = CommDictService.GetDeptDictList();
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.WriteErrLog(errorTitle, ex);
            //        return false;
            //    }
            //});
            //#endregion
            //#region 检测项目字典表
            //taskList.Add("检测项目字典表", () =>
            //{
            //    try
            //    {
            //        ExtendApplicationContext.Current.CommDict.MonitorFuntionDict
            //            = CommDictService.GetMonitorFuctionCodeList();
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.WriteErrLog(errorTitle, ex);
            //        return false;
            //    }
            //});
            //#endregion
            //#region 手术室字典表
            //taskList.Add("手术室字典表", () =>
            //{
            //    try
            //    {
            //        ExtendApplicationContext.Current.CommDict.OperationRoomDict
            //            = CommDictService.GetOperatingRoomList(0);
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.WriteErrLog(errorTitle, ex);
            //        return false;
            //    }
            //});
            //#endregion
            //*/
            //#endregion
            ///* 数据较多 */
            //#region 手术名称字典表
            //taskList.Add("手术名称字典表", () =>
            //{
            //    try
            //    {
            //        ExtendApplicationContext.Current.CommDict.OperationNameDict
            //            = CommDictService.GetOperNameDictList();
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.WriteErrLog(errorTitle, ex);
            //        return false;
            //    }
            //});
            //#endregion
            ///* 数据较多 */
            //#region 诊断字典表
            //taskList.Add("诊断字典表", () =>
            //{
            //    try
            //    {
            //        //ExtendApplicationContext.Current.CommDict.DiagnosisDict
            //        //    = CommDictService.GetDiagDictList();
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.WriteErrLog(errorTitle, ex);
            //        return false;
            //    }
            //});
            //#endregion
            //#region 所有字典，聚合一起请求获取
            ///*
            //#region 通用项目字典表
            //taskList.Add("通用项目字典表", () =>
            //{
            //    try
            //    {
            //        ExtendApplicationContext.Current.CommDict.AnesInputDictDict
            //            = CommDictService.GetAnesInputDictList(null);
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.WriteErrLog(errorTitle, ex);
            //        return false;
            //    }
            //});
            //#endregion
            //#region 血气字典表
            //taskList.Add("血气字典表", () =>
            //{
            //    try
            //    {
            //        ExtendApplicationContext.Current.CommDict.BloodGasDict
            //            = CommDictService.GetBloodGasDictList();
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.WriteErrLog(errorTitle, ex);
            //        return false;
            //    }
            //});
            //#endregion
            //#region 病区字典表
            //taskList.Add("病区字典表", () =>
            //{
            //    try
            //    {
            //        ExtendApplicationContext.Current.CommDict.WardDict
            //            = CommDictService.GetWardDictList();
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.WriteErrLog(errorTitle, ex);
            //        return false;
            //    }
            //});
            //#endregion
            //#region 麻醉方法字典表
            //taskList.Add("麻醉方法字典表", () =>
            //{
            //    try
            //    {
            //        ExtendApplicationContext.Current.CommDict.AnesMethodDict
            //            = CommDictService.GetAnesMethodDictList();
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.WriteErrLog(errorTitle, ex);
            //        return false;
            //    }
            //});
            //#endregion
            //#region 监护仪字典表
            //taskList.Add("监护仪字典表", () =>
            //{
            //    try
            //    {
            //        ExtendApplicationContext.Current.CommDict.MonitorDict
            //            = CommDictService.GetMonitorDictList();
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.WriteErrLog(errorTitle, ex);
            //        return false;
            //    }
            //});
            //#endregion
            //*/
            //#endregion
            #region 换成字典表DataTable
            taskList.Add("换成字典表DataTable", () =>
            {
                try
                {
                    Type type = ExtendApplicationContext.Current.CommDict.GetType();
                    Type elemType = null;
                    PropertyInfo[] propInfos = type.GetProperties();
                    foreach (var prop in propInfos)
                    {
                        var value = prop.GetValue(ExtendApplicationContext.Current.CommDict, null);
                        if (value != null
                            && (type = value.GetType()) != null
                            && typeof(IList).IsAssignableFrom(type)
                            && (elemType = type.GetGenericArguments()[0]) != null
                            && elemType.IsSubclassOf(typeof(BaseModel)))
                        {
                            var list = value as IList;
                            DataTable dt = ModelHelper.ConvertListToDataTable(list);
                            ExtendAppContext.Current.CodeTables.Add(elemType.Name, dt);
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Logger.Error(errorTitle, ex);
                    return false;
                }
            });
            #endregion
        }

        protected void BackgroudRunTask()
        {
            foreach (var fun in taskList.Values)
            {
                if (fun())
                {
                    resultList.Add(true);
                }
                else
                {
                    resultList.Add(false);
                }
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            if (t != null)
            {
                t.Dispose();
                t = null;
            }
            if (thread != null)
            {
                thread.Abort();
                taskList.Clear();
                taskList = null;
                resultList.Clear();
                resultList = null;
                thread = null;
            }
            base.OnClosed(e);
        }

        private void LoadingFrm_Resize(object sender, EventArgs e)
        {
            //this.pictureBox1.Left = (this.Width - this.pictureBox1.Width) / 2;
            //this.label1.Left = (this.Width - this.label1.Width) / 2;
        }

    }
    public class SplashFormHelper
    {
        public static void HideSplashForm()
        {
            if (HideFormEventHandler != null)
                HideFormEventHandler(null, EventArgs.Empty);
        }

        public static event EventHandler HideFormEventHandler;
        public static event EventHandler MessageNotifyHandler;
        public static void MessageNotify(string msg)
        {


            if (MessageNotifyHandler != null)
                MessageNotifyHandler(msg, EventArgs.Empty);

        }
    }

}
