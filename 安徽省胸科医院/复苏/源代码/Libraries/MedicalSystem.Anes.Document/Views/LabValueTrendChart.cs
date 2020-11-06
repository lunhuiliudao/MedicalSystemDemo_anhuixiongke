using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Domain;

namespace MedicalSystem.Anes.Document
{
    public partial class LabValueTrendChart : BaseView
    {
        private string _reportItemName = "";

        private int intXLong = 400;   //图片大小 长

        public int IntXLong
        {
            get { return intXLong; }
            set { intXLong = value; }
        }

        private int intYLong = 300;   //图片大小 高

        public int IntYLong
        {
            get { return intYLong; }
            set { intYLong = value; }
        }

        private int intXMultiple = 0;    //零刻度的值 X

        public int IntXMultiple
        {
            get { return intXMultiple; }
            set { intXMultiple = value; }
        }

        private int intYMultiple = 0;    //零刻度的值 Y

        public int IntYMultiple
        {
            get { return intYMultiple; }
            set { intYMultiple = value; }
        }

        private int intXMax = 10;    //最大刻度(点数) X

        public int IntXMax
        {
            get { return intXMax; }
            set { intXMax = value; }
        }

        private int intYMax = 10;    //最大刻度(点数) Y

        public int IntYMax
        {
            get { return intYMax; }
            set { intYMax = value; }
        }



        private int intLeft = 30;   //左边距

        public int IntLeft
        {
            get { return intLeft; }
            set { intLeft = value; }
        }

        private int intRight = 20; //右边距

        public int IntRight
        {
            get { return intRight; }
            set { intRight = value; }
        }

        private int intTop = 30;    //上边距

        public int IntTop
        {
            get { return intTop; }
            set { intTop = value; }
        }

        private int intEnd = 20;    //下边距

        public int IntEnd
        {
            get { return intEnd; }
            set { intEnd = value; }
        }



        private string strXText = "时间";    //单位 X

        public string StrXText
        {
            get { return strXText; }
            set { strXText = value; }
        }

        private string strYText = "";    //单位 Y

        public string StrYText
        {
            get { return strYText; }
            set { strYText = value; }
        }

        private string strTitle = "趋势线图";    //标题

        public string StrTitle
        {
            get { return strTitle; }
            set { strTitle = value; }
        }

        //private DataTable tbData;    //要统计的数据

        private int intXScale = 15;    //一刻度长度 X

        private int intYScale = 15;    //一刻度高度 Y

        //private double maxYvalue = 10;
        //private double minYvalue = 0;
        private double sclaleYvalue = 1; 

        public int intData = 0;    //记录数

        private List<KeyValuePair<string, double>> points = new List<KeyValuePair<string, double>>();

        private Bitmap DrawingImg()
        {

            intXScale = (intXLong - intLeft - intRight) / (intXMax + 1);//一刻度长度 X
            intYScale = (intYLong - intTop - intEnd) / (intYMax + 1);//一刻度高度 Y

            Bitmap img = new Bitmap(intXLong, intYLong); //图片大小

            Graphics g = Graphics.FromImage(img);

            g.Clear(Color.Snow);

            g.DrawString(_reportItemName + strTitle, new Font("宋体", 14), Brushes.Black, new Point(5, 5));

            g.DrawLine(new Pen(Color.Black, 2), intLeft, intYLong - intEnd, intXLong - intRight, intYLong - intEnd); //绘制横向

            g.DrawLine(new Pen(Color.Black, 2), intLeft, intTop, intLeft, intYLong - intEnd);   //绘制纵向

            //绘制纵坐标

            g.DrawString(strYText, new Font("宋体", 12), Brushes.Black, new Point(intLeft, intTop));//Y 单位

            Point p1 = new Point(intLeft - 10, intYLong - intEnd);

            for (int j = 0; j <= intYMax; j++)
            {

                p1.Y = intYLong - intEnd - j * intYScale;

                Point pt = new Point(p1.X + 10, p1.Y);

                //绘制纵坐标的刻度和直线

                g.DrawLine(Pens.Black, pt, new Point(p1.X + 15, p1.Y));

                //绘制纵坐标的文字说明

                g.DrawString(Convert.ToString((j + intYMultiple) * sclaleYvalue), new Font("宋体", 12), Brushes.Black, new Point(10, p1.Y - 8));

            } 
            //绘制横坐标

            g.DrawString(strXText, new Font("宋体", 12), Brushes.Black, new Point(intXLong - intRight, intYLong - intEnd));//X 单位

            Point p = new Point(intLeft, intYLong - intEnd);

            for (int i = 0; i < intXMax; i++)
            {

                p.X = intLeft + (i + 1) * intXScale;

                //绘制横坐标刻度和直线

                g.DrawLine(Pens.Black, p, new Point(p.X, p.Y - 5)); 
            }

            PointF pf = new PointF((float)intLeft, (float)(intYLong - intEnd));
            if (points.Count > 0)
            { 
                List<PointF> pointlist = new List<PointF>();
                for (int i = 0; i < points.Count; i++)
                {
                    pf.X = (float)(intLeft + (i + 1) * intXScale);
                    KeyValuePair<string, double> keyValue1 = points[i]; 
                    PointF sp = new PointF(pf.X, (float)(intYLong - intEnd));
                    for (int j = 0; j < intYMax; j++)
                    {
                        if (keyValue1.Value >= (j + intYMultiple) * sclaleYvalue && keyValue1.Value <= (j + 1 + intYMultiple) * sclaleYvalue)
                        {
                            sp.Y = (float)(intYLong - intEnd - intYScale * j) - (float)(intYScale * (keyValue1.Value - (j + intYMultiple) * sclaleYvalue) / sclaleYvalue);
                            g.RotateTransform(90);
                            g.DrawString(keyValue1.Key, new Font("宋体", 12), Brushes.Black, pf.Y, -pf.X - 10);
                            g.RotateTransform(270);
                            g.FillEllipse(Brushes.Red, sp.X - 3, sp.Y - 3, 6, 6);
                            pointlist.Add(sp);
                            break;
                        }
                    }
                }
                if (pointlist.Count > 1)
                { 
                    g.DrawLines(new Pen(Color.Red), pointlist.ToArray());
                }
            }

            g.Save();

            g.Dispose();
            return img;

        }



