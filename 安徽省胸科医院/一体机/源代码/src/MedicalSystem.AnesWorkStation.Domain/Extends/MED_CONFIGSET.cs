using System;
using System.Collections.Generic;
using Dapper.Data;

namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// 实体 
    /// </summary>
    public partial class MED_CONFIGSET
    {
        public bool IsSync { get; set; } // 是否同步接口
        public dynamic AnesDocPageHours { get; set; } // 麻醉单每页显示的小时数
        public bool IsSyncByInpNo { get; set; } // 急诊根据住院号同步
        public bool DoubleSelect { get; set; } // 文书是否双击显示下拉
        public bool IsOpenCoordinationCall { get; set; }// 是否加载视频组件
        public bool DrugAutoStop { get; set; }  //是否加载视频组件
        public bool IsVerificationAudit { get; set; }  //是否手术过程中完成三方核查单
        public string DrugAutoStopOperationStatus { get; set; } //持续用药自动结束时的手术状态
        public string YouDaoRoomTitle { get; set; } //诱导室名称
        public string DrugShow { get; set; } //用药控件单点用药显示类型
        public string ProLonged { get; set; } //用药控件持续用药显示类型
        public string DrugLegend { get; set; } //用药图例显示类型
        //modified by joysola on 2018-3-26
        public string BloodLiquidShow { get; set; }//输液输血显示类型
        // modified end on 2018-3-26
        // modified by joysola on 2018-4-3 新增双面打印文书
        public string DoublePrintDocNames { get; set; }
        //modified end on 2018-4-3
        public bool IsModifyVitalSignShowDifferent { get; set; }//标记修改过的体征项
        public bool IsPACUProcess { get; set; }//是否启用PACU管理
        public bool IsUpdateScheduleStatus { get; set; }//是否更新排班程序状态
        public bool IsUpdateHisStatus { get; set; }//是否更新HIS手术状态
        public bool IsUpdateAnesCharge { get; set; }//是否回传麻醉收费信息
        public dynamic AnesthesiaNumber { get; set; }//麻醉编号
        public string PDFLocalUrl { get; set; }//PDF本地生成地址
        public string PDFServerUrl { get; set; }//PDF上传服务器地址
        public bool IsDeleteAfterCommitDoc { get; set; }//文书上传后否删除本地文件
        public string[] PostPDF_Names { get; set; }//文书是否上传列表
        public bool IsAutomaticArchiving { get; set; }//是否支持自动归档
        public dynamic ArchivOperAfterDay { get; set; }//自动归档期限
        public string[] DocNameCheckList { get; set; }//文书完整性检查清单
        public string PrintPageName { get; set; }//打印张数
        public decimal PrintPaperHeight { get; set; }//打印纸张长度
        public decimal PrintPaperWidth { get; set; }//打印纸张宽度
        public decimal PaperLeftOff { get; set; }//打印纸张  左侧预留
        public decimal PaperTopOff { get; set; }//打印纸张 上方预留
        public bool IsOpenPatConfirm { get; set; }//是否启用患者核对模块
        public string DeptCodeStr { get; set; }//手术医生科室筛选

        public List<ShortCuts> ShortCuts { get; set; }//一体机快捷键设置

        public string ExamAddress { get; set; }//检查结果调阅地址

        public string DocumentAddress { get; set; }//病历病程调阅地址



        public string AnesShiftDrugList { get; set; }//麻醉交班用药配置

        public decimal AnesShiftEmergencyPatCount { get; set; }//麻醉交班急诊患者显示行数配置
    }

    public class ShortCuts
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}