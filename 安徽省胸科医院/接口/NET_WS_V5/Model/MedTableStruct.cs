using System;
using System.Collections.Generic;
using System.Text;


namespace MedicalSytem.Soft.Model
{
    public class MedTableStruct
    {
        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName
        {
            get;
            set;
        }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string ColumnName
        {
            get;
            set;
        }

        /// <summary>
        /// 数据类型
        /// </summary>
        public DataType DataType
        {
            get;
            set;
        }


        /// <summary>
        /// 字段长度
        /// </summary>
        public int DataLength
        {
            get;
            set;
        }


        /// <summary>
        /// 可空类型
        /// </summary>
        public bool IsNull
        {
            get;
            set;
        }

        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsPrimaryKey
        {
            get;
            set;
        }

        public object Value
        {
            get;
            set;
        }
    }

    public enum DataType
    {
        varchar2 = 1,
        nvarchar = 2,
        Date,
        DateTime,
        decimalType,
        numberType,
        intType,
    }
}
 
