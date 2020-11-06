using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Diagnostics;
using System.Reflection;
using MedicalSystem.Anes.Document.Properties;


namespace MedicalSystem.Anes.Document.Controls
{

    [Designer(typeof(ScrollbarControlDesigner))]
    public class MedScrollbar : UserControl
    {

        protected Color moChannelColor = Color.Empty;
        protected Image moUpArrowImage = null;
        //protected Image moUpArrowImage_Over = null;
        //protected Image moUpArrowImage_Down = null;
        protected Image moDownArrowImage = null;
        //protected Image moDownArrowImage_Over = null;
        //protected Image moDownArrowImage_Down = null;
        protected Image moThumbArrowImage = null;

        protected Image moThumbTopImage = null;
        protected Image moThumbTopSpanImage = null;
        protected Image moThumbBottomImage = null;
        protected Image moThumbBottomSpanImage = null;
        protected Image moThumbMiddleImage = null;

        protected int moLargeChange = 10;
        protected int moSmallChange = 1;
        protected int moMinimum = 0;
        protected int moMaximum = 100;
        protected int moValue = 0;
        private int nClickPoint;

        protected int moThumbTop = 0;

        protected bool moAutoSize = false;

        private bool moThumbDown = false;
        private bool moThumbDragging = false;

        public new event EventHandler Scroll = null;
        public event EventHandler ValueChanged = null;

