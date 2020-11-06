using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Data;
using MedicalSystem.Anes.Document.Constants; 

namespace MedicalSystem.Anes.Document.Utilities
{
    public class Dialog
    {
        /// <summary>
        /// 标题常量
        /// </summary>
        public const string CAPTION = " 提示信息 ";

        public static void FindAndReplace(Control parent,EventHandler eventHandle)
        {
            
        }

        /// <summary>
        /// 消息框
        /// </summary>
        /// <param name="text">提示文本</param>
        /// <returns>对话框选择结果</returns>
        public static DialogResult MessageBox(string text)
        {
            return MessageBox(text, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 消息框
        /// </summary>
        /// <param name="text">提示文本</param>
        /// <returns>对话框选择结果</returns>
        public static DialogResult MessageBox(string text, int displaySeconds)
        {
            return MessageBox(text, CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, displaySeconds);
        }

        /// <summary>
        /// 消息框
        /// </summary>
        /// <param name="text">提示文本</param>
        /// <param name="icon">图标</param>
        /// <returns>对话框选择结果</returns>
        public static DialogResult MessageBox(string text, MessageBoxIcon icon)
        {
            return MessageBox(text, CAPTION, MessageBoxButtons.OK, icon);
        }

        /// <summary>
        /// 消息框
        /// </summary>
        /// <param name="text">提示文本</param>
        /// <param name="caption">标题</param>
        /// <param name="buttons">按钮</param>
        /// <param name="icon">图标</param>
        /// <returns>对话框选择结果</returns>
        public static DialogResult MessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox(text, caption, buttons, icon, MessageBoxDefaultButton.Button1, 0);
        }

        /// <summary>
        /// 消息框
        /// </summary>
        /// <param name="text">提示文本</param>
        /// <param name="caption">标题</param>
        /// <param name="buttons">按钮</param>
        /// <param name="icon">图标</param>
        /// <returns>对话框选择结果</returns>
        public static DialogResult MessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, int displaySeconds)
        {
            return DevExpress.XtraEditors.XtraMessageBox.Show(text,caption,buttons,icon);
           // return MessageBoxForm.Show(text, caption, buttons, icon, displaySeconds);
        }

        /// <summary>
        /// 简单输入(选择)框
        /// </summary>
        /// <param name="text">提示内容</param>
        /// <param name="caption">框标题</param>
        /// <param name="initValue">初始值</param>
        /// <param name="inputFormat">输入格式-日期输入时使用</param>
        /// <returns>输入选择结果</returns>
        public static object SingleInputSelect(string text, string caption, object initValue, string inputFormat)
        {
            return new MessageBoxForm().SingleInputSelect(text, caption, initValue, inputFormat);
        }

        /// <summary>
        /// 简单输入(选择)框
        /// </summary>
        /// <param name="text">提示内容</param>
        /// <param name="initValue">初始值</param>
        /// <returns>输入选择结果</returns>
        public static object SingleInputSelect(string text, object initValue)
        {
            return new MessageBoxForm().SingleInputSelect(text, CAPTION, initValue);
        }

        public static object SingleInputSelect(string text, string caption, object initValue, string inputFormat, List<string> list)
        {
            return new MessageBoxForm().SingleInputSelect(text, caption, initValue,inputFormat,list);
        }

        /// <summary>
        /// 简单输入(选择)框
        /// </summary>
        /// <param name="text">提示内容</param>
        /// <param name="initValue">初始值</param>
        /// <param name="inputFormat">输入格式-日期输入时使用</param>
        /// <returns>输入选择结果</returns>
        public static object SingleInputSelect(string text, object initValue, string inputFormat)
        {
            return SingleInputSelect(text, CAPTION, initValue, inputFormat);
        }

        ///// <summary>
        ///// 简单输入(选择)框
        ///// </summary>
        ///// <param name="text">提示内容</param>
        ///// <param name="caption">框标题</param>
        ///// <param name="initValue">初始值</param>
        ///// <returns>输入选择结果</returns>
        //public static object SingleInputSelect(string text, string caption, object initValue)
        //{
        //    return new Com.MedicalSystem.Common.Controls.MessageBoxForm().SingleInputSelect(text, caption, initValue);
        //}

