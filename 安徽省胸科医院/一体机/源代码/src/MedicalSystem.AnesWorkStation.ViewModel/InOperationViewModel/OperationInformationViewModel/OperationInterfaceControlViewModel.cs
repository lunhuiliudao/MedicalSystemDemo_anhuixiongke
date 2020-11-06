/*******************************************************************
 * 文件名称(File Name)：      OperationInterfaceControlViewModel.cs
 * 功能描述(Description)：    第三方接口动态链接访问
 * 数据表(Tables)：		
 * 作者(Author)：             许文龙 
 * 日期(Create Date)：        2018-09-14 10:49:12
 * R1:
 *    修改作者:
 *    修改日期:
 *    修改理由:
 *******************************************************************/
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.ViewModel.Cache;
using MedicalSystem.Services;
using MedicalSystem.UsbKeyBoard;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel
{
    public class OperationInterfaceControlViewModel : BaseViewModel
    {
        private ICommand selectionChangedCommand;                         // ListBox.SelectionChanged事件命令
        private List<MED_INTERFACE_DETAIL> interfaceDetailList;           // 第三方链接配置信息
        private MED_OPERATION_MASTER operMaster;                          // 主表信息
        private MED_PAT_MASTER_INDEX patMasterIndex;                      // 患者基本信息
        private MED_PAT_VISIT patVisit;                                   // 住院记录
        private MED_PATS_IN_HOSPITAL patsInHospital;                      // 住院记录
        private List<object> dataSourceList = new List<object>();         // 数据源列表
        private bool hasClose = false;
        private dynamic argsPar;                                          // 初始化时传过来的参数

        /// <summary>
        /// ListBox 切换选中项事件命令
        /// </summary>
        public ICommand SelectionChangedCommand
        {
            get { return this.selectionChangedCommand; }
            set { this.selectionChangedCommand = value; }
        }

        /// <summary>
        /// 第三方链接配置信息
        /// </summary>
        public List<MED_INTERFACE_DETAIL> InterfaceDetailList
        {
            get { return this.interfaceDetailList; }
            set
            {
                this.interfaceDetailList = value;
                this.RaisePropertyChanged("InterfaceDetailList");
            }
        }

        /// <summary>
        /// 无参构造
        /// </summary>
        public OperationInterfaceControlViewModel()
        {
            this.RegisterMessage();
            this.InterfaceDetailList = CommonService.ClientInstance.GetInterfaceDetail().
                                                                    Where(x => x.INT_ENABLE == 1).ToList();
            new DelegateCommonObject.DelegateMethod(this.GetPatInfoData).BeginInvoke(null, null);
        }

        /// <summary>
        /// 重写加载
        /// </summary>
        public override void OnViewLoaded()
        {
            try
            {
                base.OnViewLoaded();
                if (Args != null)
                {
                    argsPar = Args[0];
                    this.SelectionChangedCommand.Execute(argsPar);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("第三方接口链接加载异常", ex);
                ShowMessageBox(ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// 获取基本数据表
        /// </summary>
        private void GetPatInfoData()
        {
            string patientID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
            int visitID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
            int operID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
            if (null == this.operMaster)
            {
                this.operMaster = AnesInfoService.ClientInstance.GetOperationMaster(patientID, visitID, operID);
                this.dataSourceList.Add(this.operMaster);
            }

            if (null == this.patMasterIndex)
            {
                this.patMasterIndex = AnesInfoService.ClientInstance.GetPatMasterIndex(patientID).FirstOrDefault();
                this.dataSourceList.Add(this.patMasterIndex);
            }

            if (null == this.patVisit)
            {
                this.patVisit = CareDocService.ClientInstance.GetPatVisit(patientID, visitID);
                this.dataSourceList.Add(this.patVisit);
            }

            if (null == this.patsInHospital)
            {
                this.patsInHospital = AnesInfoService.ClientInstance.GetPatsInHospitalList(patientID, visitID).FirstOrDefault();
                this.dataSourceList.Add(this.patsInHospital);
            }
        }

        /// <summary>
        /// 注册消息
        /// </summary>
        private void RegisterMessage()
        {
            // 切换选中项命令
            this.SelectionChangedCommand = new RelayCommand<object>(key =>
            {
                if (key != null && key is MED_INTERFACE_DETAIL)
                {
                    this.GetPatInfoData();
                    this.hasClose = true;
                    MED_INTERFACE_DETAIL curInter = key as MED_INTERFACE_DETAIL;
                    string strAddress = curInter.INT_ADDRESS;
                    string[] pars = curInter.INT_PARAMETERS.Split(new string[] { "," }, 
                                                                    StringSplitOptions.RemoveEmptyEntries);
                    List<string> parValues = new List<string>();
                    foreach(string par in pars)
                    {
                        foreach(object obj in this.dataSourceList)
                        {
                            bool hasFind = false;
                            foreach(PropertyInfo pro in obj.GetType().GetProperties())
                            {
                                if(pro.Name.Equals(par))
                                {
                                    object value = pro.GetValue(obj, null);
                                    parValues.Add(value.ToString());
                                    hasFind = true;
                                    break;
                                }
                            }

                            if(hasFind)
                            {
                                break;
                            }
                        }
                    }

                    int index = 0;
                    while (strAddress.IndexOf("{" + index + "}") > -1)
                    {
                        strAddress = strAddress.Replace("{" + index + "}", parValues[index]);
                        index++;
                    }

                    if (curInter.INT_TYPE == 1)
                    {
                        // 网页
                        Process.Start(strAddress);
                    }
                    else if (curInter.INT_TYPE == 2)
                    {
                        // 进程
                        Process p = new Process();
                        //设置要启动的应用程序
                        p.StartInfo.FileName = "cmd.exe";
                        //是否使用操作系统shell启动
                        p.StartInfo.UseShellExecute = false;
                        // 接受来自调用程序的输入信息
                        p.StartInfo.RedirectStandardInput = true;
                        //输出信息
                        p.StartInfo.RedirectStandardOutput = true;
                        // 输出错误
                        p.StartInfo.RedirectStandardError = true;
                        //不显示程序窗口
                        p.StartInfo.CreateNoWindow = true;
                        //启动程序
                        p.Start();
 
                        //向cmd窗口发送输入信息
                        p.StandardInput.WriteLine(strAddress+"&exit");
                        p.StandardInput.AutoFlush=true;
                    }
                    
                    this.CloseContentWindow();
                }
            });
        }
      
        /// <summary>
        /// 丢失焦点时关闭窗口
        /// </summary>
        public override void Control_LostFocus(object sender, EventArgs e)
        {
            if (!this.hasClose)
            {
                base.Control_LostFocus(sender, e);
                this.CloseContentWindow();
            }
        }

        /// <summary>
        /// 卸载窗口说明：菜单栏是在执行调用文书后再关闭
        /// 导致卸载时会将AppCodeStack中的值移除不对。所以在这特殊处理
        /// </summary>
        public override void OnViewUnLoaded()
        {
            List<string> tempStackList = KeyBoardStateCache.AppCodeStack.ToList();
            tempStackList.Remove(AppCode.Interface);

            // 去除所有
            while (KeyBoardStateCache.AppCodeStack.Count > 0)
            {
                KeyBoardStateCache.AppCodeStack.Pop();
            }

            // 重新插入
            tempStackList.ForEach(x =>
            {
                KeyBoardStateCache.AppCodeStack.Push(x);
            });

            Messenger.Default.Unregister<dynamic>(this);
            UnRegisterKeyBoardMessage();
        }
    }
}
