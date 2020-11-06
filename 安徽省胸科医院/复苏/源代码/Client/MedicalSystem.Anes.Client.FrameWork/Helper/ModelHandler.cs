using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MedicalSystem.Anes.Client.FrameWork
{
    /// <summary>
    /// 实体对象与DataTable互转
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public class ModelHandler<T> where T : new()
    {
        #region DataTable转换成实体类

        /// <summary>
        /// 填充对象列表：用DataSet的第一个表填充实体类
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        public List<T> FillModel(DataSet ds)
        {
            if (ds == null || ds.Tables[0] == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return FillModel(ds.Tables[0]);
            }
        }

        /// <summary>  
        /// 填充对象列表：用DataSet的第index个表填充实体类
        /// </summary>  
        public List<T> FillModel(DataSet ds, int index)
        {
            if (ds == null || ds.Tables.Count <= index || ds.Tables[index].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return FillModel(ds.Tables[index]);
            }
        }

        /// <summary>  
        /// 填充对象列表：用DataTable填充实体类
        /// </summary>  
        public List<T> FillModel(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            List<T> modelList = new List<T>();
            foreach (DataRow dr in dt.Rows)
            {
                if (dt.TableName.Equals("MED_PREOPERATIVE_EXPANSION") || dt.TableName.Equals("MED_POSTOPERATIVE_EXTENDED") || dt.TableName.Equals("MED_OPERATION_EXTENDED"))
                {
                    if (dr.RowState == DataRowState.Unchanged) continue;
                }
                T model = FillModel(dr);
                modelList.Add(model);
            }
            return modelList;
        }

        /// <summary>  
        /// 填充对象：用DataRow填充实体类
        /// </summary>  
        public T FillModel(DataRow dr)
        {
            if (dr == null)
            {
                return default(T);
            }

            //T model = (T)Activator.CreateInstance(typeof(T));  
            T model = new T();
            foreach (PropertyInfo propertyInfo in GetProperties())
            {
                propertyInfo.SetValue(model, dr[propertyInfo.Name] == DBNull.Value ? null : dr[propertyInfo.Name], null);
            }
            return model;
        }

        #endregion

        #region 实体类转换成DataTable

        /// <summary>
        /// 实体类转换成DataSet
        /// </summary>
        /// <param name="modelList">实体类列表</param>
        /// <returns></returns>
        public DataSet FillDataSet(List<T> modelList)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(FillDataTable(modelList));
            return ds;
        }

        /// <summary>
        /// 实体类转换成DataTable
        /// </summary>
        /// <param name="modelList">实体类列表</param>
        /// <returns></returns>
        public DataTable FillDataTable(List<T> modelList)
        {
            DataTable dt = CreateData();

            if (modelList != null && modelList.Count > 0)
            {
                foreach (T model in modelList)
                {
                    DataRow dataRow = dt.NewRow();
                    foreach (PropertyInfo propertyInfo in GetProperties())
                    {
                        dataRow[propertyInfo.Name] = propertyInfo.GetValue(model, null) ?? DBNull.Value;
                    }
                    dt.Rows.Add(dataRow);
                }
            }
            dt.AcceptChanges();
            return dt;
        }
        public DataTable ToDataTable(IEnumerable<T> list)
        {
            var dataTable = new DataTable();
            foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(typeof(T)))
            {
                dataTable.Columns.Add(new DataColumn(pd.Name,
                  Nullable.GetUnderlyingType(pd.PropertyType) ?? pd.PropertyType));
            }
            foreach (T item in list)
            {
                var Row = dataTable.NewRow();

                foreach (PropertyDescriptor dp in TypeDescriptor.GetProperties(typeof(T)))
                {
                    Row[dp.Name] = dp.GetValue(item) ?? DBNull.Value;
                }
                dataTable.Rows.Add(Row);
            }
            return dataTable;
        }

        public DataTable FillDataTable(T model)
        {
            DataTable dt = CreateData();

            if (model != null)
            {
                DataRow dataRow = dt.NewRow();
                foreach (PropertyInfo propertyInfo in GetProperties())
                {
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(model, null) ?? DBNull.Value;
                }
                dt.Rows.Add(dataRow);
                dt.AcceptChanges();
            }

            return dt;
        }

        /// <summary>
        /// 根据实体类得到表结构
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns></returns>
        private DataTable CreateData()
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            foreach (PropertyInfo propertyInfo in GetProperties())
            {
                dataTable.Columns.Add(new DataColumn(propertyInfo.Name,
                    Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType));
            }
            return dataTable;
        }

        #endregion

        #region Type PropertyInfo[] Cache

        private static Dictionary<Type, PropertyInfo[]> _cache = new Dictionary<Type, PropertyInfo[]>();

        private PropertyInfo[] GetProperties()
        {
            PropertyInfo[] propInfos = null;
            if (!_cache.TryGetValue(typeof(T), out propInfos) || propInfos == null)
            {
                propInfos = typeof(T).GetProperties();
                _cache[typeof(T)] = propInfos;
            }
            return propInfos;
        }

        #endregion
    }

    public class ModelHandler
    {

        #region 实体类转换成DataTable

        /// <summary>
        /// 实体类转换成DataTable
        /// </summary>
        /// <param name="modelList">实体类列表</param>
        /// <returns></returns>
        public DataTable FillDataTable(IList modelList)
        {
            if (modelList == null)
                return null;
            Type elemType = modelList.GetType().GetGenericArguments()[0];
            DataTable dt = CreateData(elemType);

            if (modelList != null && modelList.Count > 0)
            {
                foreach (var model in modelList)
                {
                    DataRow dataRow = dt.NewRow();
                    foreach (PropertyInfo propertyInfo in GetProperties(elemType))
                    {
                        dataRow[propertyInfo.Name] = propertyInfo.GetValue(model, null) ?? DBNull.Value;
                    }
                    dt.Rows.Add(dataRow);
                }
            }

            dt.AcceptChanges();
            return dt;
        }

        /// <summary>
        /// 根据实体类得到表结构
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns></returns>
        private DataTable CreateData(Type type)
        {
            DataTable dataTable = new DataTable(type.Name);
            foreach (PropertyInfo propertyInfo in GetProperties(type))
            {
                dataTable.Columns.Add(new DataColumn(propertyInfo.Name,
                    Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType));
            }
            return dataTable;
        }

        #endregion

        #region Type PropertyInfo[] Cache

        private static Dictionary<Type, PropertyInfo[]> _cache = new Dictionary<Type, PropertyInfo[]>();

        private PropertyInfo[] GetProperties(Type type)
        {
            PropertyInfo[] propInfos = null;
            if (!_cache.TryGetValue(type, out propInfos) || propInfos == null)
            {
                propInfos = type.GetProperties();
                _cache[type] = propInfos;
            }
            return propInfos;
        }

        #endregion
    }
}
