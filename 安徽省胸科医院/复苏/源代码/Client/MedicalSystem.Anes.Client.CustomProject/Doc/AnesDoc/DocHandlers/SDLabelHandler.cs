using MedicalSystem.Anes.Client.CustomProject;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms; 

namespace Medicalsystem.Anes.Custom.CustomProject
{
    public class SDLabelHandler : LabelHandler
    {
        public override void BindDataToUI(MLabel control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            base.BindDataToUI(control, dataSources);

            if (control.Name == "PageIndex")
            {
                //_pageSetting.PagerDesc[_pageSetting.CurrentPageIndex].IsMain
                control.Text = string.Format("第{0}页/共{1}页", PagerSetting.CurrentPageIndex + 1, PagerSetting.TotalPageCount);
            }
            if (control.Name == "DocTitle")
            {
                control.Text = ExtendApplicationContext.Current.HospitalName;
            }
        }
        
        /// <summary>
        /// 控件属性事件设置
        /// </summary>
        /// <param name="element"></param>
        public override void ControlSetting(MLabel control)
        {
            base.ControlSetting(control);
        }
    }
}
