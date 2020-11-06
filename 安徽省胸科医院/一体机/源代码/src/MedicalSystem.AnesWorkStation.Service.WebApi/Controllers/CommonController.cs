using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Dapper.Data;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.DataServices.Domain;
using MedicalSystem.AnesWorkStation.Domain.Origins;
using MedicalSystem.AnesWorkStation.Domain.Report;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers
{
    /// <summary>
    /// 常用方法类
    /// </summary>
    public class CommonController : BaseController
    {
        ICommonService _common;
        public CommonController(ICommonService common)
        {
            _common = common;
        }

        /// <summary>
        /// 测试网络连接
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<bool> TestNet()
        {
            return Success(_common.TestNet());
        }

        /// <summary>
        /// 测试数据库连接
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<bool> TestDbConn()
        {
            try
            {
                return Success(_common.TestDbConn());
            }
            catch (Exception ex)
            {
                return Failed<bool>(ex.Message);
            }
        }
        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<DateTime> GetServerTime()
        {
            return Success(_common.GetServerTime());
        }

        [HttpGet]
        public RequestResult<List<MED_QIXIE_TEMPLET_MASTER>> GetQiXieTempletMaster()
        {
            List<MED_QIXIE_TEMPLET_MASTER> templetMaster = _common.GetQiXieTempletMaster();
            return Success(templetMaster);
        }

        /// <summary>
        /// 使用事务批量处理数据,传递的参数一定是TransactionParamsters.ToString()
        /// </summary>
        [HttpPost]
        public RequestResult<bool> UpdateByTransaction(dynamic dyParams)
        {
            return Success(_common.UpdateByTransaction(dyParams));
        }

        [HttpGet]
        public RequestResult<List<MED_DOCUMENT_TEMPLET>> GetDocumentTemplet()
        {
            List<MED_DOCUMENT_TEMPLET> docTemplet = _common.GetDocumentTemplet();
            return Success(docTemplet);
        }

        [HttpGet]
        public RequestResult<List<MED_QIXIE_TEMPLET_DETAIL>> GetQiXieTempletDetail(string strGuid)
        {
            List<MED_QIXIE_TEMPLET_DETAIL> result = _common.GetQiXieTempletDetail(strGuid);
            return Success(result);
        }

        [HttpPost]
        public RequestResult<bool> SaveDocumentTemplet(MED_DOCUMENT_TEMPLET row)
        {
            return Success(_common.SaveDocumentTemplet(row));
        }

        /// <summary>
        /// 更新数据到数据库
        /// </summary>
        [HttpPost]
        public RequestResult<bool> SaveChangeRoomNo(List<MED_CHANGE_ROOM_NO> list)
        {
            return Success(_common.SaveChangeRoomNo(list));
        }

        /// <summary>
        /// 更新数据到数据库
        /// </summary>
        [HttpPost]
        public RequestResult<bool> SaveOperationJump(List<MED_OPERATION_JUMP> list)
        {
            return Success(_common.SaveOperationJump(list));
        }

        /// <summary>
        /// 根据ID获取对应的数据表
        /// </summary>
        [HttpGet]
        public RequestResult<List<MED_CHANGE_ROOM_NO>> GetChangeRoomNo(string patientID, int visitID, int operID)
        {
            return Success(_common.GetChangeRoomNo(patientID, visitID, operID));
        }

        /// <summary>
        /// 根据ID获取对应的数据表
        /// </summary>
        [HttpGet]
        public RequestResult<List<MED_OPERATION_JUMP>> GetOperationJump(string patientID, int visitID, int operID)
        {
            return Success(_common.GetOperationJump(patientID, visitID, operID));
        }

        /// <summary>
        /// 获取手术取消
        /// </summary>
        [HttpGet]
        public RequestResult<List<MED_OPERATION_CANCELED>> GetOperationCanceled(string patientID, int visitID)
        {
            return Success(_common.GetOperationCanceled(patientID, visitID));
        }

        /// <summary>
        /// 获得抢救明细
        /// </summary>
        [HttpGet]
        public RequestResult<List<MED_OPERATION_RESCUE>> GetOperationRescue(string patientID, int visitID, int operID)
        {
            return Success(_common.GetOperationRescue(patientID, visitID, operID));
        }

        /// <summary>
        /// 保存抢救明细
        /// </summary>
        [HttpPost]
        public RequestResult<bool> SaveOperationRescue(List<MED_OPERATION_RESCUE> list)
        {
            return Success(_common.SaveOperationRescue(list));
        }

        /// <summary>
        /// 保存大屏信息
        /// </summary>
        [HttpPost]
        public RequestResult<bool> SaveOperationScreen(List<MED_SCREEN_MSG> list)
        {
            return Success(_common.SaveOperationScreen(list));
        }

        /// <summary>
        /// 更新手术取消
        /// </summary>
        [HttpPost]
        public RequestResult<bool> SaveOperationCanceled(List<MED_OPERATION_CANCELED> list)
        {
            return Success(_common.SaveOperationCanceled(list));
        }

        /// <summary>
        /// 更新手术取消明细
        /// </summary>
        [HttpPost]
        public RequestResult<bool> SaveOperationCanceledDetail(List<MED_OPERATION_CANCELED_DETAIL> list)
        {
            return Success(_common.SaveOperationCanceledDetail(list));
        }

        /// <summary>
        /// 获取手术取消明细表
        /// </summary>
        [HttpGet]
        public RequestResult<List<MED_OPERATION_CANCELED_DETAIL>> GetOperationCanceledDetail(string patientID, int visitID, int cancelID)
        {
            return Success(_common.GetOperationCanceledDetail(patientID, visitID, cancelID));
        }

        /// <summary>
        /// 获取当前手术间的消息
        /// </summary>
        [HttpGet]
        public RequestResult<List<MED_TRANSPORT_MESSAGE>> GetTransportMessage(string strOperRoomNo)
        {
            return Success(_common.GetTransportMessage(strOperRoomNo));
        }

        /// <summary>
        /// 保存消息
        /// </summary>
        [HttpPost]
        public RequestResult<bool> SaveTransportMessage(List<MED_TRANSPORT_MESSAGE> list)
        {
            return Success(_common.SaveTransportMessage(list));
        }

        /// <summary>
        /// 获取当前手术间未读取的消息
        /// </summary>
        [HttpGet]
        public RequestResult<List<MED_TRANSPORT_MESSAGE>> GetNotReadTransportMessage(string strOperRoomNo)
        {
            return Success(_common.GetNotReadTransportMessage(strOperRoomNo));
        }

        /// <summary>
        /// 获取检验信息主信息
        /// </summary>
        [HttpGet]
        public RequestResult<List<MED_LAB_TEST_MASTER>> GetMedLabTestMaster(string patientId, int visitId)
        {
            return Success(_common.GetMedLabTestMaster(patientId, visitId));
        }

        /// <summary>
        /// 获取检验信息明细
        /// </summary>
        [HttpGet]
        public RequestResult<List<MED_LAB_RESULT>> GetMedLabResult(string testNo)
        {
            return Success(_common.GetMedLabResult(testNo));
        }

        /// <summary>
        /// 根据患者ID获取检验结果明细
        /// </summary>
        [HttpGet]
        public RequestResult<List<MED_LAB_RESULT>> GetMedLabResult(string patientId, int visitId)
        {
            return Success(_common.GetMedLabResult(patientId, visitId));
        }

        [HttpGet]
        public RequestResult<List<MED_LAB_PATIENT>> GetLabPatientList(string patientId, int visitId)
        {
            return Success(_common.GetLabPatientList(patientId, visitId));
        }

        [HttpPost]
        public RequestResult<int> PostFile(dynamic dyParams)
        {
            return Success(_common.PostFile(dyParams));
        }

        [HttpPost]
        public RequestResult<int> PostPDFFile(dynamic dyPatams)
        {
            return Success(_common.PostPDFFile(dyPatams));
        }

        [HttpGet]
        public RequestResult<List<MED_INTERFACE_DETAIL>> GetInterfaceDetail()
        {
            return Success(this._common.GetInterfaceDetail());
        }

        #region 获取公共组件字典
        /// <summary>
        /// 获取字典数据
        /// </summary>
        /// <param name="reportCondition">查询条件对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<List<KeyValue>> GetDict(QueryDictConfig config)
        {
            return Success(_common.GetDict(config));
        }
        #endregion

        [HttpGet]
        public RequestResult<List<string>> GetAnesConfigByParams(string para)
        {
            return Success(_common.GetAnesConfigByParams(para));
        }

        [HttpGet]
        public RequestResult<List<MED_VER_INFO>> GetVerInfoList(string appID)
        {
            return Success(_common.GetVerInfoList(appID));
        }
    }
}