using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Constants;

namespace Medicalsystem.Anes.Custom.CustomProject
{
    public class AnesSheetDetailsHandler : UIElementHandler<MedAnesSheetDetails>
    {
        /// <summary>
        /// 绑定数据源数据到控件
        /// </summary>
        /// <param name="control"></param>
        /// <param name="dataSources"></param>
        public override void BindDataToUI(MedAnesSheetDetails control, Dictionary<string, System.Data.DataTable> dataSources)
        {

            if (!dataSources.ContainsKey("AnesthesiaEvent"))
                throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表AnesInformations.AnesthesiaEventDataTable,请添加此绑定数据源!", "AnesthesiaEvent"));
            List<MED_ANESTHESIA_EVENT> anesEventTable = ModelHelper<MED_ANESTHESIA_EVENT>.ConvertDataTableToList(dataSources["AnesthesiaEvent"]);

            if (!dataSources.ContainsKey("MED_OPERATION_MASTER"))
                throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表AnesInformations.OperationMasterDataTable,请添加此绑定数据源!", "MED_OPERATION_MASTER"));
           // MED_OPERATION_MASTER operationMaster = ModelHelper<MED_OPERATION_MASTER>.ConvertDataRowToSingle(dataSources["MED_OPERATION_MASTER"].Rows[0]);
            MED_OPERATION_MASTER operationMaster = ModelHelper<MED_OPERATION_MASTER>.ConvertDataTableToList(dataSources["MED_OPERATION_MASTER"])[0];

            if (PagerSetting.PageTimeSpan.StartDateTime != DateTime.MinValue)
            {
                control.StartTime = PagerSetting.PageTimeSpan.StartDateTime;
                control.EndTime = PagerSetting.PageTimeSpan.EndDateTime;
            }


            control.Collections.Clear();

            if (control.Group)
            {
                MedAnesSheetDetailCollection collection;
                if (control.HasEvent)
                {
                    List<AnesClassType> anesClassList = new List<AnesClassType>();
                    anesClassList.Add(AnesClassType.Event);
                    if (control.HasZhiGuan)
                    {
                        anesClassList.Add(AnesClassType.PutPipe);
                        anesClassList.Add(AnesClassType.PullPipe);
                    }
                    if (control.HasFuji)
                    {
                        anesClassList.Add(AnesClassType.ECG);
                    }
                    AnesClassType[] anesClasses = anesClassList.ToArray();
                    collection = GenDetailCollection(anesEventTable, anesClasses, "事件", CollectionType.Event, control.StartTime, null, AnesDrugShowType.Total, false, operationMaster);
                    control.Collections.Add(collection);
                    if (collection != null) collection.Color = control.EventColor;
                }
                if (control.HasAnesDrug)
                {
                    // collection = AddAnesSheetDetailCollection(control, anesEventTable, AnesClassType.AnesDrug, "诱导", CollectionType.Drug, ApplicationConfiguration.YouDaoColor, control.StartTime, control.AnesDrugShowType, true, operationMaster);
                    collection = AddAnesSheetDetailCollection(control, anesEventTable, AnesClassType.AnesDrug, "麻药", CollectionType.Drug, control.AnesDrugColor, control.StartTime, control.AnesDrugShowType, false, operationMaster);
                }
                AddAnesSheetDetailCollection(control, anesEventTable, AnesClassType.Drug, "用药", CollectionType.Drug, control.DrugColor, control.StartTime, false, operationMaster);
                if (control.HasLiquid)
                {
                    collection = GenDetailCollection(anesEventTable, new AnesClassType[] { AnesClassType.InBlood, AnesClassType.InLiquid }, "输液和输血", CollectionType.Drug, control.StartTime, null, AnesDrugShowType.Total, false, operationMaster);
                    if (collection != null)
                    {
                        collection.Color = control.InLiquidColor;
                        control.Collections.Add(collection);
                    }
                }

                if (control.IsTimeOrder)
                {
                    MedAnesSheetDetailCollection collection99 = new MedAnesSheetDetailCollection("事件");
                    for (int i = control.Collections.Count - 1; i >= 0; i--)
                    {
                        MedAnesSheetDetailCollection cl = control.Collections[i];
                        collection99.Add(cl);
                        control.Collections.Remove(cl);
                    }
                    collection99.Sort();
                    for (int i = collection99.Points.Count - 1; i >= 0; i--)
                    {
                        collection99.Points[i].Index = i + 1;
                    }
                    control.Collections.Add(collection99);
                }
                else
                {
                    for (int i = control.Collections.Count - 1; i >= 0; i--)
                    {
                        MedAnesSheetDetailCollection cl = control.Collections[i];
                        if (cl != null && cl.Points != null)
                        {
                            for (int j = cl.Points.Count - 1; j >= 0; j--)
                            {
                                cl.Points[j].Color = cl.Color;
                            }
                        }
                    }
                }
            }
            else
            {
                List<AnesClassType> types = new List<AnesClassType>();


                foreach (int enumValue in Enum.GetValues(typeof(AnesClassType)))
                {
                    types.Add((AnesClassType)enumValue);
                }

                types.Remove(AnesClassType.DataModify);
                if (!control.HasEvent) types.Remove(AnesClassType.Event);
                if (!control.HasZhiGuan)
                {
                    types.Remove(AnesClassType.PutPipe);

                    types.Remove(AnesClassType.PullPipe);
                }
                if (!control.HasAnesDrug) types.Remove(AnesClassType.AnesDrug);


                if (!control.HasFuji)
                {

                    types.Add(AnesClassType.ECG);
                }
                if (!control.HasLiquid)
                {
                    types.Remove(AnesClassType.InBlood);
                    types.Remove(AnesClassType.InLiquid);
                }


                MedAnesSheetDetailCollection collection00 = null;
                if (control.HasAnesDrug)
                {
                    collection00 = AddAnesSheetDetailCollection(control, anesEventTable, types.ToArray(), "事件", CollectionType.Event, control.EventColor, control.StartTime, null, AnesDrugShowType.Total, false, operationMaster);

                }
                else
                {
                    collection00 = AddAnesSheetDetailCollection(control, anesEventTable, types.ToArray(), "事件", CollectionType.Event, control.EventColor, control.StartTime, GetAnesClassTypeString(AnesClassType.AnesDrug), AnesDrugShowType.Total, false, operationMaster);
                }
                if (collection00 != null) collection00.Color = control.EventColor;
            }

            //去掉重复的药
            MedDrugGraph drugGraph = null;//GetAnesGraph<MedDrugGraph>();
            foreach (IUIElementHandler handler in MedicalPaperUIElementHandlers)
            {
                if (handler.GetControlType == typeof(MedDrugGraph) && handler.GetCurrentControl != null)
                    drugGraph = handler.GetCurrentControl as MedDrugGraph;
            }

            if (drugGraph != null)
            {
                for (int i = 0; i < drugGraph.Curves.Count; i++)
                {
                    foreach (MedAnesSheetDetailCollection collect in control.Collections)
                    {
                        MedAnesSheetDetailPoint point = null;
                        for (int ii = 0; ii < collect.Points.Count; ii++)
                        {
                            point = collect.Points[ii];
                            if (point.Text.ToLower() == drugGraph.Curves[i].Text.ToLower())
                            {
                                collect.Points.Remove(point);
                                ii = ii - 1;
                                // continue;
                            }
                        }
                        //重新给序号
                        for (int ii = 0; ii < collect.Points.Count; ii++)
                        {
                            point = collect.Points[ii];
                            point.Index = ii + 1;

                        }

                    }
                }
            }



            //}

            //去掉重复的输血输液
            MedGridGraph gridGraph = null;// GetAnesGraph<MedGridGraph>();
            foreach (IUIElementHandler handler in MedicalPaperUIElementHandlers)
            {
                if (handler.GetControlType == typeof(MedGridGraph) && handler.GetCurrentControl != null)
                    gridGraph = handler.GetCurrentControl as MedGridGraph;
            }
            if (gridGraph != null)
            {
                for (int i = 0; i < gridGraph.Rows.Count; i++)
                {
                    foreach (MedAnesSheetDetailCollection collect in control.Collections)
                    {
                        MedAnesSheetDetailPoint point = null;
                        for (int ii = 0; ii < collect.Points.Count; ii++)
                        {
                            point = collect.Points[ii];
                            if (point.Text.ToLower() == gridGraph.Rows[i].Text.ToLower())
                            {
                                collect.Points.Remove(point);
                                ii = ii - 1;
                            }
                        }
                        //重新给序号
                        for (int ii = 0; ii < collect.Points.Count; ii++)
                        {
                            point = collect.Points[ii];
                            point.Index = ii + 1;

                        }

                    }

                }
            }
        }
        /// <summary>
        /// 绑定控件内容到数据源
        /// </summary>
        /// <param name="control"></param>
        /// <param name="dataSources"></param>
        public override void BindUIToData(MedAnesSheetDetails control, Dictionary<string, System.Data.DataTable> dataSources)
        {

        }
        /// <summary>
        /// 控件的属性事件设置
        /// </summary>
        /// <param name="control"></param>
        public override void ControlSetting(MedAnesSheetDetails control)
        {
            control.OriginWidth = control.Width;
            control.OriginHeight = control.Height;
        }

