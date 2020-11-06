using System;
using System.Collections.Generic;
using System.Text;

///�޸ı�ע
///2008-6-8 ��ռ������RefKeyID���ԣ��������׽��汣���飬���飬Ѫ����������ID��,���ж��������������","�ָ�


namespace MedicalSystem.Anes.Document.Controls
{
    public class MedPoint
    {
        private bool isAbnormal = true;
        /// <summary>
        /// �����Ƿ�ƫ��ο�ֵ��Ϊ��û��ƫ�룬Ϊ�ٱ�ʾƫ��
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
        /// �������ID��
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
