/*----------------------------------------------------------------
      // Copyright (C) 2008 ���˹��(����)ҽ�ƿƼ���չ���޹�˾
      // �ļ�����ContextMenuForm.cs
      // �ļ������������˵�ʽ���壨�������壩
      //
      // 
      // ������ʶ��������-2008-10-24
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MedicalSystem.Anes.Document.Constants
{
    /// <summary>
    /// �˵�ʽ���壨�������壩
    /// </summary>
    public partial class ContextMenuForm : XtraForm
    {

        #region ���췽��

        /// <summary>
        /// ���췽��
        /// </summary>
        public ContextMenuForm()
        {
            InitializeComponent();
            Deactivate += new EventHandler(ContextMenuForm_Deactivate);
        }

        private void ContextMenuForm_Deactivate(object sender, EventArgs e)
        {
            Close();
        }

        #endregion ���췽��

        #region ����

        /// <summary>
        /// �����
        /// </summary>
        private bool _locked = false;

        /// <summary>
        /// ���ؼ�
        /// </summary>
        private Control _parentControl = null;

        #endregion ����

        #region ����

        /// <summary>
        /// �����
        /// </summary>
        public bool Locked
        {
            get { return _locked; }
            set 
            {
                _locked = value; 
            }
        }

        #endregion ����

        #region ����

        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="parent">���ؼ�</param>
        /// <param name="location">λ��</param>
        /// <param name="size">��С</param>
        /// <param name="control">������Ҫ���õĿؼ�</param>
        public void Show(Control parent, Point location, Size size, Control control)
        {
            _parentControl = parent;
            this.Location = parent.PointToScreen(location);
            this.Size = size;
            SetContainingControl(control);
            this.Show();
            this.Focus();
        }

        /// <summary>
        /// ���ÿؼ�
        /// </summary>
        /// <param name="control">Ҫ���õĿؼ�</param>
        private void SetContainingControl(Control control)
        {
            panelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
        }

        /// <summary>
        /// ���ش���
        /// </summary>
        new public void Hide()
        {
            base.Hide();
        }

        #endregion ����


        #region �¼�

        private void ContextMenuPanel_Deactivate(object sender, EventArgs e)
        {
            if (!Locked)
            {
                //Hide();
            }
        }

        private void ContextMenuPanel_Leave(object sender, EventArgs e)
        {
            if (!Locked)
            {
                //Hide();
            }
        }

        #endregion �¼�

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = e.ClipRectangle;
            rect.Inflate(-1,-1);
            ControlPaint.DrawBorder3D(e.Graphics, rect,Border3DStyle.Etched);
        }

    }
}