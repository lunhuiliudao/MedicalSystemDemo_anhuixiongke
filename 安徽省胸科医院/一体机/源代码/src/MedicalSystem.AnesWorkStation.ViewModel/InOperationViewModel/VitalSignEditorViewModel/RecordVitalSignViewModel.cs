//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      RecordVitalSignViewModel.cs
//功能描述(Description)：    体征录入界面ViewMode
//数据表(Tables)：		    MED_VITAL_SIGN 
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 09:30
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model.InOperationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel
{
    public class RecordVitalSignViewModel : BaseViewModel
    {
        private DateTime startTime;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime
        {
            get
            {
                if (startTime != null)
                    startTime = startTime.Date.AddHours(startTime.Hour).AddMinutes(startTime.Minute);
                return startTime;
            }
            set
            {
                startTime = value;
                this.RaisePropertyChanged("StartTime");
            }
        }
        private DateTime endTime;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime
        {
            get
            {
                if (endTime != null)
                    endTime = endTime.Date.AddHours(endTime.Hour).AddMinutes(endTime.Minute);
                return endTime;
            }
            set
            {
                endTime = value;
                this.RaisePropertyChanged("EndTime");
            }
        }
        private List<RecordVitalSignModel> _recordPoints;

        public List<RecordVitalSignModel> RecordPoints
        {
            get { return _recordPoints; }
            set
            {
                _recordPoints = value;
                this.RaisePropertyChanged("RecordPoints");
            }
        }
        private Dictionary<int, string> rowDict;

        private List<MED_VITAL_SIGN> SelectColumsItems;

        public RecordVitalSignViewModel()
        {

        }

        /// <summary>
        /// 加载参数
        /// </summary>
        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            rowDict = (Dictionary<int, string>)Args[0];
            SelectColumsItems = (List<MED_VITAL_SIGN>)Args[1];
        }

        /// <summary>
        /// 载入数据
        /// </summary>
        public override void LoadData()
        {
            if (SelectColumsItems != null && SelectColumsItems.Count > 0)
            {
                StartTime = SelectColumsItems[0].TIME_POINT;
            }
            else
            {   // 获取开始时间
                if (ExtendAppContext.Current.PatientInformationExtend.IN_DATE_TIME.HasValue)
                    StartTime = GetFiveMinuteTime(ExtendAppContext.Current.PatientInformationExtend.IN_DATE_TIME.Value);
                else
                    StartTime = GetFiveMinuteTime(DateTime.Now);
            }
            //设置结束时间
            EndTime = startTime.AddMinutes(10);
            List<RecordVitalSignModel> points = new List<RecordVitalSignModel>();
            List<MED_PAT_MONITOR_DATA_DICT> alarmList = DictService.ClientInstance.GetPatMonitorDict();
            if (rowDict.Count > 0)
            {
                for (int i = 0; i < rowDict.Count; i++)
                {
                    if (!string.IsNullOrEmpty(rowDict[i]))
                    {
                        //添加项目
                        RecordVitalSignModel point = new RecordVitalSignModel();
                        point.ItemCode = rowDict[i];
                        point.ItemName = ExtendAppContext.Current.MonitorFunctionCodeDict.ContainsKey(rowDict[i]) ? ExtendAppContext.Current.MonitorFunctionCodeDict[rowDict[i]] : rowDict[i];
                        MED_PAT_MONITOR_DATA_DICT alarm = alarmList.Where(x => x.DB_DATA_NAME == rowDict[i]).FirstOrDefault();
                        //体征界面选择数据设置为默认数据
                        if (SelectColumsItems != null && SelectColumsItems.Count > 0)
                        {
                            MED_VITAL_SIGN signRow = SelectColumsItems.Where(x => x.ITEM_CODE == rowDict[i]).FirstOrDefault();
                            if (signRow != null) point.RecordValue = signRow.ITEM_VALUE;
                        }
                        if (alarm != null)
                            point.WamingValue = alarm.LOW_SIGNS_VALUES + "-" + alarm.HIGH_SIGNS_VALUES;

                        points.Add(point);
                    }
                }
            }
            RecordPoints = points;
        }

        /// <summary>
        /// 检查数据有效
        /// </summary>
        /// <returns></returns>
        protected override bool CheckData()
        {
            bool result = false;

            foreach (var item in _recordPoints)
            {
                if (item.RecordValue != null)
                {
                    result = true;
                    break;
                }
            }
            if (!result)
            {
                ShowMessageBox("请先输入体征数据。", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return result;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        protected override SaveResult SaveData()
        {
            this.Result = new { sTime = startTime, eTime = endTime, points = _recordPoints };
            Messenger.Default.Send<object>(this.Result, "RecordCommand");
            return SaveResult.Success;
        }

        /// <summary>
        /// 获取时间点每5分钟
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private DateTime GetFiveMinuteTime(DateTime source)
        {
            DateTime dateTime = Convert.ToDateTime(source.ToString("yyyy-MM-dd HH:mm"));
            int minute = dateTime.Minute;
            while (minute % 5 != 0)
            {
                dateTime = dateTime.AddMinutes(1);
                minute = dateTime.Minute;
            }
            return dateTime;
        }
        /// <summary>
        /// 补录体征发送消息
        /// </summary>
        public ICommand RecordCommand
        {
            get
            {
                return new RelayCommand<object>(data =>
                {
                    PublicKeyBoardMessage(KeyCode.AppCode.Save);
                });
            }
        }
    }
}
