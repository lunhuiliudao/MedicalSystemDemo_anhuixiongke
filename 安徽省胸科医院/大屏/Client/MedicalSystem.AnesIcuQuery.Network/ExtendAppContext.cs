using System;
using System.Collections.Generic;
using MedicalSystem.AnesIcuQuery.Network;
using System.Data;
using System.Threading;
using MedicalSystem.MedScreen.Common;
using MedicalSystem.MedScreen.Network;

namespace MedicalSystem.AnesIcuQuery.Network
{
    /// <summary>
    /// 应用程序上下文类
    /// 用于保存部分全局内容
    /// </summary>
    public class ExtendAppContext
    {
        public readonly static ExtendAppContext Current = new ExtendAppContext();
        public readonly static ExtendAppContext OperProcCurnt = new ExtendAppContext();

        private string _loginName = "admin";
        /// <summary>
        /// 当前登录工号
        /// </summary>
        public string LoginName
        {
            get { return _loginName; }
            set { _loginName = value; }
        }


        private string _loginUserName = string.Empty;
        /// <summary>
        /// 当前用户名
        /// </summary>
        public string LoginUserName
        {
            get { return _loginUserName; }
            set { _loginUserName = value; }
        }


        private Dictionary<ApiUrlEnum, Dictionary<string, string>> _useDict = new Dictionary<ApiUrlEnum, Dictionary<string, string>>();
        /// <summary>
        /// 所有报表--供转换字典集合
        /// </summary>
        public Dictionary<ApiUrlEnum, Dictionary<string, string>> UseDict
        {
            get { return _useDict; }
            set { _useDict = value; }
        }

        private Dictionary<ApiUrlEnum, DataTable> _useTable = new Dictionary<ApiUrlEnum, DataTable>();
        /// <summary>
        /// 所有报表--下拉提供的数据源
        /// </summary>
        public Dictionary<ApiUrlEnum, DataTable> UseTable
        {
            get { return _useTable; }
            set { _useTable = value; }
        }

        private bool _hasLoadDict = false;
        /// <summary>
        /// 是否已经加载过字典数据
        /// </summary>
        public bool HasLoadDict
        {
            get { return _hasLoadDict; }
            set { _hasLoadDict = value; }
        }


        #region 大屏

        #region 家属等待和手术排班大屏全局变量

        /// <summary>
        /// 当前大屏编号
        /// </summary>
        private string _curntScreenNo = "1";
        public string CurntScreenNo
        {
            get
            {
                return _curntScreenNo;
            }
            set
            {
                _curntScreenNo = value;
            }
        }

        /// <summary>
        /// 输出显示大屏编号
        /// </summary>
        private int _showScreenNo = 1;
        public int ShowScreenNo
        {
            get
            {
                return _showScreenNo;
            }
            set
            {
                _showScreenNo = value;
            }
        }

        /// <summary>
        /// 当前大屏的类型
        /// </summary>
        private ScreenType _curntScreenType = ScreenType.OperScheduleScreen;
        public ScreenType CurntScreentType
        {
            get
            {

                return _curntScreenType;
            }
            set
            {
                _curntScreenType = value;
            }
        }

        /// <summary>
        /// 大屏标签（标题）
        /// </summary>
        private string _screenLabel;
        public string ScreenLabel
        {
            get
            {
                return _screenLabel;
            }
            set
            {
                _screenLabel = value;
            }
        }

        /// <summary>
        /// 手术科室代码筛选
        /// </summary>
        private string _operDeptCode = "1020800";
        public string OperDeptCode
        {
            get
            {
                return _operDeptCode;
            }
            set
            {
                _operDeptCode = value;
            }
        }

        /// <summary>
        /// 手术间筛选
        /// </summary>
        private string _operRoomFilter;
        public string OperRoomFilter
        {
            get
            {
                return _operRoomFilter;
            }
            set
            {
                _operRoomFilter = value;
            }
        }

