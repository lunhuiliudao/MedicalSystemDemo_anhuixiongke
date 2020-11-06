

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:04:29
 * 
 * Notes:
 * 
* ******************************************************************/

using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data.OleDb;
using System.Data.Odbc;
using MedicalSytem.Soft.Model;
namespace MedicalSytem.Soft.DAL
{
    /// <summary>
    /// DAL MedMonitorDict
    /// </summary>

    public partial class DALMedMonitorDict
    {
        public DALMedMonitorDict()
        {
        }

        #region Oracle
        private static readonly string MED_MONITOR_DICT_Insert = @"INSERT INTO MED_MONITOR_DICT(MONITOR_LABEL,MANU_FIRM_NAME,MODEL,INTERFACE_TYPE,INTERFACE_DESC,IP_ADDR,MAC_ADDR,LAST_RECV_TIME,LAST_RECV_BED_ID,
                                                                   DUPLEX_FLAG,AUTOIN_FLAG, COMM_PORT, BAUD_RATE, BYTE_SIZE, PARITY, STOP_BITS, F_OUTX,F_INX,F_HARDWARE, TX_QUEUESIZE,
                                                                   RX_QUEUESIZE, XON_LIM,XOFF_LIM,XON_CHAR,XOFF_CHAR,ERROR_CHAR,EVENT_CHAR,DRIVER_PROG,PRIORITY,ITEM_TYPE,AUTO_LOAD,
                                                                   START_DATE_TIME,DEFAULT_RECV_FREQUENCY,CURRENT_RECV_FREQUENCY,CURRENT_RECVTIMES_UPLIMIT,CURRENT_RECV_ITEMS,
                                                                   WARD_CODE,WARD_TYPE, BED_NO,PATIENT_ID,VISIT_ID,OPER_ID,USING_INDICATOR,FREQUENCY_DISPLAY,MEMO,DATALOG_START_TIME,
                                                                   PC_PORT,DATALOG_STATUS,IP_PORT,IN_PORT,OUT_PORT,BED_NO_BIND)
                                                                   VALUES(:MONITORLABEL,:MANUFIRMNAME,:MODEL,:INTERFACETYPE,:INTERFACEDESC,:IPADDR,:MACADDR,:LASTRECVTIME,:LASTRECVBEDID,
                                                                   :DUPLEXFLAG,:AUTOINFLAG, :COMMPORT, :BAUDRATE, :BYTESIZE, :PARITY, :STOPBITS, :FOUTX,:FINX,:FHARDWARE, :TXQUEUESIZE,
                                                                   :RXQUEUESIZE, :XONLIM,:XOFFLIM,:XONCHAR,:XOFFCHAR,:ERRORCHAR,:EVENTCHAR,:DRIVERPROG,:PRIORITY,:ITEMTYPE,:AUTOLOAD,
                                                                   :STARTDATETIME,:DEFAULTRECVFREQUENCY,:CURRENTRECVFREQUENCY,:CURRENTRECVTIMESUPLIMIT,:CURRENTRECVITEMS,
                                                                   :WARDCODE,:WARDTYPE, :BEDNO,:PATIENTID,:VISITID,:OPERID,:USINGINDICATOR,:FREQUENCYDISPLAY,:MEMO,:DATALOGSTARTTIME,
                                                                   :PCPORT,:DATALOGSTATUS,:IPPORT,:INPORT,:OUTPORT,:BEDNOBIND)";
        private static readonly string MED_MONITOR_DICT_Update = @"UPDATE MED_MONITOR_DICT
                                                                   SET MONITOR_LABEL=:MONITORLABEL,MANU_FIRM_NAME =:MANUFIRMNAME,MODEL =:MODEL,INTERFACE_TYPE=:INTERFACETYPE,INTERFACE_DESC=:INTERFACEDESC,
                                                                   IP_ADDR=:IPADDR,MAC_ADDR=:MACADDR,LAST_RECV_TIME=:LASTRECVTIME,LAST_RECV_BED_ID=:LASTRECVBEDID,
                                                                   DUPLEX_FLAG=:DUPLEXFLAG,AUTOIN_FLAG=:AUTOINFLAG, COMM_PORT=:COMMPORT, BAUD_RATE=:BAUDRATE, BYTE_SIZE=:BYTESIZE, 
                                                                   PARITY=:PARITY, STOP_BITS=:STOPBITS, F_OUTX=:FOUTX,F_INX=:FINX,F_HARDWARE=:FHARDWARE, TX_QUEUESIZE=:TXQUEUESIZE,
                                                                   RX_QUEUESIZE=:RXQUEUESIZE, XON_LIM=:XONLIM,XOFF_LIM=:XOFFLIM,XON_CHAR=:XONCHAR,XOFF_CHAR=:XOFFCHAR,
                                                                   ERROR_CHAR=:ERRORCHAR,EVENT_CHAR=:EVENTCHAR,DRIVER_PROG=:DRIVERPROG,PRIORITY=:PRIORITY,ITEM_TYPE=:ITEMTYPE,AUTO_LOAD=:AUTOLOAD,
                                                                   START_DATE_TIME=:STARTDATETIME,DEFAULT_RECV_FREQUENCY=:DEFAULTRECVFREQUENCY,CURRENT_RECV_FREQUENCY=:CURRENTRECVFREQUENCY,
                                                                   CURRENT_RECVTIMES_UPLIMIT=:CURRENTRECVTIMESUPLIMIT,CURRENT_RECV_ITEMS=:CURRENTRECVITEMS,
                                                                   WARD_CODE=:WARDCODE,WARD_TYPE=:WARDTYPE, BED_NO=:BEDNO,PATIENT_ID=:PATIENTID,VISIT_ID=:VISITID,OPER_ID=:OPERID,
                                                                   USING_INDICATOR=:USINGINDICATOR,FREQUENCY_DISPLAY=:FREQUENCYDISPLAY,MEMO=:MEMO,DATALOG_START_TIME=:DATALOGSTARTTIME,
                                                                   PC_PORT=:PCPORT,DATALOG_STATUS=:DATALOGSTATUS,IP_PORT=:IPPORT,IN_PORT=:INPORT,OUT_PORT=:OUTPORT,BED_NO_BIND = :BEDNOBIND
                                                                   WHERE WARD_CODE =:WARDCODE AND BED_NO_BIND =:BEDNOBIND";
        private static readonly string MED_MONITOR_DICT_Delete = "Delete MED_MONITOR_DICT WHERE WARD_CODE=:WardCode AND Bed_No_Bind =:BedNoBind";
        private static readonly string MED_MONITOR_DICT_Select_One = "select count(1) from MED_MONITOR_DICT where patient_id =:patientID and visit_id =:visitID";
        private static readonly string MED_MONITOR_DICT_Select_One_With_Bed_No = "select count(1) from MED_MONITOR_DICT where patient_id =:patientID and visit_id =:visitID and WARD_CODE=:WardCode AND Bed_No_Bind =:BedNoBind";
        private static readonly string MED_MONITOR_DICT_Select = @"SELECT MONITOR_LABEL,MANU_FIRM_NAME,MODEL,INTERFACE_TYPE,INTERFACE_DESC,IP_ADDR,MAC_ADDR,LAST_RECV_TIME,LAST_RECV_BED_ID,
                                                                   DUPLEX_FLAG,AUTOIN_FLAG, COMM_PORT, BAUD_RATE, BYTE_SIZE, PARITY, STOP_BITS, F_OUTX,F_INX,F_HARDWARE, TX_QUEUESIZE,
                                                                   RX_QUEUESIZE, XON_LIM,XOFF_LIM,XON_CHAR,XOFF_CHAR,ERROR_CHAR,EVENT_CHAR,DRIVER_PROG,PRIORITY,ITEM_TYPE,AUTO_LOAD,
                                                                   START_DATE_TIME,DEFAULT_RECV_FREQUENCY,CURRENT_RECV_FREQUENCY,CURRENT_RECVTIMES_UPLIMIT,CURRENT_RECV_ITEMS,
                                                                   WARD_CODE,WARD_TYPE, BED_NO,PATIENT_ID,VISIT_ID,OPER_ID,USING_INDICATOR,FREQUENCY_DISPLAY,MEMO,DATALOG_START_TIME,
                                                                   PC_PORT,DATALOG_STATUS,IP_PORT,IN_PORT,OUT_PORT,BED_NO_BIND
                                                                   FROM MED_MONITOR_DICT WHERE WARD_CODE =:WardCode AND BED_NO_BIND =:BedNoBind";
        private static readonly string MED_MONITOR_DICT_Select_ALL = @"SELECT MONITOR_LABEL,MANU_FIRM_NAME,MODEL,INTERFACE_TYPE,INTERFACE_DESC,IP_ADDR,MAC_ADDR,LAST_RECV_TIME,LAST_RECV_BED_ID,
                                                                       DUPLEX_FLAG,AUTOIN_FLAG, COMM_PORT, BAUD_RATE, BYTE_SIZE, PARITY, STOP_BITS, F_OUTX,F_INX,F_HARDWARE, TX_QUEUESIZE,
                                                                       RX_QUEUESIZE, XON_LIM,XOFF_LIM,XON_CHAR,XOFF_CHAR,ERROR_CHAR,EVENT_CHAR,DRIVER_PROG,PRIORITY,ITEM_TYPE,AUTO_LOAD,
                                                                       START_DATE_TIME,DEFAULT_RECV_FREQUENCY,CURRENT_RECV_FREQUENCY,CURRENT_RECVTIMES_UPLIMIT,CURRENT_RECV_ITEMS,
                                                                       WARD_CODE,WARD_TYPE, BED_NO,PATIENT_ID,VISIT_ID,OPER_ID,USING_INDICATOR,FREQUENCY_DISPLAY,MEMO,DATALOG_START_TIME,
                                                                       PC_PORT,DATALOG_STATUS,IP_PORT,IN_PORT,OUT_PORT,BED_NO_BIND
                                                                       FROM MED_MONITOR_DICT";
        #endregion
        #region [获取参数]
        /// <summary>
        ///获取参数MedMonitorDict
        /// </summary>
        public static OracleParameter[] GetParameter(string sqlParms)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedMonitorDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":monitorlabel",OracleType.VarChar),
							new OracleParameter(":manufirmname",OracleType.VarChar),
							new OracleParameter(":model",OracleType.VarChar),
							new OracleParameter(":interfacetype",OracleType.Number),
							new OracleParameter(":interfacedesc",OracleType.VarChar),
							new OracleParameter(":ipaddr",OracleType.VarChar),
							new OracleParameter(":macaddr",OracleType.VarChar),
							new OracleParameter(":lastrecvtime",OracleType.DateTime),
							new OracleParameter(":lastrecvbedid",OracleType.VarChar),
                            new OracleParameter(":duplexflag",OracleType.Number),
                            new OracleParameter(":autoinflag",OracleType.VarChar),
							new OracleParameter(":commport",OracleType.VarChar),
							new OracleParameter(":baudrate",OracleType.Number),
							new OracleParameter(":bytesize",OracleType.Number),
							new OracleParameter(":parity",OracleType.VarChar),
							new OracleParameter(":stopbits",OracleType.Number),
                            new OracleParameter(":foutx",OracleType.VarChar),
							new OracleParameter(":finx",OracleType.VarChar),
							new OracleParameter(":fhardware",OracleType.VarChar),
							new OracleParameter(":txqueuesize",OracleType.VarChar),
							new OracleParameter(":rxqueuesize",OracleType.VarChar),
							new OracleParameter(":xonlim",OracleType.VarChar),
							new OracleParameter(":xofflim",OracleType.VarChar),
							new OracleParameter(":xonchar",OracleType.VarChar),
							new OracleParameter(":xoffchar",OracleType.VarChar),
							new OracleParameter(":errorchar",OracleType.VarChar),
							new OracleParameter(":eventchar",OracleType.VarChar),
							new OracleParameter(":driverprog",OracleType.VarChar),
                            new OracleParameter(":priority",OracleType.Number),
							new OracleParameter(":itemtype",OracleType.VarChar),
							new OracleParameter(":autoload",OracleType.Number),
							new OracleParameter(":startdatetime",OracleType.DateTime),
							new OracleParameter(":defaultrecvfrequency",OracleType.Number),
							new OracleParameter(":currentrecvfrequency",OracleType.Number),
							new OracleParameter(":currentrecvtimesuplimit",OracleType.Number),
							new OracleParameter(":currentrecvitems",OracleType.VarChar),
							new OracleParameter(":wardcode",OracleType.VarChar),
							new OracleParameter(":wardtype",OracleType.Number),
							new OracleParameter(":bedno",OracleType.VarChar),
							new OracleParameter(":patientid",OracleType.VarChar),
                            new OracleParameter(":visitid",OracleType.Number),
							new OracleParameter(":operid",OracleType.Number),
							new OracleParameter(":usingindicator",OracleType.Number),
							new OracleParameter(":frequencydisplay",OracleType.Number),
							new OracleParameter(":memo",OracleType.VarChar),
							new OracleParameter(":datalogstarttime",OracleType.DateTime),
							new OracleParameter(":pcport",OracleType.Number),
							new OracleParameter(":datalogstatus",OracleType.VarChar),
							new OracleParameter(":ipport",OracleType.Number),
							new OracleParameter(":inport",OracleType.Number),
							new OracleParameter(":outport",OracleType.VarChar),
                            new OracleParameter(":bednobind",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedMonitorDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":MONITORLABEL",OracleType.VarChar),
							new OracleParameter(":MANUFIRMNAME",OracleType.VarChar),
							new OracleParameter(":MODEL",OracleType.VarChar),
							new OracleParameter(":INTERFACETYPE",OracleType.Number),
							new OracleParameter(":INTERFACEDESC",OracleType.VarChar),
							new OracleParameter(":IPADDR",OracleType.VarChar),
							new OracleParameter(":MACADDR",OracleType.VarChar),
							new OracleParameter(":LASTRECVTIME",OracleType.DateTime),
							new OracleParameter(":LASTRECVBEDID",OracleType.VarChar),
                            new OracleParameter(":DUPLEXFLAG",OracleType.Number),
                            new OracleParameter(":AUTOINFLAG",OracleType.VarChar),
							new OracleParameter(":COMMPORT",OracleType.VarChar),
							new OracleParameter(":BAUDRATE",OracleType.Number),
							new OracleParameter(":BYTESIZE",OracleType.Number),
							new OracleParameter(":PARITY",OracleType.VarChar),
							new OracleParameter(":STOPBITS",OracleType.Number),
                            new OracleParameter(":FOUTX",OracleType.VarChar),
							new OracleParameter(":FINX",OracleType.VarChar),
							new OracleParameter(":FHARDWARE",OracleType.VarChar),
							new OracleParameter(":TXQUEUESIZE",OracleType.VarChar),
							new OracleParameter(":RXQUEUESIZE",OracleType.VarChar),
							new OracleParameter(":XONLIM",OracleType.VarChar),
							new OracleParameter(":XOFFLIM",OracleType.VarChar),
							new OracleParameter(":XONCHAR",OracleType.VarChar),
							new OracleParameter(":XOFFCHAR",OracleType.VarChar),
							new OracleParameter(":ERRORCHAR",OracleType.VarChar),
							new OracleParameter(":EVENTCHAR",OracleType.VarChar),
							new OracleParameter(":DRIVERPROG",OracleType.VarChar),
                            new OracleParameter(":PRIORITY",OracleType.Number),
							new OracleParameter(":ITEMTYPE",OracleType.VarChar),
							new OracleParameter(":AUTOLOAD",OracleType.Number),
							new OracleParameter(":STARTDATETIME",OracleType.DateTime),
							new OracleParameter(":DEFAULTRECVFREQUENCY",OracleType.Number),
							new OracleParameter(":CURRENTRECVFREQUENCY",OracleType.Number),
							new OracleParameter(":CURRENTRECVTIMESUPLIMIT",OracleType.Number),
							new OracleParameter(":CURRENTRECVITEMS",OracleType.VarChar),
							new OracleParameter(":WARDCODE",OracleType.VarChar),
							new OracleParameter(":WARDTYPE",OracleType.Number),
							new OracleParameter(":BEDNO",OracleType.VarChar),
							new OracleParameter(":PATIENTID",OracleType.VarChar),
                            new OracleParameter(":VISITID",OracleType.Number),
							new OracleParameter(":OPERID",OracleType.Number),
							new OracleParameter(":USINGINDICATOR",OracleType.Number),
							new OracleParameter(":FREQUENCYDISPLAY",OracleType.Number),
							new OracleParameter(":MEMO",OracleType.VarChar),
							new OracleParameter(":DATALOGSTARTTIME",OracleType.DateTime),
							new OracleParameter(":PCPORT",OracleType.Number),
							new OracleParameter(":DATALOGSTATUS",OracleType.VarChar),
							new OracleParameter(":IPPORT",OracleType.Number),
							new OracleParameter(":INPORT",OracleType.Number),
							new OracleParameter(":OUTPORT",OracleType.VarChar),
                            new OracleParameter(":BEDNOBIND",OracleType.VarChar),
                            new OracleParameter(":WARDCODE",OracleType.VarChar),
                            new OracleParameter(":BEDNOBIND",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedMonitorDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":WardCode",OracleType.VarChar),
							new OracleParameter(":BedNoBind",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedMonitorDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":WardCode",OracleType.VarChar),
							new OracleParameter(":BedNoBind",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedMonitorDictLabel")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":WardCode",OracleType.VarChar),
							new OracleParameter(":BedLabel",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectOneMedMonitorDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":patientID",OracleType.VarChar),
                            new OracleParameter(":visitID",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectOneMedMonitorDictWithBedNo")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":patientID",OracleType.VarChar),
                            new OracleParameter(":visitID",OracleType.Number),
                            new OracleParameter(":WardCode",OracleType.VarChar),
                            new OracleParameter(":BedNoBind",OracleType.VarChar),
                    };
                }
                OracleHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedMonitorDict 
        ///Insert Table MED_MONITOR_DICT
        /// </summary>
        public int InsertMedMonitorDict(MedMonitorDict model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedMonitorDict");
                if (model.MonitorLabel != null)
                    oneInert[0].Value = model.MonitorLabel;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.ManuFirmName != null)
                    oneInert[1].Value = model.ManuFirmName;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.Model != null)
                    oneInert[2].Value = model.Model;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.InterfaceType.ToString() != null)
                    oneInert[3].Value = model.InterfaceType;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.InterfaceDesc != null)
                    oneInert[4].Value = model.InterfaceDesc;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.IpAddr != null)
                    oneInert[5].Value = model.IpAddr;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.MacAddr != null)
                    oneInert[6].Value = model.MacAddr;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.LastRecvTime != null)
                    oneInert[7].Value = model.LastRecvTime;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.LastRecvBedId != null)
                    oneInert[8].Value = model.LastRecvBedId;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.DuplexFlag.ToString() != null)
                    oneInert[9].Value = model.DuplexFlag;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.AutoinFlag != null)
                    oneInert[10].Value = model.AutoinFlag;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.Commport.ToString() != null)
                    oneInert[11].Value = model.Commport;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.BaudRate.ToString() != null)
                    oneInert[12].Value = model.BaudRate;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.ByteSize.ToString() != null)
                    oneInert[13].Value = model.ByteSize;
                else
                    oneInert[13].Value = DBNull.Value;
                if (model.Parity.ToString() != null)
                    oneInert[14].Value = model.Parity;
                else
                    oneInert[14].Value = DBNull.Value;
                if (model.StopBits.ToString() != null)
                    oneInert[15].Value = model.StopBits;
                else
                    oneInert[15].Value = DBNull.Value;
                if (model.FOutx.ToString() != null)
                    oneInert[16].Value = model.FOutx;
                else
                    oneInert[16].Value = DBNull.Value;
                if (model.FInx.ToString() != null)
                    oneInert[17].Value = model.FInx;
                else
                    oneInert[17].Value = DBNull.Value;
                if (model.FHardware.ToString() != null)
                    oneInert[18].Value = model.FHardware;
                else
                    oneInert[18].Value = DBNull.Value;
                if (model.TxQueuesize.ToString() != null)
                    oneInert[19].Value = model.TxQueuesize;
                else
                    oneInert[19].Value = DBNull.Value;
                if (model.RxQueuesize.ToString() != null)
                    oneInert[20].Value = model.RxQueuesize;
                else
                    oneInert[20].Value = DBNull.Value;
                if (model.XonLim.ToString() != null)
                    oneInert[21].Value = model.XonLim;
                else
                    oneInert[21].Value = DBNull.Value;
                if (model.XoffLim.ToString() != null)
                    oneInert[22].Value = model.XoffLim;
                else
                    oneInert[22].Value = DBNull.Value;
                if (model.XonChar.ToString() != null)
                    oneInert[23].Value = model.XonChar;
                else
                    oneInert[23].Value = DBNull.Value;
                if (model.XoffChar.ToString() != null)
                    oneInert[24].Value = model.XoffChar;
                else
                    oneInert[24].Value = DBNull.Value;
                if (model.ErrorChar.ToString() != null)
                    oneInert[25].Value = model.ErrorChar;
                else
                    oneInert[25].Value = DBNull.Value;
                if (model.EventChar.ToString() != null)
                    oneInert[26].Value = model.EventChar;
                else
                    oneInert[26].Value = DBNull.Value;
                if (model.DriverProg.ToString() != null)
                    oneInert[27].Value = model.DriverProg;
                else
                    oneInert[27].Value = DBNull.Value;
                if (model.Priority.ToString() != null)
                    oneInert[28].Value = model.Priority;
                else
                    oneInert[28].Value = DBNull.Value;
                if (model.ItemType.ToString() != null)
                    oneInert[29].Value = model.ItemType;
                else
                    oneInert[29].Value = DBNull.Value;
                if (model.AutoLoad.ToString() != null)
                    oneInert[30].Value = model.AutoLoad;
                else
                    oneInert[30].Value = DBNull.Value;
                if (model.StartDateTime > DateTime.MinValue)
                    oneInert[31].Value = model.StartDateTime;
                else
                    oneInert[31].Value = DBNull.Value;
                if (model.DefaultRecvFrequency.ToString() != null)
                    oneInert[32].Value = model.DefaultRecvFrequency;
                else
                    oneInert[32].Value = DBNull.Value;
                if (model.CurrentRecvFrequency.ToString() != null)
                    oneInert[33].Value = model.CurrentRecvFrequency;
                else
                    oneInert[33].Value = DBNull.Value;
                if (model.CurrentRecvtimesUplimit.ToString() != null)
                    oneInert[34].Value = model.CurrentRecvtimesUplimit;
                else
                    oneInert[34].Value = DBNull.Value;
                if (model.CurrentRecviTems != null)
                    oneInert[35].Value = model.CurrentRecviTems;
                else
                    oneInert[35].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneInert[36].Value = model.WardCode;
                else
                    oneInert[36].Value = DBNull.Value;
                if (model.WardType.ToString() != null)
                    oneInert[37].Value = model.WardType;
                else
                    oneInert[37].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneInert[38].Value = model.BedNo;
                else
                    oneInert[38].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneInert[39].Value = model.PatientId;
                else
                    oneInert[39].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneInert[40].Value = model.VisitId;
                else
                    oneInert[40].Value = DBNull.Value;
                if (model.OperId.ToString() != null)
                    oneInert[41].Value = model.OperId;
                else
                    oneInert[41].Value = DBNull.Value;
                if (model.UsingIndicator.ToString() != null)
                    oneInert[42].Value = model.UsingIndicator;
                else
                    oneInert[42].Value = DBNull.Value;
                if (model.FrequencyDisplay.ToString() != null)
                    oneInert[43].Value = model.FrequencyDisplay;
                else
                    oneInert[43].Value = DBNull.Value;
                if (model.Memo != null)
                    oneInert[44].Value = model.Memo;
                else
                    oneInert[44].Value = DBNull.Value;
                if (model.DatalogStartTime != null)
                    oneInert[45].Value = model.DatalogStartTime;
                else
                    oneInert[45].Value = DBNull.Value;
                if (model.PcPort.ToString() != null)
                    oneInert[46].Value = model.PcPort;
                else
                    oneInert[46].Value = DBNull.Value;
                if (model.DatalogStatus != null)
                    oneInert[47].Value = model.DatalogStatus;
                else
                    oneInert[47].Value = DBNull.Value;
                if (model.IpPort.ToString() != null)
                    oneInert[48].Value = model.IpPort;
                else
                    oneInert[48].Value = DBNull.Value;
                if (model.InPort.ToString() != null)
                    oneInert[49].Value = model.InPort;
                else
                    oneInert[49].Value = DBNull.Value;
                if (model.OutPort.ToString() != null)
                    oneInert[50].Value = model.OutPort;
                else
                    oneInert[50].Value = DBNull.Value;
                if (model.BedNoBind != null)
                    oneInert[51].Value = model.BedNoBind;
                else
                    oneInert[51].Value = DBNull.Value;
                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_MONITOR_DICT_Insert, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedMonitorDict 
        ///Update Table     MED_MONITOR_DICT
        /// </summary>
        public int UpdateMedMonitorDict(MedMonitorDict model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneUpdate = GetParameter("UpdateMedMonitorDict");
                if (model.MonitorLabel != null)
                    oneUpdate[0].Value = model.MonitorLabel;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.ManuFirmName != null)
                    oneUpdate[1].Value = model.ManuFirmName;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.Model != null)
                    oneUpdate[2].Value = model.Model;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.InterfaceType.ToString() != null)
                    oneUpdate[3].Value = model.InterfaceType;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.InterfaceDesc != null)
                    oneUpdate[4].Value = model.InterfaceDesc;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.IpAddr != null)
                    oneUpdate[5].Value = model.IpAddr;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.MacAddr != null)
                    oneUpdate[6].Value = model.MacAddr;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.LastRecvTime > DateTime.MinValue)
                    oneUpdate[7].Value = model.LastRecvTime;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.LastRecvBedId != null)
                    oneUpdate[8].Value = model.LastRecvBedId;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.DuplexFlag > 0)
                    oneUpdate[9].Value = model.DuplexFlag;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.AutoinFlag != null)
                    oneUpdate[10].Value = model.AutoinFlag;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.Commport != null)
                    oneUpdate[11].Value = model.Commport;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.BaudRate > 0)
                    oneUpdate[12].Value = model.BaudRate;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.ByteSize > 0)
                    oneUpdate[13].Value = model.ByteSize;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (model.Parity > 0)
                    oneUpdate[14].Value = model.Parity;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (model.StopBits > 0)
                    oneUpdate[15].Value = model.StopBits;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (model.FOutx > 0)
                    oneUpdate[16].Value = model.FOutx;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (model.FInx > 0)
                    oneUpdate[17].Value = model.FInx;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (model.FHardware > 0)
                    oneUpdate[18].Value = model.FHardware;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (model.TxQueuesize > 0)
                    oneUpdate[19].Value = model.TxQueuesize;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (model.RxQueuesize > 0)
                    oneUpdate[20].Value = model.RxQueuesize;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (model.XonLim > 0)
                    oneUpdate[21].Value = model.XonLim;
                else
                    oneUpdate[21].Value = DBNull.Value;
                if (model.XoffLim > 0)
                    oneUpdate[22].Value = model.XoffLim;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (model.XonChar != null)
                    oneUpdate[23].Value = model.XonChar;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (model.XoffChar != null)
                    oneUpdate[24].Value = model.XoffChar;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (model.ErrorChar != null)
                    oneUpdate[25].Value = model.ErrorChar;
                else
                    oneUpdate[25].Value = DBNull.Value;
                if (model.EventChar != null)
                    oneUpdate[26].Value = model.EventChar;
                else
                    oneUpdate[26].Value = DBNull.Value;
                if (model.DriverProg != null)
                    oneUpdate[27].Value = model.DriverProg;
                else
                    oneUpdate[27].Value = DBNull.Value;
                if (model.Priority > 0)
                    oneUpdate[28].Value = model.Priority;
                else
                    oneUpdate[28].Value = DBNull.Value;
                if (model.ItemType != null)
                    oneUpdate[29].Value = model.ItemType;
                else
                    oneUpdate[29].Value = DBNull.Value;
                if (model.AutoLoad > 0)
                    oneUpdate[30].Value = model.AutoLoad;
                else
                    oneUpdate[30].Value = DBNull.Value;
                if (model.StartDateTime > DateTime.MinValue)
                    oneUpdate[31].Value = model.StartDateTime;
                else
                    oneUpdate[31].Value = DBNull.Value;
                if (model.DefaultRecvFrequency > 0)
                    oneUpdate[32].Value = model.DefaultRecvFrequency;
                else
                    oneUpdate[32].Value = DBNull.Value;
                if (model.CurrentRecvFrequency > 0)
                    oneUpdate[33].Value = model.CurrentRecvFrequency;
                else
                    oneUpdate[33].Value = DBNull.Value;
                if (model.CurrentRecvtimesUplimit > 0)
                    oneUpdate[34].Value = model.CurrentRecvtimesUplimit;
                else
                    oneUpdate[34].Value = DBNull.Value;
                if (model.CurrentRecviTems != null)
                    oneUpdate[35].Value = model.CurrentRecviTems;
                else
                    oneUpdate[35].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneUpdate[36].Value = model.WardCode;
                else
                    oneUpdate[36].Value = DBNull.Value;
                if (model.WardType != null)
                    oneUpdate[37].Value = model.WardType;
                else
                    oneUpdate[37].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneUpdate[38].Value = model.BedNo;
                else
                    oneUpdate[38].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneUpdate[39].Value = model.PatientId;
                else
                    oneUpdate[39].Value = DBNull.Value;
                if (model.VisitId >= 0)
                    oneUpdate[40].Value = model.VisitId;
                else
                    oneUpdate[40].Value = DBNull.Value;
                if (model.OperId >= 0)
                    oneUpdate[41].Value = model.OperId;
                else
                    oneUpdate[41].Value = DBNull.Value;
                if (model.UsingIndicator.ToString() != null)
                    oneUpdate[42].Value = model.UsingIndicator;
                else
                    oneUpdate[42].Value = DBNull.Value;
                if (model.FrequencyDisplay.ToString() != null)
                    oneUpdate[43].Value = model.FrequencyDisplay;
                else
                    oneUpdate[43].Value = DBNull.Value;
                if (model.Memo != null)
                    oneUpdate[44].Value = model.Memo;
                else
                    oneUpdate[44].Value = DBNull.Value;
                if (model.DatalogStartTime > DateTime.MinValue)
                    oneUpdate[45].Value = model.DatalogStartTime;
                else
                    oneUpdate[45].Value = DBNull.Value;
                if (model.PcPort.ToString() != null)
                    oneUpdate[46].Value = model.PcPort;
                else
                    oneUpdate[46].Value = DBNull.Value;
                if (model.DatalogStatus != null)
                    oneUpdate[47].Value = model.DatalogStatus;
                else
                    oneUpdate[47].Value = DBNull.Value;
                if (model.IpPort > 0)
                    oneUpdate[48].Value = model.IpPort;
                else
                    oneUpdate[48].Value = DBNull.Value;
                if (model.InPort > 0)
                    oneUpdate[49].Value = model.InPort;
                else
                    oneUpdate[49].Value = DBNull.Value;
                if (model.OutPort > 0)
                    oneUpdate[50].Value = model.OutPort;
                else
                    oneUpdate[50].Value = DBNull.Value;
                if (model.BedNoBind != null)
                    oneUpdate[51].Value = model.BedNoBind;
                else
                    oneUpdate[51].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneUpdate[52].Value = model.WardCode;
                else
                    oneUpdate[52].Value = DBNull.Value;
                if (model.BedNoBind != null)
                    oneUpdate[53].Value = model.BedNoBind;
                else
                    oneUpdate[53].Value = DBNull.Value;
                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_MONITOR_DICT_Update, oneUpdate);
            }
        }
        #endregion

        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedMonitorDict 
        ///Delete Table MED_MONITOR_DICT by (string WARD_CODE,string BED_NO)
        /// </summary>
        public int DeleteMedMonitorDict(string WARD_CODE, string BED_NO)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneDelete = GetParameter("DeleteMedMonitorDict");
                if (WARD_CODE != null)
                    oneDelete[0].Value = WARD_CODE;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (BED_NO != null)
                    oneDelete[1].Value = BED_NO;
                else
                    oneDelete[1].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_MONITOR_DICT_Delete, oneDelete);
            }
        }
        #endregion
        #region  [根据科室和床位获取一条记录]
        /// <summary>
        ///Select    model  MedMonitorDict 
        ///select Table MED_MONITOR_DICT by (string WARD_CODE,string BED_NO)
        /// </summary>
        public MedMonitorDict SelectMedMonitorDict(string WARD_CODE, string BED_NO)
        {
            MedMonitorDict model;
            OracleParameter[] parameterValues = GetParameter("SelectMedMonitorDict");
            parameterValues[0].Value = WARD_CODE;
            parameterValues[1].Value = BED_NO;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_MONITOR_DICT_Select, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedMonitorDict();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.MonitorLabel = oleReader["MONITOR_LABEL"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.ManuFirmName = oleReader["MANU_FIRM_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.Model = oleReader["MODEL"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.InterfaceType = decimal.Parse(oleReader["INTERFACE_TYPE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.InterfaceDesc = oleReader["INTERFACE_DESC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.IpAddr = oleReader["IP_ADDR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.MacAddr = oleReader["MAC_ADDR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.LastRecvTime = DateTime.Parse(oleReader["LAST_RECV_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.LastRecvBedId = oleReader["LAST_RECV_BED_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.DuplexFlag = decimal.Parse(oleReader["DUPLEX_FLAG"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.AutoinFlag = oleReader["AUTOIN_FLAG"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Commport = oleReader["COMM_PORT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.BaudRate = decimal.Parse(oleReader["BAUD_RATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.ByteSize = decimal.Parse(oleReader["BYTE_SIZE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Parity = decimal.Parse(oleReader["PARITY"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.StopBits = decimal.Parse(oleReader["STOP_BITS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.FOutx = decimal.Parse(oleReader["F_OUTX"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.FInx = decimal.Parse(oleReader["F_INX"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.FHardware = decimal.Parse(oleReader["F_HARDWARE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.TxQueuesize = decimal.Parse(oleReader["TX_QUEUESIZE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.RxQueuesize = decimal.Parse(oleReader["RX_QUEUESIZE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.XonLim = decimal.Parse(oleReader["XON_LIM"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.XoffLim = decimal.Parse(oleReader["XOFF_LIM"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.XonChar = oleReader["XON_CHAR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.XoffChar = oleReader["XOFF_CHAR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.ErrorChar = oleReader["ERROR_CHAR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.EventChar = oleReader["EVENT_CHAR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.DriverProg = oleReader["DRIVER_PROG"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.Priority = decimal.Parse(oleReader["PRIORITY"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.ItemType = oleReader["ITEM_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.AutoinFlag = oleReader["AUTO_LOAD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.StartDateTime = DateTime.Parse(oleReader["START_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.DefaultRecvFrequency = decimal.Parse(oleReader["DEFAULT_RECV_FREQUENCY"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.CurrentRecvFrequency = decimal.Parse(oleReader["CURRENT_RECV_FREQUENCY"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.CurrentRecvtimesUplimit = decimal.Parse(oleReader["CURRENT_RECVTIMES_UPLIMIT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(35))
                    {
                        model.CurrentRecviTems = oleReader["CURRENT_RECV_ITEMS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(36))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(37))
                    {
                        model.WardType = decimal.Parse(oleReader["WARD_TYPE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(38))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(39))
                    {
                        model.PatientId = oleReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(40))
                    {
                        model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(41))
                    {
                        model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(42))
                    {
                        model.UsingIndicator = decimal.Parse(oleReader["USING_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(43))
                    {
                        model.FrequencyDisplay = decimal.Parse(oleReader["FREQUENCY_DISPLAY"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(44))
                    {
                        model.Memo = oleReader["MEMO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(45))
                    {
                        model.DatalogStartTime = DateTime.Parse(oleReader["DATALOG_START_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(46))
                    {
                        model.PcPort = decimal.Parse(oleReader["PC_PORT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(47))
                    {
                        model.DatalogStatus = oleReader["DATALOG_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(48))
                    {
                        model.IpPort = decimal.Parse(oleReader["IP_PORT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(49))
                    {
                        model.InPort = decimal.Parse(oleReader["IN_PORT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(50))
                    {
                        model.OutPort = decimal.Parse(oleReader["OUT_PORT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(51))
                    {
                        model.BedNoBind = oleReader["BED_NO_BIND"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion
        #region [查询病人记录是否存在]
        public int SelectOneMedMonitorDict(string patientID, decimal visitID)
        {
            OracleParameter[] parms = GetParameter("SelectOneMedMonitorDict");
            parms[0].Value = patientID;
            parms[1].Value = visitID;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_MONITOR_DICT_Select_One, parms))
            {
                if (oleReader.Read())
                {
                    return (int)oleReader.GetDecimal(0);
                }
                else
                {
                    return 0;
                }
            }
        }
        #endregion

        #region [查询病人记录是否存在WithBedNo]
        public int SelectOneMedMonitorDictWithBedNo(string patientID, decimal visitID, string WardCode, string BedNo)
        {
            OracleParameter[] parms = GetParameter("SelectOneMedMonitorDictWithBedNo");
            parms[0].Value = patientID;
            parms[1].Value = visitID;
            parms[2].Value = WardCode;
            parms[3].Value = BedNo;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_MONITOR_DICT_Select_One_With_Bed_No, parms))
            {
                if (oleReader.Read())
                {
                    return (int)oleReader.GetDecimal(0);
                }
                else
                {
                    return 0;
                }
            }
        }
        #endregion
        #region  [获取所有记录]
        /// <summary>
        ///获取所有记录
        /// </summary>
        //public List<MedMonitorDict> SelectMedMonitorDictList()
        //{
        //    List<MedMonitorDict> modelList = new List<MedMonitorDict>();
        //    using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_MONITOR_DICT_Select_ALL, null))
        //    {
        //        while (oleReader.Read())
        //        {
        //            MedMonitorDict model = new MedMonitorDict();
        //            if (!oleReader.IsDBNull(0))
        //            {
        //                model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
        //            }
        //            if (!oleReader.IsDBNull(1))
        //            {
        //                model.BedNo = oleReader["BED_NO"].ToString().Trim();
        //            }
        //            if (!oleReader.IsDBNull(2))
        //            {
        //                model.BedLabel = oleReader["BED_LABEL"].ToString().Trim();
        //            }
        //            if (!oleReader.IsDBNull(3))
        //            {
        //                model.RoomNo = oleReader["ROOM_NO"].ToString().Trim();
        //            }
        //            if (!oleReader.IsDBNull(4))
        //            {
        //                model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
        //            }
        //            if (!oleReader.IsDBNull(5))
        //            {
        //                model.BedApprovedType = oleReader["BED_APPROVED_TYPE"].ToString().Trim();
        //            }
        //            if (!oleReader.IsDBNull(6))
        //            {
        //                model.BedSexType = oleReader["BED_SEX_TYPE"].ToString().Trim();
        //            }
        //            if (!oleReader.IsDBNull(7))
        //            {
        //                model.BedClass = oleReader["BED_CLASS"].ToString().Trim();
        //            }
        //            if (!oleReader.IsDBNull(8))
        //            {
        //                model.BedStatus = oleReader["BED_STATUS"].ToString().Trim();
        //            }
        //            if (!oleReader.IsDBNull(9))
        //            {
        //                model.IcuIndicator = decimal.Parse(oleReader["ICU_INDICATOR"].ToString().Trim());
        //            }
        //            if (!oleReader.IsDBNull(10))
        //            {
        //                model.MonitorLabel = oleReader["MONITOR_LABEL"].ToString().Trim();
        //            }
        //            if (!oleReader.IsDBNull(11))
        //            {
        //                model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
        //            }
        //            modelList.Add(model);
        //        }
        //    }
        //    return modelList;
        //}
        #endregion


        #region SqlServer
        private static readonly string MED_MONITOR_DICT_Insert_SQL = @"INSERT INTO MED_MONITOR_DICT(MONITOR_LABEL,MANU_FIRM_NAME,MODEL,INTERFACE_TYPE,INTERFACE_DESC,IP_ADDR,MAC_ADDR,LAST_RECV_TIME,LAST_RECV_BED_ID,
                                                                   DUPLEX_FLAG,AUTOIN_FLAG, COMM_PORT, BAUD_RATE, BYTE_SIZE, PARITY, STOP_BITS, F_OUTX,F_INX,F_HARDWARE, TX_QUEUESIZE,
                                                                   RX_QUEUESIZE, XON_LIM,XOFF_LIM,XON_CHAR,XOFF_CHAR,ERROR_CHAR,EVENT_CHAR,DRIVER_PROG,PRIORITY,ITEM_TYPE,AUTO_LOAD,
                                                                   START_DATE_TIME,DEFAULT_RECV_FREQUENCY,CURRENT_RECV_FREQUENCY,CURRENT_RECVTIMES_UPLIMIT,CURRENT_RECV_ITEMS,
                                                                   WARD_CODE,WARD_TYPE, BED_NO,PATIENT_ID,VISIT_ID,OPER_ID,USING_INDICATOR,FREQUENCY_DISPLAY,MEMO,DATALOG_START_TIME,
                                                                   PC_PORT,DATALOG_STATUS,IP_PORT,IN_PORT,OUT_PORT,BED_NO_BIND)
                                                                   VALUES(@MONITORLABEL,@MANUFIRMNAME,@MODEL,@INTERFACETYPE,@INTERFACEDESC,@IPADDR,@MACADDR,@LASTRECVTIME,@LASTRECVBEDID,
                                                                   @DUPLEXFLAG,@AUTOINFLAG, @COMMPORT, @BAUDRATE, @BYTESIZE, @PARITY, @STOPBITS, @FOUTX,@FINX,@FHARDWARE, @TXQUEUESIZE,
                                                                   @RXQUEUESIZE, @XONLIM,@XOFFLIM,@XONCHAR,@XOFFCHAR,@ERRORCHAR,@EVENTCHAR,@DRIVERPROG,@PRIORITY,@ITEMTYPE,@AUTOLOAD,
                                                                   @STARTDATETIME,@DEFAULTRECVFREQUENCY,@CURRENTRECVFREQUENCY,@CURRENTRECVTIMESUPLIMIT,@CURRENTRECVITEMS,
                                                                   @WARDCODE,@WARDTYPE, @BEDNO,@PATIENTID,@VISITID,@OPERID,@USINGINDICATOR,@FREQUENCYDISPLAY,@MEMO,@DATALOGSTARTTIME,
                                                                   @PCPORT,@DATALOGSTATUS,@IPPORT,@INPORT,@OUTPORT,@BEDNOBIND)";
        private static readonly string MED_MONITOR_DICT_Update_SQL = @"UPDATE MED_MONITOR_DICT
                                                                   SET MONITOR_LABEL=@MONITORLABEL,MANU_FIRM_NAME =@MANUFIRMNAME,MODEL =@MODEL,INTERFACE_TYPE=@INTERFACETYPE,INTERFACE_DESC=@INTERFACEDESC,
                                                                   IP_ADDR=@IPADDR,MAC_ADDR=@MACADDR,LAST_RECV_TIME=@LASTRECVTIME,LAST_RECV_BED_ID=@LASTRECVBEDID,
                                                                   DUPLEX_FLAG=@DUPLEXFLAG,AUTOIN_FLAG=@AUTOINFLAG, COMM_PORT=@COMMPORT, BAUD_RATE=@BAUDRATE, BYTE_SIZE=@BYTESIZE, 
                                                                   PARITY=@PARITY, STOP_BITS=@STOPBITS, F_OUTX=@FOUTX,F_INX=@FINX,F_HARDWARE=@FHARDWARE, TX_QUEUESIZE=@TXQUEUESIZE,
                                                                   RX_QUEUESIZE=@RXQUEUESIZE, XON_LIM=@XONLIM,XOFF_LIM=@XOFFLIM,XON_CHAR=@XONCHAR,XOFF_CHAR=@XOFFCHAR,
                                                                   ERROR_CHAR=@ERRORCHAR,EVENT_CHAR=@EVENTCHAR,DRIVER_PROG=@DRIVERPROG,PRIORITY=@PRIORITY,ITEM_TYPE=@ITEMTYPE,AUTO_LOAD=@AUTOLOAD,
                                                                   START_DATE_TIME=@STARTDATETIME,DEFAULT_RECV_FREQUENCY=@DEFAULTRECVFREQUENCY,CURRENT_RECV_FREQUENCY=@CURRENTRECVFREQUENCY,
                                                                   CURRENT_RECVTIMES_UPLIMIT=@CURRENTRECVTIMESUPLIMIT,CURRENT_RECV_ITEMS=@CURRENTRECVITEMS,
                                                                   WARD_CODE=@WARDCODE,WARD_TYPE=@WARDTYPE, BED_NO=@BEDNO,PATIENT_ID=@PATIENTID,VISIT_ID=@VISITID,OPER_ID=@OPERID,
                                                                   USING_INDICATOR=@USINGINDICATOR,FREQUENCY_DISPLAY=@FREQUENCYDISPLAY,MEMO=@MEMO,DATALOG_START_TIME=@DATALOGSTARTTIME,
                                                                   PC_PORT=@PCPORT,DATALOG_STATUS=@DATALOGSTATUS,IP_PORT=@IPPORT,IN_PORT=@INPORT,OUT_PORT=@OUTPORT,BED_NO_BIND = @BEDNOBIND
                                                                   WHERE WARD_CODE =@WARDCODE AND BED_NO_BIND =@BEDNOBIND";
        private static readonly string MED_MONITOR_DICT_Delete_SQL = "Delete MED_MONITOR_DICT WHERE WARD_CODE=@WardCode AND Bed_No_Bind =@BedNoBind";
        private static readonly string MED_MONITOR_DICT_Select_One_SQL = "select count(1) from MED_MONITOR_DICT where patient_id =@patientID and visit_id =@visitID";
        private static readonly string MED_MONITOR_DICT_Select_One_With_Bed_No_SQL = "select count(1) from MED_MONITOR_DICT where patient_id =@patientID and visit_id =@visitID and WARD_CODE=@WardCode AND Bed_No_Bind =@BedNoBind";
        private static readonly string MED_MONITOR_DICT_Select_SQL = @"SELECT MONITOR_LABEL,MANU_FIRM_NAME,MODEL,INTERFACE_TYPE,INTERFACE_DESC,IP_ADDR,MAC_ADDR,LAST_RECV_TIME,LAST_RECV_BED_ID,
                                                                   DUPLEX_FLAG,AUTOIN_FLAG, COMM_PORT, BAUD_RATE, BYTE_SIZE, PARITY, STOP_BITS, F_OUTX,F_INX,F_HARDWARE, TX_QUEUESIZE,
                                                                   RX_QUEUESIZE, XON_LIM,XOFF_LIM,XON_CHAR,XOFF_CHAR,ERROR_CHAR,EVENT_CHAR,DRIVER_PROG,PRIORITY,ITEM_TYPE,AUTO_LOAD,
                                                                   START_DATE_TIME,DEFAULT_RECV_FREQUENCY,CURRENT_RECV_FREQUENCY,CURRENT_RECVTIMES_UPLIMIT,CURRENT_RECV_ITEMS,
                                                                   WARD_CODE,WARD_TYPE, BED_NO,PATIENT_ID,VISIT_ID,OPER_ID,USING_INDICATOR,FREQUENCY_DISPLAY,MEMO,DATALOG_START_TIME,
                                                                   PC_PORT,DATALOG_STATUS,IP_PORT,IN_PORT,OUT_PORT,BED_NO_BIND
                                                                   FROM MED_MONITOR_DICT WHERE WARD_CODE =@WardCode AND BED_NO_BIND =@BedNoBind";
        private static readonly string MED_MONITOR_DICT_Select_ALL_SQL = @"SELECT MONITOR_LABEL,MANU_FIRM_NAME,MODEL,INTERFACE_TYPE,INTERFACE_DESC,IP_ADDR,MAC_ADDR,LAST_RECV_TIME,LAST_RECV_BED_ID,
                                                                       DUPLEX_FLAG,AUTOIN_FLAG, COMM_PORT, BAUD_RATE, BYTE_SIZE, PARITY, STOP_BITS, F_OUTX,F_INX,F_HARDWARE, TX_QUEUESIZE,
                                                                       RX_QUEUESIZE, XON_LIM,XOFF_LIM,XON_CHAR,XOFF_CHAR,ERROR_CHAR,EVENT_CHAR,DRIVER_PROG,PRIORITY,ITEM_TYPE,AUTO_LOAD,
                                                                       START_DATE_TIME,DEFAULT_RECV_FREQUENCY,CURRENT_RECV_FREQUENCY,CURRENT_RECVTIMES_UPLIMIT,CURRENT_RECV_ITEMS,
                                                                       WARD_CODE,WARD_TYPE, BED_NO,PATIENT_ID,VISIT_ID,OPER_ID,USING_INDICATOR,FREQUENCY_DISPLAY,MEMO,DATALOG_START_TIME,
                                                                       PC_PORT,DATALOG_STATUS,IP_PORT,IN_PORT,OUT_PORT,BED_NO_BIND
                                                                       FROM MED_MONITOR_DICT";
        #endregion
        #region [获取参数]
        /// <summary>
        ///获取参数MedMonitorDict
        /// </summary>
        public static SqlParameter[] GetParameterSQL(string sqlParms)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedMonitorDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@monitorlabel",SqlDbType.VarChar),
							new SqlParameter("@manufirmname",SqlDbType.VarChar),
							new SqlParameter("@model",SqlDbType.VarChar),
							new SqlParameter("@interfacetype",SqlDbType.Decimal),
							new SqlParameter("@interfacedesc",SqlDbType.VarChar),
							new SqlParameter("@ipaddr",SqlDbType.VarChar),
							new SqlParameter("@macaddr",SqlDbType.VarChar),
							new SqlParameter("@lastrecvtime",SqlDbType.DateTime),
							new SqlParameter("@lastrecvbedid",SqlDbType.VarChar),
                            new SqlParameter("@duplexflag",SqlDbType.Decimal),
                            new SqlParameter("@autoinflag",SqlDbType.VarChar),
							new SqlParameter("@commport",SqlDbType.VarChar),
							new SqlParameter("@baudrate",SqlDbType.Decimal),
							new SqlParameter("@bytesize",SqlDbType.Decimal),
							new SqlParameter("@parity",SqlDbType.VarChar),
							new SqlParameter("@stopbits",SqlDbType.Decimal),
                            new SqlParameter("@foutx",SqlDbType.VarChar),
							new SqlParameter("@finx",SqlDbType.VarChar),
							new SqlParameter("@fhardware",SqlDbType.VarChar),
							new SqlParameter("@txqueuesize",SqlDbType.VarChar),
							new SqlParameter("@rxqueuesize",SqlDbType.VarChar),
							new SqlParameter("@xonlim",SqlDbType.VarChar),
							new SqlParameter("@xofflim",SqlDbType.VarChar),
							new SqlParameter("@xonchar",SqlDbType.VarChar),
							new SqlParameter("@xoffchar",SqlDbType.VarChar),
							new SqlParameter("@errorchar",SqlDbType.VarChar),
							new SqlParameter("@eventchar",SqlDbType.VarChar),
							new SqlParameter("@driverprog",SqlDbType.VarChar),
                            new SqlParameter("@priority",SqlDbType.Decimal),
							new SqlParameter("@itemtype",SqlDbType.VarChar),
							new SqlParameter("@autoload",SqlDbType.Decimal),
							new SqlParameter("@startdatetime",SqlDbType.DateTime),
							new SqlParameter("@defaultrecvfrequency",SqlDbType.Decimal),
							new SqlParameter("@currentrecvfrequency",SqlDbType.Decimal),
							new SqlParameter("@currentrecvtimesuplimit",SqlDbType.Decimal),
							new SqlParameter("@currentrecvitems",SqlDbType.VarChar),
							new SqlParameter("@wardcode",SqlDbType.VarChar),
							new SqlParameter("@wardtype",SqlDbType.Decimal),
							new SqlParameter("@bedno",SqlDbType.VarChar),
							new SqlParameter("@patientid",SqlDbType.VarChar),
                            new SqlParameter("@visitid",SqlDbType.Decimal),
							new SqlParameter("@operid",SqlDbType.Decimal),
							new SqlParameter("@usingindicator",SqlDbType.Decimal),
							new SqlParameter("@frequencydisplay",SqlDbType.Decimal),
							new SqlParameter("@memo",SqlDbType.VarChar),
							new SqlParameter("@datalogstarttime",SqlDbType.DateTime),
							new SqlParameter("@pcport",SqlDbType.Decimal),
							new SqlParameter("@datalogstatus",SqlDbType.VarChar),
							new SqlParameter("@ipport",SqlDbType.Decimal),
							new SqlParameter("@inport",SqlDbType.Decimal),
							new SqlParameter("@outport",SqlDbType.VarChar),
                            new SqlParameter("@bednobind",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedMonitorDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@MONITORLABEL",SqlDbType.VarChar),
							new SqlParameter("@MANUFIRMNAME",SqlDbType.VarChar),
							new SqlParameter("@MODEL",SqlDbType.VarChar),
							new SqlParameter("@INTERFACETYPE",SqlDbType.Decimal),
							new SqlParameter("@INTERFACEDESC",SqlDbType.VarChar),
							new SqlParameter("@IPADDR",SqlDbType.VarChar),
							new SqlParameter("@MACADDR",SqlDbType.VarChar),
							new SqlParameter("@LASTRECVTIME",SqlDbType.DateTime),
							new SqlParameter("@LASTRECVBEDID",SqlDbType.VarChar),
                            new SqlParameter("@DUPLEXFLAG",SqlDbType.Decimal),
                            new SqlParameter("@AUTOINFLAG",SqlDbType.VarChar),
							new SqlParameter("@COMMPORT",SqlDbType.VarChar),
							new SqlParameter("@BAUDRATE",SqlDbType.Decimal),
							new SqlParameter("@BYTESIZE",SqlDbType.Decimal),
							new SqlParameter("@PARITY",SqlDbType.VarChar),
							new SqlParameter("@STOPBITS",SqlDbType.Decimal),
                            new SqlParameter("@FOUTX",SqlDbType.VarChar),
							new SqlParameter("@FINX",SqlDbType.VarChar),
							new SqlParameter("@FHARDWARE",SqlDbType.VarChar),
							new SqlParameter("@TXQUEUESIZE",SqlDbType.VarChar),
							new SqlParameter("@RXQUEUESIZE",SqlDbType.VarChar),
							new SqlParameter("@XONLIM",SqlDbType.VarChar),
							new SqlParameter("@XOFFLIM",SqlDbType.VarChar),
							new SqlParameter("@XONCHAR",SqlDbType.VarChar),
							new SqlParameter("@XOFFCHAR",SqlDbType.VarChar),
							new SqlParameter("@ERRORCHAR",SqlDbType.VarChar),
							new SqlParameter("@EVENTCHAR",SqlDbType.VarChar),
							new SqlParameter("@DRIVERPROG",SqlDbType.VarChar),
                            new SqlParameter("@PRIORITY",SqlDbType.Decimal),
							new SqlParameter("@ITEMTYPE",SqlDbType.VarChar),
							new SqlParameter("@AUTOLOAD",SqlDbType.Decimal),
							new SqlParameter("@STARTDATETIME",SqlDbType.DateTime),
							new SqlParameter("@DEFAULTRECVFREQUENCY",SqlDbType.Decimal),
							new SqlParameter("@CURRENTRECVFREQUENCY",SqlDbType.Decimal),
							new SqlParameter("@CURRENTRECVTIMESUPLIMIT",SqlDbType.Decimal),
							new SqlParameter("@CURRENTRECVITEMS",SqlDbType.VarChar),
							new SqlParameter("@WARDCODE",SqlDbType.VarChar),
							new SqlParameter("@WARDTYPE",SqlDbType.Decimal),
							new SqlParameter("@BEDNO",SqlDbType.VarChar),
							new SqlParameter("@PATIENTID",SqlDbType.VarChar),
                            new SqlParameter("@VISITID",SqlDbType.Decimal),
							new SqlParameter("@OPERID",SqlDbType.Decimal),
							new SqlParameter("@USINGINDICATOR",SqlDbType.Decimal),
							new SqlParameter("@FREQUENCYDISPLAY",SqlDbType.Decimal),
							new SqlParameter("@MEMO",SqlDbType.VarChar),
							new SqlParameter("@DATALOGSTARTTIME",SqlDbType.DateTime),
							new SqlParameter("@PCPORT",SqlDbType.Decimal),
							new SqlParameter("@DATALOGSTATUS",SqlDbType.VarChar),
							new SqlParameter("@IPPORT",SqlDbType.Decimal),
							new SqlParameter("@INPORT",SqlDbType.Decimal),
							new SqlParameter("@OUTPORT",SqlDbType.VarChar),
                            new SqlParameter("@BEDNOBIND",SqlDbType.VarChar),
                            new SqlParameter("@WARDCODE",SqlDbType.VarChar),
                            new SqlParameter("@BEDNOBIND",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedMonitorDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@WardCode",SqlDbType.VarChar),
							new SqlParameter("@BedNoBind",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedMonitorDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@WardCode",SqlDbType.VarChar),
							new SqlParameter("@BedNoBind",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedMonitorDictLabel")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@WardCode",SqlDbType.VarChar),
							new SqlParameter("@BedLabel",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectOneMedMonitorDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@patientID",SqlDbType.VarChar),
                            new SqlParameter("@visitID",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectOneMedMonitorDictWithBedNo")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@patientID",SqlDbType.VarChar),
                            new SqlParameter("@visitID",SqlDbType.Decimal),
                            new SqlParameter("@WardCode",SqlDbType.VarChar),
                            new SqlParameter("@BedNoBind",SqlDbType.VarChar),
                    };
                }
                SqlHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedMonitorDict 
        ///Insert Table MED_MONITOR_DICT
        /// </summary>
        public int InsertMedMonitorDictSQL(MedMonitorDict model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedMonitorDict");
                if (model.MonitorLabel != null)
                    oneInert[0].Value = model.MonitorLabel;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.ManuFirmName != null)
                    oneInert[1].Value = model.ManuFirmName;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.Model != null)
                    oneInert[2].Value = model.Model;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.InterfaceType.ToString() != null)
                    oneInert[3].Value = model.InterfaceType;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.InterfaceDesc != null)
                    oneInert[4].Value = model.InterfaceDesc;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.IpAddr != null)
                    oneInert[5].Value = model.IpAddr;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.MacAddr != null)
                    oneInert[6].Value = model.MacAddr;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.LastRecvTime != null)
                    oneInert[7].Value = model.LastRecvTime;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.LastRecvBedId != null)
                    oneInert[8].Value = model.LastRecvBedId;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.DuplexFlag.ToString() != null)
                    oneInert[9].Value = model.DuplexFlag;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.AutoinFlag != null)
                    oneInert[10].Value = model.AutoinFlag;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.Commport.ToString() != null)
                    oneInert[11].Value = model.Commport;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.BaudRate.ToString() != null)
                    oneInert[12].Value = model.BaudRate;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.ByteSize.ToString() != null)
                    oneInert[13].Value = model.ByteSize;
                else
                    oneInert[13].Value = DBNull.Value;
                if (model.Parity.ToString() != null)
                    oneInert[14].Value = model.Parity;
                else
                    oneInert[14].Value = DBNull.Value;
                if (model.StopBits.ToString() != null)
                    oneInert[15].Value = model.StopBits;
                else
                    oneInert[15].Value = DBNull.Value;
                if (model.FOutx.ToString() != null)
                    oneInert[16].Value = model.FOutx;
                else
                    oneInert[16].Value = DBNull.Value;
                if (model.FInx.ToString() != null)
                    oneInert[17].Value = model.FInx;
                else
                    oneInert[17].Value = DBNull.Value;
                if (model.FHardware.ToString() != null)
                    oneInert[18].Value = model.FHardware;
                else
                    oneInert[18].Value = DBNull.Value;
                if (model.TxQueuesize.ToString() != null)
                    oneInert[19].Value = model.TxQueuesize;
                else
                    oneInert[19].Value = DBNull.Value;
                if (model.RxQueuesize.ToString() != null)
                    oneInert[20].Value = model.RxQueuesize;
                else
                    oneInert[20].Value = DBNull.Value;
                if (model.XonLim.ToString() != null)
                    oneInert[21].Value = model.XonLim;
                else
                    oneInert[21].Value = DBNull.Value;
                if (model.XoffLim.ToString() != null)
                    oneInert[22].Value = model.XoffLim;
                else
                    oneInert[22].Value = DBNull.Value;
                if (model.XonChar.ToString() != null)
                    oneInert[23].Value = model.XonChar;
                else
                    oneInert[23].Value = DBNull.Value;
                if (model.XoffChar.ToString() != null)
                    oneInert[24].Value = model.XoffChar;
                else
                    oneInert[24].Value = DBNull.Value;
                if (model.ErrorChar.ToString() != null)
                    oneInert[25].Value = model.ErrorChar;
                else
                    oneInert[25].Value = DBNull.Value;
                if (model.EventChar.ToString() != null)
                    oneInert[26].Value = model.EventChar;
                else
                    oneInert[26].Value = DBNull.Value;
                if (model.DriverProg.ToString() != null)
                    oneInert[27].Value = model.DriverProg;
                else
                    oneInert[27].Value = DBNull.Value;
                if (model.Priority.ToString() != null)
                    oneInert[28].Value = model.Priority;
                else
                    oneInert[28].Value = DBNull.Value;
                if (model.ItemType.ToString() != null)
                    oneInert[29].Value = model.ItemType;
                else
                    oneInert[29].Value = DBNull.Value;
                if (model.AutoLoad.ToString() != null)
                    oneInert[30].Value = model.AutoLoad;
                else
                    oneInert[30].Value = DBNull.Value;
                if (model.StartDateTime > DateTime.MinValue)
                    oneInert[31].Value = model.StartDateTime;
                else
                    oneInert[31].Value = DBNull.Value;
                if (model.DefaultRecvFrequency.ToString() != null)
                    oneInert[32].Value = model.DefaultRecvFrequency;
                else
                    oneInert[32].Value = DBNull.Value;
                if (model.CurrentRecvFrequency.ToString() != null)
                    oneInert[33].Value = model.CurrentRecvFrequency;
                else
                    oneInert[33].Value = DBNull.Value;
                if (model.CurrentRecvtimesUplimit.ToString() != null)
                    oneInert[34].Value = model.CurrentRecvtimesUplimit;
                else
                    oneInert[34].Value = DBNull.Value;
                if (model.CurrentRecviTems != null)
                    oneInert[35].Value = model.CurrentRecviTems;
                else
                    oneInert[35].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneInert[36].Value = model.WardCode;
                else
                    oneInert[36].Value = DBNull.Value;
                if (model.WardType.ToString() != null)
                    oneInert[37].Value = model.WardType;
                else
                    oneInert[37].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneInert[38].Value = model.BedNo;
                else
                    oneInert[38].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneInert[39].Value = model.PatientId;
                else
                    oneInert[39].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneInert[40].Value = model.VisitId;
                else
                    oneInert[40].Value = DBNull.Value;
                if (model.OperId.ToString() != null)
                    oneInert[41].Value = model.OperId;
                else
                    oneInert[41].Value = DBNull.Value;
                if (model.UsingIndicator.ToString() != null)
                    oneInert[42].Value = model.UsingIndicator;
                else
                    oneInert[42].Value = DBNull.Value;
                if (model.FrequencyDisplay.ToString() != null)
                    oneInert[43].Value = model.FrequencyDisplay;
                else
                    oneInert[43].Value = DBNull.Value;
                if (model.Memo != null)
                    oneInert[44].Value = model.Memo;
                else
                    oneInert[44].Value = DBNull.Value;
                if (model.DatalogStartTime != null)
                    oneInert[45].Value = model.DatalogStartTime;
                else
                    oneInert[45].Value = DBNull.Value;
                if (model.PcPort.ToString() != null)
                    oneInert[46].Value = model.PcPort;
                else
                    oneInert[46].Value = DBNull.Value;
                if (model.DatalogStatus != null)
                    oneInert[47].Value = model.DatalogStatus;
                else
                    oneInert[47].Value = DBNull.Value;
                if (model.IpPort.ToString() != null)
                    oneInert[48].Value = model.IpPort;
                else
                    oneInert[48].Value = DBNull.Value;
                if (model.InPort.ToString() != null)
                    oneInert[49].Value = model.InPort;
                else
                    oneInert[49].Value = DBNull.Value;
                if (model.OutPort.ToString() != null)
                    oneInert[50].Value = model.OutPort;
                else
                    oneInert[50].Value = DBNull.Value;
                if (model.BedNoBind != null)
                    oneInert[51].Value = model.BedNoBind;
                else
                    oneInert[51].Value = DBNull.Value;
                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_MONITOR_DICT_Insert_SQL, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedMonitorDict 
        ///Update Table     MED_MONITOR_DICT
        /// </summary>
        public int UpdateMedMonitorDictSQL(MedMonitorDict model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedMonitorDict");
                if (model.MonitorLabel != null)
                    oneUpdate[0].Value = model.MonitorLabel;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.ManuFirmName != null)
                    oneUpdate[1].Value = model.ManuFirmName;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.Model != null)
                    oneUpdate[2].Value = model.Model;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.InterfaceType != null)
                    oneUpdate[3].Value = model.InterfaceType;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.InterfaceDesc != null)
                    oneUpdate[4].Value = model.InterfaceDesc;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.IpAddr != null)
                    oneUpdate[5].Value = model.IpAddr;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.MacAddr != null)
                    oneUpdate[6].Value = model.MacAddr;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.LastRecvTime > DateTime.MinValue)
                    oneUpdate[7].Value = model.LastRecvTime;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.LastRecvBedId != null)
                    oneUpdate[8].Value = model.LastRecvBedId;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.DuplexFlag != null)
                    oneUpdate[9].Value = model.DuplexFlag;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.AutoinFlag != null)
                    oneUpdate[10].Value = model.AutoinFlag;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.Commport != null)
                    oneUpdate[11].Value = model.Commport;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.BaudRate != null)
                    oneUpdate[12].Value = model.BaudRate;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.ByteSize != null)
                    oneUpdate[13].Value = model.ByteSize;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (model.Parity != null)
                    oneUpdate[14].Value = model.Parity;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (model.StopBits != null)
                    oneUpdate[15].Value = model.StopBits;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (model.FOutx != null)
                    oneUpdate[16].Value = model.FOutx;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (model.FInx != null)
                    oneUpdate[17].Value = model.FInx;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (model.FHardware != null)
                    oneUpdate[18].Value = model.FHardware;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (model.TxQueuesize != null)
                    oneUpdate[19].Value = model.TxQueuesize;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (model.RxQueuesize != null)
                    oneUpdate[20].Value = model.RxQueuesize;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (model.XonLim != null)
                    oneUpdate[21].Value = model.XonLim;
                else
                    oneUpdate[21].Value = DBNull.Value;
                if (model.XoffLim != null)
                    oneUpdate[22].Value = model.XoffLim;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (model.XonChar != null)
                    oneUpdate[23].Value = model.XonChar;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (model.XoffChar != null)
                    oneUpdate[24].Value = model.XoffChar;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (model.ErrorChar != null)
                    oneUpdate[25].Value = model.ErrorChar;
                else
                    oneUpdate[25].Value = DBNull.Value;
                if (model.EventChar != null)
                    oneUpdate[26].Value = model.EventChar;
                else
                    oneUpdate[26].Value = DBNull.Value;
                if (model.DriverProg != null)
                    oneUpdate[27].Value = model.DriverProg;
                else
                    oneUpdate[27].Value = DBNull.Value;
                if (model.Priority != null)
                    oneUpdate[28].Value = model.Priority;
                else
                    oneUpdate[28].Value = DBNull.Value;
                if (model.ItemType != null)
                    oneUpdate[29].Value = model.ItemType;
                else
                    oneUpdate[29].Value = DBNull.Value;
                if (model.AutoLoad != null)
                    oneUpdate[30].Value = model.AutoLoad;
                else
                    oneUpdate[30].Value = DBNull.Value;
                if (model.StartDateTime > DateTime.MinValue)
                    oneUpdate[31].Value = model.StartDateTime;
                else
                    oneUpdate[31].Value = DBNull.Value;
                if (model.DefaultRecvFrequency != null)
                    oneUpdate[32].Value = model.DefaultRecvFrequency;
                else
                    oneUpdate[32].Value = DBNull.Value;
                if (model.CurrentRecvFrequency != null)
                    oneUpdate[33].Value = model.CurrentRecvFrequency;
                else
                    oneUpdate[33].Value = DBNull.Value;
                if (model.CurrentRecvtimesUplimit != null)
                    oneUpdate[34].Value = model.CurrentRecvtimesUplimit;
                else
                    oneUpdate[34].Value = DBNull.Value;
                if (model.CurrentRecviTems != null)
                    oneUpdate[35].Value = model.CurrentRecviTems;
                else
                    oneUpdate[35].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneUpdate[36].Value = model.WardCode;
                else
                    oneUpdate[36].Value = DBNull.Value;
                if (model.WardType != null)
                    oneUpdate[37].Value = model.WardType;
                else
                    oneUpdate[37].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneUpdate[38].Value = model.BedNo;
                else
                    oneUpdate[38].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneUpdate[39].Value = model.PatientId;
                else
                    oneUpdate[39].Value = DBNull.Value;
                if (model.VisitId != null)
                    oneUpdate[40].Value = model.VisitId;
                else
                    oneUpdate[40].Value = DBNull.Value;
                if (model.OperId != null)
                    oneUpdate[41].Value = model.OperId;
                else
                    oneUpdate[41].Value = DBNull.Value;
                if (model.UsingIndicator != null)
                    oneUpdate[42].Value = model.UsingIndicator;
                else
                    oneUpdate[42].Value = DBNull.Value;
                if (model.FrequencyDisplay != null)
                    oneUpdate[43].Value = model.FrequencyDisplay;
                else
                    oneUpdate[43].Value = DBNull.Value;
                if (model.Memo != null)
                    oneUpdate[44].Value = model.Memo;
                else
                    oneUpdate[44].Value = DBNull.Value;
                if (model.DatalogStartTime > DateTime.MinValue)
                    oneUpdate[45].Value = model.DatalogStartTime;
                else
                    oneUpdate[45].Value = DBNull.Value;
                if (model.PcPort != null)
                    oneUpdate[46].Value = model.PcPort;
                else
                    oneUpdate[46].Value = DBNull.Value;
                if (model.DatalogStatus != null)
                    oneUpdate[47].Value = model.DatalogStatus;
                else
                    oneUpdate[47].Value = DBNull.Value;
                if (model.IpPort != null)
                    oneUpdate[48].Value = model.IpPort;
                else
                    oneUpdate[48].Value = DBNull.Value;
                if (model.InPort != null)
                    oneUpdate[49].Value = model.InPort;
                else
                    oneUpdate[49].Value = DBNull.Value;
                if (model.OutPort != null)
                    oneUpdate[50].Value = model.OutPort;
                else
                    oneUpdate[50].Value = DBNull.Value;
                if (model.BedNoBind != null)
                    oneUpdate[51].Value = model.BedNoBind;
                else
                    oneUpdate[51].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneUpdate[52].Value = model.WardCode;
                else
                    oneUpdate[52].Value = DBNull.Value;
                if (model.BedNoBind != null)
                    oneUpdate[53].Value = model.BedNoBind;
                else
                    oneUpdate[53].Value = DBNull.Value;
                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_MONITOR_DICT_Update_SQL, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedMonitorDict 
        ///Delete Table MED_MONITOR_DICT by (string WARD_CODE,string BED_NO)
        /// </summary>
        public int DeleteMedMonitorDictSQL(string WARD_CODE, string BED_NO)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneDelete = GetParameterSQL("DeleteMedMonitorDict");
                if (WARD_CODE != null)
                    oneDelete[0].Value = WARD_CODE;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (BED_NO != null)
                    oneDelete[1].Value = BED_NO;
                else
                    oneDelete[1].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_MONITOR_DICT_Delete_SQL, oneDelete);
            }
        }
        #endregion
        #region  [根据科室和床位获取一条记录]
        /// <summary>
        ///Select    model  MedMonitorDict 
        ///select Table MED_MONITOR_DICT by (string WARD_CODE,string BED_NO)
        /// </summary>
        public MedMonitorDict SelectMedMonitorDictSQL(string WARD_CODE, string BED_NO)
        {
            MedMonitorDict model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedMonitorDict");
            parameterValues[0].Value = WARD_CODE;
            parameterValues[1].Value = BED_NO;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_MONITOR_DICT_Select_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedMonitorDict();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.MonitorLabel = oleReader["MONITOR_LABEL"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.ManuFirmName = oleReader["MANU_FIRM_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.Model = oleReader["MODEL"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.InterfaceType = decimal.Parse(oleReader["INTERFACE_TYPE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.InterfaceDesc = oleReader["INTERFACE_DESC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.IpAddr = oleReader["IP_ADDR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.MacAddr = oleReader["MAC_ADDR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.LastRecvTime = DateTime.Parse(oleReader["LAST_RECV_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.LastRecvBedId = oleReader["LAST_RECV_BED_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.DuplexFlag = decimal.Parse(oleReader["DUPLEX_FLAG"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.AutoinFlag = oleReader["AUTOIN_FLAG"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Commport = oleReader["COMM_PORT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.BaudRate = decimal.Parse(oleReader["BAUD_RATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.ByteSize = decimal.Parse(oleReader["BYTE_SIZE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Parity = decimal.Parse(oleReader["PARITY"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.StopBits = decimal.Parse(oleReader["STOP_BITS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.FOutx = decimal.Parse(oleReader["F_OUTX"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.FInx = decimal.Parse(oleReader["F_INX"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.FHardware = decimal.Parse(oleReader["F_HARDWARE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.TxQueuesize = decimal.Parse(oleReader["TX_QUEUESIZE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.RxQueuesize = decimal.Parse(oleReader["RX_QUEUESIZE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.XonLim = decimal.Parse(oleReader["XON_LIM"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.XoffLim = decimal.Parse(oleReader["XOFF_LIM"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.XonChar = oleReader["XON_CHAR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.XoffChar = oleReader["XOFF_CHAR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.ErrorChar = oleReader["ERROR_CHAR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.EventChar = oleReader["EVENT_CHAR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.DriverProg = oleReader["DRIVER_PROG"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.Priority = decimal.Parse(oleReader["PRIORITY"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.ItemType = oleReader["ITEM_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.AutoinFlag = oleReader["AUTO_LOAD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.StartDateTime = DateTime.Parse(oleReader["START_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.DefaultRecvFrequency = decimal.Parse(oleReader["DEFAULT_RECV_FREQUENCY"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.CurrentRecvFrequency = decimal.Parse(oleReader["CURRENT_RECV_FREQUENCY"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.CurrentRecvtimesUplimit = decimal.Parse(oleReader["CURRENT_RECVTIMES_UPLIMIT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(35))
                    {
                        model.CurrentRecviTems = oleReader["CURRENT_RECV_ITEMS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(36))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(37))
                    {
                        model.WardType = decimal.Parse(oleReader["WARD_TYPE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(38))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(39))
                    {
                        model.PatientId = oleReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(40))
                    {
                        model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(41))
                    {
                        model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(42))
                    {
                        model.UsingIndicator = decimal.Parse(oleReader["USING_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(43))
                    {
                        model.FrequencyDisplay = decimal.Parse(oleReader["FREQUENCY_DISPLAY"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(44))
                    {
                        model.Memo = oleReader["MEMO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(45))
                    {
                        model.DatalogStartTime = DateTime.Parse(oleReader["DATALOG_START_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(46))
                    {
                        model.PcPort = decimal.Parse(oleReader["PC_PORT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(47))
                    {
                        model.DatalogStatus = oleReader["DATALOG_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(48))
                    {
                        model.IpPort = decimal.Parse(oleReader["IP_PORT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(49))
                    {
                        model.InPort = decimal.Parse(oleReader["IN_PORT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(50))
                    {
                        model.OutPort = decimal.Parse(oleReader["OUT_PORT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(51))
                    {
                        model.BedNoBind = oleReader["BED_NO_BIND"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion
        #region [查询病人记录是否存在]
        public int SelectOneMedMonitorDictSQL(string patientID, decimal visitID)
        {
            SqlParameter[] parms = GetParameterSQL("SelectOneMedMonitorDict");
            parms[0].Value = patientID;
            parms[1].Value = visitID;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_MONITOR_DICT_Select_One_SQL, parms))
            {
                if (oleReader.Read())
                {
                    return (int)oleReader.GetDecimal(0);
                }
                else
                {
                    return 0;
                }
            }
        }
        #endregion

        #region [查询病人记录是否存在WithBedNo]
        public int SelectOneMedMonitorDictWithBedNoSQL(string patientID, decimal visitID, string WardCode, string BedNo)
        {
            SqlParameter[] parms = GetParameterSQL("SelectOneMedMonitorDictWithBedNo");
            parms[0].Value = patientID;
            parms[1].Value = visitID;
            parms[2].Value = WardCode;
            parms[3].Value = BedNo;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_MONITOR_DICT_Select_One_With_Bed_No_SQL, parms))
            {
                if (oleReader.Read())
                {
                    return (int)oleReader.GetDecimal(0);
                }
                else
                {
                    return 0;
                }
            }
        }
        #endregion
        #region  [获取所有记录]
        /// <summary>
        ///获取所有记录
        /// </summary>
        //public List<MedMonitorDict> SelectMedMonitorDictList()
        //{
        //    List<MedMonitorDict> modelList = new List<MedMonitorDict>();
        //    using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_MONITOR_DICT_Select_ALL, null))
        //    {
        //        while (oleReader.Read())
        //        {
        //            MedMonitorDict model = new MedMonitorDict();
        //            if (!oleReader.IsDBNull(0))
        //            {
        //                model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
        //            }
        //            if (!oleReader.IsDBNull(1))
        //            {
        //                model.BedNo = oleReader["BED_NO"].ToString().Trim();
        //            }
        //            if (!oleReader.IsDBNull(2))
        //            {
        //                model.BedLabel = oleReader["BED_LABEL"].ToString().Trim();
        //            }
        //            if (!oleReader.IsDBNull(3))
        //            {
        //                model.RoomNo = oleReader["ROOM_NO"].ToString().Trim();
        //            }
        //            if (!oleReader.IsDBNull(4))
        //            {
        //                model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
        //            }
        //            if (!oleReader.IsDBNull(5))
        //            {
        //                model.BedApprovedType = oleReader["BED_APPROVED_TYPE"].ToString().Trim();
        //            }
        //            if (!oleReader.IsDBNull(6))
        //            {
        //                model.BedSexType = oleReader["BED_SEX_TYPE"].ToString().Trim();
        //            }
        //            if (!oleReader.IsDBNull(7))
        //            {
        //                model.BedClass = oleReader["BED_CLASS"].ToString().Trim();
        //            }
        //            if (!oleReader.IsDBNull(8))
        //            {
        //                model.BedStatus = oleReader["BED_STATUS"].ToString().Trim();
        //            }
        //            if (!oleReader.IsDBNull(9))
        //            {
        //                model.IcuIndicator = decimal.Parse(oleReader["ICU_INDICATOR"].ToString().Trim());
        //            }
        //            if (!oleReader.IsDBNull(10))
        //            {
        //                model.MonitorLabel = oleReader["MONITOR_LABEL"].ToString().Trim();
        //            }
        //            if (!oleReader.IsDBNull(11))
        //            {
        //                model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
        //            }
        //            modelList.Add(model);
        //        }
        //    }
        //    return modelList;
        //}
        #endregion

    }
}
