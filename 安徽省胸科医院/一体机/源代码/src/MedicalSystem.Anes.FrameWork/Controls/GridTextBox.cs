using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Drawing.Design;

namespace MedicalSystem.Anes.FrameWork
{
    /// <summary>
    /// 文本下来菜单
    /// </summary>
    public class GridTextBox : MTextBoxBorder
    {
        public GridTextBox()
        {
            PopupDataSource = null;
            PopupMultiSelect = false;
            PopupGridViewMember = "";
            PopupDisplayMember = "";
            PopupValueMember = "";
            PopupWidth = 280;
            PopupPageSize = 10;
            PopupMultiChar = ",";
        }

        #region Popup Props
        [DefaultValue(false)]
        public bool PopupMultiSelect { get; set; }
        [DefaultValue(",")]
        public string PopupMultiChar { get; set; }
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue("")]
        public object PopupDataSource { get; set; }
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string PopupGridViewMember { get; set; }
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string PopupDisplayMember { get; set; }
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string PopupValueMember { get; set; }
        [DefaultValue(280)]
        public int PopupWidth { get; set; }
        [DefaultValue(10)]
        public int PopupPageSize { get; set; }

        #endregion

        #region 弹出下拉列表

        private GridViewPopup Popup
        {
            get
            {
                GridViewPopup popup = new GridViewPopup()
                {
                    MultiSelect = this.PopupMultiSelect,
                    MultiChar = this.PopupMultiChar,
                    DataSource = this.PopupDataSource,
                    GridViewMember = this.PopupGridViewMember,
                    DisplayMember  = this.PopupDisplayMember,
                    ValueMember = this.PopupValueMember,
                    PageSize = this.PopupPageSize
                };
                popup.SelectedValue = Convert.ToString(this.Data);
                return popup;
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            if (this.Focused && string.IsNullOrEmpty(Convert.ToString(this.Value)) && PopupDataSource != null)
            {
                var popup = Popup;
                popup.DataBind();
                popup.Selected += PopupControl_Selected;
                PopupForm.Show(this, popup, this.PopupWidth, popup.Height);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && PopupDataSource != null)
            {
                e.Handled = true;
                var popup = Popup;
                popup.DataBind();
                popup.Selected += PopupControl_Selected;
                PopupForm.Show(this, popup, this.PopupWidth, popup.Height);
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

        void PopupControl_Selected(GridViewPopupEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            this.Data = e.Value;
            this.Text = e.Display;
            isChanged = true;

            if (e.IsClosed)
            {
                FocusHelper.FocusNext(this, false);
            }
        }

        #endregion

        private string dataText = null;

        public override object Data
        {
            get
            {
                return base.Data;
            }
            set
            {
                if (this.PopupDataSource != null && PopupDisplayMember != PopupValueMember)
                {
                    this.Text = Popup.GetDisplayByValue(Convert.ToString(value));
                }
                else
                {
                    this.Text = Convert.ToString(value);
                }
                
                base.Data = value;
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                dataText = value;
            }
        }
        private bool isChanged = false;
        public override bool IsChanged
        {
            get
            {
                return isChanged || dataText != this.Text;
            }
        }

    }

}