        /// <summary>
        /// 大屏翻页数据刷新间隔
        /// </summary>
        private int _refreshTime = 60;
        public int RefreshTime
        {
            get
            {
                return _refreshTime;
            }
            set
            {
                _refreshTime = value;
            }
        }

        /// <summary>
        /// 大屏每页显示的行数
        /// </summary>
        private int _rowCount = 15;
        public int RowCount
        {
            get
            {
                return _rowCount;
            }
            set
            {
                _rowCount = value;
            }
        }

        /// <summary>
        /// 是否语音播报
        /// </summary>
        private bool _isBroadCast = true;
        public bool IsBroadCast
        {
            get
            {
                return _isBroadCast;
            }
            set
            {
                _isBroadCast = value;
            }
        }

        /// <summary>
        /// 大屏展现模式，是否是接台模式
        /// 仅限于排班大屏
        /// </summary>
        private bool _seqMode = false;
        public bool SeqMode
        {
            get
            {
                return _seqMode;
            }
            set
            {
                _seqMode = value;
            }
        }

        /// <summary>
        /// 特殊标记显示
        /// </summary>
        private bool _markSpec = false;
        public bool MarkSpec
        {
            get
            {
                return _markSpec;
            }
            set
            {
                _markSpec = value;
            }
        }

        /// <summary>
        /// 是否显示视频
        /// </summary>
        private bool _isTV = true;
        public bool IsTV
        {
            get
            {
                return _isTV;
            }
            set
            {
                _isTV = value;
            }
        }

        /// <summary>
        /// 是否保护患者隐私
        /// </summary>
        private bool _isPrivate = true;
        public bool IsPrivate
        {
            get
            {
                return _isPrivate;
            }
            set
            {
                _isPrivate = value;
            }
        }

        /// <summary>
        /// 皮肤名
        /// </summary>
        private string _skinName;
        public string SkinName
        {
            get
            {
                return _skinName;
            }
            set
            {
                _skinName = value;
            }
        }

        /// <summary>
        /// 显示字段
        /// </summary>
        private DataTable _fieldData;
        public DataTable FieldData
        {
            get
            {
                return _fieldData;
            }
            set
            {
                _fieldData = value;
            }
        }

        /// <summary>
        /// 接台显示字段
        /// </summary>
        private DataTable _seqFieldData;
        public DataTable SeqFieldData
        {
            get
            {
                return _seqFieldData;
            }
            set
            {
                _seqFieldData = value;
            }
        }
        /// <summary>
        /// 标题、显示行的高度
        /// </summary>
        private int _rowHeight;
        public int RowHeight
        {
            get
            {
                return _rowHeight;
            }
            set
            {
                _rowHeight = value;
            }
        }

        /// <summary>
        /// 顶部和底部的高度
        /// </summary>
        private int _topBottomHeight;
        public int TopBottomHeight
        {
            get
            {
                return _topBottomHeight;
            }
            set
            {
                _topBottomHeight = value;
            }
        }

        /// <summary>
        /// 显示内容的字体大小
        /// </summary>
        private float _contentFontSize;
        public float ContentFontSize
        {
            get
            {
                return _contentFontSize;
            }
            set
            {
                _contentFontSize = value;
            }
        }

        /// <summary>
        /// 固定播报信息列表
        /// </summary>
        private List<string> _staticMsgList;
        public List<string> StaticMsgList
        {
            get
            {
                return _staticMsgList;
            }
            set
            {
                _staticMsgList = value;
            }
        }
        #endregion

        #region 公共全局变量

        /// <summary>
        /// 系统当前进程（单位秒）
        /// </summary>
        private Thread _threadNetCheck = null;
        public Thread ThreadNetCheck
        {
            get { return _threadNetCheck; }
            set { _threadNetCheck = value; }
        }
        private int screenIndex = 0;
        public int ScreenIndex
        {
            get
            {
                return screenIndex;
            }
            set
            {
                screenIndex = value;
            }
        }
        /// <summary>
        /// 系统当前状态
        /// </summary>
        NetStatus _NetStatus = NetStatus.Connected;
        public NetStatus NetStatus
        {
            get { return _NetStatus; }
            set { _NetStatus = value; }
        }

