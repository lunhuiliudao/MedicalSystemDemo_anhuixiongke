using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedicalSystem.DataServices.WebApi;
using Dapper.Data;
using System.Xml;
using MedicalSystem.Services;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 账号接口
    /// </summary>
    public interface ISyncInfoService
    {
        string SyncLis(string patientID, EventHandler eventHandle);
        string SyncPatientInfoAndInHospital(string patientID);
        string SyncScheduleInfo(string patientID, DateTime operDateTime);
        string SyncLis(string patientID, int visitId, EventHandler eventHandle);
        string SyncPACSNoAndType(string inpNo);
        string SyncAnesVisit(string patientID, int visitID, int operID);
    }

    public class SyncInfoService : BaseService<SyncInfoService>
    {
        /// <summary>
        /// 后台处理完成后事件
        /// </summary>
        private EventHandler _eventHandle = null;

        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected SyncInfoService()
            : base() { }

        public SyncInfoService(IDapperContext context)
            : base(context)
        {
        }

        ///<summary>
        /// 同步单病人基本信息及住院信息
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        [HttpGet]
        public string SyncPatientInfoAndInHospital(string patientID)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
                paramIn.Code = "PAT101";
                paramIn.App = "手麻系统";
                paramIn.OperatorBase.Operator = "操作人";
                paramIn.OperatorBase.OperatorDept = "操作人所属科室";

                paramIn.Patient.PatientId = patientID;
                string ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));
                return ret;
            }
            else
            {
                return "空的患者ID";
            }
        }

        /// <summary>
        /// 同步病人申请或预约信息
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public string SyncScheduleInfo(string patientID, DateTime operDateTime)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
                paramIn.Code = "OPER101";
                paramIn.App = "手麻系统";
                paramIn.OperatorBase.Operator = "操作人";
                paramIn.OperatorBase.OperatorDept = "操作人所属科室";

                paramIn.Patient.PatientId = patientID;
                paramIn.Operation.StartDataTime = DateTime.Parse(operDateTime.ToString("yyyy-MM-dd") + " 00:00:00"); ;
                paramIn.Operation.StopDataTime = DateTime.Parse(operDateTime.ToString("yyyy-MM-dd") + " 23:59:59");
                string ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));
                return ret;
            }
            else
            {
                return "空的患者ID";
            }
        }

        /// <summary>
        /// 同步单病人基本信息及住院信息
        /// </summary>
        /// <param name="inpno">住院号</param>
        /// <returns></returns>
        [HttpGet]
        public string SyncPatientInfoAndInHospitalByInpNo(string inpNo)
        {
            if (!string.IsNullOrEmpty(inpNo))
            {
                InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
                paramIn.Code = "PAT102";
                paramIn.App = "手麻系统";
                paramIn.OperatorBase.Operator = "操作人";
                paramIn.OperatorBase.OperatorDept = "操作人所属科室";

                paramIn.Patient.InpNo = inpNo;
                string ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));
                return ret;
            }
            else
            {
                return "空的住院号";
            }
        }
        /// <summary>
        /// 回写手术状态到HIS
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        [HttpGet]
        public string SyncWriteHisOper(string patientID, int visitID, int operID)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
                paramIn.Code = "PAT101";
                paramIn.App = "手麻系统";
                paramIn.OperatorBase.Operator = "操作人";
                paramIn.OperatorBase.OperatorDept = "操作人所属科室";

                paramIn.Patient.PatientId = patientID;
                paramIn.Patient.VisitId = visitID;
                paramIn.Operation.OperId = operID;
                string ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));
                return ret;
            }
            else
            {
                return "空的患者ID";
            }
        }
        /// <summary>
        /// 回写手术状态到HIS 202回写状态 203 回写信息 212 取消手术
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        [HttpGet]
        public string SyncWriteHisOperStatus(string patientID, int visitID, int operID, int state)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();

                string sycID = "";
                switch (state)
                {
                    case 0:
                        sycID = "OPER501W";
                        break;
                    case 1:
                        sycID = "OPER502W";
                        break;
                    case 2:
                        sycID = "OPER504W";
                        break;
                }
                paramIn.Code = sycID;
                paramIn.App = "手麻系统";
                paramIn.OperatorBase.Operator = "操作人";
                paramIn.OperatorBase.OperatorDept = "操作人所属科室";

                paramIn.Patient.PatientId = patientID;
                paramIn.Patient.VisitId = visitID;
                paramIn.Operation.OperId = operID;
                string ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));
                return ret;
            }
            else
            {
                return "空的患者ID";
            }
        }

        [HttpGet]
        public string SyncPACS(string patientID, decimal visitID, EventHandler eventHandle)
        {
            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            paramIn.Code = "PACS101";
            paramIn.App = "手麻系统";
            paramIn.OperatorBase.Operator = "操作人";
            paramIn.OperatorBase.OperatorDept = "操作人所属科室";
            paramIn.Patient.PatientId = patientID;
            paramIn.Patient.VisitId = visitID;
            paramIn.OpenClient = true;
            string ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));
            return ret;
        }

        [HttpGet]
        public string SyncPACSNoAndType(string inpNo)
        {
            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            paramIn.Code = "PACS01";
            paramIn.App = "手麻系统";
            paramIn.OperatorBase.Operator = "操作人";
            paramIn.OperatorBase.OperatorDept = "操作人所属科室";
            paramIn.Patient.InpNo = inpNo;
            paramIn.OpenClient = false;
            string strSync = InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson());
            Logger.Info("PACS01返回值：" + strSync);
            string ret = GetRetFromSync(strSync);
            return ret;
        }

        [HttpGet]
        public string SyncEMR(string patientID, decimal visitID, EventHandler eventHandle)
        {
            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            paramIn.Code = "EMR101";
            paramIn.App = "手麻系统";
            paramIn.OperatorBase.Operator = "操作人";
            paramIn.OperatorBase.OperatorDept = "操作人所属科室";
            paramIn.Patient.PatientId = patientID;
            paramIn.Patient.VisitId = visitID;
            paramIn.OpenClient = true;
            string ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));
            return ret;
        }

        [HttpGet]
        public string SyncAnesVisit(string patientID, int visitID, int operID)
        {
            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            paramIn.Code = "PAT201";
            paramIn.App = "手麻系统";
            paramIn.OperatorBase.Operator = "操作人";
            paramIn.OperatorBase.OperatorDept = "操作人所属科室";
            paramIn.Patient.PatientId = patientID;
            paramIn.Patient.VisitId = visitID;
            paramIn.Operation.OperId = operID;
            string ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));
            return ret;
        }

        /// <summary>
        /// 根据病人ID提取同步检验信息
        /// </summary>
        [HttpGet]
        public string SyncLis(string patientID, EventHandler eventHandle)
        {
            string ret = "";
            _eventHandle = eventHandle;
            using (System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker())
            {
                worker.DoWork += delegate(object sender, System.ComponentModel.DoWorkEventArgs e)
                {
                    InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
                    paramIn.Code = "LIS101";
                    paramIn.Patient.PatientId = patientID;
                    paramIn.Patient.VisitId = 1;
                    paramIn.App = "手麻系统";
                    ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));

                };
                worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker.RunWorkerAsync();
            }
            return ret;
        }

        /// <summary>
        /// 根据病人ID提取同步检验信息
        /// </summary>
        [HttpGet]
        public string SyncLis(string patientID, int visitId, EventHandler eventHandle)
        {
            string ret = "";
            _eventHandle = eventHandle;
            using (System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker())
            {
                worker.DoWork += delegate(object sender, System.ComponentModel.DoWorkEventArgs e)
                {
                    InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
                    paramIn.Code = "LIS101";
                    paramIn.Patient.PatientId = patientID;
                    paramIn.Patient.VisitId = visitId;
                    paramIn.App = "手麻系统";
                    ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));

                };
                worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker.RunWorkerAsync();
            }
            return ret;
        }

        private string RunInterFace(string strapptype, string assystemclass, string asinterfacetype, InterFaceV5.ParamInputDomain parmIn)
        {
            //return InterFaceV5.InterFaceV5.of_systeminterface(strapptype, assystemclass, asinterfacetype, parmIn);
            return string.Empty;
        }

        private void worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (_eventHandle != null)
            {
                _eventHandle(null, null);
            }
        }

        /// <summary>
        /// 获取接口返回msg
        /// </summary>
        /// <param name="syncString"></param>
        /// <returns></returns>
        private string GetRetFromSync(string syncString)
        {
            try
            {
                // xml文件不能包含 & 符号
                syncString = syncString.Replace("&", "");
                XmlDocument dom = new XmlDocument();
                string ret = string.Empty;
                dom.LoadXml(syncString);
                XmlElement root = dom.DocumentElement;
                foreach (XmlNode node in root)
                {
                    if (node.Name == "msg")
                    {
                        ret = node.InnerText;
                        break;
                    }
                }

                return ret == null ? string.Empty : ret;
            }
            catch(Exception ex)
            {
                Logger.Error("解析接口返回信息错误：", ex);
            }

            return string.Empty;
        }
    }
}
