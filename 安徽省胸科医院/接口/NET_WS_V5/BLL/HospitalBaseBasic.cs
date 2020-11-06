using InitDocare;
using MedicalSytem.Soft.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial class HospitalBase
    {

        string DateType = PublicA.GetConfig("DataServerType");//根据配置的数据库连接类型自动调用相应的方法来完成DoCare系统的数据插入、更新及删除操作

        #region DAL 实例

        private MedicalSytem.Soft.DAL.DALMedPatsInHospital medPatsInHospitalDALBASE = new MedicalSytem.Soft.DAL.DALMedPatsInHospital();
        private MedicalSytem.Soft.DAL.DALMedPatInicuInformation medPatInicuInformationDALBASE = new MedicalSytem.Soft.DAL.DALMedPatInicuInformation();
        private MedicalSytem.Soft.DAL.DALMedPatVisit medPatVisitDALBASE = new MedicalSytem.Soft.DAL.DALMedPatVisit();
        private MedicalSytem.Soft.DAL.DALMedPatMasterIndex medPatMasterIndexDALBASE = new MedicalSytem.Soft.DAL.DALMedPatMasterIndex();
        private MedicalSytem.Soft.DAL.DALMedVsHisPat medVsHisPatDALBASE = new MedicalSytem.Soft.DAL.DALMedVsHisPat();
        private MedicalSytem.Soft.DAL.DALMedVsHisDepId medVsHisDepIdDALBASE = new MedicalSytem.Soft.DAL.DALMedVsHisDepId();

        private MedicalSytem.Soft.DAL.DALMedOrders medOrdersDALBASE = new MedicalSytem.Soft.DAL.DALMedOrders();
        private MedicalSytem.Soft.DAL.DALMedVsHisOrders medVsHisOrdersDALBASE = new MedicalSytem.Soft.DAL.DALMedVsHisOrders();
        private MedicalSytem.Soft.DAL.DALMedVsHisOrderClass medVsHisOrderClassDALBASE = new MedicalSytem.Soft.DAL.DALMedVsHisOrderClass();
        private MedicalSytem.Soft.DAL.DALMedPerformDefaultSchedule medPerformDefaultScheduleDALBASE = new MedicalSytem.Soft.DAL.DALMedPerformDefaultSchedule();

        private MedicalSytem.Soft.DAL.DALMedIfTransDict medTransDictDALBASE = new MedicalSytem.Soft.DAL.DALMedIfTransDict();
        private MedicalSytem.Soft.DAL.DALMedTransfer medTransferDALBASE = new MedicalSytem.Soft.DAL.DALMedTransfer();
        private MedicalSytem.Soft.DAL.DALMedDeptDict medDeptDictDALBASE = new MedicalSytem.Soft.DAL.DALMedDeptDict();
        private MedicalSytem.Soft.DAL.DALMedDiagnosisDict medDiagnosisDALBASE = new MedicalSytem.Soft.DAL.DALMedDiagnosisDict();
        private MedicalSytem.Soft.DAL.DALMedHisUsers medHisUsersDALBASE = new MedicalSytem.Soft.DAL.DALMedHisUsers();
        private MedicalSytem.Soft.DAL.DALMedIFLog medIfLogDALBASE = new MedicalSytem.Soft.DAL.DALMedIFLog();
        private MedicalSytem.Soft.DAL.DALMedHisUserInfo medHisUsersInfoDALBASE = new MedicalSytem.Soft.DAL.DALMedHisUserInfo();
        private MedicalSytem.Soft.DAL.DALMedPriceList medPriceListDALBASE = new MedicalSytem.Soft.DAL.DALMedPriceList();
        private MedicalSytem.Soft.DAL.DALMedOperationDict medOperationDictDALBASE = new MedicalSytem.Soft.DAL.DALMedOperationDict();
        private MedicalSytem.Soft.DAL.DALMedBedRec medBedRecDALBASE = new MedicalSytem.Soft.DAL.DALMedBedRec();
        //增加DALMedMonitorDict 2011-5-4
        private MedicalSytem.Soft.DAL.DALMedMonitorDict medMonitorDictDALBASE = new MedicalSytem.Soft.DAL.DALMedMonitorDict();
        private MedicalSytem.Soft.DAL.DALMedIcuConfig medIcuConfigDALBASE = new MedicalSytem.Soft.DAL.DALMedIcuConfig();

        private MedicalSytem.Soft.DAL.DALMedOperationBillItems medOperationBillItemsDALBASE = new MedicalSytem.Soft.DAL.DALMedOperationBillItems();
        private MedicalSytem.Soft.DAL.DALMedVsHisOperBillConsts medVsHisOperBillConstsDALBASE = new MedicalSytem.Soft.DAL.DALMedVsHisOperBillConsts();
        private MedicalSytem.Soft.DAL.DALMedBillItemClassVsHis medBillItemClassVsHisDALBASE = new MedicalSytem.Soft.DAL.DALMedBillItemClassVsHis();
        private MedicalSytem.Soft.DAL.DALMedOperationSchedule medOperationScheduleDALBASE = new MedicalSytem.Soft.DAL.DALMedOperationSchedule();
        private MedicalSytem.Soft.DAL.DALMedOperationCanceled medOperationCanceledDALBASE = new MedicalSytem.Soft.DAL.DALMedOperationCanceled();
        private MedicalSytem.Soft.DAL.DALMedOperationNameCanceled medOperationNameCanceledDALBASE = new MedicalSytem.Soft.DAL.DALMedOperationNameCanceled();
        private MedicalSytem.Soft.DAL.DALMedScheduledOperationName medScheduleOperationNameDALBASE = new MedicalSytem.Soft.DAL.DALMedScheduledOperationName();
        private MedicalSytem.Soft.DAL.DALMedOperationMaster medOperationMasterDALBASE = new MedicalSytem.Soft.DAL.DALMedOperationMaster();
        private MedicalSytem.Soft.DAL.DALMedOperationName medOperationNameDALBASE = new MedicalSytem.Soft.DAL.DALMedOperationName();
        private MedicalSytem.Soft.DAL.DALMedOperationMasterAndName medOperationMasterAndNameDALBASE = new MedicalSytem.Soft.DAL.DALMedOperationMasterAndName();
        private MedicalSytem.Soft.DAL.DALMedVsHisOperApplyV2 medVsHisOperApplyV2DALBASE = new MedicalSytem.Soft.DAL.DALMedVsHisOperApplyV2();

        private MedicalSytem.Soft.DAL.DALMedLabTestMaster medLabTestMasterDALBASE = new MedicalSytem.Soft.DAL.DALMedLabTestMaster();
        private MedicalSytem.Soft.DAL.DALMedLabResult medLabResultDALBASE = new MedicalSytem.Soft.DAL.DALMedLabResult();
        private MedicalSytem.Soft.DAL.DALMedLabTestItems medLabTestItemsDALBASE = new MedicalSytem.Soft.DAL.DALMedLabTestItems();

        private MedicalSytem.Soft.DAL.DALMedDrugDict medDrugDictDALBASE = new MedicalSytem.Soft.DAL.DALMedDrugDict();
        private MedicalSytem.Soft.DAL.DALMedDrugNameDict medDrugNameDictDALBASE = new MedicalSytem.Soft.DAL.DALMedDrugNameDict();

        private MedicalSytem.Soft.DAL.DALMedMtrlDict medMtrlDictDALBASE = new MedicalSytem.Soft.DAL.DALMedMtrlDict();
        private MedicalSytem.Soft.DAL.DALMedMtrlSupplierCatalog medMtrlSupplierCatalogDALBASE = new MedicalSytem.Soft.DAL.DALMedMtrlSupplierCatalog();

        private MedicalSytem.Soft.DAL.DALMedMtrlImportMaster medMtrlImportMasterDALBASE = new MedicalSytem.Soft.DAL.DALMedMtrlImportMaster();
        private MedicalSytem.Soft.DAL.DALMedMtrlImportDetail medMtrlImportDetailDALBASE = new MedicalSytem.Soft.DAL.DALMedMtrlImportDetail();

        private MedicalSytem.Soft.DAL.DALMedEmrArchiveDetial medEmrArchiveDetialDALBASE = new MedicalSytem.Soft.DAL.DALMedEmrArchiveDetial();
        private MedicalSytem.Soft.DAL.DALMedEmrArchiveDetialExt medEmrArchiveDetialExtDALBASE = new MedicalSytem.Soft.DAL.DALMedEmrArchiveDetialExt();
        private MedicalSytem.Soft.DAL.DALMedEmrUsers medEmrUsersDALBASE = new MedicalSytem.Soft.DAL.DALMedEmrUsers();
        private MedicalSytem.Soft.DAL.DALMedEmrWorkPath medEmrWorkPathDALBASE = new MedicalSytem.Soft.DAL.DALMedEmrWorkPath();

        //SEMR系统
        private MedicalSytem.Soft.DAL.DALMedicalcases medicalcasesDALBASE = new MedicalSytem.Soft.DAL.DALMedicalcases();
        private MedicalSytem.Soft.DAL.DALPatients patientsDALBASE = new MedicalSytem.Soft.DAL.DALPatients();
        private MedicalSytem.Soft.DAL.DALUsers usersDALBASE = new MedicalSytem.Soft.DAL.DALUsers();


        //HIS数据放到DOCARE表中
        private MedicalSytem.Soft.DAL.DALMedIfHisViewSql medifhisviewsqlDALBASE = new MedicalSytem.Soft.DAL.DALMedIfHisViewSql();

        //供应室追溯系统
        private MedicalSytem.Soft.DAL.DALMedPackageMaster medpackagemasterDALBASE = new MedicalSytem.Soft.DAL.DALMedPackageMaster();
        private MedicalSytem.Soft.DAL.DALMedPackageDetail medpackagedetailDALBASE = new MedicalSytem.Soft.DAL.DALMedPackageDetail();

        //麻醉事件
        private MedicalSytem.Soft.DAL.DALMedAnesthesiaEvent medAnesthesiaEventDALBASE = new MedicalSytem.Soft.DAL.DALMedAnesthesiaEvent();

        //出入量和体征数据
        private MedicalSytem.Soft.DAL.DALMedInOrOutRec medInOrOutRecDALBASE = new MedicalSytem.Soft.DAL.DALMedInOrOutRec();
        private MedicalSytem.Soft.DAL.DALMedVitalSignsRecTemp medVitalSignsRecTempDALBASE = new MedicalSytem.Soft.DAL.DALMedVitalSignsRecTemp();

        private MedicalSytem.Soft.DAL.DALMedBloodGasMaster medBloodGasMasterDALBASE = new MedicalSytem.Soft.DAL.DALMedBloodGasMaster();

        private MedicalSytem.Soft.DAL.DALMedPatMonitorData medPatMonitorDataDALBASE = new MedicalSytem.Soft.DAL.DALMedPatMonitorData();

        private MedicalSytem.Soft.DAL.DALMedPatMonitorDataExt medPatMonitorExtDataDALBASE = new MedicalSytem.Soft.DAL.DALMedPatMonitorDataExt();

        #endregion

        #region 医嘱操作
        public virtual MedicalSytem.Soft.Model.MedOrders SelectMedOrders(string patientId, decimal visitId, string orderNo, decimal orderSubNo)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOrdersDALBASE.SelectMedOrdersOdbc(patientId, visitId, orderNo, orderSubNo);
                case "ORACLE":
                    return medOrdersDALBASE.SelectMedOrders(patientId, visitId, orderNo, orderSubNo);
                case "SQLSERVER":
                    return medOrdersDALBASE.SelectMedOrdersSQL(patientId, visitId, orderNo, orderSubNo);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOrdersDALBASE.SelectMedOrdersOLE(patientId, visitId, orderNo, orderSubNo);
                default:
                    return medOrdersDALBASE.SelectMedOrders(patientId, visitId, orderNo, orderSubNo);
            }
        }

        public virtual int InsertMedOrders(MedicalSytem.Soft.Model.MedOrders orders)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOrdersDALBASE.InsertMedOrdersOdbc(orders);
                case "ORACLE":
                    return medOrdersDALBASE.InsertMedOrders(orders);
                case "SQLSERVER":
                    return medOrdersDALBASE.InsertMedOrdersSQL(orders);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOrdersDALBASE.InsertMedOrdersOLE(orders);
                default:
                    return medOrdersDALBASE.InsertMedOrders(orders);
            }
        }

        public virtual int UpdateMedOrders(MedicalSytem.Soft.Model.MedOrders orders)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOrdersDALBASE.UpdateMedOrdersOdbc(orders);
                case "ORACLE":
                    return medOrdersDALBASE.UpdateMedOrders(orders);
                case "SQLSERVER":
                    return medOrdersDALBASE.UpdateMedOrdersSQL(orders);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOrdersDALBASE.UpdateMedOrdersOLE(orders);
                default:
                    return medOrdersDALBASE.UpdateMedOrders(orders);
            }
        }

        public virtual int DeletePatientOrders(string patientId, decimal visitId, string orderNo, decimal orderSubNo)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            return medOrdersDALBASE.DeleteMedOrders(patientId, visitId, orderNo, orderSubNo);

            //    case "ORACLE":
            //        return medOrdersDALBASE.DeleteMedOrders(patientId, visitId, orderNo, orderSubNo);

            //    case "SQLSERVER":
            //        return medOrdersDALBASE.DeleteMedOrdersSQL(patientId, visitId, orderNo, orderSubNo);

            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medOrdersDALBASE.DeleteMedOrders(patientId, visitId, orderNo, orderSubNo);

            //    default:
            //        return medOrdersDALBASE.DeleteMedOrders(patientId, visitId, orderNo, orderSubNo);

            //}
        }

        public virtual int DeletePatientOrders(string patientId, decimal visitId)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            return medOrdersDALBASE.DeleteMedOrders(patientId, visitId);
            //        
            //    case "ORACLE":

            //        
            //    case "SQLSERVER":

            //        
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":

            //        

            //    default:
            //        
            //}
        }
        #endregion
        #region 病人医嘱信息 Trans

        public virtual MedicalSytem.Soft.Model.MedOrders SelectMedOrders(string patientId, decimal visitId, string orderNo, decimal orderSubNo, DbConnection oleCisConn)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOrdersDALBASE.SelectMedOrdersOdbc(patientId, visitId, orderNo, orderSubNo);//, oleCisConn);
                case "ORACLE":
                    return medOrdersDALBASE.SelectMedOrders(patientId, visitId, orderNo, orderSubNo, oleCisConn);
                case "SQLSERVER":
                    return medOrdersDALBASE.SelectMedOrdersSQL(patientId, visitId, orderNo, orderSubNo);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOrdersDALBASE.SelectMedOrdersOLE(patientId, visitId, orderNo, orderSubNo);
                default:
                    return medOrdersDALBASE.SelectMedOrders(patientId, visitId, orderNo, orderSubNo, oleCisConn);
            }
        }

        public virtual int InsertMedOrders(MedicalSytem.Soft.Model.MedOrders orders, DbTransaction oleCisTrans)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOrdersDALBASE.InsertMedOrdersODBC(orders, oleCisTrans);
                case "ORACLE":
                    return medOrdersDALBASE.InsertMedOrders(orders, oleCisTrans);
                case "SQLSERVER":
                    return medOrdersDALBASE.InsertMedOrdersSQL(orders, oleCisTrans);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOrdersDALBASE.InsertMedOrdersOLE(orders, oleCisTrans);
                default:
                    return medOrdersDALBASE.InsertMedOrders(orders, oleCisTrans);
            }
        }

        public virtual int UpdateMedOrders(MedicalSytem.Soft.Model.MedOrders orders, DbTransaction oleCisTrans)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOrdersDALBASE.UpdateMedOrdersODBC(orders, oleCisTrans);
                case "ORACLE":
                    return medOrdersDALBASE.UpdateMedOrders(orders, oleCisTrans);
                case "SQLSERVER":
                    return medOrdersDALBASE.UpdateMedOrdersSQL(orders, oleCisTrans);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOrdersDALBASE.UpdateMedOrdersOLE(orders, oleCisTrans);
                default:
                    return medOrdersDALBASE.UpdateMedOrders(orders, oleCisTrans);
            }
        }

        public virtual int DeletePatientOrders(string patientId, decimal visitId, decimal orderNo, decimal orderSubNo, DbTransaction oleCisTrans)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            return medOrdersDALBASE.DeleteMedOrders(patientId, visitId, orderNo, orderSubNo, oleCisTrans);

            //    case "ORACLE":
            //    case "SQLSERVER":

            //        
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":

            //        

            //    default:
            //        
            //}
        }

        public virtual int DeletePatientOrders(string patientId, decimal visitId, DbTransaction oleCisTrans)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            return medOrdersDALBASE.DeleteMedOrders(patientId, visitId, oleCisTrans);
            //        
            //    case "ORACLE":
            //        return medOrdersDALBASE.DeleteMedOrders(patientId, visitId, oleCisTrans);
            //        
            //    case "SQLSERVER":
            //        return medOrdersDALBASE.DeleteMedOrders(patientId, visitId, oleCisTrans);
            //        
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medOrdersDALBASE.DeleteMedOrders(patientId, visitId, oleCisTrans);
            //        

            //    default:
            //        
            //}
        }
        #endregion

        #region 医嘱转换信息--考虑电子医嘱不是规范化
        /// <summary>
        /// 查询唯一一条医嘱对照信息
        /// </summary>
        /// <param name="medPatientId">病人ID号</param>
        /// <param name="medVisitId">病人住院次数</param>
        /// <param name="hisOrderNo">HIS医嘱序号</param>
        /// <param name="hisOrderSubNo">HIS医嘱组号</param>
        /// <param name="createDate"></param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedVsHisOrders SelectMedVsHisOrdersHis(string medPatientId, decimal medVisitId, string hisOrderNo, string hisOrderSubNo, DateTime createDate)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOrdersDALBASE.SelectMedVsHisOrdersHisODBC(medPatientId, medVisitId, hisOrderNo, hisOrderSubNo, createDate);
                case "ORACLE":
                    return medVsHisOrdersDALBASE.SelectMedVsHisOrdersHis(medPatientId, medVisitId, hisOrderNo, hisOrderSubNo, createDate);
                case "SQLSERVER":
                    return medVsHisOrdersDALBASE.SelectMedVsHisOrdersHisSQL(medPatientId, medVisitId, hisOrderNo, hisOrderSubNo, createDate);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOrdersDALBASE.SelectMedVsHisOrdersHisOLE(medPatientId, medVisitId, hisOrderNo, hisOrderSubNo, createDate);
                default:
                    return medVsHisOrdersDALBASE.SelectMedVsHisOrdersHisSQL(medPatientId, medVisitId, hisOrderNo, hisOrderSubNo, createDate);
            }
        }
        /// <summary>
        /// 查询唯一一条医嘱对照信息
        /// </summary>
        /// <param name="hisOrderNo">HIS医嘱序号</param>
        /// <param name="hisOrderSubNo">HIS医嘱组号</param>
        /// <param name="createDate">创建时间默认为(2009, 1, 1)</param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedVsHisOrders SelectMedVsHisOrdersHis(string hisOrderNo, string hisOrderSubNo, DateTime createDate)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOrdersDALBASE.SelectMedVsHisOrdersHisODBC(hisOrderNo, hisOrderSubNo, createDate);
                case "ORACLE":
                    return medVsHisOrdersDALBASE.SelectMedVsHisOrdersHis(hisOrderNo, hisOrderSubNo, createDate);
                case "SQLSERVER":
                    return medVsHisOrdersDALBASE.SelectMedVsHisOrdersHisSQL(hisOrderNo, hisOrderSubNo, createDate);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOrdersDALBASE.SelectMedVsHisOrdersHisOLE(hisOrderNo, hisOrderSubNo, createDate);
                default:
                    return medVsHisOrdersDALBASE.SelectMedVsHisOrdersHis(hisOrderNo, hisOrderSubNo, createDate);
            }
        }
        /// <summary>
        /// 查询唯一一条医嘱对照信息
        /// </summary>
        /// <param name="medPatientId">病人ID号</param>
        /// <param name="medVisitId">病人住院次数</param>
        /// <param name="medOrderNo">医嘱序号</param>
        /// <param name="medOrderSubNo">子医嘱序号</param>
        /// <param name="medRepeatIndicator">长期短期标识</param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedVsHisOrders SelectMedVsHisOrders(string medPatientId, decimal medVisitId, string medOrderNo, decimal medOrderSubNo, decimal medRepeatIndicator)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOrdersDALBASE.SelectMedVsHisOrdersODBC(medPatientId, medVisitId, medOrderNo, medOrderSubNo, medRepeatIndicator);
                case "ORACLE":
                    return medVsHisOrdersDALBASE.SelectMedVsHisOrders(medPatientId, medVisitId, medOrderNo, medOrderSubNo, medRepeatIndicator);
                case "SQLSERVER":
                    return medVsHisOrdersDALBASE.SelectMedVsHisOrdersSQL(medPatientId, medVisitId, medOrderNo, medOrderSubNo, medRepeatIndicator);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOrdersDALBASE.SelectMedVsHisOrdersOLE(medPatientId, medVisitId, medOrderNo, medOrderSubNo, medRepeatIndicator);
                default:
                    return medVsHisOrdersDALBASE.SelectMedVsHisOrders(medPatientId, medVisitId, medOrderNo, medOrderSubNo, medRepeatIndicator);
            }
        }
        /// <summary>
        /// 查询该医嘱序号下面最大的子医嘱序号
        /// </summary>
        /// <param name="medPatientId">病人ID号</param>
        /// <param name="medVisitId">病人住院次数</param>
        /// <param name="medOrderNo">医嘱序号</param>
        /// <returns></returns>
        public virtual int SelectMaxMedOrdersSubNo(string medPatientId, decimal medVisitId, string medOrderNo)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOrdersDALBASE.SelectMaxMedOrdersSubNoODBC(medPatientId, medVisitId, medOrderNo);
                case "ORACLE":
                    return medVsHisOrdersDALBASE.SelectMaxMedOrdersSubNo(medPatientId, medVisitId, medOrderNo);
                case "SQLSERVER":
                    return medVsHisOrdersDALBASE.SelectMaxMedOrdersSubNoSQL(medPatientId, medVisitId, medOrderNo);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOrdersDALBASE.SelectMaxMedOrdersSubNoOLE(medPatientId, medVisitId, medOrderNo);
                default:
                    return medVsHisOrdersDALBASE.SelectMaxMedOrdersSubNo(medPatientId, medVisitId, medOrderNo);
            }
        }
        /// <summary>
        /// 查询该HIS医嘱序号下面最大的子医嘱序号
        /// </summary>
        /// <param name="medPatientId">病人ID号</param>
        /// <param name="medVisitId">病人住院次数</param>
        /// <param name="hisOrderSubNo">HIS医嘱序号</param>
        /// <returns></returns>
        public virtual int SelectMaxMedOrdersSubNoFromHis(string medPatientId, decimal medVisitId, string hisOrderSubNo)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOrdersDALBASE.SelectMaxMedOrdersSubNoFromHisODBC(medPatientId, medVisitId, hisOrderSubNo);
                case "ORACLE":
                    return medVsHisOrdersDALBASE.SelectMaxMedOrdersSubNoFromHis(medPatientId, medVisitId, hisOrderSubNo);
                case "SQLSERVER":
                    return medVsHisOrdersDALBASE.SelectMaxMedOrdersSubNoFromHisSQL(medPatientId, medVisitId, hisOrderSubNo);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOrdersDALBASE.SelectMaxMedOrdersSubNoFromHisOLE(medPatientId, medVisitId, hisOrderSubNo);
                default:
                    return medVsHisOrdersDALBASE.SelectMaxMedOrdersSubNoFromHis(medPatientId, medVisitId, hisOrderSubNo);
            }
        }
        /// <summary>
        /// 获取最大医嘱编号
        /// </summary>
        /// <returns></returns>
        public virtual int SelectMaxMedOrdersNo()
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOrdersDALBASE.SelectMaxMedOrdersODBC();
                case "SQLSERVER":
                    return medVsHisOrdersDALBASE.SelectMaxMedOrdersSQL();
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOrdersDALBASE.SelectMaxMedOrdersOLE();
                default:
                    return medVsHisOrdersDALBASE.SelectMaxMedOrders();
            }

        }

        public virtual int InsertMedVsHisOrders(MedicalSytem.Soft.Model.MedVsHisOrders oneMedVsHisOrders)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOrdersDALBASE.InsertMedVsHisOrdersODBC(oneMedVsHisOrders);
                case "ORACLE":
                    return medVsHisOrdersDALBASE.InsertMedVsHisOrders(oneMedVsHisOrders);
                case "SQLSERVER":
                    return medVsHisOrdersDALBASE.InsertMedVsHisOrdersSQL(oneMedVsHisOrders);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOrdersDALBASE.InsertMedVsHisOrdersOLE(oneMedVsHisOrders);
                default:
                    return medVsHisOrdersDALBASE.InsertMedVsHisOrders(oneMedVsHisOrders);
            }
        }

        public virtual int UpdateMedVsHisOrders(MedicalSytem.Soft.Model.MedVsHisOrders oneMedVsHisOrders)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOrdersDALBASE.UpdateMedVsHisOrdersODBC(oneMedVsHisOrders);
                case "ORACLE":
                    return medVsHisOrdersDALBASE.UpdateMedVsHisOrders(oneMedVsHisOrders);
                case "SQLSERVER":
                    return medVsHisOrdersDALBASE.UpdateMedVsHisOrdersSQL(oneMedVsHisOrders);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOrdersDALBASE.UpdateMedVsHisOrdersOLE(oneMedVsHisOrders);
                default:
                    return medVsHisOrdersDALBASE.UpdateMedVsHisOrders(oneMedVsHisOrders);
            }
        }
        #endregion
        #region 医嘱转换信息--考虑电子医嘱不是规范化 Trans

        public virtual MedicalSytem.Soft.Model.MedVsHisOrders SelectMedVsHisOrdersHis(string medPatientId, decimal medVisitId, string hisOrderNo, string hisOrderSubNo, DateTime createDate, DbConnection oleCisConn)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medVsHisOrdersDALBASE.SelectMedVsHisOrdersHisODBC(medPatientId, medVisitId, hisOrderNo, hisOrderSubNo, createDate, oleCisConn);
            //    case "ORACLE":
            //        return medVsHisOrdersDALBASE.SelectMedVsHisOrdersHis(medPatientId, medVisitId, hisOrderNo, hisOrderSubNo, createDate, oleCisConn);
            //    case "SQLSERVER":
            //        return medVsHisOrdersDALBASE.SelectMedVsHisOrdersHisSQL(medPatientId, medVisitId, hisOrderNo, hisOrderSubNo, createDate, oleCisConn);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medVsHisOrdersDALBASE.SelectMedVsHisOrdersHisOLE(medPatientId, medVisitId, hisOrderNo, hisOrderSubNo, createDate, oleCisConn);
            //    default:
            return medVsHisOrdersDALBASE.SelectMedVsHisOrdersHis(medPatientId, medVisitId, hisOrderNo, hisOrderSubNo, createDate);
            //}

        }

        public virtual MedicalSytem.Soft.Model.MedVsHisOrders SelectMedVsHisOrdersHis(string hisOrderNo, string hisOrderSubNo, DateTime createDate, DbConnection oleCisConn)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medVsHisOrdersDALBASE.SelectMedVsHisOrdersHisODBC(hisOrderNo, hisOrderSubNo, createDate, oleCisConn);
            //    case "ORACLE":
            //        return medVsHisOrdersDALBASE.SelectMedVsHisOrdersHis(hisOrderNo, hisOrderSubNo, createDate, oleCisConn);
            //    case "SQLSERVER":
            //        return medVsHisOrdersDALBASE.SelectMedVsHisOrdersHisSQL(hisOrderNo, hisOrderSubNo, createDate, oleCisConn);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medVsHisOrdersDALBASE.SelectMedVsHisOrdersHisOLE(hisOrderNo, hisOrderSubNo, createDate, oleCisConn);
            //    default:
            return medVsHisOrdersDALBASE.SelectMedVsHisOrdersHis(hisOrderNo, hisOrderSubNo, createDate);
            //}
        }

        public virtual MedicalSytem.Soft.Model.MedVsHisOrders SelectMedVsHisOrders(string medPatientId, decimal medVisitId, string medOrderNo, decimal medOrderSubNo, decimal medRepeatIndicator, DbConnection oleCisConn)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medVsHisOrdersDALBASE.SelectMedVsHisOrders(medPatientId, medVisitId, medOrderNo, medOrderSubNo, medRepeatIndicator, oleCisConn);
            //    case "ORACLE":
            //        return medVsHisOrdersDALBASE.SelectMedVsHisOrders(medPatientId, medVisitId, medOrderNo, medOrderSubNo, medRepeatIndicator, oleCisConn);
            //    case "SQLSERVER":
            //        return medVsHisOrdersDALBASE.SelectMedVsHisOrders(medPatientId, medVisitId, medOrderNo, medOrderSubNo, medRepeatIndicator, oleCisConn);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medVsHisOrdersDALBASE.SelectMedVsHisOrders(medPatientId, medVisitId, medOrderNo, medOrderSubNo, medRepeatIndicator, oleCisConn);
            //    default:
            return medVsHisOrdersDALBASE.SelectMedVsHisOrders(medPatientId, medVisitId, medOrderNo, medOrderSubNo, medRepeatIndicator, oleCisConn);
            //}

        }

        public virtual int SelectMaxMedOrdersSubNo(string medPatientId, decimal medVisitId, string medOrderNo, DbTransaction oleCisTrans)
        {
            return medVsHisOrdersDALBASE.SelectMaxMedOrdersSubNo(medPatientId, medVisitId, medOrderNo, oleCisTrans);
        }

        public virtual int SelectMaxMedOrdersNo(DbTransaction oleCisTrans)
        {
            return medVsHisOrdersDALBASE.SelectMaxMedOrders(oleCisTrans);
        }

        public virtual int SelectMaxMedOrdersSubNoFromHis(string medPatientId, decimal medVisitId, string hisOrderSubNo, DbTransaction oleCisTrans)
        {
            return medVsHisOrdersDALBASE.SelectMaxMedOrdersSubNoFromHis(medPatientId, medVisitId, hisOrderSubNo, oleCisTrans);
        }

        public virtual int InsertMedVsHisOrders(MedicalSytem.Soft.Model.MedVsHisOrders oneMedVsHisOrders, DbTransaction oleCisTrans)
        {
            return medVsHisOrdersDALBASE.InsertMedVsHisOrders(oneMedVsHisOrders, oleCisTrans);
        }

        public virtual int UpdateMedVsHisOrders(MedicalSytem.Soft.Model.MedVsHisOrders oneMedVsHisOrders, DbTransaction oleCisTrans)
        {
            return medVsHisOrdersDALBASE.UpdateMedVsHisOrders(oneMedVsHisOrders, oleCisTrans);
        }
        #endregion

        #region 医嘱类别对照字典

        /// <summary>
        /// 医嘱类别对照字典
        /// </summary>
        /// <param name="HIS_CLASS_CODE">HIS医嘱类别代码</param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedVsHisOrderClass SelectMedVsHisOrderClass(string HIS_CLASS_CODE)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClassODBC(HIS_CLASS_CODE);
                case "ORACLE":
                    return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClass(HIS_CLASS_CODE);
                case "SQLSERVER":
                    return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClassSQL(HIS_CLASS_CODE);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClassOLE(HIS_CLASS_CODE);
                default:
                    return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClass(HIS_CLASS_CODE);
            }
        }
        /// <summary>
        /// 医嘱类别对照字典
        /// </summary>
        /// <param name="HIS_CLASS_CODE">HIS医嘱类别名称</param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedVsHisOrderClass SelectMedVsHisOrderClassHisClassName(string HIS_CLASS_NAME)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClassHisClassNameODBC(HIS_CLASS_NAME);
                case "ORACLE":
                    return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClassHisClassName(HIS_CLASS_NAME);
                case "SQLSERVER":
                    return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClassHisClassNameSQL(HIS_CLASS_NAME);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClassHisClassNameOLE(HIS_CLASS_NAME);
                default:
                    return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClassHisClassName(HIS_CLASS_NAME);
            }
        }
        /// <summary>
        /// 插入医嘱类别对照字典
        /// </summary>
        /// <param name="medPerformDefaultSchedule"></param>
        /// <returns></returns>
        public virtual int InsertMedVsHisOrderClass(MedicalSytem.Soft.Model.MedVsHisOrderClass medVsHisOrderClass)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOrderClassDALBASE.InsertMedVsHisOrderClassODBC(medVsHisOrderClass);
                case "ORACLE":
                    return medVsHisOrderClassDALBASE.InsertMedVsHisOrderClass(medVsHisOrderClass);
                case "SQLSERVER":
                    return medVsHisOrderClassDALBASE.InsertMedVsHisOrderClassSQL(medVsHisOrderClass);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOrderClassDALBASE.InsertMedVsHisOrderClassOLE(medVsHisOrderClass);
                default:
                    return medVsHisOrderClassDALBASE.InsertMedVsHisOrderClass(medVsHisOrderClass);
            }
        }
        /// <summary>
        /// 更新医嘱类别对照字典
        /// </summary>
        /// <param name="medPerformDefaultSchedule"></param>
        /// <returns></returns>
        public virtual int UpdateMedVsHisOrderClass(MedicalSytem.Soft.Model.MedVsHisOrderClass medVsHisOrderClass)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOrderClassDALBASE.UpdateMedVsHisOrderClassODBC(medVsHisOrderClass);
                case "ORACLE":
                    return medVsHisOrderClassDALBASE.UpdateMedVsHisOrderClass(medVsHisOrderClass);
                case "SQLSERVER":
                    return medVsHisOrderClassDALBASE.UpdateMedVsHisOrderClassSQL(medVsHisOrderClass);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOrderClassDALBASE.UpdateMedVsHisOrderClassOLE(medVsHisOrderClass);
                default:
                    return medVsHisOrderClassDALBASE.UpdateMedVsHisOrderClass(medVsHisOrderClass);
            }
        }
        #endregion
        #region 医嘱类别对照字典 Trans

        /// <summary>
        /// 医嘱类别对照字典
        /// </summary>
        /// <param name="HIS_CLASS_CODE">HIS医嘱类别代码</param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedVsHisOrderClass SelectMedVsHisOrderClass(string HIS_CLASS_CODE, DbConnection oleCisConn)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClass(HIS_CLASS_CODE, oleCisConn);
            //    case "ORACLE":
            //        return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClass(HIS_CLASS_CODE, oleCisConn);
            //    case "SQLSERVER":
            //        return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClass(HIS_CLASS_CODE, oleCisConn);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClass(HIS_CLASS_CODE, oleCisConn);
            //    default:
            return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClass(HIS_CLASS_CODE, oleCisConn);
            //}

        }
        /// <summary>
        /// 医嘱类别对照字典
        /// </summary>
        /// <param name="HIS_CLASS_CODE">HIS医嘱类别名称</param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedVsHisOrderClass SelectMedVsHisOrderClassHisClassName(string HIS_CLASS_NAME, DbConnection oleCisConn)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClassHisClassNameODBC(HIS_CLASS_NAME, oleCisConn);
            //    case "ORACLE":
            //        return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClassHisClassName(HIS_CLASS_NAME, oleCisConn);
            //    case "SQLSERVER":
            //        return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClassHisClassNameSQL(HIS_CLASS_NAME, oleCisConn);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClassHisClassNameOLE(HIS_CLASS_NAME, oleCisConn);
            //    default:
            return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClassHisClassName(HIS_CLASS_NAME);
            //}
        }
        /// <summary>
        /// 插入医嘱类别对照字典
        /// </summary>
        /// <param name="medPerformDefaultSchedule"></param>
        /// <returns></returns>
        public virtual int InsertMedVsHisOrderClass(MedicalSytem.Soft.Model.MedVsHisOrderClass medVsHisOrderClass, DbTransaction oleCisTrans)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medVsHisOrderClassDALBASE.InsertMedVsHisOrderClassODBC(medVsHisOrderClass, oleCisTrans);
            //    case "ORACLE":
            //        return medVsHisOrderClassDALBASE.InsertMedVsHisOrderClass(medVsHisOrderClass, oleCisTrans);
            //    case "SQLSERVER":
            //        return medVsHisOrderClassDALBASE.InsertMedVsHisOrderClassSQL(medVsHisOrderClass, oleCisTrans);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medVsHisOrderClassDALBASE.InsertMedVsHisOrderClassOLE(medVsHisOrderClass, oleCisTrans);
            //    default:
            return medVsHisOrderClassDALBASE.InsertMedVsHisOrderClass(medVsHisOrderClass);
            //}
        }
        /// <summary>
        /// 更新医嘱类别对照字典
        /// </summary>
        /// <param name="medPerformDefaultSchedule"></param>
        /// <returns></returns>
        public virtual int UpdateMedVsHisOrderClass(MedicalSytem.Soft.Model.MedVsHisOrderClass medVsHisOrderClass, DbTransaction oleCisTrans)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medVsHisOrderClassDALBASE.UpdateMedVsHisOrderClassODBC(medVsHisOrderClass, oleCisTrans);
            //    case "ORACLE":
            //        return medVsHisOrderClassDALBASE.UpdateMedVsHisOrderClass(medVsHisOrderClass, oleCisTrans);
            //    case "SQLSERVER":
            //        return medVsHisOrderClassDALBASE.UpdateMedVsHisOrderClassSQL(medVsHisOrderClass, oleCisTrans);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medVsHisOrderClassDALBASE.UpdateMedVsHisOrderClassOLE(medVsHisOrderClass, oleCisTrans);
            //    default:
            return medVsHisOrderClassDALBASE.UpdateMedVsHisOrderClass(medVsHisOrderClass);
            //}
        }
        #endregion

        #region 医嘱默认执行时间
        /// <summary>
        /// 医嘱默认执行时间
        /// </summary>
        /// <param name="FREQ_DESC">医嘱频次</param>
        /// <param name="ADMINISTRATION">给药途径</param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedPerformDefaultSchedule SelectMedPerformDefaultSchedule(string FREQ_DESC)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medPerformDefaultScheduleDALBASE.SelectMedPerformDefaultSchedule(FREQ_DESC);
                case "ORACLE":
                    return medPerformDefaultScheduleDALBASE.SelectMedPerformDefaultSchedule(FREQ_DESC);
                case "SQLSERVER":
                    return medPerformDefaultScheduleDALBASE.SelectMedPerformDefaultScheduleSQL(FREQ_DESC);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medPerformDefaultScheduleDALBASE.SelectMedPerformDefaultSchedule(FREQ_DESC);
                default:
                    return medPerformDefaultScheduleDALBASE.SelectMedPerformDefaultSchedule(FREQ_DESC);
            }
        }

        /// <summary>
        /// 医嘱默认执行时间列表
        /// </summary>
        /// <returns></returns>
        public virtual List<MedicalSytem.Soft.Model.MedPerformDefaultSchedule> SelectMedPerformDefaultScheduleList()
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medPerformDefaultScheduleDALBASE.SelectMedPerformDefaultScheduleListODBC();
                case "ORACLE":
                    return medPerformDefaultScheduleDALBASE.SelectMedPerformDefaultScheduleList();
                case "SQLSERVER":
                    return medPerformDefaultScheduleDALBASE.SelectMedPerformDefaultScheduleListSQL();
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medPerformDefaultScheduleDALBASE.SelectMedPerformDefaultScheduleListOLE();
                default:
                    return medPerformDefaultScheduleDALBASE.SelectMedPerformDefaultScheduleList();
            }
        }


        /// <summary>
        /// 医嘱类别对照字典列表
        /// </summary>
        /// <returns></returns>
        public virtual List<MedicalSytem.Soft.Model.MedVsHisOrderClass> SelectMedVsHisOrderClassList()
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClassListODBC();
                case "ORACLE":
                    return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClassList();
                case "SQLSERVER":
                    return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClassListSQL();
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClassListOLE();
                default:
                    return medVsHisOrderClassDALBASE.SelectMedVsHisOrderClassList();
            }
        }


        /// <summary>
        /// 医嘱默认执行时间
        /// </summary>
        /// <param name="FREQ_DESC">医嘱频次</param>
        /// <param name="ADMINISTRATION">给药途径</param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedPerformDefaultSchedule SelectMedPerformDefaultSchedule(string FREQ_DESC, string ADMINISTRATION)
        {
            return medPerformDefaultScheduleDALBASE.SelectMedPerformDefaultSchedule(FREQ_DESC, ADMINISTRATION);
        }
        /// <summary>
        /// 插入医嘱默认执行时间
        /// </summary>
        /// <param name="medPerformDefaultSchedule"></param>
        /// <returns></returns>
        public virtual int InsertMedPerformDefaultSchedule(MedicalSytem.Soft.Model.MedPerformDefaultSchedule medPerformDefaultSchedule)
        {
            return medPerformDefaultScheduleDALBASE.InsertMedPerformDefaultSchedule(medPerformDefaultSchedule);
        }
        /// <summary>
        /// 更新医嘱默认执行时间
        /// </summary>
        /// <param name="medPerformDefaultSchedule"></param>
        /// <returns></returns>
        public virtual int UpdateMedPerformDefaultSchedule(MedicalSytem.Soft.Model.MedPerformDefaultSchedule medPerformDefaultSchedule)
        {
            return medPerformDefaultScheduleDALBASE.UpdateMedPerformDefaultSchedule(medPerformDefaultSchedule);
        }
        #endregion
        #region 医嘱默认执行时间 Trans
        /// <summary>
        /// 医嘱默认执行时间
        /// </summary>
        /// <param name="FREQ_DESC">医嘱频次</param>
        /// <param name="ADMINISTRATION">给药途径</param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedPerformDefaultSchedule SelectMedPerformDefaultSchedule(string FREQ_DESC, DbConnection oleCisConn)
        {
            return medPerformDefaultScheduleDALBASE.SelectMedPerformDefaultSchedule(FREQ_DESC, oleCisConn);
        }
        /// <summary>
        /// 医嘱默认执行时间
        /// </summary>
        /// <param name="FREQ_DESC">医嘱频次</param>
        /// <param name="ADMINISTRATION">给药途径</param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedPerformDefaultSchedule SelectMedPerformDefaultSchedule(string FREQ_DESC, string ADMINISTRATION, DbConnection oleCisConn)
        {
            return medPerformDefaultScheduleDALBASE.SelectMedPerformDefaultSchedule(FREQ_DESC, ADMINISTRATION, oleCisConn);
        }
        /// <summary>
        /// 插入医嘱默认执行时间
        /// </summary>
        /// <param name="medPerformDefaultSchedule"></param>
        /// <returns></returns>
        public virtual int InsertMedPerformDefaultSchedule(MedicalSytem.Soft.Model.MedPerformDefaultSchedule medPerformDefaultSchedule, DbTransaction oleCisTrans)
        {
            return medPerformDefaultScheduleDALBASE.InsertMedPerformDefaultSchedule(medPerformDefaultSchedule, oleCisTrans);
        }
        /// <summary>
        /// 更新医嘱默认执行时间
        /// </summary>
        /// <param name="medPerformDefaultSchedule"></param>
        /// <returns></returns>
        public virtual int UpdateMedPerformDefaultSchedule(MedicalSytem.Soft.Model.MedPerformDefaultSchedule medPerformDefaultSchedule, DbTransaction oleCisTrans)
        {
            return medPerformDefaultScheduleDALBASE.UpdateMedPerformDefaultSchedule(medPerformDefaultSchedule, oleCisTrans);
        }
        #endregion

        #region 在科病人记录


        public virtual MedicalSytem.Soft.Model.MedPatsInHospital SelectMedPatsInHospital(string patientId,decimal visitid)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medPatsInHospitalDALBASE.SelectMedPatsInHospitalOdbc(patientId);
                case "ORACLE":
                    return medPatsInHospitalDALBASE.SelectMedPatsInHospital(patientId, visitid);
                case "SQLSERVER":
                    return medPatsInHospitalDALBASE.SelectMedPatsInHospitalSQL(patientId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medPatsInHospitalDALBASE.SelectMedPatsInHospitalOLE(patientId);
                default:
                    return medPatsInHospitalDALBASE.SelectMedPatsInHospital(patientId, visitid);
            }
        }

        public virtual List<MedicalSytem.Soft.Model.MedPatsInHospital> SelectDeptMedPatsInHospital(string wardCode)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medPatsInHospitalDALBASE.SelectDeptMedPatsInHospitalOdbc(wardCode);
                case "ORACLE":
                    return medPatsInHospitalDALBASE.SelectDeptMedPatsInHospital(wardCode);
                case "SQLSERVER":
                    return medPatsInHospitalDALBASE.SelectDeptMedPatsInHospitalSQL(wardCode);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medPatsInHospitalDALBASE.SelectDeptMedPatsInHospitalOLE(wardCode);
                default:
                    return medPatsInHospitalDALBASE.SelectDeptMedPatsInHospital(wardCode);
            }
        }

        public virtual int InsertMedPatsInHospital(MedicalSytem.Soft.Model.MedPatsInHospital MedPatsInHospital)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medPatsInHospitalDALBASE.InsertMedPatsInHospitalOdbc(MedPatsInHospital);
                case "ORACLE":
                    return medPatsInHospitalDALBASE.InsertMedPatsInHospital(MedPatsInHospital);
                case "SQLSERVER":
                    return medPatsInHospitalDALBASE.InsertMedPatsInHospitalSQL(MedPatsInHospital);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medPatsInHospitalDALBASE.InsertMedPatsInHospitalOLE(MedPatsInHospital);
                default:
                    return medPatsInHospitalDALBASE.InsertMedPatsInHospital(MedPatsInHospital);
            }
        }

        public virtual int UpdateMedPatsInHospital(MedicalSytem.Soft.Model.MedPatsInHospital MedPatsInHospital)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medPatsInHospitalDALBASE.UpdateMedPatsInHospitalOdbc(MedPatsInHospital);
                case "ORACLE":
                    return medPatsInHospitalDALBASE.UpdateMedPatsInHospital(MedPatsInHospital);
                case "SQLSERVER":
                    return medPatsInHospitalDALBASE.UpdateMedPatsInHospitalSQL(MedPatsInHospital);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medPatsInHospitalDALBASE.UpdateMedPatsInHospitalOLE(MedPatsInHospital);
                default:
                    return medPatsInHospitalDALBASE.UpdateMedPatsInHospital(MedPatsInHospital);
            }
        }

        public virtual int DeleteMedPatsInHospital(MedicalSytem.Soft.Model.MedPatsInHospital MedPatsInHospital)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medPatsInHospitalDALBASE.DeleteMedPatsInHospitalOdbc(MedPatsInHospital);
                case "ORACLE":
                    return medPatsInHospitalDALBASE.DeleteMedPatsInHospital(MedPatsInHospital.PatientId);
                case "SQLSERVER":
                    return medPatsInHospitalDALBASE.DeleteMedPatsInHospitalSQL(MedPatsInHospital.PatientId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medPatsInHospitalDALBASE.DeleteMedPatsInHospitalOLE(MedPatsInHospital);
                default:
                    return medPatsInHospitalDALBASE.DeleteMedPatsInHospital(MedPatsInHospital.PatientId);
            }

        }
        #endregion
        #region 在科病人记录 Trans


        public virtual MedicalSytem.Soft.Model.MedPatsInHospital SelectMedPatsInHospital(string patientId,decimal visitid ,DbConnection oleCisConn)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medPatsInHospitalDALBASE.SelectMedPatsInHospitalOdbc(patientId, oleCisConn);
            //    case "ORACLE":
            //        return medPatsInHospitalDALBASE.SelectMedPatsInHospital(patientId, oleCisConn);
            //    case "SQLSERVER":
            //        return medPatsInHospitalDALBASE.SelectMedPatsInHospitalSQL(patientId, oleCisConn);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medPatsInHospitalDALBASE.SelectMedPatsInHospitalOLE(patientId, oleCisConn);
            //    default:
            return medPatsInHospitalDALBASE.SelectMedPatsInHospital(patientId, visitid);
            //}
        }

        public virtual List<MedicalSytem.Soft.Model.MedPatsInHospital> SelectDeptMedPatsInHospital(string wardCode, DbConnection oleCisConn)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medPatsInHospitalDALBASE.SelectDeptMedPatsInHospitalOdbc(wardCode, oleCisConn);
            //    case "ORACLE":
            //        return medPatsInHospitalDALBASE.SelectDeptMedPatsInHospital(wardCode, oleCisConn);
            //    case "SQLSERVER":
            //        return medPatsInHospitalDALBASE.SelectDeptMedPatsInHospitalSQL(wardCode, oleCisConn);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medPatsInHospitalDALBASE.SelectDeptMedPatsInHospitalOLE(wardCode, oleCisConn);
            //    default:
            return medPatsInHospitalDALBASE.SelectDeptMedPatsInHospital(wardCode);
            //}
        }

        public virtual int InsertMedPatsInHospital(MedicalSytem.Soft.Model.MedPatsInHospital MedPatsInHospital, DbTransaction oleCisTrans)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medPatsInHospitalDALBASE.InsertMedPatsInHospitalOdbc(MedPatsInHospital, oleCisTrans);
            //    case "ORACLE":
            //        return medPatsInHospitalDALBASE.InsertMedPatsInHospital(MedPatsInHospital, oleCisTrans);
            //    case "SQLSERVER":
            //        return medPatsInHospitalDALBASE.InsertMedPatsInHospitalSQL(MedPatsInHospital, oleCisTrans);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medPatsInHospitalDALBASE.InsertMedPatsInHospitalOLE(MedPatsInHospital, oleCisTrans);
            //    default:
            return medPatsInHospitalDALBASE.InsertMedPatsInHospital(MedPatsInHospital);
            //}
        }

        public virtual int UpdateMedPatsInHospital(MedicalSytem.Soft.Model.MedPatsInHospital MedPatsInHospital, DbTransaction oleCisTrans)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medPatsInHospitalDALBASE.UpdateMedPatsInHospitalOdbc(MedPatsInHospital, oleCisTrans);
            //    case "ORACLE":
            //        return medPatsInHospitalDALBASE.UpdateMedPatsInHospital(MedPatsInHospital, oleCisTrans);
            //    case "SQLSERVER":
            //        return medPatsInHospitalDALBASE.UpdateMedPatsInHospitalSQL(MedPatsInHospital, oleCisTrans);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medPatsInHospitalDALBASE.UpdateMedPatsInHospitalOLE(MedPatsInHospital, oleCisTrans);
            //    default:
            return medPatsInHospitalDALBASE.UpdateMedPatsInHospital(MedPatsInHospital);
            //}
        }

        public virtual int DeleteMedPatsInHospital(MedicalSytem.Soft.Model.MedPatsInHospital MedPatsInHospital, DbTransaction oleCisTrans)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medPatsInHospitalDALBASE.DeleteMedPatsInHospitalOdbc(MedPatsInHospital.PatientId, oleCisTrans);
            //    case "ORACLE":
            //        return medPatsInHospitalDALBASE.DeleteMedPatsInHospital(MedPatsInHospital.PatientId, oleCisTrans);
            //    case "SQLSERVER":
            //        return medPatsInHospitalDALBASE.DeleteMedPatsInHospitalSQL(MedPatsInHospital.PatientId, oleCisTrans);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medPatsInHospitalDALBASE.DeleteMedPatsInHospitalOLE(MedPatsInHospital.PatientId, oleCisTrans);
            //    default:
            return medPatsInHospitalDALBASE.DeleteMedPatsInHospital(MedPatsInHospital.PatientId);
            //}
        }
        #endregion

        #region 在科病人记录-历史病人
        public virtual MedicalSytem.Soft.Model.MedPatInicuInformation SelectMedPatInicuInformation(string patientId, decimal visitId, decimal depId, decimal inIcuTimes)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medPatInicuInformationDALBASE.SelectMedPatInicuInformationODBC(patientId, visitId, depId, inIcuTimes);
                case "ORACLE":
                    return medPatInicuInformationDALBASE.SelectMedPatInicuInformation(patientId, visitId, depId, inIcuTimes);
                case "SQLSERVER":
                    return medPatInicuInformationDALBASE.SelectMedPatInicuInformationSQL(patientId, visitId, depId, inIcuTimes);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medPatInicuInformationDALBASE.SelectMedPatInicuInformationOLE(patientId, visitId, depId, inIcuTimes);
                default:
                    return medPatInicuInformationDALBASE.SelectMedPatInicuInformation(patientId, visitId, depId, inIcuTimes);
            }
        }

        public virtual int InsertMedPatInicuInformation(MedicalSytem.Soft.Model.MedPatInicuInformation oneMedPatInicuInformation)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medPatInicuInformationDALBASE.InsertMedPatInicuInformationODBC(oneMedPatInicuInformation);
                case "ORACLE":
                    return medPatInicuInformationDALBASE.InsertMedPatInicuInformation(oneMedPatInicuInformation);
                case "SQLSERVER":
                    return medPatInicuInformationDALBASE.InsertMedPatInicuInformationSQL(oneMedPatInicuInformation);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medPatInicuInformationDALBASE.InsertMedPatInicuInformationOLE(oneMedPatInicuInformation);
                default:
                    return medPatInicuInformationDALBASE.InsertMedPatInicuInformation(oneMedPatInicuInformation);
            }
        }

        public virtual int UpdateMedPatInicuInformation(MedicalSytem.Soft.Model.MedPatInicuInformation oneMedPatInicuInformation)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medPatInicuInformationDALBASE.UpdateMedPatInicuInformationODBC(oneMedPatInicuInformation);
                case "ORACLE":
                    return medPatInicuInformationDALBASE.UpdateMedPatInicuInformation(oneMedPatInicuInformation);
                case "SQLSERVER":
                    return medPatInicuInformationDALBASE.UpdateMedPatInicuInformationSQL(oneMedPatInicuInformation); ;
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medPatInicuInformationDALBASE.UpdateMedPatInicuInformationOLE(oneMedPatInicuInformation);
                default:
                    return medPatInicuInformationDALBASE.UpdateMedPatInicuInformation(oneMedPatInicuInformation);
            }
        }

        public virtual int DeleteMedPatInicuInformation(MedicalSytem.Soft.Model.MedPatInicuInformation oneMedPatInicuInformation)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medPatInicuInformationDALBASE.DeleteMedPatInicuInformationODBC(oneMedPatInicuInformation.PatientId, oneMedPatInicuInformation.VisitId, oneMedPatInicuInformation.DepId, oneMedPatInicuInformation.InIcuTimes);
                case "ORACLE":
                    return medPatInicuInformationDALBASE.DeleteMedPatInicuInformation(oneMedPatInicuInformation.PatientId, oneMedPatInicuInformation.VisitId, oneMedPatInicuInformation.DepId, oneMedPatInicuInformation.InIcuTimes);
                case "SQLSERVER":
                    return medPatInicuInformationDALBASE.DeleteMedPatInicuInformationSQL(oneMedPatInicuInformation.PatientId, oneMedPatInicuInformation.VisitId, oneMedPatInicuInformation.DepId, oneMedPatInicuInformation.InIcuTimes);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medPatInicuInformationDALBASE.DeleteMedPatInicuInformationOLE(oneMedPatInicuInformation.PatientId, oneMedPatInicuInformation.VisitId, oneMedPatInicuInformation.DepId, oneMedPatInicuInformation.InIcuTimes);
                default:
                    return medPatInicuInformationDALBASE.DeleteMedPatInicuInformation(oneMedPatInicuInformation.PatientId, oneMedPatInicuInformation.VisitId, oneMedPatInicuInformation.DepId, oneMedPatInicuInformation.InIcuTimes);
            }
        }
        #endregion
        #region 在科病人记录-历史病人 Trans

        public virtual MedicalSytem.Soft.Model.MedPatInicuInformation SelectMedPatInicuInformation(string patientId, decimal visitId, decimal depId, decimal inIcuTimes, DbConnection oleCisConn)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medPatInicuInformationDALBASE.SelectMedPatInicuInformationODBC(patientId, visitId, depId, inIcuTimes, oleCisConn);
            //    case "ORACLE":
            //        return medPatInicuInformationDALBASE.SelectMedPatInicuInformation(patientId, visitId, depId, inIcuTimes, oleCisConn);
            //    case "SQLSERVER":
            //        return medPatInicuInformationDALBASE.SelectMedPatInicuInformationSQL(patientId, visitId, depId, inIcuTimes, oleCisConn);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medPatInicuInformationDALBASE.SelectMedPatInicuInformationOLE(patientId, visitId, depId, inIcuTimes, oleCisConn);
            //    default:
            return medPatInicuInformationDALBASE.SelectMedPatInicuInformation(patientId, visitId, depId, inIcuTimes);
            //}
        }

        public virtual int InsertMedPatInicuInformation(MedicalSytem.Soft.Model.MedPatInicuInformation oneMedPatInicuInformation, DbTransaction oleCisTran)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medPatInicuInformationDALBASE.InsertMedPatInicuInformationODBC(oneMedPatInicuInformation, oleCisTran);
            //    case "ORACLE":
            //        return medPatInicuInformationDALBASE.InsertMedPatInicuInformation(oneMedPatInicuInformation, oleCisTran);
            //    case "SQLSERVER":
            //        return medPatInicuInformationDALBASE.InsertMedPatInicuInformationSQL(oneMedPatInicuInformation, oleCisTran);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medPatInicuInformationDALBASE.InsertMedPatInicuInformationOLE(oneMedPatInicuInformation, oleCisTran);
            //    default:
            return medPatInicuInformationDALBASE.InsertMedPatInicuInformation(oneMedPatInicuInformation);
            //}

        }

        public virtual int UpdateMedPatInicuInformation(MedicalSytem.Soft.Model.MedPatInicuInformation oneMedPatInicuInformation, DbTransaction oleCisTran)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medPatInicuInformationDALBASE.UpdateMedPatInicuInformationODBC(oneMedPatInicuInformation, oleCisTran);
            //    case "ORACLE":
            //        return medPatInicuInformationDALBASE.UpdateMedPatInicuInformation(oneMedPatInicuInformation, oleCisTran);
            //    case "SQLSERVER":
            //        return medPatInicuInformationDALBASE.UpdateMedPatInicuInformationSQL(oneMedPatInicuInformation, oleCisTran);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medPatInicuInformationDALBASE.UpdateMedPatInicuInformationOLE(oneMedPatInicuInformation, oleCisTran);
            //    default:
            return medPatInicuInformationDALBASE.UpdateMedPatInicuInformation(oneMedPatInicuInformation);
            //}
        }

        public virtual int DeleteMedPatInicuInformation(MedicalSytem.Soft.Model.MedPatInicuInformation oneMedPatInicuInformation, DbTransaction oleCisTran)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medPatInicuInformationDALBASE.DeleteMedPatInicuInformationODBC(oneMedPatInicuInformation.PatientId, oneMedPatInicuInformation.VisitId, oneMedPatInicuInformation.DepId, oneMedPatInicuInformation.InIcuTimes, oleCisTran);
            //    case "ORACLE":
            //        return medPatInicuInformationDALBASE.DeleteMedPatInicuInformation(oneMedPatInicuInformation.PatientId, oneMedPatInicuInformation.VisitId, oneMedPatInicuInformation.DepId, oneMedPatInicuInformation.InIcuTimes, oleCisTran);
            //    case "SQLSERVER":
            //        return medPatInicuInformationDALBASE.DeleteMedPatInicuInformationSQL(oneMedPatInicuInformation.PatientId, oneMedPatInicuInformation.VisitId, oneMedPatInicuInformation.DepId, oneMedPatInicuInformation.InIcuTimes, oleCisTran);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medPatInicuInformationDALBASE.DeleteMedPatInicuInformationOLE(oneMedPatInicuInformation.PatientId, oneMedPatInicuInformation.VisitId, oneMedPatInicuInformation.DepId, oneMedPatInicuInformation.InIcuTimes, oleCisTran);
            //    default:
            return medPatInicuInformationDALBASE.DeleteMedPatInicuInformation(oneMedPatInicuInformation.PatientId, oneMedPatInicuInformation.VisitId, oneMedPatInicuInformation.DepId, oneMedPatInicuInformation.InIcuTimes);
            //}
        }
        #endregion

        #region 病人入科次数--医院没有DEP_ID计算出来的住入科次数

        public virtual int SelectMaxMedVsHisDepId(string medPatientId, decimal medVisitId)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisDepIdDALBASE.SelectMaxMedVsHisDepIdODBC(medPatientId, medVisitId);
                case "ORACLE":
                    return medVsHisDepIdDALBASE.SelectMaxMedVsHisDepId(medPatientId, medVisitId);
                case "SQLSERVER":
                    return medVsHisDepIdDALBASE.SelectMaxMedVsHisDepIdSQL(medPatientId, medVisitId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisDepIdDALBASE.SelectMaxMedVsHisDepIdOLE(medPatientId, medVisitId);
                default:
                    return medVsHisDepIdDALBASE.SelectMaxMedVsHisDepId(medPatientId, medVisitId);
            }
        }
        public virtual MedicalSytem.Soft.Model.MedVsHisDepId SelectMedVsHisDepId(string medPatientId, decimal medVisitId, decimal medDepId)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisDepIdDALBASE.SelectMedVsHisDepIdODBC(medPatientId, medVisitId, medDepId);
                case "ORACLE":
                    return medVsHisDepIdDALBASE.SelectMedVsHisDepId(medPatientId, medVisitId, medDepId);
                case "SQLSERVER":
                    return medVsHisDepIdDALBASE.SelectMedVsHisDepIdSQL(medPatientId, medVisitId, medDepId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisDepIdDALBASE.SelectMedVsHisDepIdOLE(medPatientId, medVisitId, medDepId);
                default:
                    return medVsHisDepIdDALBASE.SelectMedVsHisDepId(medPatientId, medVisitId, medDepId);
            }
        }

        public virtual MedicalSytem.Soft.Model.MedVsHisDepId SelectMedVsHisDepIdHis(string hisPatientId, string hisVisitId, DateTime wardDateTime)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisDepIdDALBASE.SelectMedVsHisDepIdHISODBC(hisPatientId, hisVisitId, wardDateTime);
                case "ORACLE":
                    return medVsHisDepIdDALBASE.SelectMedVsHisDepIdHis(hisPatientId, hisVisitId, wardDateTime);
                case "SQLSERVER":
                    return medVsHisDepIdDALBASE.SelectMedVsHisDepIdHisSQL(hisPatientId, hisVisitId, wardDateTime);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisDepIdDALBASE.SelectMedVsHisDepIdHisOLE(hisPatientId, hisVisitId, wardDateTime);
                default:
                    return medVsHisDepIdDALBASE.SelectMedVsHisDepIdHis(hisPatientId, hisVisitId, wardDateTime);
            }
        }

        public virtual int InsertMedVsHisDepId(MedicalSytem.Soft.Model.MedVsHisDepId oneMedVsHisDepId)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisDepIdDALBASE.InsertMedVsHisDepIdODBC(oneMedVsHisDepId);
                case "ORACLE":
                    return medVsHisDepIdDALBASE.InsertMedVsHisDepId(oneMedVsHisDepId);
                case "SQLSERVER":
                    return medVsHisDepIdDALBASE.InsertMedVsHisDepIdSQL(oneMedVsHisDepId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisDepIdDALBASE.InsertMedVsHisDepIdOLE(oneMedVsHisDepId);
                default:
                    return medVsHisDepIdDALBASE.InsertMedVsHisDepId(oneMedVsHisDepId);
            }
        }

        public virtual int UpdateMedVsHisDepId(MedicalSytem.Soft.Model.MedVsHisDepId oneMedVsHisDepId)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisDepIdDALBASE.UpdateMedVsHisDepIdODBC(oneMedVsHisDepId);
                case "ORACLE":
                    return medVsHisDepIdDALBASE.UpdateMedVsHisDepId(oneMedVsHisDepId);
                case "SQLSERVER":
                    return medVsHisDepIdDALBASE.UpdateMedVsHisDepIdSQL(oneMedVsHisDepId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisDepIdDALBASE.UpdateMedVsHisDepIdOLE(oneMedVsHisDepId);
                default:
                    return medVsHisDepIdDALBASE.UpdateMedVsHisDepId(oneMedVsHisDepId);
            }
        }

        #endregion

        #region 在院病人信息
        public virtual MedicalSytem.Soft.Model.MedPatVisit SelectMedPatVisit(string patientId, decimal visitId)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medPatVisitDALBASE.SelectMedPatVisitOdbc(patientId, visitId);
                case "ORACLE":
                    return medPatVisitDALBASE.SelectMedPatVisit(patientId, visitId);
                case "SQLSERVER":
                    return medPatVisitDALBASE.SelectMedPatVisitSQL(patientId, visitId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medPatVisitDALBASE.SelectMedPatVisitOLE(patientId, visitId);
                default:
                    return medPatVisitDALBASE.SelectMedPatVisit(patientId, visitId);
            }
        }

        public virtual int InsertMedPatVisit(MedicalSytem.Soft.Model.MedPatVisit MedPatVisit)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medPatVisitDALBASE.InsertMedPatVisitOdbc(MedPatVisit);
                case "ORACLE":
                    return medPatVisitDALBASE.InsertMedPatVisit(MedPatVisit);
                case "SQLSERVER":
                    return medPatVisitDALBASE.InsertMedPatVisitSQL(MedPatVisit);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medPatVisitDALBASE.InsertMedPatVisitOLE(MedPatVisit);
                default:
                    return medPatVisitDALBASE.InsertMedPatVisit(MedPatVisit);
            }
        }

        public virtual int UpdateMedPatVisit(MedicalSytem.Soft.Model.MedPatVisit MedPatVisit)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medPatVisitDALBASE.UpdateMedPatVisitOdbc(MedPatVisit);
                case "ORACLE":
                    return medPatVisitDALBASE.UpdateMedPatVisit(MedPatVisit);
                case "SQLSERVER":
                    return medPatVisitDALBASE.UpdateMedPatVisitSQL(MedPatVisit);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medPatVisitDALBASE.UpdateMedPatVisitOLE(MedPatVisit);
                default:
                    return medPatVisitDALBASE.UpdateMedPatVisit(MedPatVisit);
            }
        }
        #endregion
        #region 在院病人信息 Trans
        public virtual MedicalSytem.Soft.Model.MedPatVisit SelectMedPatVisit(string patientId, decimal visitId, DbConnection oleCisConn)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medPatVisitDALBASE.SelectMedPatVisitOdbc(patientId, visitId, oleCisConn);
            //    case "ORACLE":
            //        return medPatVisitDALBASE.SelectMedPatVisit(patientId, visitId, oleCisConn);
            //    case "SQLSERVER":
            //        return medPatVisitDALBASE.SelectMedPatVisitSQL(patientId, visitId, oleCisConn);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medPatVisitDALBASE.SelectMedPatVisitOLE(patientId, visitId, oleCisConn);
            //    default:
            return medPatVisitDALBASE.SelectMedPatVisit(patientId, visitId);
            //}
        }

        public virtual int InsertMedPatVisit(MedicalSytem.Soft.Model.MedPatVisit MedPatVisit, DbTransaction oleCisTrans)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medPatVisitDALBASE.InsertMedPatVisitOdbc(MedPatVisit, oleCisTrans);
            //    case "ORACLE":
            //        return medPatVisitDALBASE.InsertMedPatVisit(MedPatVisit, oleCisTrans);
            //    case "SQLSERVER":
            //        return medPatVisitDALBASE.InsertMedPatVisitSQL(MedPatVisit, oleCisTrans);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medPatVisitDALBASE.InsertMedPatVisitOLE(MedPatVisit, oleCisTrans);
            //    default:
            return medPatVisitDALBASE.InsertMedPatVisit(MedPatVisit);
            //}
        }

        public virtual int UpdateMedPatVisit(MedicalSytem.Soft.Model.MedPatVisit MedPatVisit, DbTransaction oleCisTrans)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medPatVisitDALBASE.UpdateMedPatVisitOdbc(MedPatVisit, oleCisTrans);
            //    case "ORACLE":
            //        return medPatVisitDALBASE.UpdateMedPatVisit(MedPatVisit, oleCisTrans);
            //    case "SQLSERVER":
            //        return medPatVisitDALBASE.UpdateMedPatVisitSQL(MedPatVisit, oleCisTrans);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medPatVisitDALBASE.UpdateMedPatVisitOLE(MedPatVisit, oleCisTrans);
            //    default:
            return medPatVisitDALBASE.UpdateMedPatVisit(MedPatVisit);
            //}
        }
        #endregion

        public virtual MedicalSytem.Soft.Model.MedVsHisOperApplyV2 SelectMedVsHisOperApplyV2HisReq(string hisApplyNo, string hisPatientId, string hisVisitId, string hisScheduleId, string reqdatetime)
        {

            return medVsHisOperApplyV2DALBASE.SelectMedVsHisOperApplyV2HisReq(hisApplyNo, hisPatientId, hisVisitId, hisScheduleId, reqdatetime);

        }

        #region 病人基本信息

        private   MedicalSytem.Soft.Model.MedPatMasterIndex SelectMedPatMasterIndex(string patientId)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medPatMasterIndexDALBASE.SelectMedPatMasterIndexOdbc(patientId);
                case "ORACLE":
                    return medPatMasterIndexDALBASE.SelectMedPatMasterIndex(patientId);
                case "SQLSERVER":
                    return medPatMasterIndexDALBASE.SelectMedPatMasterIndexSQL(patientId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medPatMasterIndexDALBASE.SelectMedPatMasterIndexOLE(patientId);
                default:
                    return medPatMasterIndexDALBASE.SelectMedPatMasterIndex(patientId);
            }
        }

        public   int InsertMedPatMasterIndex(MedicalSytem.Soft.Model.MedPatMasterIndex MedPatMasterIndex)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medPatMasterIndexDALBASE.InsertMedPatMasterIndexOdbc(MedPatMasterIndex);
                case "ORACLE":
                    return medPatMasterIndexDALBASE.InsertMedPatMasterIndex(MedPatMasterIndex);
                case "SQLSERVER":
                    return medPatMasterIndexDALBASE.InsertMedPatMasterIndexSQL(MedPatMasterIndex);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medPatMasterIndexDALBASE.InsertMedPatMasterIndexOLE(MedPatMasterIndex);
                default:
                    return medPatMasterIndexDALBASE.InsertMedPatMasterIndex(MedPatMasterIndex);
            }
        }

        public virtual int UpdateMedPatMasterIndex(MedicalSytem.Soft.Model.MedPatMasterIndex MedPatMasterIndex)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medPatMasterIndexDALBASE.UpdateMedPatMasterIndexOdbc(MedPatMasterIndex);
                case "ORACLE":
                    return medPatMasterIndexDALBASE.UpdateMedPatMasterIndex(MedPatMasterIndex);
                case "SQLSERVER":
                    return medPatMasterIndexDALBASE.UpdateMedPatMasterIndexSQL(MedPatMasterIndex);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medPatMasterIndexDALBASE.UpdateMedPatMasterIndexOLE(MedPatMasterIndex);
                default:
                    return medPatMasterIndexDALBASE.UpdateMedPatMasterIndex(MedPatMasterIndex);
            }
        }
        #endregion
        #region 病人基本信息 Trans

        public virtual MedicalSytem.Soft.Model.MedPatMasterIndex SelectMedPatMasterIndex(string patientId, DbConnection oleCisConn)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medPatMasterIndexDALBASE.SelectMedPatMasterIndexOdbc(patientId, oleCisConn);
            //    case "ORACLE":
            //        return medPatMasterIndexDALBASE.SelectMedPatMasterIndex(patientId, oleCisConn);
            //    case "SQLSERVER":
            //        return medPatMasterIndexDALBASE.SelectMedPatMasterIndexSQL(patientId, oleCisConn);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medPatMasterIndexDALBASE.SelectMedPatMasterIndexOLE(patientId, oleCisConn);
            //    default:
            return medPatMasterIndexDALBASE.SelectMedPatMasterIndex(patientId);
            //}
        }

        public virtual int InsertMedPatMasterIndex(MedicalSytem.Soft.Model.MedPatMasterIndex MedPatMasterIndex, DbTransaction oleCisTrans)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medPatMasterIndexDALBASE.InsertMedPatMasterIndexOdbc(MedPatMasterIndex, oleCisTrans);
            //    case "ORACLE":
            //        return medPatMasterIndexDALBASE.InsertMedPatMasterIndex(MedPatMasterIndex, oleCisTrans);
            //    case "SQLSERVER":
            //        return medPatMasterIndexDALBASE.InsertMedPatMasterIndexSQL(MedPatMasterIndex, oleCisTrans);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medPatMasterIndexDALBASE.InsertMedPatMasterIndexOLE(MedPatMasterIndex, oleCisTrans);
            //    default:
            return medPatMasterIndexDALBASE.InsertMedPatMasterIndex(MedPatMasterIndex);
            //}
        }

        public virtual int UpdateMedPatMasterIndex(MedicalSytem.Soft.Model.MedPatMasterIndex MedPatMasterIndex, DbTransaction oleCisTrans)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medPatMasterIndexDALBASE.UpdateMedPatMasterIndexOdbc(MedPatMasterIndex, oleCisTrans);
            //    case "ORACLE":
            //        return medPatMasterIndexDALBASE.UpdateMedPatMasterIndex(MedPatMasterIndex, oleCisTrans);
            //    case "SQLSERVER":
            //        return medPatMasterIndexDALBASE.UpdateMedPatMasterIndexSQL(MedPatMasterIndex, oleCisTrans);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medPatMasterIndexDALBASE.UpdateMedPatMasterIndexOLE(MedPatMasterIndex, oleCisTrans);
            //    default:
            return medPatMasterIndexDALBASE.UpdateMedPatMasterIndex(MedPatMasterIndex);
            //}
        }
        #endregion

        #region 床位记录
        /// <summary>
        /// 根据病区代码和床位别名查询
        /// </summary>
        /// <param name="wardCode"></param>
        /// <param name="bedLabel"></param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedBedRec SelectMedBedLabelRec(string wardCode, string bedLabel)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medBedRecDALBASE.SelectMedBedLabelRec(wardCode, bedLabel);
            //    case "ORACLE":
            //        return medBedRecDALBASE.SelectMedBedLabelRec(wardCode, bedLabel);
            //    case "SQLSERVER":
            //        return medBedRecDALBASE.SelectMedBedLabelRec(wardCode, bedLabel);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medBedRecDALBASE.SelectMedBedLabelRec(wardCode, bedLabel);
            //    default:
            return medBedRecDALBASE.SelectMedBedLabelRec(wardCode, bedLabel);
            //}
        }
        /// <summary>
        /// 根据病区代码和床位号查询
        /// </summary>
        /// <param name="wardCode"></param>
        /// <param name="bedNo"></param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedBedRec SelectMedBedRec(string wardCode, string bedNo)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medBedRecDALBASE.SelectMedBedRecOdbc(wardCode, bedNo);
                case "ORACLE":
                    return medBedRecDALBASE.SelectMedBedRec(wardCode, bedNo);
                case "SQLSERVER":
                    return medBedRecDALBASE.SelectMedBedRecSQL(wardCode, bedNo);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medBedRecDALBASE.SelectMedBedRecOLE(wardCode, bedNo);
                default:
                    return medBedRecDALBASE.SelectMedBedRec(wardCode, bedNo);
            }
        }
        /// <summary>
        /// 插入床位记录
        /// </summary>
        /// <param name="medBedRec"></param>
        /// <returns></returns>
        public virtual int InsertMedBedRec(MedicalSytem.Soft.Model.MedBedRec medBedRec)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medBedRecDALBASE.InsertMedBedRecOdbc(medBedRec);
                case "ORACLE":
                    return medBedRecDALBASE.InsertMedBedRec(medBedRec);
                case "SQLSERVER":
                    return medBedRecDALBASE.InsertMedBedRecSQL(medBedRec);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medBedRecDALBASE.InsertMedBedRecOLE(medBedRec);
                default:
                    return medBedRecDALBASE.InsertMedBedRec(medBedRec);
            }
        }
        /// <summary>
        /// 更新床位记录
        /// </summary>
        /// <param name="medBedRec"></param>
        /// <returns></returns>
        public virtual int UpdateMedBedRec(MedicalSytem.Soft.Model.MedBedRec medBedRec)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medBedRecDALBASE.UpdateMedBedRecOdbc(medBedRec);
                case "ORACLE":
                    return medBedRecDALBASE.UpdateMedBedRec(medBedRec);
                case "SQLSERVER":
                    return medBedRecDALBASE.UpdateMedBedRecSQL(medBedRec);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medBedRecDALBASE.UpdateMedBedRecOLE(medBedRec); ;
                default:
                    return medBedRecDALBASE.UpdateMedBedRec(medBedRec);
            }
        }
        #endregion

        #region 床位记录 Trans
        /// <summary>
        /// 根据病区代码和床位别名查询
        /// </summary>
        /// <param name="wardCode"></param>
        /// <param name="bedLabel"></param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedBedRec SelectMedBedLabelRec(string wardCode, string bedLabel, DbConnection oleCisConn)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medBedRecDALBASE.SelectMedBedLabelRec(wardCode, bedLabel, oleCisConn);
            //    case "ORACLE":
            //        return medBedRecDALBASE.SelectMedBedLabelRec(wardCode, bedLabel, oleCisConn);
            //    case "SQLSERVER":
            //        return medBedRecDALBASE.SelectMedBedLabelRec(wardCode, bedLabel, oleCisConn);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medBedRecDALBASE.SelectMedBedLabelRec(wardCode, bedLabel, oleCisConn);
            //    default:
            return medBedRecDALBASE.SelectMedBedLabelRec(wardCode, bedLabel, oleCisConn);
            //}
        }
        /// <summary>
        /// 根据病区代码和床位号查询
        /// </summary>
        /// <param name="wardCode"></param>
        /// <param name="bedNo"></param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedBedRec SelectMedBedRec(string wardCode, string bedNo, DbConnection oleCisConn)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medBedRecDALBASE.SelectMedBedRecOdbc(wardCode, bedNo, oleCisConn);
            //    case "ORACLE":
            //        return medBedRecDALBASE.SelectMedBedRec(wardCode, bedNo, oleCisConn);
            //    case "SQLSERVER":
            //        return medBedRecDALBASE.SelectMedBedRecSQL(wardCode, bedNo, oleCisConn);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medBedRecDALBASE.SelectMedBedRecOLE(wardCode, bedNo, oleCisConn);
            //    default:
            return medBedRecDALBASE.SelectMedBedRec(wardCode, bedNo);
            //}
        }
        /// <summary>
        /// 插入床位记录
        /// </summary>
        /// <param name="medBedRec"></param>
        /// <returns></returns>
        public virtual int InsertMedBedRec(MedicalSytem.Soft.Model.MedBedRec medBedRec, DbTransaction oleCisTrans)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medBedRecDALBASE.InsertMedBedRecOdbc(medBedRec, oleCisTrans);
            //    case "ORACLE":
            //        return medBedRecDALBASE.InsertMedBedRec(medBedRec, oleCisTrans);
            //    case "SQLSERVER":
            //        return medBedRecDALBASE.InsertMedBedRecSQL(medBedRec, oleCisTrans);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medBedRecDALBASE.InsertMedBedRecOLE(medBedRec, oleCisTrans);
            //    default:
            return medBedRecDALBASE.InsertMedBedRec(medBedRec);
            //}
        }
        /// <summary>
        /// 更新床位记录
        /// </summary>
        /// <param name="medBedRec"></param>
        /// <returns></returns>
        public virtual int UpdateMedBedRec(MedicalSytem.Soft.Model.MedBedRec medBedRec, DbTransaction oleCisTrans)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medBedRecDALBASE.UpdateMedBedRecOdbc(medBedRec, oleCisTrans);
            //    case "ORACLE":
            //        return medBedRecDALBASE.UpdateMedBedRec(medBedRec, oleCisTrans);
            //    case "SQLSERVER":
            //        return medBedRecDALBASE.UpdateMedBedRecSQL(medBedRec, oleCisTrans);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medBedRecDALBASE.UpdateMedBedRecOLE(medBedRec, oleCisTrans);
            //default:
            return medBedRecDALBASE.UpdateMedBedRec(medBedRec);
            //}
        }
        #endregion

        #region 监护仪记录
        /// <summary>
        /// 插入监护仪记录
        /// </summary>
        /// <param name="medMonitorDict"></param>
        /// <returns></returns>
        public virtual int InsertMedMonitorDict(MedicalSytem.Soft.Model.MedMonitorDict medMonitorDict)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medMonitorDictDALBASE.InsertMedMonitorDictODBC(medMonitorDict);
                case "ORACLE":
                    return medMonitorDictDALBASE.InsertMedMonitorDict(medMonitorDict);
                case "SQLSERVER":
                    return medMonitorDictDALBASE.InsertMedMonitorDictSQL(medMonitorDict);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medMonitorDictDALBASE.InsertMedMonitorDictOLE(medMonitorDict);
                default:
                    return medMonitorDictDALBASE.InsertMedMonitorDict(medMonitorDict);
            }
        }
        /// <summary>
        /// 更新监护仪记录
        /// </summary>
        /// <param name="medMonitorDict"></param>
        /// <returns></returns>
        public virtual int UpdateMedMonitorDict(MedicalSytem.Soft.Model.MedMonitorDict medMonitorDict)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medMonitorDictDALBASE.UpdateMedMonitorDictODBC(medMonitorDict);
                case "ORACLE":
                    return medMonitorDictDALBASE.UpdateMedMonitorDict(medMonitorDict);
                case "SQLSERVER":
                    return medMonitorDictDALBASE.UpdateMedMonitorDictSQL(medMonitorDict);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medMonitorDictDALBASE.UpdateMedMonitorDictOLE(medMonitorDict);
                default:
                    return medMonitorDictDALBASE.UpdateMedMonitorDict(medMonitorDict);
            }
        }
        /// <summary>
        /// SelectMedMonitorDictWithBedNo
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="wardCode"></param>
        /// <param name="bedNo"></param>
        /// <returns></returns>
        public virtual int SelectOneMedMonitorDictWithBedNo(string patientID, decimal visitID, string wardCode, string bedNo)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medMonitorDictDALBASE.SelectOneMedMonitorDictWithBedNoODBC(patientID, visitID, wardCode, bedNo);
                case "ORACLE":
                    return medMonitorDictDALBASE.SelectOneMedMonitorDictWithBedNo(patientID, visitID, wardCode, bedNo);
                case "SQLSERVER":
                    return medMonitorDictDALBASE.SelectOneMedMonitorDictWithBedNoSQL(patientID, visitID, wardCode, bedNo);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medMonitorDictDALBASE.SelectOneMedMonitorDictWithBedNoOLE(patientID, visitID, wardCode, bedNo);
                default:
                    return medMonitorDictDALBASE.SelectOneMedMonitorDictWithBedNo(patientID, visitID, wardCode, bedNo);
            }
        }
        /// <summary>
        /// 查询监护仪记录
        /// </summary>
        /// <param name="medMonitorDict"></param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedMonitorDict SelectMedMonitorDict(string wardCode, string bedNo)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medMonitorDictDALBASE.SelectMedMonitorDictODBC(wardCode, bedNo);
                case "ORACLE":
                    return medMonitorDictDALBASE.SelectMedMonitorDict(wardCode, bedNo);
                case "SQLSERVER":
                    return medMonitorDictDALBASE.SelectMedMonitorDictSQL(wardCode, bedNo);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medMonitorDictDALBASE.SelectMedMonitorDictOLE(wardCode, bedNo);
                default:
                    return medMonitorDictDALBASE.SelectMedMonitorDict(wardCode, bedNo);
            }
        }

        /// <summary>
        /// 查询单病人监护仪记录
        /// </summary>
        /// <param name="medMonitorDict"></param>
        /// <returns></returns>
        public virtual int SelectOneMedMonitorDict(string patientID, decimal visitID)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medMonitorDictDALBASE.SelectOneMedMonitorDictODBC(patientID, visitID);
                case "ORACLE":
                    return medMonitorDictDALBASE.SelectOneMedMonitorDict(patientID, visitID);
                case "SQLSERVER":
                    return medMonitorDictDALBASE.SelectOneMedMonitorDictSQL(patientID, visitID);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medMonitorDictDALBASE.SelectOneMedMonitorDictOLE(patientID, visitID);
                default:
                    return medMonitorDictDALBASE.SelectOneMedMonitorDict(patientID, visitID);
            }
        }
        #endregion

        #region MedIcuConfig
        /// <summary>
        /// 根据科室获取MedIcuConfig
        /// </summary>
        /// <param name="wardCode"></param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedIcuConfig SelectMedIcuConfig(string wardCode)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medIcuConfigDALBASE.SelectMedIcuConfigODBC(wardCode);
                case "ORACLE":
                    return medIcuConfigDALBASE.SelectMedIcuConfig(wardCode);
                case "SQLSERVER":
                    return medIcuConfigDALBASE.SelectMedIcuConfigSQL(wardCode);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medIcuConfigDALBASE.SelectMedIcuConfigOLE(wardCode);
                default:
                    return medIcuConfigDALBASE.SelectMedIcuConfig(wardCode);
            }
        }
        /// <summary>
        /// 获取全部MedIcuConfig
        /// </summary>
        /// <returns></returns>
        public virtual List<MedicalSytem.Soft.Model.MedIcuConfig> SelectMedIcuConfigList()
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medIcuConfigDALBASE.SelectMedIcuConfigListODBC();
                case "ORACLE":
                    return medIcuConfigDALBASE.SelectMedIcuConfigList();
                case "SQLSERVER":
                    return medIcuConfigDALBASE.SelectMedIcuConfigListSQL();
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medIcuConfigDALBASE.SelectMedIcuConfigListOLE();
                default:
                    return medIcuConfigDALBASE.SelectMedIcuConfigList();
            }
        }
        #endregion

        #region 入出转信息
        /// <summary>
        /// 查询最大入科次数
        /// </summary>
        /// <param name="patientId">病人ID号</param>
        /// <param name="visitId">住院次数</param>
        /// <param name="deptStayed">所在科室代码</param>
        /// <returns></returns>
        public virtual int SelectMaxTransferRe2(string patientId, decimal visitId, string deptStayed)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medTransferDALBASE.SelectMaxTransferRe2(patientId, visitId, deptStayed);
            //    case "ORACLE":
            //        return medTransferDALBASE.SelectMaxTransferRe2(patientId, visitId, deptStayed);
            //    case "SQLSERVER":
            //        return medTransferDALBASE.SelectMaxTransferRe2(patientId, visitId, deptStayed);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medTransferDALBASE.SelectMaxTransferRe2(patientId, visitId, deptStayed);
            //    default:
            return medTransferDALBASE.SelectMaxTransferRe2(patientId, visitId, deptStayed);
            //}
        }

        public virtual MedicalSytem.Soft.Model.MedTransfer SelectMedTransfer(string patientId, decimal visitId, DateTime admissionDateTime)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medTransferDALBASE.SelectMedTransferOdbc(patientId, visitId, admissionDateTime);
                case "ORACLE":
                    return medTransferDALBASE.SelectMedTransfer(patientId, visitId, admissionDateTime);
                case "SQLSERVER":
                    return medTransferDALBASE.SelectMedTransferSQL(patientId, visitId, admissionDateTime);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medTransferDALBASE.SelectMedTransferOLE(patientId, visitId, admissionDateTime);
                default:
                    return medTransferDALBASE.SelectMedTransfer(patientId, visitId, admissionDateTime);
            }
        }

        public virtual int InsertMedTransfer(MedicalSytem.Soft.Model.MedTransfer medTransfer)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medTransferDALBASE.InsertMedTransferOdbc(medTransfer);
                case "ORACLE":
                    return medTransferDALBASE.InsertMedTransfer(medTransfer);
                case "SQLSERVER":
                    return medTransferDALBASE.InsertMedTransferSQL(medTransfer);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medTransferDALBASE.InsertMedTransferOLE(medTransfer);
                default:
                    return medTransferDALBASE.InsertMedTransfer(medTransfer);
            }
        }

        public virtual int UpdateMedTransfer(MedicalSytem.Soft.Model.MedTransfer medTransfer)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medTransferDALBASE.UpdateMedTransferOdbc(medTransfer);
                case "ORACLE":
                    return medTransferDALBASE.UpdateMedTransfer(medTransfer);
                case "SQLSERVER":
                    return medTransferDALBASE.UpdateMedTransferSQL(medTransfer);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medTransferDALBASE.UpdateMedTransferOLE(medTransfer);
                default:
                    return medTransferDALBASE.UpdateMedTransfer(medTransfer);
            }
        }
        #endregion
        #region 入出转信息 Trans
        /// <summary>
        /// 查询最大入科次数
        /// </summary>
        /// <param name="patientId">病人ID号</param>
        /// <param name="visitId">住院次数</param>
        /// <param name="deptStayed">所在科室代码</param>
        /// <returns></returns>
        public virtual int SelectMaxTransferRe2(string patientId, decimal visitId, string deptStayed, DbConnection oleCisConn)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medTransferDALBASE.SelectMaxTransferRe2(patientId, visitId, deptStayed, oleCisConn);
                case "ORACLE":
                    return medTransferDALBASE.SelectMaxTransferRe2(patientId, visitId, deptStayed, oleCisConn);
                case "SQLSERVER":
                    return medTransferDALBASE.SelectMaxTransferRe2SQL(patientId, visitId, deptStayed, oleCisConn);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medTransferDALBASE.SelectMaxTransferRe2(patientId, visitId, deptStayed, oleCisConn);
                default:
                    return medTransferDALBASE.SelectMaxTransferRe2(patientId, visitId, deptStayed, oleCisConn);
            }
        }

        public virtual MedicalSytem.Soft.Model.MedTransfer SelectMedTransfer(string patientId, decimal visitId, DateTime admissionDateTime, DbConnection oleCisConn)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medTransferDALBASE.SelectMedTransferOdbc(patientId, visitId, admissionDateTime, oleCisConn);
            //    case "ORACLE":
            //        return medTransferDALBASE.SelectMedTransfer(patientId, visitId, admissionDateTime, oleCisConn);
            //    case "SQLSERVER":
            //        return medTransferDALBASE.SelectMedTransferSQL(patientId, visitId, admissionDateTime, oleCisConn);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medTransferDALBASE.SelectMedTransferOLE(patientId, visitId, admissionDateTime, oleCisConn);
            //    default:
            return medTransferDALBASE.SelectMedTransfer(patientId, visitId, admissionDateTime);
            //}
        }

        public virtual int InsertMedTransfer(MedicalSytem.Soft.Model.MedTransfer medTransfer, DbTransaction oleCisTrans)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medTransferDALBASE.InsertMedTransferOdbc(medTransfer, oleCisTrans);
            //    case "ORACLE":
            //        return medTransferDALBASE.InsertMedTransfer(medTransfer, oleCisTrans);
            //    case "SQLSERVER":
            //        return medTransferDALBASE.InsertMedTransferSQL(medTransfer, oleCisTrans);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medTransferDALBASE.InsertMedTransferOLE(medTransfer, oleCisTrans);
            //    default:
            return medTransferDALBASE.InsertMedTransfer(medTransfer);
            //}
        }

        public virtual int UpdateMedTransfer(MedicalSytem.Soft.Model.MedTransfer medTransfer, DbTransaction oleCisTrans)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medTransferDALBASE.UpdateMedTransferOdbc(medTransfer, oleCisTrans);
            //    case "ORACLE":
            //        return medTransferDALBASE.UpdateMedTransfer(medTransfer, oleCisTrans);
            //    case "SQLSERVER":
            //        return medTransferDALBASE.UpdateMedTransferSQL(medTransfer, oleCisTrans);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medTransferDALBASE.UpdateMedTransferOLE(medTransfer, oleCisTrans);
            //    default:
            return medTransferDALBASE.UpdateMedTransfer(medTransfer);
            //}
        }
        #endregion
        #region 病人生成住院次数--如果医院没有VISITID生成住院次数

        public virtual int SelectMaxMedVsHisPat(string medPatientId)
        {

            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisPatDALBASE.SelectMaxMedVsHisPatODBC(medPatientId);
                case "ORACLE":
                    return medVsHisPatDALBASE.SelectMaxMedVsHisPat(medPatientId);
                case "SQLSERVER":
                    return medVsHisPatDALBASE.SelectMaxMedVsHisPatSQL(medPatientId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisPatDALBASE.SelectMaxMedVsHisPatOLE(medPatientId);
                default:
                    return medVsHisPatDALBASE.SelectMaxMedVsHisPat(medPatientId);
            }
        }
        public virtual MedicalSytem.Soft.Model.MedVsHisPat SelectMedVsHisPat(string medPatientId, decimal medVisitId)
        {

            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisPatDALBASE.SelectMedVsHisPatODBC(medPatientId, medVisitId);
                case "ORACLE":
                    return medVsHisPatDALBASE.SelectMedVsHisPat(medPatientId, medVisitId);
                case "SQLSERVER":
                    return medVsHisPatDALBASE.SelectMedVsHisPatSQL(medPatientId, medVisitId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisPatDALBASE.SelectMedVsHisPatOLE(medPatientId, medVisitId);
                default:
                    return medVsHisPatDALBASE.SelectMedVsHisPat(medPatientId, medVisitId);
            }
        }

        public virtual MedicalSytem.Soft.Model.MedVsHisPat SelectMedVsHisPatHis(string hisPatientId, string hisInpNo, string hisVisitId)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisPatDALBASE.SelectMedVsHisPatHisODBC(hisPatientId, hisInpNo, hisVisitId);
                case "ORACLE":
                    return medVsHisPatDALBASE.SelectMedVsHisPatHis(hisPatientId, hisInpNo, hisVisitId);
                case "SQLSERVER":
                    return medVsHisPatDALBASE.SelectMedVsHisPatHisSQL(hisPatientId, hisInpNo, hisVisitId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisPatDALBASE.SelectMedVsHisPatHisOLE(hisPatientId, hisInpNo, hisVisitId);
                default:
                    return medVsHisPatDALBASE.SelectMedVsHisPatHis(hisPatientId, hisInpNo, hisVisitId);
            }
        }

        public virtual int InsertMedVsHisPat(MedicalSytem.Soft.Model.MedVsHisPat oneMedVsHisPat)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisPatDALBASE.InsertMedVsHisPatODBC(oneMedVsHisPat);
                case "ORACLE":
                    return medVsHisPatDALBASE.InsertMedVsHisPat(oneMedVsHisPat);
                case "SQLSERVER":
                    return medVsHisPatDALBASE.InsertMedVsHisPatSQL(oneMedVsHisPat);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisPatDALBASE.InsertMedVsHisPatOLE(oneMedVsHisPat);
                default:
                    return medVsHisPatDALBASE.InsertMedVsHisPat(oneMedVsHisPat);
            }
        }

        public virtual int UpdateMedVsHisPat(MedicalSytem.Soft.Model.MedVsHisPat oneMedVsHisPat)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisPatDALBASE.UpdateMedVsHisPatODBC(oneMedVsHisPat);
                case "ORACLE":
                    return medVsHisPatDALBASE.UpdateMedVsHisPat(oneMedVsHisPat);
                case "SQLSERVER":
                    return medVsHisPatDALBASE.UpdateMedVsHisPatSQL(oneMedVsHisPat);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisPatDALBASE.UpdateMedVsHisPatOLE(oneMedVsHisPat);
                default:
                    return medVsHisPatDALBASE.UpdateMedVsHisPat(oneMedVsHisPat);
            }
        }

        #endregion


        #region 科室信息
        /// <summary>
        /// 根据科室代码获取信息
        /// </summary>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedDeptDict SelectMedDeptDict(string deptCode)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medDeptDictDALBASE.SelectMedDeptDictOdbc(deptCode);
                case "ORACLE":
                    return medDeptDictDALBASE.SelectMedDeptDict(deptCode);
                case "SQLSERVER":
                    return medDeptDictDALBASE.SelectMedDeptDictSQL(deptCode);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medDeptDictDALBASE.SelectMedDeptDictOLE(deptCode);
                default:
                    return medDeptDictDALBASE.SelectMedDeptDict(deptCode);
            }
        }
        /// <summary>
        /// 根据科室名称获取信息
        /// </summary>
        /// <param name="deptName"></param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedDeptDict SelectMedDeptDictName(string deptName)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medDeptDictDALBASE.SelectMedDeptDictNameOdbc(deptName);
                case "ORACLE":
                    return medDeptDictDALBASE.SelectMedDeptDictName(deptName);
                case "SQLSERVER":
                    return medDeptDictDALBASE.SelectMedDeptDictNameSQL(deptName);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medDeptDictDALBASE.SelectMedDeptDictNameOLE(deptName);
                default:
                    return medDeptDictDALBASE.SelectMedDeptDictName(deptName);
            }
        }

        public virtual int InsertMedDeptDict(MedicalSytem.Soft.Model.MedDeptDict medDeptDict)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medDeptDictDALBASE.InsertMedDeptDictOdbc(medDeptDict);
                case "ORACLE":
                    return medDeptDictDALBASE.InsertMedDeptDict(medDeptDict);
                case "SQLSERVER":
                    return medDeptDictDALBASE.InsertMedDeptDictSQL(medDeptDict);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medDeptDictDALBASE.InsertMedDeptDictOLE(medDeptDict);
                default:
                    return medDeptDictDALBASE.InsertMedDeptDict(medDeptDict);
            }
        }


        public virtual int UpdateMedDiagnosisDict(MedicalSytem.Soft.Model.MedDiagnosisDict medDeptDict)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medDiagnosisDALBASE.UpdateMedDiagnosisDict_Odbc(medDeptDict);
                case "ORACLE":
                    return medDiagnosisDALBASE.UpdateMedDiagnosisDict(medDeptDict);
                case "SQLSERVER":
                    return medDiagnosisDALBASE.UpdateMedDiagnosisDictSQL(medDeptDict);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medDiagnosisDALBASE.UpdateMedDiagnosisDictOLE(medDeptDict);
                default:
                    return medDiagnosisDALBASE.UpdateMedDiagnosisDict(medDeptDict);
            }
        }

        public virtual int InsertMedDiagnosisDict(MedicalSytem.Soft.Model.MedDiagnosisDict medDeptDict)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medDiagnosisDALBASE.InsertMedDiagnosisDict_Odbc(medDeptDict);
                case "ORACLE":
                    return medDiagnosisDALBASE.InsertMedDiagnosisDict(medDeptDict);
                case "SQLSERVER":
                    return medDiagnosisDALBASE.InsertMedDiagnosisDictSQL(medDeptDict);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medDiagnosisDALBASE.InsertMedDiagnosisDictOLE(medDeptDict);
                default:
                    return medDiagnosisDALBASE.InsertMedDiagnosisDict(medDeptDict);
            }
        }

        public virtual int UpdateMedDeptDict(MedicalSytem.Soft.Model.MedDeptDict medDeptDict)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medDeptDictDALBASE.UpdateMedDeptDictOdbc(medDeptDict);
                case "ORACLE":
                    return medDeptDictDALBASE.UpdateMedDeptDict(medDeptDict);
                case "SQLSERVER":
                    return medDeptDictDALBASE.UpdateMedDeptDictSQL(medDeptDict);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medDeptDictDALBASE.UpdateMedDeptDictOLE(medDeptDict);
                default:
                    return medDeptDictDALBASE.UpdateMedDeptDict(medDeptDict);
            }
        }


        public virtual List<MedIfTransDict> SelectMedIfTransDict()
        {
            switch (DateType.ToUpper())
            {
            
                case "ORACLE":
                    return medTransDictDALBASE.SelectMedIfTransDictList();
                case "SQLSERVER":
                    return medTransDictDALBASE.SelectMedIfTransDictListSQL();
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medTransDictDALBASE.SelectMedIfTransDictListOLE();
                default:
                    return medTransDictDALBASE.SelectMedIfTransDictList();
            }
        }

        public virtual int UpdateMedIfTransDict(MedIfTransDict dict)
        {
            switch (DateType.ToUpper())
            {

                case "ORACLE":
                    return medTransDictDALBASE.UpdateMedIfTransDict(dict);
                case "SQLSERVER":
                    return medTransDictDALBASE.UpdateMedIfTransDictSQL(dict);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medTransDictDALBASE.UpdateMedIfTransDictOLE(dict);
                default:
                    return medTransDictDALBASE.UpdateMedIfTransDict(dict);
            }
        
        }

        public virtual int InsertMedIfTransDict(MedIfTransDict dict)
        {
            switch (DateType.ToUpper())
            {

                case "ORACLE":
                    return medTransDictDALBASE.InsertMedIfTransDict(dict);
                case "SQLSERVER":
                    return medTransDictDALBASE.InsertMedIfTransDictSQL(dict);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medTransDictDALBASE.InsertMedIfTransDictOLE(dict);
                default:
                    return medTransDictDALBASE.InsertMedIfTransDict(dict);
            }

        }

        #endregion
        #region 科室信息 Trans

        public virtual MedicalSytem.Soft.Model.MedDeptDict SelectMedDeptDict(string deptCode, DbConnection oleCisConn)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medDeptDictDALBASE.SelectMedDeptDict(deptCode, oleCisConn);
                case "ORACLE":
                    return medDeptDictDALBASE.SelectMedDeptDict(deptCode, oleCisConn);
                case "SQLSERVER":
                    return medDeptDictDALBASE.SelectMedDeptDict(deptCode, oleCisConn);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medDeptDictDALBASE.SelectMedDeptDict(deptCode, oleCisConn);
                default:
                    return medDeptDictDALBASE.SelectMedDeptDict(deptCode, oleCisConn);
            }
        }

        public virtual int InsertMedDeptDict(MedicalSytem.Soft.Model.MedDeptDict medDeptDict, DbTransaction oleCisTrans)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medDeptDictDALBASE.InsertMedDeptDict(medDeptDict, oleCisTrans);
            //    case "ORACLE":
            //        return medIcuConfigDALBASE.SelectMedIcuConfig(wardCode);
            //    case "SQLSERVER":
            //        return medIcuConfigDALBASE.SelectMedIcuConfigSQL(wardCode);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medIcuConfigDALBASE.SelectMedIcuConfigOLE(wardCode);
            //    default:
            return medDeptDictDALBASE.InsertMedDeptDict(medDeptDict, oleCisTrans);
            //}

        }

        public virtual int UpdateMedDeptDict(MedicalSytem.Soft.Model.MedDeptDict medDeptDict, DbTransaction oleCisTrans)
        {
            return medDeptDictDALBASE.UpdateMedDeptDict(medDeptDict, oleCisTrans);
        }
        #endregion

        #region HIS人员信息
        /// <summary>
        /// 根据工号查找信息
        /// </summary>
        /// <param name="userID">工号</param>
        /// <returns>人员信息实体类</returns>
        public virtual MedicalSytem.Soft.Model.MedHisUsers SelectMedHisUsers(string userID)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medHisUsersDALBASE.SelectMedHisUsersOdbc(userID);
                case "ORACLE":
                    return medHisUsersDALBASE.SelectMedHisUsers(userID);
                case "SQLSERVER":
                    return medHisUsersDALBASE.SelectMedHisUsersSQL(userID);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medHisUsersDALBASE.SelectMedHisUsersOLE(userID);
                default:
                    return medHisUsersDALBASE.SelectMedHisUsers(userID);
            }
        }
        /// <summary>
        /// 根据姓名查找信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedHisUsers SelectMedHisUsersName(string userName)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medHisUsersDALBASE.SelectMedHisUsersNameOdbc(userName);
                case "ORACLE":
                    return medHisUsersDALBASE.SelectMedHisUsersName(userName);
                case "SQLSERVER":
                    return medHisUsersDALBASE.SelectMedHisUsersNameSQL(userName);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medHisUsersDALBASE.SelectMedHisUsersNameOLE(userName);
                default:
                    return medHisUsersDALBASE.SelectMedHisUsersName(userName);
            }
        }
        /// <summary>
        /// 插入最新HIS人员信息
        /// </summary>
        /// <param name="medHisUsers"></param>
        /// <returns></returns>
        public virtual int InsertMedHisUsers(MedicalSytem.Soft.Model.MedHisUsers medHisUsers)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medHisUsersDALBASE.InsertMedHisUsersOdbc(medHisUsers);
                case "ORACLE":
                    return medHisUsersDALBASE.InsertMedHisUsers(medHisUsers);
                case "SQLSERVER":
                    return medHisUsersDALBASE.InsertMedHisUsersSQL(medHisUsers);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medHisUsersDALBASE.InsertMedHisUsersOLE(medHisUsers);
                default:
                    return medHisUsersDALBASE.InsertMedHisUsers(medHisUsers);
            }
        }
        /// <summary>
        /// 更新HIS人员信息
        /// </summary>
        /// <param name="medHisUsers"></param>
        /// <returns></returns>
        public virtual int UpdateMedHisUsers(MedicalSytem.Soft.Model.MedHisUsers medHisUsers)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medHisUsersDALBASE.UpdateMedHisUsersOdbc(medHisUsers);
                case "ORACLE":
                    return medHisUsersDALBASE.UpdateMedHisUsers(medHisUsers);
                case "SQLSERVER":
                    return medHisUsersDALBASE.UpdateMedHisUsersSQL(medHisUsers);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medHisUsersDALBASE.UpdateMedHisUsersOLE(medHisUsers);
                default:
                    return medHisUsersDALBASE.UpdateMedHisUsers(medHisUsers);
            }
        }
        #endregion
        #region HIS人员信息-扩展
        /// <summary>
        /// 根据工号查找信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedHisUserInfo SelectMedHisUsersInfo(string userID)
        {
            return medHisUsersInfoDALBASE.SelectMedHisUserInfo(userID);
        }
        /// <summary>
        /// 插入最新HIS人员信息
        /// </summary>
        /// <param name="medHisUsers"></param>
        /// <returns></returns>
        public virtual int InsertMedHisUsersInfo(MedicalSytem.Soft.Model.MedHisUserInfo medHisUsersInfo)
        {
            return medHisUsersInfoDALBASE.InsertMedHisUserInfo(medHisUsersInfo);
        }
        /// <summary>
        /// 更新HIS人员信息
        /// </summary>
        /// <param name="medHisUsers"></param>
        /// <returns></returns>
        public virtual int UpdateMedHisUsersInfo(MedicalSytem.Soft.Model.MedHisUserInfo medHisUsersInfo)
        {
            return medHisUsersInfoDALBASE.UpdateMedHisUserInfo(medHisUsersInfo);
        }
        #endregion
        #region HIS人员信息 Trans
        /// <summary>
        /// 根据工号查找信息
        /// </summary>
        /// <param name="userID">工号</param>
        /// <returns>人员信息实体类</returns>
        public virtual MedicalSytem.Soft.Model.MedHisUsers SelectMedHisUsers(string userID, DbConnection oleCisConn)
        {
            return medHisUsersDALBASE.SelectMedHisUsers(userID, oleCisConn);
        }
        /// <summary>
        /// 根据姓名查找信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedHisUsers SelectMedHisUsersName(string userName, DbConnection oleCisConn)
        {
            return medHisUsersDALBASE.SelectMedHisUsersName(userName, oleCisConn);
        }
        /// <summary>
        /// 插入最新HIS人员信息
        /// </summary>
        /// <param name="medHisUsers"></param>
        /// <returns></returns>
        public virtual int InsertMedHisUsers(MedicalSytem.Soft.Model.MedHisUsers medHisUsers, DbTransaction oleCisTrans)
        {
            return medHisUsersDALBASE.InsertMedHisUsers(medHisUsers, oleCisTrans);
        }
        /// <summary>
        /// 更新HIS人员信息
        /// </summary>
        /// <param name="medHisUsers"></param>
        /// <returns></returns>
        public virtual int UpdateMedHisUsers(MedicalSytem.Soft.Model.MedHisUsers medHisUsers, DbTransaction oleCisTrans)
        {
            return medHisUsersDALBASE.UpdateMedHisUsers(medHisUsers, oleCisTrans);
        }
        #endregion
        #region HIS人员信息-扩展 Trans


        /// <summary>
        /// 根据工号查找信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedHisUserInfo SelectMedHisUsersInfo(string userID, DbConnection oleCisConn)
        {
            return medHisUsersInfoDALBASE.SelectMedHisUserInfo(userID, oleCisConn);
        }
        /// <summary>
        /// 插入最新HIS人员信息
        /// </summary>
        /// <param name="medHisUsers"></param>
        /// <returns></returns>
        public virtual int InsertMedHisUsersInfo(MedicalSytem.Soft.Model.MedHisUserInfo medHisUsersInfo, DbTransaction oleCisTrans)
        {
            return medHisUsersInfoDALBASE.InsertMedHisUserInfo(medHisUsersInfo, oleCisTrans);
        }
        /// <summary>
        /// 更新HIS人员信息
        /// </summary>
        /// <param name="medHisUsers"></param>
        /// <returns></returns>
        public virtual int UpdateMedHisUsersInfo(MedicalSytem.Soft.Model.MedHisUserInfo medHisUsersInfo, DbTransaction oleCisTrans)
        {
            return medHisUsersInfoDALBASE.UpdateMedHisUserInfo(medHisUsersInfo, oleCisTrans);
        }


        private List<MedicalSytem.Soft.Model.MedHisUsers> medHisUserList;
        private List<MedicalSytem.Soft.Model.MedHisUsers> MedHisUserList
        {
            get
            {
                if (medHisUserList != null)
                {
                    return medHisUserList;
                }
                medHisUserList = new List<MedicalSytem.Soft.Model.MedHisUsers>();
                switch (DateType.ToUpper())
                {
                    case "ODBC":
                        break;
                    case "ORACLE":
                        medHisUserList = medHisUsersDALBASE.SelectMedHisUsersList();
                        break;
                    case "SQLSERVER":
                        medHisUserList = medHisUsersDALBASE.SelectMedHisUsersListSQL();
                        break;
                    case "ORACLEOLE":
                    case "ORAOLEDB":
                        medHisUserList = medHisUsersDALBASE.SelectMedHisUserListOLE();
                        break;
                    default:
                        medHisUserList = medHisUsersDALBASE.SelectMedHisUsersList();
                        break;

                }
                return medHisUserList;
            }
        }

        /// <summary>
        /// 返回HIS 人员实体
        /// </summary>
        /// <param name="userIdOrName">姓名或者工号</param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedHisUsers SelectOneMedHisUser(string userIdOrName)
        {

            List<MedicalSytem.Soft.Model.MedHisUsers> MedHisUserALL = MedHisUserList;
            MedicalSytem.Soft.Model.MedHisUsers user = MedHisUserALL.Find(P => P.UserJobId == userIdOrName);
            if (user != null)
            {
                return user;
            }
            return MedHisUserALL.Find(P => P.UserName == userIdOrName);
        }

        /// <summary>
        ///  返回HIS 人员姓名
        /// </summary>
        /// <param name="userIdOrUserName">姓名或者工号</param>
        /// <returns></returns>
        public virtual string SelectMedHisUserName(string userIdOrUserName)
        {
            MedicalSytem.Soft.Model.MedHisUsers user = SelectOneMedHisUser(userIdOrUserName);
            if (user != null)
            {
                return user.UserName;
            }
            return userIdOrUserName;
        }

        /// <summary>
        /// 返回his 人员工号
        /// </summary>
        /// <param name="userIdOrUserName">姓名或者工号</param>
        /// <returns></returns>
        public virtual string SelectMedHisUserID(string userIdOrUserName)
        {
            MedicalSytem.Soft.Model.MedHisUsers user = SelectOneMedHisUser(userIdOrUserName);
            if (user != null)
            {
                return user.UserJobId;
            }
            return userIdOrUserName;
        }
        #endregion

        #region 日志

        /// <summary>
        /// 更新HIS人员信息
        /// </summary>
        /// <param name="medHisUsers"></param>
        /// <returns></returns>
        public virtual int InsertMedIfLog(MedicalSytem.Soft.Model.MedIfLog medIfLog)
        {
            switch (DateType.ToUpper())
            {
                //case "ODBC":
                //    return medHisUsersDALBASE.UpdateMedHisUsersOdbc(medHisUsers);
                //case "ORACLE":
                //    return medIfLogDALBASE.InsertMedifLog(medIfLog);
                //case "SQLSERVER":
                //    return medIfLogDALBASE.InsertMedifLogSQL(medIfLog);
                //case "ORACLEOLE":
                //case "ORAOLEDB":
                //    return medIfLogDALBASE.InsertMedifLogOleDb(medIfLog);
                //default:
                //    return medIfLogDALBASE.InsertMedifLog(medIfLog);
            }
            return 1;
        }

        #endregion

        #region 手术名称字典  //??????
        public virtual MedicalSytem.Soft.Model.MedOperationDict SelectMedOperationDict(string deptDict)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationDictDALBASE.SelectMedOperationDict(deptDict);
                case "ORACLE":
                    return medOperationDictDALBASE.SelectMedOperationDict(deptDict);
                case "SQLSERVER":
                    return medOperationDictDALBASE.SelectMedOperationDictSQL(deptDict);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationDictDALBASE.SelectMedOperationDict(deptDict);
                default:
                    return medOperationDictDALBASE.SelectMedOperationDict(deptDict);
            }
        }

        public virtual int InsertMedOperationDict(MedicalSytem.Soft.Model.MedOperationDict medOperationDict)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationDictDALBASE.InsertMedOperationDictODBC(medOperationDict);
                case "ORACLE":
                    return medOperationDictDALBASE.InsertMedOperationDict(medOperationDict);
                case "SQLSERVER":
                    return medOperationDictDALBASE.InsertMedOperationDictSQL(medOperationDict);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationDictDALBASE.InsertMedOperationDictOLE(medOperationDict);
                default:
                    return medOperationDictDALBASE.InsertMedOperationDict(medOperationDict);
            }
        }

        public virtual int UpdateMedOperationDict(MedicalSytem.Soft.Model.MedOperationDict medOperationDict)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationDictDALBASE.UpdateMedOperationDictODBC(medOperationDict);
                case "ORACLE":
                    return medOperationDictDALBASE.UpdateMedOperationDict(medOperationDict);
                case "SQLSERVER":
                    return medOperationDictDALBASE.UpdateMedOperationDictSQL(medOperationDict);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationDictDALBASE.UpdateMedOperationDictOLE(medOperationDict);
                default:
                    return medOperationDictDALBASE.UpdateMedOperationDict(medOperationDict);
            }
        }
        #endregion
        #region 手术预约对照信息

        public virtual MedicalSytem.Soft.Model.MedVsHisOperApplyV2 SelectMedVsHisOperApplyV2His(string hisApplyNo, string hisPatientId, string hisVisitId, string hisScheduleId)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOperApplyV2DALBASE.SelectMedVsHisOperApplyV2HisOdbc(hisApplyNo, hisPatientId, hisVisitId, hisScheduleId);
                case "ORACLE":
                    return medVsHisOperApplyV2DALBASE.SelectMedVsHisOperApplyV2His(hisApplyNo, hisPatientId, hisVisitId, hisScheduleId);
                case "SQLSERVER":
                    return medVsHisOperApplyV2DALBASE.SelectMedVsHisOperApplyV2HisSQL(hisApplyNo, hisPatientId, hisVisitId, hisScheduleId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOperApplyV2DALBASE.SelectMedVsHisOperApplyV2HisOLE(hisApplyNo, hisPatientId, hisVisitId, hisScheduleId);
                default:
                    return medVsHisOperApplyV2DALBASE.SelectMedVsHisOperApplyV2His(hisApplyNo, hisPatientId, hisVisitId, hisScheduleId);
            }
        }

        public virtual MedicalSytem.Soft.Model.MedVsHisOperApplyV2 SelectMedVsHisOperApplyV2(string medPatientId, decimal medVisitId, decimal medSchedule)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOperApplyV2DALBASE.SelectMedVsHisOperApplyV2Odbc(medPatientId, medVisitId, medSchedule);
                case "ORACLE":
                    return medVsHisOperApplyV2DALBASE.SelectMedVsHisOperApplyV2(medPatientId, medVisitId, medSchedule);
                case "SQLSERVER":
                    return medVsHisOperApplyV2DALBASE.SelectMedVsHisOperApplyV2SQL(medPatientId, medVisitId, medSchedule);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOperApplyV2DALBASE.SelectMedVsHisOperApplyV2OLE(medPatientId, medVisitId, medSchedule);
                default:
                    return medVsHisOperApplyV2DALBASE.SelectMedVsHisOperApplyV2(medPatientId, medVisitId, medSchedule);
            }
        }

        public virtual int SelectCountMedVsHisOperApplyV2ReqDateTime(string hisApplyNo, string hisPatientId, string hisVisitId, decimal hisScheduleId, string reqDateTime)
        {
            return medVsHisOperApplyV2DALBASE.SelectCountMedVsHisOperApplyV2ReqDateTime(hisApplyNo, hisPatientId, hisVisitId, hisScheduleId, reqDateTime);
        }

        public virtual int SelectCountMedVsHisOperApplyV2His(string hisApplyNo, string hisPatientId, string hisVisitId, string hisScheduleId)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOperApplyV2DALBASE.SelectCountMedVsHisOperApplyV2HisOdbc(hisApplyNo, hisPatientId, hisVisitId, hisScheduleId);
                case "ORACLE":
                    return medVsHisOperApplyV2DALBASE.SelectCountMedVsHisOperApplyV2His(hisApplyNo, hisPatientId, hisVisitId, hisScheduleId);
                case "SQLSERVER":
                    return medVsHisOperApplyV2DALBASE.SelectCountMedVsHisOperApplyV2HisSQL(hisApplyNo, hisPatientId, hisVisitId, hisScheduleId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOperApplyV2DALBASE.SelectCountMedVsHisOperApplyV2HisOLE(hisApplyNo, hisPatientId, hisVisitId, hisScheduleId);
                default:
                    return medVsHisOperApplyV2DALBASE.SelectCountMedVsHisOperApplyV2His(hisApplyNo, hisPatientId, hisVisitId, hisScheduleId);
            }
        }

        public virtual int InsertMedVsHisOperApplyV2(MedicalSytem.Soft.Model.MedVsHisOperApplyV2 oneMedVsHisOperApply)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOperApplyV2DALBASE.InsertMedVsHisOperApplyV2Odbc(oneMedVsHisOperApply);
                case "ORACLE":
                    return medVsHisOperApplyV2DALBASE.InsertMedVsHisOperApplyV2(oneMedVsHisOperApply);
                case "SQLSERVER":
                    return medVsHisOperApplyV2DALBASE.InsertMedVsHisOperApplyV2SQL(oneMedVsHisOperApply);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOperApplyV2DALBASE.InsertMedVsHisOperApplyV2OLE(oneMedVsHisOperApply);
                default:
                    return medVsHisOperApplyV2DALBASE.InsertMedVsHisOperApplyV2(oneMedVsHisOperApply);
            }
        }

        public virtual int UpdateMedVsHisOperApplyV2(MedicalSytem.Soft.Model.MedVsHisOperApplyV2 oneMedVsHisOperApply)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOperApplyV2DALBASE.UpdateMedVsHisOperApplyV2Odbc(oneMedVsHisOperApply);
                case "ORACLE":
                    return medVsHisOperApplyV2DALBASE.UpdateMedVsHisOperApplyV2(oneMedVsHisOperApply);
                case "SQLSERVER":
                    return medVsHisOperApplyV2DALBASE.UpdateMedVsHisOperApplyV2SQL(oneMedVsHisOperApply);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOperApplyV2DALBASE.UpdateMedVsHisOperApplyV2OLE(oneMedVsHisOperApply);
                default:
                    return medVsHisOperApplyV2DALBASE.UpdateMedVsHisOperApplyV2(oneMedVsHisOperApply);
            }
        }

        public virtual int DeleteMedVsHisOperApplyV2(MedicalSytem.Soft.Model.MedVsHisOperApplyV2 oneMedVsHisOperApply)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOperApplyV2DALBASE.DeleteMedVsHisOperApplyV2Odbc(oneMedVsHisOperApply.MedPatientId, oneMedVsHisOperApply.MedVisitId, oneMedVsHisOperApply.MedScheduleId);
                case "ORACLE":
                    return medVsHisOperApplyV2DALBASE.DeleteMedVsHisOperApplyV2(oneMedVsHisOperApply.MedPatientId, oneMedVsHisOperApply.MedVisitId, oneMedVsHisOperApply.MedScheduleId);
                case "SQLSERVER":
                    return medVsHisOperApplyV2DALBASE.DeleteMedVsHisOperApplyV2SQL(oneMedVsHisOperApply.MedPatientId, oneMedVsHisOperApply.MedVisitId, oneMedVsHisOperApply.MedScheduleId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOperApplyV2DALBASE.DeleteMedVsHisOperApplyV2OLE(oneMedVsHisOperApply.MedPatientId, oneMedVsHisOperApply.MedVisitId, oneMedVsHisOperApply.MedScheduleId);
                default:
                    return medVsHisOperApplyV2DALBASE.DeleteMedVsHisOperApplyV2(oneMedVsHisOperApply.MedPatientId, oneMedVsHisOperApply.MedVisitId, oneMedVsHisOperApply.MedScheduleId);
            }
        }

        #endregion
        #region 手术预约信息 预约信息和手术名称信息OperationSchedule

        public virtual int SelectCountMedOperationSchedule(string patientId, decimal visitId, decimal scheduleId)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationScheduleDALBASE.SelectCountMedOperationScheduleOdbc(patientId, visitId, scheduleId);
                case "ORACLE":
                    return medOperationScheduleDALBASE.SelectCountMedOperationSchedule(patientId, visitId, scheduleId);
                case "SQLSERVER":
                    return medOperationScheduleDALBASE.SelectCountMedOperationScheduleSQL(patientId, visitId, scheduleId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationScheduleDALBASE.SelectCountMedOperationScheduleOLE(patientId, visitId, scheduleId);
                default:
                    return medOperationScheduleDALBASE.SelectCountMedOperationSchedule(patientId, visitId, scheduleId);
            }
        }

        public virtual MedicalSytem.Soft.Model.MedOperationSchedule SelectMedOperationSchedule(string patientId, decimal visitId, decimal scheduleId)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationScheduleDALBASE.SelectMedOperationScheduleOdbc(patientId, visitId, scheduleId);
                case "ORACLE":
                    return medOperationScheduleDALBASE.SelectMedOperationSchedule(patientId, visitId, scheduleId);
                case "SQLSERVER":
                    return medOperationScheduleDALBASE.SelectMedOperationScheduleSQL(patientId, visitId, scheduleId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationScheduleDALBASE.SelectMedOperationScheduleOLE(patientId, visitId, scheduleId);
                default:
                    return medOperationScheduleDALBASE.SelectMedOperationSchedule(patientId, visitId, scheduleId);
            }
        }
        public virtual MedicalSytem.Soft.Model.MedOperationSchedule SelectMedOperationScheduleWithOperId(string patientId, decimal visitId, decimal operId)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationScheduleDALBASE.SelectMedOperationScheduleWithOperIdOdbc(patientId, visitId, operId);
                case "ORACLE":
                    return medOperationScheduleDALBASE.SelectMedOperationScheduleWithOperId(patientId, visitId, operId);
                case "SQLSERVER":
                    return medOperationScheduleDALBASE.SelectMedOperationScheduleWithOperIdSQL(patientId, visitId, operId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationScheduleDALBASE.SelectMedOperationScheduleWithOperIdOLE(patientId, visitId, operId);
                default:
                    return medOperationScheduleDALBASE.SelectMedOperationScheduleWithOperId(patientId, visitId, operId);
            }
        }
        public virtual int InsertMedOperationSchedule(MedicalSytem.Soft.Model.MedOperationSchedule oneMedOperationSchedule)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationScheduleDALBASE.InsertMedOperationScheduleOdbc(oneMedOperationSchedule);
                case "ORACLE":
                    return medOperationScheduleDALBASE.InsertMedOperationSchedule(oneMedOperationSchedule);
                case "SQLSERVER":
                    return medOperationScheduleDALBASE.InsertMedOperationScheduleSQL(oneMedOperationSchedule);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationScheduleDALBASE.InsertMedOperationScheduleOLE(oneMedOperationSchedule);
                default:
                    return medOperationScheduleDALBASE.InsertMedOperationSchedule(oneMedOperationSchedule);
            }
        }

        public virtual int UpdateMedOperationSchedule(MedicalSytem.Soft.Model.MedOperationSchedule oneMedOperationSchedule)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationScheduleDALBASE.UpdateMedOperationScheduleOdbc(oneMedOperationSchedule);
                case "ORACLE":
                    return medOperationScheduleDALBASE.UpdateMedOperationSchedule(oneMedOperationSchedule);
                case "SQLSERVER":
                    return medOperationScheduleDALBASE.UpdateMedOperationScheduleSQL(oneMedOperationSchedule);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationScheduleDALBASE.UpdateMedOperationScheduleOLE(oneMedOperationSchedule);
                default:
                    return medOperationScheduleDALBASE.UpdateMedOperationSchedule(oneMedOperationSchedule);
            }
        }

        public virtual int DeleteMedOperationSchedule(MedicalSytem.Soft.Model.MedOperationSchedule oneMedOperationSchedule)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationScheduleDALBASE.DeleteMedOperationScheduleOdbc(oneMedOperationSchedule.PatientId, oneMedOperationSchedule.VisitId, oneMedOperationSchedule.ScheduleId);
                case "ORACLE":
                    return medOperationScheduleDALBASE.DeleteMedOperationSchedule(oneMedOperationSchedule.PatientId, oneMedOperationSchedule.VisitId, oneMedOperationSchedule.ScheduleId);
                case "SQLSERVER":
                    return medOperationScheduleDALBASE.DeleteMedOperationScheduleSQL(oneMedOperationSchedule.PatientId, oneMedOperationSchedule.VisitId, oneMedOperationSchedule.ScheduleId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationScheduleDALBASE.DeleteMedOperationScheduleOLE(oneMedOperationSchedule.PatientId, oneMedOperationSchedule.VisitId, oneMedOperationSchedule.ScheduleId);
                default:
                    return medOperationScheduleDALBASE.DeleteMedOperationSchedule(oneMedOperationSchedule.PatientId, oneMedOperationSchedule.VisitId, oneMedOperationSchedule.ScheduleId);
            }
        }

        //------------------------------------------------------------------------

        public virtual MedicalSytem.Soft.Model.MedScheduledOperationName SelectMedScheduleOperationName(string patientId, decimal visitId, decimal scheduleId, decimal operationNo)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medScheduleOperationNameDALBASE.SelectMedScheduledOperationNameOdbc(patientId, visitId, scheduleId, operationNo);
                case "ORACLE":
                    return medScheduleOperationNameDALBASE.SelectMedScheduledOperationName(patientId, visitId, scheduleId, operationNo);
                case "SQLSERVER":
                    return medScheduleOperationNameDALBASE.SelectMedScheduledOperationNameSQL(patientId, visitId, scheduleId, operationNo);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medScheduleOperationNameDALBASE.SelectMedScheduledOperationNameOLE(patientId, visitId, scheduleId, operationNo);
                default:
                    return medScheduleOperationNameDALBASE.SelectMedScheduledOperationName(patientId, visitId, scheduleId, operationNo);
            }
        }

        public virtual List<MedicalSytem.Soft.Model.MedScheduledOperationName> SelectMedScheduleOperationName(string patientId, decimal visitId, decimal scheduleId)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medScheduleOperationNameDALBASE.SelectMedScheduledOperationNameOdbc(patientId, visitId, scheduleId);
                case "ORACLE":
                    return medScheduleOperationNameDALBASE.SelectMedScheduledOperationName(patientId, visitId, scheduleId);
                case "SQLSERVER":
                    return medScheduleOperationNameDALBASE.SelectMedScheduledOperationNameSQL(patientId, visitId, scheduleId);

                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medScheduleOperationNameDALBASE.SelectMedScheduledOperationNameOLE(patientId, visitId, scheduleId);
                default:
                    return medScheduleOperationNameDALBASE.SelectMedScheduledOperationName(patientId, visitId, scheduleId);
            }
        }

        public virtual int InsertMedScheduleOperationName(MedicalSytem.Soft.Model.MedScheduledOperationName oneMedScheduleOperationName)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medScheduleOperationNameDALBASE.InsertMedScheduledOperationNameOdbc(oneMedScheduleOperationName);
                case "ORACLE":
                    return medScheduleOperationNameDALBASE.InsertMedScheduledOperationName(oneMedScheduleOperationName);
                case "SQLSERVER":
                    return medScheduleOperationNameDALBASE.InsertMedScheduledOperationNameSQL(oneMedScheduleOperationName);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medScheduleOperationNameDALBASE.InsertMedScheduledOperationNameOLE(oneMedScheduleOperationName);
                default:
                    return medScheduleOperationNameDALBASE.InsertMedScheduledOperationName(oneMedScheduleOperationName);
            }
        }

        public virtual int UpdateMedScheduleOperationName(MedicalSytem.Soft.Model.MedScheduledOperationName oneMedScheduleOperationName)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medScheduleOperationNameDALBASE.UpdateMedScheduledOperationNameOdbc(oneMedScheduleOperationName);
                case "ORACLE":
                    return medScheduleOperationNameDALBASE.UpdateMedScheduledOperationName(oneMedScheduleOperationName);
                case "SQLSERVER":
                    return medScheduleOperationNameDALBASE.UpdateMedScheduledOperationNameSQL(oneMedScheduleOperationName);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medScheduleOperationNameDALBASE.UpdateMedScheduledOperationNameOLE(oneMedScheduleOperationName);
                default:
                    return medScheduleOperationNameDALBASE.UpdateMedScheduledOperationName(oneMedScheduleOperationName);
            }
        }

        public virtual int DeleteMedScheduleOperationName(MedicalSytem.Soft.Model.MedScheduledOperationName oneMedScheduleOperationName)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medScheduleOperationNameDALBASE.DeleteMedScheduledOperationNameOdbc(oneMedScheduleOperationName.PatientId, oneMedScheduleOperationName.VisitId, oneMedScheduleOperationName.ScheduleId, oneMedScheduleOperationName.OperNo);
                case "ORACLE":
                    return medScheduleOperationNameDALBASE.DeleteMedScheduledOperationName(oneMedScheduleOperationName.PatientId, oneMedScheduleOperationName.VisitId, oneMedScheduleOperationName.ScheduleId, oneMedScheduleOperationName.OperNo);
                case "SQLSERVER":
                    return medScheduleOperationNameDALBASE.DeleteMedScheduledOperationNameSQL(oneMedScheduleOperationName.PatientId, oneMedScheduleOperationName.VisitId, oneMedScheduleOperationName.ScheduleId, oneMedScheduleOperationName.OperNo);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medScheduleOperationNameDALBASE.DeleteMedScheduledOperationNameOLE(oneMedScheduleOperationName.PatientId, oneMedScheduleOperationName.VisitId, oneMedScheduleOperationName.ScheduleId, oneMedScheduleOperationName.OperNo);
                default:
                    return medScheduleOperationNameDALBASE.DeleteMedScheduledOperationName(oneMedScheduleOperationName.PatientId, oneMedScheduleOperationName.VisitId, oneMedScheduleOperationName.ScheduleId, oneMedScheduleOperationName.OperNo);
            }
        }

        public virtual int DeleteMedScheduleOperationName(string patientId, decimal visitId, decimal scheduleId)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medScheduleOperationNameDALBASE.DeleteMedScheduledOperationNameOdbc(patientId, visitId, scheduleId);
                case "ORACLE":
                    return medScheduleOperationNameDALBASE.DeleteMedScheduledOperationName(patientId, visitId, scheduleId);
                case "SQLSERVER":
                    return medScheduleOperationNameDALBASE.DeleteMedScheduledOperationNameSQL(patientId, visitId, scheduleId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medScheduleOperationNameDALBASE.DeleteMedScheduledOperationNameOLE(patientId, visitId, scheduleId);
                default:
                    return medScheduleOperationNameDALBASE.DeleteMedScheduledOperationName(patientId, visitId, scheduleId);
            }
        }

        #endregion
        #region 手术预约信息 预约信息和手术名称信息OperationSchedule Trans

        public virtual int SelectCountMedOperationSchedule(string patientId, decimal visitId, decimal scheduleId, DbTransaction oleCisTrans)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medOperationScheduleDALBASE.SelectCountMedOperationSchedule(patientId, visitId, scheduleId, oleCisTrans);
            //    case "ORACLE":
            //        return medOperationScheduleDALBASE.SelectCountMedOperationSchedule(patientId, visitId, scheduleId, oleCisTrans);
            //    case "SQLSERVER":
            //        return medOperationScheduleDALBASE.SelectCountMedOperationSchedule(patientId, visitId, scheduleId, oleCisTrans);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medOperationScheduleDALBASE.SelectCountMedOperationSchedule(patientId, visitId, scheduleId, oleCisTrans);
            //    default:
            return medOperationScheduleDALBASE.SelectCountMedOperationSchedule(patientId, visitId, scheduleId, oleCisTrans);
            //}
        }

        public virtual MedicalSytem.Soft.Model.MedOperationSchedule SelectMedOperationSchedule(string patientId, decimal visitId, decimal scheduleId, DbConnection oleCisConn)
        {
            return medOperationScheduleDALBASE.SelectMedOperationSchedule(patientId, visitId, scheduleId, oleCisConn);
        }

        public virtual int InsertMedOperationSchedule(MedicalSytem.Soft.Model.MedOperationSchedule oneMedOperationSchedule, DbTransaction oleCisTrans)
        {
            return medOperationScheduleDALBASE.InsertMedOperationSchedule(oneMedOperationSchedule, oleCisTrans);
        }

        public virtual int UpdateMedOperationSchedule(MedicalSytem.Soft.Model.MedOperationSchedule oneMedOperationSchedule, DbTransaction oleCisTrans)
        {
            return medOperationScheduleDALBASE.UpdateMedOperationSchedule(oneMedOperationSchedule, oleCisTrans);
        }

        public virtual int DeleteMedOperationSchedule(MedicalSytem.Soft.Model.MedOperationSchedule oneMedOperationSchedule, DbTransaction oleCisTrans)
        {
            return medOperationScheduleDALBASE.DeleteMedOperationSchedule(oneMedOperationSchedule.PatientId, oneMedOperationSchedule.VisitId, oneMedOperationSchedule.ScheduleId, oleCisTrans);
        }

        public virtual int DeleteMedScheduleOperationName(MedicalSytem.Soft.Model.MedScheduledOperationName oneMedScheduleOperationName, DbTransaction oleCisTrans)
        {
            return medScheduleOperationNameDALBASE.DeleteMedScheduledOperationName(oneMedScheduleOperationName.PatientId, oneMedScheduleOperationName.VisitId, oneMedScheduleOperationName.ScheduleId, oneMedScheduleOperationName.OperNo, oleCisTrans);
        }

        public virtual int DeleteMedScheduleOperationName(string patientId, decimal visitId, decimal scheduleId, DbTransaction oleCisTrans)
        {
            return medScheduleOperationNameDALBASE.DeleteMedScheduledOperationName(patientId, visitId, scheduleId, oleCisTrans);
        }

        //------------------------------------------------------------------------

        public virtual MedicalSytem.Soft.Model.MedScheduledOperationName SelectMedScheduleOperationName(string patientId, decimal visitId, decimal scheduleId, decimal operationNo, DbConnection oleCisConn)
        {
            return medScheduleOperationNameDALBASE.SelectMedScheduledOperationName(patientId, visitId, scheduleId, operationNo, oleCisConn);
        }

        public virtual List<MedicalSytem.Soft.Model.MedScheduledOperationName> SelectMedScheduleOperationName(string patientId, decimal visitId, decimal scheduleId, DbConnection oleCisConn)
        {
            return medScheduleOperationNameDALBASE.SelectMedScheduledOperationName(patientId, visitId, scheduleId, oleCisConn);
        }

        public virtual int InsertMedScheduleOperationName(MedicalSytem.Soft.Model.MedScheduledOperationName oneMedScheduleOperationName, DbTransaction oleCisTrans)
        {
            return medScheduleOperationNameDALBASE.InsertMedScheduledOperationName(oneMedScheduleOperationName, oleCisTrans);
        }

        public virtual int UpdateMedScheduleOperationName(MedicalSytem.Soft.Model.MedScheduledOperationName oneMedScheduleOperationName, DbTransaction oleCisTrans)
        {
            return medScheduleOperationNameDALBASE.UpdateMedScheduledOperationName(oneMedScheduleOperationName, oleCisTrans);
        }

        #endregion
        #region 手术信息 手术名称信息OperationMaster

        public virtual int SelectMaxOperId(string patientId, decimal visitId)
        {
            int max = 0;
            int operId;
            int scheduleId;
            int cancelId;
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    operId = medOperationMasterDALBASE.SelectMaxOperIdOdbc(patientId, visitId);
                    scheduleId = medOperationScheduleDALBASE.SelectMaxScheduleIdOdbc(patientId, visitId);
                    cancelId = medOperationCanceledDALBASE.SelectMaxCanceledIdOdbc(patientId, visitId);
                    break;
                case "ORACLE":
                    operId = medOperationMasterDALBASE.SelectMaxOperId(patientId, visitId);
                    scheduleId = medOperationScheduleDALBASE.SelectMaxScheduleId(patientId, visitId);
                    cancelId = medOperationCanceledDALBASE.SelectMaxCanceledId(patientId, visitId);
                    break;
                case "SQLSERVER":
                    operId = medOperationMasterDALBASE.SelectMaxOperIdSQL(patientId, visitId);
                    scheduleId = medOperationScheduleDALBASE.SelectMaxScheduleIdSQL(patientId, visitId);
                    cancelId = medOperationCanceledDALBASE.SelectMaxCanceledIdSQL(patientId, visitId);
                    break;
                case "ORACLEOLE":
                case "ORAOLEDB":
                    operId = medOperationMasterDALBASE.SelectMaxOperIdOLE(patientId, visitId);
                    scheduleId = medOperationScheduleDALBASE.SelectMaxScheduleIdOLE(patientId, visitId);
                    cancelId = medOperationCanceledDALBASE.SelectMaxCanceledIdOLE(patientId, visitId);
                    break;
                default:
                    operId = medOperationMasterDALBASE.SelectMaxOperId(patientId, visitId);
                    scheduleId = medOperationScheduleDALBASE.SelectMaxScheduleId(patientId, visitId);
                    cancelId = medOperationCanceledDALBASE.SelectMaxCanceledId(patientId, visitId);
                    break;
            }
            max = Math.Max(operId, scheduleId);
            max = Math.Max(max, cancelId);
            return max;
        }

        public virtual MedicalSytem.Soft.Model.MedOperationMaster SelectMedOperationMaster(string patientId, decimal visitId, decimal operId)
        {

            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationMasterDALBASE.SelectMedOperationMasterOdbc(patientId, visitId, operId);
                case "ORACLE":
                    return medOperationMasterDALBASE.SelectMedOperationMaster(patientId, visitId, operId);
                case "SQLSERVER":
                    return medOperationMasterDALBASE.SelectMedOperationMasterSQL(patientId, visitId, operId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationMasterDALBASE.SelectMedOperationMasterOLE(patientId, visitId, operId);
                default:
                    return medOperationMasterDALBASE.SelectMedOperationMaster(patientId, visitId, operId);
            }
        }

        public virtual List<MedicalSytem.Soft.Model.MedOperationMaster> SelectMedOperationMasterALL()
        {

            switch (DateType.ToUpper())
            {

                case "ORACLE":
                    return medOperationMasterDALBASE.SelectMedOperationMasterList();
                case "SQLSERVER":
                    return medOperationMasterDALBASE.SelectMedOperationMasterListSQL();
                case "ORACLEOLE":
                case "ORAOLEDB":
                //return medOperationMasterDALBASE.SelectMedOperationMasterList();
                default:
                    return medOperationMasterDALBASE.SelectMedOperationMasterList();
            }
        }


        public virtual int InsertMedOperationMaster(MedicalSytem.Soft.Model.MedOperationMaster oneMedOperationMaster)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationMasterDALBASE.InsertMedOperationMasterOdbc(oneMedOperationMaster);
                case "ORACLE":
                    return medOperationMasterDALBASE.InsertMedOperationMaster(oneMedOperationMaster);
                case "SQLSERVER":
                    return medOperationMasterDALBASE.InsertMedOperationMasterSQL(oneMedOperationMaster);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationMasterDALBASE.InsertMedOperationMasterOLE(oneMedOperationMaster);
                default:
                    return medOperationMasterDALBASE.InsertMedOperationMasterOdbc(oneMedOperationMaster);
            }
        }

        public virtual int UpdateMedOperationMaster(MedicalSytem.Soft.Model.MedOperationMaster oneMedOperationMaster)
        {

            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationMasterDALBASE.UpdateMedOperationMasterOdbc(oneMedOperationMaster);
                case "ORACLE":
                    return medOperationMasterDALBASE.UpdateMedOperationMaster(oneMedOperationMaster);
                case "SQLSERVER":
                    return medOperationMasterDALBASE.UpdateMedOperationMasterSQL(oneMedOperationMaster);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationMasterDALBASE.UpdateMedOperationMasterOLE(oneMedOperationMaster);
                default:
                    return medOperationMasterDALBASE.UpdateMedOperationMaster(oneMedOperationMaster);
            }
        }

        //---------------------------------------------------------------------------------------------------------

        public virtual MedicalSytem.Soft.Model.MedOperationName SelectMedOperationName(string patientId, decimal visitId, decimal operId, decimal operationNo)
        {

            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationNameDALBASE.SelectMedOperationNameOdbc(patientId, visitId, operId, operationNo);
                case "ORACLE":
                    return medOperationNameDALBASE.SelectMedOperationName(patientId, visitId, operId, operationNo);
                case "SQLSERVER":
                    return medOperationNameDALBASE.SelectMedOperationNameSQL(patientId, visitId, operId, operationNo);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationNameDALBASE.SelectMedOperationNameOLE(patientId, visitId, operId, operationNo);
                default:
                    return medOperationNameDALBASE.SelectMedOperationName(patientId, visitId, operId, operationNo);
            }
        }

        public virtual List<MedicalSytem.Soft.Model.MedOperationName> SelectMedOperationName(string patientId, decimal visitId, decimal operId)
        {

            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationNameDALBASE.SelectMedOperationNameOdbc(patientId, visitId, operId);
                case "ORACLE":
                    return medOperationNameDALBASE.SelectMedOperationName(patientId, visitId, operId);
                case "SQLSERVER":
                    return medOperationNameDALBASE.SelectMedOperationNameSQL(patientId, visitId, operId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationNameDALBASE.SelectMedOperationNameOLE(patientId, visitId, operId);
                default:
                    return medOperationNameDALBASE.SelectMedOperationName(patientId, visitId, operId);
            }
        }

        public virtual int InsertMedOperationName(MedicalSytem.Soft.Model.MedOperationName oneMedOperationName)
        {

            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationNameDALBASE.InsertMedOperationNameOdbc(oneMedOperationName);
                case "ORACLE":
                    return medOperationNameDALBASE.InsertMedOperationName(oneMedOperationName);
                case "SQLSERVER":
                    return medOperationNameDALBASE.InsertMedOperationNameSQL(oneMedOperationName);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationNameDALBASE.InsertMedOperationNameOLE(oneMedOperationName);

                default:
                    return medOperationNameDALBASE.InsertMedOperationName(oneMedOperationName);
            }
        }

        public virtual int UpdateMedOperationName(MedicalSytem.Soft.Model.MedOperationName oneMedOperationName)
        {

            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationNameDALBASE.UpdateMedOperationNameOdbc(oneMedOperationName);
                case "ORACLE":
                    return medOperationNameDALBASE.UpdateMedOperationName(oneMedOperationName);
                case "SQLSERVER":
                    return medOperationNameDALBASE.UpdateMedOperationNameSQL(oneMedOperationName);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationNameDALBASE.UpdateMedOperationNameOLE(oneMedOperationName);
                default:
                    return medOperationNameDALBASE.UpdateMedOperationName(oneMedOperationName);
            }
        }
        #endregion
        #region 取消手术信息 取消手术名称信息 OperationCanceled
        public virtual MedicalSytem.Soft.Model.MedOperationCanceled SelectMedOperationCancel(string patientId, decimal visitId, decimal cancelId)
        {

            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationCanceledDALBASE.SelectMedOperationCanceledOdbc(patientId, visitId, cancelId);
                case "ORACLE":
                    return medOperationCanceledDALBASE.SelectMedOperationCanceled(patientId, visitId, cancelId);
                case "SQLSERVER":
                    return medOperationCanceledDALBASE.SelectMedOperationCanceledSQL(patientId, visitId, cancelId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationCanceledDALBASE.SelectMedOperationCanceledOLE(patientId, visitId, cancelId);
                default:
                    return medOperationCanceledDALBASE.SelectMedOperationCanceled(patientId, visitId, cancelId);
            }
        }

        public virtual MedicalSytem.Soft.Model.MedOperationNameCanceled SelectMedOperationNameCanceled(string patientId, decimal visitId, decimal operId, decimal operationNo)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationNameCanceledDALBASE.SelectMedOperationNameCanceledOdbc(patientId, visitId, operId, operationNo);
                case "ORACLE":
                    return medOperationNameCanceledDALBASE.SelectMedOperationNameCanceled(patientId, visitId, operId, operationNo);
                case "SQLSERVER":
                    return medOperationNameCanceledDALBASE.SelectMedOperationNameCanceledSQL(patientId, visitId, operId, operationNo);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationNameCanceledDALBASE.SelectMedOperationNameCanceledOLE(patientId, visitId, operId, operationNo);
                default:
                    return medOperationNameCanceledDALBASE.SelectMedOperationNameCanceled(patientId, visitId, operId, operationNo);
            }
        }

        public virtual List<MedicalSytem.Soft.Model.MedOperationNameCanceled> SelectMedOperationNameCanceled(string patientId, decimal visitId, decimal operId)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationNameCanceledDALBASE.SelectMedOperationNameCanceledOdbc(patientId, visitId, operId);
                case "ORACLE":
                    return medOperationNameCanceledDALBASE.SelectMedOperationNameCanceled(patientId, visitId, operId);
                case "SQLSERVER":
                    return medOperationNameCanceledDALBASE.SelectMedOperationNameCanceledSQL(patientId, visitId, operId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationNameCanceledDALBASE.SelectMedOperationNameCanceledOLE(patientId, visitId, operId);
                default:
                    return medOperationNameCanceledDALBASE.SelectMedOperationNameCanceled(patientId, visitId, operId);
            }
        }
        #endregion

        #region 检验信息
        //-----------------------------------

        public virtual MedicalSytem.Soft.Model.MedLabTestMaster SelectMedLabTestMaster(string testNo)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medLabTestMasterDALBASE.SelectMedLabTestMasterOdbc(testNo);
                case "ORACLE":
                    return medLabTestMasterDALBASE.SelectMedLabTestMaster(testNo);
                case "SQLSERVER":
                    return medLabTestMasterDALBASE.SelectMedLabTestMasterSQL(testNo);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medLabTestMasterDALBASE.SelectMedLabTestMasterOLE(testNo);
                default:
                    return medLabTestMasterDALBASE.SelectMedLabTestMaster(testNo);
            }
        }

        public virtual int InsertMedLabTestMaster(MedicalSytem.Soft.Model.MedLabTestMaster medLabTestMaster)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medLabTestMasterDALBASE.InsertMedLabTestMasterOdbc(medLabTestMaster);
                case "ORACLE":
                    return medLabTestMasterDALBASE.InsertMedLabTestMaster(medLabTestMaster);
                case "SQLSERVER":
                    return medLabTestMasterDALBASE.InsertMedLabTestMasterSQL(medLabTestMaster);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medLabTestMasterDALBASE.InsertMedLabTestMasterOLE(medLabTestMaster);
                default:
                    return medLabTestMasterDALBASE.InsertMedLabTestMaster(medLabTestMaster);
            }
        }

        public virtual int UpdateMedLabTestMaster(MedicalSytem.Soft.Model.MedLabTestMaster medLabTestMaster)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medLabTestMasterDALBASE.UpdateMedLabTestMasterOdbc(medLabTestMaster);
                case "ORACLE":
                    return medLabTestMasterDALBASE.UpdateMedLabTestMaster(medLabTestMaster);
                case "SQLSERVER":
                    return medLabTestMasterDALBASE.UpdateMedLabTestMasterSQL(medLabTestMaster);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medLabTestMasterDALBASE.UpdateMedLabTestMasterOLE(medLabTestMaster);
                default:
                    return medLabTestMasterDALBASE.UpdateMedLabTestMaster(medLabTestMaster);
            }
        }
        //<-----------------------------------

        //------------------------------------
        public virtual MedicalSytem.Soft.Model.MedLabResult SelectMedLabResult(string testNo, decimal itemNo, decimal printOrder)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medLabResultDALBASE.SelectMedLabResultOdbc(testNo, itemNo, printOrder);
                case "ORACLE":
                    return medLabResultDALBASE.SelectMedLabResult(testNo, itemNo, printOrder);
                case "SQLSERVER":
                    return medLabResultDALBASE.SelectMedLabResultSQL(testNo, itemNo, printOrder);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medLabResultDALBASE.SelectMedLabResultOLE(testNo, itemNo, printOrder);
                default:
                    return medLabResultDALBASE.SelectMedLabResult(testNo, itemNo, printOrder);
            }
        }

        public virtual int InsertMedLabResult(MedicalSytem.Soft.Model.MedLabResult medLabResult)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medLabResultDALBASE.InsertMedLabResultOdbc(medLabResult);
                case "ORACLE":
                    return medLabResultDALBASE.InsertMedLabResult(medLabResult);
                case "SQLSERVER":
                    return medLabResultDALBASE.InsertMedLabResultSQL(medLabResult);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medLabResultDALBASE.InsertMedLabResultOLE(medLabResult);
                default:
                    return medLabResultDALBASE.InsertMedLabResult(medLabResult);
            }
        }

        public virtual int UpdateMedLabResult(MedicalSytem.Soft.Model.MedLabResult medLabResult)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medLabResultDALBASE.UpdateMedLabResultOdbc(medLabResult);
                case "ORACLE":
                    return medLabResultDALBASE.UpdateMedLabResult(medLabResult);
                case "SQLSERVER":
                    return medLabResultDALBASE.UpdateMedLabResultSQL(medLabResult);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medLabResultDALBASE.UpdateMedLabResultOLE(medLabResult);
                default:
                    return medLabResultDALBASE.UpdateMedLabResult(medLabResult);
            }
        }
        //<-----------------------------------

        //------------------------------------

        public virtual MedicalSytem.Soft.Model.MedLabTestItems SelectMedLabTestItems(string testNo, decimal itemNo)
        {
            //switch (DateType.ToUpper())
            //{
            //    case "ODBC":
            //        return medLabTestItemsDALBASE.SelectMedLabTestItems(testNo, itemNo);
            //    case "ORACLE":
            //        return medLabTestItemsDALBASE.SelectMedLabTestItems(testNo, itemNo);
            //    case "SQLSERVER":
            //        return medLabTestItemsDALBASE.SelectMedLabTestItems(testNo, itemNo);
            //    case "ORACLEOLE":
            //    case "ORAOLEDB":
            //        return medLabTestItemsDALBASE.SelectMedLabTestItems(testNo, itemNo);
            //    default:
            return medLabTestItemsDALBASE.SelectMedLabTestItems(testNo, itemNo);
            //}
        }
        //??????
        public virtual int InsertMedLabTestItems(MedicalSytem.Soft.Model.MedLabTestItems medLabTestItems)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medLabTestItemsDALBASE.InsertMedLabTestItems(medLabTestItems);
                case "ORACLE":
                    return medLabTestItemsDALBASE.InsertMedLabTestItems(medLabTestItems);
                case "SQLSERVER":
                    return medLabTestItemsDALBASE.InsertMedLabTestItemsSQL(medLabTestItems);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medLabTestItemsDALBASE.InsertMedLabTestItems(medLabTestItems);
                default:
                    return medLabTestItemsDALBASE.InsertMedLabTestItems(medLabTestItems);
            }
        }

        public virtual int UpdateMedLabTestItems(MedicalSytem.Soft.Model.MedLabTestItems medLabTestItems)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medLabTestItemsDALBASE.UpdateMedLabTestItems(medLabTestItems);
                case "ORACLE":
                    return medLabTestItemsDALBASE.UpdateMedLabTestItems(medLabTestItems);
                case "SQLSERVER":
                    return medLabTestItemsDALBASE.UpdateMedLabTestItemsSQL(medLabTestItems);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medLabTestItemsDALBASE.UpdateMedLabTestItems(medLabTestItems);
                default:
                    return medLabTestItemsDALBASE.UpdateMedLabTestItems(medLabTestItems);
            }
        }
        //<-----------------------------------

        #endregion
        #region 检验信息 Trans
        //-----------------------------------

        public virtual MedicalSytem.Soft.Model.MedLabTestMaster SelectMedLabTestMaster(string testNo, DbConnection oleCisConn)
        {
            return medLabTestMasterDALBASE.SelectMedLabTestMaster(testNo, oleCisConn);
        }

        public virtual int InsertMedLabTestMaster(MedicalSytem.Soft.Model.MedLabTestMaster medLabTestMaster, DbTransaction oleCisTrans)
        {
            return medLabTestMasterDALBASE.InsertMedLabTestMaster(medLabTestMaster, oleCisTrans);
        }

        public virtual int UpdateMedLabTestMaster(MedicalSytem.Soft.Model.MedLabTestMaster medLabTestMaster, DbTransaction oleCisTrans)
        {
            return medLabTestMasterDALBASE.UpdateMedLabTestMaster(medLabTestMaster, oleCisTrans);
        }
        //<-----------------------------------

        //------------------------------------
        public virtual MedicalSytem.Soft.Model.MedLabResult SelectMedLabResult(string testNo, decimal itemNo, decimal printOrder, DbConnection oleCisConn)
        {
            return medLabResultDALBASE.SelectMedLabResult(testNo, itemNo, printOrder, oleCisConn);
        }

        public virtual int InsertMedLabResult(MedicalSytem.Soft.Model.MedLabResult medLabResult, DbTransaction oleCisTrans)
        {
            return medLabResultDALBASE.InsertMedLabResult(medLabResult, oleCisTrans);
        }

        public virtual int UpdateMedLabResult(MedicalSytem.Soft.Model.MedLabResult medLabResult, DbTransaction oleCisTrans)
        {
            return medLabResultDALBASE.UpdateMedLabResult(medLabResult, oleCisTrans);
        }
        //<-----------------------------------

        #endregion
        #region 价表信息

        public virtual MedicalSytem.Soft.Model.MedPriceList SelectMedPriceList(string itemClass, string itemCode, string itemSpec, string units)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medPriceListDALBASE.SelectMedPriceListOdbc(itemClass, itemCode, itemSpec, units);
                case "ORACLE":
                    return medPriceListDALBASE.SelectMedPriceList(itemClass, itemCode, itemSpec, units);
                case "SQLSERVER":
                    return medPriceListDALBASE.SelectMedPriceListSQL(itemClass, itemCode, itemSpec, units);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medPriceListDALBASE.SelectMedPriceListOLE(itemClass, itemCode, itemSpec, units);
                default:
                    return medPriceListDALBASE.SelectMedPriceList(itemClass, itemCode, itemSpec, units);
            }
        }

        public virtual int InsertMedPriceList(MedicalSytem.Soft.Model.MedPriceList medPriceList)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medPriceListDALBASE.InsertMedPriceListOdbc(medPriceList);
                case "ORACLE":
                    return medPriceListDALBASE.InsertMedPriceList(medPriceList);
                case "SQLSERVER":
                    return medPriceListDALBASE.InsertMedPriceListSQL(medPriceList);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medPriceListDALBASE.InsertMedPriceListOLE(medPriceList);
                default:
                    return medPriceListDALBASE.InsertMedPriceList(medPriceList);
            }
        }

        public virtual int UpdateMedPriceList(MedicalSytem.Soft.Model.MedPriceList medPriceList)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medPriceListDALBASE.UpdateMedPriceListOdbc(medPriceList);
                case "ORACLE":
                    return medPriceListDALBASE.UpdateMedPriceList(medPriceList);
                case "SQLSERVER":
                    return medPriceListDALBASE.UpdateMedPriceListSQL(medPriceList);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medPriceListDALBASE.UpdateMedPriceListOLE(medPriceList);
                default:
                    return medPriceListDALBASE.UpdateMedPriceList(medPriceList);
            }
        }
        #endregion
        #region 价表信息 Trans

        public virtual MedicalSytem.Soft.Model.MedPriceList SelectMedPriceList(string itemClass, string itemCode, string itemSpec, string units, DbConnection oleCisConn)
        {
            return medPriceListDALBASE.SelectMedPriceList(itemClass, itemCode, itemSpec, units, oleCisConn);
        }

        public virtual int InsertMedPriceList(MedicalSytem.Soft.Model.MedPriceList medPriceList, DbTransaction oleCisTrans)
        {
            return medPriceListDALBASE.InsertMedPriceList(medPriceList, oleCisTrans);
        }

        public virtual int UpdateMedPriceList(MedicalSytem.Soft.Model.MedPriceList medPriceList, DbTransaction oleCisTrans)
        {
            return medPriceListDALBASE.UpdateMedPriceList(medPriceList, oleCisTrans);
        }
        #endregion

        #region 病人费用对照信息

        public virtual MedicalSytem.Soft.Model.MedBillItemClassVsHis SelectMedBillItemClassVsHis(string classCode)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medBillItemClassVsHisDALBASE.SelectMedBillItemClassVsHis(classCode);
                case "ORACLE":
                    return medBillItemClassVsHisDALBASE.SelectMedBillItemClassVsHis(classCode);
                case "SQLSERVER":
                    return medBillItemClassVsHisDALBASE.SelectMedBillItemClassVsHisSQL(classCode);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medBillItemClassVsHisDALBASE.SelectMedBillItemClassVsHis(classCode);
                default:
                    return medBillItemClassVsHisDALBASE.SelectMedBillItemClassVsHis(classCode);
            }
        }

        public virtual MedicalSytem.Soft.Model.MedBillItemClassVsHis SelectHisMedBillItemClassVsHis(string codeInHis)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medBillItemClassVsHisDALBASE.SelectHisMedBillItemClassVsHis(codeInHis);
                case "ORACLE":
                    return medBillItemClassVsHisDALBASE.SelectHisMedBillItemClassVsHis(codeInHis);
                case "SQLSERVER":
                    return medBillItemClassVsHisDALBASE.SelectHisMedBillItemClassVsHisSQL(codeInHis);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medBillItemClassVsHisDALBASE.SelectHisMedBillItemClassVsHis(codeInHis);
                default:
                    return medBillItemClassVsHisDALBASE.SelectHisMedBillItemClassVsHis(codeInHis);
            }
        }

        public virtual int SelectCountMedVsHisOperBillConsts(string patientId, decimal visitId, decimal operId)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOperBillConstsDALBASE.SelectCountMedVsHisOperBillConsts(patientId, visitId, operId);
                case "ORACLE":
                    return medVsHisOperBillConstsDALBASE.SelectCountMedVsHisOperBillConsts(patientId, visitId, operId);
                case "SQLSERVER":
                    return medVsHisOperBillConstsDALBASE.SelectCountMedVsHisOperBillConstsSQL(patientId, visitId, operId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOperBillConstsDALBASE.SelectCountMedVsHisOperBillConsts(patientId, visitId, operId);
                default:
                    return medVsHisOperBillConstsDALBASE.SelectCountMedVsHisOperBillConsts(patientId, visitId, operId);
            }
        }

        public virtual List<MedicalSytem.Soft.Model.MedVsHisOperBillConsts> SelectOneMoreMedVsHisOperBillConsts(string patientId, decimal visitId, decimal operId, decimal medConstsCount)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOperBillConstsDALBASE.SelectOneMoreMedVsHisOperBillConsts(patientId, visitId, operId, medConstsCount);
                case "ORACLE":
                    return medVsHisOperBillConstsDALBASE.SelectOneMoreMedVsHisOperBillConsts(patientId, visitId, operId, medConstsCount);
                case "SQLSERVER":
                    return medVsHisOperBillConstsDALBASE.SelectOneMoreMedVsHisOperBillConstsSQL(patientId, visitId, operId, medConstsCount);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOperBillConstsDALBASE.SelectOneMoreMedVsHisOperBillConsts(patientId, visitId, operId, medConstsCount);
                default:
                    return medVsHisOperBillConstsDALBASE.SelectOneMoreMedVsHisOperBillConsts(patientId, visitId, operId, medConstsCount);
            }
        }

        public virtual List<MedicalSytem.Soft.Model.MedVsHisOperBillConsts> SelectOneMoreItemNoMedVsHisOperBillConsts(string patientId, decimal visitId, decimal operId, string itemNo)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOperBillConstsDALBASE.SelectOneMoreItemNoMedVsHisOperBillConsts(patientId, visitId, operId, itemNo);
                case "ORACLE":
                    return medVsHisOperBillConstsDALBASE.SelectOneMoreItemNoMedVsHisOperBillConsts(patientId, visitId, operId, itemNo);
                case "SQLSERVER":
                    return medVsHisOperBillConstsDALBASE.SelectOneMoreItemNoMedVsHisOperBillConstsSQL(patientId, visitId, operId, itemNo);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOperBillConstsDALBASE.SelectOneMoreItemNoMedVsHisOperBillConsts(patientId, visitId, operId, itemNo);
                default:
                    return medVsHisOperBillConstsDALBASE.SelectOneMoreItemNoMedVsHisOperBillConsts(patientId, visitId, operId, itemNo);
            }
        }

        public virtual MedicalSytem.Soft.Model.MedVsHisOperBillConsts SelectOneMedVsHisOperBillConsts(string patientId, decimal visitId, decimal operId, decimal medConstsCount, string itemNo)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOperBillConstsDALBASE.SelectMedVsHisOperBillConsts(patientId, visitId, operId, medConstsCount, itemNo);
                case "ORACLE":
                    return medVsHisOperBillConstsDALBASE.SelectMedVsHisOperBillConsts(patientId, visitId, operId, medConstsCount, itemNo);
                case "SQLSERVER":
                    return medVsHisOperBillConstsDALBASE.SelectMedVsHisOperBillConstsSQL(patientId, visitId, operId, medConstsCount, itemNo);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOperBillConstsDALBASE.SelectMedVsHisOperBillConsts(patientId, visitId, operId, medConstsCount, itemNo);
                default:
                    return medVsHisOperBillConstsDALBASE.SelectMedVsHisOperBillConsts(patientId, visitId, operId, medConstsCount, itemNo);
            }
        }

        public virtual List<MedicalSytem.Soft.Model.MedVsHisOperBillConsts> SelectMedVsHisOperBillConsts(string patientId, decimal visitId, decimal operId)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOperBillConstsDALBASE.SelectMedVsHisOperBillConsts(patientId, visitId, operId);
                case "ORACLE":
                    return medVsHisOperBillConstsDALBASE.SelectMedVsHisOperBillConsts(patientId, visitId, operId);
                case "SQLSERVER":
                    return medVsHisOperBillConstsDALBASE.SelectMedVsHisOperBillConstsSQL(patientId, visitId, operId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOperBillConstsDALBASE.SelectMedVsHisOperBillConsts(patientId, visitId, operId);
                default:
                    return medVsHisOperBillConstsDALBASE.SelectMedVsHisOperBillConsts(patientId, visitId, operId);
            }
        }

        public virtual int InsertMedVsHisOperBillConsts(MedicalSytem.Soft.Model.MedVsHisOperBillConsts medOperationBillItemsList)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOperBillConstsDALBASE.InsertMedVsHisOperBillConsts(medOperationBillItemsList); ;
                case "ORACLE":
                    return medVsHisOperBillConstsDALBASE.InsertMedVsHisOperBillConsts(medOperationBillItemsList);
                case "SQLSERVER":
                    return medVsHisOperBillConstsDALBASE.InsertMedVsHisOperBillConstsSQL(medOperationBillItemsList);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOperBillConstsDALBASE.InsertMedVsHisOperBillConsts(medOperationBillItemsList);
                default:
                    return medVsHisOperBillConstsDALBASE.InsertMedVsHisOperBillConsts(medOperationBillItemsList);
            }
        }

        public virtual int UpdateMedVsHisOperBillConsts(MedicalSytem.Soft.Model.MedVsHisOperBillConsts medOperationBillItemsList)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOperBillConstsDALBASE.UpdateMedVsHisOperBillConsts(medOperationBillItemsList);
                case "ORACLE":
                    return medVsHisOperBillConstsDALBASE.UpdateMedVsHisOperBillConsts(medOperationBillItemsList);
                case "SQLSERVER":
                    return medVsHisOperBillConstsDALBASE.UpdateMedVsHisOperBillConstsSQL(medOperationBillItemsList);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOperBillConstsDALBASE.UpdateMedVsHisOperBillConsts(medOperationBillItemsList);
                default:
                    return medVsHisOperBillConstsDALBASE.UpdateMedVsHisOperBillConsts(medOperationBillItemsList);
            }
        }

        public virtual int DeleteMedVsHisOperBillConsts(MedicalSytem.Soft.Model.MedVsHisOperBillConsts medOperationBillItemsList)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVsHisOperBillConstsDALBASE.DeleteMedVsHisOperBillConsts(medOperationBillItemsList.PatientId, medOperationBillItemsList.VisitId, medOperationBillItemsList.OperId, medOperationBillItemsList.ConstsCount, medOperationBillItemsList.ItemNoString);
                case "ORACLE":
                    return medVsHisOperBillConstsDALBASE.DeleteMedVsHisOperBillConsts(medOperationBillItemsList.PatientId, medOperationBillItemsList.VisitId, medOperationBillItemsList.OperId, medOperationBillItemsList.ConstsCount, medOperationBillItemsList.ItemNoString);
                case "SQLSERVER":
                    return medVsHisOperBillConstsDALBASE.DeleteMedVsHisOperBillConstsSQL(medOperationBillItemsList.PatientId, medOperationBillItemsList.VisitId, medOperationBillItemsList.OperId, medOperationBillItemsList.ConstsCount, medOperationBillItemsList.ItemNoString);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVsHisOperBillConstsDALBASE.DeleteMedVsHisOperBillConsts(medOperationBillItemsList.PatientId, medOperationBillItemsList.VisitId, medOperationBillItemsList.OperId, medOperationBillItemsList.ConstsCount, medOperationBillItemsList.ItemNoString);
                default:
                    return medVsHisOperBillConstsDALBASE.DeleteMedVsHisOperBillConsts(medOperationBillItemsList.PatientId, medOperationBillItemsList.VisitId, medOperationBillItemsList.OperId, medOperationBillItemsList.ConstsCount, medOperationBillItemsList.ItemNoString);
            }
        }

        #endregion
        #region 病人费用对照信息 Trans 一部分

        public virtual MedicalSytem.Soft.Model.MedBillItemClassVsHis SelectMedBillItemClassVsHis(string classCode, DbConnection oleCisConn)
        {
            return medBillItemClassVsHisDALBASE.SelectMedBillItemClassVsHis(classCode, oleCisConn);
        }

        public virtual MedicalSytem.Soft.Model.MedBillItemClassVsHis SelectHisMedBillItemClassVsHis(string codeInHis, DbConnection oleCisConn)
        {
            return medBillItemClassVsHisDALBASE.SelectHisMedBillItemClassVsHis(codeInHis, oleCisConn);
        }
        #endregion
        #region 病人费用信息

        public virtual MedicalSytem.Soft.Model.MedOperationBillItems SelectOneMedOperationBillItems(string patientId, decimal visitId, decimal operId, decimal itemNo)
        {

            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationBillItemsDALBASE.SelectMedOperationBillItemsODBC(patientId, visitId, operId, itemNo);
                case "ORACLE":
                    return medOperationBillItemsDALBASE.SelectMedOperationBillItems(patientId, visitId, operId, itemNo);
                case "SQLSERVER":
                    return medOperationBillItemsDALBASE.SelectMedOperationBillItemsSQL(patientId, visitId, operId, itemNo);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationBillItemsDALBASE.SelectMedOperationBillItemsOLE(patientId, visitId, operId, itemNo);
                default:
                    return medOperationBillItemsDALBASE.SelectMedOperationBillItems(patientId, visitId, operId, itemNo);
            }
        }

        public virtual List<MedicalSytem.Soft.Model.MedOperationBillItems> SelectMedOperationBillItemsNo(string patientId, decimal visitId, decimal operId, string itemClass, string itemCode, string itemSpec, string units)
        {

            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationBillItemsDALBASE.SelectMedOperationBillItemsNoODBC(patientId, visitId, operId, itemClass, itemCode, itemSpec, units);
                case "ORACLE":
                    return medOperationBillItemsDALBASE.SelectMedOperationBillItemsNo(patientId, visitId, operId, itemClass, itemCode, itemSpec, units);
                case "SQLSERVER":
                    return medOperationBillItemsDALBASE.SelectMedOperationBillItemsNoSQL(patientId, visitId, operId, itemClass, itemCode, itemSpec, units);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationBillItemsDALBASE.SelectMedOperationBillItemsNoOLE(patientId, visitId, operId, itemClass, itemCode, itemSpec, units);
                default:
                    return medOperationBillItemsDALBASE.SelectMedOperationBillItemsNo(patientId, visitId, operId, itemClass, itemCode, itemSpec, units);
            }
        }
        public virtual List<MedicalSytem.Soft.Model.MedOperationBillItems> SelectMedOperationBillItems(string patientId, decimal visitId, decimal operId, decimal billAttr)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationBillItemsDALBASE.SelectMedOperationBillItemsForInODBC(patientId, visitId, operId, billAttr);
                case "SQLSERVER":
                    return medOperationBillItemsDALBASE.SelectMedOperationBillItemsForInSQL(patientId, visitId, operId, billAttr);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationBillItemsDALBASE.SelectMedOperationBillItemsForInOLE(patientId, visitId, operId, billAttr);
                default:
                    return medOperationBillItemsDALBASE.SelectMedOperationBillItemsForIn(patientId, visitId, operId, billAttr);
            }
        }

        //public virtual List<MedicalSytem.Soft.Model.MedOperationBillItems> SelectMedOperationBillItems(string patientId, decimal visitId, decimal operId, string itemNoInStr)
        //{
        //    return medOperationBillItemsDALBASE.SelectMedOperationBillItemsForIn(patientId, visitId, operId, itemNoInStr);
        //}

        public virtual int InsertMedOperationBillItems(MedicalSytem.Soft.Model.MedOperationBillItems medOperationBillItemsList)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationBillItemsDALBASE.InsertMedOperationBillItemsODBC(medOperationBillItemsList);
                case "ORACLE":
                    return medOperationBillItemsDALBASE.InsertMedOperationBillItems(medOperationBillItemsList);
                case "SQLSERVER":
                    return medOperationBillItemsDALBASE.InsertMedOperationBillItemsSQL(medOperationBillItemsList);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationBillItemsDALBASE.InsertMedOperationBillItemsOLE(medOperationBillItemsList);
                default:
                    return medOperationBillItemsDALBASE.InsertMedOperationBillItems(medOperationBillItemsList);
            }
        }

        public virtual int UpdateMedOperationBillItems(MedicalSytem.Soft.Model.MedOperationBillItems medOperationBillItemsList)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationBillItemsDALBASE.UpdateMedOperationBillItemsODBC(medOperationBillItemsList);
                case "ORACLE":
                    return medOperationBillItemsDALBASE.UpdateMedOperationBillItems(medOperationBillItemsList);
                case "SQLSERVER":
                    return medOperationBillItemsDALBASE.UpdateMedOperationBillItemsSQL(medOperationBillItemsList);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationBillItemsDALBASE.UpdateMedOperationBillItemsOLE(medOperationBillItemsList);
                default:
                    return medOperationBillItemsDALBASE.UpdateMedOperationBillItems(medOperationBillItemsList);
            }
        }
        #endregion

        #region  同步的同时写手术主记录信息
        /// <summary>
        /// 同步的同时写手术主记录信息
        /// </summary>
        /// <param name="patientID">The patient ID.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <returns></returns>
        public virtual int MedOperationMasterAndOperationName(string patientID, decimal visitId, decimal operId)
        {

            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medOperationMasterAndNameDALBASE.MedOperationMasterAndOperationNameOdbcV4(patientID, visitId, operId);
                case "ORACLE":
                    return medOperationMasterAndNameDALBASE.MedOperationMasterAndOperationNameV4(patientID, visitId, operId);
                case "SQLSERVER":
                    return medOperationMasterAndNameDALBASE.MedOperationMasterAndOperationNameSQLV4(patientID, visitId, operId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medOperationMasterAndNameDALBASE.MedOperationMasterAndOperationNameOLEV4(patientID, visitId, operId);
                default:
                    return medOperationMasterAndNameDALBASE.MedOperationMasterAndOperationNameV4(patientID, visitId, operId);
            }
        }
        #endregion
        #region 药品字典

        public virtual MedicalSytem.Soft.Model.MedDrugDict SelectMedDrugDict(string DrugCode, string DrugSpec)
        {
            return medDrugDictDALBASE.SelectMedDrugDict(DrugCode, DrugSpec);
        }

        public virtual int InsertMedDrugDict(MedicalSytem.Soft.Model.MedDrugDict medDrugDict)
        {
            return medDrugDictDALBASE.InsertMedDrugDict(medDrugDict);
        }

        public virtual int UpdateMedDrugDict(MedicalSytem.Soft.Model.MedDrugDict medDrugDict)
        {
            return medDrugDictDALBASE.UpdateMedDrugDict(medDrugDict);
        }
        #endregion
        #region 药品名称信息

        public virtual MedicalSytem.Soft.Model.MedDrugNameDict SelectMedDrugNameDict(string DrugCode, string DrugName)
        {
            return medDrugNameDictDALBASE.SelectMedDrugNameDict(DrugCode, DrugName);
        }

        public virtual int InsertMedDrugNameDict(MedicalSytem.Soft.Model.MedDrugNameDict medDrugNameDict)
        {
            return medDrugNameDictDALBASE.InsertMedDrugNameDict(medDrugNameDict);
        }

        public virtual int UpdateMedDrugNameDict(MedicalSytem.Soft.Model.MedDrugNameDict medDrugNameDict)
        {
            return medDrugNameDictDALBASE.UpdateMedDrugNameDict(medDrugNameDict);
        }
        #endregion
        #region 耗材字典

        public virtual MedicalSytem.Soft.Model.MedMtrlDict SelectMedMtrlDict(string MtrlCode, string MtrlSpec)
        {
            return medMtrlDictDALBASE.SelectMedMtrlDict(MtrlCode, MtrlSpec);
        }

        public virtual int InsertMedMtrlDict(MedicalSytem.Soft.Model.MedMtrlDict medMtrlDict)
        {
            return medMtrlDictDALBASE.InsertMedMtrlDict(medMtrlDict);
        }

        public virtual int UpdateMedMtrlDict(MedicalSytem.Soft.Model.MedMtrlDict medMtrlDict)
        {
            return medMtrlDictDALBASE.UpdateMedMtrlDict(medMtrlDict);
        }
        #endregion
        #region 耗材名称信息

        public virtual MedicalSytem.Soft.Model.MedMtrlSupplierCatalog SelectMedMtrlSupplierCatalog(string supplierId)
        {
            return medMtrlSupplierCatalogDALBASE.SelectMedMtrlSupplierCatalog(supplierId);
        }

        public virtual int InsertMedMtrlSupplierCatalog(MedicalSytem.Soft.Model.MedMtrlSupplierCatalog medMtrlSupplierCatalog)
        {
            return medMtrlSupplierCatalogDALBASE.InsertMedMtrlSupplierCatalog(medMtrlSupplierCatalog);
        }

        public virtual int UpdateMedMtrlSupplierCatalog(MedicalSytem.Soft.Model.MedMtrlSupplierCatalog medMtrlSupplierCatalog)
        {
            return medMtrlSupplierCatalogDALBASE.UpdateMedMtrlSupplierCatalog(medMtrlSupplierCatalog);
        }
        #endregion
        #region 电子病历路径
        /// <summary>
        /// 一般输入DOCARE
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedEmrWorkPath SelectMedEmrWorkPath(string application)
        {

            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medEmrWorkPathDALBASE.SelectMedEmrWorkPathOdbc(application);
                case "ORACLE":
                    return medEmrWorkPathDALBASE.SelectMedEmrWorkPath(application);
                case "SQLSERVER":
                    return medEmrWorkPathDALBASE.SelectMedEmrWorkPathSQL(application);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medEmrWorkPathDALBASE.SelectMedEmrWorkPathOLE(application);
                default:
                    return medEmrWorkPathDALBASE.SelectMedEmrWorkPath(application);
            }
        }
        /// <summary>
        /// 插入配置表信息
        /// </summary>
        /// <param name="medEmrWorkPath"></param>
        /// <returns></returns>
        public virtual int InsertMedEmrWorkPath(MedicalSytem.Soft.Model.MedEmrWorkPath medEmrWorkPath)
        {

            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medEmrWorkPathDALBASE.InsertMedEmrWorkPathOdbc(medEmrWorkPath);
                case "ORACLE":
                    return medEmrWorkPathDALBASE.InsertMedEmrWorkPath(medEmrWorkPath);
                case "SQLSERVER":
                    return medEmrWorkPathDALBASE.InsertMedEmrWorkPathSQL(medEmrWorkPath);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medEmrWorkPathDALBASE.InsertMedEmrWorkPathOLE(medEmrWorkPath);
                default:
                    return medEmrWorkPathDALBASE.InsertMedEmrWorkPath(medEmrWorkPath);
            }
        }
        /// <summary>
        /// 更新配置表信息
        /// </summary>
        /// <param name="medEmrWorkPath"></param>
        /// <returns></returns>
        public virtual int UpdateMedEmrWorkPath(MedicalSytem.Soft.Model.MedEmrWorkPath medEmrWorkPath)
        {

            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medEmrWorkPathDALBASE.UpdateMedEmrWorkPathOdbc(medEmrWorkPath);
                case "ORACLE":
                    return medEmrWorkPathDALBASE.UpdateMedEmrWorkPath(medEmrWorkPath);
                case "SQLSERVER":
                    return medEmrWorkPathDALBASE.UpdateMedEmrWorkPathSQL(medEmrWorkPath);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medEmrWorkPathDALBASE.UpdateMedEmrWorkPathOLE(medEmrWorkPath);
                default:
                    return medEmrWorkPathDALBASE.UpdateMedEmrWorkPath(medEmrWorkPath);
            }
        }
        #endregion
        #region 电子病历明细表
        /// <summary>
        /// 电子病历明细表查询一条记录
        /// </summary>
        /// <param name="patientId">病人ID号</param>
        /// <param name="visitId"></param>
        /// <param name="mrClass"></param>
        /// <param name="mrSubClass"></param>
        /// <param name="archiveKey"></param> 
        /// <param name="archiveTimes">归档次数 归档次数为0则不知道归档次数需要自己到数据库里面获取</param>
        /// <param name="emrFileIndex">页码 0为第一文件 1为第二个文件</param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedEmrArchiveDetial SelectMedEmrArchiveDetial(string patientId, decimal visitId, string mrClass, string mrSubClass, string archiveKey, decimal emrFileIndex, decimal archiveTimes)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medEmrArchiveDetialDALBASE.SelectMedEmrArchiveDetialOdbc(patientId, visitId, mrClass, mrSubClass, archiveKey, emrFileIndex, archiveTimes);
                case "ORACLE":
                    return medEmrArchiveDetialDALBASE.SelectMedEmrArchiveDetial(patientId, visitId, mrClass, mrSubClass, archiveKey, emrFileIndex, archiveTimes);
                case "SQLSERVER":
                    return medEmrArchiveDetialDALBASE.SelectMedEmrArchiveDetialSQL(patientId, visitId, mrClass, mrSubClass, archiveKey, emrFileIndex, archiveTimes);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medEmrArchiveDetialDALBASE.SelectMedEmrArchiveDetialOLE(patientId, visitId, mrClass, mrSubClass, archiveKey, emrFileIndex, archiveTimes);
                default:
                    return medEmrArchiveDetialDALBASE.SelectMedEmrArchiveDetial(patientId, visitId, mrClass, mrSubClass, archiveKey, emrFileIndex, archiveTimes);
            }
        }
        /// <summary>
        /// 电子病历明细表查询记录
        /// </summary>
        /// <param name="patientId">病人ID号</param>
        /// <param name="visitId"></param>
        /// <param name="mrClass"></param>
        /// <param name="mrSubClass"></param>
        /// <param name="archiveKey"></param>
        /// <param name="archiveTimes">归档次数 归档次数为0则不知道归档次数需要自己到数据库里面获取</param>
        /// <returns></returns>
        public virtual List<MedicalSytem.Soft.Model.MedEmrArchiveDetial> SelectMedEmrArchiveDetial(string patientId, decimal visitId, string mrClass, string mrSubClass, string archiveKey, decimal archiveTimes)
        {

            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medEmrArchiveDetialDALBASE.SelectMedEmrArchiveDetialOdbc(patientId, visitId, mrClass, mrSubClass, archiveKey, archiveTimes);
                case "ORACLE":
                    return medEmrArchiveDetialDALBASE.SelectMedEmrArchiveDetial(patientId, visitId, mrClass, mrSubClass, archiveKey, archiveTimes);
                case "SQLSERVER":
                    return medEmrArchiveDetialDALBASE.SelectMedEmrArchiveDetialSQL(patientId, visitId, mrClass, mrSubClass, archiveKey, archiveTimes);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medEmrArchiveDetialDALBASE.SelectMedEmrArchiveDetialOLE(patientId, visitId, mrClass, mrSubClass, archiveKey, archiveTimes);
                default:
                    return medEmrArchiveDetialDALBASE.SelectMedEmrArchiveDetial(patientId, visitId, mrClass, mrSubClass, archiveKey, archiveTimes);
            }
        }
        /// <summary>
        /// 电子病历明细表查询 根据mrClass archiveKey
        /// </summary>
        /// <param name="patientId">病人ID号</param>
        /// <param name="visitId"></param>
        /// <param name="mrClass"></param>
        /// <param name="archiveKey"></param>
        /// <returns></returns>
        public virtual List<MedicalSytem.Soft.Model.MedEmrArchiveDetial> SelectMedEmrArchiveDetialList(string patientId, decimal visitId, string mrClass, string archiveKey)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medEmrArchiveDetialDALBASE.SelectMedEmrArchiveDetialListOdbc(patientId, visitId, mrClass, archiveKey);
                case "ORACLE":
                    return medEmrArchiveDetialDALBASE.SelectMedEmrArchiveDetialList(patientId, visitId, mrClass, archiveKey);
                case "SQLSERVER":
                    return medEmrArchiveDetialDALBASE.SelectMedEmrArchiveDetialListSQL(patientId, visitId, mrClass, archiveKey);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medEmrArchiveDetialDALBASE.SelectMedEmrArchiveDetialListOLE(patientId, visitId, mrClass, archiveKey);
                default:
                    return medEmrArchiveDetialDALBASE.SelectMedEmrArchiveDetialList(patientId, visitId, mrClass, archiveKey);
            }
        }
        /// <summary>
        /// 电子病历明细表查询 根据mrClass
        /// </summary>
        /// <param name="patientId">病人ID号</param>
        /// <param name="visitId"></param>
        /// <param name="mrClass"></param>
        /// <param name="archiveKey"></param>
        /// <returns></returns>
        public virtual List<MedicalSytem.Soft.Model.MedEmrArchiveDetial> SelectMedEmrArchiveDetialList(string patientId, decimal visitId, string mrClass)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medEmrArchiveDetialDALBASE.SelectMedEmrArchiveDetialListOdbc(patientId, visitId, mrClass);
                case "ORACLE":
                    return medEmrArchiveDetialDALBASE.SelectMedEmrArchiveDetialList(patientId, visitId, mrClass);
                case "SQLSERVER":
                    return medEmrArchiveDetialDALBASE.SelectMedEmrArchiveDetialListSQL(patientId, visitId, mrClass);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medEmrArchiveDetialDALBASE.SelectMedEmrArchiveDetialListOLE(patientId, visitId, mrClass);
                default:
                    return medEmrArchiveDetialDALBASE.SelectMedEmrArchiveDetialList(patientId, visitId, mrClass);
            }
        }
        /// <summary>
        /// 插入电子病历明细表
        /// </summary>
        /// <param name="medEmrWorkPath"></param>
        /// <returns></returns>
        public virtual int InsertMedEmrArchiveDetial(MedicalSytem.Soft.Model.MedEmrArchiveDetial medEmrArchiveDetial)
        {

            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medEmrArchiveDetialDALBASE.InsertMedEmrArchiveDetialOdbc(medEmrArchiveDetial);
                case "ORACLE":
                    return medEmrArchiveDetialDALBASE.InsertMedEmrArchiveDetial(medEmrArchiveDetial);
                case "SQLSERVER":
                    return medEmrArchiveDetialDALBASE.InsertMedEmrArchiveDetialSQL(medEmrArchiveDetial);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medEmrArchiveDetialDALBASE.InsertMedEmrArchiveDetialOLE(medEmrArchiveDetial);
                default:
                    return medEmrArchiveDetialDALBASE.InsertMedEmrArchiveDetial(medEmrArchiveDetial);
            }
        }
        /// <summary>
        /// 更新电子病历明细表
        /// </summary>
        /// <param name="medEmrWorkPath"></param>
        /// <returns></returns>
        public virtual int UpdateMedEmrArchiveDetial(MedicalSytem.Soft.Model.MedEmrArchiveDetial medEmrArchiveDetial)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medEmrArchiveDetialDALBASE.UpdateMedEmrArchiveDetialOdbc(medEmrArchiveDetial);
                case "ORACLE":
                    return medEmrArchiveDetialDALBASE.UpdateMedEmrArchiveDetial(medEmrArchiveDetial);
                case "SQLSERVER":
                    return medEmrArchiveDetialDALBASE.UpdateMedEmrArchiveDetialSQL(medEmrArchiveDetial);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medEmrArchiveDetialDALBASE.UpdateMedEmrArchiveDetialOLE(medEmrArchiveDetial);
                default:
                    return medEmrArchiveDetialDALBASE.UpdateMedEmrArchiveDetial(medEmrArchiveDetial);
            }
        }
        #endregion
        #region 电子病历用户表
        /// <summary>
        /// 一般输入DOCARE
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedEmrUsers SelectMedEmrUsers(string userId)
        {
            return medEmrUsersDALBASE.SelectMedEmrUsers(userId);
        }
        /// <summary>
        /// 插入配置表信息
        /// </summary>
        /// <param name="medEmrWorkPath"></param>
        /// <returns></returns>
        public virtual int InsertMedEmrUsers(MedicalSytem.Soft.Model.MedEmrUsers medEmrUsers)
        {
            return medEmrUsersDALBASE.InsertMedEmrUsers(medEmrUsers);
        }
        /// <summary>
        /// 更新配置表信息
        /// </summary>
        /// <param name="medEmrWorkPath"></param>
        /// <returns></returns>
        public virtual int UpdateMedEmrUsers(MedicalSytem.Soft.Model.MedEmrUsers medEmrUsers)
        {
            return medEmrUsersDALBASE.UpdateMedEmrUsers(medEmrUsers);
        }
        #endregion
        #region 电子病历明细表EXT
        /// <summary>
        /// 电子病历明细表查询一条记录
        /// </summary>
        /// <param name="patientId">病人ID号</param>
        /// <param name="visitId"></param>
        /// <param name="mrClass"></param>
        /// <param name="mrSubClass"></param>
        /// <param name="archiveKey"></param> 
        /// <param name="archiveTimes">归档次数 归档次数为0则不知道归档次数需要自己到数据库里面获取</param>
        /// <param name="emrFileIndex">页码 0为第一文件 1为第二个文件</param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedEmrArchiveDetialExt SelectMedEmrArchiveDetialExt(string patientId, decimal visitId, string mrClass, string mrSubClass, string archiveKey, decimal emrFileIndex, decimal archiveTimes)
        {
            return medEmrArchiveDetialExtDALBASE.SelectMedEmrArchiveDetialExt(patientId, visitId, mrClass, mrSubClass, archiveKey, emrFileIndex, archiveTimes);
        }

        /// <summary>
        /// 电子病历明细表查询 根据mrClass
        /// </summary>
        /// <param name="patientId">病人ID号</param>
        /// <param name="visitId"></param>
        /// <param name="mrClass"></param>
        /// <param name="archiveKey"></param>
        /// <returns></returns>
        public virtual List<MedicalSytem.Soft.Model.MedEmrArchiveDetialExt> SelectMedEmrArchiveDetialExtList(string patientId, decimal visitId, string mrClass)
        {
            return medEmrArchiveDetialExtDALBASE.SelectMedEmrArchiveDetialExtList(patientId, visitId, mrClass);
        }
        /// <summary>
        /// 电子病历明细表查询 根据mrClass archive_key1 archive_key2
        /// </summary>
        /// <param name="patientId">病人ID号</param>
        /// <param name="visitId"></param>
        /// <param name="mrClass"></param>
        /// <param name="archiveKey"></param>
        /// <returns></returns>
        public virtual List<MedicalSytem.Soft.Model.MedEmrArchiveDetialExt> SelectMedEmrArchiveDetialExtList(string patientId, decimal visitId, string mrClass, string archive_key1, string archive_key2)
        {
            return medEmrArchiveDetialExtDALBASE.SelectMedEmrArchiveDetialExtList(patientId, visitId, mrClass, archive_key1, archive_key2);
        }
        /// <summary>
        /// 插入电子病历明细表
        /// </summary>
        /// <param name="medEmrWorkPath"></param>
        /// <returns></returns>
        public virtual int InsertMedEmrArchiveDetialExt(MedicalSytem.Soft.Model.MedEmrArchiveDetialExt MedEmrArchiveDetialExt)
        {
            return medEmrArchiveDetialExtDALBASE.InsertMedEmrArchiveDetialExt(MedEmrArchiveDetialExt);
        }
        /// <summary>
        /// 更新电子病历明细表
        /// </summary>
        /// <param name="medEmrWorkPath"></param>
        /// <returns></returns>
        public virtual int UpdateMedEmrArchiveDetialExt(MedicalSytem.Soft.Model.MedEmrArchiveDetialExt MedEmrArchiveDetialExt)
        {
            return medEmrArchiveDetialExtDALBASE.UpdateMedEmrArchiveDetialExt(MedEmrArchiveDetialExt);
        }
        #endregion

        #region Semr工作人员工号信息
        /// <summary>
        /// 获取SEMR工作人员信息
        /// </summary>
        /// <param name="userId">员工工号</param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.Users SelectSemrUsers(string userId)
        {
            return usersDALBASE.SelectUsers(userId);
        }
        /// <summary>
        /// 获取SEMR工作人员信息
        /// </summary>
        /// <param name="userId">员工工号</param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.Users SelectSemrUsersName(string userName)
        {
            return usersDALBASE.SelectUsersName(userName);
        }
        /// <summary>
        /// 插入SEMR工作人员信息
        /// </summary>
        /// <param name="medEmrWorkPath"></param>
        /// <returns></returns>
        public virtual int InsertSemrUsers(MedicalSytem.Soft.Model.Users oneUsers)
        {
            return usersDALBASE.InsertUsers(oneUsers);
        }
        /// <summary>
        /// 更新SEMR工作人员信息
        /// </summary>
        /// <param name="medEmrWorkPath"></param>
        /// <returns></returns>
        public virtual int UpdateSemrUsers(MedicalSytem.Soft.Model.Users oneUsers)
        {
            return usersDALBASE.UpdateUsers(oneUsers);
        }
        #endregion
        #region Semr病人基本信息
        /// <summary>
        /// 获取SEMR病人基本信息
        /// </summary>
        /// <param name="userId">病人ID</param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.Patients SelectSemrPatients(string patientId)
        {
            return patientsDALBASE.SelectPatients(patientId);
        }
        /// <summary>
        /// 插入SEMR病人基本信息
        /// </summary>
        /// <param name="medEmrWorkPath"></param>
        /// <returns></returns>
        public virtual int InsertSemrPatients(MedicalSytem.Soft.Model.Patients onePatients)
        {
            return patientsDALBASE.InsertPatients(onePatients);
        }
        /// <summary>
        /// 更新SEMR病人基本信息
        /// </summary>
        /// <param name="medEmrWorkPath"></param>
        /// <returns></returns>
        public virtual int UpdateSemrPatients(MedicalSytem.Soft.Model.Patients onePatients)
        {
            return patientsDALBASE.UpdatePatients(onePatients);
        }
        #endregion
        #region Semr挂号基本信息
        /// <summary>
        /// 获取SEMR挂号基本信息
        /// </summary>
        /// <param name="userId">挂号ID</param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.Medicalcases SelectSemrMedicalcases(string medicalId)
        {
            return medicalcasesDALBASE.SelectMedicalcases(medicalId);
        }
        /// <summary>
        /// 插入SEMR挂号基本信息
        /// </summary>
        /// <param name="medEmrWorkPath"></param>
        /// <returns></returns>
        public virtual int InsertSemrMedicalcases(MedicalSytem.Soft.Model.Medicalcases oneMedicalcases)
        {
            return medicalcasesDALBASE.InsertMedicalcases(oneMedicalcases);
        }
        /// <summary>
        /// 更新SEMR挂号基本信息
        /// </summary>
        /// <param name="medEmrWorkPath"></param>
        /// <returns></returns>
        public virtual int UpdateSemrMedicalcases(MedicalSytem.Soft.Model.Medicalcases oneMedicalcases)
        {
            return medicalcasesDALBASE.UpdateMedicalcases(oneMedicalcases);
        }
        #endregion

        #region  HIS视图脚本存放处
        /// <summary>
        /// HIS视图脚本存放处
        /// </summary>
        /// <param name="MedTableName"></param>
        /// <param name="DbmsType"></param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedIfHisViewSql SelectMedIfHisViewSql(string MedTableName, string DbmsType)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medifhisviewsqlDALBASE.SelectMedIfHisViewSqlODBC(MedTableName, DbmsType);
                case "SQLSERVER":
                    return medifhisviewsqlDALBASE.SelectMedIfHisViewSqlSQL(MedTableName, DbmsType);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medifhisviewsqlDALBASE.SelectMedIfHisViewSqlOLE(MedTableName, DbmsType);
                default:
                    return medifhisviewsqlDALBASE.SelectMedIfHisViewSql(MedTableName, DbmsType);
            }
        }
        #endregion

        #region 供应室追溯系统
        /// <summary>
        /// 根据条码号BarCode提取一个物品信息
        /// </summary>
        /// <param name="BarCode">条码号</param>
        /// <returns></returns>
        public virtual MedicalSytem.Soft.Model.MedPackageMaster SelectMedPackageMaster(string BarCode)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medpackagemasterDALBASE.SelectMedPackageMasterODBC(BarCode);
                case "SQLSERVER":
                    return medpackagemasterDALBASE.SelectMedPackageMasterSQL(BarCode);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medpackagemasterDALBASE.SelectMedPackageMasterOLE(BarCode);
                default:
                    return medpackagemasterDALBASE.SelectMedPackageMaster(BarCode);
            }

        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="oneMedPackageMaster"></param>
        /// <returns></returns>
        public virtual int InsertMedPackageMaster(MedicalSytem.Soft.Model.MedPackageMaster oneMedPackageMaster)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medpackagemasterDALBASE.InsertMedPackageMasterODBC(oneMedPackageMaster);
                case "SQLSERVER":
                    return medpackagemasterDALBASE.InsertMedPackageMasterSQL(oneMedPackageMaster);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medpackagemasterDALBASE.InsertMedPackageMasterOLE(oneMedPackageMaster);
                default:
                    return medpackagemasterDALBASE.InsertMedPackageMaster(oneMedPackageMaster);
            }

        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="oneMedPackageMaster"></param>
        /// <returns></returns>
        public virtual int UpdateMedPackageMaster(MedicalSytem.Soft.Model.MedPackageMaster oneMedPackageMaster)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medpackagemasterDALBASE.UpdateMedPackageMasterODBC(oneMedPackageMaster);
                case "SQLSERVER":
                    return medpackagemasterDALBASE.UpdateMedPackageMasterSQL(oneMedPackageMaster);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medpackagemasterDALBASE.UpdateMedPackageMasterOLE(oneMedPackageMaster);
                default:
                    return medpackagemasterDALBASE.UpdateMedPackageMaster(oneMedPackageMaster);
            }

        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="BarCode"></param>
        /// <returns></returns>
        public virtual int DeleteMedPackageMaster(string BarCode)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medpackagemasterDALBASE.DeleteMedPackageMasterODBC(BarCode);
                case "SQLSERVER":
                    return medpackagemasterDALBASE.DeleteMedPackageMasterSQL(BarCode);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medpackagemasterDALBASE.DeleteMedPackageMasterOLE(BarCode);
                default:
                    return medpackagemasterDALBASE.DeleteMedPackageMaster(BarCode);
            }

        }
        /// <summary>
        /// 根据条码号BarCode提取一个物品明细信息
        /// </summary>
        /// <param name="BarCode"></param>
        /// <returns></returns>
        public virtual List<MedicalSytem.Soft.Model.MedPackageDetail> SelectMedPackageDetail(string BarCode)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medpackagedetailDALBASE.SelectMedPackageDetailODBC(BarCode);
                case "SQLSERVER":
                    return medpackagedetailDALBASE.SelectMedPackageDetailSQL(BarCode);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medpackagedetailDALBASE.SelectMedPackageDetailOLE(BarCode);
                default:
                    return medpackagedetailDALBASE.SelectMedPackageDetail(BarCode);
            }

        }
        public virtual MedicalSytem.Soft.Model.MedPackageDetail SelectMedPackageDetailWithName(string BarCode, string InstrumentName)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medpackagedetailDALBASE.SelectMedPackageDetailWithNameODBC(BarCode, InstrumentName);
                case "SQLSERVER":
                    return medpackagedetailDALBASE.SelectMedPackageDetailWithNameSQL(BarCode, InstrumentName);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medpackagedetailDALBASE.SelectMedPackageDetailWithNameOLE(BarCode, InstrumentName);
                default:
                    return medpackagedetailDALBASE.SelectMedPackageDetailWithName(BarCode, InstrumentName);
            }

        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="oneMedPackageDetail"></param>
        /// <returns></returns>
        public virtual int InsertMedPackageDetail(MedicalSytem.Soft.Model.MedPackageDetail oneMedPackageDetail)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medpackagedetailDALBASE.InsertMedPackageDetailODBC(oneMedPackageDetail);
                case "SQLSERVER":
                    return medpackagedetailDALBASE.InsertMedPackageDetailSQL(oneMedPackageDetail);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medpackagedetailDALBASE.InsertMedPackageDetailOLE(oneMedPackageDetail);
                default:
                    return medpackagedetailDALBASE.InsertMedPackageDetail(oneMedPackageDetail);
            }
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="oneMedPackageDetail"></param>
        /// <returns></returns>
        public virtual int UpdateMedPackageDetail(MedicalSytem.Soft.Model.MedPackageDetail oneMedPackageDetail)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medpackagedetailDALBASE.UpdateMedPackageDetailODBC(oneMedPackageDetail);
                case "SQLSERVER":
                    return medpackagedetailDALBASE.UpdateMedPackageDetailSQL(oneMedPackageDetail);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medpackagedetailDALBASE.UpdateMedPackageDetailOLE(oneMedPackageDetail);
                default:
                    return medpackagedetailDALBASE.UpdateMedPackageDetail(oneMedPackageDetail);
            }

        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="BarCode"></param>
        /// <returns></returns>
        public virtual int DeleteMedPackageDetail(string BarCode)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medpackagedetailDALBASE.DeleteMedPackageDetailODBC(BarCode);
                case "SQLSERVER":
                    return medpackagedetailDALBASE.DeleteMedPackageDetailSQL(BarCode);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medpackagedetailDALBASE.DeleteMedPackageDetailOLE(BarCode);
                default:
                    return medpackagedetailDALBASE.DeleteMedPackageDetail(BarCode);
            }

        }
        #endregion

        #region 麻醉事件
        public virtual MedicalSytem.Soft.Model.MedAnesthesiaEvent SelectMedAnesiaEvent(string patientId, decimal visitId, decimal operId)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medAnesthesiaEventDALBASE.SelectMedAnesiaEventODBC(patientId, visitId, operId);
                case "SQLSERVER":
                    return medAnesthesiaEventDALBASE.SelectMedAnesiaEventSQL(patientId, visitId, operId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medAnesthesiaEventDALBASE.SelectMedAnesiaEventOLE(patientId, visitId, operId);
                default:
                    return medAnesthesiaEventDALBASE.SelectMedAnesiaEvent(patientId, visitId, operId);
            }

        }
        #endregion

        #region 出入量和体征数据
        public virtual int InsertMedInOrOutRec(MedicalSytem.Soft.Model.MedInOrOutRec medInOrOutRec)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medInOrOutRecDALBASE.InsertMedInOrOutRecODBC(medInOrOutRec);
                case "SQLSERVER":
                    return medInOrOutRecDALBASE.InsertMedInOrOutRecSQL(medInOrOutRec);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medInOrOutRecDALBASE.InsertMedInOrOutRecOLE(medInOrOutRec);
                default:
                    return medInOrOutRecDALBASE.InsertMedInOrOutRec(medInOrOutRec);
            }
        }
        public virtual int UpdateMedInOrOutRec(MedicalSytem.Soft.Model.MedInOrOutRec medInOrOutRec)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medInOrOutRecDALBASE.UpdateMedInOrOutRecODBC(medInOrOutRec);
                case "SQLSERVER":
                    return medInOrOutRecDALBASE.UpdateMedInOrOutRecSQL(medInOrOutRec);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medInOrOutRecDALBASE.UpdateMedInOrOutRecOLE(medInOrOutRec);
                default:
                    return medInOrOutRecDALBASE.UpdateMedInOrOutRec(medInOrOutRec);
            }
        }
        public virtual MedicalSytem.Soft.Model.MedInOrOutRec SelectMedInOrOutRec(string patientId, decimal visitId, decimal deptId)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medInOrOutRecDALBASE.SelectMedInOrOutRecODBC(patientId, visitId, deptId);
                case "SQLSERVER":
                    return medInOrOutRecDALBASE.SelectMedInOrOutRecSQL(patientId, visitId, deptId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medInOrOutRecDALBASE.SelectMedInOrOutRecOLE(patientId, visitId, deptId);
                default:
                    return medInOrOutRecDALBASE.SelectMedInOrOutRec(patientId, visitId, deptId);
            }
        }


        public virtual int InsertMedVitalSignsRecTemp(MedicalSytem.Soft.Model.MedVitalSignsRecTemp medVitalSignsRecTemp)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVitalSignsRecTempDALBASE.InsertMedVitalSignsRecTempODBC(medVitalSignsRecTemp);
                case "SQLSERVER":
                    return medVitalSignsRecTempDALBASE.InsertMedVitalSignsRecTempSQL(medVitalSignsRecTemp);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVitalSignsRecTempDALBASE.InsertMedVitalSignsRecTempOLE(medVitalSignsRecTemp);
                default:
                    return medVitalSignsRecTempDALBASE.InsertMedVitalSignsRecTemp(medVitalSignsRecTemp);
            }
        }
        public virtual int UpdateMedVitalSignsRecTemp(MedicalSytem.Soft.Model.MedVitalSignsRecTemp medVitalSignsRecTemp)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVitalSignsRecTempDALBASE.UpdateMedVitalSignsRecTempODBC(medVitalSignsRecTemp);
                case "SQLSERVER":
                    return medVitalSignsRecTempDALBASE.UpdateMedVitalSignsRecTempSQL(medVitalSignsRecTemp);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVitalSignsRecTempDALBASE.UpdateMedVitalSignsRecTempOLE(medVitalSignsRecTemp);
                default:
                    return medVitalSignsRecTempDALBASE.UpdateMedVitalSignsRecTemp(medVitalSignsRecTemp);
            }
        }
        public virtual MedicalSytem.Soft.Model.MedVitalSignsRecTemp SelectMedVitalSignsRecTemp(string patientId, decimal visitId, decimal deptId)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVitalSignsRecTempDALBASE.SelectMedVitalSignsRecTempODBC(patientId, visitId, deptId);
                case "SQLSERVER":
                    return medVitalSignsRecTempDALBASE.SelectMedVitalSignsRecTempSQL(patientId, visitId, deptId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVitalSignsRecTempDALBASE.SelectMedVitalSignsRecTempOLE(patientId, visitId, deptId);
                default:
                    return medVitalSignsRecTempDALBASE.SelectMedVitalSignsRecTemp(patientId, visitId, deptId);
            }
        }
        public virtual List<MedicalSytem.Soft.Model.MedVitalSignsRecTemp> SelectMedVitalSignsRecTempALL(string patientId, decimal visitId)
        {
            switch (DateType.ToUpper())
            {
                case "ODBC":
                    return medVitalSignsRecTempDALBASE.SelectMedVitalSignsRecTempALLODBC(patientId, visitId);
                case "SQLSERVER":
                    return medVitalSignsRecTempDALBASE.SelectMedVitalSignsRecTempALLSQL(patientId, visitId);
                case "ORACLEOLE":
                case "ORAOLEDB":
                    return medVitalSignsRecTempDALBASE.SelectMedVitalSignsRecTempALLOLE(patientId, visitId);
                default:
                    return medVitalSignsRecTempDALBASE.SelectMedVitalSignsRecTempALL(patientId, visitId);
            }
        }
        #endregion
    }

}
