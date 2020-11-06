using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Client.Repository;
using MedicalSystem.Services;

namespace MedicalSystem.Anes.Client.AppPC
{
    [ToolboxItem(true)]
    public partial class OperationRoomPandect : BaseView
    {
        CommonRepository commonRepository = new CommonRepository();

        ComnDictRepository comnDictRepository = new ComnDictRepository();

        PatientInfoRepository patientInfoRepository = new PatientInfoRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        AccountRepository accountRepository = new AccountRepository();

        OperationScheduleRepository operationScheduleRepository = new OperationScheduleRepository();

        SyncInfoRepository syncInfoRepository = new SyncInfoRepository();

        int colCount = 6;
        int rowCount = 4;
        string _bedType = "0";
        public int OrginWidth = 1200;
        List<OperationRoomContent> OperationRoomContentList = new List<OperationRoomContent>();
        List<MED_OPERATING_ROOM> pacuRoomList = null;
        MED_HIS_USERS doctor = null;
        public OperationRoomContent _selectedOpeRoom = null;
        public bool _canSelect = false;
        public static int _pageTage = 0;
        public OperationRoomPandect() : this("0") { }
        public OperationRoomPandect(string bedType) : this(bedType, false) { }
        public OperationRoomPandect(string bedType, bool canSelect)
        {
            InitializeComponent();
            _canSelect = canSelect;
            if (ApplicationConfiguration.IsPACUProgram)
                _bedType = "1";
            OperationRoomPandectLoad(_bedType);
        }
        private OperationRoomContent _selectedOperationRoomContent = null;
        public OperationRoomContent SelectedOperationRoomContent
        {
            get
            {
                return _selectedOperationRoomContent;
            }
        }
        private static readonly object _PACUPandectDocClick = new object();
        public event EventHandler PACUPandectDocClick
        {
            add
            {
                Events.AddHandler(_PACUPandectDocClick, value);
            }
            remove
            {
                Events.RemoveHandler(_PACUPandectDocClick, value);
            }
        }
        private static readonly object _OutPACUPandectClick = new object();
        public event EventHandler OutPACUPandectClick
        {
            add
            {
                Events.AddHandler(_OutPACUPandectClick, value);
            }
            remove
            {
                Events.RemoveHandler(_OutPACUPandectClick, value);
            }
        }
        public event EventHandler PatientSelected;

        public void FirePatientSelectedEvent()
        {
            if (PatientSelected != null)
                PatientSelected(null, EventArgs.Empty);
        }
        public void InitOperationRoomContentList()
        {
            int count = pacuRoomList.Count;// pacuRoomList.Count > 12 ? 12 :
            for (int i = 0; i < count; i++)
            {
                MED_OPERATING_ROOM row = pacuRoomList[i];
                OperationRoomContent operRoomContent = new OperationRoomContent();
                operRoomContent.BedLabel = row.BED_LABEL;
                operRoomContent.OperRoomNo = row.ROOM_NO;
                operRoomContent.RoomNo = row.ROOM_NO;
                operRoomContent.OperRoomKey = row.ROOM_NO;
                operRoomContent.BedType = _bedType;
                OperationRoomContentList.Add(operRoomContent);
                operRoomContent.OperRoomSelected += new EventHandler(operRoomContent_OperRoomSelected);
                operRoomContent.Click += new EventHandler(operRoomContent_Click);
                operRoomContent.DoDoubleClick += new EventHandler(operRoomContent_DoubleClick);
                operRoomContent.PACUDocClick += new EventHandler(operRoomContent_PACUDocClick);
                operRoomContent.OutPACUDocClick += operRoomContent_OutPACUDocClick;
            }
            int contentWidth = 0;
            int contentHeight = 0;

            if (OperationRoomContentList.Count > 0)
            {
                contentWidth = OperationRoomContentList[0].Width;
                contentHeight = OperationRoomContentList[0].Height;
            }
            int useWidth = this.Width < OrginWidth ? OrginWidth : this.Width;
            while (colCount * contentWidth >= useWidth)
            {
                colCount--;
            }
            if (colCount <= 0)
                return;
            if (OperationRoomContentList.Count % colCount > 0)
            {
                rowCount = OperationRoomContentList.Count / colCount + 1;
            }
            else
            {
                rowCount = OperationRoomContentList.Count / colCount;
            }
            int offX = 1;
            int offY = 5;
            OperationRoomContent operationRoomContent = null;
            int index = 0;
            //排序
            for (int i = 0; i < rowCount; i++)
            {
                offY = i == 0 ? 5 : 10;
                for (int j = 0; j < colCount; j++)
                {
                    offX = j == 0 ? 1 : 5;
                    index = (i * colCount) + j;
                    if (index >= OperationRoomContentList.Count)
                        break;
                    operationRoomContent = OperationRoomContentList[index];
                    operationRoomContent.Left = offX * (j + 1) + contentWidth * j;
                    operationRoomContent.Top = offY * (i + 1) + contentHeight * i;
                    operationRoomContent.Visible = true;
                }
            }
            pRoomPandect.Controls.AddRange(OperationRoomContentList.ToArray());
        }