        private List<MED_ANESTHESIA_EVENT> GetAnesthesiaEvent(List<MED_ANESTHESIA_EVENT> anesEventTable, AnesClassType[] anesClasses)
        {
            if (anesEventTable != null && anesClasses != null && anesClasses.Length > 0)
            {
                var anesClassList = anesClasses
                   .Select(clas => GetAnesClassTypeString(clas)).ToList();

                anesEventTable = anesEventTable
                    .Where(x => anesClassList.Contains(x.EVENT_CLASS_CODE)).ToList();
                return anesEventTable;
            }
            return null;
        }
        /// <summary>
        /// 复制数据表
        /// </summary>
        /// <param name="sourceTable">源数据表</param>
        /// <param name="targetTable">目标数据表</param>
        private void CopyTable(DataTable sourceTable, DataTable targetTable)
        {
            for (int i = 0; i < sourceTable.Rows.Count; i++)
            {
                DataRow row = targetTable.NewRow();
                for (int j = 0; j < sourceTable.Columns.Count; j++)
                {
                    row[j] = sourceTable.Rows[i][j];
                }
                targetTable.Rows.Add(row);
            }
        }


        private MedAnesSheetDetailCollection AddAnesSheetDetailCollection(MedAnesSheetDetails anesDetail, List<MED_ANESTHESIA_EVENT> anesEventTable, AnesClassType anesClassType, string collectionText, CollectionType collectionType, Color collectionColor, DateTime startDate, bool isYouDao, MED_OPERATION_MASTER operationMaster)
        {
            return AddAnesSheetDetailCollection(anesDetail, anesEventTable, anesClassType, collectionText, collectionType, collectionColor, startDate, AnesDrugShowType.Total, isYouDao, operationMaster);
        }

