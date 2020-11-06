using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.Origins;
using MedicalSystem.Common.FileManage;
using MedicalSystem.Configurations;
using MedicalSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IPlatformCASignedService
    {
        /// <summary>
        /// 获取签名数据
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="visitId"></param>
        /// <param name="operId"></param>
        /// <param name="signDocName"></param>
        /// <param name="controlId"></param>
        /// <returns></returns>
        List<MED_BJCA_SIGN> QuerySignData(string patientId, decimal visitId, decimal operId, string signDocName, string controlId);

        /// <summary>
        /// 保存签名数据
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="visitId"></param>
        /// <param name="operId"></param>
        /// <param name="signDocName"></param>
        /// <param name="controlId"></param>
        /// <param name="signImage"></param>
        /// <returns></returns>
        int SaveSignData(string patientId, decimal visitId, decimal operId, string signDocName, string signName, string controlId, string signImage);

        /// <summary>
        /// 删除签名数据
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="visitId"></param>
        /// <param name="operId"></param>
        /// <param name="signDocName"></param>
        /// <param name="controlId"></param>
        /// <returns></returns>
        int DeleteSignData(string patientId, decimal visitId, decimal operId, string signDocName, string controlId);
    }
    public class PlatformCASignedService : BaseService<PlatformAnesQueryService>, IPlatformCASignedService
    {
        protected PlatformCASignedService()
            : base() { }
        public PlatformCASignedService(IDapperContext context)
            : base(context)
        {

        }


        /// <summary>
        /// 获取签名数据
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="visitId"></param>
        /// <param name="operId"></param>
        /// <param name="signDocName"></param>
        /// <param name="controlId"></param>
        /// <returns></returns>
        public List<MED_BJCA_SIGN> QuerySignData(string patientId, decimal visitId, decimal operId, string signDocName, string controlId)
        {
            List<MED_BJCA_SIGN> list = new List<MED_BJCA_SIGN>();

            string sql = sqlDict.GetSQLByKey("QuerySignData");
            list= dapper.Set<MED_BJCA_SIGN>().Query(sql, new { PATIENT_ID = patientId, VISIT_ID = visitId, OPER_ID = operId, SIGNDOCNAME = signDocName, CONTROLID = controlId });

            foreach (var item in list)
            {
                item.B64SIGNIMAGE = Arr2Str(item.SIGNIMAGE);
            }
            return list;
        }

        /// <summary>
        /// 保存签名数据
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="visitId"></param>
        /// <param name="operId"></param>
        /// <param name="signDocName"></param>
        /// <param name="controlId"></param>
        /// <param name="signImage"></param>
        /// <returns></returns>
        public int SaveSignData(string patientId, decimal visitId, decimal operId, string signDocName, string signName, string controlId, string signImage)
        {
            int result = 0;

            try
            {
                MED_BJCA_SIGN bjcaSign = new MED_BJCA_SIGN();

                //保证GUID 唯一 
                do//先执行一次，再判断。  
                {
                    bjcaSign.SIGNID = Guid.NewGuid().ToString();

                    bjcaSign.SIGNNAME = signName;

                    bjcaSign.SIGNDOCNAME = signDocName;

                    bjcaSign.SIGNDATE = DateTime.Now;

                    bjcaSign.SIGNTYPE = 0;

                    bjcaSign.CERTSN = null;

                    bjcaSign.SIGNVALUE = null;

                    bjcaSign.TIMESTAMPVALUE = null;

                    bjcaSign.SIGNCERT = null;

                    bjcaSign.SIGNIMAGE = Str2Arr(signImage);

                    bjcaSign.PATIENT_ID = patientId;

                    bjcaSign.VISIT_ID = (int)visitId;

                    bjcaSign.OPER_ID = (int)operId;

                    bjcaSign.ORGDATA = null;

                    bjcaSign.CONTROLID = controlId;
                }
                while (dapper.Set<MED_BJCA_SIGN>().Single(d => d.SIGNID == bjcaSign.SIGNID) != null);


                if (dapper.Set<MED_BJCA_SIGN>().Single(d => d.PATIENT_ID == bjcaSign.PATIENT_ID && d.VISIT_ID == bjcaSign.VISIT_ID
                && d.OPER_ID == bjcaSign.OPER_ID && d.OPER_ID == bjcaSign.OPER_ID && d.SIGNDOCNAME == bjcaSign.SIGNDOCNAME
                && d.CONTROLID == bjcaSign.CONTROLID) == null)
                {
                    result = dapper.Set<MED_BJCA_SIGN>().Insert(bjcaSign) ? 1 : 0;

                }
                else
                {
                    result = dapper.Set<MED_BJCA_SIGN>().Update(bjcaSign) > 0 ? 1 : 0;
                }

                dapper.SaveChanges();

            }
            catch (Exception ex)
            {
                Logger.Error("保存签名数据错误SaveSignData:", ex);
            }


            return result;
        }

        /// <summary>
        /// 删除签名数据
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="visitId"></param>
        /// <param name="operId"></param>
        /// <param name="signDocName"></param>
        /// <param name="controlId"></param>
        /// <returns></returns>
        public int DeleteSignData(string patientId, decimal visitId, decimal operId, string signDocName, string controlId)
        {
            int result = 0;

            try
            {
                dynamic bjcaSign = QuerySignData(patientId, visitId, operId, signDocName, controlId);

                if (bjcaSign != null)
                {
                    result = dapper.Set<MED_BJCA_SIGN>().Delete(bjcaSign) > 0 ? 1 : 0;

                    dapper.SaveChanges();
                }
                else
                {
                    result = 2;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("删除签名数据错误DeleteSignData:", ex);
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