        //转换数字

        private double TurnNumber(string str)
        {

            double dubReturn;

            try
            {

                dubReturn = Convert.ToDouble(str);

            }

            catch
            {

                dubReturn = 0;

            }

            return dubReturn;

        }

        public LabValueTrendChart()
        {
            InitializeComponent();
        }
        private string _patientID;
        private int _visitID;
        public LabValueTrendChart(string reportItemName,string patientID,int visitID)
        {
            InitializeComponent();
            _reportItemName = reportItemName;
            _patientID = patientID;
            _visitID = visitID;
        }

        private void LabValueTrendChart_Load(object sender, EventArgs e)
        {
            intXLong = 600;
            intYLong = 500;
            intLeft = 50;
            intRight = 80;
            intEnd = 80;
//            MED_LAB_TEST_MASTER master = EMRDictService.GetPatLabTestMaster(_patientID, _visitID);
//            string sql = string.Format(@"SELECT A.REPORT_ITEM_NAME, A.RESULT,A.RESULT_DATE_TIME, A.UNITS,REFERENCE_RESULT,B.TEST_CAUSE
//                          FROM MED_LAB_RESULT A,MED_LAB_TEST_MASTER B WHERE A.TEST_NO = B.TEST_NO AND B.PATIENT_ID = '{0}' 
//                          AND VISIT_ID = {1} AND A.REPORT_ITEM_NAME= '{2}'  ORDER BY A.Result_date_time ",
//                        _patientID, _visitID, _reportItemName);

//            DataTable data = (new CommonDA()).GetDataFromSQLString(sql);
//            if (data != null && data.Rows.Count > 0)
//            {
//                double d = 0, max = -99999, min = 999999;
//                foreach (DataRow row in data.Rows)
//                {
//                    if (!row.IsNull("RESULT") && double.TryParse(row["RESULT"].ToString(), out d))
//                    {
//                        points.Add(new KeyValuePair<string, double>(((DateTime)row["Result_date_time"]).ToString("MM-dd"), d));

//                        if (max < d)
//                        {
//                            max = d;
//                        }
//                        if (min > d)
//                        {
//                            min = d;
//                        }
//                    }
//                }
//                if (max > 0)
//                {
//                    d = max;
//                }
//                else
//                {
//                    d = min;
//                }
//                d = Math.Abs(d);
//                double d2 = max - min;
//                if (d <= 0.001)
//                {
//                    sclaleYvalue = 0.0001;
//                }
//                else if (d <= 0.01)
//                {
//                    sclaleYvalue = 0.001;
//                }
//                else if (d <= 0.1)
//                {
//                    sclaleYvalue = 0.01;
//                }
//                else if (d <= 0.5)
//                {
//                    sclaleYvalue = 0.05;
//                }
//                else if (d <= 1)
//                {
//                    sclaleYvalue = 0.1;
//                }
//                else if (d <= 5)
//                {
//                    sclaleYvalue = 0.5;
//                }
//                else if (d <= 10)
//                {
//                    sclaleYvalue = 1;
//                }
//                else if (d <= 50)
//                {
//                    sclaleYvalue = 5;
//                }
//                else if (d <= 100)
//                {
//                    sclaleYvalue = 10;
//                }
//                else if (d <= 1000)
//                {
//                    sclaleYvalue = 100;
//                }
//                else if (d <= 5000)
//                {
//                    sclaleYvalue = 500;
//                }
//                if (intYMultiple == 0)
//                {
//                    if (max == 0 && min == 0)
//                    {
//                        intYMultiple = -IntYMax / 2;
//                    }
//                    else if (max > 0 && min >= 0)
//                    {
//                        intYMultiple = 0;
//                    }
//                    else if (max > 0 && min < 0)
//                    {
//                        intYMultiple = -IntYMax / 2;
//                    }
//                    else if (max <= 0 && min < 0)
//                    {
//                        intYMultiple = -IntYMax;
//                    }
//                }
//            }
//            while (points.Count > 10)
//            {
//                points.RemoveAt(0);
//            }
//            Bitmap img = DrawingImg();
//            pictureEdit1.Image = img;

        } 
    }
}