        private MedAnesSheetDetailCollection AddAnesSheetDetailCollection(MedAnesSheetDetails anesDetail, List<MED_ANESTHESIA_EVENT> anesEventTable, AnesClassType anesClassType, string collectionText, CollectionType collectionType, Color collectionColor, DateTime startDate, AnesDrugShowType drugShowType, bool isYouDao, MED_OPERATION_MASTER operationMaster)
        {
            return AddAnesSheetDetailCollection(anesDetail, anesEventTable, new AnesClassType[] { anesClassType }, collectionText, collectionType, collectionColor, startDate, null, drugShowType, isYouDao, operationMaster);
        }

        private MedAnesSheetDetailCollection AddAnesSheetDetailCollection(MedAnesSheetDetails anesDetail, List<MED_ANESTHESIA_EVENT> anesEventTable, AnesClassType[] anesClasses, string collectionText, CollectionType collectionType, Color collectionColor, DateTime startDate, string filtItemName, AnesDrugShowType drugShowType, bool isYouDao, MED_OPERATION_MASTER operationMaster)
        {
            MedAnesSheetDetailCollection collection = GenDetailCollection(anesEventTable, anesClasses, collectionText, collectionType, startDate, filtItemName, drugShowType, isYouDao, operationMaster);
            if (collection != null)
            {
                collection.Color = collectionColor;
                anesDetail.Collections.Add(collection);
            }
            return collection;
        }

