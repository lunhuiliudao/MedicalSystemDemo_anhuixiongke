using MedicalSystem.AnesWorkStation.Model.AnesGraphModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace MedicalSystem.AnesWorkStation.View.AnesGraph
{
    public class DataRowDefine
    {
        public string RowTitle
        {
            get
            {
                return RowData.FirstOrDefault() == null ? string.Empty : RowData.FirstOrDefault().Name;
            }
        }
        /// <summary>
        /// 头矩形区域
        /// </summary>
        public Rectangle HeadRectangle { get; set; }

        /// <summary>
        /// 体矩形
        /// </summary>
        public Rectangle BodyRectangle { get; set; }

        public List<IntakeAndOutputData> RowData { get; set; }

        public List<UIElement> DataUIElements { get; set; }

        public List<UIElement> TitleUIElements { get; set; }

        /// <summary>
        /// 数据点
        /// </summary>
        public List<DataPoint> DataPoints;

        public DataRowDefine(Rectangle HeadRectangle, Rectangle BodyRectangle)
        {
            this.HeadRectangle = HeadRectangle;
            this.BodyRectangle = BodyRectangle;
            RowData = new List<IntakeAndOutputData>();
            DataUIElements = new List<UIElement>();
            TitleUIElements = new List<UIElement>();
            DataPoints = new List<DataPoint>();
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="dataList"></param>
        public void AddData(List<IntakeAndOutputData> dataList)
        {
            if (RowData.Count > 0 && dataList.FirstOrDefault().Name != RowData.FirstOrDefault().Name)
                return;

            RowData.AddRange(dataList);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="dataList"></param>
        public void UpdateData(List<IntakeAndOutputData> dataList)
        {
            if (dataList == null || dataList.Count == 0)
                return;
            if (RowData.Count > 0 && dataList.FirstOrDefault().Name != RowData.FirstOrDefault().Name)
                return;

            RowData.Clear();
            RowData.AddRange(dataList);
            //foreach (IntakeAndOutputData item in dataList)
            //{
            //    IntakeAndOutputData orgData = RowData.Find(p =>
            //    {
            //        if (item.IsOneTime)
            //            return item.OnetimeData.ExcuteTime == p.OnetimeData.ExcuteTime;
            //        else
            //            return item.BeginTime == p.BeginTime && item.EndTime == p.EndTime;
            //    });
            //    if (orgData != null)
            //        orgData = item;
            //    else
            //        RowData.Add(item);
            //}                 
        }
    }
}
