/*----------------------------------------------------------------
      // Copyright (C) 2008 ���˹��(����)ҽ�ƿƼ���չ���޹�˾
      // �ļ�����AnesGraph.cs
      // �ļ������������������ͼ��ؼ������ࣩ
      //
      // 
      // ������ʶ��������-2008-10-29
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using MedicalSystem.Anes.Document.Controls;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// �̶�����
    /// </summary>
    [Serializable]
    public enum ScaleType
    {
        /// <summary>
        /// һ����
        /// </summary>
        OneMin,
        /// <summary>
        /// ������
        /// </summary>
        TwoMin,
        /// <summary>
        /// �����
        /// </summary>
        FiveMin,
        /// <summary>
        /// ʮ����
        /// </summary>
        TenMin,
        /// <summary>
        /// ����
        /// </summary>
        Quarter,
        /// <summary>
        /// ��Сʱ
        /// </summary>
        HalfHour,
        /// <summary>
        /// ������
        /// </summary>
        TriQuarter,
        /// <summary>
        /// Сʱ
        /// </summary>
        Hour,
        /// <summary>
        /// ��Сʱ
        /// </summary>
        TwiHour
    }

    /// <summary>
    /// ʱ��������λ������
    /// </summary>
    [Serializable]
    public enum TimeAxisPositionType
    {
        /// <summary>
        /// ����
        /// </summary>
        [Description("����")]
        Top,
        /// <summary>
        /// �ײ�
        /// </summary>
        [Description("�ײ�")]
        Bottom,
        /// <summary>
        /// ��
        /// </summary>
        [Description("��")]
        None
    }

    /// <summary>
    /// �������ͼ��ؼ������ࣩ
    /// </summary>
    [Serializable, ToolboxItem(false)]
    public partial class AnesGraph : AnesBand
    {
        #region ���췽��

        public AnesGraph()
        {
            InitializeComponent();
        }

        #endregion ���췽��

        #region ����

        /// <summary>
        /// ��߰ٷֱ�
        /// </summary>
        protected float _leftWidthPercent = .12f;

        /// <summary>
        /// �ұ߰ٷֱ�
        /// </summary>
        protected float _rightWidthPercent = .1f;

        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        protected DateTime _startTime = DateTime.Parse("08:00");

        /// <summary>
        /// ����ʱ��
        /// </summary>
        protected DateTime _endTime = DateTime.Parse("12:00");

        /// <summary>
        /// �̶�����
        /// </summary>
        protected ScaleType _scaleType = ScaleType.HalfHour;

        /// <summary>
        /// ʱ��������λ������
        /// </summary>
        protected TimeAxisPositionType _timeAxisPositionType = TimeAxisPositionType.Top;

        /// <summary>
        /// ����ƫ����
        /// </summary>
        protected float _topOffSet = 0;
        public float TopOffSet
        {
            get
            {
                return _topOffSet;
            }
            set
            {
                _topOffSet = value;
            }
        }

        /// <summary>
        /// �̶�ֵ����
        /// </summary>
        private Font _scaleValueFont;

        #endregion ����
        /// <summary>
        /// ʱ�����
        /// </summary>
        private string _timeText = "ʱ��";

        /// <summary>
        /// �ܼƱ���
        /// </summary>
        private string _totalText = "������";

        #region ����

        /// <summary>
        /// ʱ�����
        /// </summary>
        [Category("����-�Զ���"), DisplayName("ʱ�����")]
        public string TimeText
        {
            get
            {
                return _timeText;
            }
            set
            {
                _timeText = value;
            }
        }

        /// <summary>
        /// �ܼƱ���
        /// </summary>
        [Category("����-�Զ���"), DisplayName("�ܼƱ���")]
        public string TotalText
        {
            get
            {
                return _totalText;
            }
            set
            {
                _totalText = value;
            }
        }

        /// <summary>
        /// �̶�ֵ����
        /// </summary>
        [Category("����-�Զ���"), DisplayName("�̶�ֵ����")]
        public Font ScaleValueFont
        {
            get
            {
                if (_scaleValueFont == null)
                {
                    return DefaultFont;
                }
                else
                {
                    return _scaleValueFont;
                }
            }
            set
            {
                _scaleValueFont = value;
            }
        }
        private DateTime _maxDateTime;
        private DateTime _miniDateTime;

        /// <summary>
        /// ������ʱ��
        /// </summary>
        [Browsable(false)]
        public DateTime MaxEndDateTime
        {
            get
            {
                return _maxDateTime;
            }
            set
            {
                _maxDateTime = value;
            }
        }
        /// <summary>
        /// ��С��ʼʱ��
        /// </summary>
        [Browsable(false)]
        public DateTime MinStartDateTime
        {
            get
            {
                return _miniDateTime;
            }
            set
            {
                _miniDateTime = value;
            }
        }
        /// <summary>
        /// ʱ��������λ������
        /// </summary>
        [Category("����-�Զ���"), DisplayName("ʱ��������λ������")]
        public TimeAxisPositionType TimeAxisPositionType
        {
            get
            {
                return _timeAxisPositionType;
            }
            set
            {
                _timeAxisPositionType = value;
            }
        }

        /// <summary>
        /// �̶�����
        /// </summary>
        [Category("����-�Զ���"), DisplayName("�̶�����")]
        public ScaleType ScaleType
        {
            get
            {
                return _scaleType;
            }
            set
            {
                _scaleType = value;
            }
        }

        /// <summary>
        /// ��߰ٷֱ�
        /// </summary>
        [Category("����-�Զ���"), DisplayName("��߰ٷֱ�")]
        public float LeftWidthPercent
        {
            get
            {
                return _leftWidthPercent;
            }
            set
            {
                //if (value > .05f && value <= 1)
                {
                    _leftWidthPercent = value;
                }
                //else
                //{
                //    Exception ex = new Exception("��Ч�İٷֱȣ��������5%��100%֮��!");
                //    throw ex;
                //}
            }
        }

        /// <summary>
        /// �ұ߰ٷֱ�
        /// </summary>
        [Category("����-�Զ���"), DisplayName("�ұ߰ٷֱ�")]
        public float RightWidthPercent
        {
            get
            {
                return _rightWidthPercent;
            }
            set
            {
                if (value >= 0 && value <= 1)
                {
                    _rightWidthPercent = value;
                }
                else
                {
                    Exception ex = new Exception("��Ч�İٷֱȣ��������0%��100%֮��!");
                    throw ex;
                }
            }
        }

        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
            }
        }

        #endregion ����

        #region ����

        protected virtual void AddJustEndTime()
        {
            TimeSpan ts = _endTime - _startTime;
            float gridScale = .25f;// GetGridScale();
            int scaleCount = (int)(ts.TotalHours / gridScale);
            if (scaleCount * gridScale < ts.TotalHours) scaleCount++;
            _endTime = _startTime.AddHours(scaleCount * gridScale);
        }

        /// <summary>
        /// ��ȡ����̶ȿ��
        /// </summary>
        /// <returns></returns>
        protected virtual float GetGridWidth()
        {
            TimeSpan ts = _endTime - _startTime;
            if (_endTime == DateTime.MinValue && _startTime == DateTime.MinValue)
            {
                ts = _endTime.AddHours(4) - _startTime;
            }


            RectangleF rectF = GetMainRect();
            return (float)(rectF.Width / ts.TotalHours) * GetGridScale();
        }

        /// <summary>
        /// ��ȡ����̶�ʱ��--������
        /// </summary>
        /// <returns></returns>
        protected virtual int GetGridMinutes()
        {
            return (int)(60 * GetGridScale());
        }

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        /// <returns></returns>
        protected virtual float GetGridScale()
        {
            float scale = 1;
            switch (_scaleType)
            {
                case ScaleType.Hour:
                    scale = 1;
                    break;
                case ScaleType.Quarter:
                    scale = .25f;
                    break;
                case ScaleType.HalfHour:
                    scale = .5f;
                    break;
                case ScaleType.TriQuarter:
                    scale = .75f;
                    break;
                case ScaleType.TwiHour:
                    scale = 2;
                    break;
                case ScaleType.OneMin:
                    scale = (float)(1 / 60.0);
                    break;
                case ScaleType.FiveMin:
                    scale = (float)(5 / 60.0);
                    break;
                case ScaleType.TwoMin:
                    scale = (float)(2 / 60.0);
                    break;
                case ScaleType.TenMin:
                    scale = (float)(10 / 60.0);
                    break;

            }
            return scale;
        }

        /// <summary>
        /// ��ȡ������
        /// </summary>
        /// <returns></returns>
        public virtual RectangleF GetMainRect()
        {
            Rectangle rect = OriginRect;
            RectangleF rectF = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
            rectF.X += rectF.Width * _leftWidthPercent;
            rectF.Width = rectF.Width * (1 - _leftWidthPercent - _rightWidthPercent);
            //return new RectangleF(rectF.X * _zoomRate, rectF.Y * _zoomRate, rectF.Width * _zoomRate, rectF.Height * _zoomRate);
            return rectF;
        }

        //protected override RectangleF GetMainRect()
        //{
        //    RectangleF rectF = base.GetMainRect();
        //}

        private bool _first = false;
        /// <summary>
        /// ���̶�ֵ
        /// </summary>
        /// <param name="g"></param>
        protected virtual void DrawScaleValue(Graphics g)
        {
            int vSpan = 1;
            Font font = ScaleValueFont;
            RectangleF rectF = GetMainRect();
            Rectangle rect = OriginRect;
            float gridWidth = GetGridWidth();
            int minutes = GetGridMinutes();
            DateTime dt = _startTime.AddMinutes(minutes);
            if (minutes == 15)
            {
                //minutes = 30;
                //gridWidth = gridWidth * 2;
            }
            float x = rectF.X + gridWidth;
            float topOffSet = rectF.Y + vSpan;
            if (_topOffSet > 0)
            {
                topOffSet = rectF.Y + vSpan + (_topOffSet * _zoomRate - g.MeasureString("H", font).Height) / 2;
                if (topOffSet < 0)
                {
                    topOffSet = 0;
                }
            }
            using (Brush brush = new SolidBrush(_scaleValueColor))
            {
                if (_timeText != null)
                {
                    g.DrawString(_timeText, font, brush, rect.X + (rectF.X - rect.X - g.MeasureString(_timeText, font).Width) / 2, topOffSet);
                }
                if (_rightWidthPercent > 0 && _totalText != null)
                {
                    g.DrawString(_totalText, font, brush, rectF.Right + (rect.Right - rectF.Right - g.MeasureString(_totalText, font).Width) / 2, topOffSet);
                }
                string firstScaleValue = dt.AddMinutes(-minutes).ToString("HH:mm");
                g.FillRectangle(Brushes.White, new RectangleF(rectF.X, topOffSet, 1, _topOffSet));
                g.DrawString(firstScaleValue, font, brush, rectF.X - g.MeasureString(firstScaleValue, font).Width / 2, topOffSet);
                while (x + gridWidth - 5 < rectF.Right)
                {
                    string scaleValue = dt.ToString("HH:mm");
                    g.DrawString(scaleValue, font, brush, x - g.MeasureString(scaleValue, font).Width / 2, topOffSet);
                    dt = dt.AddMinutes(minutes);
                    x += gridWidth;
                }
            }
            if (_topOffSet == 0)
            {
                _topOffSet = g.MeasureString("A", font).Height + vSpan * 2;
            }
            else if (_first)
            {
                _first = false;
                _topOffSet = _topOffSet * _zoomRate;
            }
            using (Pen pen = new Pen(_borderColor, _borderWidth))
            {
                g.DrawLine(pen, rect.X + 1, rectF.Y + _topOffSet, rect.Right, rectF.Y + _topOffSet);
            }

        }

        protected override void DoDrawBorder(Graphics g)
        {
            base.DoDrawBorder(g);
            using (Pen pen = new Pen(_borderColor))
            {
                Rectangle rect = OriginRect;
                rect.Width -= 1;
                rect.Height -= 1;
                //g.DrawRectangle(pen, rect);
                g.DrawLine(pen, rect.X + rect.Width * _leftWidthPercent, rect.Y + _topOffSet, rect.X + rect.Width * _leftWidthPercent, rect.Y + rect.Height - _topOffSet);
                g.DrawLine(pen, rect.X + rect.Width * (1 - _rightWidthPercent), rect.Y, rect.X + rect.Width * (1 - _rightWidthPercent), rect.Y + rect.Height);
            }
        }

        public override void DrawGraphics(Graphics g)
        {
            base.DrawGraphics(g);
            AddJustEndTime();
            if (_timeAxisPositionType == TimeAxisPositionType.Top)
            {
                DrawScaleValue(g);
            }
            //else if (_timeAxisPositionType == TimeAxisPositionType.Bottom)
            //{
            //    DrawScaleValue(g);
            //}
            else
            {
                _topOffSet = 0;
            }
        }

        #endregion ����

    }
}
