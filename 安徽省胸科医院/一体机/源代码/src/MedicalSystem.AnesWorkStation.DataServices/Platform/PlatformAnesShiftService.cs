using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
//using MedicalSystem.AnesWorkStation.Domain.AnesQuery;
using MedicalSystem.AnesWorkStation.Domain.Origins;
using MedicalSystem.AnesWorkStation.Domain.ViewModule;
using MedicalSystem.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.AccessControl;
using System.Runtime.InteropServices;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 护理管理接口
    /// </summary>
    public interface IPlatformAnesShiftService
    {
        /// <summary>
        /// 麻醉患者手术信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<dynamic> GetAnesShiftOperInfoList(OperQueryParaModel model);

        /// <summary>
        /// 麻醉交班记录查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<MED_ANES_SHIFT_MASTER> GetAnesShiftInfoList(OperQueryParaModel model);

        /// <summary>
        /// 麻醉交班毒麻药查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<MED_ANES_SHIFT_DRUGS> GetAnesShiftDrugInfoList(OperQueryParaModel model);

        /// <summary>
        /// 麻醉交班患者信息查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<MED_ANES_SHIFT_PATIENTINFO> GetAnesShiftPatientInfoList(OperQueryParaModel model);

        /// <summary>
        /// 保存麻醉交班数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int SaveAnesShiftMasterInfoList(MED_ANES_SHIFT_MASTER data);

        /// <summary>
        /// 保存麻醉交班毒麻药数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int SaveAnesShiftDrugInfoList(List<MED_ANES_SHIFT_DRUGS> data);

        /// <summary>
        /// 保存急救插管信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int SaveAnesShiftPatientInfoList(List<MED_ANES_SHIFT_PATIENTINFO> data);
    }

    /// <summary>
    /// 护理管理接口
    /// </summary>
    public class PlatformAnesShiftService : BaseService<PlatformAnesShiftService>, IPlatformAnesShiftService
    {
        IPlatformSysConfigServices sysConfigService;
        protected PlatformAnesShiftService()
            : base() { }
        public PlatformAnesShiftService(IDapperContext context, IPlatformSysConfigServices sysConfigServicesParam)
            : base(context)
        {
            sysConfigService = sysConfigServicesParam;
        }

        /// <summary>
        /// 麻醉患者手术信息
        /// </summary>
        /// <param name="model">查询条件</param>
        /// <returns></returns>
        public List<dynamic> GetAnesShiftOperInfoList(OperQueryParaModel model)
        {
            string sql = sqlDict.GetSQLByKey("GetAnesShiftOperInfoList");

            DateTime? startTime = null;
            DateTime? endTime = null;

            if (!string.IsNullOrWhiteSpace(model.SHIFT_DATE))
            {
                if (model.SHIFT_TYUPE == "1")// 白班
                {
                    startTime = Convert.ToDateTime(model.SHIFT_DATE).Date.AddHours(8);
                    endTime = Convert.ToDateTime(model.SHIFT_DATE).Date.AddHours(18);
                }
                else if (model.SHIFT_TYUPE == "0")// 夜班
                {
                    startTime = Convert.ToDateTime(model.SHIFT_DATE).Date.AddHours(18);
                    endTime = Convert.ToDateTime(model.SHIFT_DATE).Date.AddDays(1).AddHours(8);
                }
            }

            List<dynamic> list = dapper.Set<dynamic>().Query(sql, new
            {
                StartDate = startTime,
                EndDate = endTime,
            });

            return list;
        }

        /// <summary>
        /// 麻醉交班记录查询
        /// </summary>
        /// <param name="model">查询条件</param>
        /// <returns></returns>
        public List<MED_ANES_SHIFT_MASTER> GetAnesShiftInfoList(OperQueryParaModel model)
        {
            string sql = sqlDict.GetSQLByKey("GetAnesShiftInfoList");

            DateTime? startTime = null;
            DateTime? endTime = null;

            if (!string.IsNullOrWhiteSpace(model.StartDate))
            {
                startTime = Convert.ToDateTime(model.StartDate).Date;
                endTime = Convert.ToDateTime(model.EndDate).Date.AddDays(1);

                if (endTime > DateTime.Now.Date.AddDays(1))
                {
                    endTime = DateTime.Now.Date.AddDays(1);
                }
            }


            TimeSpan? ts = endTime - startTime;

            double days = ts.Value.TotalDays;

            for (int i = 0; i < days; i++)
            {
                var sTime = Convert.ToDateTime(model.StartDate).Date.AddDays(i);
                var eTime = Convert.ToDateTime(model.StartDate).Date.AddDays(1).AddDays(i);

                List<MED_ANES_SHIFT_MASTER> listFind = dapper.Set<MED_ANES_SHIFT_MASTER>().Query(sql, new
                {
                    StartDate = sTime,
                    EndDate = eTime,
                });

                if (listFind == null || listFind.Count == 0)
                {
                    if (listFind == null)
                    {
                        listFind = new List<MED_ANES_SHIFT_MASTER>();
                    }

                    listFind.Add(new MED_ANES_SHIFT_MASTER
                    {
                        SHIFT_DATE = sTime,
                        SHIFT_TYUPE = 1//白班
                    });

                    listFind.Add(new MED_ANES_SHIFT_MASTER
                    {
                        SHIFT_DATE = sTime,
                        SHIFT_TYUPE = 0//夜班
                    });

                    dapper.Set<MED_ANES_SHIFT_MASTER>().Insert(listFind);

                }
            }

            dapper.SaveChanges();

            List<MED_ANES_SHIFT_MASTER> list = dapper.Set<MED_ANES_SHIFT_MASTER>().Query(sql, new
            {
                StartDate = startTime,
                EndDate = endTime,
            });

            foreach (var item in list)
            {

                if (item.ANES_DOCTOR_PIC != null && item.ANES_DOCTOR_PIC.Length > 0)
                {
                    item.ANES_DOCTOR_PIC_STR = Arr2Str(item.ANES_DOCTOR_PIC);
                }

                if (item.SHIFT_DOCTOR_PIC != null && item.SHIFT_DOCTOR_PIC.Length > 0)
                {
                    item.SHIFT_DOCTOR_PIC_STR = Arr2Str(item.SHIFT_DOCTOR_PIC);
                }

                if (item.ANES_DOCTOR1_PIC != null && item.ANES_DOCTOR1_PIC.Length > 0)
                {
                    item.ANES_DOCTOR1_PIC_STR = Arr2Str(item.ANES_DOCTOR1_PIC);
                }

                if (item.SHIFT_DOCTOR1_PIC != null && item.SHIFT_DOCTOR1_PIC.Length > 0)
                {
                    item.SHIFT_DOCTOR1_PIC_STR = Arr2Str(item.SHIFT_DOCTOR1_PIC);
                }
            }

            return list;
        }

        /// <summary>
        /// 麻醉交班毒麻药查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<MED_ANES_SHIFT_DRUGS> GetAnesShiftDrugInfoList(OperQueryParaModel model)
        {
            string sql = sqlDict.GetSQLByKey("GetAnesShiftDrugInfoList");

            DateTime? startTime = null;

            int? shift_Type = 0;

            if (!string.IsNullOrWhiteSpace(model.SHIFT_DATE))
            {
                startTime = Convert.ToDateTime(model.SHIFT_DATE).Date;
            }

            if (!string.IsNullOrWhiteSpace(model.SHIFT_TYUPE))
            {
                shift_Type = Convert.ToInt32(model.SHIFT_TYUPE);
            }

            List<MED_ANES_SHIFT_DRUGS> list = dapper.Set<MED_ANES_SHIFT_DRUGS>().Query(sql, new
            {
                SHIFT_DATE = startTime,
                SHIFT_TYUPE = shift_Type
            });

            //List<string> drugList = model.DRUG_LIST;//毒麻药列表

            List<string> drugList = new List<string>();

            MED_CONFIGSET config = sysConfigService.GetMedConfigSet();

            if (!string.IsNullOrEmpty(config.AnesShiftDrugList))
            {
                drugList = config.AnesShiftDrugList.Split(',').ToList();
            }

            if (drugList != null)
            {
                for (int i = 0; i < drugList.Count; i++)
                {
                    var item = drugList[i];

                    MED_ANES_SHIFT_DRUGS listFind = list.Find(d => d.DRUGS_NAME == item);

                    if (listFind == null)
                    {
                        listFind = new MED_ANES_SHIFT_DRUGS()
                        {
                            SHIFT_DATE = startTime,
                            SHIFT_TYUPE = shift_Type,
                            DRUGS_NO = i,
                            DRUGS_NAME = item
                        };
                        list.Add(listFind);

                        dapper.Set<MED_ANES_SHIFT_DRUGS>().Insert(listFind);
                    }
                }
                dapper.SaveChanges();
            }

            list = dapper.Set<MED_ANES_SHIFT_DRUGS>().Query(sql, new
            {
                SHIFT_DATE = startTime,
                SHIFT_TYUPE = shift_Type
            });

            return list;
        }

        /// <summary>
        /// 麻醉交班急救插管患者信息查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<MED_ANES_SHIFT_PATIENTINFO> GetAnesShiftPatientInfoList(OperQueryParaModel model)
        {
            string sql = sqlDict.GetSQLByKey("GetAnesShiftPatientInfoList");

            DateTime? startTime = null;

            int? shift_Type = 0;

            if (!string.IsNullOrWhiteSpace(model.SHIFT_DATE))
            {
                startTime = Convert.ToDateTime(model.SHIFT_DATE).Date;
            }

            if (!string.IsNullOrWhiteSpace(model.SHIFT_TYUPE))
            {
                shift_Type = Convert.ToInt32(model.SHIFT_TYUPE);
            }

            List<MED_ANES_SHIFT_PATIENTINFO> list = dapper.Set<MED_ANES_SHIFT_PATIENTINFO>().Query(sql, new
            {
                SHIFT_DATE = startTime,
                SHIFT_TYUPE = shift_Type
            });

            //int? emergencyPatCount = model.AnesShiftEmergencyPatCount;//毒麻药列表

            decimal? emergencyPatCount = 0;

            MED_CONFIGSET config = sysConfigService.GetMedConfigSet();

            if (!string.IsNullOrEmpty(config.AnesShiftEmergencyPatCount.ToString()))
            {
                emergencyPatCount = config.AnesShiftEmergencyPatCount;
            }

            if (emergencyPatCount != 0)
            {
                for (int i = 0; i < emergencyPatCount; i++)
                {
                    var item = i;

                    MED_ANES_SHIFT_PATIENTINFO listFind = list.Find(d => d.PATIENT_NO == item);

                    if (listFind == null)
                    {
                        listFind = new MED_ANES_SHIFT_PATIENTINFO()
                        {
                            SHIFT_DATE = startTime,
                            SHIFT_TYUPE = shift_Type,
                            PATIENT_NO = i
                        };
                        list.Add(listFind);

                        dapper.Set<MED_ANES_SHIFT_PATIENTINFO>().Insert(listFind);
                    }
                }
                dapper.SaveChanges();
            }

            list = dapper.Set<MED_ANES_SHIFT_PATIENTINFO>().Query(sql, new
            {
                SHIFT_DATE = startTime,
                SHIFT_TYUPE = shift_Type
            });

            return list;
        }


        /// <summary>
        /// 保存麻醉交班数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int SaveAnesShiftMasterInfoList(MED_ANES_SHIFT_MASTER data)
        {
            int result = 0;
            try
            {
                if (!string.IsNullOrEmpty(data.ANES_DOCTOR_PIC_STR))
                {
                    data.ANES_DOCTOR_PIC = Str2Arr(data.ANES_DOCTOR_PIC_STR);
                }
                else
                {
                    data.ANES_DOCTOR_PIC = null;
                }

                if (!string.IsNullOrEmpty(data.SHIFT_DOCTOR_PIC_STR))
                {
                    data.SHIFT_DOCTOR_PIC = Str2Arr(data.SHIFT_DOCTOR_PIC_STR);
                }
                else
                {
                    data.SHIFT_DOCTOR_PIC = null;
                }

                if (!string.IsNullOrEmpty(data.ANES_DOCTOR1_PIC_STR))
                {
                    data.ANES_DOCTOR1_PIC = Str2Arr(data.ANES_DOCTOR1_PIC_STR);
                }
                else
                {
                    data.ANES_DOCTOR1_PIC = null;
                }

                if (!string.IsNullOrEmpty(data.SHIFT_DOCTOR1_PIC_STR))
                {
                    data.SHIFT_DOCTOR1_PIC = Str2Arr(data.SHIFT_DOCTOR1_PIC_STR);
                }
                else
                {
                    data.SHIFT_DOCTOR1_PIC = null;
                }

                result = dapper.Set<MED_ANES_SHIFT_MASTER>().Update(data) > 0 ? 1 : 0;
                dapper.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Error("保存麻醉交班数据", ex);
            }
            return result;
        }

        /// <summary>
        /// 保存麻醉交班毒麻药
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int SaveAnesShiftDrugInfoList(List<MED_ANES_SHIFT_DRUGS> data)
        {
            int result = 0;
            try
            {
                result = dapper.Set<MED_ANES_SHIFT_DRUGS>().Update(data) > 0 ? 1 : 0;
                dapper.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Error("保存麻醉交班毒麻药", ex);
            }
            return result;
        }

        /// <summary>
        /// 保存急救插管信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int SaveAnesShiftPatientInfoList(List<MED_ANES_SHIFT_PATIENTINFO> data)
        {
            int result = 0;
            try
            {
                result = dapper.Set<MED_ANES_SHIFT_PATIENTINFO>().Update(data) > 0 ? 1 : 0;
                dapper.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Error("保存急救插管信息", ex);
            }
            return result;
        }


        public static byte[] Str2Arr(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }

        public static string Arr2Str(byte[] buffer)
        {
            return (new UnicodeEncoding()).GetString(buffer, 0, buffer.Length);
        }
    }
}