        #endregion

        #region 主任工作站大屏全局变量
        /// <summary>
        /// 主任工作站大屏手术科室代码
        /// </summary>
        private string _dirctProcDeptCode = "1020800";
        public string DirctProcDeptCode
        {
            get
            {
                return _dirctProcDeptCode;
            }
            set
            {
                _dirctProcDeptCode = value;
            }
        }

        /// <summary>
        /// 主任工作站大屏每页显示行数
        /// </summary>
        private int _dirctProcRowCount = 2;
        public int DirctProcRowCount
        {
            get
            {
                return _dirctProcRowCount;
            }
            set
            {
                _dirctProcRowCount = value;
            }
        }

        /// <summary>
        /// 主任工作站大屏每页显示列数
        /// </summary>
        private int _dirctProcColCount = 5;
        public int DirctProcColCount
        {
            get
            {
                return _dirctProcColCount;
            }
            set
            {
                _dirctProcColCount = value;
            }
        }
        #endregion

        #region 医务站大屏配置项
        /// <summary>
        /// 医务站大屏每页显示行数
        /// </summary>
        private int _medicProRows = 15;
        public int MedicProRows
        {
            get
            {
                return _medicProRows;
            }
            set
            {
                _medicProRows = value;
            }
        }

        /// <summary>
        /// 医务站大屏手术科室代码
        /// </summary>
        private string _medicProDeptCode = "1020800";
        public string MedicProDeptCode
        {
            get
            {
                return _medicProDeptCode;
            }
            set
            {
                _medicProDeptCode = value;
            }
        }


        /// <summary>
        /// 医务站大屏起始时间
        /// </summary>
        private DateTime _medicProStartTime = DateTime.MinValue;
        public DateTime MedicProStartTime
        {
            get
            {

                return _medicProStartTime;
            }
            set
            {
                _medicProStartTime = value;
            }
        }

        /// <summary>
        /// 医务站大屏时间跨度
        /// </summary>
        private int _medicTimeSpan = 12;
        public int MedicTimeSpan
        {
            get
            {
                return _medicTimeSpan;
            }
            set
            {
                _medicTimeSpan = value;
            }
        }

        /// <summary>
        /// 医务站大屏首台开台时间
        /// </summary>
        private DateTime _medicFirstOperTime = DateTime.MinValue;
        public DateTime MedicFirstOperTime
        {
            get
            {

                return _medicFirstOperTime;
            }
            set
            {
                _medicFirstOperTime = value;
            }
        }

        /// <summary>
        /// 医务站大屏，首台开台时间偏差值
        /// </summary>
        private int _medicFirstSeqDev = 10;
        public int MedicFirstSeqDev
        {
            get
            {
                return _medicFirstSeqDev;
            }
            set
            {
                _medicFirstSeqDev = value;
            }
        }
        #endregion

        #region 主任工作站副屏2配置项
        /// <summary>
        /// 手术间明细左侧显示行数
        /// </summary>
        private int _operDetlRoomCount = 12;
        public int OperDetlRoomCount
        {
            get
            {
                return _operDetlRoomCount;
            }
            set
            {
                _operDetlRoomCount = value;
            }
        }

        /// <summary>
        /// 手术间明细中间区域显示的行数
        /// </summary>
        private int _operDetlRowCount = 2;
        public int OperDetlRowCount
        {
            get
            {
                return _operDetlRowCount;
            }
            set
            {
                _operDetlRowCount = value;
            }
        }

        /// <summary>
        /// 手术间明细中间区域显示的列数
        /// </summary>
        private int _operDetlColCount = 3;
        public int OperDetlColCount
        {
            get
            {
                return _operDetlColCount;
            }
            set
            {
                _operDetlColCount = value;
            }
        }
        #endregion
        #endregion
    }
}