        /// <summary>
        /// 复合输入(选择)框
        /// </summary>
        /// <param name="text">提示内容</param>
        /// <param name="caption">框标题</param>
        /// <param name="initValue">初始值</param>
        /// <param name="inputFormat">输入格式-日期输入时使用或者*号表示文本框为密码输入</param>
        /// <returns>输入选择结果</returns>
        public static DialogResult MultiInputSelect(ref InputStruct[] inputParameters)
        {
            //InputStruct[] inputP = new InputStruct[inputParameters.Length];
            //for (int i = 0; i < inputParameters.Length; i++)
            //{
            //    inputP[i].Text = inputParameters[i].Text;
            //    inputP[i].Caption = inputParameters[i].Caption;
            //    inputP[i].InputFormat = inputParameters[i].InputFormat;
            //    inputP[i].InitValue = inputParameters[i].InitValue;
            //}
            return new MessageBoxForm().MultiInputSelect(ref inputParameters);
        }

        /// <summary>
        /// 显示客户对话框
        /// </summary>
        /// <param name="control">客户添加控件</param>
        /// <param name="caption">标题</param>
        public static void ShowCustomDialog(Control control, string caption)
        {
            Form frm = new Form();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Width = Screen.PrimaryScreen.Bounds.Width - 20;
            frm.Height = Screen.PrimaryScreen.Bounds.Height - 40;
            frm.ShowInTaskbar = false;
            frm.Left = 20;
            frm.Top = 5;
            frm.Text = caption;
            Panel panelBottom = new Panel();
            Button buttonOK = new Button();
            buttonOK.Text = "确定";
            buttonOK.ForeColor = System.Drawing.Color.Black;
            buttonOK.Top = 8;
            buttonOK.DialogResult = DialogResult.OK;
            panelBottom.Height = 40;
            panelBottom.Left = 5;
            panelBottom.Controls.Add(buttonOK);
            panelBottom.Resize +=
                new EventHandler(
                    delegate(object sender, EventArgs e)
                    {
                        buttonOK.Left = (panelBottom.Width - buttonOK.Width) / 2;
                    }
                );
            frm.Controls.Add(panelBottom);
            if (control != null)
            {
                frm.Controls.Add(control);
                control.Left = 5;
                control.Top = 30;
            }
            frm.Resize +=
                new EventHandler(
                    delegate(object sender, EventArgs e)
                    {
                        panelBottom.Top = frm.Height - panelBottom.Height - 5;
                        panelBottom.Width = frm.Width - 10;
                        if (control != null)
                        {
                            control.Width = frm.Width - 10;
                            control.Height = panelBottom.Top - control.Top;
                        }
                    }
                );
            frm.ShowDialog();
        }

        public static void ShowCustomSelection(IEnumerable list, string displayName, Control callControl, Point point, Size size, EventHandler eventHandle)
        {
            ShowCustomSelection(list, displayName, callControl, point, size, eventHandle, ListType.DataGridView, null);
        }
        public static void ShowCustomSelection(IEnumerable list, string displayName, Control callControl, Point point, Size size, EventHandler eventHandle, DataGridViewCellPaintingEventHandler cellPaintingEventHandle)
        {
            ShowCustomSelection(list, displayName, callControl, point, size, eventHandle, ListType.DataGridView, cellPaintingEventHandle);
        }
        /// <summary>
        /// 弹出选择列表窗体
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <param name="displayName">需要显示的字段</param>
        /// <param name="callControl">调用的控件</param>
        /// <param name="point">显示坐标</param>
        /// <param name="size">显示大小</param>
        /// <param name="eventHandle"></param>
        public static void ShowCustomSelection(IEnumerable list, string displayName, Control callControl, Point point, Size size, EventHandler eventHandle, ListType listType)
        {
            //ShowCustomSelection(list, displayName, callControl, point, size, eventHandle, false, false);
            ShowCustomSelection(list, displayName, callControl, point, size, eventHandle, listType, false, false, null);
        }
        public static void ShowCustomSelection(IEnumerable list, string displayName, Control callControl, Point point, Size size, EventHandler eventHandle, ListType listType, DataGridViewCellPaintingEventHandler cellPaintingEventHandle)
        {
            //ShowCustomSelection(list, displayName, callControl, point, size, eventHandle, false, false);
            ShowCustomSelection(list, displayName, callControl, point, size, eventHandle, listType, false, false, cellPaintingEventHandle);
        }

