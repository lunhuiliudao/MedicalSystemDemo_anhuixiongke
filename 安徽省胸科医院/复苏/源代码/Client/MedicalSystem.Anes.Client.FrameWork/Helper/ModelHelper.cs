using Newtonsoft.Json;
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
    public static class ModelHelper<T> where T : new()
    {

        /// <summary>
        /// 实体类转换成DataTable
        /// </summary>
        /// <param name="modelList">实体类列表</param>
        /// <returns></returns>
        public static DataTable ConvertSingleToDataTable(T model)
        {
            DataTable dataTable = null;

            if (model != null)
            {


                dataTable = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(new List<T>() { model }));
            }
            else
            {
                dataTable = new DataTable();
            }

            dataTable.TableName = typeof(T).Name;

            return dataTable;

        }

        /// <summary>
        /// 实体类转换成DataTable
        /// </summary>
        /// <param name="modelList">实体类列表</param>
        /// <returns></returns>
        public static DataTable ConvertListToDataTable(List<T> modelList)
        {
            DataTable dataTable = null;

            if (modelList.Count > 0)
            {
                dataTable = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelList));
            }
            else
            {
                dataTable = new DataTable();
            }

            dataTable.TableName = typeof(T).Name;

            return dataTable;

        }

        public static List<T> ConvertDataTableToList(DataTable dt)
        {
            List<T> list = new List<T>();

            try
            {
                list = JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(dt));
            }
            catch(Exception e)
            {

            }
            return list;
        }

        public static T ConvertDataTableToSingle(DataTable dt)
        {
            T model = new T();

            try
            {
                model = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(dt));
            }
            catch
            {

            }

            return model;
        }


        public static T ConvertDataRowToSingle(DataRow dt)
        {
            T model = new T();

            try
            {
                model = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(dt));
            }
            catch
            {

            }

            return model;
        }

    }

    public static class ModelHelper
    {

        /// <summary>
        /// 实体类转换成DataTable
        /// </summary>
        /// <param name="modelList">实体类列表</param>
        /// <returns></returns>
        public static DataTable ConvertSingleToDataTable(IList model)
        {
            DataTable dataTable = null;

            if (model != null)
            {


                dataTable = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(new List<IList>() { model }));
            }
            else
            {
                dataTable = new DataTable();
            }

            dataTable.TableName = typeof(IList).Name;

            return dataTable;

        }

        /// <summary>
        /// 实体类转换成DataTable
        /// </summary>
        /// <param name="modelList">实体类列表</param>
        /// <returns></returns>
        public static DataTable ConvertListToDataTable(IList modelList)
        {
            DataTable dataTable = null;

            if (modelList.Count > 0)
            {
                dataTable = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(modelList));
            }
            else
            {
                dataTable = new DataTable();
            }

           // dataTable.TableName = typeof(IList).Name;

            return dataTable;

        }

    }
}
