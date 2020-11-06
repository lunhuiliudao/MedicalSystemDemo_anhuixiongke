using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using log4net;
using System.IO;
using InitDocare;
using BLL;
using Init;
using MedicalSytem.Soft.InitDocare;

[WebService(Description = "Docare医疗数据集成平台v4", Name = "WebServices", Namespace = "Http://ws.medicalsystem.com.cn")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
[System.Web.Script.Services.GenerateScriptType(typeof(ParmInputData))]
public class WebServices : System.Web.Services.WebService
{
    /// <summary>
    /// WebServer服务
    /// </summary>
    public WebServices()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
 
    /// <summary>
    /// 应用程序类型，麻醉，ICU,数字化手术室 等等
    /// </summary>
    private string strAppType
    {
        get;
        set;
    }
   
    /// <summary>
    /// 对外统一接口DocareSysInterface
    /// </summary>
    /// <param name="strAppType">应用程序类型</param>
    /// <param name="strSystemClass">类别HIS LIS等</param>
    /// <param name="strInterFaceType">参数</param>
    /// <param name="struInputData">输入结构体</param>
    /// <returns></returns>
    [WebMethod(Description = "Docare医疗数据集成平台--统一调用平台")]
    public string DocareSysInterface(string xmlMessage) 
    {
        #region DocareSysInterfaceV4

        ParamInputDomain domain = new ParamInputDomain(xmlMessage); //医院名称 //同一功能点一个结合. TransDict  (2个表)  数据源暂时写死
                                                                    // 加页面设置transDict 表数据源 , 一个功能点对于5个类型
        if (!domain.ErrInfoEty.Flag)
        {
            return domain.ErrInfoEty.ErrMsg;
        }

        string re = "";
        try
        {
            InitDocare.LogA.Debug("时间=" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "，接收到由系统" + domain.App + "传递过来的调用信息.申请类型为" + domain.Coltd + "，接口类型为" + domain.Code);

            if (domain.Reserved9 == "DB") ///数据库模式，SQLSERVER, ORACLE,
            {
                return MessageHander.GetInstance().MessageSwitch(domain).PrePareDataBase(new Config(), domain);
            }
            else if (domain.Reserved9 == "WS") ///web 服务模式，HL7，XML,JSON ,CDR ,
            {
                return MessageHander.GetInstance().MessageSwitch(domain).PrePareReceiveMsg(new Config(), domain);
            }

            //  return  
            //switch (domain.Code)
            //{


                //case "HIS000": //单点登陆
                //    re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetLoginInfo(domain.BaseEty.UserID, domain.BaseEty.Operator, domain.BaseEty.PWD);
                //    break;
                //case "HIS001":	//同步科室
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetDeptDictRec(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS002":	//同步HIS人员
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetHisUsersRec(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS003":  //同步诊断字典
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetDiagnosisDict(doCareConfig, doCareDict);
                //        break;
                //    }

                //case "HIS006":  //同步床位字典
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetBedRec(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS007":  //同步价表
                //    {
                //        if (string.IsNullOrEmpty(domain.OperationEty.Performedcode))
                //        {
                //            domain.OperationEty.Performedcode = doCareDict.DoCarePerformedcode;
                //        }
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetPriceListRec(doCareConfig, doCareDict, domain.OperationEty.Performedcode);
                //        break;
                //    }
                //case "HIS008":  //同步价表名称信息
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetPriceItemNameDictRec(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS009":  //同步药品字典信息
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetDrugDictRec(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS010":  //同步药品名称字典信息
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetDrugNameDictRec(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS011":  //同步物资(耗材)字典信息
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetMtrlDictRec(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS012":  //同步药品及物资(耗材)供应商信息
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetMtrlSupplierCatalogRec(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS013":  //同步手术名称信息
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetOperationDict(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS101":  //根据ID号同步单病人基本信息及住院信息
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetPatientIDRec(doCareConfig, doCareDict,domain.PatientEty.PatientId);
                //        break;
                //    }
                //case "HIS102":  //提取并同步所有在科病区住院病人基本信息
                //    {
                //        if(string.IsNullOrEmpty(domain.OperationEty.Performedcode))
                //        {
                //            domain.OperationEty.Performedcode = doCareDict.DoCarePerformedcode;
                //        }
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetDeptPatientRec(doCareConfig, doCareDict, domain.OperationEty.Performedcode);
                //        break;
                //    }
                //case "HIS103":  //提取单病人医嘱信息	
                //    {
                //        if (!domain.PatientEty.VisitId.HasValue)
                //        {
                //            return "visitid 为空";
                //        }
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetIcuPatientOrdersRec(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value);
                //        break;
                //    }
                //case "HIS104":  //根据住院号同步单病人基本信息及住院信息
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetPatientInpNoRec(doCareConfig, doCareDict, domain.PatientEty.InpNo);
                //        break;
                //    }
                //case "HIS105":  //提取单病人区间医嘱信息
                //    {

                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetIcuPatientOrdersRec(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value, domain.BaseEty.StartDateTime.Value, domain.BaseEty.StopDateTime.Value);

                //        break;
                //    }
                //case "HIS201":  //同步病人申请或预约信息（如果patientid为空，同步所有病人，否则，同步单个病人）
                //    {

                //        if (string.IsNullOrEmpty(domain.PatientEty.PatientId))
                //            domain.PatientEty.PatientId = "ALL";
                //        if (!domain.PatientEty.VisitId.HasValue)
                //            domain.PatientEty.VisitId = 999;
                //        if (!domain.OperationEty.StartDataTime.HasValue)
                //        {
                //            DateTime dateStart = DateTime.Now;
                //            domain.OperationEty.StartDataTime = new DateTime(dateStart.Year, dateStart.Month, dateStart.Day, 0, 0, 0);
                //        }
                //        if (!domain.OperationEty.StopDataTime.HasValue)
                //        {
                //            DateTime dateEnd = DateTime.Now.AddDays(2);
                //            if (string.IsNullOrEmpty(doCareDict.DoCareDayNum))
                //            {
                //                 domain.OperationEty.StopDataTime= new DateTime(dateEnd.Year, dateEnd.Month, dateEnd.Day, 23, 59, 59);
                //            }
                //            else
                //            {
                //                int xi;
                //                if (Int32.TryParse(doCareDict.DoCareDayNum.ToString(), out xi))
                //                    domain.OperationEty.StopDataTime = domain.OperationEty.StartDataTime.Value.AddDays(Int32.Parse(doCareDict.DoCareDayNum.ToString()));
                //                else
                //                    domain.OperationEty.StopDataTime = new DateTime(dateEnd.Year, dateEnd.Month, dateEnd.Day, 23, 59, 59);
                //            }
                //        }
                //        if (domain.OperationEty.StartDataTime.Value >= domain.OperationEty.StopDataTime.Value)
                //        {
                //            DateTime dateEnd = DateTime.Now.AddDays(2);
                //            if (string.IsNullOrEmpty(doCareDict.DoCareDayNum))
                //            {
                //                domain.OperationEty.StopDataTime = new DateTime(dateEnd.Year, dateEnd.Month, dateEnd.Day, 23, 59, 59);
                //            }
                //            else
                //            {
                //                int xi;
                //                if (Int32.TryParse(doCareDict.DoCareDayNum.ToString(), out xi))
                //                    domain.OperationEty.StopDataTime = domain.OperationEty.StartDataTime.Value.AddDays(Int32.Parse(doCareDict.DoCareDayNum.ToString()));
                //                else
                //                    domain.OperationEty.StopDataTime = new DateTime(dateEnd.Year, dateEnd.Month, dateEnd.Day, 23, 59, 59);
                //            }
                //        }
                //        if (string.IsNullOrEmpty(domain.OperationEty.Performedcode))
                //        {
                //            domain.OperationEty.Performedcode = doCareDict.DoCarePerformedcode;
                //        }

                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetPatientOperationSchedule(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value, domain.OperationEty.StartDataTime.Value, domain.OperationEty.StopDataTime.Value, domain.OperationEty.Performedcode);
                //        break;
                //    }
                //case "HIS202":  //回写病人手术预约信息(OPERATION_SCHEDULE,SCHEDULED_OPERATION_NAME)--麻醉程序术前手术安排时候回写
                //    {
                //        if (!domain.OperationEty.ScheduleId.HasValue)
                //        {
                //            return "scheduleid is null";
                //        }
                //        if (!domain.PatientEty.VisitId.HasValue)
                //        {
                //            return "visitid is null";
                //        }
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).CopyBackOperationScheduleInformation(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value, domain.OperationEty.ScheduleId.Value);
                //        break;
                //    }
                //case "HIS203":  //回写病人手术信息(OPERATION_MASTER,OPERATION_NAME)--需要沟通
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).CopyBackOperationInformation(doCareConfig, doCareDict, DateTime.Now, DateTime.Now, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value, domain.OperationEty.ScheduleId.Value);
                //        break;
                //    }
                //case "HIS204":  //查询HIS中收费单个项目价格
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetOnePriceListRec(doCareConfig, doCareDict, domain.Reserved1, domain.Reserved2);
                //        break;
                //    }
                //case "HIS205":  //查询HIS中单个药品库存信息
                //    {
                //        break;
                //    }
                //case "HIS206":  //回写HIS收费项目，单条回写收费信息 -- 暂时未使用
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).CopyBackPatientOneTransConsts(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value, domain.OperationEty.OperId.Value);

                //        break;
                //    }
                //case "HIS207":  //提取HIS药品申请信息-入库信息 对应HIS-出库
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetDrugImportDetailHis(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS208":  //提取HIS物资(耗材)申请信息-入库信息 对应HIS-出库
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetMtrlImportDetailHis(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS209":  //回写HIS收费项目,一次回写本次所有的收费信息
                //    {
                //        if (string.IsNullOrEmpty(domain.Reserved2))
                //            domain.Reserved2 = "1";
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).CopyBackPatientAllTransConsts(doCareConfig, doCareDict, domain.OperationEty.BillAtr.Value.ToString(), domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value, domain.OperationEty.OperId.Value, 0, domain.Reserved3);
                //        break;
                //    }
                //case "HIS210":  //九院查看病人HIS收费明细
                //    {
                //        break;
                //    }
                //case "HIS211"://回写手术状态 2011-9-4　酒小龙增加
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).CopyBackOperationState(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value, domain.OperationEty.OperId.Value , domain.Reserved1);
                //        break;
                //    }
                //case "HIS212":  //回写取消手术信息--手术取消(OPERATION_CANCELED,OPERATION_NAME_CANCELED)
                //    {

                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).CopyBackOperationChancel(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value, domain.OperationEty.OperId.Value);
                //        break;
                //    }
                //case "HIS214":  //收费授权--获取该病人本次手术是否有收费权限
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetPatientTransConstsVerify(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value, domain.OperationEty.OperId.Value, domain.Reserved1, domain.OperationEty.Performedcode);
                //        break;
                //    }
                //case "HIS301"://打印上传病历文书--提交HIS相关信息
                //    {

                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetPatientEmrDocUpLoad(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value, domain.EmrDocUpLoadEty.MrClass, domain.EmrDocUpLoadEty.MrSubClass, domain.EmrDocUpLoadEty.ArchiveKey.Value.ToString(), domain.EmrDocUpLoadEty.ArchiveTimes.Value, domain.EmrDocUpLoadEty.EmrFileIndex.Value, domain.EmrDocUpLoadEty.EmrFileName);
                //        break;
                //    }
                //case "HIS302"://病人所有病历提交(无法再修改)--提交所有相关文书信息
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetPatientAllEmrDocUpLoad(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value, domain.Reserved1, domain.Reserved3);
                //        break;
                //    }
                //case "HIS601":  //2013-11-26
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).CopyBackNursingInfo(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value,null);
                //        break;
                //    }
                //case "HIS900":  //取SEMR医生信息
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetSemrUsersRec(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS901":  //取SEMR病人基本信息
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetSemrPatientsRec(doCareConfig, doCareDict,domain.PatientEty.PatientId);
                //        break;
                //    }
                //case "HIS902":  //取SEMR挂号基本信息
                //    {
                //        //if (string.IsNullOrEmpty(struInputData.patientid))
                //        //    struInputData.patientid = "ALL";
                //        //if (struInputData.startdatetime == DateTime.MinValue || struInputData.startdatetime == null)
                //        //{
                //        //    DateTime dateStart = DateTime.Now;
                //        //    struInputData.startdatetime = new DateTime(dateStart.Year, dateStart.Month, dateStart.Day, 0, 0, 0);
                //        //}
                //        //if (struInputData.stopdatetime == DateTime.MinValue || struInputData.stopdatetime == null)
                //        //{
                //        //    DateTime dateEnd = DateTime.Now.AddDays(1);
                //        //    if (string.IsNullOrEmpty(doCareDict.DoCareDayNum))
                //        //    {
                //        //        struInputData.stopdatetime = new DateTime(dateEnd.Year, dateEnd.Month, dateEnd.Day, 23, 59, 59);
                //        //    }
                //        //    else
                //        //    {
                //        //        int xi;
                //        //        if (Int32.TryParse(doCareDict.DoCareDayNum.ToString(), out xi))
                //        //            struInputData.stopdatetime = struInputData.startdatetime.AddDays(Int32.Parse(doCareDict.DoCareDayNum.ToString()));
                //        //        else
                //        //            struInputData.stopdatetime = new DateTime(dateEnd.Year, dateEnd.Month, dateEnd.Day, 23, 59, 59);
                //        //    }
                //        //}
                //        //if (struInputData.startdatetime >= struInputData.stopdatetime)
                //        //{
                //        //    DateTime dateEnd = DateTime.Now.AddDays(1);
                //        //    if (string.IsNullOrEmpty(doCareDict.DoCareDayNum))
                //        //    {
                //        //        struInputData.stopdatetime = new DateTime(dateEnd.Year, dateEnd.Month, dateEnd.Day, 23, 59, 59);
                //        //    }
                //        //    else
                //        //    {
                //        //        int xi;
                //        //        if (Int32.TryParse(doCareDict.DoCareDayNum.ToString(), out xi))
                //        //            struInputData.stopdatetime = struInputData.startdatetime.AddDays(Int32.Parse(doCareDict.DoCareDayNum.ToString()));
                //        //        else
                //        //            struInputData.stopdatetime = new DateTime(dateEnd.Year, dateEnd.Month, dateEnd.Day, 23, 59, 59);
                //        //    }
                //        //}
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetSemrMedicalcasesRec(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.BaseEty.StartDateTime.Value, domain.BaseEty.StopDateTime.Value);

                //        break;
                //    }
                //case "HIS903":  //取SEMR单患者挂号基本信息
                //    {

                //        if (string.IsNullOrEmpty(domain.PatientEty.PatientId))
                //            domain.PatientEty.PatientId = "ALL";
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetSemrOneMedicalcasesRec(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.Reserved1, domain.Reserved2);
                //        break;
                //    }

                //case "HIS999":  //自动同步一体机
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).InitANES(doCareConfig, doCareDict, domain.Reserved1);
                //        break;
                //    }
                //case "LIS001":	//检验信息
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetPatientLabTestMaster(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value);
                //        break;
                //    }
                //case "LIS002":	//使用的提取护理信息 --绍兴人民医院
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetPatientNursingDataRec(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value);
                //        break;
                //    }
                //case "CSSD001":  //同步供应室消耗品信息 -孙凯    struInputData.reserved01=Bar_Code条码号 //是否单独分类，待讨论
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetSupplyPackageRec(doCareConfig, doCareDict, domain.Reserved1);
                //        break;
                //    }
                //case "CSSD201":
                //    {
                //      //  re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).CopyBackSupplyPackageUseInfo(doCareConfig, doCareDict, struInputData.reserved01, struInputData.reserved02, struInputData.reserved03, struInputData.reserved04, struInputData.reserved05, struInputData.reserved06, struInputData.reserved07, struInputData.reserved08, struInputData.reserved09, struInputData.reserved10, struInputData.reserved11, struInputData.reserved12, struInputData.reserved14, struInputData.reserved15);
                //        break;
                //    }

                //default:
                //    re = "信息接口提示[V4版本]:该传入参数未遵循接口定义规范,请传入规范定义.--传入参数1:["; //+ strAppType + "]传入参数2:[" + strSystemClass + "]传入参数3:[" + strInterFaceType + "] 为定义";
                //    break;
            //}
            return re;
        }
        catch (Exception ex)
        {
            InitDocare.LogA.Debug("错误日志: &#xA;事件消息为: &#xA;" + ex.Message + "异常发生时，调用堆栈上的桢的字符串表现形式: &#xA;" + ex.StackTrace + "引发当前异常的函数为: &#xA;" + ex.TargetSite.Name + "导致错误的应用程序或对象的名称为: &#xA;" + ex.Source);
            return "信息接口提示[V4版本]:传入参数1:";// +strAppType + "传入参数2:" + strSystemClass + "传入参数3:" + strInterFaceType + "  错误日志:" + ex.Message;
        }
        #endregion
    }

    /// <summary>
    /// 调试-输出HelloWorld
    /// </summary>
    /// <returns></returns>
    [WebMethod(Description = "Docare医疗数据集成平台-HelloWorld调试函数")]

    public string HelloWorld()
    {
        InitDocare.LogA.Debug("测试信息: Hello World");
        return "Hello World";
    }

    /// <summary>
    /// 读出LOG日志文件 读取一天日志信息 参数 strFormat 为日期格式化为 yyyy-MM-dd 的字符串
    /// </summary>
    /// <param name="strFormat"></param>
    /// <returns></returns>
    [WebMethod(Description = "Docare医疗数据集成平台--读出LOG日志文件")]
    public string GetLogDate(string strFormat)
    {
        string strTo = "没有日志文件";
        if (File.Exists(HttpContext.Current.Server.MapPath("logs/" + strFormat.ToString() + ".txt")))
        {
            FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("logs/" + strFormat.ToString() + ".txt"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
            strTo = sr.ReadToEnd();
            sr.Close();
        }
        return strTo;
    }
}