        public static void ShowCustomSelection(IEnumerable list, string displayName, Control callControl, Size size, EventHandler eventHandle)
        {
            ShowCustomSelection(list, displayName, callControl, new Point(0, 0), size, eventHandle, false, true, null);
        }
        public static void ShowCustomSelection(IEnumerable list, string displayName, Control callControl, Size size, EventHandler eventHandle, DataGridViewCellPaintingEventHandler cellPaintingEventHandle)
        {
            ShowCustomSelection(list, displayName, callControl, new Point(0, 0), size, eventHandle, false, true, cellPaintingEventHandle);
        }

        /// <summary>
        /// 弹出选择列表窗体
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <param name="displayName">需要显示的字段</param>
        /// <param name="callControl">调用的控件</param>
        /// <param name="point">显示坐标</param>
        /// <param name="size">显示大小</param>
        /// <param name="eventHandle"></param>
        public static void ShowCustomSelection(IEnumerable list, string displayName, Control callControl, Point point, Size size, EventHandler eventHandle, bool multiSelect, bool autoCalPoint)
        {
            ShowCustomSelection(list, displayName, callControl, point, size, eventHandle, ListType.DataGridView, multiSelect, autoCalPoint, null);
        }
        public static void ShowCustomSelection(IEnumerable list, string displayName, Control callControl, Point point, Size size, EventHandler eventHandle, bool multiSelect, bool autoCalPoint, DataGridViewCellPaintingEventHandler cellPaintingEventHandle)
        {
            ShowCustomSelection(list, displayName, callControl, point, size, eventHandle, ListType.DataGridView, multiSelect, autoCalPoint, cellPaintingEventHandle);
        }

        public static void ShowCustomSelection(IEnumerable list, string displayName, Control callControl, Point point, Size size, EventHandler eventHandle, bool multiSelect)
        {
            ShowCustomSelection(list, displayName, callControl, point, size, eventHandle, ListType.DataGridView, multiSelect, false, null);
        }
        public static void ShowCustomSelection(IEnumerable list, string displayName, Control callControl, Point point, Size size, EventHandler eventHandle, bool multiSelect, DataGridViewCellPaintingEventHandler cellPaintingEventHandle)
        {
            ShowCustomSelection(list, displayName, callControl, point, size, eventHandle, ListType.DataGridView, multiSelect, false, cellPaintingEventHandle);
        }

        public static void ShowCustomSelection(IEnumerable list, string displayName, Control callControl, Size size, EventHandler eventHandle, bool multiSelect)
        {
            ShowCustomSelection(list, displayName, callControl, new Point(0, 0), size, eventHandle, ListType.DataGridView, multiSelect, true, null);
        }
        public static void ShowCustomSelection(IEnumerable list, string displayName, Control callControl, Size size, EventHandler eventHandle, bool multiSelect, DataGridViewCellPaintingEventHandler cellPaintingEventHandle)
        {
            ShowCustomSelection(list, displayName, callControl, new Point(0, 0), size, eventHandle, ListType.DataGridView, multiSelect, true, cellPaintingEventHandle);
        }

