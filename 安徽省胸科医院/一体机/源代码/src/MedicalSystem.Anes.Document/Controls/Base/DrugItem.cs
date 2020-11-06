/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：DrugItem.cs
      // 文件功能描述：药品
      //
      // 
      // 创建标识：戴呈祥-2010-12-16
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Document.Controls
{
    public class DrugItem
    {
        /// <summary>
        /// 编码
        /// </summary>
        private string _itemCode;
        public string ItemCode
        {
            get
            {
                return _itemCode;
            }
            set
            {
                _itemCode = value;
            }
        }

        /// <summary>
        /// 名称
        /// </summary>
        private string _itemName;
        public string ItemName
        {
            get
            {
                return _itemName;
            }
            set
            {
                _itemName = value;
            }
        }

        /// <summary>
        /// 大类
        /// </summary>
        private string _itemType;
        public string ItemType
        {
            get
            {
                return _itemType;
            }
            set
            {
                _itemType = value;
            }
        }

        /// <summary>
        /// 用量
        /// </summary>
        private double _dosage;
        public double Dosage
        {
            get
            {
                return _dosage;
            }
            set
            {
                _dosage = value;
            }
        }

        /// <summary>
        /// 单位
        /// </summary>
        private string _itemUnit;
        public string ItemUnit
        {
            get
            {
                return _itemUnit;
            }
            set
            {
                _itemUnit = value;
            }
        }

    }
}
