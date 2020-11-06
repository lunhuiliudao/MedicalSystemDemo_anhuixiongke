using System;
using System.Collections.Generic;
using System.Text;

///修改备注
///2008-6-8 于占涛增加RefKeyID属性，用来在首界面保存检查，检验，血气分析主键ID用,如有多个主键，可以用","分割


namespace MedicalSystem.Anes.Document.Controls
{
    public class MedPoint
    {
        private bool isAbnormal = true;
        /// <summary>
        /// 数据是否偏离参考值，为真没有偏离，为假表示偏离
        /// </summary>
        public bool IsAbnormal
        {
            set
            {
                isAbnormal = value;
            }
            get
            {
                return isAbnormal;
            }
        }

        private string refKeyID;
        /// <summary>
        /// 存放主键ID用
        /// </summary>
        public string RefKeyID
        {
            set
            {
                refKeyID = value;
            }
            get
            {
                return refKeyID;
            }
        }
        private MedSymbol symbol;

        public double X;
        public double Y;
        public string Memo;
        public MedSymbol Symbol { get { return symbol; } set { symbol = value; } }

        public MedPoint() : this(0, 0, null,null) { }
        public MedPoint(double X, double Y) : this(X, Y, null,null) { }
        public MedPoint(double X, double Y, MedSymbol symbol) : this(X, Y, symbol, null) { }
        public MedPoint(double X, double Y, MedSymbol symbol,string memo)
        {
            this.X = X;
            this.Y = Y;
            this.symbol = symbol;
            this.Memo = memo;
        }
    }
}
