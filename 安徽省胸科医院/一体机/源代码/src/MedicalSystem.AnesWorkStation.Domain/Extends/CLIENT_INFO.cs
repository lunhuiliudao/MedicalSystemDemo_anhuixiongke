//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      CLIENT_INFO.cs
//功能描述(Description)：    
//数据表(Tables)：		     
//作者(Author)：             吴文蛟
//日期(Create Date)：        2017/6/29 14:01:16
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public class CLIENT_INFO : BaseModel
    {

        public bool ISONLINE { get; set; }
        public string CLIENT_IP { get; set; }
        public string USER_NAME { get; set; }
        public string USER_ID { get; set; }
        public string ROOM_NO { get; set; }
        public string ROOM_NO_DISPLAY { get; set; }
        public string MENO { get; set; }
        public int CallStatus { get; set; }
    }
}