        public void RefreshOperationRoomContentList()
        {
            foreach (OperationRoomContent roomContent in OperationRoomContentList)
            {
                roomContent.RefreshControl(roomContent.RoomNo, roomContent.BedType);
            }
        }
        public void RefreshRoom(string roomNo, string patientID, int visitID, int operID)
        {
            foreach (OperationRoomContent roomContent in OperationRoomContentList)
            {
                if (roomContent.OperRoomNo == roomNo)
                {
                    MED_OPERATION_MASTER operationMaster = operationInfoRepository.GetOperMaster(patientID, visitID, operID).Data;
                    roomContent.PatientID = patientID;
                    roomContent.VisitID = visitID;
                    roomContent.OperID = operID;
                    if (operationMaster.IN_PACU_DATE_TIME.HasValue)
                    {
                        TimeSpan timeDiff = accountRepository.GetServerTime().Data - operationMaster.IN_PACU_DATE_TIME.Value;
                        roomContent.inTime = (int)timeDiff.TotalMinutes;
                    }
                    roomContent.RefreshValue();
                    roomContent.IsSelected = true;
                }
            }
        }
        public void RefreshRoom(string searchContent, bool isSelected)
        {
            if (isSelected)
            {
                foreach (OperationRoomContent roomContent in OperationRoomContentList)
                {
                    if (roomContent.PatientID == searchContent || roomContent.InpNo == searchContent || roomContent.PatName == searchContent)
                    {
                        roomContent.IsSelected = true;
                    }
                }
            }
            else
            {
                foreach (OperationRoomContent roomContent in OperationRoomContentList)
                {
                    roomContent.IsSelected = false;
                }
            }

        }
        private void GetPacuInfo()
        {
            OperationRoomContent operationRoomContent = null;
            for (int i = 0; i < OperationRoomContentList.Count; i++)
            {
                operationRoomContent = OperationRoomContentList[i];
                operationRoomContent.VisitID = 0;
                operationRoomContent.OperID = 0;
                operationRoomContent.PatientID = "";
                operationRoomContent.InPacuTime = "";
                MED_OPERATING_ROOM pacuRoom = pacuRoomList.Where(x => x.ROOM_NO.Equals(operationRoomContent.OperRoomKey)).ToList()[0];
                if (pacuRoom != null)
                {
                    if (!string.IsNullOrEmpty(pacuRoom.PATIENT_ID))
                    {
                        operationRoomContent.PatientID = pacuRoom.PATIENT_ID;
                        operationRoomContent.VisitID = pacuRoom.VISIT_ID.Value;
                        operationRoomContent.OperID = pacuRoom.OPER_ID.Value;
                        MED_PAT_MASTER_INDEX patMaster = operationInfoRepository.GetPatMasterIndex(operationRoomContent.PatientID).Data;
                        MED_OPERATION_MASTER operationMaster = operationInfoRepository.GetOperMaster(operationRoomContent.PatientID, operationRoomContent.VisitID, operationRoomContent.OperID).Data;//ExtendApplicationContext.Current.MED_OPERATION_MASTER;
                        if (operationMaster != null && !string.IsNullOrEmpty(operationMaster.OPER_STATUS_CODE.ToString()))
                        {
                            if (operationMaster.OPER_STATUS_CODE != 45)
                            {
                                operationRoomContent.PatientID = "";
                                operationRoomContent.VisitID = 0;
                                operationRoomContent.OperID = 0;
                            }
                            else
                            {
                                if (operationMaster.IN_PACU_DATE_TIME.HasValue)
                                {
                                    TimeSpan timeDiff = accountRepository.GetServerTime().Data - operationMaster.IN_PACU_DATE_TIME.Value;
                                    operationRoomContent.inTime = (int)timeDiff.TotalMinutes;
                                }
                            }
                        }
                    }
                }
                operationRoomContent.RefreshValue();
                operationRoomContent.CancelFocus();
            }
        }

        public void OperationRoomPandectLoad(string bedType)
        {
            try
            {
                pRoomPandect.Controls.Clear();
                OperationRoomContentList.Clear();
                _bedType = bedType;
                pacuRoomList = comnDictRepository.GetOperatingRoomList(bedType).Data;
                if (pacuRoomList != null && pacuRoomList.Count > 0)
                    pacuRoomList = pacuRoomList.Where(x => x.DEPT_CODE == ExtendApplicationContext.Current.OperRoom).ToList();

                if (pacuRoomList.Count <= 12) panelBotton.Visible = false;
                else btnUp.Enabled = false;
                InitOperationRoomContentList();
                GetPacuInfo();
            }
            catch (Exception ex)
            {
                Logger.Error("OperationRoomPandectLoad", ex);
                ExceptionHandler.Handle(ex);
            }
        }
        private void operRoomContent_OperRoomSelected(object sender, EventArgs e)
        {
            if (sender is OperationRoomContent)
            {
                _selectedOpeRoom = sender as OperationRoomContent;
                _selectedOpeRoom.RoomNo = _selectedOpeRoom.OperRoomNo;
                foreach (OperationRoomContent roomContent in OperationRoomContentList)
                {
                    if (roomContent != sender)
                    {
                        roomContent.CancelFocus();
                    }
                }
            }
            ;
        }
        private void operRoomContent_Click(object sender, EventArgs e)
        {
            foreach (OperationRoomContent roomContent in OperationRoomContentList)
            {
                if (roomContent != sender)
                {
                    roomContent.CancelFocus();
                }
            }
        }

