// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      AnesthesiaPathModel.cs
// 功能描述(Description)：    没有被引用，不知道干嘛╮(╯▽╰)╭
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace MedicalSystem.AnesWorkStation.Model.InOperationModel.AnesthesiaPathModel
{
    public class AnesthesiaPathModel : ObservableObject
    {
        public string TempletName { get; set; }
        public string CREATE_BY { get; set; }
        public string TEMPLET_CLASS { get; set; }
        public string Anes_Method { get; set; }

        public List<AnesthesiaPathModel> Children { get; set; }

        public AnesthesiaPathModel()  
        {
            Children = new List<AnesthesiaPathModel>();  
        }  
    }
}
