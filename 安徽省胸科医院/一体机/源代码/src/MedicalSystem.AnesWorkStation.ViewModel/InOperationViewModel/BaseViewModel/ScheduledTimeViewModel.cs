using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalSystem.AnesWorkStation.Model.InOperationModel;
using MedicalSystem.AnesWorkStation.Model.AnesGraphModel;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel
{
    /// <summary>
    /// 时间进程
    /// </summary>
    public class ScheduledTimeViewModel
    {
        /// <summary>
        /// 获取开始时间
        /// </summary>
        public DateTimeRangeModel GetGraphDateTime(List<MED_VITAL_SIGN> vitalSignDataTable, List<MED_ANESTHESIA_EVENT> anesthesiaEventDataTable, string eventNo, MED_OPERATION_MASTER masterTable)
        {
            DateTime startTime = DateTime.MinValue, endTime = DateTime.MinValue;
            bool result = false;
            if (vitalSignDataTable != null && vitalSignDataTable.Count > 0)
            {
                vitalSignDataTable = vitalSignDataTable.OrderBy(x => x.TIME_POINT).ToList();
                startTime = vitalSignDataTable[0].TIME_POINT;
                DateTime dt = vitalSignDataTable[vitalSignDataTable.Count - 1].TIME_POINT;
                if (startTime < dt)
                {
                    endTime = dt;
                }
                else
                {
                    endTime = startTime.AddMinutes(1);
                }
                result = true;
            }
            if (anesthesiaEventDataTable != null && anesthesiaEventDataTable.Count > 0)
            {
                anesthesiaEventDataTable = anesthesiaEventDataTable.OrderBy(x => x.START_TIME).ToList();
                if (!result || startTime > anesthesiaEventDataTable[0].START_TIME.Value)
                {
                    startTime = anesthesiaEventDataTable[0].START_TIME.Value;
                }
                anesthesiaEventDataTable.ForEach(row =>
                {
                    if (row.START_TIME.HasValue && endTime == DateTime.MaxValue)
                    {
                        endTime = row.START_TIME.Value;
                    }
                    if (row.START_TIME.HasValue && row.START_TIME > endTime)
                    {
                        endTime = row.START_TIME.Value;
                    }
                    if (row.END_TIME.HasValue && row.END_TIME > endTime)
                    {
                        endTime = row.END_TIME.Value;
                    }
                });
                result = true;
            }
            if (masterTable != null)
            {
                if (masterTable.IN_DATE_TIME.HasValue)
                {
                    if (!result || (masterTable.IN_DATE_TIME.Value < startTime))
                    {
                        startTime = masterTable.IN_DATE_TIME.Value;
                    }
                    if (!result || (masterTable.IN_DATE_TIME.Value > endTime))
                    {
                        endTime = masterTable.IN_DATE_TIME.Value;
                    }
                    result = true;
                }
                if (masterTable.END_DATE_TIME.HasValue)
                {

                    if (!result || (masterTable.END_DATE_TIME.Value > endTime))
                    {
                        endTime = masterTable.END_DATE_TIME.Value;
                    }
                    result = true;
                }
                if (masterTable.ANES_END_TIME.HasValue)
                {

                    if (!result || (masterTable.ANES_END_TIME.Value > endTime))
                    {
                        endTime = masterTable.ANES_END_TIME.Value;
                    }
                    result = true;
                }
                if (masterTable.OUT_DATE_TIME.HasValue)
                {

                    if (!result || (masterTable.OUT_DATE_TIME.Value > endTime))
                    {
                        endTime = masterTable.OUT_DATE_TIME.Value;
                    }
                    result = true;
                }
            }
            if (result)
            {
                if (endTime == DateTime.MinValue)
                {
                    endTime = startTime.AddMinutes(1);
                }

            }
            else
            {
                startTime = DateTime.Parse("08:00");
                endTime = startTime.AddHours(3);
            }
            startTime = Convert.ToDateTime(startTime.ToString("yyyy-MM-dd HH:mm"));
            endTime = Convert.ToDateTime(endTime.ToString("yyyy-MM-dd HH:mm"));

            if (startTime.Minute % 5 != 0)
            {
                startTime = startTime.AddMinutes(-startTime.Minute % 5);
            }
            if (endTime.Minute % 5 != 0)
            {
                endTime = endTime.AddMinutes(5 - endTime.Minute % 5);
            }
            return new DateTimeRangeModel(startTime, endTime);
        }

        public AxisSetting SetAxisSetting(DateTimeRangeModel pageTimeRange, bool isIntensive)
        {


            AxisSetting _xAxisSetting = new AxisSetting();
            if (isIntensive)
            {
                double mu = (double)((TimeSpan)(pageTimeRange.EndDateTime - pageTimeRange.StartDateTime)).TotalMinutes;
                if (mu > 20)
                {
                    _xAxisSetting.EndTime = pageTimeRange.EndDateTime.Value;
                    _xAxisSetting.BeginTime = _xAxisSetting.EndTime.Value.AddMinutes(-20);
                    _xAxisSetting.BeginFactTime = _xAxisSetting.EndTime.Value.AddMinutes(-20);
                }
                else
                {
                    _xAxisSetting.BeginFactTime = pageTimeRange.StartDateTime.Value;
                    _xAxisSetting.BeginTime = pageTimeRange.StartDateTime.Value;
                    _xAxisSetting.EndTime = _xAxisSetting.BeginTime.Value.AddMinutes(20);
                }
                _xAxisSetting.MoveMinLimitTime = pageTimeRange.StartDateTime.Value;
                _xAxisSetting.MoveMaxLimitTime = _xAxisSetting.EndTime.Value.AddMinutes(5);
                _xAxisSetting.MinorUnit = DateUnit.Second;
                _xAxisSetting.MajorUnit = DateUnit.Second;
                _xAxisSetting.MinorStep = 20;
                _xAxisSetting.MajorStep = 120;
            }
            else
            {
                double mu = (double)((TimeSpan)(pageTimeRange.EndDateTime - pageTimeRange.StartDateTime)).TotalHours;
                if (mu > 2.5)
                {
                    _xAxisSetting.EndTime = pageTimeRange.EndDateTime.Value.AddMinutes(30);
                    _xAxisSetting.BeginTime = _xAxisSetting.EndTime.Value.AddHours(-3);
                    _xAxisSetting.BeginFactTime = _xAxisSetting.EndTime.Value.AddHours(-3);
                }
                else
                {
                    _xAxisSetting.BeginFactTime = pageTimeRange.StartDateTime.Value;
                    _xAxisSetting.BeginTime = pageTimeRange.StartDateTime.Value.AddMinutes(-5);
                    _xAxisSetting.EndTime = _xAxisSetting.BeginTime.Value.AddHours(3);
                }

                _xAxisSetting.MoveMinLimitTime = pageTimeRange.StartDateTime.Value.AddMinutes(-5);
                _xAxisSetting.MoveMaxLimitTime = _xAxisSetting.EndTime.Value.AddHours(1);
            }

            return _xAxisSetting;
        }
    }
}
