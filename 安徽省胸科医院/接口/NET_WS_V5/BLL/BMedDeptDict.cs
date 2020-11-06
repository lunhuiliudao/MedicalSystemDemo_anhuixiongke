using InitDocare;
using MedicalSytem.Soft.Model;
using NET_WS_V5;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BMedDeptDict : HospitalBase
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

                    string sqlDDL = temp.SqlText + " " + GetSqlPara(temp.SqlPara, oneTransEntity.Dbms);

                    //InitDocare.LogDALA.Debug("sqlDDL" + sqlDDL);

                    DataSet ds = IDataBase.SelectDataBase(oneTransEntity.Dbms).GetDataSet(CommandType.Text, temp.SqlText, oneTransEntity.Dbparm, null);

                    InitDocare.LogDALA.Debug("ds" + ds.GetXml());

                    DataTable dt = ds.Tables[0];

                    List<MedDeptDict> DeptDictList = GetMedDeptDictList(dt);
                    foreach (MedDeptDict entity in DeptDictList)
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
            string mess = Anterface.GetDeptDict("Anes");
            //InitDocare.LogDALA.Debug("ds:" + mess);
            DataSet ds = new DataSet();
            using (StringReader sr = new StringReader(mess))
            {
                ds.ReadXml(sr);
            }
            DataTable dt = ds.Tables[0];
            dt = PublicXML.EexcColumnName(dt, PublicXML.InterfaceDataType.DeptDict);
            List<MedDeptDict> DeptDictList = GetMedDeptDictList(dt);
            foreach (MedDeptDict entity in DeptDictList)
            {
                ReturnMessage += DoExecute(config, domain, entity);
            }
            return ReturnMessage;
        }

        public override string PreReceiveMsg(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            DataSet ds = new DataSet();
            using (StringReader sr = new StringReader(domain.ReceiveMessage))
            {
                ds.ReadXml(sr);
            }

            DataTable dt = ds.Tables[0];
            dt = PublicXML.EexcColumnName(dt, PublicXML.InterfaceDataType.DeptDict);

            List<MedDeptDict> DeptDictList = GetMedDeptDictList(dt);
            domain.Reserved1 = "reserved01";
            foreach (MedDeptDict entity in DeptDictList)
            {
                ReturnMessage += DoExecute(config, domain, entity);
            }
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

                if (!(obj is MedDeptDict))
                {
                    return "obj is not MedDeptDict " + obj.ToString();
                }
                MedDeptDict oneMedDeptDict = obj as MedDeptDict;

                //InitDocare.LogDALA.Debug("DoExecute11");

                if (UpdateMedDeptDict(oneMedDeptDict) == 0)
                {
                    //InitDocare.LogDALA.Debug("DoExecute22");

                    InsertMedDeptDict(oneMedDeptDict);
                }
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
