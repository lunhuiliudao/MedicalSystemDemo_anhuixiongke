using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Client.FrameWork
{
    public static class DataHelper
    {
        /// <summary>
        /// 获取新增或修改行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> GetNewAndUpdateList<T>(this DataTable dt)
            where T : new()
        {
            var tmp = dt.Clone();
            foreach (DataRow row in dt.Rows)
            {
                if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                {
                    tmp.ImportRow(row);
                }
            }
            tmp.AcceptChanges();
            return ModelHelper<T>.ConvertDataTableToList(tmp);
        }

        /// <summary>
        /// 获取删除行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> GetDelList<T>(this DataTable dt)
            where T : new()
        {
            var tmp = dt.Clone();
            foreach (DataRow row in dt.Rows)
            {
                if (row.RowState == DataRowState.Deleted)
                {
                    tmp.ImportRow(row);
                }
            }
            tmp.RejectChanges();
            return ModelHelper<T>.ConvertDataTableToList(tmp);
        }
    }
}
