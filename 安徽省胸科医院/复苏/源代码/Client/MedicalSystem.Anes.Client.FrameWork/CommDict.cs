using MedicalSystem.Anes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Client.FrameWork
{
    public class CommDict
    {

        // 麻醉事件字典表
        public List<MED_EVENT_DICT> EventDict { get; set; }

        // 麻醉事件字典扩展表
        public List<MED_EVENT_DICT_EXT> EventDictExt { get; set; }

        // 属性单位字典表  单位类型;1 浓度单位；2 速度单位，3 剂量单位
        public List<MED_UNIT_DICT> UnitDictExt { get; set; }

        // 给药途径字典表
        public List<MED_ADMINISTRATION_DICT> AdministrationDictExt { get; set; }

        // 麻醉事件排序字典表
        public List<MED_EVENT_SORT> EventSortDict { get; set; }

        // 用户字典表
        public List<MED_HIS_USERS> HisUsersDict { get; set; }

        // 科室字典表
        public List<MED_DEPT_DICT> DeptDict { get; set; }

        // 检测项目字典表
        public List<MED_MONITOR_FUNCTION_CODE> MonitorFuntionDict { get; set; }

        // 手术室字典表
        public List<MED_OPERATING_ROOM> OperationRoomDict { get; set; }

        // 手术名称字典表
        public List<MED_OPERATION_DICT> OperationNameDict { get; set; }

        // 诊断字典表
        public List<MED_DIAGNOSIS_DICT> DiagnosisDict { get; set; }

        // 通用项目字典表
        public List<MED_ANESTHESIA_INPUT_DICT> AnesInputDictDict { get; set; }

        // 血气字典表
        public List<MED_BLOOD_GAS_DICT> BloodGasDict { get; set; }

        // 病区字典表
        public List<MED_WARD_DICT> WardDict { get; set; }

        // 麻醉方法字典表
        public List<MED_ANESTHESIA_DICT> AnesMethodDict { get; set; }

        // 监护仪字典表
        public List<MED_MONITOR_DICT> MonitorDict { get; set; } 
        /// <summary>
        /// 获取医院抬头
        /// </summary>
        public List<MED_HOSPITAL_CONFIG> HosotalConfigDict { get; set; }

        /// <summary>
        /// 多科室字典表
        /// </summary>
        public List<MED_DEPT_DICT> MutiDeptDict { get; set; }
        public List<MED_CONFIG> ConfigDict { get; set; }
    }
}
