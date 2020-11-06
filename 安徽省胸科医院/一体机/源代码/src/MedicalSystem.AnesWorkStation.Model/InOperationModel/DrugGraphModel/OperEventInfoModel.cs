// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      OperEventInfoModel.cs
// 功能描述(Description)：    描述大事件的信息类：包含按键、标题、类型
// 数据表(Tables)：		      无
// 作者(Author)：             许文龙
// 日期(Create Date)：        2018/08/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

namespace MedicalSystem.AnesWorkStation.Model.InOperationModel.DrugGraphModel
{
    /// <summary>
    /// 描述大事件的信息类：包含按键、标题、类型
    /// </summary>
    public class OperEventInfoModel
    {
        private string appCode = string.Empty;               // 大事件对应的按键代码
        private string title = string.Empty;                 // 大事件对应的描述信息
        private string eventType = string.Empty;             // 大事件对应的实体类型

        /// <summary>
        /// 大事件对应的按键代码
        /// </summary>
        public string AppCode
        {
            get { return this.appCode; }
        }

        /// <summary>
        /// 大事件对应的描述信息
        /// </summary>
        public string Title
        {
            get { return this.title; }
        }

        /// <summary>
        /// 大事件对应的实体类型
        /// </summary>
        public string EventType
        {
            get { return this.eventType; }
        }

        /// <summary>
        /// 无参构造
        /// </summary>
        public OperEventInfoModel(string appCode, string title, string eventType)
        {
            this.appCode = appCode;
            this.title = title;
            this.eventType = eventType;
        }
    }
}
