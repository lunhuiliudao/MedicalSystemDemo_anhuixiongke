using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.Common.FileManage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Xml;
using MedicalSystem.AnesWorkStation.Domain.RequestResult;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 质控管理接口
    /// </summary>
    public interface IPlatformQuanlityControlService
    {
        IList<MED_QC_REPORT_LIST> GetQuanlityControlReportItemList(string reportMonth);
        IList<MED_QC_REPORT_LIST> GetQuanlityControlReportBakItemList(string reportName, string isOutRoomOper);

        /// <summary>
        /// 是否已经上报质控数据
        /// </summary>
        /// <param name="reportMonth"></param>
        /// <returns></returns>
        int IsQuanlityControlDataUpload(string reportMonth);

        /// <summary>
        /// 是否已经上报质控数据
        /// </summary>
        /// <param name="reportName"></param>
        /// <returns></returns>
        int IsQuanlityControlDataUploadByReportName(string reportName);

        string SyncQuanlityControlData(string reportMonth);
        string AddQuanlityControlReportDataBak(string reportMonth, string name);

        /// <summary>
        /// 保存备份数据
        /// </summary>
        /// <param name="medQcReportList"></param>
        /// <returns></returns>
        RequestResult<int> SaveQuanlityControlReportDataBak(IList<MED_QC_REPORT_LIST> medQcReportList, string isOutRoomOper);

        /// <summary>
        /// 获取不良事件备份数据
        /// </summary>
        /// <param name="reportName"></param>
        /// <returns></returns>
        List<MED_QC_AE_BAK> GetQuanlityControlAeBakDataByReportName(string reportName);

        /// <summary>
        /// 获取备份不良事件患者基本信息数据
        /// </summary>
        /// <param name="reportName"></param>
        /// <returns></returns>
        List<MED_QC_PATIENT_INFO> GetQuanlityControlAeBakPatientInfoDataByReportName(string reportName);

        /// <summary>
        /// 获取备份不良事件患者基本信息数据
        /// </summary>
        /// <param name="reportName"></param>
        /// <returns></returns>
        List<MED_QC_PATIENT_INFO> GetQuanlityControlAeBakPatientInfoDataByReportNameNoGroupBy(string reportName);

        /// <summary>
        /// 获取备份不良事件患者基本信息数据
        /// </summary>
        /// <param name="reportName"></param>
        /// <param name="reportNo">MED_QC_REPORT_LIST表 REPORT_NO </param>
        /// <returns></returns>
        List<MED_QC_PATIENT_INFO> GetQuanlityControlAeBakPatientInfoDataByReportNameAndReportNo(string reportName, string reportNo);

        /// <summary>
        /// 获取备份不良事件患者基本信息数据
        /// </summary>
        /// <param name="reportName"></param>
        /// <param name="reportNo">MED_QC_REPORT_LIST表 REPORT_NO </param>
        /// <returns></returns>
        List<MED_QC_PATIENT_INFO> GetQuanlityControlAeBakPatientInfoDataByReportNameAndReportNoOut(string reportName, string reportNo);

        List<MED_QC_REPORT_DATA_BAK> GetQuanlityControlReportDataBak(string reportName);

        List<MED_QC_REPORT_DATA_BAK> GetQuanlityControlReportDataBakAll(string reportName);

        IList<MED_QC_ITEM> GetQuanlityControlItemList();


        /// <summary>
        /// 保存不良事件备份数据上传标志
        /// </summary>
        /// <param name="medQcPatientInfo"></param>
        void SaveQuanlityControlAeBakData(IList<MED_QC_PATIENT_INFO> medQcPatientInfo);

        /// <summary>
        /// 保存不良事件备份数据上传标志
        /// </summary>
        /// <param name="medQcPatientInfo"></param>
        int UploadQuanlityControlAeBakData(string reportId, string patientId, int visitId, int operId, string reportNo, int upload);

        /// <summary>
        /// 获取主索引数据
        /// </summary>
        /// <returns></returns>
        List<MED_QC_REPORT_IND> GetQuanlityControlReportInd();
        /// <summary>
        /// 获取主索引数据
        /// </summary>
        /// <returns></returns>
        List<MED_QC_REPORT_IND> GetQuanlityControlReportIndByReportId(string reportId);
        /// <summary>
        /// 获取主索引数据
        /// </summary>
        /// <returns></returns>
        List<MED_QC_REPORT_IND> GetQuanlityControlReportInd2();

        /// <summary>
        /// 保存主索引数据上传标志
        /// </summary>
        /// <param name="reportId"></param>
        /// <param name="status"></param>
        /// <param name="LoginUserId"></param>
        /// <returns></returns>
        RequestResult<int> SaveQuanlityControlReportInd(string reportId, int status, string LoginUserId);

        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="reportMonth">月份</param>
        /// <param name="reportName">模块名字</param>
        /// <param name="exprotExcelColumns">导出的列</param>
        /// <returns></returns>
        string ExportExcel(object reportMonth, string reportName, dynamic exprotExcelColumns, string isOutRoomOper);

        int EditQuanlityControlItem(int type, MED_QC_ITEM medQcItem);

        int DeletedQuanlityControlItemList(List<MED_QC_ITEM> medQcItemList);

        IList<MED_QC_REPORT_LIST> GetQuanlityControlReportList();

        int EditQuanlityControlReportList(int type, MED_QC_REPORT_LIST medQcReportList);

        int DeletedQuanlityControlReportList(List<MED_QC_REPORT_LIST> medQcReportList);

        /// <summary>
        /// 获取患者基本信息数据
        /// </summary>
        /// <param name="inpNo"> </param>
        /// <returns></returns>
        List<MED_QC_PATIENT_INFO> GetQCPatientBaseInfo(string inpNo);

        /// <summary>
        /// 获取患者基本信息数据
        /// </summary>
        /// <param name="inpNo"> </param>
        /// <returns></returns>
        List<MED_QC_PATIENT_INFO> GetQCPatientBaseInfo2(string patientId, decimal visitId, decimal operId);

        /// <summary>
        /// 获取患者基本信息数据
        /// </summary>
        /// <param name="inpNo"> </param>
        /// <returns></returns>
        List<MED_QC_OUT_PAT_INFO> GetQCPatientBaseInfoOut(string inpNo);

        /// <summary>
        /// 获取患者基本信息数据
        /// </summary>
        /// <param name="inpNo"> </param>
        /// <returns></returns>
        List<MED_QC_OUT_PAT_INFO> GetQCPatientBaseInfoOut2(string patientId, decimal visitId, decimal operId);

        /// <summary>
        /// 获取质控数据表数据
        /// </summary>
        /// <param name="patientId">  </param>
        /// <param name="visitId">  </param>
        /// <param name="operId">  </param>
        /// <returns></returns>
        List<MED_ANESTHESIA_INPUT_DATA> GetMedAnesthesiaInputData(string patientId, int visitId, int operId);

        /// <summary>
        /// 获取质控数据表数据
        /// </summary>
        /// <param name="patientId">  </param>
        /// <param name="visitId">  </param>
        /// <param name="operId">  </param>
        /// <returns></returns>
        List<MED_ANESTHESIA_INPUT_DATA_OUT> GetMedAnesthesiaInputDataOut(string patientId, int visitId, int operId);

        /// <summary>
        /// 保存备份数据
        /// </summary>
        /// <param name="medQcReportList"></param>
        /// <returns></returns>
        int SaveMedAnesthesiaInputData(MED_ANESTHESIA_INPUT_DATA medAnesthesiaInputData);


        /// <summary>
        /// 保存备份数据---室外
        /// </summary>
        /// <param name="medQcReportList"></param>
        /// <returns></returns>
        int SaveOutMedAnesthesiaInputData(MED_QC_OUT_PAT_INFO outPatInfo, MED_ANESTHESIA_INPUT_DATA_OUT outMedAnesthesiaInputData);
    }
    /// <summary>
    /// 质控管理
    /// </summary>
    public class PlatformQuanlityControlService : BaseService<PlatformQuanlityControlService>, IPlatformQuanlityControlService
    {
        protected PlatformQuanlityControlService()
            : base() { }

        public PlatformQuanlityControlService(IDapperContext context)
            : base(context)
        {
        }

        public IList<MED_QC_REPORT_LIST> GetQuanlityControlReportItemList(string reportMonth)
        {
            IList<MED_QC_REPORT_DATA> master = GetQuanlityControlReportData(reportMonth);

            IList<MED_QC_OUT_REPORT_DATA> masterOut = GetQuanlityControlReportDataOut(reportMonth);

            IList<MED_QC_REPORT_LIST> itemList = GetQuanlityControlReportList();

            foreach (var item in itemList)
            {
                decimal valueFenZi = 0;
                decimal valueFenMu = 0;
                if (!string.IsNullOrEmpty(item.NMRTR_CODE))
                {
                    MED_QC_REPORT_DATA dataFind = master.FirstOrDefault<MED_QC_REPORT_DATA>(t => t.QC_CODE == item.NMRTR_CODE);

                    //室外
                    MED_QC_OUT_REPORT_DATA dataFindOut = masterOut.FirstOrDefault<MED_QC_OUT_REPORT_DATA>(t => t.QC_CODE == item.NMRTR_CODE);

                    if (dataFind != null)
                    {
                        valueFenZi = dataFind.QC_VALUE;//分子
                        item.NMRTR_CODE = valueFenZi.ToString();
                        item.COUNT_DATE = dataFind.COUNT_DATE;
                    }
                    else
                    {
                        valueFenZi = 0;
                        item.NMRTR_CODE = valueFenZi.ToString();
                    }

                    //室外
                    if (dataFindOut != null && !item.REPORT_NAME.Contains("麻醉科医患比（GB）"))
                    {
                        valueFenZi += dataFindOut.QC_VALUE;//分子
                        item.NMRTR_CODE = valueFenZi.ToString();
                        item.COUNT_DATE = dataFindOut.COUNT_DATE;
                    }
                    else
                    {
                        valueFenZi += 0;
                        item.NMRTR_CODE = valueFenZi.ToString();
                    }
                }
                if (!string.IsNullOrEmpty(item.DNMTR_CODE))
                {
                    MED_QC_REPORT_DATA dataFind = master.FirstOrDefault<MED_QC_REPORT_DATA>(t => t.QC_CODE == item.DNMTR_CODE);

                    //室外
                    MED_QC_OUT_REPORT_DATA dataFindOut = masterOut.FirstOrDefault<MED_QC_OUT_REPORT_DATA>(t => t.QC_CODE == item.DNMTR_CODE);

                    if (dataFind != null)
                    {
                        valueFenMu = dataFind.QC_VALUE;//分子
                        item.DNMTR_CODE = valueFenMu.ToString();
                        item.COUNT_DATE = dataFind.COUNT_DATE;
                    }
                    else
                    {
                        valueFenMu = 0;
                        item.DNMTR_CODE = valueFenMu.ToString();
                    }

                    //室外
                    if (dataFindOut != null && !item.REPORT_NAME.Contains("麻醉科医患比（DB）"))
                    {
                        valueFenMu += dataFindOut.QC_VALUE;//分子
                        item.DNMTR_CODE = valueFenMu.ToString();
                        item.COUNT_DATE = dataFindOut.COUNT_DATE;
                    }
                    else
                    {
                        valueFenMu += 0;
                        item.DNMTR_CODE = valueFenMu.ToString();
                    }
                }

                if (item.REPORT_NAME == "各ASA分级麻醉患者比例" || item.REPORT_NAME == "各类麻醉方式比例")
                {

                }
                else
                {
                    if (item.UNIT != null && !string.IsNullOrEmpty(item.UNIT.Trim()))
                    {
                        if (item.UNIT.Trim() == "%")//百分比
                        {
                            item.PERCENT = valueFenMu == 0 ? "0" + item.UNIT.Trim() : (Math.Round(valueFenZi * 100 / valueFenMu, 2).ToString() + item.UNIT.Trim());
                        }
                        else if (item.UNIT.Trim() == "‰")//千分比
                        {
                            item.PERCENT = valueFenMu == 0 ? "0" + item.UNIT.Trim() : (Math.Round(valueFenZi * 1000 / valueFenMu, 2).ToString() + item.UNIT.Trim());
                        }
                        else if (item.UNIT.Trim() == "‱")//万分比
                        {
                            item.PERCENT = valueFenMu == 0 ? "0" + item.UNIT.Trim() : (Math.Round(valueFenZi * 10000 / valueFenMu, 2).ToString() + item.UNIT.Trim());
                        }
                        else
                        {
                            if (item.REPORT_NAME == "麻醉科医患比（DB）")
                            {
                                item.PERCENT = valueFenMu == 0 ? "0" : (Math.Round(valueFenZi * 100 / valueFenMu, 2).ToString());
                            }
                            else
                            {
                                item.PERCENT = valueFenMu == 0 ? "0%" : (Math.Round(valueFenZi * 100 / valueFenMu, 2).ToString() + "%");
                            }
                        }
                    }
                    else
                    {
                        if (item.REPORT_NAME == "麻醉科医患比（DB）")
                        {
                            item.PERCENT = valueFenMu == 0 ? "0" : (Math.Round(valueFenZi * 100 / valueFenMu, 2).ToString());
                        }
                        else
                        {
                            item.PERCENT = valueFenMu == 0 ? "0%" : (Math.Round(valueFenZi * 100 / valueFenMu, 2).ToString() + "%");
                        }
                    }
                }
            }
            return itemList;
        }

        public IList<MED_QC_REPORT_LIST> GetQuanlityControlReportItemListByReportId(string reportId)
        {
            IList<MED_QC_REPORT_DATA_BAK> master = GetQuanlityControlReportDataBakByReportId(reportId);
            IList<MED_QC_REPORT_LIST> itemList = GetQuanlityControlReportList();

            foreach (var item in itemList)
            {
                decimal valueFenZi = 0;
                decimal valueFenMu = 0;
                if (!string.IsNullOrEmpty(item.NMRTR_CODE))
                {
                    MED_QC_REPORT_DATA_BAK dataFind = master.FirstOrDefault<MED_QC_REPORT_DATA_BAK>(t => t.QC_CODE == item.NMRTR_CODE);
                    if (dataFind != null)
                    {
                        valueFenZi = dataFind.QC_VALUE;//分子
                        item.NMRTR_CODE_VALUE = valueFenZi.ToString();
                    }
                    else
                    {
                        valueFenZi = 0;
                        item.NMRTR_CODE_VALUE = "0";
                    }
                }
                if (!string.IsNullOrEmpty(item.DNMTR_CODE))
                {
                    MED_QC_REPORT_DATA_BAK dataFind = master.FirstOrDefault<MED_QC_REPORT_DATA_BAK>(t => t.QC_CODE == item.DNMTR_CODE);
                    if (dataFind != null)
                    {
                        valueFenMu = dataFind.QC_VALUE;//分子
                        item.DNMTR_CODE_VALUE = valueFenMu.ToString();
                    }
                    else
                    {
                        valueFenMu = 0;
                        item.DNMTR_CODE_VALUE = "0";
                    }
                }

                if (item.REPORT_NAME == "各ASA分级麻醉患者比例" || item.REPORT_NAME == "各类麻醉方式比例")
                {

                }
                else
                {
                    if (item.UNIT != null && !string.IsNullOrEmpty(item.UNIT.Trim()))
                    {
                        if (item.UNIT.Trim() == "%")//百分比
                        {
                            item.PERCENT = valueFenMu == 0 ? "0" + item.UNIT.Trim() : (Math.Round(valueFenZi * 100 / valueFenMu, 2).ToString() + item.UNIT.Trim());
                        }
                        else if (item.UNIT.Trim() == "‰")//千分比
                        {
                            item.PERCENT = valueFenMu == 0 ? "0" + item.UNIT.Trim() : (Math.Round(valueFenZi * 1000 / valueFenMu, 2).ToString() + item.UNIT.Trim());
                        }
                        else if (item.UNIT.Trim() == "‱")//万分比
                        {
                            item.PERCENT = valueFenMu == 0 ? "0" + item.UNIT.Trim() : (Math.Round(valueFenZi * 10000 / valueFenMu, 2).ToString() + item.UNIT.Trim());
                        }
                        else
                        {
                            if (item.REPORT_NAME == "麻醉科医患比（DB）")
                            {
                                item.PERCENT = valueFenMu == 0 ? "0" : (Math.Round(valueFenZi * 100 / valueFenMu, 2).ToString());
                            }
                            else
                            {
                                item.PERCENT = valueFenMu == 0 ? "0%" : (Math.Round(valueFenZi * 100 / valueFenMu, 2).ToString() + "%");
                            }
                        }
                    }
                    else
                    {
                        if (item.REPORT_NAME == "麻醉科医患比（DB）")
                        {
                            item.PERCENT = valueFenMu == 0 ? "0" : (Math.Round(valueFenZi * 100 / valueFenMu, 2).ToString());
                        }
                        else
                        {
                            item.PERCENT = valueFenMu == 0 ? "0%" : (Math.Round(valueFenZi * 100 / valueFenMu, 2).ToString() + "%");
                        }
                    }
                }
            }
            return itemList;
        }


        /// <summary>
        /// 获取备份数据
        /// </summary>
        /// <param name="reportMonth"></param>
        /// <returns></returns>
        public IList<MED_QC_REPORT_LIST> GetQuanlityControlReportBakItemList(string reportName, string isOutRoomOper)
        {

            IList<MED_QC_REPORT_DATA_BAK> master = GetQuanlityControlReportDataBak(reportName);

            IList<MED_QC_OUT_REPORT_DATA_BAK> masterOut = GetQuanlityControlReportDataBakOut(reportName);

            IList<MED_QC_REPORT_LIST> itemList = GetQuanlityControlReportList();

            IList<MED_QC_REPORT_IND> indList = GetQuanlityControlReportIndByReportName(reportName);

            string reportId = string.Empty;

            if (indList.Count > 0)
            {
                reportId = indList[0].REPORT_ID;
            }

            foreach (var item in itemList)
            {
                decimal valueFenZi = 0;
                decimal valueFenMu = 0;
                item.REPORT_ID = reportId;

                if (!string.IsNullOrEmpty(item.NMRTR_CODE))
                {

                    if (isOutRoomOper == "室内")
                    {
                        MED_QC_REPORT_DATA_BAK dataFind = master.FirstOrDefault<MED_QC_REPORT_DATA_BAK>(t => t.QC_CODE == item.NMRTR_CODE);
                        if (dataFind != null)
                        {
                            valueFenZi = dataFind.QC_VALUE;//分子
                            item.NMRTR_CODE_VALUE = valueFenZi.ToString();
                            item.REPORT_ID = string.IsNullOrEmpty(dataFind.REPORT_ID) ? reportId : dataFind.REPORT_ID;
                            item.DETAILS_COUNT = dataFind.DETAILS_COUNT == null ? 0 : dataFind.DETAILS_COUNT;
                        }
                        else
                        {
                            valueFenZi = 0;
                            item.NMRTR_CODE_VALUE = "0";
                            item.DETAILS_COUNT = 0;
                        }
                    }
                    else if (isOutRoomOper == "室外")
                    {
                        MED_QC_OUT_REPORT_DATA_BAK dataFindOut = masterOut.FirstOrDefault<MED_QC_OUT_REPORT_DATA_BAK>(t => t.QC_CODE == item.NMRTR_CODE);
                        if (dataFindOut != null)
                        {
                            valueFenZi = dataFindOut.QC_VALUE;//分子
                            item.NMRTR_CODE_VALUE = valueFenZi.ToString();
                            item.REPORT_ID = string.IsNullOrEmpty(dataFindOut.REPORT_ID) ? reportId : dataFindOut.REPORT_ID;
                            item.DETAILS_COUNT = dataFindOut.DETAILS_COUNT == null ? 0 : dataFindOut.DETAILS_COUNT;
                        }
                        else
                        {
                            valueFenZi = 0;
                            item.NMRTR_CODE_VALUE = "0";
                            item.DETAILS_COUNT = 0;
                        }
                    }
                    else if (isOutRoomOper == "全部")
                    {
                        MED_QC_REPORT_DATA_BAK dataFind = master.FirstOrDefault<MED_QC_REPORT_DATA_BAK>(t => t.QC_CODE == item.NMRTR_CODE);

                        MED_QC_OUT_REPORT_DATA_BAK dataFindOut = masterOut.FirstOrDefault<MED_QC_OUT_REPORT_DATA_BAK>(t => t.QC_CODE == item.NMRTR_CODE);

                        if (dataFind != null)
                        {
                            valueFenZi = dataFind.QC_VALUE;//分子
                            item.NMRTR_CODE_VALUE = valueFenZi.ToString();
                            item.REPORT_ID = string.IsNullOrEmpty(dataFind.REPORT_ID) ? reportId : dataFind.REPORT_ID;
                            item.DETAILS_COUNT = dataFind.DETAILS_COUNT == null ? 0 : dataFind.DETAILS_COUNT;
                        }
                        else
                        {
                            valueFenZi += 0;
                            item.NMRTR_CODE_VALUE = valueFenZi.ToString();
                            item.DETAILS_COUNT = 0;
                        }



                        if (dataFindOut != null && !item.REPORT_NAME.Contains("麻醉科医患比（GB）"))
                        {
                            valueFenZi += dataFindOut.QC_VALUE;//分子
                            item.NMRTR_CODE_VALUE = valueFenZi.ToString();
                            item.REPORT_ID = string.IsNullOrEmpty(dataFindOut.REPORT_ID) ? reportId : dataFindOut.REPORT_ID;
                            item.DETAILS_COUNT += dataFindOut.DETAILS_COUNT == null ? 0 : dataFindOut.DETAILS_COUNT;
                        }
                        else
                        {
                            valueFenZi += 0;
                            item.NMRTR_CODE_VALUE = valueFenZi.ToString();
                            item.DETAILS_COUNT = 0;
                        }
                    }

                }
                if (!string.IsNullOrEmpty(item.DNMTR_CODE))
                {
                    if (isOutRoomOper == "室内")
                    {
                        MED_QC_REPORT_DATA_BAK dataFind = master.FirstOrDefault<MED_QC_REPORT_DATA_BAK>(t => t.QC_CODE == item.DNMTR_CODE);
                        if (dataFind != null)
                        {
                            valueFenMu = dataFind.QC_VALUE;//分子
                            item.DNMTR_CODE_VALUE = valueFenMu.ToString();
                            item.REPORT_ID = string.IsNullOrEmpty(dataFind.REPORT_ID) ? reportId : dataFind.REPORT_ID;
                        }
                        else
                        {
                            valueFenMu = 0;
                            item.DNMTR_CODE_VALUE = "0";
                        }
                    }
                    else if (isOutRoomOper == "室外")
                    {
                        MED_QC_OUT_REPORT_DATA_BAK dataFindOut = masterOut.FirstOrDefault<MED_QC_OUT_REPORT_DATA_BAK>(t => t.QC_CODE == item.DNMTR_CODE);
                        if (dataFindOut != null)
                        {
                            valueFenMu = dataFindOut.QC_VALUE;//分子
                            item.DNMTR_CODE_VALUE = valueFenMu.ToString();
                            item.REPORT_ID = string.IsNullOrEmpty(dataFindOut.REPORT_ID) ? reportId : dataFindOut.REPORT_ID;
                        }
                        else
                        {
                            valueFenMu = 0;
                            item.DNMTR_CODE_VALUE = "0";
                        }
                    }
                    else if (isOutRoomOper == "全部")
                    {
                        MED_QC_REPORT_DATA_BAK dataFind = master.FirstOrDefault<MED_QC_REPORT_DATA_BAK>(t => t.QC_CODE == item.DNMTR_CODE);

                        MED_QC_OUT_REPORT_DATA_BAK dataFindOut = masterOut.FirstOrDefault<MED_QC_OUT_REPORT_DATA_BAK>(t => t.QC_CODE == item.DNMTR_CODE);

                        if (dataFind != null)
                        {
                            valueFenMu += dataFind.QC_VALUE;//分子
                            item.DNMTR_CODE_VALUE = valueFenMu.ToString();
                            item.REPORT_ID = string.IsNullOrEmpty(dataFind.REPORT_ID) ? reportId : dataFind.REPORT_ID;
                        }
                        else
                        {
                            valueFenMu = 0;
                            item.DNMTR_CODE_VALUE = valueFenMu.ToString();
                        }


                        if (dataFindOut != null)
                        {
                      
                            valueFenMu += dataFindOut.QC_VALUE;//分子
                            item.DNMTR_CODE_VALUE = valueFenMu.ToString();
                            item.REPORT_ID = string.IsNullOrEmpty(dataFindOut.REPORT_ID) ? reportId : dataFindOut.REPORT_ID;
                        }
                        else
                        {
                            valueFenMu = 0;
                            item.DNMTR_CODE_VALUE = valueFenMu.ToString();
                        }

                        if (item.REPORT_NAME.Contains("麻醉科医患比（DB）"))
                        {
                            valueFenMu = valueFenMu / 2;
                            item.DNMTR_CODE_VALUE = valueFenMu.ToString();
                            item.REPORT_ID = (dataFindOut == null || string.IsNullOrEmpty(dataFindOut.REPORT_ID)) ? reportId : dataFindOut.REPORT_ID;
                        }

                    }
                }

                if (item.REPORT_NAME == "各ASA分级麻醉患者比例" || item.REPORT_NAME == "各类麻醉方式比例")
                {

                }
                else
                {
                    if (item.UNIT != null && !string.IsNullOrEmpty(item.UNIT.Trim()))
                    {
                        if (item.UNIT.Trim() == "%")//百分比
                        {
                            item.PERCENT = valueFenMu == 0 ? "0" + item.UNIT.Trim() : (Math.Round(valueFenZi * 100 / valueFenMu, 2).ToString() + item.UNIT.Trim());
                        }
                        else if (item.UNIT.Trim() == "‰")//千分比
                        {
                            item.PERCENT = valueFenMu == 0 ? "0" + item.UNIT.Trim() : (Math.Round(valueFenZi * 1000 / valueFenMu, 2).ToString() + item.UNIT.Trim());
                        }
                        else if (item.UNIT.Trim() == "‱")//万分比
                        {
                            item.PERCENT = valueFenMu == 0 ? "0" + item.UNIT.Trim() : (Math.Round(valueFenZi * 10000 / valueFenMu, 2).ToString() + item.UNIT.Trim());
                        }
                        else
                        {
                            if (item.REPORT_NAME == "麻醉科医患比（DB）")
                            {
                                item.PERCENT = valueFenMu == 0 ? "0" : (Math.Round(valueFenZi * 100 / valueFenMu, 2).ToString());
                            }
                            else
                            {
                                item.PERCENT = valueFenMu == 0 ? "0%" : (Math.Round(valueFenZi * 100 / valueFenMu, 2).ToString() + "%");
                            }
                        }
                    }
                    else
                    {
                        if (item.REPORT_NAME == "麻醉科医患比（DB）")
                        {
                            item.PERCENT = valueFenMu == 0 ? "0" : (Math.Round(valueFenZi * 100 / valueFenMu, 2).ToString());
                        }
                        else
                        {
                            item.PERCENT = valueFenMu == 0 ? "0%" : (Math.Round(valueFenZi * 100 / valueFenMu, 2).ToString() + "%");
                        }
                    }
                }
            }
            return itemList;
        }

        /// <summary>
        /// 是否已经上报质控数据
        /// </summary>
        /// <param name="reportMonth"></param>
        /// <returns></returns>
        public int IsQuanlityControlDataUpload(string reportMonth)
        {
            int type = 0;

            List<MED_QC_REPORT_IND> data = GetQuanlityControlReportInd().FindAll(t => t.REPORT_MONTH == reportMonth && t.STATUS == 1);//STATUS : 1->已上报   ；0->未上报

            if (data.Count > 0)
            {
                type = 1;
            }
            return type;
        }

        /// <summary>
        /// 是否已经上报质控数据
        /// </summary>
        /// <param name="reportName"></param>
        /// <returns></returns>
        public int IsQuanlityControlDataUploadByReportName(string reportName)
        {
            int type = 0;

            List<MED_QC_REPORT_IND> data = GetQuanlityControlReportInd().FindAll(t => t.REPORT_NAME == reportName && t.STATUS == 1);//STATUS : 1->已上报   ；0->未上报

            if (data.Count > 0)
            {
                type = 1;
            }
            return type;
        }



        /// <summary>
        /// 同步数据
        /// </summary>
        /// <param name="reportMonth"></param>
        public string SyncQuanlityControlData(string reportMonth)
        {
            string message = string.Empty;


            try
            {
                //IDbConnection conn = dapper.Connection;
                //IDbCommand cmd = conn.CreateCommand();
                //cmd.CommandText = "SYNCQUANLITYCONTROLDATA2";
                //cmd.CommandType = CommandType.StoredProcedure;

                //IDbDataParameter para = cmd.CreateParameter();
                //para.ParameterName = "REPORTMONTH";
                //para.Value = reportMonth;
                //para.Direction = ParameterDirection.Input;
                //para.Size = 6;
                //para.DbType = DbType.String;
                //cmd.Parameters.Add(para);

                //conn.Open();
                //cmd.ExecuteNonQuery();
                //conn.Close();

                //顺序不能乱，一定是先执行存储过程sp_qc_databak，再执行存储过程sp_qc_report
                List<string> list = new List<string>();
                list.Add("sp_qc_databak");
                list.Add("sp_qc_report");
                list.Add("SP_QC_DATA_OUT");

                foreach (var item in list)
                {
                    IDbConnection conn = dapper.Connection;
                    IDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = item;
                    cmd.CommandType = CommandType.StoredProcedure;

                    IDbDataParameter para = cmd.CreateParameter();
                    para.ParameterName = "v_month";
                    para.Value = reportMonth;
                    para.Direction = ParameterDirection.Input;
                    para.Size = 6;
                    para.DbType = DbType.String;
                    cmd.Parameters.Add(para);

                    if (item.ToUpper() == "SP_QC_DATA_OUT".ToUpper())
                    {
                        string sql = "SELECT * FROM MED_QC_REPORT_IND WHERE REPORT_MONTH='" + reportMonth + "'";

                        MED_QC_REPORT_IND ind = dapper.Set<MED_QC_REPORT_IND>().Query(sql).FirstOrDefault();
                        if (ind != null && !string.IsNullOrEmpty(ind.REPORT_ID))
                        {
                            dapper.Connection.Close();

                            IDbDataParameter para3 = cmd.CreateParameter();
                            para3.ParameterName = "REPORT_ID";
                            para3.Value = ind.REPORT_ID;
                            para3.Direction = ParameterDirection.Input;
                            para3.Size = 40;
                            para3.DbType = DbType.String;
                            cmd.Parameters.Add(para3);
                        }
                        else
                        {
                            continue;
                        }
                    }

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
        /// <summary>
        /// 转存备份数据
        /// </summary>
        /// <param name="log"></param>
        public string AddQuanlityControlReportDataBak(string reportMonth, string name)
        {
            string message = string.Empty;
            try
            {
                IList<MED_QC_REPORT_DATA> master = GetQuanlityControlReportData(reportMonth);//获取质控数据
                List<MED_QC_REPORT_DATA_BAK> masterBak = GetQuanlityControlReportDataBak(name);//获取质控备份数据
                if (masterBak.Count > 0)
                {
                    int result = dapper.Set<MED_QC_REPORT_DATA_BAK>().Delete(masterBak);//删除历史备份数据
                    dapper.SaveChanges();
                }
                List<MED_QC_REPORT_DATA_BAK> itemList = new List<MED_QC_REPORT_DATA_BAK>();
                foreach (var item in master)
                {
                    itemList.Add(new MED_QC_REPORT_DATA_BAK()
                    {
                        REPORT_ID = item.REPORT_ID,
                        QC_CODE = item.QC_CODE,
                        QC_VALUE = item.QC_VALUE
                    });
                    item.REPORT_NAME = name;
                }
                if (itemList.Count > 0)
                {
                    int count = dapper.Set<MED_QC_REPORT_DATA_BAK>().Insert(itemList);//备份质控上报数据
                    dapper.SaveChanges();

                    if (count > 0 && master.Count > 0)
                    {
                        List<MED_QC_REPORT_IND> indList = GetQuanlityControlReportIndByReportId(master[0].REPORT_ID);//保存上报名称
                        if (indList != null)
                        {
                            indList[0].REPORT_NAME = name;
                            dapper.Set<MED_QC_REPORT_IND>().Update(indList);
                            dapper.SaveChanges();
                        }
                        List<MED_QC_AE_BAK> aeBakItemList = new List<MED_QC_AE_BAK>();//不良事件备份数据
                        List<MED_QC_AE_BAK> aeBakList = GetQuanlityControlAeBakData(master[0].REPORT_ID);//获取历史备份数据
                        if (aeBakList.Count > 0)
                        {
                            int result = dapper.Set<MED_QC_AE_BAK>().Delete(aeBakList);//删除历史备份数据
                            dapper.SaveChanges();
                        }
                        List<MED_QC_AE> aeList = GetQuanlityControlAeData(master[0].REPORT_ID);//获取当前不良事件数据
                        foreach (var item in aeList)
                        {
                            aeBakItemList.Add(new MED_QC_AE_BAK()
                            {
                                REPORT_ID = item.REPORT_ID,
                                PATIENT_ID = item.PATIENT_ID,
                                VISIT_ID = item.VISIT_ID,
                                OPER_ID = item.OPER_ID,
                                ITEM_CODE = item.ITEM_CODE,
                                UPLOAD = 1   //  1 :上报  ,  0 :不上报 ,  默认 1
                            });
                        }
                        if (aeList.Count > 0)
                        {
                            int count2 = dapper.Set<MED_QC_AE_BAK>().Insert(aeBakItemList);//备份不良事件数据
                            dapper.SaveChanges();
                        }
                    }
                }

                //室外数据
                AddQuanlityControlReportDataBakOut(reportMonth, name);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }

        /// <summary>
        /// 转存备份数据
        /// </summary>
        /// <param name="log"></param>
        public string AddQuanlityControlReportDataBakOut(string reportMonth, string name)
        {
            string message = string.Empty;
            try
            {
                IList<MED_QC_OUT_REPORT_DATA> master = GetQuanlityControlReportDataOut(reportMonth);//获取质控数据
                List<MED_QC_OUT_REPORT_DATA_BAK> masterBak = GetQuanlityControlReportDataBakOut(name);//获取质控备份数据
                if (masterBak.Count > 0)
                {
                    int result = dapper.Set<MED_QC_OUT_REPORT_DATA_BAK>().Delete(masterBak);//删除历史备份数据
                    dapper.SaveChanges();
                }
                List<MED_QC_OUT_REPORT_DATA_BAK> itemList = new List<MED_QC_OUT_REPORT_DATA_BAK>();
                foreach (var item in master)
                {
                    itemList.Add(new MED_QC_OUT_REPORT_DATA_BAK()
                    {
                        REPORT_ID = item.REPORT_ID,
                        QC_CODE = item.QC_CODE,
                        QC_VALUE = item.QC_VALUE
                    });
                    item.REPORT_NAME = name;
                }
                if (itemList.Count > 0)
                {
                    int count = dapper.Set<MED_QC_OUT_REPORT_DATA_BAK>().Insert(itemList);//备份质控上报数据
                    dapper.SaveChanges();

                    if (count > 0 && master.Count > 0)
                    {

                        List<MED_QC_OUT_AE_BAK> aeBakItemList = new List<MED_QC_OUT_AE_BAK>();//不良事件备份数据
                        List<MED_QC_OUT_AE_BAK> aeBakList = GetQuanlityControlAeBakDataOut(master[0].REPORT_ID);//获取历史备份数据
                        if (aeBakList.Count > 0)
                        {
                            int result = dapper.Set<MED_QC_OUT_AE_BAK>().Delete(aeBakList);//删除历史备份数据
                            dapper.SaveChanges();
                        }
                        List<MED_QC_OUT_AE> aeList = GetQuanlityControlAeDataOut(master[0].REPORT_ID);//获取当前不良事件数据
                        foreach (var item in aeList)
                        {
                            aeBakItemList.Add(new MED_QC_OUT_AE_BAK()
                            {
                                REPORT_ID = item.REPORT_ID,
                                PATIENT_ID = item.PATIENT_ID,
                                VISIT_ID = item.VISIT_ID,
                                OPER_ID = item.OPER_ID,
                                ITEM_CODE = item.ITEM_CODE,
                                UPLOAD = 1   //  1 :上报  ,  0 :不上报 ,  默认 1
                            });
                        }
                        if (aeList.Count > 0)
                        {
                            int count2 = dapper.Set<MED_QC_OUT_AE_BAK>().Insert(aeBakItemList);//备份不良事件数据
                            dapper.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
        /// <summary>
        /// 提交质控报表数据
        /// </summary>
        /// <param name="medQcReportList"></param>
        /// <returns></returns>
        public RequestResult<int> SaveQuanlityControlReportDataBak(IList<MED_QC_REPORT_LIST> medQcReportList, string isOutRoomOper)
        {
            int type = 0;

            RequestResult<int> requestResult = new RequestResult<int>();

            //验证数据
            List<string> errorList = ValidateQuanlityControlReportDataBak(medQcReportList);

            if (errorList.Count > 0)
            {
                requestResult.Data = type;
                requestResult.Message = JsonConvert.SerializeObject(errorList);
                return requestResult;
            }

            IList<MED_QC_REPORT_LIST> itemList = GetQuanlityControlReportList();//界面显示数据样式表

            if (isOutRoomOper == "室内")
            {
                List<MED_QC_REPORT_DATA_BAK> itemBakList = new List<MED_QC_REPORT_DATA_BAK>();

                foreach (var item in itemList)
                {
                    MED_QC_REPORT_DATA_BAK dataFind = itemBakList.FirstOrDefault<MED_QC_REPORT_DATA_BAK>(t => t.QC_CODE == item.NMRTR_CODE);//分子
                    MED_QC_REPORT_LIST findList = medQcReportList.FirstOrDefault<MED_QC_REPORT_LIST>(t => t.REPORT_NO == item.REPORT_NO);//根据样式表的REPORT_NO，找到数据表的行数据
                    if (dataFind != null)
                    {
                        dataFind.QC_CODE = item.NMRTR_CODE;//分子编号
                        dataFind.QC_VALUE = findList != null ? Convert.ToDecimal(findList.NMRTR_CODE_VALUE) : 0;
                    }
                    else
                    {
                        if (item.NMRTR_CODE != null)
                        {
                            itemBakList.Add(new MED_QC_REPORT_DATA_BAK()
                            {
                                REPORT_ID = findList != null ? findList.REPORT_ID : null,
                                QC_CODE = item.NMRTR_CODE,//分子编号
                                QC_VALUE = findList != null ? Convert.ToDecimal(findList.NMRTR_CODE_VALUE) : 0
                            });
                        }
                    }
                    dataFind = itemBakList.FirstOrDefault<MED_QC_REPORT_DATA_BAK>(t => t.QC_CODE == item.DNMTR_CODE);//分母
                    if (dataFind != null)
                    {
                        dataFind.QC_CODE = item.DNMTR_CODE;//分母编号
                        dataFind.QC_VALUE = findList != null ? Convert.ToDecimal(findList.DNMTR_CODE_VALUE) : 0;
                    }
                    else
                    {
                        if (item.DNMTR_CODE != null)
                        {
                            itemBakList.Add(new MED_QC_REPORT_DATA_BAK()
                            {
                                REPORT_ID = findList != null ? findList.REPORT_ID : null,
                                QC_CODE = item.DNMTR_CODE,//分母编号
                                QC_VALUE = findList != null ? Convert.ToDecimal(findList.DNMTR_CODE_VALUE) : 0
                            });
                        }
                    }
                }
                if (itemBakList.Count > 0)
                {
                    type = dapper.Set<MED_QC_REPORT_DATA_BAK>().Update(itemBakList) > 0 ? 1 : 0;
                    dapper.SaveChanges();
                }

                requestResult.Message = "室内数据保存成功";
            }
            else if (isOutRoomOper == "室外")
            {
                List<MED_QC_OUT_REPORT_DATA_BAK> itemBakList = new List<MED_QC_OUT_REPORT_DATA_BAK>();

                foreach (var item in itemList)
                {
                    MED_QC_OUT_REPORT_DATA_BAK dataFind = itemBakList.FirstOrDefault<MED_QC_OUT_REPORT_DATA_BAK>(t => t.QC_CODE == item.NMRTR_CODE);//分子
                    MED_QC_REPORT_LIST findList = medQcReportList.FirstOrDefault<MED_QC_REPORT_LIST>(t => t.REPORT_NO == item.REPORT_NO);//根据样式表的REPORT_NO，找到数据表的行数据
                    if (dataFind != null)
                    {
                        dataFind.QC_CODE = item.NMRTR_CODE;//分子编号
                        dataFind.QC_VALUE = findList != null ? Convert.ToDecimal(findList.NMRTR_CODE_VALUE) : 0;
                    }
                    else
                    {
                        if (item.NMRTR_CODE != null)
                        {
                            itemBakList.Add(new MED_QC_OUT_REPORT_DATA_BAK()
                            {
                                REPORT_ID = findList != null ? findList.REPORT_ID : null,
                                QC_CODE = item.NMRTR_CODE,//分子编号
                                QC_VALUE = findList != null ? Convert.ToDecimal(findList.NMRTR_CODE_VALUE) : 0
                            });
                        }
                    }
                    dataFind = itemBakList.FirstOrDefault<MED_QC_OUT_REPORT_DATA_BAK>(t => t.QC_CODE == item.DNMTR_CODE);//分母
                    if (dataFind != null)
                    {
                        dataFind.QC_CODE = item.DNMTR_CODE;//分母编号
                        dataFind.QC_VALUE = findList != null ? Convert.ToDecimal(findList.DNMTR_CODE_VALUE) : 0;
                    }
                    else
                    {
                        if (item.DNMTR_CODE != null)
                        {
                            itemBakList.Add(new MED_QC_OUT_REPORT_DATA_BAK()
                            {
                                REPORT_ID = findList != null ? findList.REPORT_ID : null,
                                QC_CODE = item.DNMTR_CODE,//分母编号
                                QC_VALUE = findList != null ? Convert.ToDecimal(findList.DNMTR_CODE_VALUE) : 0
                            });
                        }
                    }
                }
                if (itemBakList.Count > 0)
                {
                    type = dapper.Set<MED_QC_OUT_REPORT_DATA_BAK>().Update(itemBakList) > 0 ? 1 : 0;
                    dapper.SaveChanges();
                }

                requestResult.Message = "室外数据保存成功";
            }
            requestResult.Data = type;
            //requestResult.Message = "保存成功";
            return requestResult;

        }



        /// <summary>
        /// 获取备份不良事件数据
        /// </summary>
        /// <param name="reportName"></param>
        /// <returns></returns>
        public List<MED_QC_AE_BAK> GetQuanlityControlAeBakDataByReportName(string reportName)
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlAeBakDataByReportName");
            return dapper.Set<MED_QC_AE_BAK>().Query(sql, new { REPORT_NAME = reportName });
        }
        /// <summary>
        /// 获取备份不良事件患者基本信息数据
        /// </summary>
        /// <param name="reportName"></param>
        /// <returns></returns>
        public List<MED_QC_PATIENT_INFO> GetQuanlityControlAeBakPatientInfoDataByReportName(string reportName)
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlAeBakPatientInfoDataByReportName");
            return dapper.Set<MED_QC_PATIENT_INFO>().Query(sql, new { REPORT_NAME = reportName });
        }

        /// <summary>
        /// 获取备份不良事件患者基本信息数据
        /// </summary>
        /// <param name="reportName"></param>
        /// <returns></returns>
        public List<MED_QC_PATIENT_INFO> GetQuanlityControlAeBakPatientInfoDataByReportNameNoGroupBy(string reportName)
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlAeBakPatientInfoDataByReportNameNoGroupBy");
            return dapper.Set<MED_QC_PATIENT_INFO>().Query(sql, new { REPORT_NAME = reportName });
        }

        /// <summary>
        /// 获取备份不良事件患者基本信息数据
        /// </summary>
        /// <param name="reportName"></param>
        /// <param name="reportNo">MED_QC_REPORT_LIST表 REPORT_NO </param>
        /// <returns></returns>
        public List<MED_QC_PATIENT_INFO> GetQuanlityControlAeBakPatientInfoDataByReportNameAndReportNo(string reportName, string reportNo)
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlAeBakPatientInfoDataByReportNameAndReportNo");
            return dapper.Set<MED_QC_PATIENT_INFO>().Query(sql, new { REPORT_NAME = reportName, REPORT_NO = reportNo });
        }

        /// <summary>
        /// 获取备份不良事件患者基本信息数据
        /// </summary>
        /// <param name="reportName"></param>
        /// <param name="reportNo">MED_QC_REPORT_LIST表 REPORT_NO </param>
        /// <returns></returns>
        public List<MED_QC_PATIENT_INFO> GetQuanlityControlAeBakPatientInfoDataByReportNameAndReportNoOut(string reportName, string reportNo)
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlAeBakPatientInfoDataByReportNameAndReportNoOut");
            return dapper.Set<MED_QC_PATIENT_INFO>().Query(sql, new { REPORT_NAME = reportName, REPORT_NO = reportNo });
        }

        /// <summary>
        /// 保存备份不良事件数据
        /// </summary>
        /// <param name="medQcPatientInfo"></param>
        /// <returns></returns>
        public void SaveQuanlityControlAeBakData(IList<MED_QC_PATIENT_INFO> medQcPatientInfo)
        {
            foreach (var item in medQcPatientInfo)
            {
                if (item.REPORT_ID != null && item.PATIENT_ID != null)
                {
                    List<MED_QC_AE_BAK> itemList = GetQuanlityControlAeBakDataByParams(item.REPORT_ID, item.PATIENT_ID, item.VISIT_ID, item.OPER_ID);

                    foreach (var item2 in itemList)
                    {
                        item2.UPLOAD = item.UPLOAD;
                        item2.ModelStatus = ModelStatus.Modeified;
                    }

                    dapper.Set<MED_QC_AE_BAK>().Update(itemList);
                    dapper.SaveChanges();


                    // 不良事件是否保存更改之后，需要联动MED_QC_REPORT_DATA_BAK备份数据表，修改其上报数量

                    string[] codelist = item.AE_DETAIL_CODE.Split(',');

                    if (codelist.Length > 0)
                    {
                        foreach (var code in codelist)
                        {
                            if (!string.IsNullOrEmpty(code.Trim()))
                            {
                                List<MED_QC_AE_BAK> qcAeBak = GetQuanlityControlAeBakData(item.REPORT_ID).FindAll(t => t.ITEM_CODE == code.Trim() && t.UPLOAD == 1);

                                MED_QC_REPORT_DATA_BAK qcReportDataBak = GetQuanlityControlReportDataBakByReportId(item.REPORT_ID).Find(t => t.QC_CODE == code.Trim());

                                qcReportDataBak.QC_VALUE = qcAeBak.Count;

                                dapper.Set<MED_QC_REPORT_DATA_BAK>().Update(qcReportDataBak);
                            }
                        }

                    }

                    //List<MED_QC_AE_BAK> qcAeBak = GetQuanlityControlAeBakData(item.REPORT_ID).FindAll(t => t.ITEM_CODE == item.AE_DETAIL_CODE && t.UPLOAD == 1);

                    //MED_QC_REPORT_DATA_BAK qcReportDataBak = GetQuanlityControlReportDataBakByReportId(item.REPORT_ID).Find(t => t.QC_CODE == item.AE_DETAIL_CODE);

                    //qcReportDataBak.QC_VALUE = qcAeBak.Count;

                    //dapper.Set<MED_QC_REPORT_DATA_BAK>().Update(qcReportDataBak);

                    dapper.SaveChanges();
                }

            }
        }

        /// <summary>
        /// 上报不良事件
        /// </summary>
        /// <param name="medQcPatientInfo"></param>
        public int UploadQuanlityControlAeBakData(string reportId, string patientId, int visitId, int operId, string reportNo, int upload)
        {
            int type = 0;
            if (!string.IsNullOrEmpty(reportId) && !string.IsNullOrEmpty(patientId))
            {
                List<MED_QC_AE_BAK> itemList = GetQuanlityControlAeBakDataByParamsByReportNo(reportId, patientId, visitId, operId, reportNo);

                List<MED_QC_REPORT_DATA_BAK> reportDataBakList = GetQuanlityControlReportDataBakByReportId(reportId);

                foreach (var item in itemList)
                {
                    if (item != null)
                    {
                        item.UPLOAD = upload;
                        item.ModelStatus = ModelStatus.Modeified;

                        MED_QC_REPORT_DATA_BAK find = reportDataBakList.Find(t => t.QC_CODE == item.ITEM_CODE);

                        if (find != null)
                        {
                            if (upload == 1)
                            {
                                find.QC_VALUE = find.QC_VALUE + 1;
                            }
                            else if (upload == 0)
                            {
                                if (find.QC_VALUE > 0)
                                {
                                    find.QC_VALUE = find.QC_VALUE - 1;
                                }
                            }
                        }
                    }
                }

                type = dapper.Set<MED_QC_AE_BAK>().Update(itemList) > 0 ? 1 : 0;

                if (type == 1)
                {
                    int a = dapper.Set<MED_QC_REPORT_DATA_BAK>().Update(reportDataBakList) > 0 ? 1 : 0;
                }

                dapper.SaveChanges();


            }
            return type;
        }

        /// <summary>
        /// 获取主索引报表数据
        /// </summary>
        /// <returns></returns>
        public List<MED_QC_REPORT_IND> GetQuanlityControlReportInd()
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlReportInd");
            return dapper.Set<MED_QC_REPORT_IND>().Query(sql);
        }

        /// <summary>
        /// 获取主索引报表数据
        /// </summary>
        /// <returns></returns>
        public List<MED_QC_REPORT_IND> GetQuanlityControlReportIndByReportName(string reportName)
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlReportIndByReportName");
            return dapper.Set<MED_QC_REPORT_IND>().Query(sql, new { REPORT_NAME = reportName });
        }




        /// <summary>
        /// 获取主索引报表数据
        /// </summary>
        /// <returns></returns>
        public List<MED_QC_REPORT_IND> GetQuanlityControlReportInd2()
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlReportInd2");
            return dapper.Set<MED_QC_REPORT_IND>().Query(sql);
        }

        /// <summary>
        /// 保存备份不良事件数据
        /// </summary>
        /// <param name="reportId"></param>
        /// <param name="status"></param>
        /// <param name="LoginUserId"></param>
        /// <returns></returns>
        public RequestResult<int> SaveQuanlityControlReportInd(string reportId, int status, string LoginUserId)
        {
            int type = 0;
            List<MED_QC_REPORT_IND> indList = GetQuanlityControlReportIndByReportId(reportId);


            IList<MED_QC_REPORT_LIST> medQcReportList = GetQuanlityControlReportItemListByReportId(reportId);

            //验证数据
            List<string> errorList = ValidateQuanlityControlReportDataBak(medQcReportList);


            RequestResult<int> requestResult = new RequestResult<int>();

            if (errorList.Count > 0)
            {
                requestResult.Data = type;
                requestResult.Message = JsonConvert.SerializeObject(errorList);
                return requestResult;
            }


            if (indList != null)
            {
                foreach (var item in indList)
                {
                    if (item.STATUS != status)
                    {
                        item.STATUS = status;
                        item.REPORT_DATE = DateTime.Now;
                        item.OPERATOR = LoginUserId;
                        item.ModelStatus = ModelStatus.Modeified;
                    }
                }
                type = dapper.Set<MED_QC_REPORT_IND>().Update(indList) > 0 ? 1 : 0;
                dapper.SaveChanges();

                requestResult.Data = type;
            }

            return requestResult;
        }

        /// <summary>
        /// 获取患者基本信息数据
        /// </summary>
        /// <param name="inpNo"></param>
        /// <returns></returns>
        public List<MED_QC_PATIENT_INFO> GetQCPatientBaseInfo(string inpNo)
        {
            string sql = sqlDict.GetSQLByKey("GetQCPatientBaseInfo");
            return dapper.Set<MED_QC_PATIENT_INFO>().Query(sql, new { INP_NO = inpNo });
        }

        /// <summary>
        /// 获取患者基本信息数据
        /// </summary>
        /// <param name="inpNo"></param>
        /// <returns></returns>
        public List<MED_QC_PATIENT_INFO> GetQCPatientBaseInfo2(string patientId, decimal visitId, decimal operId)
        {
            string sql = sqlDict.GetSQLByKey("GetQCPatientBaseInfo2");
            return dapper.Set<MED_QC_PATIENT_INFO>().Query(sql, new { PATIENT_ID = patientId, VISIT_ID = visitId, OPER_ID = operId });
        }

        /// <summary>
        /// 获取患者基本信息数据
        /// </summary>
        /// <param name="inpNo"></param>
        /// <returns></returns>
        public List<MED_QC_OUT_PAT_INFO> GetQCPatientBaseInfoOut(string inpNo)
        {
            string sql = sqlDict.GetSQLByKey("GetOutPatInfoByInpNo");
            return dapper.Set<MED_QC_OUT_PAT_INFO>().Query(sql, new { INP_NO = inpNo });
        }

        /// <summary>
        /// 获取患者基本信息数据
        /// </summary>
        /// <param name="inpNo"></param>
        /// <returns></returns>
        public List<MED_QC_OUT_PAT_INFO> GetQCPatientBaseInfoOut2(string patientId, decimal visitId, decimal operId)
        {
            string sql = sqlDict.GetSQLByKey("GetOutPatInfoByInpNo2");
            return dapper.Set<MED_QC_OUT_PAT_INFO>().Query(sql, new { PATIENT_ID = patientId, VISIT_ID = visitId, OPER_ID = operId });
        }

        /// <summary>
        /// 获取质控数据表数据
        /// </summary>
        /// <param name="patientId">  </param>
        /// <param name="visitId">  </param>
        /// <param name="operId">  </param>
        /// <returns></returns>
        public List<MED_ANESTHESIA_INPUT_DATA> GetMedAnesthesiaInputData(string patientId, int visitId, int operId)
        {
            string sql = sqlDict.GetSQLByKey("GetMedAnesthesiaInputData");

            List<MED_ANESTHESIA_INPUT_DATA> inputDataList = dapper.Set<MED_ANESTHESIA_INPUT_DATA>().Query(sql, new { PATIENT_ID = patientId, VISIT_ID = visitId, OPER_ID = operId });

            if (inputDataList.Count == 0)
            {
                MED_ANESTHESIA_INPUT_DATA inputData = new MED_ANESTHESIA_INPUT_DATA()
                {
                    PATIENT_ID = patientId,
                    VISIT_ID = visitId,
                    OPER_ID = operId
                };

                inputDataList.Add(inputData);
            }

            return inputDataList;
        }

        /// <summary>
        /// 获取质控数据表数据
        /// </summary>
        /// <param name="patientId">  </param>
        /// <param name="visitId">  </param>
        /// <param name="operId">  </param>
        /// <returns></returns>
        public List<MED_ANESTHESIA_INPUT_DATA_OUT> GetMedAnesthesiaInputDataOut(string patientId, int visitId, int operId)
        {
            string sql = sqlDict.GetSQLByKey("GetMedAnesthesiaInputDataOut");

            List<MED_ANESTHESIA_INPUT_DATA_OUT> inputDataList = dapper.Set<MED_ANESTHESIA_INPUT_DATA_OUT>().Query(sql, new { PATIENT_ID = patientId, VISIT_ID = visitId, OPER_ID = operId });

            if (inputDataList.Count == 0)
            {
                MED_ANESTHESIA_INPUT_DATA_OUT inputData = new MED_ANESTHESIA_INPUT_DATA_OUT()
                {
                    PATIENT_ID = patientId,
                    VISIT_ID = visitId,
                    OPER_ID = operId
                };

                inputDataList.Add(inputData);
            }

            return inputDataList;
        }

        /// <summary>
        /// 保存质控数据表数据
        /// </summary>
        /// <param name="medAnesthesiaInputData"></param>
        /// <returns></returns>
        public int SaveMedAnesthesiaInputData(MED_ANESTHESIA_INPUT_DATA medAnesthesiaInputData)
        {
            int type = 0;
            if (medAnesthesiaInputData != null)
            {
                string sql = sqlDict.GetSQLByKey("GetMedAnesthesiaInputData");

                List<MED_ANESTHESIA_INPUT_DATA> dataList = dapper.Set<MED_ANESTHESIA_INPUT_DATA>().Query(sql, new { PATIENT_ID = medAnesthesiaInputData.PATIENT_ID, VISIT_ID = medAnesthesiaInputData.VISIT_ID, OPER_ID = medAnesthesiaInputData.OPER_ID });

                if (dataList.Count == 0)
                {
                    medAnesthesiaInputData.ModelStatus = ModelStatus.Add;

                    type = dapper.Set<MED_ANESTHESIA_INPUT_DATA>().Insert(medAnesthesiaInputData) ? 1 : 0;
                }
                else
                {
                    medAnesthesiaInputData.ModelStatus = ModelStatus.Modeified;
                    type = dapper.Set<MED_ANESTHESIA_INPUT_DATA>().Update(medAnesthesiaInputData) > 0 ? 1 : 0;
                }
                dapper.SaveChanges();

            }

            return type;
        }


        /// <summary>
        /// 保存质控数据表数据
        /// </summary>
        /// <param name="medAnesthesiaInputData"></param>
        /// <returns></returns>
        public int SaveOutMedAnesthesiaInputData(MED_QC_OUT_PAT_INFO outPatInfo, MED_ANESTHESIA_INPUT_DATA_OUT outMedAnesthesiaInputData)
        {
            int type = 0;

            if (outPatInfo != null)
            {

                if (outPatInfo.PATIENT_ID == "")
                {
                    string sqlMaxOperId = sqlDict.GetSQLByKey("GetOutPatInfoMaxOperId");

                    dynamic maxOperIdList = dapper.Query(sqlMaxOperId, new
                    {
                        INP_NO = outPatInfo.INP_NO
                    });

                    int maxOperId = 0;

                    if (maxOperIdList != null && maxOperIdList.Count > 0)
                    {
                        maxOperId = Convert.ToInt32(maxOperIdList[0].OPER_ID);
                    }

                    outPatInfo.PATIENT_ID = outPatInfo.INP_NO;
                    outPatInfo.VISIT_ID = 0;


                    outPatInfo.OPER_ID = maxOperId + 1;

                    outMedAnesthesiaInputData.PATIENT_ID = outPatInfo.PATIENT_ID;
                    outMedAnesthesiaInputData.VISIT_ID = outPatInfo.VISIT_ID;
                    outMedAnesthesiaInputData.OPER_ID = outPatInfo.OPER_ID;
                }

                string sql = sqlDict.GetSQLByKey("GetOutPatInfo");

                List<MED_QC_OUT_PAT_INFO> dataList = dapper.Set<MED_QC_OUT_PAT_INFO>().Query(sql, new { INP_NO = outPatInfo.INP_NO, PATIENT_ID = outPatInfo.PATIENT_ID, VISIT_ID = outPatInfo.VISIT_ID, OPER_ID = outPatInfo.OPER_ID });

                if (dataList.Count == 0)
                {
                    outPatInfo.ModelStatus = ModelStatus.Add;

                    type = dapper.Set<MED_QC_OUT_PAT_INFO>().Insert(outPatInfo) ? 1 : 0;
                }
                else
                {
                    outMedAnesthesiaInputData.ModelStatus = ModelStatus.Modeified;
                    type = dapper.Set<MED_QC_OUT_PAT_INFO>().Update(outPatInfo) > 0 ? 1 : 0;
                }
            }


            if (outMedAnesthesiaInputData != null)
            {
                string sql = sqlDict.GetSQLByKey("GetMedAnesthesiaInputDataOut");

                List<MED_ANESTHESIA_INPUT_DATA_OUT> dataList = dapper.Set<MED_ANESTHESIA_INPUT_DATA_OUT>().Query(sql, new { PATIENT_ID = outMedAnesthesiaInputData.PATIENT_ID, VISIT_ID = outMedAnesthesiaInputData.VISIT_ID, OPER_ID = outMedAnesthesiaInputData.OPER_ID });

                if (dataList.Count == 0)
                {
                    outMedAnesthesiaInputData.ModelStatus = ModelStatus.Add;

                    type = dapper.Set<MED_ANESTHESIA_INPUT_DATA_OUT>().Insert(outMedAnesthesiaInputData) ? 1 : 0;
                }
                else
                {
                    outMedAnesthesiaInputData.ModelStatus = ModelStatus.Modeified;
                    type = dapper.Set<MED_ANESTHESIA_INPUT_DATA_OUT>().Update(outMedAnesthesiaInputData) > 0 ? 1 : 0;
                }
            }

            dapper.SaveChanges();


            return type;
        }


        #region 质控项目字典数据 增删改
        /// <summary>
        /// 获取质控项目字典数据
        /// </summary>
        /// <returns></returns>
        public IList<MED_QC_ITEM> GetQuanlityControlItemList()
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlItemList");
            return dapper.Set<MED_QC_ITEM>().Query(sql);
        }


        /// <summary>
        /// 质控项目字典数据编辑
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="medQcItemt"></param>
        /// <returns>0:失败 1：成功 2:校验主键已存在</returns>
        public int EditQuanlityControlItem(int type, MED_QC_ITEM medQcItemt)
        {
            int result = 0;
            if (type == 0)
            {
                if (dapper.Set<MED_QC_ITEM>().Single(d => d.QC_CODE == medQcItemt.QC_CODE) != null)
                {
                    result = 2;
                }
                else
                {
                    result = dapper.Set<MED_QC_ITEM>().Insert(medQcItemt) ? 1 : 0;
                }
            }
            else
            {
                result = dapper.Set<MED_QC_ITEM>().Update(medQcItemt) > 0 ? 1 : 0;
            }
            dapper.SaveChanges();

            return result;
        }

        /// <summary>
        /// 删除质控项目字典数据
        /// </summary>
        /// <param name="medQcItemList">项目列表</param>
        /// <returns></returns>
        public int DeletedQuanlityControlItemList(List<MED_QC_ITEM> medQcItemList)
        {
            int result = dapper.Set<MED_QC_ITEM>().Delete(medQcItemList);
            dapper.SaveChanges();
            return result;
        }

        #endregion

        #region 报表样式数据 增删改

        /// <summary>
        /// 获取报表样式
        /// </summary>
        /// <param name="reportMonth"></param>
        /// <returns></returns>
        public IList<MED_QC_REPORT_LIST> GetQuanlityControlReportList()
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlReportList");
            return dapper.Set<MED_QC_REPORT_LIST>().Query(sql);
        }

        /// <summary>
        /// 质控项目报表样式编辑
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="medQcReportList"></param>
        /// <returns>0:失败 1：成功 2:校验主键已存在</returns>
        public int EditQuanlityControlReportList(int type, MED_QC_REPORT_LIST medQcReportList)
        {
            int result = 0;
            if (type == 0)
            {
                if (dapper.Set<MED_QC_REPORT_LIST>().Single(d => d.REPORT_NO == medQcReportList.REPORT_NO) != null)
                {
                    result = 2;
                }
                else
                {
                    result = dapper.Set<MED_QC_REPORT_LIST>().Insert(medQcReportList) ? 1 : 0;
                }
            }
            else
            {
                result = dapper.Set<MED_QC_REPORT_LIST>().Update(medQcReportList) > 0 ? 1 : 0;
            }
            dapper.SaveChanges();

            return result;
        }

        /// <summary>
        /// 删除质控项目样式数据
        /// </summary>
        /// <param name="medQcItemList">项目列表</param>
        /// <returns></returns>
        public int DeletedQuanlityControlReportList(List<MED_QC_REPORT_LIST> medQcItemList)
        {
            int result = dapper.Set<MED_QC_REPORT_LIST>().Delete(medQcItemList);
            dapper.SaveChanges();
            return result;
        }

        #endregion

        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="reportMonth">月份</param>
        /// <param name="reportName">模块名字</param>
        /// <param name="exprotExcelColumns">导出的列</param>
        /// <returns></returns>
        public string ExportExcel(object reportMonth, string reportName, dynamic exprotExcelColumns, string isOutRoomOper)
        {
            try
            {
                string directoryName = string.Concat(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "TempExprotExcel\\");
                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }

                DataTable dt = GetExportExcelData(reportMonth, reportName, isOutRoomOper);//获取导出数据
                DateTime repMonth = DateTime.MinValue;
                DateTime.TryParse(reportMonth.ToString(), out repMonth);
                string FileName = (repMonth != DateTime.MinValue ? Convert.ToDateTime(repMonth).ToString("yyyyMM") : reportMonth.ToString()) + ".xlsx";
                string FilePath = string.Concat(directoryName, FileName);
                ExcelFileHelper.ExportExcelWithAspose(dt, JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(exprotExcelColumns)), FilePath);
                return FileName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region 质控管理私有方法

        /// <summary>
        /// 获取质控报表数据--室外
        /// </summary>
        /// <param name="reportMonth"></param>
        /// <returns></returns>
        private IList<MED_QC_OUT_REPORT_DATA> GetQuanlityControlReportDataOut(string reportMonth)
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlReportDataOut");
            return dapper.Set<MED_QC_OUT_REPORT_DATA>().Query(sql, new { REPORTMONTH = reportMonth });
        }


        /// <summary>
        /// 获取质控备份数据--室外
        /// </summary>
        /// <param name="reportMonth"></param>
        /// <returns></returns>
        public List<MED_QC_OUT_REPORT_DATA_BAK> GetQuanlityControlReportDataBakOut(string reportName)
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlReportDataBakOut");
            return dapper.Set<MED_QC_OUT_REPORT_DATA_BAK>().Query(sql, new { REPORT_NAME = reportName });
        }


        /// <summary>
        /// 获取备份不良事件数据--室外
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        private List<MED_QC_OUT_AE_BAK> GetQuanlityControlAeBakDataOut(string reportId)
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlAeBakDataOut");
            return dapper.Set<MED_QC_OUT_AE_BAK>().Query(sql, new { REPORT_ID = reportId });
        }

        /// <summary>
        /// 获取不良事件数据--室外
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        private List<MED_QC_OUT_AE> GetQuanlityControlAeDataOut(string reportId)
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlAeDataOut");
            return dapper.Set<MED_QC_OUT_AE>().Query(sql, new { REPORT_ID = reportId });
        }

        /// <summary>
        /// 获取质控报表数据
        /// </summary>
        /// <param name="reportMonth"></param>
        /// <returns></returns>
        private IList<MED_QC_REPORT_DATA> GetQuanlityControlReportData(string reportMonth)
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlReportData");
            return dapper.Set<MED_QC_REPORT_DATA>().Query(sql, new { REPORTMONTH = reportMonth });
        }
        /// <summary>
        /// 获取质控备份数据
        /// </summary>
        /// <param name="reportMonth"></param>
        /// <returns></returns>
        public List<MED_QC_REPORT_DATA_BAK> GetQuanlityControlReportDataBak(string reportName)
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlReportDataBak");
            return dapper.Set<MED_QC_REPORT_DATA_BAK>().Query(sql, new { REPORT_NAME = reportName });
        }

        public List<MED_QC_REPORT_DATA_BAK> GetQuanlityControlReportDataBakAll(string reportName)
        {
            List<MED_QC_REPORT_DATA_BAK> bakList = GetQuanlityControlReportDataBak(reportName);

            IList<MED_QC_REPORT_LIST> reportList = GetQuanlityControlReportBakItemList(reportName, "全部");

            foreach (var item in bakList)
            {
                var findFenZi = reportList.ToList().FindAll(t => t.NMRTR_CODE == item.QC_CODE);// 分子

                var findFenMu = reportList.ToList().FindAll(t => t.DNMTR_CODE == item.QC_CODE);// 分母

                decimal outValue = 0;

                if (findFenZi != null && findFenZi.Count > 0)//先从分子取 ，取不到再从分母取
                {
                    decimal.TryParse( findFenZi[0].NMRTR_CODE_VALUE,out outValue);
                }
                else
                {
                    if (findFenMu != null && findFenMu.Count > 0)
                    {
                        decimal.TryParse(findFenMu[0].DNMTR_CODE_VALUE, out outValue);
                    }
                }

                item.QC_VALUE = outValue;
            }

            return bakList;
        }

        private List<MED_QC_REPORT_DATA_BAK> GetQuanlityControlReportDataBakByReportId(string reportId)
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlReportDataBakByReportId");
            return dapper.Set<MED_QC_REPORT_DATA_BAK>().Query(sql, new { REPORT_ID = reportId });
        }

        /// <summary>
        /// 获取主索引数据
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        public List<MED_QC_REPORT_IND> GetQuanlityControlReportIndByReportId(string reportId)
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlReportIndByReportId");
            return dapper.Set<MED_QC_REPORT_IND>().Query(sql, new { REPORT_ID = reportId });
        }
        /// <summary>
        /// 获取不良事件数据
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        private List<MED_QC_AE> GetQuanlityControlAeData(string reportId)
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlAeData");
            return dapper.Set<MED_QC_AE>().Query(sql, new { REPORT_ID = reportId });
        }
        /// <summary>
        /// 获取备份不良事件数据
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        private List<MED_QC_AE_BAK> GetQuanlityControlAeBakData(string reportId)
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlAeBakData");
            return dapper.Set<MED_QC_AE_BAK>().Query(sql, new { REPORT_ID = reportId });
        }


        /// <summary>
        /// 获取备份不良事件数据
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        private List<MED_QC_AE_BAK> GetQuanlityControlAeBakDataByParams(string reportId, string patientId, decimal visitId, decimal operId)
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlAeBakDataByParams");
            return dapper.Set<MED_QC_AE_BAK>().Query(sql, new { REPORT_ID = reportId, PATIENT_ID = patientId, VISIT_ID = visitId, OPER_ID = operId });
        }

        private List<MED_QC_AE_BAK> GetQuanlityControlAeBakDataByParamsByReportNo(string reportId, string patientId, decimal visitId, decimal operId, string reportNo)
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlAeBakDataByParamsByReportNo");
            return dapper.Set<MED_QC_AE_BAK>().Query(sql, new { REPORT_ID = reportId, PATIENT_ID = patientId, VISIT_ID = visitId, OPER_ID = operId });
        }

        private DataTable GetExportExcelData(object reportMonth, string reportName, string isOutRoomOper)
        {
            DataTable dt = null;
            if (reportName == "QuanlityData")
            {
                IList<MED_QC_REPORT_LIST> list = GetQuanlityControlReportItemList(Convert.ToDateTime(reportMonth).ToString("yyyyMM"));

                foreach (var item in list)
                {
                    if (item.FATHER_CHILD == 0)
                    {
                        item.GROUP_NO = null;
                    }
                }

                dt = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(list));
            }
            else if (reportName == "UpLoadQuanlityDataModify")
            {
                IList<MED_QC_REPORT_LIST> list = GetQuanlityControlReportBakItemList(reportMonth.ToString(), isOutRoomOper);

                foreach (var item in list)
                {
                    if (item.FATHER_CHILD == 0)
                    {
                        item.GROUP_NO = null;
                    }
                }

                dt = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(list));
            }
            else if (reportName == "AdverseEventModify")
            {
                IList<MED_QC_PATIENT_INFO> list = GetQuanlityControlAeBakPatientInfoDataByReportName((string)reportMonth).FindAll(t => t.UPLOAD == 1);

                dt = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(list));
            }
            return dt;
        }


        #endregion

        /// <summary>
        /// 质控报表数据验证
        /// </summary>
        /// <param name="medQcReportList"></param>
        /// <returns></returns>
        public List<string> ValidateQuanlityControlReportDataBak(IList<MED_QC_REPORT_LIST> medQcReportList)
        {
            List<string> errorList = new List<string>();

            IEnumerable<IGrouping<decimal?, MED_QC_REPORT_LIST>> groupList = medQcReportList.GroupBy(s => s.GROUP_NO);

            foreach (IGrouping<decimal?, MED_QC_REPORT_LIST> groupItem in groupList)
            {
                List<MED_QC_REPORT_LIST> itemList = groupItem.ToList<MED_QC_REPORT_LIST>();

                if (itemList.Count > 1)
                {
                    double fenziSum = 0, fenmuSum = 0;
                    string reportName = string.Empty;

                    foreach (MED_QC_REPORT_LIST item in itemList)
                    {
                        double fenzi = 0, fenmu = 0;
                        double.TryParse(item.NMRTR_CODE_VALUE, out fenzi);//分子

                        double.TryParse(item.DNMTR_CODE_VALUE, out fenmu);//分母

                        if (string.IsNullOrEmpty(reportName) && !string.IsNullOrEmpty(item.REPORT_NAME))
                        {
                            reportName = item.REPORT_NAME;
                        }

                        //先判断分子是否小于等于分母
                        if (item.REPORT_NAME.Contains("麻醉科医患比"))
                        {
                            //if (fenmu > 0 && fenmu < 1)
                            //{
                            //    fenmu = fenmu * 10000;//万例
                            //}
                        }
                        else
                        {

                            if (fenzi > fenmu)
                            {
                                errorList.Add(item.REPORT_NAME + ":分子大于分母");
                            }
                            else
                            {
                                fenziSum += fenzi;
                                fenmuSum = fenmu;
                            }
                        }
                    }

                    if (fenziSum > fenmuSum)
                    {
                        errorList.Add(reportName + ":组内各分子之和大于分母");
                    }
                    else if (fenziSum < fenmuSum)
                    {
                        errorList.Add(reportName + ":组内各分子之和小于分母");
                    }
                }
                else
                {
                    foreach (MED_QC_REPORT_LIST item in itemList)
                    {
                        double fenzi = 0, fenmu = 0;
                        double.TryParse(item.NMRTR_CODE_VALUE, out fenzi);//分子

                        double.TryParse(item.DNMTR_CODE_VALUE, out fenmu);//分母


                        //先判断分子是否小于等于分母
                        if (item.REPORT_NAME.Contains("麻醉科医患比"))
                        {
                            //if (fenmu > 0 && fenmu < 1)
                            //{
                            //    fenmu = fenmu * 10000;//万例
                            //}
                        }
                        else
                        {

                            if (fenzi > fenmu)
                            {
                                errorList.Add(item.REPORT_NAME + ":分子大于分母");
                            }
                        }
                    }

                }

            }

            return errorList;
        }


    }
}
