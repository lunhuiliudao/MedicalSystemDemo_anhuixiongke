using InitDocare;
using MedicalSytem.Soft.Model;
using NET_WS_V5;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BMedOrder103:HospitalBase
    {

        public override System.Data.Common.DbParameter[] GetPara(EnumDataBase database)
        {
            DbParameter[] parms = null;

            switch (database)
            {
                case EnumDataBase.ORACLE:
                    {
                        parms = new OracleParameter[]{
                           new OracleParameter(":patientid",OracleType.VarChar),
                           new OracleParameter(":visitid",OracleType.VarChar)};
                    }
                    break;
                case EnumDataBase.OLEDB:
                    {
                        parms = new OleDbParameter[] {
                          
                            new OleDbParameter("patientid",OleDbType.VarChar),
                            new OleDbParameter("visitid",OleDbType.VarChar), 
                        };
                    }
                    break;
                case EnumDataBase.SQLSERVER:
                    {
                        parms = new SqlParameter[] {
                            new SqlParameter("@startdatetime",SqlDbType.DateTime),
                            new SqlParameter("@stopdatetime",SqlDbType.DateTime),
                            new SqlParameter("@startdatetime1",SqlDbType.DateTime),
                            new SqlParameter("@stopdatetime1",SqlDbType.DateTime),
                            new SqlParameter("@startdatetime2",SqlDbType.DateTime),
                            new SqlParameter("@stopdatetime2",SqlDbType.DateTime),
                            new SqlParameter("@patientid",SqlDbType.VarChar),
                            new SqlParameter("@inpno",SqlDbType.VarChar),
                           
                        };
                    }
                    break;
                case EnumDataBase.ODBC:
                    {
                        parms = new OdbcParameter[] {
                            new OdbcParameter("patientid",OdbcType.VarChar),
                            new OdbcParameter("visitid",OdbcType.VarChar)
                        };
                    }
                    break;
            }
            return parms;
        }

        public override string PreDataBase(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            try
            {
                InitDocare.LogA.Debug("同步医嘱开始xxxORDER103");
                InitDocare.LogA.Debug(" 同步医嘱:start:" + domain.Patient.StartDate + " stopdatetie:" + domain.Patient.StopDate);
                string PatientId = domain.Patient.PatientId;
                decimal VisitId = domain.Patient.VisitId.Value;
                domain.Patient.StopDate = domain.Patient.StopDate.AddHours(7);
                MedVsHisPat vspat = SelectMedVsHisPat(PatientId, VisitId);
                if (vspat == null)
                {
                    vspat = new MedVsHisPat();
                    vspat.HisPatientId = PatientId;
                    vspat.HisVisitId = VisitId.ToString();
                    
                    string sqlwhere = "select t.inp_no from med_pat_inicu_information t where t.patient_id='" + PatientId + "' order by t.visit_id desc";

                    DataSet dstemp = IDataBase.SelectDataBase(EnumDataBase.ORACLE).GetDataSet(CommandType.Text, sqlwhere);

                    vspat.HisInpNo = dstemp.Tables[0].Rows[0][0].ToString();

                }

                List<MedIfHisViewSql2> sql = config.SelectMedIfHisViewSql(domain.Code);
                DataSet dsResult = new DataSet();
                foreach (MedIfHisViewSql2 temp in sql)
                {
                    if (temp.CommandType == "WS")
                    {
                        return PreWebServices(config, domain);
                    }
                    MedIfTransDict oneTransEntity = config.SelectOneMedIfTransDict(temp.TransName);

                    DbParameter[] para = GetPara(oneTransEntity.Dbms);
                    para[0].Value = domain.Patient.StartDate;
                    para[1].Value = domain.Patient.StopDate;
                    para[2].Value = domain.Patient.StartDate;
                    para[3].Value = domain.Patient.StopDate;
                    para[4].Value = domain.Patient.StartDate;
                    para[5].Value = domain.Patient.StopDate;
                    para[6].Value = vspat.HisPatientId;   //todo 多个参数动态怎么解决
                    para[7].Value = vspat.HisInpNo;

                    foreach (SqlParameter p in para)
                    {
                        InitDocare.LogA.Debug("name:" + p.ParameterName + " value:" + p.Value);
                    }

                    string sqlDDL = temp.SqlText + " " + GetSqlPara(temp.SqlPara, oneTransEntity.Dbms);
                    InitDocare.LogA.Debug(sqlDDL);
                    DataSet ds = IDataBase.SelectDataBase(oneTransEntity.Dbms).GetDataSet(CommandType.Text, sqlDDL, oneTransEntity.Dbparm, para);
                    InitDocare.LogA.Debug("ds:" + ds.GetXml());
                    DataTable dt = ds.Tables[0];
                    dt = PublicXML.EexcColumnName(dt, PublicXML.InterfaceDataType.Orders);
                    List<MedOrders> OrderList = GetMedOrder(dt);
                    foreach (MedOrders order in OrderList)
                    {
                        //MED_VS_HIS_ORDER_CLASS表需要进行配置：A.西药，B.成药，C.草药，D.检验，E.检查，F.手术，K.材料，I.治疗
                        MedicalSytem.Soft.Model.MedVsHisOrderClass oneMedVsHisOrderClass = SelectMedVsHisOrderClass(order.OrderClass);
                        if (oneMedVsHisOrderClass == null)
                        {
                            MedicalSytem.Soft.Model.MedVsHisOrderClass oneMedVsHisOrderClassInsert = new MedicalSytem.Soft.Model.MedVsHisOrderClass();
                            oneMedVsHisOrderClassInsert.HisClassCode = order.OrderClass;
                            oneMedVsHisOrderClassInsert.HisClassName = "待填";
                            oneMedVsHisOrderClassInsert.MedClassCode = "Z";
                            oneMedVsHisOrderClassInsert.MedClassName = "待填";
                            InsertMedVsHisOrderClass(oneMedVsHisOrderClassInsert);
                            order.OrderClass = "Z";
                        }
                        else
                            order.OrderClass = oneMedVsHisOrderClass.MedClassCode;

                        ReturnMessage += DoExecute(config, domain, order);
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

        public override string PreReceiveMsg(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            return base.PreReceiveMsg(config, domain);
        }

        public override string PreWebServices(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            MedPatsInHospital hos = SelectMedPatsInHospital(domain.Patient.PatientId, domain.Patient.VisitId.Value);
            domain.Patient.InpNo = hos.InpNo;
           
            string resultXML = Anterface.GetPatientOrder(domain.Patient.InpNo);
            InitDocare.LogDALA.Debug(" resultXML:" + resultXML);
            DataSet ds=new DataSet();
            using (StringReader sr = new StringReader(resultXML))
            {
                ds.ReadXml(sr);
            }
            DataTable dt = ds.Tables[0];
            dt = PublicXML.EexcColumnName(dt, PublicXML.InterfaceDataType.Orders);
            List<MedOrders> OrderList = GetMedOrder(dt);

            OrderList = OrderList.Where(p => p.StartDateTime > domain.Patient.StartDate.AddDays(-1)).ToList();
            foreach (MedOrders order in OrderList)
            {
              
                //MED_VS_HIS_ORDER_CLASS表需要进行配置：A.西药，B.成药，C.草药，D.检验，E.检查，F.手术，K.材料，I.治疗
                MedicalSytem.Soft.Model.MedVsHisOrderClass oneMedVsHisOrderClass = SelectMedVsHisOrderClass(order.OrderClass);
                if (oneMedVsHisOrderClass == null)
                {
                    MedicalSytem.Soft.Model.MedVsHisOrderClass oneMedVsHisOrderClassInsert = new MedicalSytem.Soft.Model.MedVsHisOrderClass();
                    oneMedVsHisOrderClassInsert.HisClassCode = order.OrderClass;
                    oneMedVsHisOrderClassInsert.HisClassName = "待填";
                    oneMedVsHisOrderClassInsert.MedClassCode = "Z";
                    oneMedVsHisOrderClassInsert.MedClassName = "待填";
                    InsertMedVsHisOrderClass(oneMedVsHisOrderClassInsert);
                    order.OrderClass = "Z";
                }
                else
                    order.OrderClass = oneMedVsHisOrderClass.MedClassCode;

                ReturnMessage += DoExecute(config, domain, order);
            }
            return ReturnMessage;
        }

        public override string DoExecute(InitDocare.Config2 config, Init.ParamInputDomain domain, MedicalSytem.Soft.Model.ModelBase obj)
        {
            try
            {
                if (!(obj is MedOrders))
                {
                    return "异常";
                }

                MedOrders order = obj as MedOrders;
                //转换医嘱信息
                MedicalSytem.Soft.Model.MedVsHisOrders medVsHisOrdersOne = new MedicalSytem.Soft.Model.MedVsHisOrders();
                medVsHisOrdersOne.MedPatientId = domain.Patient.PatientId;
                medVsHisOrdersOne.MedVisitId = domain.Patient.VisitId.Value;
                order.PatientId = domain.Patient.PatientId;
                order.VisitId = domain.Patient.VisitId.Value;
                //取最大医嘱编号
                if (InitDocare.PublicString.GetRealLength(order.OrderNo.ToString()) > 20)
                {
                    int medOrdersMaxOK = SelectMaxMedOrdersNo() + 1;
                    //<--
                    //子医嘱转换
                    if (order.OrderSubNo <= decimal.Parse("1"))
                    {
                        medVsHisOrdersOne.MedOrderSubNo = (decimal)1;
                        //medVsHisOrdersOne.MedOrderNo = order.OrderNo
                        medVsHisOrdersOne.MedOrderNo = medOrdersMaxOK.ToString();
                    }
                    else
                    {
                        //medVsHisOrdersOne.MedOrderNo = order.OrderSubNo;
                        medVsHisOrdersOne.MedOrderNo = medOrdersMaxOK.ToString();
                        int medVsHisOrdersMax = SelectMaxMedOrdersSubNo(order.PatientId, order.VisitId, order.OrderSubNo.ToString());
                        if (medVsHisOrdersMax <= 0)
                            medVsHisOrdersOne.MedOrderSubNo = 1;
                        else
                            medVsHisOrdersOne.MedOrderSubNo = medVsHisOrdersMax + 1;
                    }
                }
                else
                {
                    //子医嘱转换
                    //if (order.OrderSubNo <= decimal.Parse("1"))
                    //{
                    //    medVsHisOrdersOne.MedOrderSubNo = (decimal)1;
                    //    medVsHisOrdersOne.MedOrderNo = order.OrderNo;
                    //}
                    //else
                    //{
                    medVsHisOrdersOne.MedOrderNo = order.OrderNo;
                    int medVsHisOrdersMax = SelectMaxMedOrdersSubNo(order.PatientId, order.VisitId, order.OrderNo);
                    if (medVsHisOrdersMax <= 0)
                        medVsHisOrdersOne.MedOrderSubNo = 1;
                    else
                        medVsHisOrdersOne.MedOrderSubNo = medVsHisOrdersMax + 1;
                    //}
                }
                medVsHisOrdersOne.MedRepeatIndicator = order.RepeatIndicator;
                medVsHisOrdersOne.HisOrderNo = order.OrderNo.ToString();
                medVsHisOrdersOne.HisOrderSubNo = order.HisOrderSubNo.ToString();
             
                medVsHisOrdersOne.CreateDate = new DateTime(2011, 1, 1);
                MedicalSytem.Soft.Model.MedVsHisOrders medVsHisOrdersTemp = SelectMedVsHisOrdersHis(order.OrderNo.ToString(), order.HisOrderSubNo.ToString(), new DateTime(2011, 1, 1));
                if (medVsHisOrdersTemp == null)
                {
                    InsertMedVsHisOrders(medVsHisOrdersOne);
                }
                else
                {
                    medVsHisOrdersOne.MedOrderNo = medVsHisOrdersTemp.MedOrderNo;
                    medVsHisOrdersOne.MedOrderSubNo = medVsHisOrdersTemp.MedOrderSubNo;
                    if (!medVsHisOrdersOne.Equals(medVsHisOrdersTemp))
                        UpdateMedVsHisOrders(medVsHisOrdersOne);
                }
                order.PatientId = medVsHisOrdersOne.MedPatientId;
                order.VisitId = medVsHisOrdersOne.MedVisitId;
                order.OrderNo = medVsHisOrdersOne.MedOrderNo;
                order.OrderSubNo = medVsHisOrdersOne.MedOrderSubNo;
                //判断，如果主医嘱停止了，它的所有子医嘱也都要停止
                if (order.OrderSubNo > 1)
                {
                    MedicalSytem.Soft.Model.MedOrders orderSubTemp = SelectMedOrders(order.PatientId, order.VisitId, order.OrderNo, (decimal)1);
                    if (orderSubTemp != null)
                    {
                        order.StartDateTime = orderSubTemp.StartDateTime.Value;
                        if (orderSubTemp.StopDateTime.HasValue)
                        {
                            order.StopDateTime = orderSubTemp.StopDateTime.Value;
                        }
                        order.OrderStatus = orderSubTemp.OrderStatus;
                    }
                }
                if (UpdateMedOrders(order) == 0)
                    InsertMedOrders(order);

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
