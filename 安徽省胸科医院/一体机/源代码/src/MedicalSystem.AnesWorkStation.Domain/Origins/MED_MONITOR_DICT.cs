namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 监护仪字典表
    /// </summary>
    [Table("MED_MONITOR_DICT")]
    public partial class MED_MONITOR_DICT : BaseModel
    {
        /// <summary>
        /// 主键 监护仪标示
        /// </summary>
        [Key]
        public string MONITOR_LABEL { get; set; }
        /// <summary>
        /// 厂家
        /// </summary>
        public string MANU_FIRM_NAME { get; set; }
        /// <summary>
        /// 型号	;确定采用何种采集协议
        /// </summary>
        public string MODEL { get; set; }
        /// <summary>
        /// 	接口类型	;0-RS232串口,1-RJ45
        /// </summary>
        public Nullable<Int32> INTERFACE_TYPE { get; set; }
        /// <summary>
        /// 接口描述
        /// </summary>
        public string INTERFACE_DESC { get; set; }
        /// <summary>
        /// IP地址	
        /// </summary>
        public string IP_ADDR { get; set; }
        /// <summary>
        /// MAC地址
        /// </summary>
        public string MAC_ADDR { get; set; }
        /// <summary>
        /// 最近一次采集时间	
        /// </summary>
        public Nullable<DateTime> LAST_RECV_TIME { get; set; }
        /// <summary>
        /// 最近采集床号
        /// </summary>
        public string LAST_RECV_BED_ID { get; set; }
        /// <summary>
        /// 双攻标志	
        /// </summary>
        public Nullable<Int32> DUPLEX_FLAG { get; set; }
        /// <summary>
        /// 自动入库标志	
        /// </summary>
        public string AUTOIN_FLAG { get; set; }
        /// <summary>
        /// 通讯串口号	;连接仪器的本地计算机串口，非医疗设备上的串口号。（ 串口设备才填写）
        /// </summary>
        public string COMM_PORT { get; set; }
        /// <summary>
        /// 波特率	
        /// </summary>
        public Nullable<Int32> BAUD_RATE { get; set; }
        /// <summary>
        /// 数据位	
        /// </summary>
        public Nullable<Int32> BYTE_SIZE { get; set; }
        /// <summary>
        /// 校验类型
        /// </summary>
        public Nullable<Int32> PARITY { get; set; }
        /// <summary>
        /// 停止位	
        /// </summary>
        public Nullable<Int32> STOP_BITS { get; set; }
        /// <summary>
        /// 传送使用	
        /// </summary>
        public Nullable<Int32> F_OUTX { get; set; }
        /// <summary>
        /// 接收使用
        /// </summary>
        public Nullable<Int32> F_INX { get; set; }
        /// <summary>
        /// 流硬件控制	
        /// </summary>
        public Nullable<Int32> F_HARDWARE { get; set; }
        /// <summary>
        /// 传送队列大小	
        /// </summary>
        public Nullable<Int32> TX_QUEUESIZE { get; set; }
        /// <summary>
        /// 接收队列大小
        /// </summary>
        public Nullable<Int32> RX_QUEUESIZE { get; set; }
        /// <summary>
        /// XON阀值
        /// </summary>
        public Nullable<Int32> XON_LIM { get; set; }
        /// <summary>
        /// XOFF阀值
        /// </summary>
        public Nullable<Int32> XOFF_LIM { get; set; }
        /// <summary>
        /// XON字符
        /// </summary>
        public string XON_CHAR { get; set; }
        /// <summary>
        /// XOFF字符	
        /// </summary>
        public string XOFF_CHAR { get; set; }
        /// <summary>
        /// 错误替代字符	
        /// </summary>
        public string ERROR_CHAR { get; set; }
        /// <summary>
        /// 监控时间字符
        /// </summary>
        public string EVENT_CHAR { get; set; }
        /// <summary>
        /// 采集程序名称
        /// </summary>
        public string DRIVER_PROG { get; set; }
        /// <summary>
        /// 接口程序优先级
        /// </summary>
        public Nullable<Int32> PRIORITY { get; set; }
        /// <summary>
        /// 仪器起分类字母	
        /// </summary>
        public string ITEM_TYPE { get; set; }
        /// <summary>
        /// 自动装入联机接口程序	
        /// </summary>
        public Nullable<Int32> AUTO_LOAD { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public Nullable<DateTime> START_DATE_TIME { get; set; }
        /// <summary>
        /// 默认采集频率
        /// </summary>
        public Nullable<Int32> DEFAULT_RECV_FREQUENCY { get; set; }
        /// <summary>
        /// 当前采集频率	
        /// </summary>
        public Nullable<Int32> CURRENT_RECV_FREQUENCY { get; set; }
        /// <summary>
        /// 当前采集频率采集次数
        /// </summary>
        public Nullable<Int32> CURRENT_RECVTIMES_UPLIMIT { get; set; }
        /// <summary>
        /// 当前采集的生命体征	
        /// </summary>
        public string CURRENT_RECV_ITEMS { get; set; }
        /// <summary>
        /// 护理单元	
        /// </summary>
        public string WARD_CODE { get; set; }
        /// <summary>
        /// 单位类型	;0=手术室；1=术后复苏室（PACU）；2= 重症监护室(ICU、CCU)；3=手术室和PACU 共用； 4= 术前诱导室；5=急救车；6=血透室； 7= 供应室;8=产房；
        /// </summary>
        public Nullable<Int32> WARD_TYPE { get; set; }
        /// <summary>
        /// 床号	
        /// </summary>
        public string BED_NO { get; set; }
        /// <summary>
        /// 病人ID	;非空，唯一确定手术病人
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 入院次数	;	住院病人每次住院加1
        /// </summary>
        public Nullable<Int32> VISIT_ID { get; set; }
        /// <summary>
        /// 手术号	;一个病人一次住院期间手术的标识，从1开始顺序排列
        /// </summary>
        public Nullable<Int32> OPER_ID { get; set; }
        /// <summary>
        /// 再用标示
        /// </summary>
        public Nullable<Int32> USING_INDICATOR { get; set; }
        /// <summary>
        /// 采集频率	
        /// </summary>
        public Nullable<Int32> FREQUENCY_DISPLAY { get; set; }
        /// <summary>
        /// 备注	
        /// </summary>
        public string MEMO { get; set; }
        /// <summary>
        /// 数据记录开始时间	
        /// </summary>
        public Nullable<DateTime> DATALOG_START_TIME { get; set; }
        /// <summary>
        /// PC端口号	
        /// </summary>
        public Nullable<Int32> PC_PORT { get; set; }
        /// <summary>
        /// 状态	
        /// </summary>
        public string DATALOG_STATUS { get; set; }
        /// <summary>
        /// IP端口	
        /// </summary>
        public Nullable<Int32> IP_PORT { get; set; }
        /// <summary>
        /// 接收端口
        /// </summary>
        public Nullable<Int32> IN_PORT { get; set; }
        /// <summary>
        /// 发送端口
        /// </summary>
        public Nullable<Int32> OUT_PORT { get; set; }
        /// <summary>
        /// 床边采集程序的TCP服务IP地址	
        /// </summary>
        public string DATALOG_SERVERIP { get; set; }
        /// <summary>
        /// 数据采集的体征参数的服务端口	
        /// </summary>
        public Nullable<Int32> DATALOG_PARA_PORT { get; set; }
        /// <summary>
        /// 数据采集的生命波形的服务端口
        /// </summary>
        public Nullable<Int32> DATALOG_WAVE_PORT { get; set; }
        /// <summary>
        /// 数据采集的运行状态的服务端口
        /// </summary>
        public Nullable<Int32> DATALOG_STATUS_PORT { get; set; }
        /// <summary>
        /// 数据采集的需要用到的相关文件名	
        /// </summary>
        public string DATALOG_FILES { get; set; }
    }
}