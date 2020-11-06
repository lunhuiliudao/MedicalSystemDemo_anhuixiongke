
using System;
using System.Collections.Generic;
using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.Services;
using MedicalSystem.Common.SecretManage;
using MedicalSystem.AnesWorkStation.Domain.RequestResult;
using System.Xml;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IPacuSyncInfoService
    {
        string SyncPatientInfoAndInHospital(string patientID);
        string SyncScheduleInfo(string patientID, DateTime operDateTime);
        string SyncPatientInfoAndInHospitalByInpNo(string inpNo);
        string SyncWriteHisOper(string patientID, int visitID, int operID);
        string SyncWriteHisOperStatus(string patientID, int visitID, int operID, int state);
        string SaveOperScheduleStateToHis(string patientID, int visitID, int operID, string State);
        string SyncScheduleInfoByDeptCode(string performedcode);
        string SyncScheduleInfo(string patientID);
        string SyncScheduleInfoByDateDiff(string patientID, int dateDiff);
        string SyncScheduleInfoByDateTime(string patientID, DateTime startTime, DateTime endTime);
        string SyncLis(string patientID, EventHandler eventHandle);
        string SyncLisByVisitID(string patientID, decimal visitID, EventHandler eventHandle);
        string SyncPACS(string patientID, decimal visitID, EventHandler eventHandle);
        string SyncEMR(string patientID, decimal visitID, EventHandler eventHandle);

        string SyncOPER505W(MED_EMR_ARCHIVE_DETIAL medEmrArchiveDetial);

        string SyncOPER503W(string patientID, int visitId, int operId, int operStatus);

        string SyncOrderInfo(string patientID, int visitID);
    }


    public class PacuSyncInfoService : BaseService<PacuSyncInfoService>, IPacuSyncInfoService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected PacuSyncInfoService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public PacuSyncInfoService(IDapperContext context)
            : base(context)
        {
        }

        private string RunInterFace(string strapptype, string assystemclass, string asinterfacetype, InterFaceV4.ParmInputData parmIn)
        {
            return InterFaceV4.InterFaceV4.of_systeminterface(strapptype, assystemclass, asinterfacetype, parmIn);
        }
        private static void RecordInterFaceLog(string strapptype, string assystemclass, string asinterfacetype, string parmInData)
        {
            bool bRecordInterfaceLog = false;
            try
            {
                //System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //string value = config.AppSettings.Settings["RecordInterfaceLog"].Value;
                //if (!bool.TryParse(value, out bRecordInterfaceLog))
                //{
                //    bRecordInterfaceLog = false;
                //}
            }
            catch (Exception ex)
            {
                // Logger.Write("RecordInterFaceLog Read key RecordInterfaceLog Err " + ex.StackTrace);
            }

            if (bRecordInterfaceLog)
            {
                //  Logger.Write("调用接口，传入参数 【AppType】:" + strapptype + " ，【SyatemClass】:" + assystemclass + "，【InterfaceType】:" + asinterfacetype + "，【ParmInputData】:" + parmInData);

            }
        }

        ///<summary>
        /// 同步单病人基本信息及住院信息
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public string SyncPatientInfoAndInHospital(string patientID)
        {
            if (!string.IsNullOrEmpty(patientID))
            {

                InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();

                paramIn.Patient.PatientId = patientID;

                paramIn.Code = "HIS101";

                string parmInString = "";

                parmInString = "patientID : " + paramIn.Patient.PatientId;

                RecordInterFaceLog("ANESMGR", "HIS", "HIS101", parmInString);

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

            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();

            if (!string.IsNullOrEmpty(patientID))
            {
                paramIn.Patient.PatientId = patientID;
            }
            else
            {
                paramIn.Patient.PatientId = "ALL";
            }

            paramIn.Code = "HIS201";

            paramIn.Operation.StartDataTime = DateTime.Parse(operDateTime.ToString("yyyy-MM-dd") + " 00:00:00");
            paramIn.Operation.StopDataTime = DateTime.Parse(operDateTime.ToString("yyyy-MM-dd") + " 23:59:59");


            string parmInString = "";

            parmInString = "patientID : " + paramIn.Patient.PatientId;

            RecordInterFaceLog("ANESMGR", "HIS", "HIS201", parmInString);

            string ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));
            return ret;

        }

        /// <summary>
        /// 同步单病人基本信息及住院信息
        /// </summary>
        /// <param name="inpno">住院号</param>
        /// <returns></returns>
        public string SyncPatientInfoAndInHospitalByInpNo(string inpNo)
        {
            if (!string.IsNullOrEmpty(inpNo))
            {

                InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();

                paramIn.Patient.InpNo = inpNo;
                paramIn.Code = "HIS104";


                string parmInString = "";

                parmInString = "inpNo : " + paramIn.Patient.InpNo;

                RecordInterFaceLog("ANESMGR", "HIS", "HIS104", parmInString);

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
        public string SyncWriteHisOper(string patientID, int visitID, int operID)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();

                paramIn.Patient.PatientId = patientID;
                paramIn.Patient.VisitId = (int)visitID;
                paramIn.Operation.OperId = operID;
                paramIn.Code = "HIS202";


                string parmInString = "";

                parmInString = "patientid : " + paramIn.Patient.PatientId;
                parmInString += " visitid : " + paramIn.Patient.VisitId;
                parmInString += " operid : " + paramIn.Operation.OperId;
                parmInString = "performedcode : " + paramIn.Code;

                RecordInterFaceLog("ANESMGR", "HIS", "HIS202", parmInString);

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
        public string SyncWriteHisOperStatus(string patientID, int visitID, int operID, int state)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();

                paramIn.Patient.PatientId = patientID;
                paramIn.Patient.VisitId = (int)visitID;
                paramIn.Operation.OperId = operID;


                switch (state)
                {
                    case 0:
                        paramIn.Code = "HIS202";
                        break;
                    case 1:
                        paramIn.Code = "HIS203";
                        break;
                    case 2:
                        paramIn.Code = "HIS212";
                        break;
                }

                string parmInString = "";

                parmInString = "patientid : " + paramIn.Patient.PatientId;
                parmInString += " visitid : " + paramIn.Patient.VisitId;
                parmInString += " operid : " + paramIn.Operation.OperId;
                parmInString = "performedcode : " + paramIn.Code;

                RecordInterFaceLog("ANESMGR", "HIS", paramIn.Code, parmInString);

                string ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));
                return ret;
            }
            else
            {
                return "空的患者ID";
            }
        }

        public string SaveOperScheduleStateToHis(string patientID, int visitID, int operID, string State)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                InterFaceV4.ParmInputData inputPara = new InterFaceV4.ParmInputData();
                inputPara.patientid = patientID;
                inputPara.visitid = visitID;
                inputPara.operid = operID;
                inputPara.reserved20 = State;
                string parmInString = "";
                parmInString = "patientid : " + inputPara.patientid;
                parmInString += " visitid : " + inputPara.visitid;
                parmInString += " operid : " + inputPara.operid;
                parmInString += " reserved20 : " + inputPara.reserved20;
                RecordInterFaceLog("ANESMGR", "HIS", "HIS211", parmInString);

                string ret = RunInterFace("ANESMGR", "HIS", "HIS211", inputPara);
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
        public string SyncScheduleInfoByDeptCode(string performedcode)
        {
            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            paramIn.Code = performedcode;

            string parmInString = "";
            parmInString = "performedcode : " + paramIn.Code;
            RecordInterFaceLog("ANESMGR", "HIS", "HIS201", parmInString);

            string ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));
            return ret;

        }
        /// <summary>
        /// 同步病人申请或预约信息
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public string SyncScheduleInfo(string patientID)
        {
            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            paramIn.Code = "HIS201";

            if (!string.IsNullOrEmpty(patientID))
            {
                paramIn.Patient.PatientId = patientID;

            }
            else
            {
                paramIn.Patient.PatientId = "ALL";
            }

            paramIn.Operation.StartDataTime = DateTime.Parse(DateTime.Today.ToString("yyyy-MM-dd") + " 00:00:00");
            paramIn.Operation.StopDataTime = DateTime.Parse(DateTime.Today.AddDays(3).ToString("yyyy-MM-dd") + " 23:59:59");
            string parmInString = "";
            parmInString = "patientid : " + paramIn.Patient.PatientId;
            parmInString += " startdatetime : " + paramIn.Operation.StartDataTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            parmInString += " stopdatetime : " + paramIn.Operation.StopDataTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            RecordInterFaceLog("ANESMGR", "HIS", "HIS201", parmInString);

            string ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));
            return ret;


        }
        /// <summary>
        /// 同步病人申请或预约信息
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public string SyncScheduleInfoByDateDiff(string patientID, int dateDiff)
        {

            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            paramIn.Code = "HIS201";

            if (!string.IsNullOrEmpty(patientID))
            {
                paramIn.Patient.PatientId = patientID;

            }
            else
            {
                paramIn.Patient.PatientId = "ALL";
            }

            paramIn.Operation.StartDataTime = DateTime.Parse(DateTime.Today.ToString("yyyy-MM-dd") + " 00:00:00");
            paramIn.Operation.StopDataTime = DateTime.Parse(DateTime.Today.AddDays(dateDiff).ToString("yyyy-MM-dd") + " 23:59:59");
            string parmInString = "";
            parmInString = "patientid : " + paramIn.Patient.PatientId;
            parmInString += " startdatetime : " + paramIn.Operation.StartDataTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            parmInString += " stopdatetime : " + paramIn.Operation.StopDataTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            RecordInterFaceLog("ANESMGR", "HIS", "HIS201", parmInString);

            string ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));
            return ret;


        }

        /// <summary>
        /// 同步病人申请或预约信息
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public string SyncScheduleInfoByDateTime(string patientID, DateTime startTime, DateTime endTime)
        {

            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            paramIn.Code = "HIS201";

            if (!string.IsNullOrEmpty(patientID))
            {
                paramIn.Patient.PatientId = patientID;

            }
            else
            {
                paramIn.Patient.PatientId = "ALL";
            }

            paramIn.Operation.StartDataTime = startTime;
            paramIn.Operation.StopDataTime = endTime;
            string parmInString = "";
            parmInString = "patientid : " + paramIn.Patient.PatientId;
            parmInString += " startdatetime : " + paramIn.Operation.StartDataTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            parmInString += " stopdatetime : " + paramIn.Operation.StopDataTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            RecordInterFaceLog("ANESMGR", "HIS", "HIS201", parmInString);

            string ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));
            return ret;

        }

        private EventHandler _eventHandle = null;
        /// <summary>
        /// 根据病人ID提取同步检验信息
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="eventHandle"></param>
        public string SyncLis(string patientID, EventHandler eventHandle)
        {
            string ret = "";
            _eventHandle = eventHandle;
            using (System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker())
            {
                worker.DoWork += delegate (object sender, System.ComponentModel.DoWorkEventArgs e)
                {

                    InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
                    paramIn.Code = "LIS001";

                    paramIn.Patient.PatientId = patientID;

                    string parmInString = "";
                    parmInString = "patientid : " + paramIn.Patient.PatientId;
                    RecordInterFaceLog("ANESMGR", "LIS", "LIS001", parmInString);

                    ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));

                };
                worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker.RunWorkerAsync();
            }
            return ret;
        }
        private void worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (_eventHandle != null)
            {
                _eventHandle(null, null);
            }
        }
        public string SyncLisByVisitID(string patientID, decimal visitID, EventHandler eventHandle)
        {
            string ret = "";
            _eventHandle = eventHandle;
            using (System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker())
            {
                worker.DoWork += delegate (object sender, System.ComponentModel.DoWorkEventArgs e)
                {
                    InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
                    paramIn.Code = "LIS001";

                    paramIn.Patient.PatientId = patientID;
                    paramIn.Patient.VisitId = (int)visitID;

                    string parmInString = "";
                    parmInString = "patientid : " + paramIn.Patient.PatientId;
                    parmInString += " visitid : " + paramIn.Patient.VisitId;
                    RecordInterFaceLog("ANESMGR", "LIS", "LIS001", parmInString);

                    ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));
                };
                worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker.RunWorkerAsync();
            }
            return ret;
        }
        public string SyncPACS(string patientID, decimal visitID, EventHandler eventHandle)
        {
            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            paramIn.Code = "PACS001";

            paramIn.Patient.PatientId = patientID;
            paramIn.Patient.VisitId = (int)visitID;
            paramIn.Operation.OperId = 1;
            paramIn.Operation.StartDataTime = System.DateTime.Today.AddDays(-1);
            paramIn.Operation.StopDataTime = System.DateTime.Today;
            string parmInString = "";
            parmInString = "patientid : " + paramIn.Patient.PatientId;
            parmInString += " visitid : " + paramIn.Patient.VisitId;
            parmInString += " operid : " + paramIn.Operation.OperId;
            parmInString += " startdatetime : " + paramIn.Operation.StartDataTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            parmInString += " stopdatetime : " + paramIn.Operation.StopDataTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            RecordInterFaceLog("ANESMGR", "PACS", "PACS001", parmInString);

            string ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));
            return ret;


        }
        public string SyncEMR(string patientID, decimal visitID, EventHandler eventHandle)
        {
            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            paramIn.Code = "EMR001";

            paramIn.Patient.PatientId = patientID;
            paramIn.Patient.VisitId = (int)visitID;
            string parmInString = "";
            parmInString = "patientid : " + paramIn.Patient.PatientId;
            parmInString += " visitid : " + paramIn.Patient.VisitId;
            RecordInterFaceLog("ANESMGR", "EMR", "EMR001", parmInString);

            string ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));
            return ret;
        }

        public string SyncOPER505W(MED_EMR_ARCHIVE_DETIAL medEmrArchiveDetial)
        {
            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            paramIn.Code = "OPER505W";
            paramIn.Patient.PatientId = medEmrArchiveDetial.PATIENT_ID;
            paramIn.Patient.VisitId = (decimal)medEmrArchiveDetial.VISIT_ID;
            paramIn.EmrDocUpLoad.MrClass = medEmrArchiveDetial.MR_CLASS;
            paramIn.EmrDocUpLoad.MrSubClass = medEmrArchiveDetial.MR_SUB_CLASS;
            paramIn.EmrDocUpLoad.ArchiveKey = decimal.Parse(medEmrArchiveDetial.ARCHIVE_KEY);
            paramIn.EmrDocUpLoad.ArchiveTimes = (decimal)medEmrArchiveDetial.ARCHIVE_TIMES;
            paramIn.EmrDocUpLoad.EmrFileIndex = (decimal)medEmrArchiveDetial.EMR_FILE_INDEX;
            paramIn.EmrDocUpLoad.EmrFileName = medEmrArchiveDetial.EMR_FILE_NAME;
            string ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));
            return ret;
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
            catch (Exception ex)
            {
                Logger.Error("解析接口返回信息错误：", ex);
            }

            return string.Empty;
        }

        public string SyncOPER503W(string patientID, int visitId, int operId, int operStatus)
        {
            InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
            paramIn.Code = "OPER503W";
            paramIn.Patient.PatientId = patientID;
            paramIn.Patient.VisitId = (decimal)visitId;
            paramIn.Operation.OperId = (decimal)operId;
            paramIn.Operation.OperStatus = (decimal)operStatus;
            string ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));
            return ret;
        }

        /// <summary>
        /// 同步单病人医嘱信息
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public string SyncOrderInfo(string patientID, int visitID)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
                paramIn.Code = "HIS103";

                paramIn.Patient.PatientId = patientID;
                paramIn.Patient.VisitId = visitID;
                string parmInString = "";
                parmInString = "patientid : " + paramIn.Patient.PatientId;
                parmInString += " visitid : " + paramIn.Patient.VisitId;
                RecordInterFaceLog("ANESMGR", "HIS", "HIS103", parmInString);

                string ret = GetRetFromSync(InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson()));
                return ret;
            }
            else
            {
                return "空的患者ID";
            }
        }
    }
}
