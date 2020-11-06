using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{
    [Serializable]
    public class GridRowAliasName
    {
        public GridRowAliasName()
        {
        }

        public override string ToString()
        {
            return _alias + "[" + _name + "]";
        }

        private string _name = string.Empty;
        [DisplayName("名称")]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private string _alias = string.Empty;
        [DisplayName("别名")]
        public string Alias
        {
            get
            {
                return _alias;
            }
            set
            {
                _alias = value;
            }
        }

        private int _dotNumber = 0;
        /// <summary>
        /// 小数位数
        /// </summary>
        [DisplayName("小数位数")]
        public int DotNumber
        {
            get
            {
                return _dotNumber;
            }
            set
            {
                if (value >= 0)
                {
                    _dotNumber = value;
                }
                else
                {
                    _dotNumber = 0;
                }
            }
        }

        private bool _alwaysNeeded = false;
        [DisplayName("总是显示")]
        public bool AlwaysNeeded
        {
            get
            {
                return _alwaysNeeded;
            }
            set
            {
                _alwaysNeeded = value;
            }
        }

    }
}
