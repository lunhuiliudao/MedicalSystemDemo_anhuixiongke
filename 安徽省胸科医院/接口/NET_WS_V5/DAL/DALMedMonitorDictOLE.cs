

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

        #region OleDB
        private static readonly string MED_MONITOR_DICT_Insert_OLE = @"INSERT INTO MED_MONITOR_DICT(MONITOR_LABEL,MANU_FIRM_NAME,MODEL,INTERFACE_TYPE,INTERFACE_DESC,IP_ADDR,MAC_ADDR,LAST_RECV_TIME,LAST_RECV_BED_ID,
                                                                   DUPLEX_FLAG,AUTOIN_FLAG, COMM_PORT, BAUD_RATE, BYTE_SIZE, PARITY, STOP_BITS, F_OUTX,F_INX,F_HARDWARE, TX_QUEUESIZE,
                                                                   RX_QUEUESIZE, XON_LIM,XOFF_LIM,XON_CHAR,XOFF_CHAR,ERROR_CHAR,EVENT_CHAR,DRIVER_PROG,PRIORITY,ITEM_TYPE,AUTO_LOAD,
                                                                   START_DATE_TIME,DEFAULT_RECV_FREQUENCY,CURRENT_RECV_FREQUENCY,CURRENT_RECVTIMES_UPLIMIT,CURRENT_RECV_ITEMS,
                                                                   WARD_CODE,WARD_TYPE, BED_NO,PATIENT_ID,VISIT_ID,OPER_ID,USING_INDICATOR,FREQUENCY_DISPLAY,MEMO,DATALOG_START_TIME,
                                                                   PC_PORT,DATALOG_STATUS,IP_PORT,IN_PORT,OUT_PORT,BED_NO_BIND)
                                                                   VALUES(?,?,?,?,?,?,?,?,?,?,?, ?, ?, ?, ?, ?, ?,?,?, ?,?, ?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
        private static readonly string MED_MONITOR_DICT_Update_OLE = @"UPDATE MED_MONITOR_DICT
                                                                   SET MONITOR_LABEL=?,MANU_FIRM_NAME =?,MODEL =?,INTERFACE_TYPE=?,INTERFACE_DESC=?,
                                                                   IP_ADDR=?,MAC_ADDR=?,LAST_RECV_TIME=?,LAST_RECV_BED_ID=?,
                                                                   DUPLEX_FLAG=?,AUTOIN_FLAG=?, COMM_PORT=?, BAUD_RATE=?, BYTE_SIZE=?, 
                                                                   PARITY=?, STOP_BITS=?, F_OUTX=?,F_INX=?,F_HARDWARE=?, TX_QUEUESIZE=?,
                                                                   RX_QUEUESIZE=?, XON_LIM=?,XOFF_LIM=?,XON_CHAR=?,XOFF_CHAR=?,
                                                                   ERROR_CHAR=?,EVENT_CHAR=?,DRIVER_PROG=?,PRIORITY=?,ITEM_TYPE=?,AUTO_LOAD=?,
                                                                   START_DATE_TIME=?,DEFAULT_RECV_FREQUENCY=?,CURRENT_RECV_FREQUENCY=?,
                                                                   CURRENT_RECVTIMES_UPLIMIT=?,CURRENT_RECV_ITEMS=?,
                                                                   WARD_CODE=?,WARD_TYPE=?, BED_NO=?,PATIENT_ID=?,VISIT_ID=?,OPER_ID=?,
                                                                   USING_INDICATOR=?,FREQUENCY_DISPLAY=?,MEMO=?,DATALOG_START_TIME=?,
                                                                   PC_PORT=?,DATALOG_STATUS=?,IP_PORT=?,IN_PORT=?,OUT_PORT=?,BED_NO_BIND = ?
                                                                   WHERE WARD_CODE =? AND BED_NO_BIND =?";
        private static readonly string MED_MONITOR_DICT_Delete_OLE = "Delete MED_MONITOR_DICT WHERE WARD_CODE=? AND Bed_No_Bind =?";
        private static readonly string MED_MONITOR_DICT_Select_One_OLE = "select count(1) from MED_MONITOR_DICT where patient_id =? and visit_id =?";
        private static readonly string MED_MONITOR_DICT_Select_One_With_Bed_No_OLE = "select count(1) from MED_MONITOR_DICT where patient_id =? and visit_id =? and WARD_CODE=? AND Bed_No_Bind =?";
        private static readonly string MED_MONITOR_DICT_Select_OLE = @"SELECT MONITOR_LABEL,MANU_FIRM_NAME,MODEL,INTERFACE_TYPE,INTERFACE_DESC,IP_ADDR,MAC_ADDR,LAST_RECV_TIME,LAST_RECV_BED_ID,
                                                                   DUPLEX_FLAG,AUTOIN_FLAG, COMM_PORT, BAUD_RATE, BYTE_SIZE, PARITY, STOP_BITS, F_OUTX,F_INX,F_HARDWARE, TX_QUEUESIZE,
                                                                   RX_QUEUESIZE, XON_LIM,XOFF_LIM,XON_CHAR,XOFF_CHAR,ERROR_CHAR,EVENT_CHAR,DRIVER_PROG,PRIORITY,ITEM_TYPE,AUTO_LOAD,
                                                                   START_DATE_TIME,DEFAULT_RECV_FREQUENCY,CURRENT_RECV_FREQUENCY,CURRENT_RECVTIMES_UPLIMIT,CURRENT_RECV_ITEMS,
                                                                   WARD_CODE,WARD_TYPE, BED_NO,PATIENT_ID,VISIT_ID,OPER_ID,USING_INDICATOR,FREQUENCY_DISPLAY,MEMO,DATALOG_START_TIME,
                                                                   PC_PORT,DATALOG_STATUS,IP_PORT,IN_PORT,OUT_PORT,BED_NO_BIND
                                                                   FROM MED_MONITOR_DICT WHERE WARD_CODE =? AND BED_NO_BIND =?";
        private static readonly string MED_MONITOR_DICT_Select_ALL_OLE = @"SELECT MONITOR_LABEL,MANU_FIRM_NAME,MODEL,INTERFACE_TYPE,INTERFACE_DESC,IP_ADDR,MAC_ADDR,LAST_RECV_TIME,LAST_RECV_BED_ID,
                                                                       DUPLEX_FLAG,AUTOIN_FLAG, COMM_PORT, BAUD_RATE, BYTE_SIZE, PARITY, STOP_BITS, F_OUTX,F_INX,F_HARDWARE, TX_QUEUESIZE,
                                                                       RX_QUEUESIZE, XON_LIM,XOFF_LIM,XON_CHAR,XOFF_CHAR,ERROR_CHAR,EVENT_CHAR,DRIVER_PROG,PRIORITY,ITEM_TYPE,AUTO_LOAD,
                                                                       START_DATE_TIME,DEFAULT_RECV_FREQUENCY,CURRENT_RECV_FREQUENCY,CURRENT_RECVTIMES_UPLIMIT,CURRENT_RECV_ITEMS,
                                                                       WARD_CODE,WARD_TYPE, BED_NO,PATIENT_ID,VISIT_ID,OPER_ID,USING_INDICATOR,FREQUENCY_DISPLAY,MEMO,DATALOG_START_TIME,
                                                                       PC_PORT,DATALOG_STATUS,IP_PORT,IN_PORT,OUT_PORT,BED_NO_BIND
                                                                       FROM MED_MONITOR_DICT";
        #endregion
        #region [获取参数OLEDB]
        /// <summary>
        ///获取参数MedMonitorDict
        /// </summary>
        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedMonitorDict")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("monitorlabel",OleDbType.VarChar),
							new OleDbParameter("manufirmname",OleDbType.VarChar),
							new OleDbParameter("model",OleDbType.VarChar),
							new OleDbParameter("interfacetype",OleDbType.Decimal),
							new OleDbParameter("interfacedesc",OleDbType.VarChar),
							new OleDbParameter("ipaddr",OleDbType.VarChar),
							new OleDbParameter("macaddr",OleDbType.VarChar),
							new OleDbParameter("lastrecvtime",OleDbType.DBTimeStamp),
							new OleDbParameter("lastrecvbedid",OleDbType.VarChar),
                            new OleDbParameter("duplexflag",OleDbType.Decimal),
                            new OleDbParameter("autoinflag",OleDbType.VarChar),
							new OleDbParameter("commport",OleDbType.VarChar),
							new OleDbParameter("baudrate",OleDbType.Decimal),
							new OleDbParameter("bytesize",OleDbType.Decimal),
							new OleDbParameter("parity",OleDbType.VarChar),
							new OleDbParameter("stopbits",OleDbType.Decimal),
                            new OleDbParameter("foutx",OleDbType.VarChar),
							new OleDbParameter("finx",OleDbType.VarChar),
							new OleDbParameter("fhardware",OleDbType.VarChar),
							new OleDbParameter("txqueuesize",OleDbType.VarChar),
							new OleDbParameter("rxqueuesize",OleDbType.VarChar),
							new OleDbParameter("xonlim",OleDbType.VarChar),
							new OleDbParameter("xofflim",OleDbType.VarChar),
							new OleDbParameter("xonchar",OleDbType.VarChar),
							new OleDbParameter("xoffchar",OleDbType.VarChar),
							new OleDbParameter("errorchar",OleDbType.VarChar),
							new OleDbParameter("eventchar",OleDbType.VarChar),
							new OleDbParameter("driverprog",OleDbType.VarChar),
                            new OleDbParameter("priority",OleDbType.Decimal),
							new OleDbParameter("itemtype",OleDbType.VarChar),
							new OleDbParameter("autoload",OleDbType.Decimal),
							new OleDbParameter("startdatetime",OleDbType.DBTimeStamp),
							new OleDbParameter("defaultrecvfrequency",OleDbType.Decimal),
							new OleDbParameter("currentrecvfrequency",OleDbType.Decimal),
							new OleDbParameter("currentrecvtimesuplimit",OleDbType.Decimal),
							new OleDbParameter("currentrecvitems",OleDbType.VarChar),
							new OleDbParameter("wardcode",OleDbType.VarChar),
							new OleDbParameter("wardtype",OleDbType.Decimal),
							new OleDbParameter("bedno",OleDbType.VarChar),
							new OleDbParameter("patientid",OleDbType.VarChar),
                            new OleDbParameter("visitid",OleDbType.Decimal),
							new OleDbParameter("operid",OleDbType.Decimal),
							new OleDbParameter("usingindicator",OleDbType.Decimal),
							new OleDbParameter("frequencydisplay",OleDbType.Decimal),
							new OleDbParameter("memo",OleDbType.VarChar),
							new OleDbParameter("datalogstarttime",OleDbType.DBTimeStamp),
							new OleDbParameter("pcport",OleDbType.Decimal),
							new OleDbParameter("datalogstatus",OleDbType.VarChar),
							new OleDbParameter("ipport",OleDbType.Decimal),
							new OleDbParameter("inport",OleDbType.Decimal),
							new OleDbParameter("outport",OleDbType.VarChar),
                            new OleDbParameter("bednobind",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedMonitorDict")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("monitorlabel",OleDbType.VarChar),
							new OleDbParameter("manufirmname",OleDbType.VarChar),
							new OleDbParameter("model",OleDbType.VarChar),
							new OleDbParameter("interfacetype",OleDbType.Decimal),
							new OleDbParameter("interfacedesc",OleDbType.VarChar),
							new OleDbParameter("ipaddr",OleDbType.VarChar),
							new OleDbParameter("macaddr",OleDbType.VarChar),
							new OleDbParameter("lastrecvtime",OleDbType.DBTimeStamp),
							new OleDbParameter("lastrecvbedid",OleDbType.VarChar),
                            new OleDbParameter("duplexflag",OleDbType.Decimal),
                            new OleDbParameter("autoinflag",OleDbType.VarChar),
							new OleDbParameter("commport",OleDbType.VarChar),
							new OleDbParameter("baudrate",OleDbType.Decimal),
							new OleDbParameter("bytesize",OleDbType.Decimal),
							new OleDbParameter("parity",OleDbType.VarChar),
							new OleDbParameter("stopbits",OleDbType.Decimal),
                            new OleDbParameter("foutx",OleDbType.VarChar),
							new OleDbParameter("finx",OleDbType.VarChar),
							new OleDbParameter("fhardware",OleDbType.VarChar),
							new OleDbParameter("txqueuesize",OleDbType.VarChar),
							new OleDbParameter("rxqueuesize",OleDbType.VarChar),
							new OleDbParameter("xonlim",OleDbType.VarChar),
							new OleDbParameter("xofflim",OleDbType.VarChar),
							new OleDbParameter("xonchar",OleDbType.VarChar),
							new OleDbParameter("xoffchar",OleDbType.VarChar),
							new OleDbParameter("errorchar",OleDbType.VarChar),
							new OleDbParameter("eventchar",OleDbType.VarChar),
							new OleDbParameter("driverprog",OleDbType.VarChar),
                            new OleDbParameter("priority",OleDbType.Decimal),
							new OleDbParameter("itemtype",OleDbType.VarChar),
							new OleDbParameter("autoload",OleDbType.Decimal),
							new OleDbParameter("startdatetime",OleDbType.DBTimeStamp),
							new OleDbParameter("defaultrecvfrequency",OleDbType.Decimal),
							new OleDbParameter("currentrecvfrequency",OleDbType.Decimal),
							new OleDbParameter("currentrecvtimesuplimit",OleDbType.Decimal),
							new OleDbParameter("currentrecvitems",OleDbType.VarChar),
							new OleDbParameter("wardcode",OleDbType.VarChar),
							new OleDbParameter("wardtype",OleDbType.Decimal),
							new OleDbParameter("bedno",OleDbType.VarChar),
							new OleDbParameter("patientid",OleDbType.VarChar),
                            new OleDbParameter("visitid",OleDbType.Decimal),
							new OleDbParameter("operid",OleDbType.Decimal),
							new OleDbParameter("usingindicator",OleDbType.Decimal),
							new OleDbParameter("frequencydisplay",OleDbType.Decimal),
							new OleDbParameter("memo",OleDbType.VarChar),
							new OleDbParameter("datalogstarttime",OleDbType.DBTimeStamp),
							new OleDbParameter("pcport",OleDbType.Decimal),
							new OleDbParameter("datalogstatus",OleDbType.VarChar),
							new OleDbParameter("ipport",OleDbType.Decimal),
							new OleDbParameter("inport",OleDbType.Decimal),
							new OleDbParameter("outport",OleDbType.VarChar),
                            new OleDbParameter("bednobind",OleDbType.VarChar),
                            new OleDbParameter("WARDCODE",OleDbType.VarChar),
                            new OleDbParameter("BEDNOBIND",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedMonitorDict")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("WardCode",OleDbType.VarChar),
							new OleDbParameter("BedNoBind",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedMonitorDict")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("WardCode",OleDbType.VarChar),
							new OleDbParameter("BedNoBind",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedMonitorDictLabel")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("WardCode",OleDbType.VarChar),
							new OleDbParameter("BedLabel",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectOneMedMonitorDict")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("patientID",OleDbType.VarChar),
                            new OleDbParameter("visitID",OleDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectOneMedMonitorDictWithBedNo")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("patientID",OleDbType.VarChar),
                            new OleDbParameter("visitID",OleDbType.Decimal),
                            new OleDbParameter("WardCode",OleDbType.VarChar),
                            new OleDbParameter("BedNoBind",OleDbType.VarChar),
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedMonitorDict 
        ///Insert Table MED_MONITOR_DICT
        /// </summary>
        public int InsertMedMonitorDictOLE(MedMonitorDict model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedMonitorDict");
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
                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, MED_MONITOR_DICT_Insert_OLE, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedMonitorDict 
        ///Update Table     MED_MONITOR_DICT
        /// </summary>
        public int UpdateMedMonitorDictOLE(MedMonitorDict model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedMonitorDict");
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
                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, MED_MONITOR_DICT_Update_OLE, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedMonitorDict 
        ///Delete Table MED_MONITOR_DICT by (string WARD_CODE,string BED_NO)
        /// </summary>
        public int DeleteMedMonitorDictOLE(string WARD_CODE, string BED_NO)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneDelete = GetParameterOLE("DeleteMedMonitorDict");
                if (WARD_CODE != null)
                    oneDelete[0].Value = WARD_CODE;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (BED_NO != null)
                    oneDelete[1].Value = BED_NO;
                else
                    oneDelete[1].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, MED_MONITOR_DICT_Delete_OLE, oneDelete);
            }
        }
        #endregion
        #region  [根据科室和床位获取一条记录]
        /// <summary>
        ///Select    model  MedMonitorDict 
        ///select Table MED_MONITOR_DICT by (string WARD_CODE,string BED_NO)
        /// </summary>
        public MedMonitorDict SelectMedMonitorDictOLE(string WARD_CODE, string BED_NO)
        {
            MedMonitorDict model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedMonitorDict");
            parameterValues[0].Value = WARD_CODE;
            parameterValues[1].Value = BED_NO;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_MONITOR_DICT_Select_OLE, parameterValues))
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
        public int SelectOneMedMonitorDictOLE(string patientID, decimal visitID)
        {
            OleDbParameter[] parms = GetParameterOLE("SelectOneMedMonitorDict");
            parms[0].Value = patientID;
            parms[1].Value = visitID;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_MONITOR_DICT_Select_One_OLE, parms))
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
        public int SelectOneMedMonitorDictWithBedNoOLE(string patientID, decimal visitID, string WardCode, string BedNo)
        {
            OleDbParameter[] parms = GetParameterOLE("SelectOneMedMonitorDictWithBedNo");
            parms[0].Value = patientID;
            parms[1].Value = visitID;
            parms[2].Value = WardCode;
            parms[3].Value = BedNo;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_MONITOR_DICT_Select_One_With_Bed_No_OLE, parms))
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

        #region ODBC
        private static readonly string MED_MONITOR_DICT_Insert_ODBC = @"INSERT INTO MED_MONITOR_DICT(MONITOR_LABEL,MANU_FIRM_NAME,MODEL,INTERFACE_TYPE,INTERFACE_DESC,IP_ADDR,MAC_ADDR,LAST_RECV_TIME,LAST_RECV_BED_ID,
                                                                   DUPLEX_FLAG,AUTOIN_FLAG, COMM_PORT, BAUD_RATE, BYTE_SIZE, PARITY, STOP_BITS, F_OUTX,F_INX,F_HARDWARE, TX_QUEUESIZE,
                                                                   RX_QUEUESIZE, XON_LIM,XOFF_LIM,XON_CHAR,XOFF_CHAR,ERROR_CHAR,EVENT_CHAR,DRIVER_PROG,PRIORITY,ITEM_TYPE,AUTO_LOAD,
                                                                   START_DATE_TIME,DEFAULT_RECV_FREQUENCY,CURRENT_RECV_FREQUENCY,CURRENT_RECVTIMES_UPLIMIT,CURRENT_RECV_ITEMS,
                                                                   WARD_CODE,WARD_TYPE, BED_NO,PATIENT_ID,VISIT_ID,OPER_ID,USING_INDICATOR,FREQUENCY_DISPLAY,MEMO,DATALOG_START_TIME,
                                                                   PC_PORT,DATALOG_STATUS,IP_PORT,IN_PORT,OUT_PORT,BED_NO_BIND)
                                                                   VALUES(?,?,?,?,?,?,?,?,?,?,?, ?, ?, ?, ?, ?, ?,?,?, ?,?, ?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
        private static readonly string MED_MONITOR_DICT_Update_ODBC = @"UPDATE MED_MONITOR_DICT
                                                                   SET MONITOR_LABEL=?,MANU_FIRM_NAME =?,MODEL =?,INTERFACE_TYPE=?,INTERFACE_DESC=?,
                                                                   IP_ADDR=?,MAC_ADDR=?,LAST_RECV_TIME=?,LAST_RECV_BED_ID=?,
                                                                   DUPLEX_FLAG=?,AUTOIN_FLAG=?, COMM_PORT=?, BAUD_RATE=?, BYTE_SIZE=?, 
                                                                   PARITY=?, STOP_BITS=?, F_OUTX=?,F_INX=?,F_HARDWARE=?, TX_QUEUESIZE=?,
                                                                   RX_QUEUESIZE=?, XON_LIM=?,XOFF_LIM=?,XON_CHAR=?,XOFF_CHAR=?,
                                                                   ERROR_CHAR=?,EVENT_CHAR=?,DRIVER_PROG=?,PRIORITY=?,ITEM_TYPE=?,AUTO_LOAD=?,
                                                                   START_DATE_TIME=?,DEFAULT_RECV_FREQUENCY=?,CURRENT_RECV_FREQUENCY=?,
                                                                   CURRENT_RECVTIMES_UPLIMIT=?,CURRENT_RECV_ITEMS=?,
                                                                   WARD_CODE=?,WARD_TYPE=?, BED_NO=?,PATIENT_ID=?,VISIT_ID=?,OPER_ID=?,
                                                                   USING_INDICATOR=?,FREQUENCY_DISPLAY=?,MEMO=?,DATALOG_START_TIME=?,
                                                                   PC_PORT=?,DATALOG_STATUS=?,IP_PORT=?,IN_PORT=?,OUT_PORT=?,BED_NO_BIND = ?
                                                                   WHERE WARD_CODE =? AND BED_NO_BIND =?";
        private static readonly string MED_MONITOR_DICT_Delete_ODBC = "Delete MED_MONITOR_DICT WHERE WARD_CODE=? AND Bed_No_Bind =?";
        private static readonly string MED_MONITOR_DICT_Select_One_ODBC = "select count(1) from MED_MONITOR_DICT where patient_id =? and visit_id =?";
        private static readonly string MED_MONITOR_DICT_Select_One_With_Bed_No_ODBC = "select count(1) from MED_MONITOR_DICT where patient_id =? and visit_id =? and WARD_CODE=? AND Bed_No_Bind =?";
        private static readonly string MED_MONITOR_DICT_Select_ODBC = @"SELECT MONITOR_LABEL,MANU_FIRM_NAME,MODEL,INTERFACE_TYPE,INTERFACE_DESC,IP_ADDR,MAC_ADDR,LAST_RECV_TIME,LAST_RECV_BED_ID,
                                                                   DUPLEX_FLAG,AUTOIN_FLAG, COMM_PORT, BAUD_RATE, BYTE_SIZE, PARITY, STOP_BITS, F_OUTX,F_INX,F_HARDWARE, TX_QUEUESIZE,
                                                                   RX_QUEUESIZE, XON_LIM,XOFF_LIM,XON_CHAR,XOFF_CHAR,ERROR_CHAR,EVENT_CHAR,DRIVER_PROG,PRIORITY,ITEM_TYPE,AUTO_LOAD,
                                                                   START_DATE_TIME,DEFAULT_RECV_FREQUENCY,CURRENT_RECV_FREQUENCY,CURRENT_RECVTIMES_UPLIMIT,CURRENT_RECV_ITEMS,
                                                                   WARD_CODE,WARD_TYPE, BED_NO,PATIENT_ID,VISIT_ID,OPER_ID,USING_INDICATOR,FREQUENCY_DISPLAY,MEMO,DATALOG_START_TIME,
                                                                   PC_PORT,DATALOG_STATUS,IP_PORT,IN_PORT,OUT_PORT,BED_NO_BIND
                                                                   FROM MED_MONITOR_DICT WHERE WARD_CODE =? AND BED_NO_BIND =?";
        private static readonly string MED_MONITOR_DICT_Select_ALL_ODBC = @"SELECT MONITOR_LABEL,MANU_FIRM_NAME,MODEL,INTERFACE_TYPE,INTERFACE_DESC,IP_ADDR,MAC_ADDR,LAST_RECV_TIME,LAST_RECV_BED_ID,
                                                                       DUPLEX_FLAG,AUTOIN_FLAG, COMM_PORT, BAUD_RATE, BYTE_SIZE, PARITY, STOP_BITS, F_OUTX,F_INX,F_HARDWARE, TX_QUEUESIZE,
                                                                       RX_QUEUESIZE, XON_LIM,XOFF_LIM,XON_CHAR,XOFF_CHAR,ERROR_CHAR,EVENT_CHAR,DRIVER_PROG,PRIORITY,ITEM_TYPE,AUTO_LOAD,
                                                                       START_DATE_TIME,DEFAULT_RECV_FREQUENCY,CURRENT_RECV_FREQUENCY,CURRENT_RECVTIMES_UPLIMIT,CURRENT_RECV_ITEMS,
                                                                       WARD_CODE,WARD_TYPE, BED_NO,PATIENT_ID,VISIT_ID,OPER_ID,USING_INDICATOR,FREQUENCY_DISPLAY,MEMO,DATALOG_START_TIME,
                                                                       PC_PORT,DATALOG_STATUS,IP_PORT,IN_PORT,OUT_PORT,BED_NO_BIND
                                                                       FROM MED_MONITOR_DICT";
        #endregion
        #region [获取参数ODBC]
        /// <summary>
        ///获取参数MedMonitorDict
        /// </summary>
        public static OdbcParameter[] GetParameterODBC(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedMonitorDict")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("monitorlabel",OdbcType.VarChar),
							new OdbcParameter("manufirmname",OdbcType.VarChar),
							new OdbcParameter("model",OdbcType.VarChar),
							new OdbcParameter("interfacetype",OdbcType.Decimal),
							new OdbcParameter("interfacedesc",OdbcType.VarChar),
							new OdbcParameter("ipaddr",OdbcType.VarChar),
							new OdbcParameter("macaddr",OdbcType.VarChar),
							new OdbcParameter("lastrecvtime",OdbcType.DateTime),
							new OdbcParameter("lastrecvbedid",OdbcType.VarChar),
                            new OdbcParameter("duplexflag",OdbcType.Decimal),
                            new OdbcParameter("autoinflag",OdbcType.VarChar),
							new OdbcParameter("commport",OdbcType.VarChar),
							new OdbcParameter("baudrate",OdbcType.Decimal),
							new OdbcParameter("bytesize",OdbcType.Decimal),
							new OdbcParameter("parity",OdbcType.VarChar),
							new OdbcParameter("stopbits",OdbcType.Decimal),
                            new OdbcParameter("foutx",OdbcType.VarChar),
							new OdbcParameter("finx",OdbcType.VarChar),
							new OdbcParameter("fhardware",OdbcType.VarChar),
							new OdbcParameter("txqueuesize",OdbcType.VarChar),
							new OdbcParameter("rxqueuesize",OdbcType.VarChar),
							new OdbcParameter("xonlim",OdbcType.VarChar),
							new OdbcParameter("xofflim",OdbcType.VarChar),
							new OdbcParameter("xonchar",OdbcType.VarChar),
							new OdbcParameter("xoffchar",OdbcType.VarChar),
							new OdbcParameter("errorchar",OdbcType.VarChar),
							new OdbcParameter("eventchar",OdbcType.VarChar),
							new OdbcParameter("driverprog",OdbcType.VarChar),
                            new OdbcParameter("priority",OdbcType.Decimal),
							new OdbcParameter("itemtype",OdbcType.VarChar),
							new OdbcParameter("autoload",OdbcType.Decimal),
							new OdbcParameter("startdatetime",OdbcType.DateTime),
							new OdbcParameter("defaultrecvfrequency",OdbcType.Decimal),
							new OdbcParameter("currentrecvfrequency",OdbcType.Decimal),
							new OdbcParameter("currentrecvtimesuplimit",OdbcType.Decimal),
							new OdbcParameter("currentrecvitems",OdbcType.VarChar),
							new OdbcParameter("wardcode",OdbcType.VarChar),
							new OdbcParameter("wardtype",OdbcType.Decimal),
							new OdbcParameter("bedno",OdbcType.VarChar),
							new OdbcParameter("patientid",OdbcType.VarChar),
                            new OdbcParameter("visitid",OdbcType.Decimal),
							new OdbcParameter("operid",OdbcType.Decimal),
							new OdbcParameter("usingindicator",OdbcType.Decimal),
							new OdbcParameter("frequencydisplay",OdbcType.Decimal),
							new OdbcParameter("memo",OdbcType.VarChar),
							new OdbcParameter("datalogstarttime",OdbcType.DateTime),
							new OdbcParameter("pcport",OdbcType.Decimal),
							new OdbcParameter("datalogstatus",OdbcType.VarChar),
							new OdbcParameter("ipport",OdbcType.Decimal),
							new OdbcParameter("inport",OdbcType.Decimal),
							new OdbcParameter("outport",OdbcType.VarChar),
                            new OdbcParameter("bednobind",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedMonitorDict")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("monitorlabel",OdbcType.VarChar),
							new OdbcParameter("manufirmname",OdbcType.VarChar),
							new OdbcParameter("model",OdbcType.VarChar),
							new OdbcParameter("interfacetype",OdbcType.Decimal),
							new OdbcParameter("interfacedesc",OdbcType.VarChar),
							new OdbcParameter("ipaddr",OdbcType.VarChar),
							new OdbcParameter("macaddr",OdbcType.VarChar),
							new OdbcParameter("lastrecvtime",OdbcType.DateTime),
							new OdbcParameter("lastrecvbedid",OdbcType.VarChar),
                            new OdbcParameter("duplexflag",OdbcType.Decimal),
                            new OdbcParameter("autoinflag",OdbcType.VarChar),
							new OdbcParameter("commport",OdbcType.VarChar),
							new OdbcParameter("baudrate",OdbcType.Decimal),
							new OdbcParameter("bytesize",OdbcType.Decimal),
							new OdbcParameter("parity",OdbcType.VarChar),
							new OdbcParameter("stopbits",OdbcType.Decimal),
                            new OdbcParameter("foutx",OdbcType.VarChar),
							new OdbcParameter("finx",OdbcType.VarChar),
							new OdbcParameter("fhardware",OdbcType.VarChar),
							new OdbcParameter("txqueuesize",OdbcType.VarChar),
							new OdbcParameter("rxqueuesize",OdbcType.VarChar),
							new OdbcParameter("xonlim",OdbcType.VarChar),
							new OdbcParameter("xofflim",OdbcType.VarChar),
							new OdbcParameter("xonchar",OdbcType.VarChar),
							new OdbcParameter("xoffchar",OdbcType.VarChar),
							new OdbcParameter("errorchar",OdbcType.VarChar),
							new OdbcParameter("eventchar",OdbcType.VarChar),
							new OdbcParameter("driverprog",OdbcType.VarChar),
                            new OdbcParameter("priority",OdbcType.Decimal),
							new OdbcParameter("itemtype",OdbcType.VarChar),
							new OdbcParameter("autoload",OdbcType.Decimal),
							new OdbcParameter("startdatetime",OdbcType.DateTime),
							new OdbcParameter("defaultrecvfrequency",OdbcType.Decimal),
							new OdbcParameter("currentrecvfrequency",OdbcType.Decimal),
							new OdbcParameter("currentrecvtimesuplimit",OdbcType.Decimal),
							new OdbcParameter("currentrecvitems",OdbcType.VarChar),
							new OdbcParameter("wardcode",OdbcType.VarChar),
							new OdbcParameter("wardtype",OdbcType.Decimal),
							new OdbcParameter("bedno",OdbcType.VarChar),
							new OdbcParameter("patientid",OdbcType.VarChar),
                            new OdbcParameter("visitid",OdbcType.Decimal),
							new OdbcParameter("operid",OdbcType.Decimal),
							new OdbcParameter("usingindicator",OdbcType.Decimal),
							new OdbcParameter("frequencydisplay",OdbcType.Decimal),
							new OdbcParameter("memo",OdbcType.VarChar),
							new OdbcParameter("datalogstarttime",OdbcType.DateTime),
							new OdbcParameter("pcport",OdbcType.Decimal),
							new OdbcParameter("datalogstatus",OdbcType.VarChar),
							new OdbcParameter("ipport",OdbcType.Decimal),
							new OdbcParameter("inport",OdbcType.Decimal),
							new OdbcParameter("outport",OdbcType.VarChar),
                            new OdbcParameter("bednobind",OdbcType.VarChar),
                            new OdbcParameter("WARDCODE",OdbcType.VarChar),
                            new OdbcParameter("BEDNOBIND",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedMonitorDict")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("WardCode",OdbcType.VarChar),
							new OdbcParameter("BedNoBind",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedMonitorDict")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("WardCode",OdbcType.VarChar),
							new OdbcParameter("BedNoBind",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedMonitorDictLabel")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("WardCode",OdbcType.VarChar),
							new OdbcParameter("BedLabel",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "SelectOneMedMonitorDict")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("patientID",OdbcType.VarChar),
                            new OdbcParameter("visitID",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "SelectOneMedMonitorDictWithBedNo")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("patientID",OdbcType.VarChar),
                            new OdbcParameter("visitID",OdbcType.Decimal),
                            new OdbcParameter("WardCode",OdbcType.VarChar),
                            new OdbcParameter("BedNoBind",OdbcType.VarChar),
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedMonitorDict 
        ///Insert Table MED_MONITOR_DICT
        /// </summary>
        public int InsertMedMonitorDictODBC(MedMonitorDict model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterODBC("InsertMedMonitorDict");
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
                return OdbcHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, MED_MONITOR_DICT_Insert_ODBC, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedMonitorDict 
        ///Update Table     MED_MONITOR_DICT
        /// </summary>
        public int UpdateMedMonitorDictODBC(MedMonitorDict model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterODBC("UpdateMedMonitorDict");
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
                return OdbcHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, MED_MONITOR_DICT_Update_ODBC, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedMonitorDict 
        ///Delete Table MED_MONITOR_DICT by (string WARD_CODE,string BED_NO)
        /// </summary>
        public int DeleteMedMonitorDictODBC(string WARD_CODE, string BED_NO)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneDelete = GetParameterODBC("DeleteMedMonitorDict");
                if (WARD_CODE != null)
                    oneDelete[0].Value = WARD_CODE;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (BED_NO != null)
                    oneDelete[1].Value = BED_NO;
                else
                    oneDelete[1].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, MED_MONITOR_DICT_Delete_ODBC, oneDelete);
            }
        }
        #endregion
        #region  [根据科室和床位获取一条记录]
        /// <summary>
        ///Select    model  MedMonitorDict 
        ///select Table MED_MONITOR_DICT by (string WARD_CODE,string BED_NO)
        /// </summary>
        public MedMonitorDict SelectMedMonitorDictODBC(string WARD_CODE, string BED_NO)
        {
            MedMonitorDict model;
            OdbcParameter[] parameterValues = GetParameterODBC("SelectMedMonitorDict");
            parameterValues[0].Value = WARD_CODE;
            parameterValues[1].Value = BED_NO;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_MONITOR_DICT_Select_ODBC, parameterValues))
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
        public int SelectOneMedMonitorDictODBC(string patientID, decimal visitID)
        {
            OdbcParameter[] parms = GetParameterODBC("SelectOneMedMonitorDict");
            parms[0].Value = patientID;
            parms[1].Value = visitID;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_MONITOR_DICT_Select_One_ODBC, parms))
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
        public int SelectOneMedMonitorDictWithBedNoODBC(string patientID, decimal visitID, string WardCode, string BedNo)
        {
            OdbcParameter[] parms = GetParameterODBC("SelectOneMedMonitorDictWithBedNo");
            parms[0].Value = patientID;
            parms[1].Value = visitID;
            parms[2].Value = WardCode;
            parms[3].Value = BedNo;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_MONITOR_DICT_Select_One_With_Bed_No_ODBC, parms))
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
