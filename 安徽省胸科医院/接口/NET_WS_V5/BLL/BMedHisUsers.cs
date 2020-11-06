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
    public class BMedHisUsers : HospitalBase
    {
        private DateTime datetime;
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
                    DataTable dt = PublicXML.EexcColumnName(ds.Tables[0], PublicXML.InterfaceDataType.HisUsers);

                    List<MedHisUsers> HisUserList = GetMedHisUsers(dt);
                    foreach (MedHisUsers oneHisUsers in HisUserList)
                    {
                        ReturnMessage += DoExecute(config, domain, oneHisUsers);
                    }
                }
                return ReturnMessage;
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n");
                return ex.Message;
            }
        }

        /// <summary>
        /// 系统接收到消息
        /// </summary>
        /// <param name="config"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public override string PreReceiveMsg(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            DataSet ds = new DataSet();
            using (StringReader sr = new StringReader(domain.ReceiveMessage))
            {
                ds.ReadXml(sr);
            }
            DataTable dt = PublicXML.EexcColumnName(ds.Tables[0], PublicXML.InterfaceDataType.HisUsers);

            List<MedHisUsers> HisUserList = GetMedHisUsers(dt);
            foreach (MedHisUsers oneHisUsers in HisUserList)
            {
                ReturnMessage += DoExecute(config, domain, oneHisUsers);
            }
            return ReturnMessage;
        }

        /// <summary>
        /// web 服务 同步
        /// </summary>
        /// <param name="config"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public override string PreWebServices(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            string mess = Anterface.GetHisUsers("Anes");
            InitDocare.LogDALA.Debug("mess:" + mess);
            DataSet ds = new DataSet();
            using (StringReader sr = new StringReader(mess))
            {
                ds.ReadXml(sr);
            }
            DataTable dt =ds.Tables[0];// PublicXML.EexcColumnName(, PublicXML.InterfaceDataType.HisUsers);
            List<MedHisUsers> HisUserList = GetMedHisUsers(dt);
            foreach (MedHisUsers oneHisUsers in HisUserList)
            {
                ReturnMessage += DoExecute(config, domain, oneHisUsers);
            }
            return ReturnMessage;
        }

        /// <summary>
        /// 处理返回结果
        /// </summary>
        /// <param name="config"></param>
        /// <param name="domain"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override string DoExecute(InitDocare.Config2 config, Init.ParamInputDomain domain, MedicalSytem.Soft.Model.ModelBase obj)
        {
            try
            {
                if (!(obj is MedHisUsers))
                {
                    return "obj is not MedHisUsers " + obj.ToString();
                }

                MedHisUsers oneMedHisUsers = obj as MedHisUsers;

                if (UpdateMedHisUsers(oneMedHisUsers) == 0)
                    InsertMedHisUsers(oneMedHisUsers);
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
