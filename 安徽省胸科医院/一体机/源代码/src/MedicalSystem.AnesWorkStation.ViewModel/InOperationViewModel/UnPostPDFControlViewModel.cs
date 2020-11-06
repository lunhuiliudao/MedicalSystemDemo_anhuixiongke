//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      UnPostPDFControlViewModel.cs
//功能描述(Description)：    未上传文书详细洗洗
//数据表(Tables)：		    MED_POSTPDF_SHOW
//作者(Author)：             许文龙
//日期(Create Date)：        2018/08/01 14:20
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.Wpf.Message;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.Anes.CustomProject;
using MedicalSystem.Anes.Document.Documents;
using System.Drawing;
using MedicalSystem.Services;
using System.ComponentModel;
using System.IO;
using MedicalSystem.AnesWorkStation.Wpf.Controls;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel
{
    public class UnPostPDFControlViewModel : BaseViewModel
    {
        private string anesDoc = string.Empty;
        private List<MED_POSTPDF_SHOW> postPDFShowList = new List<MED_POSTPDF_SHOW>();       // 未上传文书列表信息
        private ICommand signPostPDFCommand = null;                                          // 上传单个患者的文书
        private ICommand postPDFCommand = null;                                              // 上传所有文书
        private ICommand cancelCommand = null;                                               // 取消
        private double proBarMaximum = 0.0;                                                  // 进度条最大值
        private double proBarValue = 0.0;                                                    // 进度条当前值
        private bool IsPostSuccessed = true;                                                 // 归档时，上传文书是否成功
        /// <summary>
        /// 当前是否正在归档,在使用时不要使用字段，请使用对应的属性。在修改值时需要发送消息
        /// </summary>
        private bool isPosting = false;

        /// <summary>
        /// 是否正在进行归档
        /// </summary>
        public bool IsPosting
        {
            get { return this.isPosting; }
            set
            {
                this.isPosting = value;
                if (!value)
                {
                    keyBoardMessageLock = false;
                }
                else
                {
                    // 进入归档流程后，不响应按键
                    keyBoardMessageLock = true;
                }

                this.ProBarMaximum = 0;
                this.ProBarValue = 0;
                Messenger.Default.Send<bool>(this.isPosting, EnumMessageKey.SetUnPostPDFProbarShow);
            }
        }

        /// <summary>
        /// 进度条最大值
        /// </summary>
        public double ProBarMaximum
        {
            get { return this.proBarMaximum; }
            set
            {
                this.proBarMaximum = value;
                this.RaisePropertyChanged("ProBarMaximum");
            }
        }

        /// <summary>
        /// 进度条当前值
        /// </summary>
        public double ProBarValue
        {
            get { return this.proBarValue; }
            set
            {
                this.proBarValue = value;
                this.RaisePropertyChanged("ProBarValue");
            }
        }

        /// <summary>
        /// 未上传文书列表信息
        /// </summary>
        public List<MED_POSTPDF_SHOW> PostPDFShowList
        {
            get { return this.postPDFShowList; }
            set
            {
                this.postPDFShowList = value;
                this.RaisePropertyChanged("PostPDFShowList");
            }
        }

        /// <summary>
        /// // 上传单个患者的文书
        /// </summary>
        public ICommand SignPostPDFCommand
        {
            get { return this.signPostPDFCommand; }
            set { this.signPostPDFCommand = value; }
        }

        /// <summary>
        /// 上传所有文书
        /// </summary>
        public ICommand PostPDFCommand
        {
            get { return this.postPDFCommand; }
            set { this.postPDFCommand = value; }
        }

        /// <summary>
        /// 取消
        /// </summary>
        public ICommand CancelCommand
        {
            get { return this.cancelCommand; }
            set { this.cancelCommand = value; }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="patModel">患者信息实体</param>
        /// <param name="eventNo">软件类型：麻醉=0，复苏=1</param>
        public UnPostPDFControlViewModel(string anesDoc)
        {
            this.anesDoc = anesDoc;
            this.RegisterCommand();
            this.RefreshData();
        }

        /// <summary>
        /// 在归档过程中不允许关闭窗口
        /// </summary>
        public override void OnPreviewViewUnLoaded(CancelEventArgs e)
        {
            if (this.IsPosting)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 注册命令信息
        /// </summary>
        private void RegisterCommand()
        {
            // 取消OR暂停按钮
            this.CancelCommand = new RelayCommand<object>(par =>
            {
                if (!this.IsPosting)
                {
                    this.CloseContentWindow();
                }
            });

            // 上传单个患者的文书
            this.SignPostPDFCommand = new RelayCommand<object>(par =>
            {
                if (!this.IsPosting && null != par && par is MED_POSTPDF_SHOW)
                {
                    this.IsPosting = true;
                    this.IsPostSuccessed = true;
                    this.SignPatientPostPDF(par);
                    this.RefreshData();
                    this.DeletePDF();
                    if (!this.IsPostSuccessed)
                    {
                        ConfirmMessageBox.Show("系统提示", "归档失败，请检查服务器配置",
                                        MessageBoxButton.OK, MessageBoxImage.Warning);

                    }
                    this.IsPosting = false;
                }
            });

            // 批量上传所有文书
            this.PostPDFCommand = new RelayCommand<object>(par =>
            {
                if (!IsPosting)
                {
                    this.IsPosting = true;
                    this.IsPostSuccessed = true;
                    this.AllPatientPostPDF();
                    this.RefreshData();
                    this.DeletePDF();
                    this.IsPosting = false;
                    if (!this.IsPostSuccessed)
                    {
                        ConfirmMessageBox.Show("系统提示", "归档失败，请检查服务器配置",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        // 批量归档后 自动关闭窗口
                        this.CloseContentWindow();
                    }
                }
            });
        }

        /// <summary>
        /// 所有患者文书批量归档
        /// </summary>
        private void AllPatientPostPDF()
        {
            // 计算进度条总量
            this.PostPDFShowList.ForEach(item =>
            {
                if (!string.IsNullOrEmpty(item.NO_EXIST_DOCNAMES))
                {
                    List<string> noExistPostDocnames = item.NO_EXIST_DOCNAMES.Split(new char[] { ',' },
                                                       StringSplitOptions.RemoveEmptyEntries).ToList();
                    this.ProBarMaximum += noExistPostDocnames.Count;
                }
            });

            while (this.PostPDFShowList.Count > 0)
            {
                this.SignPatientPostPDF(this.PostPDFShowList[0]);
                this.PostPDFShowList.RemoveAt(0);
            }
        }

        /// <summary>
        /// 单个患者的PDF归档
        /// </summary>
        private void SignPatientPostPDF(object par)
        {
            MED_PAT_INFO curPat = ExtendAppContext.Current.PatientInformationExtend;
            try
            {
                MED_POSTPDF_SHOW temp = par as MED_POSTPDF_SHOW;

                // 加载文书时涉及到全局缓存，需要重新设置
                ExtendAppContext.Current.PatientInformationExtend = new MED_PAT_INFO() { PATIENT_ID = temp.PATIENT_ID, VISIT_ID = temp.VISIT_ID, OPER_ID = temp.OPER_ID };

                if (string.IsNullOrEmpty(temp.NO_EXIST_DOCNAMES))
                {
                    return;
                }

                List<string> noExistPostDocnames = temp.NO_EXIST_DOCNAMES.Split(new char[] { ',' },
                                                       StringSplitOptions.RemoveEmptyEntries).ToList();

                if (this.ProBarMaximum == 0)
                {
                    this.ProBarMaximum = noExistPostDocnames.Count;
                }

                foreach (string item in noExistPostDocnames)
                {
                    // 等待刷新界面
                    ExtendAppContext.Current.Sleep(1000);
                    this.PostPDF(item);
                }
            }
            catch
            {
            }
            finally
            {
                ExtendAppContext.Current.PatientInformationExtend = curPat;
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        private void DeletePDF()
        {
            try
            {
                if (ApplicationConfiguration.IsDeleteAfterCommitDoc)
                {
                    ExtendAppContext.Current.Sleep(1000);
                    string strURL = ApplicationConfiguration.PDFLocalUrl;
                    Directory.GetFiles(strURL).ToList().ForEach(File.Delete);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 响应按键事件
        /// </summary>
        protected override void KeyBoardMessage(string keyCode)
        {
            switch (keyCode)
            {
                case MedicalSystem.Anes.FrameWork.KeyCode.AppCode.Back:
                    if (!IsPosting)
                    {
                        this.CloseContentWindow();
                    }
                    break;
            }
        }

        /// <summary>
        /// 刷新主表数据
        /// </summary>
        private void RefreshData()
        {
            List<MED_POSTPDF_SHOW> result = new List<MED_POSTPDF_SHOW>();
            List<MED_POSTPDF_SHOW> tempList = AnesInfoService.ClientInstance.GetPostPDFShowList(this.anesDoc);
            string NeedPostPDF = ApplicationConfiguration.PostPDF_Names;
            List<string> needPostPDFList = NeedPostPDF.Split(new char[] { ',' },
                                                           StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> existDocNamesList = new List<string>();
            List<string> noExistDocNamesList = new List<string>();
            tempList.ForEach(item =>
            {
                existDocNamesList.Clear();
                noExistDocNamesList.Clear();

                if (!string.IsNullOrEmpty(item.EXIST_DOCNAMES))
                {
                    existDocNamesList = item.EXIST_DOCNAMES.Split(new char[] { ',' },
                                                                  StringSplitOptions.RemoveEmptyEntries).ToList();
                }

                if (null == existDocNamesList || existDocNamesList.Count == 0)
                {
                    // 一张文书都没有上传
                    noExistDocNamesList.AddRange(needPostPDFList);
                }
                else if (null != existDocNamesList && existDocNamesList.Count > 0)
                {
                    // 上传了部分文书
                    needPostPDFList.ForEach(row =>
                    {
                        if (!existDocNamesList.Contains(row))
                        {
                            noExistDocNamesList.Add(row);
                        }
                    });
                }

                if (noExistDocNamesList.Count > 0)
                {
                    item.NO_EXIST_DOCNAMES = string.Join(",", noExistDocNamesList);
                    result.Add(item);
                }
            });

            // 更新序号
            for (int i = 0; i < result.Count; i++)
            {
                result[i].ROWNUM = i + 1;
            }

            this.PostPDFShowList = result;
        }

        /// <summary>
        /// 上传文书
        /// </summary>
        private void PostPDF(object docName)
        {
            // 减少资源消耗，每次加载文书前都手动释放资源
            GC.Collect();
            GC.Collect();

            string strCurDocName = ExtendAppContext.Current.CurrentDocName;
            try
            {
                ApplicationConfiguration.MedicalDocucementElement document = ApplicationConfiguration.GetMedicalDocument(docName.ToString());
                Type t = Type.GetType(document.Type);
                using (BaseDoc baseDoc = Activator.CreateInstance(t) as BaseDoc)
                {
                    baseDoc.BackColor = Color.White;
                    baseDoc.Name = docName.ToString();
                    ExtendAppContext.Current.CurrentDocName = baseDoc.Name;
                    baseDoc.HideScrollBar();
                    baseDoc.Initial();
                    baseDoc.LoadReport(ExtendAppContext.Current.AppPath + document.Path);
                    baseDoc.SingPostPDFNoMsgbox();
                    if (this.IsPostSuccessed)// 保证有一张文书失败就是上传失败
                    {
                        this.IsPostSuccessed = baseDoc.IsPostSuccessed; // 文书上传失败的话,可以得提示
                    }
                    this.ProBarValue = this.ProBarValue + 1;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("文书批量归档错误", ex);
            }
            finally
            {
                GC.Collect();
                GC.Collect();
            }

            // 重置当前文书名称
            ExtendAppContext.Current.CurrentDocName = strCurDocName;
        }
    }
}