        /// <summary>
        /// 弹出选择列表窗体
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <param name="displayName">需要显示的字段</param>
        /// <param name="parent">调用的控件</param>
        /// <param name="point">显示坐标</param>
        /// <param name="size">显示大小</param>
        /// <param name="eventHandle"></param>
        private static void ShowCustomSelection(IEnumerable list, string displayName, Control parent, Point point, Size size, EventHandler eventHandle, ListType listType, bool multiSelect, bool autoCalPoint, DataGridViewCellPaintingEventHandler cellPaintingEventHandle)
        {
            CustomSelection.Show(list, displayName, parent, point, size, eventHandle, listType, multiSelect,autoCalPoint,cellPaintingEventHandle);
        }

        public static void ShowDataTableSelection(DataTable dataTable, string displayName, Control parent, Point point, Size size, EventHandler eventHandle, bool multiSelect, bool autoCalPoint, DataGridViewCellPaintingEventHandler cellPaintingEventHandle)
        {
            CustomSelection.Show(dataTable, displayName, parent, point, size, eventHandle, multiSelect, autoCalPoint, cellPaintingEventHandle);
        }

       public static void SetPopup(Control control, Control callControl, Point location, Size size, bool autoPoint)
        {
            control.Leave += new EventHandler(delegate(object sender, EventArgs e) {
                if (!control.ClientRectangle.Contains(control.PointToClient(Control.MousePosition)))
                {
                    try
                    {
                        control.Dispose();
                    }
                    catch
                    {
                    }
                }
            });
            control.KeyDown += new KeyEventHandler(delegate(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Escape) control.Dispose(); });
            control.ControlAdded += new ControlEventHandler(delegate(object sender, ControlEventArgs e) { e.Control.KeyDown += new KeyEventHandler(delegate(object sender1, KeyEventArgs e1) { if (e1.KeyCode == Keys.Escape) control.Dispose(); }); });
            foreach (Control ctl in control.Controls)
            {
                ctl.KeyDown += new KeyEventHandler(delegate(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Escape) control.Dispose(); });
            }
            Control parentControl = callControl;
            int x = 0, y = 0;
            while (!(parentControl is Form) && parentControl.Parent != null)
            {
                x += parentControl.Left;
                y += parentControl.Top;
                parentControl = parentControl.Parent;
                parentControl.Click += new EventHandler(delegate(object sender, EventArgs e)
                {
                    try
                    {
                        control.Dispose();
                    }
                    catch
                    {
                    }
                });
            }
            parentControl.Controls.Add(control);
            control.Left = location.X + x;
            control.Top = location.Y + y;
            if (autoPoint && callControl is TextBox)
            {
                control.Top += callControl.Height;
            }
            control.Size = size;
            if (control.Top + control.Height >= parentControl.ClientSize.Height) control.Top = location.Y + y - control.Height;
            if (control.Left + control.Width >= parentControl.ClientSize.Width) control.Left = location.X + x - control.Width;
            control.BringToFront();
            control.Focus();
        }

        public static void ShowDateTimeSelector(DateTime initValue, Control callControl, EventHandler eventHandle)
        {
            ShowDateTimeSelector(initValue, callControl, new Point(0, 0), eventHandle, true,"");
        }

        public static void ShowDateTimeSelector(DateTime initValue, Control callControl, EventHandler eventHandle,string formatString)
        {
            ShowDateTimeSelector(initValue, callControl, new Point(0, 0), eventHandle, true, formatString);
        }


        public static void ShowDateTimeSelector(DateTime initValue, Control callControl, Point point, EventHandler eventHandle)
        {
            ShowDateTimeSelector(initValue, callControl, point, eventHandle, false,"");
        }

        public static void ShowDateTimeSelector(DateTime initValue, Control callControl, Point point, EventHandler eventHandle,string formatString)
        {
            ShowDateTimeSelector(initValue, callControl, point, eventHandle, false, formatString);
        }


        public static void ShowDateTimeSelector(DateTime initValue, Control callControl, Point point, EventHandler eventHandle, bool autoPoint,string formatString)
        {
            ShowDevDateTimeEditor(initValue, callControl, callControl.ClientRectangle, eventHandle, formatString);
            return;
            //Panel panel = new Panel();
            //DateTimePicker dateTimePicker = new DateTimePicker();
            //if (initValue < DateTime.Parse("1900-1-1"))
            //{
            //    dateTimePicker.Value = DateTime.Parse("1900-1-1");
            //}
            //else
            //{
            //    dateTimePicker.Value = initValue;
            //}
            //dateTimePicker.Format = DateTimePickerFormat.Custom;
            //if (string.IsNullOrEmpty(formatString))
            //{
            //    dateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            //}
            //else
            //{
            //    dateTimePicker.CustomFormat = formatString;
            //}
            //dateTimePicker.ShowUpDown = true;
            //panel.Controls.Add(dateTimePicker);
            //panel.BorderStyle = BorderStyle.FixedSingle;
            //dateTimePicker.Dock = DockStyle.Top;
            //MonthCalendar monthCalendar = new MonthCalendar();
            //monthCalendar.KeyDown += new KeyEventHandler(delegate(object sender, KeyEventArgs e)
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        if (eventHandle != null)
            //        {
            //            eventHandle(dateTimePicker.Value, null);
            //        }
            //        panel.Dispose();
            //    }
            //});
            //monthCalendar.MouseMove += new MouseEventHandler(delegate(object sender, MouseEventArgs e)
            //{
            //    MonthCalendar.HitTestInfo hitTest = monthCalendar.HitTest(e.X, e.Y);
            //    if (hitTest != null && hitTest.Time > DateTime.Parse("1900-1-1"))
            //    {
            //        DateTime value = hitTest.Time;
            //        monthCalendar.SetSelectionRange(value, value);
            //    }
            //});
            //monthCalendar.MouseDown += new MouseEventHandler(delegate(object sender, MouseEventArgs e)
            //{
            //    MonthCalendar.HitTestInfo hitTest = monthCalendar.HitTest(e.X, e.Y);
            //    if (hitTest != null && hitTest.Time > DateTime.Parse("1900-1-1") && hitTest.HitArea == MonthCalendar.HitArea.Date)
            //    {
            //        if (eventHandle != null)
            //        {
            //            eventHandle(dateTimePicker.Value, null);
            //        }
            //        panel.Dispose();
            //    }
            //});
            //dateTimePicker.KeyDown += new KeyEventHandler(delegate(object sender, KeyEventArgs e)
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        if (eventHandle != null)
            //        {
            //            eventHandle(dateTimePicker.Value, null);
            //        }
            //        panel.Dispose();
            //    }
            //});
            //dateTimePicker.ValueChanged += new EventHandler(delegate(object sender, EventArgs e) { monthCalendar.SetSelectionRange(dateTimePicker.Value, dateTimePicker.Value); });
            //monthCalendar.DateChanged += new DateRangeEventHandler(delegate(object sender, DateRangeEventArgs e)
            //{
            //    DateTime oldValue = dateTimePicker.Value;
            //    dateTimePicker.Value = new DateTime(e.Start.Year, e.Start.Month, e.Start.Day, oldValue.Hour, oldValue.Minute, oldValue.Second);
            //});
            //monthCalendar.DateSelected += new DateRangeEventHandler(delegate(object sender, DateRangeEventArgs e)
            //{
            //    DateTime oldValue = dateTimePicker.Value;
            //    dateTimePicker.Value = new DateTime(e.Start.Year, e.Start.Month, e.Start.Day, oldValue.Hour, oldValue.Minute, oldValue.Second);
            //    if (eventHandle != null)
            //    {
            //        eventHandle(dateTimePicker.Value, null);
            //    }
            //});
            //panel.Controls.Add(monthCalendar);
            //monthCalendar.Dock = DockStyle.Fill;
            //monthCalendar.Font = new Font("宋体", 12f);
            //dateTimePicker.Font = new Font("宋体", 21.75f);
            //monthCalendar.SetSelectionRange(dateTimePicker.Value, dateTimePicker.Value);
            //monthCalendar.BringToFront();
            //SetPopup(panel, callControl, point, new Size(354, 232), autoPoint);
        }

        public static void ShowDevDateTimeEditor(DateTime initValue, Control callControl, Rectangle rect, EventHandler eventHandle, string formatString)
        {
            ShowDevDateTimeEditor(initValue, callControl, rect, eventHandle, formatString, formatString);
        }

        public static void ShowDevDateTimeEditor(DateTime initValue, Control callControl, Rectangle rect, EventHandler eventHandle, string displayFormatString, string editFormatString)
        {
            Control parentControl = callControl;
            int x = 0, y = 0;
            if (parentControl.Parent != null)
            {
                x += parentControl.Left;
                y += parentControl.Top;
                parentControl = parentControl.Parent;
                DevExpress.XtraEditors.DateEdit dateEditCtl = new DevExpress.XtraEditors.DateEdit();
                dateEditCtl.Properties.DisplayFormat.FormatString = displayFormatString;
                dateEditCtl.Properties.EditFormat.FormatString = editFormatString;
                dateEditCtl.Properties.Mask.EditMask = editFormatString;
                dateEditCtl.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
                dateEditCtl.EnterMoveNextControl = true;
                if (initValue == DateTime.MinValue)
                {
                    dateEditCtl.Text = "";
                }
                else
                {
                    dateEditCtl.EditValue = initValue;
                }
                dateEditCtl.Leave += new EventHandler(delegate(object sender, EventArgs e)
                {
                    if (eventHandle != null)
                    {
                        eventHandle(dateEditCtl.EditValue, null);
                    }
                    //if (!dateEditCtl.ClientRectangle.Contains(dateEditCtl.PointToClient(Control.MousePosition)))
                    //{
                        try
                        {
                            dateEditCtl.Dispose();
                        }
                        catch
                        {
                        }
                    //}
                });
                Control pControl = callControl;
                while (!(pControl is Form) && pControl.Parent != null)
                {
                    pControl = pControl.Parent;
                    pControl.Click += new EventHandler(delegate(object sender, EventArgs e)
                    {
                        try
                        {
                            dateEditCtl.Dispose();
                        }
                        catch
                        {
                        }
                    });
                }
                dateEditCtl.KeyDown += new KeyEventHandler(delegate(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Escape) dateEditCtl.Dispose(); });
                parentControl.Controls.Add(dateEditCtl);
                dateEditCtl.Left = rect.X + x;
                dateEditCtl.Top = rect.Y + y;
                dateEditCtl.Size = new Size(rect.Width, rect.Height);
                dateEditCtl.BringToFront();
                dateEditCtl.Focus();
            }
        }

        public static void SelectFromDataTable(DataTable dataTable, string displayName, Control textBox, bool multiSelect)
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (DataRow row in dataTable.Rows)
            {
                rows.Add(row);
            }
            SelectFromRows(rows.ToArray(), displayName, textBox, multiSelect);
        }

        public static void SelectFromRows(DataRow[] rows, string displayName, Control textBox, bool multiSelect)
        {
            Dialog.ShowCustomSelection(rows, displayName, textBox, new Point(0, textBox.Height), new Size(200, 400)
                , new EventHandler(delegate(object sender1, EventArgs e1)
                {
                    if (!multiSelect)
                    {
                        if (sender1 is int)
                        {
                            int index = (int)sender1;
                            textBox.Text = rows[index][displayName].ToString();
                        }
                    }
                    else
                    {
                        int[] selectedIndexes = sender1 as int[];
                        if (selectedIndexes != null)
                        {
                            string text = "";
                            foreach (int index in selectedIndexes)
                            {
                                text += "," + rows[index][displayName].ToString();
                            }
                            textBox.Text = text.Substring(1);
                        }
                    }
                }), multiSelect);
        }

        public static Control GetTopParent(Control parent)
        {
            Control parentControl = parent;
            while (!(parentControl is Form) && parentControl.Parent != null)
            {
                parentControl = parentControl.Parent;
            }
            return parentControl;
        }

    }
}
