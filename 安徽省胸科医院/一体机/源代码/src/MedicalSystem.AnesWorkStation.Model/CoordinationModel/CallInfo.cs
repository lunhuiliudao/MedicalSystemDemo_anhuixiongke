// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      CallInfo.cs
// 功能描述(Description)：    协同通信的实体类
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

namespace MedicalSystem.AnesWorkStation.Model.CoordinationModel
{
    public class CallInfo : NotificationObject
    {
        private CallStatus _CallStatus;                                      // 通信状态枚举
        private string _RoomNo = "01";                                       // 手术间后台数据值
        private string _RoomNoDisplay = "手术间01";                          // 手术间前台显示值
        private string _UserName = "王OO医生";                               // 通信的人员
        private string _UserID = "";                                         // 当前系统登录账号

        /// <summary>
        /// 通信类型
        /// </summary>
        public CallStatus CallStatus
        {
            get { return _CallStatus; }
            set
            {
                _CallStatus = value;
                RaisePropertyChange("CallStatus");
            }
        }

        /// <summary>
        /// 手术间后台数据值
        /// </summary>
        public string RoomNo
        {
            get { return _RoomNo; }
            set
            {
                _RoomNo = value;
                RaisePropertyChange("RoomNo");
            }
        }

        /// <summary>
        /// 手术间前台显示值
        /// </summary>
        public string RoomNoDisplay
        {
            get { return _RoomNoDisplay; }
            set
            {
                _RoomNoDisplay = value;
                RaisePropertyChange("RoomNoDisplay");
            }
        }

        /// <summary>
        /// 通信人员
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                RaisePropertyChange("UserName");
            }
        }
        
        /// <summary>
        /// 登录工号
        /// </summary>
        public string UserID
        {
            get { return _UserID; }
            set
            {
                _UserID = value;
                RaisePropertyChange("UserID");
            }
        }

        /// <summary>
        /// 无参构造，默认当前通信状态处于空闲
        /// </summary>
        public CallInfo()
        {
            _CallStatus = CoordinationModel.CallStatus.Free;
        }

        /// <summary>
        /// 有参构造，设置通信状态
        /// </summary>
        public CallInfo(CallStatus CallStatus)
        {
            _CallStatus = CallStatus;
        }

        /// <summary>
        /// 有参构造
        /// </summary>
        /// <param name="CallStatus">通信状态</param>
        /// <param name="roomNo">手术间</param>
        /// <param name="roomNoDisplay">手术间显示信息</param>
        /// <param name="userID">通信人员ID</param>
        /// <param name="userName">通信人员姓名</param>
        public CallInfo(CallStatus CallStatus, string roomNo, string roomNoDisplay, string userID, string userName)
        {
            _CallStatus = CallStatus;
            _RoomNo = roomNo;
            _UserName = userName;
            _UserID = userID;
            _RoomNoDisplay = roomNoDisplay;
        }

        /// <summary>
        /// 有参构造
        /// </summary>
        /// <param name="roomNo">手术间</param>
        /// <param name="userName">通信人员</param>
        public CallInfo(string roomNo, string userName)
        {
            _CallStatus = CoordinationModel.CallStatus.Free;
            _RoomNo = roomNo;
            _UserName = userName;
        }
    }
}
