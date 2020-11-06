using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.MonitorBindViewModel
{
    public class MonitorBindViewModel : BaseViewModel
    {

        /// <summary>
        /// 构造方法
        /// </summary>
        public MonitorBindViewModel()
        {
            // 载入字典数据
            LoadDictData();
        }

        #region 界面绑定相关字段

        private string _OPER_ROOM_NO;                                              // 手术间号
        private Nullable<Int32> _SEQUENCE;                                         // 台次
        private string _PATIENT_ID;                                                // 患者ID
        private string _INP_NO;                                                    // 住院号
        private string _NAME;                                                      // 姓名
        private string _SEX;                                                       // 性别
        private Nullable<DateTime> _DATE_OF_BIRTH;                                 // 出生日期
        private string _AGE;                                                          // 年龄
        private string _BED_NO;                                                    // 床号

        /// <summary>
        /// 手术间号
        /// </summary>
        public string OPER_ROOM_NO
        {
            get
            {
                return _OPER_ROOM_NO;
            }
            set
            {
                this._OPER_ROOM_NO = value;
                RaisePropertyChanged("OPER_ROOM_NO");
            }
        }
        /// <summary>
        /// 台次
        /// </summary>
        public Nullable<Int32> SEQUENCE
        {
            get
            {
                return _SEQUENCE;
            }
            set
            {
                this._SEQUENCE = value;
                RaisePropertyChanged("SEQUENCE");
            }
        }
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PATIENT_ID
        {
            get
            {
                return _PATIENT_ID;
            }
            set
            {
                this._PATIENT_ID = value;
                RaisePropertyChanged("PATIENT_ID");
            }
        }
        /// <summary>
        /// 住院号
        /// </summary>
        public string INP_NO
        {
            get
            {
                return _INP_NO;
            }
            set
            {
                this._INP_NO = value;
                RaisePropertyChanged("INP_NO");
            }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string NAME
        {
            get
            {
                return _NAME;
            }
            set
            {
                this._NAME = value;
                RaisePropertyChanged("NAME");
            }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string SEX
        {
            get
            {
                return _SEX;
            }
            set
            {
                this._SEX = value;
                RaisePropertyChanged("SEX");
            }
        }
        /// <summary>
        /// 出生年月
        /// </summary>
        public Nullable<DateTime> DATE_OF_BIRTH
        {
            get
            {
                //AGE = DateTime.Now.Year - DATE_OF_BIRTH.Value.Year;
                return _DATE_OF_BIRTH;
            }
            set
            {
                this._DATE_OF_BIRTH = value;
                RaisePropertyChanged("DATE_OF_BIRTH");
            }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public string AGE
        {
            get { return _AGE; }
            set
            {
                _AGE = value;
                RaisePropertyChanged("AGE");
            }
        }
        /// <summary>
        /// 床号
        /// </summary>
        public string BED_NO
        {
            get
            {
                return _BED_NO;
            }
            set
            {
                this._BED_NO = value;
                RaisePropertyChanged("BED_NO");
            }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 载入数据
        /// </summary>
        public override void LoadData()
        {
            OPER_ROOM_NO = ExtendAppContext.Current.PatientInformationExtend.OPER_ROOM_NO;
            SEQUENCE = ExtendAppContext.Current.PatientInformationExtend.SEQUENCE;
            PATIENT_ID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
            INP_NO = ExtendAppContext.Current.PatientInformationExtend.INP_NO;
            NAME = ExtendAppContext.Current.PatientInformationExtend.NAME;
            SEX = ExtendAppContext.Current.PatientInformationExtend.SEX;
            DATE_OF_BIRTH = ExtendAppContext.Current.PatientInformationExtend.DATE_OF_BIRTH;
            BED_NO = ExtendAppContext.Current.PatientInformationExtend.BED_NO;
        }

        /// <summary>
        /// 保存患者信息
        /// </summary>
        protected override SaveResult SaveData()
        {
            bool result = true;
            SaveResult saveResult = SaveResult.Fail;
            if (MONITORDICT != null && MONITORDICT.Count > 0)
            {
                foreach (MED_MONITOR_DICT row in MONITORDICT)
                {
                    row.PATIENT_ID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
                    row.VISIT_ID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
                    row.OPER_ID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
                    row.ModelStatus = ModelStatus.Modeified;

                    // 自动启动监护仪
                    if (!string.IsNullOrEmpty(row.DRIVER_PROG)) //采集程序名称DRIVER_PROG
                    {
                        string strPath = ExtendAppContext.Current.AppPath + row.DRIVER_PROG;
                        if (!File.Exists(strPath))
                        {
                            ShowMessageBox("未找到采集程序，请确保采集程序存在根目录下！");
                            continue;
                        }
                        bool hasStart = false;
                        // 获取当前启动的所有进程
                        string strProcessName = row.DRIVER_PROG.Substring(0, row.DRIVER_PROG.ToLower().IndexOf(".exe"));
                        Process[] myProgress = Process.GetProcessesByName(strProcessName);
                        // 查看采集EXE是否启动
                        foreach (Process p in myProgress)
                        {
                            if (p.ProcessName.Equals(strProcessName))
                            {
                                hasStart = true;
                                break;
                            }
                        }

                        // 进程没有启动同时采集EXE必须存在
                        if (!hasStart && File.Exists(strPath))
                        {
                            Process.Start(strPath);
                        }
                    }
                }
                result = DictService.ClientInstance.UpdateMonitorDict(MONITORDICT);
            }
            if (result)
                saveResult = SaveResult.Success;
            return saveResult;
        }

        #endregion

        #region 命令

        /// <summary>
        /// 保存或下一步
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    SaveData();
                });
            }
        }

        /// <summary>
        /// 重置或上一步
        /// </summary>
        public ICommand CancelCommand
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    this.CloseContentWindow();
                });
            }
        }


        #endregion

    }
}