        private int GetThumbHeight()
        {
            int nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
            float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
            int nThumbHeight = (int)fThumbHeight;

            if (nThumbHeight > nTrackHeight)
            {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56)
            {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            return nThumbHeight;
        }

        public MedScrollbar()
        {

            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            moChannelColor = Color.FromArgb(193, 217, 239);

            UpArrowImage = Resources.uparrow;
            DownArrowImage = Resources.downarrow;


            ThumbBottomImage = Resources.ThumbBottom;
            ThumbBottomSpanImage = Resources.ThumbSpanBottom;
            ThumbTopImage = Resources.ThumbTop;
            ThumbTopSpanImage = Resources.ThumbSpanTop;
            ThumbMiddleImage = Resources.ThumbMiddle;

            this.Width = UpArrowImage.Width;
            base.MinimumSize = new Size(UpArrowImage.Width, UpArrowImage.Height + DownArrowImage.Height + GetThumbHeight());

            Scroll += new EventHandler(CustomScrollbar_Scroll);
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("LargeChange")]
        public int LargeChange
        {
            get { return moLargeChange; }
            set
            {
                moLargeChange = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("SmallChange")]
        public int SmallChange
        {
            get { return moSmallChange; }
            set
            {
                moSmallChange = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Minimum")]
        public int Minimum
        {
            get { return moMinimum; }
            set
            {
                moMinimum = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Maximum")]
        public int Maximum
        {
            get { return moMaximum; }
            set
            {
                moMaximum = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Value")]
        public int Value
        {
            get { return moValue; }
            set
            {
                moValue = value;

                int nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
                float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
                int nThumbHeight = (int)fThumbHeight;

                if (nThumbHeight > nTrackHeight)
                {
                    nThumbHeight = nTrackHeight;
                    fThumbHeight = nTrackHeight;
                }
                if (nThumbHeight < 56)
                {
                    nThumbHeight = 56;
                    fThumbHeight = 56;
                }

                //figure out value
                int nPixelRange = nTrackHeight - nThumbHeight;
                int nRealRange = (Maximum - Minimum) - LargeChange;
                float fPerc = 0.0f;
                if (nRealRange != 0)
                {
                    fPerc = (float)moValue / (float)nRealRange;

                }

                float fTop = fPerc * nPixelRange;
                moThumbTop = (int)fTop;


                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Channel Color")]
        public Color ChannelColor
        {
            get { return moChannelColor; }
            set { moChannelColor = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image UpArrowImage
        {
            get { return moUpArrowImage; }
            set { moUpArrowImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image DownArrowImage
        {
            get { return moDownArrowImage; }
            set { moDownArrowImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image ThumbTopImage
        {
            get { return moThumbTopImage; }
            set { moThumbTopImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image ThumbTopSpanImage
        {
            get { return moThumbTopSpanImage; }
            set { moThumbTopSpanImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image ThumbBottomImage
        {
            get { return moThumbBottomImage; }
            set { moThumbBottomImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image ThumbBottomSpanImage
        {
            get { return moThumbBottomSpanImage; }
            set { moThumbBottomSpanImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image ThumbMiddleImage
        {
            get { return moThumbMiddleImage; }
            set { moThumbMiddleImage = value; }
        }


        private Control thisControl = null;
        public Control ThisControl
        {
            get { return thisControl; }
            set
            {
                thisControl = value;
                if (thisControl != null)
                {
                    thisControl.Resize += ThisControl_Resize;
                    thisControl.MouseWheel += new MouseEventHandler(thisControl_MouseWheel);
                    thisControl.LocationChanged += ThisControl_LocationChanged;

                    if (thisControl is DataGridView)
                    {
                        ((DataGridView)thisControl).Scroll += DataGridViewScrollbar_Scroll;
                        ((DataGridView)thisControl).DataBindingComplete += CustomScrollbar_DataBindingComplete;
                    }
                    thisControl.SizeChanged += thisControl_SizeChanged;
                    this.BringToFront();
                    SetThisConntrolLocation();
                }
            }
        }

        private void ThisControl_LocationChanged(object sender, EventArgs e)
        {
            SetThisConntrolLocation();
        }

        /// <summary>
        /// 滚动条位置适应
        /// </summary>
        private void SetThisConntrolLocation()
        {
            if (thisControl != null)
            {
                this.Left = thisControl.Left + thisControl.Width - this.Width - 1;
                this.Top = thisControl.Top + 1;
                this.Height = thisControl.Height - 2;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            if (UpArrowImage != null)
            {
                e.Graphics.DrawImage(UpArrowImage, new Rectangle(new Point(0, 0), new Size(this.Width, UpArrowImage.Height)));
            }

            Brush oBrush = new SolidBrush(moChannelColor);
            Brush oWhiteBrush = new SolidBrush(Color.FromArgb(255, 255, 255));

            //draw channel left and right border colors
            e.Graphics.FillRectangle(oWhiteBrush, new Rectangle(0, UpArrowImage.Height, 1, (this.Height - DownArrowImage.Height)));
            e.Graphics.FillRectangle(oWhiteBrush, new Rectangle(this.Width - 1, UpArrowImage.Height, 1, (this.Height - DownArrowImage.Height)));

            //draw channel
            e.Graphics.FillRectangle(oBrush, new Rectangle(0, UpArrowImage.Height, this.Width, (this.Height - DownArrowImage.Height)));

            //draw thumb
            int nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
            float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
            int nThumbHeight = (int)fThumbHeight;

            if (nThumbHeight > nTrackHeight)
            {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56)
            {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            //Debug.WriteLine(nThumbHeight.ToString());

            float fSpanHeight = (fThumbHeight - (ThumbMiddleImage.Height + ThumbTopImage.Height + ThumbBottomImage.Height)) / 2.0f;
            int nSpanHeight = (int)fSpanHeight;

            int nTop = moThumbTop;
            nTop += UpArrowImage.Height;

            //draw top
            e.Graphics.DrawImage(ThumbTopImage, new Rectangle(1, nTop, this.Width - 2, ThumbTopImage.Height));

            nTop += ThumbTopImage.Height;
            //draw top span
            Rectangle rect = new Rectangle(1, nTop, this.Width - 2, nSpanHeight);


            e.Graphics.DrawImage(ThumbTopSpanImage, 1.0f, (float)nTop, (float)this.Width - 2.0f, (float)fSpanHeight * 2);

            nTop += nSpanHeight;
            //draw middle
            e.Graphics.DrawImage(ThumbMiddleImage, new Rectangle(1, nTop, this.Width - 2, ThumbMiddleImage.Height));


            nTop += ThumbMiddleImage.Height;
            //draw top span
            rect = new Rectangle(1, nTop, this.Width - 2, nSpanHeight * 2);
            e.Graphics.DrawImage(ThumbBottomSpanImage, rect);

            nTop += nSpanHeight;
            //draw bottom
            e.Graphics.DrawImage(ThumbBottomImage, new Rectangle(1, nTop, this.Width - 2, ThumbBottomImage.Height));//nSpanHeight

            if (DownArrowImage != null)
            {
                e.Graphics.DrawImage(DownArrowImage, new Rectangle(new Point(0, (this.Height - DownArrowImage.Height)), new Size(this.Width, DownArrowImage.Height)));
            }

        }

        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
                if (base.AutoSize)
                {
                    this.Width = moUpArrowImage.Width;
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MedScrollbar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Name = "MedScrollbar";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CustomScrollbar_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CustomScrollbar_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CustomScrollbar_MouseUp);
            this.ResumeLayout(false);

        }

        private void CustomScrollbar_MouseDown(object sender, MouseEventArgs e)
        {
            Point ptPoint = this.PointToClient(Cursor.Position);
            int nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
            float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
            int nThumbHeight = (int)fThumbHeight;

            if (nThumbHeight > nTrackHeight)
            {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56)
            {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            int nTop = moThumbTop;
            nTop += UpArrowImage.Height;


            Rectangle thumbrect = new Rectangle(new Point(1, nTop), new Size(ThumbMiddleImage.Width, nThumbHeight));
            if (thumbrect.Contains(ptPoint))
            {

                //hit the thumb
                nClickPoint = (ptPoint.Y - nTop);
                //MessageBox.Show(Convert.ToString((ptPoint.Y - nTop)));
                this.moThumbDown = true;
            }

            Rectangle uparrowrect = new Rectangle(new Point(1, 0), new Size(UpArrowImage.Width, UpArrowImage.Height));
            if (uparrowrect.Contains(ptPoint))//上按钮
            {

                int nRealRange = (Maximum - Minimum) - LargeChange;
                int nPixelRange = (nTrackHeight - nThumbHeight);
                if (nRealRange > 0)
                {
                    if (nPixelRange > 0)
                    {
                        if ((moThumbTop - SmallChange) < 0)
                            moThumbTop = 0;
                        else
                            moThumbTop -= SmallChange;

                        //figure out value
                        float fPerc = (float)moThumbTop / (float)nPixelRange;
                        float fValue = fPerc * (Maximum - LargeChange);

                        moValue = (int)fValue;
                        Debug.WriteLine(moValue.ToString());

                        if (ValueChanged != null)
                            ValueChanged(this, new EventArgs());

                        if (Scroll != null)
                            Scroll(this, new EventArgs());

                        Invalidate();
                    }
                }
            }

            Rectangle downarrowrect = new Rectangle(new Point(1, UpArrowImage.Height + nTrackHeight), new Size(UpArrowImage.Width, UpArrowImage.Height));
            if (downarrowrect.Contains(ptPoint))//下按钮
            {
                int nRealRange = (Maximum - Minimum) - LargeChange;
                int nPixelRange = (nTrackHeight - nThumbHeight);
                if (nRealRange > 0)
                {
                    if (nPixelRange > 0)
                    {
                        if ((moThumbTop + SmallChange) > nPixelRange)
                            moThumbTop = nPixelRange;
                        else
                            moThumbTop += SmallChange;

                        //figure out value
                        float fPerc = (float)moThumbTop / (float)nPixelRange;
                        float fValue = fPerc * (Maximum - LargeChange);

                        moValue = (int)fValue;
                        Debug.WriteLine(moValue.ToString());

                        if (ValueChanged != null)
                            ValueChanged(this, new EventArgs());

                        if (Scroll != null)
                            Scroll(this, new EventArgs());

                        Invalidate();
                    }
                }
            }
        }

        private void CustomScrollbar_MouseUp(object sender, MouseEventArgs e)
        {
            this.moThumbDown = false;
            this.moThumbDragging = false;
        }

        private void MoveThumb(int y)
        {
            int nRealRange = Maximum - Minimum;
            int nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
            float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
            int nThumbHeight = (int)fThumbHeight;

            if (nThumbHeight > nTrackHeight)
            {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56)
            {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            int nSpot = nClickPoint;

            int nPixelRange = (nTrackHeight - nThumbHeight);
            if (moThumbDown && nRealRange > 0)
            {
                if (nPixelRange > 0)
                {
                    int nNewThumbTop = y - (UpArrowImage.Height + nSpot);

                    if (nNewThumbTop < 0)
                    {
                        moThumbTop = nNewThumbTop = 0;
                    }
                    else if (nNewThumbTop > nPixelRange)
                    {
                        moThumbTop = nNewThumbTop = nPixelRange;
                    }
                    else
                    {
                        moThumbTop = y - (UpArrowImage.Height + nSpot);
                    }

                    //figure out value
                    float fPerc = (float)moThumbTop / (float)nPixelRange;
                    float fValue = fPerc * (Maximum - LargeChange);
                    moValue = (int)fValue;
                    Debug.WriteLine(moValue.ToString());

                    Application.DoEvents();

                    Invalidate();
                }
            }
        }

        private void CustomScrollbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (moThumbDown == true)
            {
                this.moThumbDragging = true;
            }

            if (this.moThumbDragging)
            {
                MoveThumb(e.Y);
            }

            if (ValueChanged != null)
                ValueChanged(this, new EventArgs());

            if (Scroll != null)
                Scroll(this, new EventArgs());
        }


        /// <summary>
        /// 滚动条滚动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomScrollbar_Scroll(object sender, EventArgs e)
        {
            this.Minimum = 0;
            SetScroolPoint();
        }


        void CustomScrollbar_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetScroolPoint();
        }

        void thisControl_SizeChanged(object sender, EventArgs e)
        {
            SetScroolPoint();
        }

        /// <summary>
        /// 设置滚动条位置
        /// </summary>
        private void SetScroolPoint()
        {
            if (thisControl is Panel)
            {
                this.Maximum = ((Panel)this.thisControl).VerticalScroll.Maximum;// this.innerPanel.DisplayRectangle.Height;
                this.LargeChange = ((Panel)this.thisControl).VerticalScroll.LargeChange;// customScrollbar1.Maximum / customScrollbar1.Height + this.innerPanel.Height;
                ((Panel)this.thisControl).AutoScrollPosition = new Point(0, this.Value);
                if (Maximum == 100)
                    this.Visible = false;
                else
                    this.Visible = true;
                if (thisControl.Name.Equals("pnlBody"))
                {
                    if (thisControl.Controls.Count > 8)
                        this.Visible = true;
                    else
                        this.Visible = false;
                }
            }
            else if (thisControl is DataGridView)
            {
                DataGridView gdv = ((DataGridView)this.thisControl);
                this.Maximum = (gdv.RowCount - gdv.DisplayedRowCount(false) + 3) * gdv.RowTemplate.Height;

                this.SmallChange = gdv.RowTemplate.Height;
                this.LargeChange = gdv.RowTemplate.Height * 3;

                if (Maximum == LargeChange)
                    this.Visible = false;
                else
                {
                    this.Visible = true;
                    if (moValue > 0)
                    {
                        int rowindex = this.moValue / gdv.RowTemplate.Height;
                        if (rowindex >= gdv.RowCount)
                        {
                            gdv.FirstDisplayedScrollingRowIndex = 0;
                            moValue = 0;
                        }
                        else
                        {
                            gdv.FirstDisplayedScrollingRowIndex = rowindex;
                        }
                    }
                }
            }
        }
        void thisControl_MouseWheel(object sender, MouseEventArgs e)
        {
            if (thisControl is Panel)
            {
                this.Value = ((Panel)this.thisControl).VerticalScroll.Value;
                this.Maximum = ((Panel)this.thisControl).VerticalScroll.Maximum;// this.innerPanel.DisplayRectangle.Height;
                this.LargeChange = ((Panel)this.thisControl).VerticalScroll.LargeChange;
            }
        }

        private void DataGridViewScrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                this.Value = e.NewValue * this.SmallChange;//计算相差倍数
            }
        }

        /// <summary>
        /// 控件位置移动，滚动条跟随
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThisControl_Resize(object sender, EventArgs e)
        {
            SetThisConntrolLocation();
        }
    }


    internal class ScrollbarControlDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        public override SelectionRules SelectionRules
        {
            get
            {
                SelectionRules selectionRules = base.SelectionRules;
                PropertyDescriptor propDescriptor = TypeDescriptor.GetProperties(this.Component)["AutoSize"];
                if (propDescriptor != null)
                {
                    bool autoSize = (bool)propDescriptor.GetValue(this.Component);
                    if (autoSize)
                    {
                        selectionRules = SelectionRules.Visible | SelectionRules.Moveable | SelectionRules.BottomSizeable | SelectionRules.TopSizeable;
                    }
                    else
                    {
                        selectionRules = SelectionRules.Visible | SelectionRules.AllSizeable | SelectionRules.Moveable;
                    }
                }
                return selectionRules;
            }
        }
    }
}