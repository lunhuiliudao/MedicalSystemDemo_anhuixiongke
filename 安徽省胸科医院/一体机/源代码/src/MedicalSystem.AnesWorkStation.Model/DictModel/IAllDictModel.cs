/*******************************
 * 文件名称：IAllDictModel.cs
 * 文件说明：字典集合实体接口
 * 作    者：许文龙
 * 日    期：2017-04-14
 * *****************************/
using MedicalSystem.AnesWorkStation.Domain;
using System.Collections.Generic;

namespace MedicalSystem.AnesWorkStation.Model.DictModel
{
    public interface IAllDictModel
    {
        /// <summary>
        /// 麻醉方法字典表
        /// </summary>
        List<MED_ANESTHESIA_DICT> AnesthesiaDictList { get; set; }

        /// <summary>
        /// 实体 麻醉通用项目字典表;此表保存麻醉产品中输入项目的字典，这些输入项目直接保存次表的项目名称。
        /// </summary>
        List<MED_ANESTHESIA_INPUT_DICT> AnesthesiaInputDictList { get; set; }

        /// <summary>
        /// 应用程序字典表
        /// </summary>
        List<MED_APPLICATIONS> ApplicationsList { get; set; }

        /// <summary>
        /// 收费项目分类代码表
        /// </summary>
        List<MED_BILL_ITEM_CLASS_DICT> BillItemClassDictList { get; set; }

        /// <summary>
        /// 血气分析字典表
        /// </summary>
        List<MED_BLOOD_GAS_DICT> BloodGasDictList { get; set; }

        /// <summary>
        /// 实体 协同终端列表;手术间协同终端列表，保存各个终端的IP，实现点对点通讯。终端登录时，要更新客户端状态为已登录。未登录的终端，不显示在发送终端列表中。
        /// </summary>
        List<MED_CLIENT_COMPUTER> ClientComputerList { get; set; }

        /// <summary>
        /// 配置文件实体 
        /// </summary>
        List<MED_CONFIG> ConfigList { get; set; }

        /// <summary>
        /// 科室代码表
        /// </summary>
        List<MED_DEPT_DICT> DeptDictList { get; set; }

        /// <summary>
        /// 诊断字典
        /// </summary>
        List<MED_DIAGNOSIS_DICT> DiagnosisDictList { get; set; }

        /// <summary>
        /// 文书模板字典表 
        /// </summary>
        List<MED_DOCUMENT_TEMPLET> DocumentTempletList { get; set; }

        /// <summary>
        /// 麻醉事件定义
        /// </summary>
        List<MED_EVENT_DICT> EventDictList { get; set; }

        /// <summary>
        /// 麻醉事件定义扩展表
        /// </summary>
        List<MED_EVENT_DICT_EXT> EventDictExtList { get; set; }

        /// <summary>
        /// 事件类型代码表
        /// </summary>
        List<MED_EVENT_ITEM_CLASS_DICT> EventItemClassDictClass { get; set; }

        /// <summary>
        /// 麻醉事件使用频率排序表
        /// </summary>
        List<MED_EVENT_SORT> EventSortList { get; set; }

        /// <summary>
        /// 麻醉事件收费对照表
        /// </summary>
        List<MED_EVENT_VS_BILL> EventVSBillList { get; set; }

        /// <summary>
        /// 用户信息（HIS）
        /// </summary>
        List<MED_HIS_USERS> HisUsersList { get; set; }

        /// <summary>
        /// 院区代码表
        /// </summary>
        List<MED_HOSP_BRANCH_DICT> HospBranchDictList { get; set; }

        /// <summary>
        /// 医院信息配置字典表
        /// </summary>
        List<MED_HOSPITAL_CONFIG> HospitalConfigList { get; set; }

        /// <summary>
        /// 麻醉方法字典表
        /// </summary>
        List<MED_METHOD_DICT> MethodDictList { get; set; }

        /// <summary>
        /// 监护仪字典表
        /// </summary>
        List<MED_MONITOR_DICT> MonitorDictList { get; set; }

        /// <summary>
        /// 检测项目字典表
        /// </summary>
        List<MED_MONITOR_FUNCTION_CODE> MonitorFuctionCodeList { get; set; }

        /// <summary>
        /// 手术间代码表
        /// </summary>
        List<MED_OPERATING_ROOM> OperatingRoomList { get; set; }

        /// <summary>
        /// 手术间默认仪器对照表
        /// </summary>
        List<MED_OPERATING_ROOM_VS_MONITOR> OperatingRoomVSMonitorList { get; set; }

        /// <summary>
        /// 手术字典表
        /// </summary>
        List<MED_OPERATION_DICT> OperationDictList { get; set; }

        /// <summary>
        /// 手术状态字典表
        /// </summary>
        List<MED_OPERATION_STATUS_DICT> OperationStatusDictList { get; set; }

        /// <summary>
        /// 手术分值表
        /// </summary>
        List<MED_OPERSCORE_DICT> OperscoreDictList { get; set; }

        /// <summary>
        /// 实体 
        /// </summary>
        List<MED_PERIOPERATIVE_EVENT_CONFIG> PerioperativeEventConfigList { get; set; }

        /// <summary>
        /// 单位代码表
        /// </summary>
        List<MED_UNIT_DICT> UnitDictList { get; set; }

        /// <summary>
        /// 病区代码表
        /// </summary>
        List<MED_WARD_DICT> WardDictList { get; set; }

        /// <summary>
        /// 用药途径字典表
        /// </summary>
        List<MED_ADMINISTRATION_DICT> AdministrationDictList { get; set; }
    }

}
