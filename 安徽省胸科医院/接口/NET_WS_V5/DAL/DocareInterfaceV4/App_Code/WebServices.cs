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

[WebService(Description = "Docareҽ�����ݼ���ƽ̨v4", Name = "WebServices", Namespace = "Http://ws.medicalsystem.com.cn")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
[System.Web.Script.Services.GenerateScriptType(typeof(ParmInputData))]
public class WebServices : System.Web.Services.WebService
{
    /// <summary>
    /// WebServer����
    /// </summary>
    public WebServices()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
 
    /// <summary>
    /// Ӧ�ó������ͣ�����ICU,���ֻ������� �ȵ�
    /// </summary>
    private string strAppType
    {
        get;
        set;
    }
   
    /// <summary>
    /// ����ͳһ�ӿ�DocareSysInterface
    /// </summary>
    /// <param name="strAppType">Ӧ�ó�������</param>
    /// <param name="strSystemClass">���HIS LIS��</param>
    /// <param name="strInterFaceType">����</param>
    /// <param name="struInputData">����ṹ��</param>
    /// <returns></returns>
    [WebMethod(Description = "Docareҽ�����ݼ���ƽ̨--ͳһ����ƽ̨")]
    public string DocareSysInterface(string xmlMessage) 
    {
        #region DocareSysInterfaceV4

        ParamInputDomain domain = new ParamInputDomain(xmlMessage); //ҽԺ���� //ͬһ���ܵ�һ�����. TransDict  (2����)  ����Դ��ʱд��
                                                                    // ��ҳ������transDict ������Դ , һ�����ܵ����5������
        if (!domain.ErrInfoEty.Flag)
        {
            return domain.ErrInfoEty.ErrMsg;
        }

        string re = "";
        try
        {
            InitDocare.LogA.Debug("ʱ��=" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "�����յ���ϵͳ" + domain.App + "���ݹ����ĵ�����Ϣ.��������Ϊ" + domain.Coltd + "���ӿ�����Ϊ" + domain.Code);

            if (domain.Reserved9 == "DB") ///���ݿ�ģʽ��SQLSERVER, ORACLE,
            {
                return MessageHander.GetInstance().MessageSwitch(domain).PrePareDataBase(new Config(), domain);
            }
            else if (domain.Reserved9 == "WS") ///web ����ģʽ��HL7��XML,JSON ,CDR ,
            {
                return MessageHander.GetInstance().MessageSwitch(domain).PrePareReceiveMsg(new Config(), domain);
            }

            //  return  
            //switch (domain.Code)
            //{


                //case "HIS000": //�����½
                //    re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetLoginInfo(domain.BaseEty.UserID, domain.BaseEty.Operator, domain.BaseEty.PWD);
                //    break;
                //case "HIS001":	//ͬ������
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetDeptDictRec(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS002":	//ͬ��HIS��Ա
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetHisUsersRec(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS003":  //ͬ������ֵ�
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetDiagnosisDict(doCareConfig, doCareDict);
                //        break;
                //    }

                //case "HIS006":  //ͬ����λ�ֵ�
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetBedRec(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS007":  //ͬ���۱�
                //    {
                //        if (string.IsNullOrEmpty(domain.OperationEty.Performedcode))
                //        {
                //            domain.OperationEty.Performedcode = doCareDict.DoCarePerformedcode;
                //        }
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetPriceListRec(doCareConfig, doCareDict, domain.OperationEty.Performedcode);
                //        break;
                //    }
                //case "HIS008":  //ͬ���۱�������Ϣ
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetPriceItemNameDictRec(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS009":  //ͬ��ҩƷ�ֵ���Ϣ
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetDrugDictRec(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS010":  //ͬ��ҩƷ�����ֵ���Ϣ
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetDrugNameDictRec(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS011":  //ͬ������(�Ĳ�)�ֵ���Ϣ
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetMtrlDictRec(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS012":  //ͬ��ҩƷ������(�Ĳ�)��Ӧ����Ϣ
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetMtrlSupplierCatalogRec(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS013":  //ͬ������������Ϣ
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetOperationDict(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS101":  //����ID��ͬ�������˻�����Ϣ��סԺ��Ϣ
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetPatientIDRec(doCareConfig, doCareDict,domain.PatientEty.PatientId);
                //        break;
                //    }
                //case "HIS102":  //��ȡ��ͬ�������ڿƲ���סԺ���˻�����Ϣ
                //    {
                //        if(string.IsNullOrEmpty(domain.OperationEty.Performedcode))
                //        {
                //            domain.OperationEty.Performedcode = doCareDict.DoCarePerformedcode;
                //        }
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetDeptPatientRec(doCareConfig, doCareDict, domain.OperationEty.Performedcode);
                //        break;
                //    }
                //case "HIS103":  //��ȡ������ҽ����Ϣ	
                //    {
                //        if (!domain.PatientEty.VisitId.HasValue)
                //        {
                //            return "visitid Ϊ��";
                //        }
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetIcuPatientOrdersRec(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value);
                //        break;
                //    }
                //case "HIS104":  //����סԺ��ͬ�������˻�����Ϣ��סԺ��Ϣ
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetPatientInpNoRec(doCareConfig, doCareDict, domain.PatientEty.InpNo);
                //        break;
                //    }
                //case "HIS105":  //��ȡ����������ҽ����Ϣ
                //    {

                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetIcuPatientOrdersRec(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value, domain.BaseEty.StartDateTime.Value, domain.BaseEty.StopDateTime.Value);

                //        break;
                //    }
                //case "HIS201":  //ͬ�����������ԤԼ��Ϣ�����patientidΪ�գ�ͬ�����в��ˣ�����ͬ���������ˣ�
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
                //case "HIS202":  //��д��������ԤԼ��Ϣ(OPERATION_SCHEDULE,SCHEDULED_OPERATION_NAME)--���������ǰ��������ʱ���д
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
                //case "HIS203":  //��д����������Ϣ(OPERATION_MASTER,OPERATION_NAME)--��Ҫ��ͨ
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).CopyBackOperationInformation(doCareConfig, doCareDict, DateTime.Now, DateTime.Now, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value, domain.OperationEty.ScheduleId.Value);
                //        break;
                //    }
                //case "HIS204":  //��ѯHIS���շѵ�����Ŀ�۸�
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetOnePriceListRec(doCareConfig, doCareDict, domain.Reserved1, domain.Reserved2);
                //        break;
                //    }
                //case "HIS205":  //��ѯHIS�е���ҩƷ�����Ϣ
                //    {
                //        break;
                //    }
                //case "HIS206":  //��дHIS�շ���Ŀ��������д�շ���Ϣ -- ��ʱδʹ��
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).CopyBackPatientOneTransConsts(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value, domain.OperationEty.OperId.Value);

                //        break;
                //    }
                //case "HIS207":  //��ȡHISҩƷ������Ϣ-�����Ϣ ��ӦHIS-����
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetDrugImportDetailHis(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS208":  //��ȡHIS����(�Ĳ�)������Ϣ-�����Ϣ ��ӦHIS-����
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetMtrlImportDetailHis(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS209":  //��дHIS�շ���Ŀ,һ�λ�д�������е��շ���Ϣ
                //    {
                //        if (string.IsNullOrEmpty(domain.Reserved2))
                //            domain.Reserved2 = "1";
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).CopyBackPatientAllTransConsts(doCareConfig, doCareDict, domain.OperationEty.BillAtr.Value.ToString(), domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value, domain.OperationEty.OperId.Value, 0, domain.Reserved3);
                //        break;
                //    }
                //case "HIS210":  //��Ժ�鿴����HIS�շ���ϸ
                //    {
                //        break;
                //    }
                //case "HIS211"://��д����״̬ 2011-9-4����С������
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).CopyBackOperationState(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value, domain.OperationEty.OperId.Value , domain.Reserved1);
                //        break;
                //    }
                //case "HIS212":  //��дȡ��������Ϣ--����ȡ��(OPERATION_CANCELED,OPERATION_NAME_CANCELED)
                //    {

                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).CopyBackOperationChancel(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value, domain.OperationEty.OperId.Value);
                //        break;
                //    }
                //case "HIS214":  //�շ���Ȩ--��ȡ�ò��˱��������Ƿ����շ�Ȩ��
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetPatientTransConstsVerify(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value, domain.OperationEty.OperId.Value, domain.Reserved1, domain.OperationEty.Performedcode);
                //        break;
                //    }
                //case "HIS301"://��ӡ�ϴ���������--�ύHIS�����Ϣ
                //    {

                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetPatientEmrDocUpLoad(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value, domain.EmrDocUpLoadEty.MrClass, domain.EmrDocUpLoadEty.MrSubClass, domain.EmrDocUpLoadEty.ArchiveKey.Value.ToString(), domain.EmrDocUpLoadEty.ArchiveTimes.Value, domain.EmrDocUpLoadEty.EmrFileIndex.Value, domain.EmrDocUpLoadEty.EmrFileName);
                //        break;
                //    }
                //case "HIS302"://�������в����ύ(�޷����޸�)--�ύ�������������Ϣ
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetPatientAllEmrDocUpLoad(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value, domain.Reserved1, domain.Reserved3);
                //        break;
                //    }
                //case "HIS601":  //2013-11-26
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).CopyBackNursingInfo(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value,null);
                //        break;
                //    }
                //case "HIS900":  //ȡSEMRҽ����Ϣ
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetSemrUsersRec(doCareConfig, doCareDict);
                //        break;
                //    }
                //case "HIS901":  //ȡSEMR���˻�����Ϣ
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetSemrPatientsRec(doCareConfig, doCareDict,domain.PatientEty.PatientId);
                //        break;
                //    }
                //case "HIS902":  //ȡSEMR�ҺŻ�����Ϣ
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
                //case "HIS903":  //ȡSEMR�����߹ҺŻ�����Ϣ
                //    {

                //        if (string.IsNullOrEmpty(domain.PatientEty.PatientId))
                //            domain.PatientEty.PatientId = "ALL";
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetSemrOneMedicalcasesRec(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.Reserved1, domain.Reserved2);
                //        break;
                //    }

                //case "HIS999":  //�Զ�ͬ��һ���
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).InitANES(doCareConfig, doCareDict, domain.Reserved1);
                //        break;
                //    }
                //case "LIS001":	//������Ϣ
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetPatientLabTestMaster(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value);
                //        break;
                //    }
                //case "LIS002":	//ʹ�õ���ȡ������Ϣ --��������ҽԺ
                //    {
                //        re = hospitalbaseSelect.SelectHospital(doCareDict.DoCareHisSupply).GetPatientNursingDataRec(doCareConfig, doCareDict, domain.PatientEty.PatientId, domain.PatientEty.VisitId.Value);
                //        break;
                //    }
                //case "CSSD001":  //ͬ����Ӧ������Ʒ��Ϣ -�￭    struInputData.reserved01=Bar_Code����� //�Ƿ񵥶����࣬������
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
                //    re = "��Ϣ�ӿ���ʾ[V4�汾]:�ô������δ��ѭ�ӿڶ���淶,�봫��淶����.--�������1:["; //+ strAppType + "]�������2:[" + strSystemClass + "]�������3:[" + strInterFaceType + "] Ϊ����";
                //    break;
            //}
            return re;
        }
        catch (Exception ex)
        {
            InitDocare.LogA.Debug("������־: &#xA;�¼���ϢΪ: &#xA;" + ex.Message + "�쳣����ʱ�����ö�ջ�ϵ�����ַ���������ʽ: &#xA;" + ex.StackTrace + "������ǰ�쳣�ĺ���Ϊ: &#xA;" + ex.TargetSite.Name + "���´����Ӧ�ó������������Ϊ: &#xA;" + ex.Source);
            return "��Ϣ�ӿ���ʾ[V4�汾]:�������1:";// +strAppType + "�������2:" + strSystemClass + "�������3:" + strInterFaceType + "  ������־:" + ex.Message;
        }
        #endregion
    }

    /// <summary>
    /// ����-���HelloWorld
    /// </summary>
    /// <returns></returns>
    [WebMethod(Description = "Docareҽ�����ݼ���ƽ̨-HelloWorld���Ժ���")]

    public string HelloWorld()
    {
        InitDocare.LogA.Debug("������Ϣ: Hello World");
        return "Hello World";
    }

    /// <summary>
    /// ����LOG��־�ļ� ��ȡһ����־��Ϣ ���� strFormat Ϊ���ڸ�ʽ��Ϊ yyyy-MM-dd ���ַ���
    /// </summary>
    /// <param name="strFormat"></param>
    /// <returns></returns>
    [WebMethod(Description = "Docareҽ�����ݼ���ƽ̨--����LOG��־�ļ�")]
    public string GetLogDate(string strFormat)
    {
        string strTo = "û����־�ļ�";
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
