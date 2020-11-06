using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Json;

namespace InterFaceV5
{

    public class ParamInputDomain
    {
        private Patient patient = null;
        /// <summary>
        /// 患者信息
        /// </summary>
        public Patient Patient
        {
            get
            {
                if (patient == null)
                {
                    patient = new Patient();
                }
                return patient;
            }
            set
            {
                patient = value;
            }
        }

        private OperatorBase operatorBase = null;

        /// <summary>
        /// 操作人员相关信息
        /// </summary>
        public OperatorBase OperatorBase
        {
            get
            {
                if (operatorBase == null)
                {
                    operatorBase = new OperatorBase();
                }
                return operatorBase;
            }
            set
            {
                operatorBase = value;
            }

        }

        private Operation operation = null;
        /// <summary>
        /// 手术信息相关
        /// </summary>
        public Operation Operation
        {
            get
            {
                if (operation == null)
                {
                    operation = new Operation();
                }
                return operation;
            }
            set
            {
                operation = value;
            }
        }

        private Bar bar = null;
        /// <summary>
        /// 特殊器械
        /// </summary>
        public Bar Bar
        {
            get
            {
                if (bar == null)
                {
                    bar = new Bar();
                }
                return bar;

            }
            set
            {
                bar = value;
            }
        }

        private EmrDocUpLoad emrDocUpLoad = null;

        /// <summary>
        /// 文书回传
        /// </summary>
        public EmrDocUpLoad EmrDocUpLoad
        {
            get
            {
                if (emrDocUpLoad == null)
                {
                    emrDocUpLoad = new EmrDocUpLoad();
                }
                return emrDocUpLoad;
            }
            set
            {
                emrDocUpLoad = value;
            }
        }

        private ErrInfo errinfo = null;
        public ErrInfo ErrInfo
        {
            get
            {
                if (errinfo == null)
                {
                    errinfo = new ErrInfo();
                }
                return errinfo;

            }
            set
            {

                errinfo = value;
            }

        }

        private LabTest labTest = null;

        /// <summary>
        /// 检验单号
        /// </summary>
        public LabTest LabTest
        {
            get
            {
                if (labTest == null)
                {
                    labTest = new LabTest();
                }
                return labTest;

            }
            set
            {
                labTest = value;
            }

        }


        /// <summary>
        /// 厂商名称
        /// </summary>
        public string Coltd
        {
            get;
            set;
        }

        /// <summary>
        /// 应用系统系统缩写，如电子病历、手术系统等
        /// </summary>
        public string App
        {
            get;
            set;
        }

        /// <summary>
        /// 编码，类似HIS001
        /// </summary>
        public string Code
        {
            get;
            set;
        }

        /// <summary>
        /// XML/JSON/HL7
        /// </summary>
        public string MsgType
        {
           get;set;
        }

        /// <summary>
        /// 是否同步插入数据库0-是，1-否,全部2 ,默认0
        /// </summary>
        public decimal  Route
        {
            get;set;
        }

        /// <summary>
        /// 病区编码
        /// </summary>
        public string  HospitalBranch 
        {
          get;
          set;
        }

         /// <summary>
        /// 
        /// </summary> /// </summary>
        public string Reserved1
        {
            get;
            set;
        }
        

        /// <summary>
        /// 备用字段2
        /// </summary>
        public string Reserved2
        {
            get;
            set;
        }

        /// <summary>
        ///  /// <summary>
        /// 备用字段3
        /// </summary>
        /// </summary>
        public string Reserved3
        {
            get;
            set;
        }

        /// <summary>
        ///  /// <summary>
        /// 备用字段4
        /// </summary>
        /// </summary>
        public string Reserved4
        {
            get;
            set;
        }

        /// <summary>
        ///  /// <summary>
        /// 备用字段5
        /// </summary>
        /// </summary>
        public string Reserved5
        {
            get;
            set;
        }

        /// <summary>
        ///  备用字段6
        /// </summary>
        public string Reserved6
        {
            get;
            set;
        }

        /// <summary>
        ///  备用字段7
        /// </summary>
        public string Reserved7
        {
            get;
            set;
        }

        /// <summary>
        ///  备用字段8
        /// </summary>
        public string Reserved8
        {
            get;
            set;
        }

        /// <summary>
        ///  /// <summary>
        ///  备用字段9
        /// </summary>
        /// </summary>
        public string Reserved9
        {
            get;
            set;
        }

        /// <summary>
        ///  /// <summary>
        ///  备用字段10
        /// </summary>
        /// </summary>
        public string Reserved10
        {
            get;
            set;
        }

        /// <summary>
        ///  /// <summary>
        ///  /// <summary>
        /// xml ，josn ,hl7 消息载体
        /// </summary>
        /// </summary>
        /// </summary>
        public string SendMessage
        {
            get;
            set;
        }

        /// <summary>
        /// 接收的消息
        /// </summary>
        public string ReceiveMessage
        {
            get;
            set;
        }