        private void operRoomContent_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (!_canSelect) return;
                OperationRoomContent operationRoomContent = sender as OperationRoomContent;
                if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
                {
                    if (operationRoomContent != null)
                    {
                        if (string.IsNullOrEmpty(operationRoomContent.PatientID))
                        {
                            _selectedOperationRoomContent = operationRoomContent;
                            if (ParentForm != null)
                            {
                                ParentForm.DialogResult = DialogResult.OK;
                            }
                            RefreshRoom(operationRoomContent.RoomNo, ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID,
               ExtendApplicationContext.Current.PatientContextExtend.OperID);
                        }
                    }
                }

            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }
        }

        private void operRoomContent_PACUDocClick(object sender, EventArgs e)
        {
            if (sender is OperationRoomContent)
            {
                _selectedOpeRoom = sender as OperationRoomContent;
                if (!string.IsNullOrEmpty(_selectedOpeRoom.PatientID))
                {
                    ExtendApplicationContext.Current.PatientContextExtend.PatientID = _selectedOpeRoom.PatientID;
                    ExtendApplicationContext.Current.PatientContextExtend.VisitID = _selectedOpeRoom.VisitID;
                    ExtendApplicationContext.Current.PatientContextExtend.OperID = _selectedOpeRoom.OperID;
                    ExtendApplicationContext.Current.PatientInformationExtend = patientInfoRepository.GetPatCard(_selectedOpeRoom.PatientID, _selectedOpeRoom.VisitID, _selectedOpeRoom.OperID).Data;
                    ExtendApplicationContext.Current.SystemStatus = ProgramStatus.PACURecord;
                    EventHandler eventHandle = Events[_PACUPandectDocClick] as EventHandler;
                    if (eventHandle != null)
                    {
                        eventHandle(sender, e);
                    }
                }
            }
        }
        private void operRoomContent_OutPACUDocClick(object sender, EventArgs e)
        {
            EventHandler eventHandle = Events[_OutPACUPandectClick] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, e);
            }
        }
        private void RefreshRoomInfo(int pageTage)
        {
            pacuRoomList = comnDictRepository.GetOperatingRoomList("1").Data;
            if (pacuRoomList != null && pacuRoomList.Count > 0)
                pacuRoomList = pacuRoomList.Where(x => x.DEPT_CODE == ExtendApplicationContext.Current.OperRoom).ToList();
            foreach (OperationRoomContent roomContent in OperationRoomContentList)
            {
                MED_OPERATING_ROOM row = pacuRoomList[pageTage];
                roomContent.BedLabel = row.BED_LABEL;
                roomContent.OperRoomNo = row.ROOM_NO;
                roomContent.RoomNo = row.ROOM_NO;
                roomContent.OperRoomKey = row.ROOM_NO;
                roomContent.BedType = _bedType;
                pageTage = pageTage + 1;
            }
            GetPacuInfo();
        }

        private void btnUp_BtnClicked(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
            _pageTage = _pageTage - 12;
            RefreshRoomInfo(_pageTage);
            if (_pageTage - 12 < 0) btnUp.Enabled = false;
        }

        private void btnNext_BtnClicked(object sender, EventArgs e)
        {
            btnUp.Enabled = true;
            _pageTage = _pageTage + 12;
            RefreshRoomInfo(_pageTage);
            if (_pageTage + 12 >= pacuRoomList.Count) btnNext.Enabled = false;
        }

        private void pRoomPandect_Paint(object sender, PaintEventArgs e)
        {
            int offX = 1;
            int offY = 5;
            Graphics gac = e.Graphics;
            for (int i = 0; i < OperationRoomContentList.Count; i++)
            {
                OperationRoomContent room = OperationRoomContentList[i];
                if (i % 2 == 1)
                {
                    using (Pen pen = new Pen(Color.FromArgb(221, 226, 233), 1))
                    {
                        gac.DrawLine(pen, room.Left - 5, room.Top, room.Left - 5, room.Top + room.Height);
                    }
                }
                else if (i != 0)
                {
                    using (Pen pen = new Pen(Color.FromArgb(221, 226, 233), 1))
                    {
                        gac.DrawLine(pen, 2, room.Top - 5, room.Width * 2 + 10, room.Top - 5);
                    }
                }
            }
        }
    }
}
