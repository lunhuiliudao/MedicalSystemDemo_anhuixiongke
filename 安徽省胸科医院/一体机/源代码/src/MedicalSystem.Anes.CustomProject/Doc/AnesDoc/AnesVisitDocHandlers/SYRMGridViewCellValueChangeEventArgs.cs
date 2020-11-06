// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      SYRMGridViewCellValueChangeEventArgs.cs
// 功能描述(Description)：    术后随访文书中单元格值更改触发的 自定义事件，用于计算总量
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using System;

namespace MedicalSystem.Anes.CustomProject.AnesVisitDocHandlers
{
    public class SYRMGridViewCellValueChangeEventArgs : EventArgs
    {
        private int valueTatol = 0;

        public int ValueTatol
        {
            get { return valueTatol; }
        }

        /// <summary>
        /// 有参构造
        /// </summary>
        /// <param name="valueTatol">总量</param>
        public SYRMGridViewCellValueChangeEventArgs(int valueTatol)
        {
            this.valueTatol = valueTatol;
        }
    }
}
