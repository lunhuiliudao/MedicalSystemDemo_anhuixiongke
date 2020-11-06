/*----------------------------------------------------------------
      // Copyright (C) 2005 ���˹��(����)ҽ�ƿƼ���չ���޹�˾
      // �ļ�����MessageBoxForm.cs
      // �ļ�������������Ϣ�Ի�����
      //
      // 
      // ������ʶ��������-2008-01-05
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.Document.Controls;

namespace MedicalSystem.Anes.Document.Constants
{

    /// <summary>
    /// ��Ϣ�Ի�����
    /// </summary>
    public partial class MessageBoxForm : XtraForm
    {

        #region ���췽��

        public MessageBoxForm()
        {
            InitializeComponent();
           
            StartPosition = FormStartPosition.CenterParent;
        }

        #endregion ���췽��

        #region ����

        /// <summary>
        /// ��Ϣ��ʾ�ı�
        /// </summary>
        private static string _text;

        /// <summary>
        /// ��Ϣ��ʾ��ť
        /// </summary>
        private static MessageBoxButtons _buttons;

        /// <summary>
        /// ��Ϣͼ��
        /// </summary>
        private static MessageBoxIcon _icon;

        /// <summary>
        /// ������ѡ������
        /// </summary>
        private string singleInputSelectType;
        private string[] singleInputSelectTypes;

        /// <summary>
        /// ������ѡ���ؼ�
        /// </summary>
        private Control singleInputSelectControl;
        private Control[] singleInputSelectControls;
        private System.Windows.Forms.Label[] inputLabels;

        /// <summary>
        /// ������ѡ�����
        /// </summary>
        private object resultObject;
        private object[] resultObjects;

        private static int _timeOut = 0;

        private static MessageBoxForm _form;

        #endregion ����

        #region ����

        /// <summary>
        /// ��ʾ��Ϣ��ʾ��
        /// </summary>
        /// <param name="text">��ʾ����</param>
        /// <param name="caption">�����</param>
        /// <param name="buttons">�ɼ���ť</param>
        /// <param name="icon">��ʾͼ��</param>
        /// <returns>�û�������</returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(text, caption, buttons, icon, 0);
        }

        /// <summary>
        /// ��ʾ��Ϣ��ʾ��
        /// </summary>
        /// <param name="text">��ʾ����</param>
        /// <param name="caption">�����</param>
        /// <param name="buttons">�ɼ���ť</param>
        /// <param name="icon">��ʾͼ��</param>
        /// <param name="timeout">�Զ��ر����ȴ�ʱ�䣬���������0���Զ��ر�</param>
        /// <returns></returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, int timeout)
        {
            if (_form == null)
            {
                _form = new MessageBoxForm();
                _form.ShowInTaskbar = false;
            }
            _form.Text = caption;
            _form.Height = 190;
            _form.Visible = false;
            _text = text;
            _icon = icon;
            _buttons = buttons;
            _timeOut = timeout;
            switch (_buttons)
            {
                case MessageBoxButtons.OK:
                    _form.btnOK.Visible = true;
                    //_form.Height = 150;
                    _form.CancelButton = _form.btnOK;
                    //_form.Show();
                    //return DialogResult.OK;
                    break;
                case MessageBoxButtons.OKCancel:
                    _form.btnOK.Visible = true;
                    _form.btnCancel.Visible = true;
                    break;
                case MessageBoxButtons.YesNo:
                    _form.btnOK.DialogResult = DialogResult.Yes;
                    _form.btnOK.Text = "��";
                    _form.btnCancel.DialogResult = DialogResult.No;
                    _form.btnCancel.Text = "��";
                    _form.btnOK.Visible = true;
                    _form.btnCancel.Visible = true;
                    break;
                case MessageBoxButtons.RetryCancel:
                    _form.btnOK.DialogResult = DialogResult.Retry;
                    _form.btnOK.Text = "����";
                    _form.btnOK.Visible = true;
                    _form.btnCancel.Visible = true;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    _form.btnOK.DialogResult = DialogResult.Yes;
                    _form.btnOK.Text = "��";
                    _form.btnOK.Visible = true;
                    _form.btnCancel.Visible = true;
                    _form.btnNo.Visible = true;
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    _form.btnOK.DialogResult = DialogResult.Abort;
                    _form.btnOK.Text = "����";
                    _form.btnNo.DialogResult = DialogResult.Retry;
                    _form.btnNo.Text = "����";
                    _form.btnCancel.DialogResult = DialogResult.Ignore;
                    _form.btnCancel.Text = "��Ч";
                    _form.btnOK.Visible = true;
                    _form.btnCancel.Visible = true;
                    _form.btnNo.Visible = true;
                    break;
            }
            if (_timeOut > 0)
            {
                _form.timer1.Enabled = true;
                _form.timer1_Tick(null, null);
            }
            _form.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = _form.ShowDialog();
            _form = null;
            return result;
        }

        /// <summary>
        /// ������(ѡ��)��
        /// </summary>
        /// <param name="text">��ʾ����</param>
        /// <param name="caption">�����</param>
        /// <param name="initValue">��ʼֵ</param>
        /// <returns>����ѡ����</returns>
        public object SingleInputSelect(string text, string caption, object initValue)
        {
            return SingleInputSelect(text, caption, initValue, "yyyy-MM-dd HH:mm");
        }

        /// <summary>
        /// ��������(ѡ��)��
        /// </summary>
        /// <param name="text">��ʾ����</param>
        /// <param name="caption">�����</param>
        /// <param name="initValue">��ʼֵ</param>
        /// <param name="inputFormat">�����ʽ-��������ʱʹ�û���*�ű�ʾ�ı���Ϊ��������</param>
        /// <returns>����ѡ����</returns>
        public DialogResult MultiInputSelect(ref InputStruct[] inputParameters)
        {
            ///���û�г�ʼֵ���׳��쳣
            foreach (InputStruct inputParameter in inputParameters)
            {
                if (inputParameter.InitValue == null)
                {
                    throw new Exception("Please give a not null initilized value!");
                }
            }

            resultObjects = new object[inputParameters.Length];
            singleInputSelectControls = new Control[inputParameters.Length];
            singleInputSelectTypes = new string[inputParameters.Length];
            inputLabels = new Label[inputParameters.Length];

            for(int i = 0; i < inputParameters.Length; i++)
            {
                InputStruct inputParameter = inputParameters[i];
                //lblInput.Text = inputParameter.Text;
                //lblInput.Visible = true;
                
                Text = inputParameter.Caption;
                btnOK.Visible = true;
                btnCancel.Visible = true;
                inputLabels[i] = new Label();
                inputLabels[i].Text = inputParameter.Text;

                ///��������
                singleInputSelectTypes[i] = inputParameter.InitValue.GetType().ToString();

                ///��������ѡ��ؼ�
                switch (singleInputSelectTypes[i])
                {
                    case "System.DateTime":
                        if (inputParameter.InputFormat.Equals("ʱ��"))
                        {
                            singleInputSelectControls[i] = new MaskedTextBox();
                            (singleInputSelectControls[i] as MaskedTextBox).Mask = "00:00";
                            (singleInputSelectControls[i] as MaskedTextBox).Font = new Font("����", 20);
                            (singleInputSelectControls[i] as MaskedTextBox).InsertKeyMode = InsertKeyMode.Overwrite;
                            (singleInputSelectControls[i] as MaskedTextBox).Text = ((DateTime)inputParameter.InitValue).ToString("HH:mm");
                            (singleInputSelectControls[i] as MaskedTextBox).KeyDown += Key_Down;
                            (singleInputSelectControls[i] as MaskedTextBox).KeyUp += Key_Up;
                            (singleInputSelectControls[i] as MaskedTextBox).TextChanged += Text_Changed;
                        }
                        else
                        {
                            singleInputSelectControls[i] = new DateTimePicker();
                            (singleInputSelectControls[i] as DateTimePicker).Format = DateTimePickerFormat.Custom;
                            (singleInputSelectControls[i] as DateTimePicker).Font = new Font("����", 20);
                            (singleInputSelectControls[i] as DateTimePicker).CustomFormat = inputParameter.InputFormat;
                            if (inputParameter.InputFormat.ToLower().Contains("hh:mm"))
                            {
                                (singleInputSelectControls[i] as DateTimePicker).ShowUpDown = true;
                            }
                            (singleInputSelectControls[i] as DateTimePicker).Value = (DateTime)inputParameter.InitValue;
                        }
                        break;
                    case "System.String[]":
                        singleInputSelectControls[i] = new DevExpress.XtraEditors.ComboBoxEdit();
                        (singleInputSelectControls[i] as DevExpress.XtraEditors.ComboBoxEdit).Properties.Items.AddRange(inputParameter.InitValue as string[]);
                        if ((inputParameter.InitValue as string[]).Length > 0)
                        {
                            (singleInputSelectControls[i] as DevExpress.XtraEditors.ComboBoxEdit).SelectedIndex = 0;
                        }
                        break;
                    default:
                        singleInputSelectControls[i] = new MedTextBox();
                        (singleInputSelectControls[i] as MedTextBox).Text = inputParameter.InitValue.ToString();
                        if (inputParameter.InputFormat.Equals("*"))
                        {
                            (singleInputSelectControls[i] as MedTextBox).PasswordChar = '*';
                        }
                        break;
                }

                singleInputSelectControls[i].Left = lblInput.Left;
                singleInputSelectControls[i].Width = ClientRectangle.Width - singleInputSelectControls[i].Left * 2;
                inputLabels[i].Left = lblInput.Left;
                inputLabels[i].Top = lblInput.Top + i * (inputLabels[i].Height + singleInputSelectControls[i].Height + 2);
                singleInputSelectControls[i].Top = inputLabels[i].Top + inputLabels[i].Height;
                Controls.Add(inputLabels[i]);
                Controls.Add(singleInputSelectControls[i]);
                singleInputSelectControls[i].TabIndex = i;

                if (singleInputSelectControls[i] is MaskedTextBox)
                {
                    (singleInputSelectControls[i] as MaskedTextBox).Enter += new EventHandler(
                        delegate(object sender1, EventArgs e1)
                        {
                            (sender1 as MaskedTextBox).SelectAll();
                        }
                    );
                }

            }

            DialogResult ret = ShowDialog();

            for (int i = 0; i < inputParameters.Length; i++)
            {
                inputParameters[i].InitValue = resultObjects[i];
            }

            return ret;

        }


        /// <summary>
        /// ������(ѡ��)��
        /// </summary>
        /// <param name="text">��ʾ����</param>
        /// <param name="caption">�����</param>
        /// <param name="initValue">��ʼֵ</param>
        /// <param name="inputFormat">�����ʽ-��������ʱʹ�û���*�ű�ʾ�ı���Ϊ��������</param>
        /// <returns>����ѡ����</returns>
        public object SingleInputSelect(string text, string caption, object initValue, string inputFormat)
        {
            return SingleInputSelect(text, caption, initValue, inputFormat, null);
        }

        private List<string> _list;
        public object SingleInputSelect(string text, string caption, object initValue,string inputFormat,List<string> list)
        {
            ///���û�г�ʼֵ���׳��쳣
            if (initValue == null)
            {
                throw new Exception("Please give a not null initilized value!");
            }

            _list = list;

            resultObject = null;

            lblInput.Text = text;
            lblInput.Visible = true;
            Text = caption;
            _buttons = MessageBoxButtons.OKCancel;
            _text = null;
            btnOK.Visible = true;
            btnCancel.Visible = true;

            ///��������
            singleInputSelectType = initValue.GetType().ToString();

            ///��������ѡ��ؼ�
            switch (singleInputSelectType)
            {
                case "System.DateTime":
                    if (inputFormat.Equals("ʱ��"))
                    {
                        singleInputSelectControl = new MaskedTextBox();
                        (singleInputSelectControl as MaskedTextBox).Mask = "00:00";
                        (singleInputSelectControl as MaskedTextBox).Font = new Font("����", 20);
                        (singleInputSelectControl as MaskedTextBox).InsertKeyMode = InsertKeyMode.Overwrite;
                        (singleInputSelectControl as MaskedTextBox).Text = ((DateTime)initValue).ToString("HH:mm");
                        (singleInputSelectControl as MaskedTextBox).KeyDown += Key_Down;
                        (singleInputSelectControl as MaskedTextBox).KeyUp += Key_Up;
                        (singleInputSelectControl as MaskedTextBox).TextChanged += Text_Changed;
                    }
                    else if (inputFormat.Equals("��"))
                    {
                        singleInputSelectControl = new MaskedTextBox();
                        (singleInputSelectControl as MaskedTextBox).Mask = "00:00:00";
                        (singleInputSelectControl as MaskedTextBox).Font = new Font("����", 20);
                        (singleInputSelectControl as MaskedTextBox).InsertKeyMode = InsertKeyMode.Overwrite;
                        (singleInputSelectControl as MaskedTextBox).Text = ((DateTime)initValue).ToString("HH:mm:ss");
                        (singleInputSelectControl as MaskedTextBox).KeyDown += Key_Down;
                        (singleInputSelectControl as MaskedTextBox).KeyUp += Key_Up;
                        (singleInputSelectControl as MaskedTextBox).TextChanged += Text_Changed;
                    }
                    else
                    {
                        singleInputSelectControl = new DateTimePicker();
                        (singleInputSelectControl as DateTimePicker).Format = DateTimePickerFormat.Custom;
                        (singleInputSelectControl as DateTimePicker).Font = new Font("����", 20);
                        (singleInputSelectControl as DateTimePicker).CustomFormat = inputFormat;
                        if (inputFormat.ToLower().Contains("hh:mm"))
                        {
                            (singleInputSelectControl as DateTimePicker).ShowUpDown = true;
                        }
                        (singleInputSelectControl as DateTimePicker).Value = (DateTime)initValue;
                    }
                    break;
                case "System.String[]":
                    singleInputSelectControl = new DevExpress.XtraEditors.ComboBoxEdit();
                    (singleInputSelectControl as DevExpress.XtraEditors.ComboBoxEdit).Properties.Items.AddRange(initValue as string[]);
                    if ((initValue as string[]).Length > 0)
                    {
                        (singleInputSelectControl as DevExpress.XtraEditors.ComboBoxEdit).SelectedIndex = 0;
                        if (!string.IsNullOrEmpty(inputFormat) && inputFormat.Equals("noedit"))
                        {
                            (singleInputSelectControl as DevExpress.XtraEditors.ComboBoxEdit).Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        }
                    }
                    break;
                default:
                    singleInputSelectControl = new MedTextBox();
                    (singleInputSelectControl as MedTextBox).Text = initValue.ToString();
                    if (inputFormat.Equals("*"))
                    {
                        (singleInputSelectControl as MedTextBox).PasswordChar = '*';
                    }
                    btnOK.Enabled = false;
                    singleInputSelectControl.TextChanged += new EventHandler(singleInputSelectControl_TextChanged);
                    if (_list != null)
                    {
                        singleInputSelectControl.DoubleClick += new EventHandler(singleInputSelectControl_DoubleClick);
                    }
                    break;
            }

            singleInputSelectControl.Left = lblInput.Left;
            singleInputSelectControl.Width = ClientRectangle.Width - singleInputSelectControl.Left * 2;
            singleInputSelectControl.Top = lblInput.Top + lblInput.Height + 5;
            Controls.Add(singleInputSelectControl);
            singleInputSelectControl.TabIndex = 0;

            if (singleInputSelectControl is MaskedTextBox)
            {
                (singleInputSelectControl as MaskedTextBox).Enter += new EventHandler(
                    delegate(object sender1, EventArgs e1)
                    {
                        (sender1 as MaskedTextBox).SelectAll();
                    }
                );
            }

            ShowDialog();

            return resultObject;

        }

        private void singleInputSelectControl_TextChanged(object sender, EventArgs e)
        {
            string s = (sender as Control).Text;
            if (string.IsNullOrEmpty(s) || (_list != null && _list.Contains(s)))
            {
                btnOK.Enabled = false;
            }
            else
            {
                btnOK.Enabled = true;
            }
        }

        private void singleInputSelectControl_DoubleClick(object sender, EventArgs e)
        {
            Dialog.ShowCustomSelection(_list, "", sender as Control, new Size(300, 300), new EventHandler(delegate(object s1, EventArgs e1)
                {
                    if (s1 is int)
                    {
                        (sender as Control).Text = _list[(int)s1];
                    }
                }));
        }

        /// <summary>
        /// ���̰���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Key_Down(object sender, KeyEventArgs e)
        {
            if (sender is MaskedTextBox)
            {
                //if ((sender as MaskedTextBox).SelectionStart == 2)
                //{
                //    (sender as MaskedTextBox).SelectionStart = 4;
                //}
            }
        }

        /// <summary>
        /// ���̰���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Key_Up(object sender, KeyEventArgs e)
        {
            if (sender is MaskedTextBox)
            {
                //if((sender as MaskedTextBox).IsOverwriteMode = 
                //    ((sender as MaskedTextBox).SelectionStart == 2)
                //{
                //    (sender as MaskedTextBox).SelectionStart = 4;
                //}
            }
        }

        /// <summary>
        /// ֵ�ı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Text_Changed(object sender, EventArgs e)
        {
            if (sender is MaskedTextBox)
            {
                //if (((sender as MaskedTextBox).GetPositionFromCharIndex( .SelectionStart == 1))
                //{
                //    (sender as MaskedTextBox).SelectionStart = 4;
                //}
            }
        }

        /// <summary>
        /// ������ʾ��Ϣ
        /// </summary>
        /// <param name="e">�����¼�����</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ///���û����ʾ�ı���Ϣ�򲻴���
            if (string.IsNullOrEmpty(_text))
            {
                return;
            }

            ///������ʾͼ��
            //switch (_icon)
            //{
            //    case MessageBoxIcon.Information:
            //        e.Graphics.DrawIcon(Resources.Information, new Rectangle(50, 50, 32, 32));
            //        break;
            //    case MessageBoxIcon.Warning:
            //        e.Graphics.DrawIcon(Resources.Warning, new Rectangle(50, 50, 32, 32));
            //        break;
            //    case MessageBoxIcon.Error:
            //        e.Graphics.DrawIcon(Resources.Error, new Rectangle(50, 50, 32, 32));
            //        break;
            //    case MessageBoxIcon.Question:
            //        e.Graphics.DrawIcon(Resources.Question, new Rectangle(50, 50, 32, 32));
            //        break;
            //    case MessageBoxIcon.None:
            //        break;
            //}

            ///������ʾ�ı�
            e.Graphics.DrawString(_text, this.Font, new SolidBrush(this.ForeColor), new RectangleF(100, 50, 300, 250));
        }

        #endregion ����

        #region �ؼ��¼�

        private void btnOK_Click(object sender, EventArgs e)
        {
            ///������ѡ��
            if (lblInput.Visible)
            {
                switch (singleInputSelectType)
                {
                    case "System.DateTime":
                        if (singleInputSelectControl is DateTimePicker)
                        {
                            resultObject = (singleInputSelectControl as DateTimePicker).Value;
                        }
                        else
                        {
                            try
                            {
                                resultObject = DateTime.Parse((singleInputSelectControl as MaskedTextBox).Text);
                            }
                            catch
                            {
                                Dialog.MessageBox("����ʱ�����", MessageBoxIcon.Information);
                                resultObject = null;
                            }
                        }
                        break;
                    case "System.String[]":
                        resultObject = (singleInputSelectControl as DevExpress.XtraEditors.ComboBoxEdit).Text;
                        break;
                    default:
                        resultObject = (singleInputSelectControl as MedTextBox).Text;
                        break;
                }
            }
            else if ((singleInputSelectControls != null) && (singleInputSelectControls.Length > 0) && (singleInputSelectControls[0] != null))
            {
                for (int i = 0; i < singleInputSelectControls.Length; i++)
                {
                    switch (singleInputSelectTypes[i])
                    {
                        case "System.DateTime":
                            if (singleInputSelectControls[i] is DateTimePicker)
                            {
                                resultObjects[i] = (singleInputSelectControls[i] as DateTimePicker).Value;
                            }
                            else
                            {
                                try
                                {
                                    resultObjects[i] = DateTime.Parse((singleInputSelectControls[i] as MaskedTextBox).Text);
                                }
                                catch
                                {
                                    Dialog.MessageBox("����ʱ�����", MessageBoxIcon.Information);
                                    resultObjects[i] = null;
                                }
                            }
                            break;
                        case "System.String[]":
                            resultObjects[i] = (singleInputSelectControl as DevExpress.XtraEditors.ComboBoxEdit).Text;
                            break;
                        default:
                            resultObjects[i] = (singleInputSelectControls[i] as MedTextBox).Text;
                            break;
                    }
                }
            }
        }

        #endregion �ؼ��¼�

        private void MessageBoxForm_Activated(object sender, EventArgs e)
        {
            //if (_buttons == MessageBoxButtons.OK)
            //{
            //    Form frm = Application.OpenForms[0];
            //    FormBorderStyle = FormBorderStyle.None;
            //    Left =frm.Left + frm.Width - Width - 3;
            //    Top = frm.Top + frm.Height - Height - 3;
            //    Cursor.Position = new Point(Left + (int)(Width / 2), Top + (int)(Height / 2));
            //    TopMost = true;
            //    Focus();
            //}
            //else
            {
                //FormBorderStyle = FormBorderStyle.FixedDialog;
            }
            if (singleInputSelectControl != null)
            {
                singleInputSelectControl.Focus();
            }
            else if ((singleInputSelectControls != null) && (singleInputSelectControls.Length > 0) && (singleInputSelectControls[0] != null) && (singleInputSelectControls[0].Visible))
            {
                singleInputSelectControls[0].Focus();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_timeOut > 0)
            {
                lblTimeOut.Text = string.Format("��Ϣ��ʾ�Ի���ϵͳ����{0}����Զ��ر�",_timeOut--);
            }
            else
            {
                Close();
            }
        }

        private void MessageBoxForm_Leave(object sender, EventArgs e)
        {
            //if (_buttons == MessageBoxButtons.OK) Close();
        }

        private void MessageBoxForm_MouseLeave(object sender, EventArgs e)
        {
            //if (_buttons == MessageBoxButtons.OK)
            //{
            //    if (!ClientRectangle.Contains(PointToClient(Control.MousePosition)))
            //    {
            //        Hide();
            //    }
            //}
        }

        private void MessageBoxForm_Paint(object sender, PaintEventArgs e)
        {
            //if (FormBorderStyle == FormBorderStyle.None)
            //{
            //    ControlPaint.DrawBorder3D(e.Graphics, e.ClipRectangle);
            //}
        }

        private void MessageBoxForm_KeyDown(object sender, KeyEventArgs e)
        {
            //if (_buttons == MessageBoxButtons.OK) Hide();
        }

        private void MessageBoxForm_BackColorChanged(object sender, EventArgs e)
        {
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(142,193,238)), e.ClipRectangle);
        }

    }
}
