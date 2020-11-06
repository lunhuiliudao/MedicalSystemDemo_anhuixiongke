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
        ///修改备注
        ///2008-6-8 于占涛增加Add方法重载，用来在首界面保存检查，检验，血气分析主键ID用
        public void Add(double x, double y, MedSymbol symbol, string memo,string keys) 
        {
            MedPoint MedPoint1 = new MedPoint(x, y, symbol, memo);
            MedPoint1.RefKeyID = keys;
            List.Add(MedPoint1); 
        }
        ///修改备注
        ///2008-6-9 于占涛增加Add方法重载，用来判断数据值是否偏离参考值范围
        public void Add(double x, double y, MedSymbol symbol, string memo, bool isAbnormal)
        {
            MedPoint MedPoint1 = new MedPoint(x, y, symbol, memo); 
            MedPoint1.IsAbnormal = isAbnormal;
            List.Add(MedPoint1);
        }
        ///修改备注
        ///2008-6-9 于占涛增加Add方法重载
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
