using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{

    /// <summary>
    /// 手术查询条件参数model
    /// </summary>
    public class OperQueryParaModel
    {
        public string PatientId { get; set; }
        public int VisitId { get; set; }
        public int OperId { get; set; }
        public string PatName { get; set; }
        public string InpNo { get; set; }
        public string OperDept { get; set; }
        public string OperDoctor { get; set; }
        public string OperName { get; set; }
        public string AnesDoctor { get; set; }
        public string Nurse { get; set; }
        public string AnesMethod { get; set; }
        public string OperScale { get; set; }
        public string ASA { get; set; }
        public bool EMERGENCY { get; set; }  //急诊

        public decimal EMERGENCY_IND { get; set; }  //急诊择期

        public bool ISOLATION { get; set; }  //隔离
        public bool ASINFECTEDA { get; set; }  //抢救
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }


        /// <summary>
        /// 时间类型标记（年月日等）
        /// </summary>
        public string TimeType { get; set; }

        /// <summary>
        /// 查询分类
        /// </summary>
        public string QueryType { get; set; }

        /// <summary>
        /// 查询标记
        /// </summary>
        public string SearchMark { get; set; }


        /// <summary>
        /// 当前用户ID
        /// </summary>
        public string CurrentUserId { get; set; }

        public string StatusType { get; set; }

        public string OperRoomNo { get; set; }

        public string Status { get; set; }

        //麻醉交班
        /// <summary>
        /// 交班时间
        /// </summary>
        public string SHIFT_DATE { get; set; }

        /// <summary>
        /// 交班类型
        /// </summary>
        public string SHIFT_TYUPE { get; set; }

        /// <summary>
        /// 毒麻药列表
        /// </summary>
        public List<string> DRUG_LIST { get; set; }

        /// <summary>
        /// 急救患者的数量
        /// </summary>
        public int? AnesShiftEmergencyPatCount { get; set; }

        public string OrderName { get; set; }

        public string OrderSort { get; set; }
    }

    public class QueryDictConfig {
        /// <summary>
        /// 字典类型
        /// </summary>
        public string DictType { get; set; }
        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 是否远程搜索
        /// </summary>
        public bool Romote { get; set; }
        /// <summary>
        /// 是否在本地缓存
        /// </summary>
        public bool IsLocal { get; set; }
        /// <summary>
        /// 自定义对象信息
        /// </summary>
        public string DictObjStrings { get; set; }

    }
}
