using InitDocare;
using MedicalSytem.Soft.Model;
using NET_WS_V5;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BMedOperationDict:HospitalBase
    {
        /// <summary>
        /// 数据库同步
        /// </summary>
        /// <param name="config"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public override string PreDataBase(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            try
            {
                List<MedIfHisViewSql2> sql = config.SelectMedIfHisViewSql(domain.Code);
                DataSet dsResult = new DataSet();
                foreach (MedIfHisViewSql2 temp in sql)
                {
                    if (temp.CommandType == "WS")
                    {
                        return PreWebServices(config, domain);
                    }
                    MedIfTransDict oneTransEntity = config.SelectOneMedIfTransDict(temp.TransName);


                    DataSet ds = IDataBase.SelectDataBase(oneTransEntity.Dbms).GetDataSet(CommandType.Text, temp.SqlText, oneTransEntity.Dbparm, null);
                    InitDocare.LogA.Debug("ds:" + ds.GetXml());
                    DataTable dt = ds.Tables[0];

                    List<MedOperationDict> DeptDictList = GetMedOperationDict(dt);
                    foreach (MedOperationDict entity in DeptDictList)
                    {
                        ReturnMessage += DoExecute(config, domain, entity);
                    }
                }
                return ReturnMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// web 服务同步数据
        /// </summary>
        /// <param name="config"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public override string PreWebServices(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
           
            return ReturnMessage;
        }

        public override string PreReceiveMsg(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
           
            return ReturnMessage;
        }

        /// <summary>
        /// 处理执行数据
        /// </summary>
        /// <param name="config"></param>
        /// <param name="domain"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override string DoExecute(InitDocare.Config2 config, Init.ParamInputDomain domain, MedicalSytem.Soft.Model.ModelBase obj)
        {
            try
            {
                // domain.Reserved1;
                if (!(obj is MedOperationDict))
                {
                    return "obj is not MedDeptDict " + obj.ToString();
                }
                MedOperationDict oneMedDeptDict = obj as MedOperationDict;

                if (UpdateMedOperationDict(oneMedDeptDict) == 0)
                  InsertMedOperationDict(oneMedDeptDict);
                return "";
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n详细数据" + obj.ToString() + "\r\n");
                return ex.Message;
            }
        }
    }
}
