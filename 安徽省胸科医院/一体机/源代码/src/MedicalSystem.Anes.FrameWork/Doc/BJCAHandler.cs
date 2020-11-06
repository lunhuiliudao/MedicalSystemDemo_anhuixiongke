
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MedicalSystem.Anes.FrameWork.Doc
{
    public class BJCAHandler : UIElementHandler<BJCAControl>
    {
        /// <summary>
        /// 将源数据绑定到控件上
        /// </summary>
        public override void BindDataToUI(BJCAControl control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            if (!dataSources.ContainsKey("MED_BJCA_SIGN") || null == dataSources["MED_BJCA_SIGN"])
            {
                return;
            }

            DataTable caDt = dataSources["MED_BJCA_SIGN"];
            DataRow[] rows = caDt.Select(string.Format("CONTROLID='{0}'", control.Name));
            // 显示最后一条签名
            if(rows.Length > 0)
            {
                control.LoadImage(rows[0]);
            }
        }

        /// <summary>
        /// 绑定控件内容到数据源
        /// </summary>
        public override void BindUIToData(BJCAControl control, Dictionary<string, System.Data.DataTable> dataSources)
        {

        }

        /// <summary>
        /// 添加事件绑定
        /// </summary>
        public override void ControlSetting(BJCAControl caControl)
        {
            caControl.OnCustomSave += this.OnCustomSave;
            caControl.OnCustomDelete += this.OnCustomDelete;
        }

        /// <summary>
        /// 保存CA数据
        /// </summary>
        private void OnCustomSave(object sender, EventArgs e)
        {
            if(sender is MED_BJCA_SIGN)
            {
                MED_BJCA_SIGN curCA = sender as MED_BJCA_SIGN;

                string patientId = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
                int visitId = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
                int operId = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;

                // 获取最新的CA数据
                curCA.PATIENT_ID = patientId;
                curCA.VISIT_ID = visitId;
                curCA.OPER_ID = operId;
                curCA.SIGNDOCNAME = ExtendAppContext.Current.CurrentDocName;
                curCA.SIGNDATE = CommonService.ClientInstance.GetServerTime();
                curCA.ModelStatus = AnesWorkStation.Domain.ModelStatus.Add;
                CareDocService.ClientInstance.SaveBjcaSign(curCA);
            }
        }

        private void OnCustomDelete(object sender, EventArgs e)
        {
            try
            {
                if (sender is BJCAControl)
                {
                    BJCAControl ca = sender as BJCAControl;
                    string patientId = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
                    int visitId = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
                    int operId = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;

                    List<MED_BJCA_SIGN> caList = CareDocService.ClientInstance.GetBjcaSignList(patientId, visitId, operId, ExtendAppContext.Current.CurrentDocName);

                    List<MED_BJCA_SIGN> temp = caList.Where(x => x.CONTROLID.Equals(ca.Name) &&
                                                                 x.SIGNNAME.Equals(ca.CertName) &&
                                                                 x.CERTSN.Equals(ca.CertSN)).ToList();

                    if (temp.Count > 0)
                    {
                        temp.ForEach(x =>
                        {
                            x.ModelStatus = AnesWorkStation.Domain.ModelStatus.Deleted;
                        });

                        CareDocService.ClientInstance.UpdateBjcaSignList(temp);
                        ca.ClearPic();
                        MessageBox.Show("签名信息删除成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }

                }
            }
            catch(Exception ex)
            {
                Logger.Error("删除签名图片异常", ex);
                MessageBox.Show("删除签名图片异常", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
