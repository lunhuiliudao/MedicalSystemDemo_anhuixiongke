namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 术前访视(检验部分);每条手术对应一条术前访视记录，存放术前访视的病史部分信息。既往病史past medical history
    /// </summary>
    [Table("MED_ANESTHESIA_PLAN_EXAM")]
    public partial class MED_ANESTHESIA_PLAN_EXAM : BaseModel
    {
        /// <summary>
        /// 主键 病人id;	非空，唯一确定手术病人
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 住院次数;	病人每次住院加1
        /// </summary>
        [Key]
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 主键 手术号;一个病人一次住院期间手术的标识，从1开始顺序排列
        /// </summary>
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 心率;	单位“次/分”
        /// </summary>
        public Nullable<Int32> CARDIOTACH { get; set; }
        /// <summary>
        /// 	脉搏;	单位“次/分”
        /// </summary>
        public Nullable<Int32> PLUS { get; set; }
        /// <summary>
        /// 呼吸;	单位“次/分”
        /// </summary>
        public Nullable<Int32> BREATH { get; set; }
        /// <summary>
        /// 体温
        /// </summary>
        public string TEMPETURE { get; set; }
        /// <summary>
        /// 意识;	清醒、嗜睡、昏迷
        /// </summary>
        public string CONSCIOUSNESS { get; set; }
        /// <summary>
        /// 	高血压
        /// </summary>
        public Nullable<Int32> BLOOD_PRESS_HIGH { get; set; }
        /// <summary>
        /// 低血压
        /// </summary>
        public Nullable<Int32> BLOOD_PRESS_LOW { get; set; }
        /// <summary>
        /// 血压;	冗余字段。原有PC界面可以快速/,一体机数据不方便，所以分开两个字段输入。
        /// </summary>
        public string BLOOD_PRESS { get; set; }
        /// <summary>
        /// 头颈部;	无异常/疤痕/颈短/颈部肿块/后仰困难
        /// </summary>
        public string CERVIX { get; set; }
        /// <summary>
        /// 	口腔检查;	指松动、假牙、缺牙情况
        /// </summary>
        public string TOOTH_EXAM { get; set; }
        /// <summary>
        /// 	张口宽度;	一般填写张口**指
        /// </summary>
        public string MOUTH_OPEN_WIDTH { get; set; }
        /// <summary>
        /// 心肺听诊
        /// </summary>
        public string SOUND_OF_HEART_AND_LUNG { get; set; }
        /// <summary>
        /// 	肢力位置;	上肢体/下肢体
        /// </summary>
        public string LIMB_INDICATOR { get; set; }
        /// <summary>
        /// 肢力及感觉;	无异常、左/右感觉异常、左/右肢力减退
        /// </summary>
        public string LIMB_FEEL { get; set; }
        /// <summary>
        /// 	肺功能;	正常/阻塞性、限制性通气功能障碍/弥散障碍
        /// </summary>
        public string LUNG { get; set; }
        /// <summary>
        /// 	胸片或血透
        /// </summary>
        public string EXAM_X { get; set; }
        /// <summary>
        /// 肝功能;	1-正常、0-异常
        /// </summary>
        public string LIVER_INDICATOR { get; set; }
        /// <summary>
        /// 肝功能异常描述
        /// </summary>
        public string LIVER { get; set; }
        /// <summary>
        /// 肾功能;	1-正常、0-异常
        /// </summary>
        public string KIDNEY_INDICATOR { get; set; }
        /// <summary>
        /// 肾功能异常描述
        /// </summary>
        public string KIDNEY { get; set; }
        /// <summary>
        /// 气道
        /// </summary>
        public string AIRWAY { get; set; }
        /// <summary>
        /// 牙齿
        /// </summary>
        public string TOOTH { get; set; }
        /// <summary>
        /// 胸
        /// </summary>
        public string HEART { get; set; }
        /// <summary>
        /// 腹
        /// </summary>
        public string ABDOMEN { get; set; }
        /// <summary>
        /// HB血红蛋白
        /// </summary>
        public string LAB_HGB { get; set; }
        /// <summary>
        /// K+ 钾
        /// </summary>
        public string LAB_K { get; set; }
        /// <summary>
        /// Na 钠	
        /// </summary>
        public string LAB_NA { get; set; }
        /// <summary>
        /// CL 氯
        /// </summary>
        public string LAB_CL { get; set; }
        /// <summary>
        /// CA 钙
        /// </summary>
        public string LAB_CA { get; set; }
        /// <summary>
        /// 血糖
        /// </summary>
        public string LAB_GIU { get; set; }
        /// <summary>
        /// Cr肌酐
        /// </summary>
        public string LAB_CR { get; set; }
        /// <summary>
        /// Hct 红细胞压积
        /// </summary>
        public string LAB_HCT { get; set; }
        /// <summary>
        /// 尿常规	
        /// </summary>
        public string ROUTINE_URINE { get; set; }
        /// <summary>
        /// 心电图 ECG
        /// </summary>
        public string ECG_EXAM { get; set; }
        /// <summary>
        /// 红细胞
        /// </summary>
        public string LAB_BLD { get; set; }
        /// <summary>
        /// 红细胞计数
        /// </summary>
        public string LAB_RBC { get; set; }
        /// <summary>
        /// 平均红细胞积压
        /// </summary>
        public string LAB_MCV { get; set; }
        /// <summary>
        /// 血小板计数
        /// </summary>
        public string LAB_PLT { get; set; }
        /// <summary>
        /// 出血时间
        /// </summary>
        public string BLEEDING_TIME { get; set; }
        /// <summary>
        /// 	凝血时间
        /// </summary>
        public string CRUOR_TIME { get; set; }
        /// <summary>
        /// 白细胞
        /// </summary>
        public string LAB_LEU { get; set; }
        /// <summary>
        /// 白细胞计数
        /// </summary>
        public string LAB_WBC { get; set; }
        /// <summary>
        /// 谷丙转氨酶
        /// </summary>
        public string LAB_ALT { get; set; }
        /// <summary>
        /// 谷草转氨酶
        /// </summary>
        public string LAB_AST { get; set; }
        /// <summary>
        /// 尿素氮
        /// </summary>
        public string LAB_BUN { get; set; }
        /// <summary>
        /// 白蛋白
        /// </summary>
        public string LAB_ALB { get; set; }
        /// <summary>
        /// 胆红素
        /// </summary>
        public string LAB_BIL { get; set; }
        /// <summary>
        /// 其他
        /// </summary>
        public string OTHER { get; set; }
        /// <summary>
        /// 活动能力
        /// </summary>
        public string MOVEMENTS { get; set; }
        /// <summary>
        /// 神经;1-正常、0-异常
        /// </summary>
        public string HEART_INDICATOR { get; set; }
        /// <summary>
        /// 心功能描述
        /// </summary>
        public string HEART_DESCRIBE { get; set; }
        public string NERVOUS_DESCRIBE { get; set; }
        /// <summary>
        /// 凝血项目
        /// </summary>
        public string CRUOR_ITEM { get; set; }
        /// <summary>
        /// 心脏超声 UCG
        /// </summary>
        public string UCG_EXAM { get; set; }
    }
}