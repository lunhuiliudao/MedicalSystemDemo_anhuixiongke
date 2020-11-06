/*----------------------------------------------------------------
      // Copyright (C) 2005 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedGridRowList.cs
      // 文件功能描述：图表之数据列表行类
      //
      // 
      // 创建标识：戴呈祥-2007-12-20
----------------------------------------------------------------*/
using System.Collections;

namespace MedicalSystem.Anes.Document.Controls
{
    public class MedGridRowList
    {

        private bool _hastotal = true, _hassummery = true;
        private ArrayList[] _groups;

        public bool HasTotal { get { return _hastotal; } set { _hastotal = value; } }
        public bool HasSummery { get { return _hassummery; } set { _hassummery = value; } }
        public int TypeCount { get { return _groups.GetLength(0); } }
        
        public int Count 
        {
            get 
            { 
                int count = 0;
                foreach (ArrayList al in _groups)
                {
                    count += al.Count;// +1;
                }
                return (count <= 0) ? 1 : count;// +1;
            }
        }

        public int CountOfType(int typeindex) {return _groups[typeindex].Count; } 
        public MedGridRow this[int index, int typeindex] { get { return (MedGridRow)_groups[typeindex][index]; } set { _groups[typeindex][index] = value; } }

        public MedGridRowList(int typecount) 
        { 
            _groups = new ArrayList[typecount];
            for (int i = 0; i < _groups.GetLength(0); i++)
            {
                _groups[i] = new ArrayList();
            }
        }

        public void Add(MedGridRow row, int typeindex) { _groups[typeindex].Add(row); }
        public void Clear() 
        {
            foreach (ArrayList al in _groups)
            {
                al.Clear();
            }
        }

    }
}
