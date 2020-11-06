using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.FrameWork
{
    public class OpenForm
    {
        public OpenForm()
        { }

        public OpenForm(string name,List<string> allowList)
        {
            FormName = name;
            _allowOpenList = allowList;
        }

        /// <summary>
        /// 窗体名称
        /// </summary>
        public string FormName{get;set;}

        /// <summary>
        /// 允许打开的新窗体列表
        /// </summary>
        List<string> _allowOpenList = null;
        public List<string> AllowOpenList
        {
            get
            {
                return _allowOpenList;
            }

            set
            {
                _allowOpenList = value;
            } 
        }
    }
}
