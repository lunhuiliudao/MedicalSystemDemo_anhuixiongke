/*----------------------------------------------------------------
      // Copyright (C) 2010 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedReportView.cs
      // 文件功能描述：报表设计器控件
      //
      // 
      // 修改标识：戴呈祥-2010-05-19
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using MedicalSystem.Anes.Document.Controls;



namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 报表设计器控件
    /// </summary>
    [ToolboxItem(false)]
    public class MedReportView : UserControl
    {
        public MedReportView()
        {
            components = new System.ComponentModel.Container();
            InitializeComponent();
        }

        public MedReportView(string reportName)
            : this()
        {
            _reportName = reportName;
            ResetReport();
        }

        public void LoadReport(string reportName)
        {
            _reportName = reportName;
            ResetReport();
        }

        protected string _reportName;
        private System.ComponentModel.IContainer components = null;

        public void AddComponent(Component component)
        {
            components.Add(component);
        }

        public System.ComponentModel.ComponentCollection Components
        {
            get
            {
                return components.Components;
            }
        }

        public void ResetReport()
        {
            Controls.Clear();
            AssemblyHelper.ReadFile(_reportName, this);
            // InitControlValue(this);
            AutoScroll = false;

        }



        /// <summary>
        /// 获取所有某类控件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>返回控件集合</returns>
        public List<T> GetControls<T>() where T : Control
        {
            List<T> controls = new List<T>();
            GetControls<T>(this, controls);
            return controls;
        }
        // private Dictionary<Type, object> _controlCache = new Dictionary<Type, object>();
        /// <summary>
        /// 获取所有某类控件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <param name="list">存放控件的集合</param>
        private void GetControls<T>(Control parent, List<T> list) where T : Control
        {
            //if (parent.GetType().Equals(typeof(T)))
            if (parent is T)
            {
                list.Add((T)parent);
            }
            //else
            {
                //foreach (Control control in parent.Controls)
                for (int i = parent.Controls.Count - 1; i > -1; i--)
                {
                    Control control = parent.Controls[i];
                    GetControls<T>(control, list);
                }
            }
        }

        public List<T> GetComponents<T>() where T : Component
        {
            List<T> components = new List<T>();
            foreach (Component component in Components)
            {
                if (component is T)
                {
                    components.Add((T)component);
                }
            }
            return components;
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();
            // 
            // MedReportView
            // 
            this.Name = "MedReportView";
            this.ResumeLayout(false);

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }
    }
}
