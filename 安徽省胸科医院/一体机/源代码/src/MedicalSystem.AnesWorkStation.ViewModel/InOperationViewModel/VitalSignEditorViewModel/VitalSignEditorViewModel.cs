//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      VitalSignEditorViewModel.cs
//功能描述(Description)：    补录体征ViewModel
//数据表(Tables)：		    MED_VITAL_SIGN
//                          MED_MONITOR_FUNCTION_CODE
//                          MED_PAT_MONITOR_DATA_EXT
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
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.Model.InOperationModel;
using MedicalSystem.AnesWorkStation.Wpf.Message;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel
{
    public class VitalSignEditorViewModel : BaseViewModel
    {
        private string _patientID;
        private int _visitID;
        private int _operID;
        private string _eventNo;
        /// <summary>
        /// 列
        /// </summary>
        private Dictionary<int, DateTime> columnDict;
        /// <summary>
        /// 行
        /// </summary>
        private Dictionary<int, string> rowDict;

        private ObservableCollection<dynamic> vitalSignSource;
        public ObservableCollection<dynamic> VitalSignSource
        {
            get { return vitalSignSource; }
            set
            {
                vitalSignSource = value;
                this.RaisePropertyChanged("VitalSignSource");
            }
        }
        private dynamic selectDataGridItem;

        private dynamic SelectDataGridItem
        {
            get { return selectDataGridItem; }
            set
            {
                selectDataGridItem = value;
                this.RaisePropertyChanged("SelectDataGridItem");
            }
        }
        private List<MED_VITAL_SIGN> selectColumsItems = new List<MED_VITAL_SIGN>();

        public List<MED_VITAL_SIGN> SelectColumsItems
        {
            get { return selectColumsItems; }
            set
            {
                selectColumsItems = value;
                this.RaisePropertyChanged("SelectColumsItems");
            }
        }

        public VitalSignEditorViewModel()
        {
            if (ExtendAppContext.Current.PatientInformationExtend == null)
                return;
            _patientID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
            _visitID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
            _operID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
            _eventNo = ExtendAppContext.Current.EventNo;

            List<MED_MONITOR_FUNCTION_CODE> monitorCodeList = ApplicationModel.Instance.AllDictList.MonitorFuctionCodeList;
            foreach (MED_MONITOR_FUNCTION_CODE codeRow in monitorCodeList)
            {
                if (!ExtendAppContext.Current.MonitorFunctionCodeDict.ContainsKey(codeRow.ITEM_CODE))
                {
                    ExtendAppContext.Current.MonitorFunctionCodeDict.Add(codeRow.ITEM_CODE, codeRow.ITEM_NAME);
                }
            }
            GetVitalSignData();
        }

        /// <summary>
        /// 组装体征数据
        /// </summary>
        public void GetVitalSignData()
        {
            ObservableCollection<dynamic> dataSource = new ObservableCollection<dynamic>();
            List<MED_VITAL_SIGN> vitalSignDataTable = AnesInfoService.ClientInstance.GetVitalSignData(_patientID, _visitID, _operID, _eventNo, false);
            string[] rowName = AnesInfoService.ClientInstance.GetVitalSignTitles(_patientID, _visitID, _operID, _eventNo, ExtendAppContext.Current.PatientInformationExtend.OPER_ROOM_NO);
            // 从med_pat_monitor_data_ext表获取体征数据
            List<MED_PAT_MONITOR_DATA_EXT> patMonitorDataExt = AnesInfoService.ClientInstance.GetPatMonitorExtListByEvent(_patientID, _visitID, _operID, _eventNo);

            rowDict = new Dictionary<int, string>();
            if (rowName != null)//组装对应体征项目Code
            {
                int i = 0;
                foreach (string item in rowName)
                {
                    if (!rowDict.ContainsKey(i))
                    {
                        rowDict.Add(i, item);
                        i++;
                    }
                }
            }

            columnDict = new Dictionary<int, DateTime>();
            int columnID = 0;
            if (vitalSignDataTable != null && vitalSignDataTable.Count > 0)  //组装对应时间列
            {
                DateTime vStartTime = vitalSignDataTable[0].TIME_POINT;
                DateTime vEndTime = vitalSignDataTable[vitalSignDataTable.Count - 1].TIME_POINT;
                if (vStartTime.Minute % 5 != 0)
                {
                    vStartTime = DateTimeEqual(vStartTime);
                }
                while (vStartTime <= vEndTime)
                {
                    DateTime columnName = vStartTime;
                    if (!columnDict.ContainsValue(columnName))
                    {
                        //columnDict.Add(columnID, columnName);
                        //columnID++;

                        // 从med_pat_monitor_data_ext表获取体征数据，DATA_MARK == 0 表示删除数据
                        if (!patMonitorDataExt.Exists(x => x.DATA_MARK == 0 && x.TIME_POINT == vStartTime))
                        {
                            columnDict.Add(columnID, columnName);
                            columnID++;
                        }
                    }
                    vStartTime = vStartTime.AddMinutes(5);
                }
            }
            //避免监护仪漏采的情况将对应每5分钟一格时间点重新加进去
            foreach (MED_VITAL_SIGN row in vitalSignDataTable)
            {
                if (row.TIME_POINT.Minute % 5 == 0)
                {
                    DateTime columnName = row.TIME_POINT;
                    if (!columnDict.ContainsValue(columnName))
                    {
                        //columnDict.Add(columnID, columnName);
                        //columnID++;

                        // 从med_pat_monitor_data_ext表获取体征数据，DATA_MARK == 0 表示删除的数据，也就是不显示的数据
                        if (!patMonitorDataExt.Exists(x => x.DATA_MARK == 0 && x.TIME_POINT == row.TIME_POINT))
                        {
                            columnDict.Add(columnID, columnName);
                            columnID++;
                        }
                    }
                }
            }
            for (int i = 0; i < rowName.Length; i++)
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                for (int j = 0; j < columnDict.Count + 2; j++)
                {
                    if (j == 0)//第一列Code隐藏
                    {
                        MED_VITAL_SIGN row = new MED_VITAL_SIGN();
                        row.ITEM_NAME = ExtendAppContext.Current.MonitorFunctionCodeDict.ContainsKey(rowDict[i]) ? ExtendAppContext.Current.MonitorFunctionCodeDict[rowDict[i]] : rowDict[i];
                        row.ITEM_CODE = rowDict[i];
                        row.ITEM_VALUE = rowDict[i];
                        row.IsReadOnlyColumn = true;
                        row.IsShowColumn = false;
                        dict.Add("CODE", row);
                    }
                    else if (j == 1)//第二列项目名称
                    {
                        MED_VITAL_SIGN row = new MED_VITAL_SIGN();
                        row.ITEM_NAME = ExtendAppContext.Current.MonitorFunctionCodeDict.ContainsKey(rowDict[i]) ? ExtendAppContext.Current.MonitorFunctionCodeDict[rowDict[i]] : rowDict[i];
                        row.ITEM_CODE = rowDict[i];
                        row.ITEM_VALUE = ExtendAppContext.Current.MonitorFunctionCodeDict.ContainsKey(rowDict[i]) ? ExtendAppContext.Current.MonitorFunctionCodeDict[rowDict[i]] : rowDict[i];
                        row.IsReadOnlyColumn = true;
                        row.IsShowColumn = true;
                        dict.Add("项目", row);
                    }
                    else
                    {
                        //第三列开始为每个时间点
                        MED_VITAL_SIGN row = vitalSignDataTable.Where(x => x.TIME_POINT == columnDict[j - 2] && x.ITEM_CODE == rowDict[i]).LastOrDefault();
                        if (row != null)
                        {
                            row.IsReadOnlyColumn = false;
                            row.IsShowColumn = true;
                            dict.Add(columnDict[j - 2].ToString("yyyy-MM-dd HH:mm"), row);
                        }
                        else
                        {
                            row = new MED_VITAL_SIGN();
                            row.ITEM_CODE = rowDict[i];
                            row.ITEM_NAME = ExtendAppContext.Current.MonitorFunctionCodeDict.ContainsKey(rowDict[i]) ? ExtendAppContext.Current.MonitorFunctionCodeDict[rowDict[i]] : rowDict[i];
                            row.TIME_POINT = columnDict[j - 2];
                            row.IsReadOnlyColumn = false;
                            row.IsShowColumn = true;
                            dict.Add(columnDict[j - 2].ToString("yyyy-MM-dd HH:mm"), row);
                        }
                    }
                }
                var dyn = GetDynamicObject(dict);//将对象转换为一整行数据
                dataSource.Add(dyn);
            }
            VitalSignSource = dataSource;
        }
        /// <summary>
        /// 时间转换整五分钟
        /// </summary>
        /// <param name="selectDateTime"></param>
        /// <returns></returns>
        public DateTime DateTimeEqual(DateTime selectDateTime)
        {
            int minute = selectDateTime.Minute % 5;
            if (minute != 0)
            {
                minute = 5 - minute;
                selectDateTime = selectDateTime.AddMinutes(minute);
            }
            return selectDateTime;
        }

        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="item"></param>
        public void AddVitalSign(dynamic item)
        {
            MED_MONITOR_FUNCTION_CODE itema = item as MED_MONITOR_FUNCTION_CODE;
            ObservableCollection<dynamic> dataSource = new ObservableCollection<dynamic>();
            Dictionary<string, object> dict = new Dictionary<string, object>();

            rowDict.Add(rowDict.Count, itema.ITEM_CODE);
            for (int j = 0; j < columnDict.Count + 2; j++)
            {
                if (j == 0)
                {
                    MED_VITAL_SIGN row = new MED_VITAL_SIGN();
                    row.ITEM_CODE = itema.ITEM_CODE;
                    row.ITEM_NAME = itema.ITEM_NAME;
                    row.Flag = "2";
                    row.ITEM_VALUE = itema.ITEM_CODE;
                    row.IsReadOnlyColumn = true;
                    row.IsShowColumn = false;
                    dict.Add("CODE", row);
                }
                else if (j == 1)
                {
                    MED_VITAL_SIGN row = new MED_VITAL_SIGN();
                    row.ITEM_CODE = itema.ITEM_CODE;
                    row.ITEM_NAME = itema.ITEM_NAME;
                    row.Flag = "2";
                    row.ITEM_VALUE = itema.ITEM_NAME;
                    row.IsReadOnlyColumn = true;
                    row.IsShowColumn = true;
                    dict.Add("项目", row);
                }
                else
                {
                    MED_VITAL_SIGN row = new MED_VITAL_SIGN();
                    row.ITEM_CODE = itema.ITEM_CODE;
                    row.ITEM_NAME = itema.ITEM_NAME;
                    row.Flag = "2";
                    row.TIME_POINT = columnDict[j - 2];
                    row.IsReadOnlyColumn = false;
                    row.IsShowColumn = true;
                    dict.Add(columnDict[j - 2].ToString("yyyy-MM-dd HH:mm"), row);
                }
            }
            var dyn = GetDynamicObject(dict);
            VitalSignSource.Add(dyn);
        }

        /// <summary>
        /// 检查数据是否更改
        /// </summary>
        /// <returns></returns>
        protected override bool CheckDataChange()
        {
            bool changed = false;
            ObservableCollection<dynamic> ld = VitalSignSource as ObservableCollection<dynamic>;
            IEnumerable<string> vitalColumns = ld[0].GetDynamicMemberNames();
            foreach (dynamic itemList in VitalSignSource)
            {
                foreach (var propName in vitalColumns)
                {
                    MED_VITAL_SIGN row = itemList.GetMemberValue(propName) as MED_VITAL_SIGN;
                    if (row.ModelStatus != ModelStatus.Default)
                    {
                        changed = true;
                    }
                }
            }
            return changed;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        protected override SaveResult SaveData()
        {
            SaveResult saveResult = SaveResult.Fail;
            ObservableCollection<dynamic> ld = VitalSignSource as ObservableCollection<dynamic>;
            IEnumerable<string> vitalColumns = ld[0].GetDynamicMemberNames();
            List<MED_PAT_MONITOR_DATA_EXT> patientMonitorExt = AnesInfoService.ClientInstance.GetPatMonitorExtListByEvent(_patientID, _visitID, _operID, _eventNo);
            foreach (dynamic itemList in VitalSignSource)
            {
                foreach (var propName in vitalColumns)
                {
                    MED_VITAL_SIGN row = itemList.GetMemberValue(propName) as MED_VITAL_SIGN;
                    if (row.ModelStatus == ModelStatus.Add && !string.IsNullOrEmpty(row.ITEM_VALUE))// row.ModelStatus的变化来自于RaisePropertyChanged方法！（BaseModel里）
                    {
                        MED_PAT_MONITOR_DATA_EXT patientMonitorDataRow = new MED_PAT_MONITOR_DATA_EXT();
                        patientMonitorDataRow.PATIENT_ID = _patientID;
                        patientMonitorDataRow.VISIT_ID = _visitID;
                        patientMonitorDataRow.OPER_ID = _operID;
                        patientMonitorDataRow.TIME_POINT = row.TIME_POINT;
                        patientMonitorDataRow.ITEM_NAME = row.ITEM_NAME;
                        patientMonitorDataRow.ITEM_CODE = row.ITEM_CODE;
                        patientMonitorDataRow.ITEM_VALUE = row.ITEM_VALUE;
                        patientMonitorDataRow.DATA_TYPE = _eventNo;
                        patientMonitorDataRow.LAST_MODIFY_DATE = DateTime.Now;
                        patientMonitorDataRow.OPERATOR = ExtendAppContext.Current.LoginUser == null ? "" : ExtendAppContext.Current.LoginUser.USER_JOB_ID;
                        patientMonitorDataRow.DATA_MARK = 1;
                        patientMonitorDataRow.ModelStatus = ModelStatus.Add;
                        patientMonitorExt.Add(patientMonitorDataRow);
                    }
                    else if (row.ModelStatus == ModelStatus.Modeified)
                    {
                        List<MED_PAT_MONITOR_DATA_EXT> monitorExt = patientMonitorExt.Where(x => x.PATIENT_ID.Equals(_patientID) && x.VISIT_ID.Equals(_visitID) && x.OPER_ID.Equals(_operID)
                            && x.TIME_POINT.Equals(row.TIME_POINT) && x.ITEM_NAME.Equals(row.ITEM_NAME) && x.DATA_TYPE.Equals(_eventNo) && x.ITEM_CODE.Equals(row.ITEM_CODE)).ToList();

                        if (monitorExt != null && monitorExt.Count > 0)
                        {
                            MED_PAT_MONITOR_DATA_EXT patientMonitorDataRow = monitorExt[0];
                            patientMonitorDataRow.ITEM_VALUE = string.IsNullOrEmpty(row.ITEM_VALUE) ? "/" : row.ITEM_VALUE;
                            patientMonitorDataRow.LAST_MODIFY_DATE = DateTime.Now;
                            patientMonitorDataRow.OPERATOR = ExtendAppContext.Current.LoginUser == null ? "" : ExtendAppContext.Current.LoginUser.USER_JOB_ID;
                            patientMonitorDataRow.DATA_MARK = 1;
                            patientMonitorDataRow.ModelStatus = ModelStatus.Modeified;
                        }
                        else if (!string.IsNullOrEmpty(row.ITEM_VALUE) || !row.IsShowColumn)// MED_PAT_MONITOR_DATA_EXT表里不存在这条数据，且此条数据ITEM_VALUE有值
                        {
                            MED_PAT_MONITOR_DATA_EXT patientMonitorDataRow = new MED_PAT_MONITOR_DATA_EXT();
                            patientMonitorDataRow.PATIENT_ID = _patientID;
                            patientMonitorDataRow.VISIT_ID = _visitID;
                            patientMonitorDataRow.OPER_ID = _operID;
                            patientMonitorDataRow.TIME_POINT = row.TIME_POINT;
                            patientMonitorDataRow.ITEM_NAME = row.ITEM_NAME;
                            patientMonitorDataRow.ITEM_CODE = row.ITEM_CODE;
                            patientMonitorDataRow.ITEM_VALUE = null == row.ITEM_VALUE ? "/" : row.ITEM_VALUE;// 当row.IsShowColumn=fasle，ITEM_VALUE才会=“/”
                            patientMonitorDataRow.DATA_TYPE = _eventNo;
                            patientMonitorDataRow.LAST_MODIFY_DATE = DateTime.Now;
                            patientMonitorDataRow.OPERATOR = ExtendAppContext.Current.LoginUser == null ? "" : ExtendAppContext.Current.LoginUser.USER_JOB_ID;
                            patientMonitorDataRow.DATA_MARK = 1;
                            patientMonitorDataRow.ModelStatus = ModelStatus.Add;
                            patientMonitorExt.Add(patientMonitorDataRow);
                        }
                        else if (string.IsNullOrEmpty(row.ITEM_VALUE) && row.IsShowColumn)
                        {
                            MED_PAT_MONITOR_DATA_EXT patientMonitorDataRow = new MED_PAT_MONITOR_DATA_EXT();
                            patientMonitorDataRow.PATIENT_ID = _patientID;
                            patientMonitorDataRow.VISIT_ID = _visitID;
                            patientMonitorDataRow.OPER_ID = _operID;
                            patientMonitorDataRow.TIME_POINT = row.TIME_POINT;
                            patientMonitorDataRow.ITEM_NAME = row.ITEM_NAME;
                            patientMonitorDataRow.ITEM_CODE = row.ITEM_CODE;
                            patientMonitorDataRow.ITEM_VALUE = string.IsNullOrEmpty(row.ITEM_VALUE) ? "/" : row.ITEM_VALUE;
                            patientMonitorDataRow.DATA_TYPE = _eventNo;
                            patientMonitorDataRow.LAST_MODIFY_DATE = DateTime.Now;
                            patientMonitorDataRow.OPERATOR = ExtendAppContext.Current.LoginUser == null ? "" : ExtendAppContext.Current.LoginUser.USER_JOB_ID;
                            patientMonitorDataRow.DATA_MARK = 1;
                            patientMonitorDataRow.ModelStatus = ModelStatus.Add;
                            patientMonitorExt.Add(patientMonitorDataRow);
                        }
                    }
                }
            }

            // 如果一个时间点即存在隐藏的（DATA_MARK == 0）又存在显示的（DATA_MARK == 1），则把隐藏的数据删除掉
            List<DateTime> timePointList = new List<DateTime>();
            foreach (MED_PAT_MONITOR_DATA_EXT item in patientMonitorExt)
            {
                if (!timePointList.Contains(item.TIME_POINT))
                {
                    timePointList.Add(item.TIME_POINT);
                }
            }

            foreach (DateTime dt in timePointList)
            {
                int unShow = patientMonitorExt.Where(x => x.TIME_POINT == dt && x.DATA_MARK == 0).ToList().Count();
                int show = patientMonitorExt.Where(x => x.TIME_POINT == dt && x.DATA_MARK == 1).ToList().Count();
                if (unShow > 0 && show > 0)
                {
                    patientMonitorExt.ForEach(tempRow =>
                    {
                        if (tempRow.TIME_POINT == dt && tempRow.DATA_MARK == 0)//  在自动生成列时，去除 data_mark=0的列
                        {
                            tempRow.ModelStatus = ModelStatus.Deleted;
                        }
                    });
                }
            }



            bool result = AnesInfoService.ClientInstance.SavePatMonitorExtList(patientMonitorExt);
            if (result)
            {
                foreach (dynamic itemList in VitalSignSource)
                {
                    foreach (var propName in vitalColumns)
                    {
                        MED_VITAL_SIGN row = itemList.GetMemberValue(propName) as MED_VITAL_SIGN;
                        row.ModelStatus = ModelStatus.Default;
                    }
                }
            }

            if (result)
                saveResult = SaveResult.Success;

            return saveResult;
        }

        /// <summary>
        /// 补录体征
        /// </summary>
        /// <returns></returns>
        protected override bool InsertData()
        {
            this.keyBoardMessageLock = true;//补录锁定键盘消息
            var message = new ShowContentWindowMessage("SignMakeupControl", "体征补录");
            message.Height = 700;
            message.Width = 500;
            message.Args = new Object[] { rowDict, SelectColumsItems };
            message.CallBackCommand = CallRecordPoints;
            Messenger.Default.Send<ShowContentWindowMessage>(message);
            return true;
        }


        #region
        /// <summary>
        /// 根据时间点删除体征数据
        /// </summary>
        /// <returns></returns>
        public bool Delete(DateTime timePoint)
        {
            bool result = false;
            DateTime dtServer = DateTime.Now;
            List<MED_PAT_MONITOR_DATA_EXT> patMonitorDataExtList = AnesInfoService.ClientInstance.GetPatMonitorExtListByEvent(_patientID, _visitID, _operID, _eventNo).Where(x => x.TIME_POINT == timePoint).ToList();
            List<MED_PAT_MONITOR_DATA> patMonitorDataList = AnesInfoService.ClientInstance.GetPatMonitorDataListByEvent(_patientID, _visitID, _operID, _eventNo).Where(x => x.TIME_POINT == timePoint).ToList();
            if (patMonitorDataList != null && patMonitorDataList.Count > 0)
            {
                patMonitorDataList.ForEach(row =>
                {
                    List<MED_PAT_MONITOR_DATA_EXT> extList = patMonitorDataExtList.Where(x => x.TIME_POINT.Equals(row.TIME_POINT) && x.ITEM_NAME.Equals(row.ITEM_NAME) && x.ITEM_CODE.Equals(row.ITEM_CODE)).ToList();
                    if (extList.Count > 0)
                    {
                        MED_PAT_MONITOR_DATA_EXT patientMonitorDataRow = extList[0];
                        patientMonitorDataRow.ITEM_VALUE = row.ITEM_VALUE;
                        patientMonitorDataRow.LAST_MODIFY_DATE = dtServer;
                        patientMonitorDataRow.OPERATOR = ExtendAppContext.Current.LoginUser == null ? "" : ExtendAppContext.Current.LoginUser.USER_JOB_ID;
                        patientMonitorDataRow.DATA_MARK = 0;
                    }
                    else
                    {
                        MED_PAT_MONITOR_DATA_EXT patientMonitorDataRow = new MED_PAT_MONITOR_DATA_EXT();
                        patientMonitorDataRow.PATIENT_ID = _patientID;
                        patientMonitorDataRow.VISIT_ID = _visitID;
                        patientMonitorDataRow.OPER_ID = _operID;
                        patientMonitorDataRow.TIME_POINT = row.TIME_POINT;
                        patientMonitorDataRow.ITEM_NAME = row.ITEM_NAME;
                        patientMonitorDataRow.ITEM_CODE = row.ITEM_CODE;
                        patientMonitorDataRow.ITEM_VALUE = row.ITEM_VALUE;
                        patientMonitorDataRow.DATA_TYPE = _eventNo;
                        patientMonitorDataRow.LAST_MODIFY_DATE = dtServer;
                        patientMonitorDataRow.OPERATOR = ExtendAppContext.Current.LoginUser == null ? "" : ExtendAppContext.Current.LoginUser.USER_JOB_ID;
                        patientMonitorDataRow.DATA_MARK = 0;
                        patMonitorDataExtList.Add(patientMonitorDataRow);
                    }
                });
            }
            if (patMonitorDataExtList != null)
                patMonitorDataExtList.ForEach(row =>
                {
                    row.DATA_MARK = 0;
                });
            result = AnesInfoService.ClientInstance.SavePatMonitorExtList(patMonitorDataExtList);
            return result;
        }
        //public bool Delete(string itemCode)
        //{
        //    bool result = false;
        //    DateTime dtServer = AccountService.GetServerTime();
        //    List<MED_PAT_MONITOR_DATA_EXT> patMonitorDataExtList = OperationInfoService.GetPatMonitorExtList(_patientID, _visitID, _operID, _eventNo).Where(x => x.ITEM_CODE == itemCode).ToList();
        //    List<MED_PAT_MONITOR_DATA> patMonitorDataList = OperationInfoService.GetPatMonitorDataListByEvent(_patientID, _visitID, _operID, _eventNo).Where(x => x.ITEM_CODE == itemCode).ToList();
        //    if (patMonitorDataList != null && patMonitorDataList.Count > 0)
        //    {
        //        patMonitorDataList.ForEach(row =>
        //        {
        //            List<MED_PAT_MONITOR_DATA_EXT> extList = patMonitorDataExtList.Where(x => x.TIME_POINT.Equals(row.TIME_POINT) && x.ITEM_NAME.Equals(row.ITEM_NAME) && x.ITEM_CODE.Equals(row.ITEM_CODE)).ToList();
        //            if (extList.Count > 0)
        //            {
        //                MED_PAT_MONITOR_DATA_EXT patientMonitorDataRow = extList[0];
        //                patientMonitorDataRow.ITEM_VALUE = row.ITEM_VALUE;
        //                patientMonitorDataRow.LAST_MODIFY_DATE = dtServer;
        //                patientMonitorDataRow.OPERATOR = _loginUser;
        //                patientMonitorDataRow.DATA_MARK = 0;
        //            }
        //            else
        //            {
        //                MED_PAT_MONITOR_DATA_EXT patientMonitorDataRow = new MED_PAT_MONITOR_DATA_EXT();
        //                patientMonitorDataRow.PATIENT_ID = _patientID;
        //                patientMonitorDataRow.VISIT_ID = _visitID;
        //                patientMonitorDataRow.OPER_ID = _operID;
        //                patientMonitorDataRow.TIME_POINT = row.TIME_POINT;
        //                patientMonitorDataRow.ITEM_NAME = row.ITEM_NAME;
        //                patientMonitorDataRow.ITEM_CODE = row.ITEM_CODE;
        //                patientMonitorDataRow.ITEM_VALUE = row.ITEM_VALUE;
        //                patientMonitorDataRow.DATA_TYPE = _eventNo;
        //                patientMonitorDataRow.LAST_MODIFY_DATE = dtServer;
        //                patientMonitorDataRow.OPERATOR = _loginUser;
        //                patientMonitorDataRow.DATA_MARK = 0;
        //                patMonitorDataExtList.Add(patientMonitorDataRow);
        //            }
        //        });
        //    }
        //    if (patMonitorDataExtList != null)
        //        patMonitorDataExtList.ForEach(row =>
        //        {
        //            row.DATA_MARK = 0;
        //        });
        //    result = OperationInfoService.SavePatMonitorExtList(patMonitorDataExtList);
        //    return result;
        //} 
        #endregion

        /// <summary>
        ///  体征补录
        /// </summary>
        public ICommand SignMakeupControl
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    InsertData();
                });
            }
        }

        /// <summary>
        ///  增加体征项目 
        /// </summary>
        public ICommand AddSignsControl
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    this.keyBoardMessageLock = true;//添加体征锁定键盘消息
                    var message = new ShowContentWindowMessage("AddSignsControl", "添加体征");
                    message.Height = 400;
                    message.Width = 400;
                    message.Args = new Object[] { rowDict, SelectColumsItems };
                    message.CallBackCommand = CallAddSigns;
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                });
            }
        }

        /// <summary>
        /// 体征补录回调
        /// </summary>
        public ICommand CallRecordPoints
        {
            get
            {
                return new RelayCommand<dynamic>(key =>
                {
                    this.keyBoardMessageLock = false;//解锁键盘消息
                    if (key != null)
                    {
                        DateTime startTime = key.sTime;
                        DateTime endTime = key.eTime;
                        List<RecordVitalSignModel> points = key.points;
                        while (startTime <= endTime)
                        {
                            if (!columnDict.ContainsValue(startTime))
                            {//Add列 
                                columnDict.Add(columnDict.Count, startTime);
                                foreach (RecordVitalSignModel vitalSign in points)
                                {
                                    int i = 0;
                                    foreach (dynamic item in VitalSignSource)
                                    {
                                        MED_VITAL_SIGN row = VitalSignSource[i].GetMemberValue("CODE") as MED_VITAL_SIGN;
                                        if (row.ITEM_CODE == vitalSign.ItemCode)
                                        {
                                            item.AddProp(startTime.ToString("yyyy-MM-dd HH:mm"), new MED_VITAL_SIGN()
                                            {
                                                ITEM_CODE = vitalSign.ItemCode,
                                                ITEM_NAME = vitalSign.ItemName,
                                                TIME_POINT = startTime,
                                                ITEM_VALUE = vitalSign.RecordValue,
                                                IsReadOnlyColumn = false,
                                                IsShowColumn = true,
                                                ModelStatus = ModelStatus.Add,// 新增的体征状态Add
                                                Flag = "2"
                                            });
                                            break;
                                        }
                                        i++;
                                    }
                                }
                                ObservableCollection<dynamic> ocd = new ObservableCollection<dynamic>(VitalSignSource);
                                VitalSignSource = ocd;
                            }
                            else
                            {//Add  单元格数据补录
                                foreach (RecordVitalSignModel vitalSign in points)
                                {
                                    if (!string.IsNullOrEmpty(vitalSign.RecordValue))//如果补录数据为空则不改变原有数据
                                    {
                                        for (int i = 0; i < rowDict.Count; i++)
                                        {
                                            if (rowDict[i] == vitalSign.ItemCode)
                                            {
                                                string flag = ((VitalSignSource[i].GetMemberValue(startTime.ToString("yyyy-MM-dd HH:mm"))) as MED_VITAL_SIGN).Flag;
                                                if (string.IsNullOrEmpty(flag) || flag == "0")
                                                    ((VitalSignSource[i].GetMemberValue(startTime.ToString("yyyy-MM-dd HH:mm"))) as MED_VITAL_SIGN).Flag = "1";
                                                ((VitalSignSource[i].GetMemberValue(startTime.ToString("yyyy-MM-dd HH:mm"))) as MED_VITAL_SIGN).ITEM_VALUE = vitalSign.RecordValue;
                                            }
                                        }
                                    }
                                }
                            }
                            startTime = startTime.AddMinutes(5);
                        }
                    }
                });
            }
        }

        /// <summary>
        /// 增加体征项目回调
        /// </summary>
        public ICommand CallAddSigns
        {
            get
            {
                return new RelayCommand<dynamic>(key =>
                {
                    this.keyBoardMessageLock = false;//解放界面键盘响应
                });
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        public ICommand ColseSignCommand
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    this.CloseContentWindow();
                });
            }
        }
        /// <summary>
        /// 删除选中的时间列
        /// </summary>
        public ICommand DeleteSignsControl
        {
            get
            {
                return new RelayCommand<dynamic>(key =>
                {
                    if (SelectColumsItems != null && SelectColumsItems.Count > 0)
                    {
                        for (int i = 0; i < SelectColumsItems.Count; i = i + rowDict.Count)
                        {
                            Delete(selectColumsItems[i].TIME_POINT);
                        }
                        GetVitalSignData();
                    }
                    else
                    {
                        ShowMessageBox("请先选择需要删除的时间列！", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                });
            }
        }
    }
}
