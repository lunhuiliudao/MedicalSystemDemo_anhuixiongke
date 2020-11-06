/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MyClipBoard.cs
      // 文件功能描述：自制剪切板
      //
      // 
      // 创建标识：戴呈祥-2010-12-13
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Document.Designer
{
    public class MyClipBoard
    {
        private static object _data;
        public static object Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }
    }
}