        /// <summary>
        /// 返回值
        /// </summary>
        public string Result
        {
            get;
            set;
        }

        /// <summary>
        /// 是否客户端打开
        /// </summary>
        public bool OpenClient
        { get; set; }


        public string ToJson()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string jsonString = ser.Serialize(this);
            string p = @"\\/Date(\d+)\+\d+\\/";
            MatchEvaluator matchEvaluator = new MatchEvaluator(ConvertJsonDateToDateString);
            Regex reg = new Regex(p);
            jsonString = reg.Replace(jsonString, matchEvaluator);
            return jsonString;
        }

        private static string ConvertJsonDateToDateString(Match m)
        {
            string result = string.Empty;
            DateTime dt = new DateTime(1970, 1, 1, 16, 0, 0);
            dt = dt.AddMilliseconds(long.Parse(m.Groups[1].Value));
            dt = dt.ToLocalTime();
            result = dt.ToString("yyyy-MM-dd HH:mm:ss");
            return result;
        }
 
        //private static string ConvertDateStringToJsonDate(Match m)
        //{
        //    string result = string.Empty;
        //    DateTime dt = DateTime.Parse(m.Groups[0].Value);
        //    dt = dt.ToUniversalTime();
        //    TimeSpan ts = dt - DateTime.Parse("1970-01-01");
        //    result = string.Format("\\/Date({0}+0800)\\/", ts.TotalMilliseconds);
        //    return result;
        //}
    }

    /// <summary>
    /// 操作员信息
    /// </summary>
    public class OperatorBase
    {
        /// <summary>
        /// 操作工号
        /// </summary>
        public string Operator
        {
            get;
            set;
        }

        /// <summary>
        /// 操作员所属科室
        /// </summary>
        public string OperatorDept
        {
            get;
            set;
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        public Nullable<DateTime> OperateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 平台用户名
        /// </summary>
        public string UserID
        {
            get;
            set;
        }

        /// <summary>
        /// 平台密码
        /// </summary>
        public string PWD
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 患者信息
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PatientId
        {
            get;
            set;
        }

        /// <summary>
        /// 住院次数
        /// </summary>
        public Nullable<decimal> VisitId
        {
            get;
            set;
        }

        /// <summary>
        /// 手术次数
        /// </summary>
        public Nullable<decimal> OperId
        {
            get;
            set;
        }

        /// <summary>
        /// 住院号
        /// </summary>
        public string InpNo
        {
            get;
            set;
        }
        /// <summary>
        /// 病区代码
        /// </summary>
        public string WardCode
        {
            get;
            set;
        }

        /// <summary>
        /// 科室代码
        /// </summary>
        public string DeptCode
        {
            get;
            set;
        }

        public Nullable<decimal> DEP_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        ///结束时间
        /// </summary>
        public DateTime StopDate { get; set; }
    }

    /// <summary>
    /// 手术相关信息
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// 手术申请单号
        /// </summary>
        public Nullable<decimal> ScheduleId
        {
            get;
            set;
        }

        public Nullable<decimal> OperId
        {
            get;
            set;
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public Nullable<DateTime> StartDataTime
        {
            get;
            set;
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public Nullable<DateTime> StopDataTime
        {
            get;
            set;
        }

        ///费用类别</>0-手术；1-麻醉
        public Nullable<decimal> BillAtr
        {
            get;
            set;
        }


        ///手术阶段，术前，术中，术后
        public string OperStep
        {
            get;
            set;
        }

        /// <summary>
        /// >手术状态
        /// </summary>
        public Nullable<decimal> OperStatus
        {
            get;
            set;
        }

        /// <summary>
        /// 当前科室
        /// </summary>
        public string Performedcode
        {
            get;
            set;
        }

        /// <summary>
        /// his 住院次数
        /// </summary>
        public string HisVisitId { get; set; }

        /// <summary>
        /// his 手术申请单号
        /// </summary>
        public string HisScheduleId { get; set; }
    }

    /// <summary>
    /// 器械
    /// </summary>
    public class Bar
    {
        /// <summary>
        /// 器械条形码
        /// </summary>
        public string BarCode
        {
            get;
            set;
        }

        /// <summary>
        /// 条形码扩展信息
        /// </summary>
        public string BarParm
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 文书回传
    /// </summary>
    public class EmrDocUpLoad
    {
        public string MrClass
        {
            get;
            set;
        }

        public string MrSubClass
        {
            get;
            set;
        }

        public Nullable<decimal> ArchiveKey
        {
            get;
            set;
        }

        public Nullable<decimal> ArchiveTimes
        {
            get;
            set;
        }

        public Nullable<decimal> EmrFileIndex
        {
            get;
            set;
        }

        public string EmrFileName
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 错误信息
    /// </summary>
    public class ErrInfo
    {
        public bool Flag
        {
            get;
            set;
        }

        public string ErrMsg
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 检验信息
    /// </summary>
    public class LabTest
    {
        public string TestNo { get; set; }
    }


}
