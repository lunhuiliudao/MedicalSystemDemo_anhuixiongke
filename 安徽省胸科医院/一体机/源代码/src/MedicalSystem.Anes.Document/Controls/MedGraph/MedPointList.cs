using System;
using System.Collections;
using System.Text;


namespace MedicalSystem.Anes.Document.Controls
{
    public class MedPointList : CollectionBase
    {

        public void Add(double x, double y) { List.Add(new MedPoint(x, y)); }
        public void Add(double x, double y, MedSymbol symbol) { List.Add(new MedPoint(x, y, symbol)); }
        public void Add(double x, double y, MedSymbol symbol,string memo) { List.Add(new MedPoint(x, y, symbol,memo)); }
        ///�޸ı�ע
        ///2008-6-8 ��ռ������Add�������أ��������׽��汣���飬���飬Ѫ����������ID��
        public void Add(double x, double y, MedSymbol symbol, string memo,string keys) 
        {
            MedPoint MedPoint1 = new MedPoint(x, y, symbol, memo);
            MedPoint1.RefKeyID = keys;
            List.Add(MedPoint1); 
        }
        ///�޸ı�ע
        ///2008-6-9 ��ռ������Add�������أ������ж�����ֵ�Ƿ�ƫ��ο�ֵ��Χ
        public void Add(double x, double y, MedSymbol symbol, string memo, bool isAbnormal)
        {
            MedPoint MedPoint1 = new MedPoint(x, y, symbol, memo); 
            MedPoint1.IsAbnormal = isAbnormal;
            List.Add(MedPoint1);
        }
        ///�޸ı�ע
        ///2008-6-9 ��ռ������Add��������
        public void Add(double x, double y, MedSymbol symbol, string memo, bool isAbnormal,string keys)
        {
            MedPoint MedPoint1 = new MedPoint(x, y, symbol, memo);
            MedPoint1.RefKeyID = keys;
            MedPoint1.IsAbnormal = isAbnormal;
            List.Add(MedPoint1);
        }
        public MedPoint this[int index]
        {
            get { return ((MedPoint)List[index]); }
            set { List[index] = value; }
        }
    }
}
