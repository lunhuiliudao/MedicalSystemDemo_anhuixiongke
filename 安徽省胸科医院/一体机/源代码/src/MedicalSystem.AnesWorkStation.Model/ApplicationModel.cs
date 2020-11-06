/*******************************
 * 文件名称：ApplicationModel.cs
 * 文件说明：全局实体类，采用单例模式
 * 作    者：许文龙
 * 日    期：2017-04-12
 * *****************************/
using Castle.Components.DictionaryAdapter;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model.DictModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MedicalSystem.AnesWorkStation.Model
{
    /// <summary>
    /// 消息标志枚举
    /// </summary>
    public enum EnumMessageKey
    {
        /// <summary>
        /// 根据患者ID，姓名，住院号 搜索，同时在工作列表中显示
        /// </summary>
        [Description("根据患者ID，姓名，住院号 搜索，同时在工作列表中显示")]
        SearchCommand,

        /// <summary>
        /// 搜索文本框文本改变命令
        /// </summary>
        [Description("搜索文本框文本改变命令")]
        SearchTextChangedCommand,

        /// <summary>
        /// 显示明日手术工作列表
        /// </summary>
        [Description("显示明日手术工作列表")]
        TomorrowSurgeryWorkListCommand,

        /// <summary>
        /// 显示一周的手术工作列表
        /// </summary>
        [Description("显示一周的手术工作列表")]
        WeekSurgeryWorkListCommand,

        /// <summary>
        /// 根据当前工作列表类型显示，未完成手术显示明日手术汇总，已完成手术显示一周手术汇总
        /// </summary>
        [Description("切换显示明日手术汇总还是一周手术汇总")]
        SwitchSurgery,

        /// <summary>
        /// 显示术中登记界面
        /// </summary>
        [Description("显示术中登记界面")]
        ShowInOperationWindow,

        /// <summary>
        /// 关闭登录界面
        /// </summary>
        [Description("关闭登录界面")]
        CloseLogin,

        /// <summary>
        /// 退出登录界面，关闭程序
        /// </summary>
        [Description("退出登录界面，关闭程序")]
        ExitLogin,

        /// <summary>
        /// 刷新今日手术汇总界面
        /// </summary>
        [Description("刷新今日手术汇总界面")]
        RefreshTodaySurgery,

        /// <summary>
        /// 刷新明日手术汇总界面
        /// </summary>
        [Description("刷新明日手术汇总界面")]
        RefreshTomorrowSurgery,

        /// <summary>
        /// 刷新一周手术汇总界面
        /// </summary>
        [Description("刷新一周手术汇总界面")]
        RefreshWeekSurgery,

        /// <summary>
        /// 刷新正在进行手术界面
        /// </summary>
        [Description("刷新正在进行手术界面")]
        RefreshOperatingPatient,

        /// <summary>
        /// 刷新工作列表界面
        /// </summary>
        [Description("刷新工作列表界面")]
        RefreshWordList,

        /// <summary>
        /// 刷新主界面
        /// </summary>
        [Description("刷新主界面")]
        RefreshMainWindow,

        /// <summary>
        /// 刷新当前工作列表状态的背景图片: 是已完成还是未完成
        /// </summary>
        [Description("刷新当前工作列表状态的背景图片")]
        RefreshEnumWorkListType,

        /// <summary>
        /// 刷新术中界面
        /// </summary>
        [Description("刷新术中界面")]
        RefreshInOperationWindow,

        /// <summary>
        /// 刷新用药界面
        /// </summary>
        [Description("刷新用药界面")]
        RefreshAnesEventWindow,

        /// <summary>
        /// 刷新体征界面
        /// </summary>
        [Description("刷新体征界面")]
        RefreshSignVitalWindow,
        /// <summary>
        /// 刷新密集体征界面
        /// </summary>
        [Description("刷新密集体征界面")]
        RefreshIntensiveSignVitalWindow,
        /// <summary>
        /// 关闭术中界面
        /// </summary>
        [Description("关闭术中界面")]
        CloseInOperationWindow,

        /// <summary>
        /// 协同Call
        /// </summary>
        [Description("协同Call")]
        CoordinationCall,

        /// <summary>
        /// 协同等待
        /// </summary>
        [Description("协同等待")]
        CoordinationWait,
        /// <summary>
        /// 麦克风
        /// </summary>
        [Description("协同麦克风")]
        CoordinationMic,
        /// <summary>
        /// 扬声器
        /// </summary>
        [Description("协同扬声器")]
        CoordinationSpeaker,
        /// <summary>
        /// 协同窗体大小改变
        /// </summary>
        [Description("协同窗体大小改变")]
        CoordinationSizeChange,

        /// <summary>
        /// 隐藏主界面
        /// </summary>
        [Description("隐藏主界面")]
        HideMainWindow,

        /// <summary>
        /// 显示主界面
        /// </summary>
        [Description("显示主界面")]
        ShowMainWindow,

        /// <summary>
        /// 刷新当前选中的患者边框
        /// </summary>
        [Description("刷新当前选中的患者边框")]
        RefreshSelectedCurPatientInfoBorder,

        /// <summary>
        /// 刷新搜索列表选中的患者边框
        /// </summary>
        [Description("刷新搜索列表选中的患者边框")]
        RefreshSearchSelectedCurPatientInfoBorder,

        /// <summary>
        /// 刷新正在手术的患者边框
        /// </summary>
        [Description("刷新正在手术的患者边框")]
        RefreshOperatingSelectedCurPatientInfoBorder,

        /// <summary>
        /// 刷新工作列表选中的患者边框
        /// </summary>
        [Description("刷新工作列表选中的患者边框")]
        RefreshWorkListSelectedCurPatientInfoBorder,

        /// <summary>
        /// 刷新手术进程LED状态灯
        /// </summary>
        [Description("刷新手术进程LED状态灯")]
        RefreshSecondKeyBoardAllLed,

        /// <summary>
        /// 显示护士交班
        /// </summary>
        [Description("显示护士交班")]
        ShowNurseShift,
        /// <summary>
        /// 显示麻醉交班
        /// </summary>
        [Description("显示麻醉交班")]
        ShowAnesDocShift,
        /// <summary>
        /// 显示医生交班
        /// </summary>
        [Description("显示医生交班")]
        ShowSurgeonShift,
        /// <summary>
        /// 刷新血气分析主信息
        /// </summary>
        [Description("刷新血气分析主信息")]
        RefreshBloodGasMaster,

        /// <summary>
        /// 刷新血气分析主信息被选中项
        /// </summary>
        [Description("刷新血气分析主信息被选中项")]
        RefreshBloodGasMasterSelection,

        /// <summary>
        /// 刷新术中界面中的患者信息
        /// </summary>
        [Description("刷新术中界面中的患者信息")]
        RefreshInOperationInformation,

        /// <summary>
        /// 重置界面焦点
        /// </summary>
        [Description("重置界面焦点")]
        ResetOperationMedNoteControlFocus,

        /// <summary>
        /// WorkList默认选择
        /// </summary>
        [Description("设置WorkList默认选择")]
        SetWorkListSelectItem,

        /// <summary>
        /// 设置焦点
        /// </summary>
        [Description("设置焦点")]
        ResetFocus,


        /// <summary>
        /// 患者进入抢救模式
        /// </summary>
        [Description("患者进入抢救模式")]
        IsOperationRescuing,

        /// <summary>
        /// 接收到新消息时显示右上角动画图标
        /// </summary>
        [Description("接收到新消息时显示右上角动画图标")]
        NewUnreadMessage,

        /// <summary>
        /// 响应视频通讯请求
        /// </summary>
        [Description("响应视频通讯请求")]
        ResponseVideoComm,

        /// <summary>
        /// 确认选择血气后刷新血气界面
        /// </summary>
        [Description("确认选择血气后刷新血气界面")]
        RefreshBloodGasMasterAfterBloodGasSelector,

        /// <summary>
        /// 快速更改手术时间点
        /// </summary>
        [Description("快速更改手术时间点")]
        ChangeDateRegister,

        /// <summary>
        /// 设置时间窗口获取焦点
        /// </summary>
        [Description("设置时间窗口获取焦点")]
        RefreshDateRegisterFocus,

        /// <summary>
        /// 设置批量归档界面中的进度条显示与否
        /// </summary>
        [Description("设置批量归档界面中的进度条显示与否")]
        SetUnPostPDFProbarShow,

        /// <summary>
        /// 响应快捷键操作:M1-M8
        /// </summary>
        [Description("响应快捷键操作:M1-M8")]
        ShortcutKey,

        /// <summary>
        /// 快速切换大事件界面
        /// </summary>
        [Description("快速切换大事件界面")]
        QuickChangeOperEventWindow,

        /// <summary>
        /// 在快速切换大事件界面时刷新窗体的标题
        /// </summary>
        [Description("在快速切换大事件界面时刷新窗体的标题")]
        RefreshOperEventWindowTitle,

        /// <summary>
        /// 在文书窗口内切换文书内容
        /// </summary>
        [Description("在文书窗口内切换文书内容")]
        QuickChangeDoc,

        /// <summary>
        /// 重置LoadReport窗口
        /// </summary>
        [Description("重置LoadReport窗口")]
        ResetLoadReport,

        /// <summary>
        /// 有新版本通知
        /// </summary>
        [Description("有新版本通知")]
        HasNewVersion,
    }

    /// <summary>
    /// 跨手术间传递消息类别
    /// </summary>
    public enum EnumTransportMessageClass
    {
        /// <summary>
        /// 更换手术间
        /// </summary>
        [Description("更换手术间")]
        ChangeOperRoomNo = 1,

        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        Unknow = -1,
    }

    /// <summary>
    /// 全局实体类
    /// </summary>
    public class ApplicationModel
    {
        private static ApplicationModel instance = null;                                             // 单例
        private Dictionary<Type, object> dictHashtable = new Dictionary<Type, object>();       // 字典列表缓存，不直接开放给外界，通过属性：AllDictList 去获取对应的字典信息

        /// <summary>
        /// 单例
        /// </summary>
        public static ApplicationModel Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new ApplicationModel();
                }

                return instance;
            }
        }

        ///// <summary>
        ///// 当前登录用户的基本信息
        ///// </summary>
        //public LoginUserModel CurLoginUserModel
        //{
        //    get { return this.curLoginUserModel;  }
        //    set { this.curLoginUserModel = value; }
        //}

        /// <summary>
        /// 所有字典列表
        /// </summary>
        public IAllDictModel AllDictList
        {
            get { return GetDataByInterface<IAllDictModel>(); }
        }

        #region 字典缓存表

        Dictionary<string, MED_DEPT_DICT> _deptDictCache;
        public Dictionary<string, MED_DEPT_DICT> DeptDictCache
        {
            get
            {
                if (_deptDictCache == null && AllDictList.DeptDictList != null)
                {
                    try
                    {
                        _deptDictCache = AllDictList.DeptDictList.ToDictionary<MED_DEPT_DICT, string>(x => x.DEPT_CODE);
                    }
                    catch
                    {
                        foreach (var item in AllDictList.DeptDictList)
                        {
                            _deptDictCache[item.DEPT_CODE] = item;
                        }
                    }
                }
                return _deptDictCache;
            }
        }

        Dictionary<string, MED_HIS_USERS> _hisUsersCache;
        public Dictionary<string, MED_HIS_USERS> HisUsersCache
        {
            get
            {
                if (_hisUsersCache == null && AllDictList.HisUsersList != null)
                {
                    try
                    {
                        _hisUsersCache = AllDictList.HisUsersList.ToDictionary<MED_HIS_USERS, string>(x => x.USER_JOB_ID);
                    }
                    catch
                    {
                        foreach (var item in AllDictList.HisUsersList)
                        {
                            _hisUsersCache[item.USER_JOB_ID] = item;
                        }
                    }
                }
                return _hisUsersCache;
            }
        }

        #endregion

        ///// <summary>
        ///// 当前一体机所在的手术间
        ///// </summary>
        //public string OperRoomNo
        //{
        //    get { return this.operRoomNo;  }
        //    set { this.operRoomNo = value; }
        //}

        ///// <summary>
        ///// 当前正在进行手术的的患者
        ///// </summary>
        //public PatientModel CurOperatingPatientModel
        //{
        //    get { return this.curOperatingPatientModel;  }
        //    set { this.curOperatingPatientModel = value; }
        //}

        ///// <summary>
        ///// 工作列表中被选中的患者
        ///// </summary>
        //public PatientModel CurSelectedPatientInWorkList
        //{
        //    get { return this.curSelectedPatientInWorkList;  }
        //    set { this.curSelectedPatientInWorkList = value; }
        //}

        /// <summary>
        /// 私有构造方法
        /// </summary>
        private ApplicationModel()
        {
        }

        /// <summary>
        /// 根据接口类型获取对应的数据
        /// </summary>
        /// <typeparam name="T">接口类型</typeparam>
        private T GetDataByInterface<T>()
        {
            try
            {
                object dictionary = null;
                if (dictHashtable.ContainsKey(typeof(T)))
                {
                    dictionary = dictHashtable[typeof(T)];
                }
                else
                {
                    var hs = new Hashtable();
                    dictionary = new DictionaryAdapterFactory().GetAdapter<T>(hs);
                    dictHashtable[typeof(T)] = dictionary;
                }

                return (T)dictionary;
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// 全局高速缓存
        /// </summary>
        static Dictionary<Enum, string> EnumDictCache = new Dictionary<Enum, string>();

        /// <summary>
        /// 获取枚举类型子项的描述信息
        /// </summary>
        public string GetEnumDescription<TEnum>(TEnum enumType)
        {
            string result = string.Empty;
            Enum val = enumType as Enum;
            if (val == null || !EnumDictCache.TryGetValue(val, out result))
            {
                Type t = typeof(TEnum);
                if (null != enumType && t.IsEnum)
                {
                    System.Reflection.FieldInfo info = t.GetField(enumType.ToString());
                    if (info != null)
                    {
                        object[] objArr = info.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        if (objArr != null && objArr.Length > 0)
                        {
                            result = (objArr[0] as DescriptionAttribute).Description;
                            try
                            {
                                EnumDictCache.Add(val, result);
                            }
                            catch { }
                        }
                    }
                }
            }

            return result;
        }
    }
}
