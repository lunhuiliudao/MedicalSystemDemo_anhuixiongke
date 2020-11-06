using System;
using System.Collections.Generic;
using Dapper.Data;

namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// 体征合并后的表
    /// </summary>
    public class MED_VITAL_SIGN : BaseModel
    {
        /// <summary>
        /// 主键 时间点
        /// </summary>
        private DateTime _timePoint;
        public DateTime TIME_POINT
        {
            get
            {
                if (_timePoint.Second == 30)
                    return this._timePoint;
                else
                    return Convert.ToDateTime(this._timePoint.ToString("yyyy-MM-dd HH:mm"));
            }
            set
            {
                this._timePoint = value;
            }
        }
        /// <summary>
        /// 主键 项目编号	;对应体征项目代码表
        /// </summary>
        private string _itemCode;
        public string ITEM_CODE
        {
            get { return this._itemCode; }
            set
            {
                this._itemCode = value;
            }
        }
        /// <summary>
        /// 采集项目名称	;冗余字段，为查询方便
        /// </summary>
        private string itemName;
        public string ITEM_NAME
        {
            get { return this.itemName; }
            set
            {
                this.itemName = value;
            }
        }
        /// <summary>
        /// 采集项目值
        /// </summary>
        private string itemValue;
        public string ITEM_VALUE
        {
            get { return this.itemValue; }
            set
            {
                this.itemValue = value;
                RaisePropertyChanged("ITEM_VALUE");
            }
        }
        /// <summary>
        /// 修改标志 1-修改；2-增加
        /// </summary>
        private string flag;
        public string Flag
        {
            get { return this.flag; }
            set
            {
                this.flag = value;
                RaisePropertyChanged("Flag");
            }
        }

        private bool isShowColumn;

        public bool IsShowColumn
        {
            get { return isShowColumn; }
            set
            {
                isShowColumn = value;
                RaisePropertyChanged("IsShowColumn");
            }
        }


        private bool isReadOnlyColumn;

        public bool IsReadOnlyColumn
        {
            get { return isReadOnlyColumn; }
            set
            {
                isReadOnlyColumn = value;
                RaisePropertyChanged("IsReadOnlyColumn");
            }
        }
    }
}
