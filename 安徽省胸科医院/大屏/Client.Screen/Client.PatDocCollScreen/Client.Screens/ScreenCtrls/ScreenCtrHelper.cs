using MedicalSystem.AnesIcuQuery.Models;
using MedicalSystem.AnesIcuQuery.Network;
using MedicalSystem.MedScreen.Common;
using MedicalSystem.MedScreen.Network;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalSystem.MedScreen.Client.PatDocScreen
{
    public class ScreenCtrHelper
    {
        /// <summary>
        /// 计算控件高度
        /// </summary>
        public static void CalculateCtrsHeight(int height)
        {
            int screen_height = height;
            //家属等待屏，显示内容标题行+时间和大屏标签行+底部公告行，共3行
            //手术排班 多加一行当前手术和接台手术，共4行
            int extRow = 3;
            if (ExtendAppContext.Current.CurntScreentType == ScreenType.OperScheduleScreen)
                extRow = 4;
            int averg_height = screen_height / (ExtendAppContext.Current.RowCount + extRow);
            ExtendAppContext.Current.TopBottomHeight = Convert.ToInt32(averg_height * 1.2);
            ExtendAppContext.Current.RowHeight = (screen_height - ExtendAppContext.Current.TopBottomHeight * 2) / (ExtendAppContext.Current.RowCount + extRow -2);
        }

        /// <summary>
        /// 获取列字典，包含列名和宽度
        /// 每次登录只需要加载一次
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, double> GetNormalColumnList(double areaWidth)
        {
            Dictionary<string, double> colsWidthDict = new Dictionary<string, double>();
            try
            {
                QueryParams queryParams = new QueryParams();
                queryParams.AddQueryDefines("ScreenNo", ExtendAppContext.Current.CurntScreenNo);
                //获取显示字段的数据
                ExtendAppContext.Current.FieldData = DataOperator.HttpWebApi<DataResult>(ApiUrlEnum.GetScreenFieldsData, queryParams).ToDataTable();
                foreach (DataRow dr in ExtendAppContext.Current.FieldData.Rows)
                {
                    if (!colsWidthDict.ContainsKey(dr["CAPTION"].ToString()))
                        colsWidthDict.Add(dr["CAPTION"].ToString(), double.Parse(dr["COL_PERCENT"].ToString()) / 100 * areaWidth);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
            return colsWidthDict;
        }

        /// <summary>
        /// 获取接台列字典
        /// </summary>
        /// <param name="areaWidth"></param>
        /// <returns></returns>
        public static Dictionary<string, double> GetSeqColumnList(double areaWidth)
        {
            Dictionary<string, double> colsWidthDict = new Dictionary<string, double>();
            try
            {
                QueryParams queryParams = new QueryParams();
                queryParams.AddQueryDefines("ScreenNo", ExtendAppContext.Current.CurntScreenNo);
                //获取显示字段的数据
                ExtendAppContext.Current.FieldData = DataOperator.HttpWebApi<DataResult>(ApiUrlEnum.GetScreenFieldsData, queryParams).ToDataTable();
                ExtendAppContext.Current.FieldData.DefaultView.RowFilter = "SEQ_SHOW = 1";
                ExtendAppContext.Current.SeqFieldData = ExtendAppContext.Current.FieldData.DefaultView.ToTable();
                int TotalPercent = 0;
                double dev = 0;
                foreach (DataRow dr in ExtendAppContext.Current.SeqFieldData.Rows)
                {
                    if (!colsWidthDict.ContainsKey(dr["CAPTION"].ToString()))
                    {
                        colsWidthDict.Add(dr["CAPTION"].ToString(), int.Parse(dr["COL_PERCENT"].ToString()));
                        TotalPercent += int.Parse(dr["COL_PERCENT"].ToString());
                    }
                }
                if (TotalPercent != 100 && TotalPercent != 0)
                {
                    dev = (double)TotalPercent / 100;
                }
                double accutPercent = 0;
                colsWidthDict = new Dictionary<string, double>();
                for (int i = 0; i < ExtendAppContext.Current.SeqFieldData.Rows.Count; i++)
                {
                    DataRow row = ExtendAppContext.Current.SeqFieldData.Rows[i];
                    double curntPercent = 0;
                    if (!colsWidthDict.ContainsKey(row["CAPTION"].ToString()))
                    {
                        if (i == ExtendAppContext.Current.SeqFieldData.Rows.Count - 1)
                        {
                            curntPercent = double.Parse((100 - accutPercent).ToString());
                        }
                        else
                        {
                            curntPercent = double.Parse(row["COL_PERCENT"].ToString()) / dev;
                        }
                        colsWidthDict.Add(row["CAPTION"].ToString(), curntPercent / 100 * areaWidth);
                        accutPercent += curntPercent;
                    }

                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
            return colsWidthDict;
        }

        
    }
}
