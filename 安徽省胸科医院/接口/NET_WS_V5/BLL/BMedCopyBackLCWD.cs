using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BMedCopyBackLCWD:HospitalBase
    {
        public override string PreDataBase(InitDocare.Config2 config, Init.ParamInputDomain domain)
        {
            try
            {
                InitDocare.LogA.Debug("开始批量回传");

                string sql = "select * from WN_CDR_LCWD where WRITE_BACK!='1'";
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
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n详细数据"   + "\r\n");
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
                    string sqlUpdate = @"update CENTER .dbo.WN_CDR_LCWD set jzlsh='" + dr["JZLSH"].ToString() + "',yljgdm='" + dr["YLJGDM"].ToString() + "',yljgmc='" + dr["YLJGMC"].ToString() + "',jzlb='" + dr["JZLB"].ToString() + "',zyhm='" + dr["ZYHM"].ToString() + "',mzh='" + dr["MZH"].ToString() + @"',
                   patid='" + dr["PATID"].ToString() + "', hzxm='" + dr["HZXM"].ToString() + "',wdbsh='" + dr["WDBSH"].ToString() + "',yexh='" + dr["YEXH"].ToString() + "',wdmc='" + dr["WDMC"].ToString() + "',wdbbh='" + dr["WDBBH"].ToString() + "',wdlb='" + dr["WDLB"].ToString() + @"',
                   wdlbsm='" + dr["WDLBSM"].ToString() + "' ,wdmxlbdm='" + dr["WDMXLBDM"].ToString() + "',wdmxlbsm='" + dr["WDMXLBSM"].ToString() + "',ispdf='" + dr["ISPDF"].ToString() + "',iswdd='" + dr["ISWDD"].ToString() + "',isjgh='" + dr["ISJGH"].ToString() + "',cjysdm='" + dr["CJYSDM"].ToString() + @"',
                  cjysmc='" + dr["CJYSMC"].ToString() + "',shysdm='" + dr["SHYSDM"].ToString() + "',shysmc='" + dr["SHYSMC"].ToString() + "',cjsj='" + dr["CJSJ"].ToString() + "',shsj='" + dr["SHSJ"].ToString() + "',wjccbz='" + dr["WJCCBZ"].ToString() + "',url='" + dr["URL"].ToString() + @"',
                  pageindex='" + dr["PAGEINDEX"].ToString() + "',blzt='" + dr["BLZT"].ToString() + "',datastatus='" + dr["DATASTATUS"].ToString() + "', jlzt='" + dr["JLZT"].ToString() + "',sjly='" + dr["SJLY"].ToString() + "',gxrq='" + dr["GXRQ"].ToString() + "'  where  wdbsh='" + dr["WDBSH"].ToString() + "'";
                 
                    string sqlInsert = @"Insert into CENTER .dbo.WN_CDR_LCWD(jzlsh,yljgdm,yljgmc,jzlb,zyhm,mzh,patid, hzxm,wdbsh,yexh,wdmc,wdbbh,wdlb,wdlbsm ,wdmxlbdm,wdmxlbsm,ispdf,iswdd,isjgh,cjysdm,cjysmc,shysdm,shysmc,cjsj,shsj,wjccbz,url,pageindex,blzt,datastatus, jlzt,sjly,gxrq) values
                   ('" +dr["JZLSH"].ToString()+"','"+dr["YLJGDM"].ToString()+"','"+dr["YLJGMC"].ToString()+"','"+dr["JZLB"].ToString()+"','"+dr["ZYHM"].ToString()+"','"+dr["MZH"].ToString()+"','"+dr["PATID"].ToString()+"', '"+dr["HZXM"].ToString()+"','"+dr["WDBSH"].ToString()+@"',
                   '"+dr["YEXH"].ToString()+"','"+dr["WDMC"].ToString()+"','"+dr["WDBBH"].ToString()+"','"+dr["WDLB"].ToString()+"','"+dr["WDLBSM"].ToString()+"' ,'"+dr["WDMXLBDM"].ToString()+"','"+dr["WDMXLBSM"].ToString()+"','"+dr["ISPDF"].ToString()+"','"+dr["ISWDD"].ToString()+@"',
                   '"+dr["ISJGH"].ToString()+"','"+dr["CJYSDM"].ToString()+"','"+dr["CJYSMC"].ToString()+"','"+dr["SHYSDM"].ToString()+"','"+dr["SHYSMC"].ToString()+"','"+dr["CJSJ"].ToString()+"','"+dr["SHSJ"].ToString()+"','"+dr["WJCCBZ"].ToString()+"','"+dr["URL"].ToString()+@"',
                   '" + dr["PAGEINDEX"].ToString() + "','" + dr["BLZT"].ToString() + "','" + dr["DATASTATUS"].ToString() + "', '" + dr["JLZT"].ToString() + "','" + dr["SJLY"].ToString() + "','" + dr["GXRQ"].ToString() + "')";

                    //InitDocare.LogA.Debug("sqlUpdate：" + sqlUpdate);
                    //InitDocare.LogA.Debug("sqlInsert：" + sqlInsert);

                    string sql = config.SelectOneMedIfTransDict("CDR").Dbparm;

                    //InitDocare.LogA.Debug("CDRConn:" + sql);

                    int result = IDataBase.SelectDataBase(EnumDataBase.SQLSERVER).ExecuteNonQuery(CommandType.Text, sqlUpdate, config.SelectOneMedIfTransDict("CDR").Dbparm);
                    if (result == 0)
                    {
                        InitDocare.LogA.Debug("执行结果Update ：" + result);
                        result = IDataBase.SelectDataBase(EnumDataBase.SQLSERVER).ExecuteNonQuery(CommandType.Text, sqlInsert, config.SelectOneMedIfTransDict("CDR").Dbparm);
                    }
                    InitDocare.LogA.Debug("执行结果：" + result);

                    if (result == 1)
                    {
                        string sqlUpdateFlag = "update WN_CDR_LCWD set WRITE_BACK='1' where wdbsh='" + dr["WDBSH"].ToString() + "'";
                        IDataBase.SelectDataBase(EnumDataBase.ORACLE).ExecuteNonQuery(CommandType.Text, sqlUpdateFlag);
                    }

                }
                return "";
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n详细数据" + "\r\n");
                return ex.Message;

            }
        }
    }
}
