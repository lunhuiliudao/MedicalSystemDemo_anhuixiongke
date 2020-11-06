using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BMedCopyBackWDSJ:HospitalBase
    {
        public override string PreDataBase(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            try
            {
                InitDocare.LogA.Debug("开始批量回传");

                string sql = "select * from WN_CDR_LCWD_WDSJ where WRITE_BACK!='1'";
                DataSet ds = IDataBase.SelectDataBase(EnumDataBase.ORACLE).GetDataSet(CommandType.Text, sql);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    InitDocare.LogA.Debug("没有需要回传的数据");
                    return "";
                }
                config.obj = ds;
                DoExecute(config, domain, null);
                return "";
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n详细数据"  + "\r\n");
                return ex.Message;
            
            }
        }


        public override string DoExecute(InitDocare.Config2 config, Init.ParamInputDomain domain, MedicalSytem.Soft.Model.ModelBase obj)
        {
            try
            {
                DataSet ds = config.obj as DataSet;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string sqlUpdate = @"update  CENTER .dbo.WN_CDR_LCWD_WDSJ set jzlsh='" + dr["jzlsh"].ToString() + "',yljgdm='" + dr["yljgdm"].ToString() + "',yljgmc='" + dr["yljgmc"].ToString() + @"',
                                  jzlb='" + dr["jzlb"].ToString() + "',zyhm='" + dr["zyhm"].ToString() + "',mzh='" + dr["mzh"].ToString() + "',patid='" + dr["patid"].ToString() + @"',
                                hzxm='" + dr["hzxm"].ToString() + "', wdgs='" + dr["wdgs"].ToString() + "',wdnr='" + dr["wdnr"].ToString() + "',datastatus='" + dr["datastatus"].ToString() + @"',
                               jlzt='" + dr["jlzt"].ToString() + "',sjly='" + dr["sjly"].ToString() + "',gxrq ='" + dr["gxrq"].ToString() + "'where wdbsh='" + dr["wdbsh"].ToString() + "'";
                    string sqlInsert = @"Insert into CENTER .dbo.WN_CDR_LCWD_WDSJ(yljgdm,yljgmc,jzlb,zyhm,mzh,patid,hzxm, wdgs,wdnr,datastatus,jlzt,sjly,gxrq, jzlsh ,wdbsh) values
                   ('" + dr["yljgdm"].ToString() + "','" + dr["yljgmc"].ToString() + "','" + dr["jzlb"].ToString() + "','" + dr["zyhm"].ToString() + "','" + dr["mzh"].ToString() + @"',
                   '" + dr["patid"].ToString() + "','" + dr["hzxm"].ToString() + "', '" + dr["wdgs"].ToString() + "','" + dr["wdnr"].ToString() + "','" + dr["datastatus"].ToString() + @"',
                     '" + dr["jlzt"].ToString() + "','" + dr["sjly"].ToString() + "','" + dr["gxrq"].ToString() + "', '" + dr["jzlsh"].ToString() + "', '" + dr["wdbsh"].ToString() + "')";

                    InitDocare.LogA.Debug("sqlUpdate：" + sqlUpdate);
                    InitDocare.LogA.Debug("sqlInsert：" + sqlInsert);

                    string sql = config.SelectOneMedIfTransDict("CDR").Dbparm;

                    InitDocare.LogA.Debug("CDRConn:" + sql);

                    int result = IDataBase.SelectDataBase(EnumDataBase.SQLSERVER).ExecuteNonQuery(CommandType.Text, sqlUpdate, config.SelectOneMedIfTransDict("CDR").Dbparm);
                    if (result == 0)
                    {
                        InitDocare.LogA.Debug("执行结果Update ：" + result);
                        result = IDataBase.SelectDataBase(EnumDataBase.SQLSERVER).ExecuteNonQuery(CommandType.Text, sqlInsert, config.SelectOneMedIfTransDict("CDR").Dbparm);
                    }
                    InitDocare.LogA.Debug("执行结果：" + result);

                    if (result == 1)
                    {
                        string sqlUpdateFlag = "update WN_CDR_LCWD_WDSJ set WRITE_BACK='1' where wdbsh='" + dr["wdbsh"].ToString() + "'";
                        IDataBase.SelectDataBase(EnumDataBase.ORACLE).ExecuteNonQuery(CommandType.Text, sqlUpdateFlag);
                    }

                }
                return "";
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n详细数据" +  "\r\n");
                return ex.Message;

            }
        }
    }
}
