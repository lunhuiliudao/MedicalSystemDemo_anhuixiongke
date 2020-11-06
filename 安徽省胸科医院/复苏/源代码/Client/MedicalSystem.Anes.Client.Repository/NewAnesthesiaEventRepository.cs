using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
{
    public class NewAnesthesiaEventRepository
    {
        AccountRepository accountRepository = new AccountRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        ComnDictRepository comnDictRepository = new ComnDictRepository();

        public MED_ANESTHESIA_EVENT NewAnesthesiaEventRow(List<MED_ANESTHESIA_EVENT> anesthestaEventDataTable, MED_PATIENT_CARD patientContext, string eventNo)
        {
            int maxItemNo = 0;
            DateTime dt = DateTime.MaxValue;
            if (anesthestaEventDataTable != null && anesthestaEventDataTable.Count > 0)
            {

                anesthestaEventDataTable.ForEach(dataRow =>
                {
                    if (dataRow.ITEM_NO > maxItemNo) maxItemNo = dataRow.ITEM_NO;
                    if (dataRow.START_TIME.HasValue && dataRow.START_TIME.Value < dt) dt = dataRow.START_TIME.Value;
                });
            }
            if (dt == DateTime.MaxValue) dt = accountRepository.GetServerTime().Data;
            maxItemNo++;
            MED_ANESTHESIA_EVENT row = new MED_ANESTHESIA_EVENT();
            row.PATIENT_ID = patientContext.PATIENT_ID;
            row.VISIT_ID = patientContext.VISIT_ID;
            row.OPER_ID = patientContext.OPER_ID;
            row.EVENT_NO = eventNo;
            row.ITEM_NO = maxItemNo;
            DateTime dt1 = DateTime.Now;
            row.START_TIME = new DateTime(dt.Year, dt.Month, dt.Day, dt1.Hour, dt1.Minute, 0);
            dt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);
            if (row.START_TIME < dt)
            {
                row.START_TIME = row.START_TIME.Value.AddDays(1);
            }
            return row;
        }
        public MED_ANESTHESIA_EVENT CopyAnesthesiaEventRow(List<MED_ANESTHESIA_EVENT> anesthestaEventDataTable, MED_PATIENT_CARD patientContext, string eventNo, int index)
        {
            MED_ANESTHESIA_EVENT sourceRow = anesthestaEventDataTable[index];
            return CopyAnesthesiaEventRow(anesthestaEventDataTable, patientContext, eventNo, sourceRow);
        }

        public MED_ANESTHESIA_EVENT CopyAnesthesiaEventRow(List<MED_ANESTHESIA_EVENT> anesthestaEventDataTable
            , MED_PATIENT_CARD patientContext, string eventNo, MED_ANESTHESIA_EVENT sourceRow)
        {
            MED_ANESTHESIA_EVENT row = NewAnesthesiaEventRow(anesthestaEventDataTable, patientContext, eventNo);
            row.EVENT_CLASS_CODE = sourceRow.EVENT_CLASS_CODE;
            row.EVENT_ITEM_NAME = sourceRow.EVENT_ITEM_NAME;
            row.EVENT_ITEM_SPEC = sourceRow.EVENT_ITEM_SPEC;
            row.EVENT_ITEM_CODE = sourceRow.EVENT_ITEM_CODE;
            row.ADMINISTRATOR = sourceRow.ADMINISTRATOR;
            row.CONCENTRATION = sourceRow.CONCENTRATION;
            row.CONCENTRATION_UNIT = sourceRow.CONCENTRATION_UNIT;
            row.DOSAGE = sourceRow.DOSAGE;
            row.DOSAGE_UNITS = sourceRow.DOSAGE_UNITS;
            row.PERFORM_SPEED = sourceRow.PERFORM_SPEED;
            row.SPEED_UNIT = sourceRow.SPEED_UNIT;
            row.PERFORM_SPEED = sourceRow.PERFORM_SPEED;
            row.EVENT_ATTR = sourceRow.EVENT_ATTR;
            return row;
        }
        public int GetMaxEventItemNo(MED_PATIENT_CARD patientContext)
        {
            int maxItemNo = 0;
            List<MED_ANESTHESIA_EVENT> anesEvent = operationInfoRepository.GetAnesEventList(patientContext.PATIENT_ID, patientContext.VISIT_ID, patientContext.OPER_ID).Data;
            if (anesEvent != null && anesEvent.Count > 0)
            {
                anesEvent.ForEach(row =>
                    {
                        if (row.ITEM_NO > maxItemNo) maxItemNo = row.ITEM_NO;
                    });
            }
            return maxItemNo;
        }
        public bool SaveEventDict(string itemClass, string itemNo)
        {
            List<MED_EVENT_DICT> eventDictList = comnDictRepository.GetEventDictList().Data;
            List<MED_EVENT_DICT_EXT> extList = comnDictRepository.GetAnesEventDictExt().Data;
            eventDictList = eventDictList.FindAll(x => x.EVENT_CLASS_CODE == itemClass && x.EVENT_ITEM_CODE == itemNo);
            extList = extList.FindAll(x => x.EVENT_CLASS_CODE == itemClass && x.EVENT_ITEM_CODE == itemNo);
            foreach (MED_EVENT_DICT eventDict in eventDictList)
            {
                comnDictRepository.DelEventDict(eventDict);
            }
            foreach (MED_EVENT_DICT_EXT extDict in extList)
            {
                comnDictRepository.DelEventExtDict(extDict);
            }
            return true;
        }
        public void SaveEventExtDict(DataTable dataTable, int dosageCount)
        {
            List<MED_EVENT_DICT> eventDictList = comnDictRepository.GetEventDictList().Data;
            List<MED_EVENT_DICT_EXT> extList = comnDictRepository.GetAnesEventDictExt().Data;
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    MED_EVENT_DICT eventDict = eventDictList.FirstOrDefault(x => x.EVENT_CLASS_CODE == dr["EVENT_CLASS_CODE"].ToString() &&
                        x.EVENT_ITEM_CODE == dr["EVENT_ITEM_CODE"].ToString());
                    if (eventDict != null)
                    {
                        for (int i = 1; i <= dosageCount; i++)
                        {
                            if (!string.IsNullOrEmpty(dr["STANDARD_DOSAGE" + i.ToString()].ToString()))
                            {
                                MED_EVENT_DICT_EXT eventExt = extList.FirstOrDefault(x => x.EVENT_CLASS_CODE == dr["EVENT_CLASS_CODE"].ToString() &&
                                       x.EVENT_ITEM_CODE == dr["EVENT_ITEM_CODE"].ToString() && x.DOSAGE_NO == i);
                                if (eventExt == null)
                                {
                                    eventExt = new MED_EVENT_DICT_EXT();
                                    eventExt.EVENT_CLASS_CODE = dr["EVENT_CLASS_CODE"].ToString();
                                    eventExt.EVENT_ITEM_CODE = dr["EVENT_ITEM_CODE"].ToString();
                                    eventExt.DOSAGE_NO = i;
                                    eventExt.STANDARD_DOSAGE = Convert.ToDecimal(dr["STANDARD_DOSAGE" + i.ToString()]);
                                    eventExt.DOSAGE_UNITS = eventDict.DOSAGE_UNITS;
                                    eventExt.STANDARD_SPEED = eventDict.PERFORM_SPEED;
                                    eventExt.SPEED_UNITS = eventDict.SPEED_UNIT;
                                    eventExt.STANDARD_CONCENTRATION = eventDict.CONCENTRATION;
                                    eventExt.CONCENTRATION_UNIT = eventDict.CONCENTRATION_UNIT;
                                    extList.Add(eventExt);
                                }
                                else
                                {
                                    eventExt.STANDARD_DOSAGE = Convert.ToDecimal(dr["STANDARD_DOSAGE" + i.ToString()]);
                                }
                            }
                        }
                    }
                }
                comnDictRepository.SaveEventExtList(extList);
            }
        }
        public DataTable RefreshEventDictExt(string itemClass, string eventType, int dosageCount)
        {
            DataTable eventExtDT = new DataTable();//
            eventExtDT.Columns.Add("EVENT_ITEM_CODE");
            eventExtDT.Columns.Add("EVENT_CLASS_CODE");
            eventExtDT.Columns.Add("EVENT_ITEM_NAME");
            eventExtDT.Columns.Add("EVENT_ITEM_SPEC");
            eventExtDT.Columns.Add("DOSAGE_UNITS");
            for (int i = 1; i <= dosageCount; i++)
            {
                eventExtDT.Columns.Add("STANDARD_DOSAGE" + i.ToString());
            }

            List<MED_EVENT_DICT> eventDictList = comnDictRepository.GetEventDictList().Data.FindAll(x => x.EVENT_CLASS_CODE == itemClass);
            if (!string.IsNullOrEmpty(eventType))
            {
                eventDictList = comnDictRepository.GetEventDictList().Data.FindAll(x => x.EVENT_CLASS_CODE == itemClass && x.EVENT_ATTR2 == eventType);
            }
            List<MED_EVENT_DICT_EXT> eventDictExtList = comnDictRepository.GetAnesEventDictExt().Data.FindAll(x => x.EVENT_CLASS_CODE == itemClass);
            foreach (MED_EVENT_DICT eventDict in eventDictList)
            {
                DataRow row = eventExtDT.NewRow();
                row["EVENT_ITEM_CODE"] = eventDict.EVENT_ITEM_CODE;
                row["EVENT_CLASS_CODE"] = eventDict.EVENT_CLASS_CODE;
                row["EVENT_ITEM_NAME"] = eventDict.EVENT_ITEM_NAME;
                row["EVENT_ITEM_SPEC"] = eventDict.EVENT_ITEM_SPEC;
                row["DOSAGE_UNITS"] = eventDict.DOSAGE_UNITS;
                List<MED_EVENT_DICT_EXT> extList = eventDictExtList.FindAll(x => x.EVENT_CLASS_CODE == eventDict.EVENT_CLASS_CODE && x.EVENT_ITEM_CODE == eventDict.EVENT_ITEM_CODE);
                for (int i = 1; i <= extList.Count; i++)
                {
                    row["STANDARD_DOSAGE" + i.ToString()] = extList[i - 1].STANDARD_DOSAGE;
                }
                eventExtDT.Rows.Add(row);
            }
            return eventExtDT;
        }
        public  void SaveAdministrationDict(string type)
        {
            List<MED_ANESTHESIA_INPUT_DICT> inputDict = comnDictRepository.GetAnesInputDictList(type).Data;
            List<MED_ADMINISTRATION_DICT> adminDict = comnDictRepository.GetAdminstrationDictList().Data;
            adminDict.Clear();
            int index = 1;
            if (inputDict != null && inputDict.Count > 0)
            {
                foreach (MED_ANESTHESIA_INPUT_DICT dict in inputDict)
                {
                    MED_ADMINISTRATION_DICT admRow = new MED_ADMINISTRATION_DICT();
                    admRow.ADMINISTRATION_CODE = index.ToString();
                    admRow.ADMINISTRATION_NAME = dict.ITEM_NAME;
                    admRow.ADMINISTRATION_ABBR = dict.ITEM_NAME;
                    index++;
                    adminDict.Add(admRow);
                }
            }
            comnDictRepository.SaveAdministrationDict(adminDict);
        }
        public void SaveUnitDict(string type)
        {
            List<MED_UNIT_DICT> unitDict = comnDictRepository.GetUnitDictList().Data;
            List<MED_ANESTHESIA_INPUT_DICT> inputDict = comnDictRepository.GetAnesInputDictList(type).Data;
            unitDict.Clear();//、、用药单位
            int index = 1;
            int unitType = 0;
            if (type.Equals("浓度单位"))//1
            {
                index = 100; unitType = 1;
            }
            else if (type.Equals("速度单位"))//2
            { index = 200; unitType = 2; }
            else if (type.Equals("用药单位"))//3
            { index = 300; unitType = 3; }

            if (unitDict != null && inputDict.Count > 0)
            {
                foreach (MED_ANESTHESIA_INPUT_DICT dict in inputDict)
                {
                    MED_UNIT_DICT admRow = new MED_UNIT_DICT();
                    admRow.UNIT_CODE = index.ToString();
                    admRow.UNIT_NAME = dict.ITEM_NAME;
                    admRow.UNIT_TYPE = unitType;
                    index++;
                    unitDict.Add(admRow);
                }
            }
            comnDictRepository.SaveUnitsDict(unitDict);
        }
    }
}