        private MedAnesSheetDetailCollection GenDetailCollection(List<MED_ANESTHESIA_EVENT> anesEventTable, AnesClassType[] anesClasses, string collectionText, CollectionType collectionType, DateTime startDate, string filtItemName, AnesDrugShowType drugShowType, bool isYouDao, MED_OPERATION_MASTER operationMaster)
        {
            MedAnesSheetDetailCollection collection = new MedAnesSheetDetailCollection(collectionText);
            List<MED_ANESTHESIA_EVENT> anesthesiaEventDataTable;
            ///获取事件数据
            if (anesClasses != null)
            {
                anesthesiaEventDataTable = GetAnesthesiaEvent(anesEventTable, anesClasses);
            }
            else
            {
                anesthesiaEventDataTable = anesEventTable;
            }
            if (anesthesiaEventDataTable != null && anesthesiaEventDataTable.Count > 0)
            {
                foreach (MED_ANESTHESIA_EVENT row in anesthesiaEventDataTable)
                {
                    if (!isYouDao && !string.IsNullOrEmpty(row.EVENT_ATTR) && row.EVENT_ATTR.Equals(EventNames.YOUDAONUMBER)) continue;
                    //if (isYouDao && (string.IsNullOrEmpty(row.EVENT_ATTR)) || !row.EVENT_ATTR.Equals(EventNames.YOUDAONUMBER)) continue;
                    if (string.IsNullOrEmpty(row.EVENT_ITEM_NAME)) continue;
                    if (!string.IsNullOrEmpty(filtItemName))
                    {
                        if (!string.IsNullOrEmpty(row.EVENT_CLASS_CODE) && filtItemName.Equals(row.EVENT_CLASS_CODE))
                        {
                            continue;
                        }
                    }
                    switch (collectionType)
                    {
                        case CollectionType.Event:
                            MedAnesSheetDetailPoint pt = null;
                            if (row.START_TIME.HasValue && row.END_TIME.HasValue && !IsTimeEvent(row.EVENT_ITEM_NAME))
                            {
                                DateTime startTime = PraseDate(startDate, row.START_TIME.Value);
                                DateTime endTime = PraseDate(startDate, row.END_TIME.Value);
                                if (endTime > startTime)
                                {
                                    pt = new MedAnesSheetDetailPoint(startTime, endTime, row.EVENT_ITEM_NAME, row);
                                    collection.Points.Add(pt);
                                    pt.Color = collection.Color;
                                }
                                else
                                {
                                    pt = new MedAnesSheetDetailPoint(startTime, row.EVENT_ITEM_NAME, row);
                                    collection.Points.Add(pt);
                                    pt.Color = collection.Color;
                                }
                            }
                            else if (row.START_TIME.HasValue && !IsTimeEvent(row.EVENT_ITEM_NAME))
                            {
                                pt = new MedAnesSheetDetailPoint(row.START_TIME.Value, row.EVENT_ITEM_NAME);
                                collection.Points.Add(pt);
                                pt.Color = collection.Color;
                            }
                            if (pt != null)
                            {
                                if (!string.IsNullOrEmpty(row.DOSAGE_UNITS))
                                {
                                    pt.Unit = row.DOSAGE_UNITS;
                                }
                                if (row.DOSAGE.HasValue && row.DOSAGE > 0)
                                {

                                    pt.Value = (double)row.DOSAGE;
                                }
                                if (!string.IsNullOrEmpty(row.ADMINISTRATOR))
                                {
                                    pt.Route = row.ADMINISTRATOR;
                                }
                            }
                            break;
                        case CollectionType.Drug:
                            if (row.START_TIME.HasValue && !string.IsNullOrEmpty(row.DOSAGE_UNITS) && row.DOSAGE.HasValue)
                            {
                                bool canAdd = true;
                                if (drugShowType != AnesDrugShowType.Total)
                                {
                                    AnesDrugShowType stype = (row.DURATIVE_INDICATOR.HasValue && row.DURATIVE_INDICATOR == 1) ? AnesDrugShowType.ProLonged : AnesDrugShowType.SinglePoint;
                                    canAdd = stype == drugShowType;
                                }
                                if (canAdd)
                                {
                                    double value = 0;
                                    if (row.DOSAGE.HasValue) value = (double)row.DOSAGE;
                                    if (row.END_TIME.HasValue)
                                    {
                                        DateTime startTime = PraseDate(startDate, row.START_TIME.Value);
                                        DateTime endTime = PraseDate(startDate, row.END_TIME.Value);
                                        if (endTime > startTime)
                                        {
                                            MedAnesSheetDetailPoint ppt = new MedAnesSheetDetailPoint(startTime, endTime, row.EVENT_ITEM_NAME, value, row.DOSAGE_UNITS, (string.IsNullOrEmpty(row.ADMINISTRATOR) ? "" : row.ADMINISTRATOR), row);
                                            collection.Points.Add(ppt);
                                            ppt.Color = collection.Color;
                                        }
                                        else
                                        {
                                            MedAnesSheetDetailPoint ppt = new MedAnesSheetDetailPoint(startTime, row.EVENT_ITEM_NAME, value, row.DOSAGE_UNITS, (string.IsNullOrEmpty(row.ADMINISTRATOR) ? "" : row.ADMINISTRATOR), row);
                                            collection.Points.Add(ppt);
                                            ppt.Color = collection.Color;
                                        }
                                    }
                                    else
                                    {
                                        MedAnesSheetDetailPoint ppt = new MedAnesSheetDetailPoint(PraseDate(startDate, row.START_TIME.Value), row.EVENT_ITEM_NAME, value, row.DOSAGE_UNITS, (string.IsNullOrEmpty(row.ADMINISTRATOR) ? "" : row.ADMINISTRATOR), row);
                                        collection.Points.Add(ppt);
                                        ppt.Color = collection.Color;
                                    }
                                }
                            }
                            break;
                    }
                }
            }
            if (collectionType == CollectionType.Event)
            {
                if (operationMaster != null)
                {
                    if (ExtendApplicationContext.Current.EventNo == "0")
                    {
                        //判断当前页的时间范围内是否有入手术室和出手术室事件
                        if (operationMaster.IN_DATE_TIME.HasValue && operationMaster.IN_DATE_TIME >= PagerSetting.PageTimeSpan.StartDateTime
                            && operationMaster.IN_DATE_TIME <= PagerSetting.PageTimeSpan.EndDateTime)//入手术室
                        {
                            MedAnesSheetDetailPoint pt = new MedAnesSheetDetailPoint(operationMaster.IN_DATE_TIME.Value, EventNames.INDATETIME, null);
                            pt.Color = collection.Color;
                            collection.Points.Add(pt);

                        }
                        if (operationMaster.ANES_START_TIME.HasValue && operationMaster.ANES_START_TIME >= PagerSetting.PageTimeSpan.StartDateTime
                          && operationMaster.ANES_START_TIME <= PagerSetting.PageTimeSpan.EndDateTime)//麻醉开始
                        {
                            MedAnesSheetDetailPoint pt = new MedAnesSheetDetailPoint(operationMaster.ANES_START_TIME.Value, EventNames.ANESSTART, null);
                            pt.Color = collection.Color;
                            collection.Points.Add(pt);
                        }
                        if (operationMaster.START_DATE_TIME.HasValue && operationMaster.START_DATE_TIME >= PagerSetting.PageTimeSpan.StartDateTime
                           && operationMaster.START_DATE_TIME <= PagerSetting.PageTimeSpan.EndDateTime)//手术开始
                        {
                            MedAnesSheetDetailPoint pt = new MedAnesSheetDetailPoint(operationMaster.START_DATE_TIME.Value, EventNames.OPERATIONSTART, null);
                            pt.Color = collection.Color;
                            collection.Points.Add(pt);
                        }
                        if (operationMaster.END_DATE_TIME.HasValue && operationMaster.END_DATE_TIME >= PagerSetting.PageTimeSpan.StartDateTime
                           && operationMaster.END_DATE_TIME <= PagerSetting.PageTimeSpan.EndDateTime)//手术结束
                        {
                            MedAnesSheetDetailPoint pt = new MedAnesSheetDetailPoint(operationMaster.END_DATE_TIME.Value, EventNames.OPERATIONEND, null);
                            pt.Color = collection.Color;
                            collection.Points.Add(pt);
                        }
                        if (operationMaster.ANES_END_TIME.HasValue && operationMaster.ANES_END_TIME >= PagerSetting.PageTimeSpan.StartDateTime
                            && operationMaster.ANES_END_TIME <= PagerSetting.PageTimeSpan.EndDateTime)//麻醉结束
                        {
                            MedAnesSheetDetailPoint pt = new MedAnesSheetDetailPoint(operationMaster.ANES_END_TIME.Value, EventNames.ANESEND, null);
                            pt.Color = collection.Color;
                            collection.Points.Add(pt);
                        }
                        if (operationMaster.OUT_DATE_TIME.HasValue && operationMaster.OUT_DATE_TIME >= PagerSetting.PageTimeSpan.StartDateTime
                            && operationMaster.OUT_DATE_TIME <= PagerSetting.PageTimeSpan.EndDateTime)//出手术室
                        {
                            MedAnesSheetDetailPoint pt = new MedAnesSheetDetailPoint(operationMaster.OUT_DATE_TIME.Value, "出手术室", null);
                            pt.Color = collection.Color;
                            collection.Points.Add(pt);
                        }
                    }
                    //End Modify
                    else if (ExtendApplicationContext.Current.EventNo == "1")
                    {
                        if (operationMaster.IN_PACU_DATE_TIME.HasValue && operationMaster.IN_PACU_DATE_TIME >= PagerSetting.PageTimeSpan.StartDateTime
                          && operationMaster.IN_PACU_DATE_TIME <= PagerSetting.PageTimeSpan.EndDateTime)
                        {
                            MedAnesSheetDetailPoint pt = new MedAnesSheetDetailPoint(operationMaster.IN_PACU_DATE_TIME.Value, EventNames.INPACU, null);
                            pt.Color = collection.Color;
                            collection.Points.Add(pt);
                        }
                        if (operationMaster.OUT_PACU_DATE_TIME.HasValue && operationMaster.OUT_PACU_DATE_TIME >= PagerSetting.PageTimeSpan.StartDateTime
                         && operationMaster.OUT_PACU_DATE_TIME <= PagerSetting.PageTimeSpan.EndDateTime)//
                        {
                            MedAnesSheetDetailPoint pt = new MedAnesSheetDetailPoint(operationMaster.OUT_PACU_DATE_TIME.Value, EventNames.OUTPACU, null);
                            pt.Color = collection.Color;
                            collection.Points.Add(pt);
                        }
                    }
                }
            }
            collection.Sort();
            // collection.CollectionType = collectionType;
            return collection;
        }
        /// <summary>
        /// 调整时间的日期为指定日期，并保证不小于该日期（小于时日期加1）
        /// </summary>
        /// <param name="theDate">指定日期</param>
        /// <param name="sourceDateTime">要调整的日期</param>
        /// <returns>调整后的日期</returns>
        private DateTime PraseDate(DateTime theDate, DateTime sourceDateTime)
        {
            DateTime date = new DateTime(theDate.Year, theDate.Month, theDate.Day, sourceDateTime.Hour, sourceDateTime.Minute, sourceDateTime.Second);
            DateTime date1 = new DateTime(theDate.Year, theDate.Month, theDate.Day, theDate.Hour, theDate.Minute, theDate.Second);
            if (date < date1) date = date.AddDays(1);
            return date;
        }
        protected AnesClassType GetAnesTypeFromString(string classstr)
        {
            string anesClassTypeStrings = "0123456789ABCXYOZ~DU";
            int index = anesClassTypeStrings.IndexOf(classstr);
            if (index < 0)
                return AnesClassType.Unknow;

            return (AnesClassType)index;
        }
        //刷新数据时重新绑定数据源 20140210
        public override void RefreshData()
        {
            foreach (MedAnesSheetDetails control in GetAllControls)
            {
                MedAnesSheetDetails medAnesSheetDetails = (MedAnesSheetDetails)control;
                BindDataToUI(control, DataSource);

            }
        }
    }
}
