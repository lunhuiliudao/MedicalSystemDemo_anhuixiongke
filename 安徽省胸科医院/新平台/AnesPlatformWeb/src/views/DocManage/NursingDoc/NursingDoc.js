import DocUploadBtn from '@/components/DocUploadBtn/DocUploadBtn.vue'
import InputSelect from '@/components/InputSelect/InputSelect.vue'
import DocManageApi from '@/api/DocManageApi.js'
import MedSelect from '@/components/MedSelect/MedSelect.vue'
import CommonApi from '@/api/CommonApi.js'

export default {
  name: 'NursingDoc',
  data: function () {
    return {
      docName: '护理记录单',
      patientID: this.MedicalBasicDoc.PatientDetail.PATIENT_ID,
      visitID: this.MedicalBasicDoc.PatientDetail.VISIT_ID,
      operID: this.MedicalBasicDoc.PatientDetail.OPER_ID,
      IsModify: false,
      pdfInfo: {
        PATIENT_ID: this.MedicalBasicDoc.PATIENT_ID,
        VISIT_ID: this.MedicalBasicDoc.VISIT_ID,
        OPER_ID: this.MedicalBasicDoc.OPER_ID,
        docName: '护理记录单'
      },
      BF_NURSE_DISPLAY: '',
      SSS_NURSE_DISPLAY: '',
      QX_SQQD_DISPLAY: '',
      QX_GTQQ_DISPLAY: '',
      QX_GTQH_DISPLAY: '',
      QX_JB_NURSE_DISPLAY: '',
      XH_SQQD_DISPLAY: '',
      XH_GTQQ_DISPLAY: '',
      XH_GTQH_DISPLAY: '',
      XH_JB_NURSE_DISPLAY: '',
      AFTER_NURSE_DISPLAY: '',
      WARD_XH_NURSE_DISPLAY: '',
      FS_BQ_NURSE_DISPLAY: '',
      PACU_XH_NURSE_DISPLAY: '',
      PACU_BQ_NURSE_DISPLAY: '',
      OUT_OPER_WHEREABORTS_DISPLAY: ''
    }
  },
  props: ['MedicalBasicDoc'],
  components: { DocUploadBtn, InputSelect, MedSelect },
  created: function () {
    this.LoadData()
  },
  computed: {
    perWidth: function () {
      var MainContentWidth = 880 // parseInt(document.getElementById('MainContent').offsetWidth)
      return MainContentWidth / 3
    }
  },
  mounted: function () {
    this.WatchDocChanged()
  },
  methods: {
    LoadData () {
      if (sessionStorage.getItem('SurgeonDict') === null || sessionStorage.getItem('SurgeonDict') === undefined) {
        CommonApi.GetMedSelectDict({
          DictType: 'SurgeonDict',
          Key: '',
          Romote: true,
          IsLocal: true,
          DictObjStrings: ''
        })
          .then(response => {
            sessionStorage.setItem(
              'SurgeonDict',
              JSON.stringify(response.data.Data)
            )
          })
          .catch(error => {
            console.log(error)
          })
      }

      if (this.MedicalBasicDoc.MED_OPERATION_MASTER.OUT_OPER_WHEREABORTS !== null && undefined !== this.MedicalBasicDoc.MED_OPERATION_MASTER.OUT_OPER_WHEREABORTS) {
        switch (this.MedicalBasicDoc.MED_OPERATION_MASTER.OUT_OPER_WHEREABORTS) {
          case 60:
            this.OUT_OPER_WHEREABORTS_DISPLAY = '60'
            break
          case 65:
            this.OUT_OPER_WHEREABORTS_DISPLAY = '65'
            break
          case 40:
            this.OUT_OPER_WHEREABORTS_DISPLAY = '40'
            break
        }
      }
    },
    SaveData () {
      var _this = this
      _this.$confirm('确认保存该文书吗？', '提示', { confirmButtonText: '确定', cancelButtonText: '取消', type: 'warning' })
        .then(() => {
          if (_this.OUT_OPER_WHEREABORTS_DISPLAY !== '') {
            _this.MedicalBasicDoc.MED_OPERATION_MASTER.OUT_OPER_WHEREABORTS = parseInt(_this.OUT_OPER_WHEREABORTS_DISPLAY)
          } else {
            _this.MedicalBasicDoc.MED_OPERATION_MASTER.OUT_OPER_WHEREABORTS = null
          }

          // 注销
          if (_this.unwatchM) {
            _this.unwatchM()
          }

          if (_this.unwatchC) {
            _this.unwatchC()
          }

          DocManageApi.SaveMedicalBasicDoc(_this.MedicalBasicDoc)
            .then(response => {
              if (response.data.Data === 1) {
                _this.$emit('SelectMedicalBasicDoc')
                setTimeout(() => {
                  _this.LoadData()
                  _this.SetNurseDisplay()
                  _this.$message.success('保存成功！')
                }, 1000)
              } else {
                _this.$message('保存失败！')
              }
            })
            .catch(error => {
              _this.$message.error('保存失败')
              console.log(error)
            })

          this.IsModify = false
          this.WatchDocChanged()
        })
    },
    SetNurseDisplay () {
      var _this = this
      var NurseDict = JSON.parse(sessionStorage.getItem('NurseDict'))
      // 病房
      var tmp = NurseDict.find(x => x.Key === _this.MedicalBasicDoc.MED_NURSING_BEFORESHIFT.BF_NURSE)
      if (tmp !== null && tmp !== undefined) {
        _this.BF_NURSE_DISPLAY = tmp.Value
      }

      tmp = NurseDict.find(x => x.Key === _this.MedicalBasicDoc.MED_NURSING_BEFORESHIFT.SSS_NURSE)
      if (tmp !== null && tmp !== undefined) {
        _this.SSS_NURSE_DISPLAY = tmp.Value
      }

      tmp = NurseDict.find(x => x.Key === _this.MedicalBasicDoc.MED_NURSING_QDNURSE.QX_SQQD)
      if (tmp !== null && tmp !== undefined) {
        _this.QX_SQQD_DISPLAY = tmp.Value
      }

      tmp = NurseDict.find(x => x.Key === _this.MedicalBasicDoc.MED_NURSING_QDNURSE.QX_GTQQ)
      if (tmp !== null && tmp !== undefined) {
        _this.QX_GTQQ_DISPLAY = tmp.Value
      }

      tmp = NurseDict.find(x => x.Key === _this.MedicalBasicDoc.MED_NURSING_QDNURSE.QX_GTQH)
      if (tmp !== null && tmp !== undefined) {
        _this.QX_GTQH_DISPLAY = tmp.Value
      }

      tmp = NurseDict.find(x => x.Key === _this.MedicalBasicDoc.MED_NURSING_QDNURSE.QX_JB_NURSE)
      if (tmp !== null && tmp !== undefined) {
        _this.QX_JB_NURSE_DISPLAY = tmp.Value
      }

      tmp = NurseDict.find(x => x.Key === _this.MedicalBasicDoc.MED_NURSING_QDNURSE.XH_SQQD)
      if (tmp !== null && tmp !== undefined) {
        _this.XH_SQQD_DISPLAY = tmp.Value
      }

      tmp = NurseDict.find(x => x.Key === _this.MedicalBasicDoc.MED_NURSING_QDNURSE.XH_GTQQ)
      if (tmp !== null && tmp !== undefined) {
        _this.XH_GTQQ_DISPLAY = tmp.Value
      }

      tmp = NurseDict.find(x => x.Key === _this.MedicalBasicDoc.MED_NURSING_QDNURSE.XH_GTQH)
      if (tmp !== null && tmp !== undefined) {
        _this.XH_GTQH_DISPLAY = tmp.Value
      }

      tmp = NurseDict.find(x => x.Key === _this.MedicalBasicDoc.MED_NURSING_QDNURSE.XH_JB_NURSE)
      if (tmp !== null && tmp !== undefined) {
        _this.XH_JB_NURSE_DISPLAY = tmp.Value
      }

      tmp = NurseDict.find(x => x.Key === _this.MedicalBasicDoc.MED_NURSING_AFTER.NURSE)
      if (tmp !== null && tmp !== undefined) {
        _this.AFTER_NURSE_DISPLAY = tmp.Value
      }

      tmp = NurseDict.find(x => x.Key === _this.MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.XH_NURSE)
      if (tmp !== null && tmp !== undefined) {
        _this.WARD_XH_NURSE_DISPLAY = tmp.Value
      }

      tmp = NurseDict.find(x => x.Key === _this.MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.FS_BQ_NURSE)
      if (tmp !== null && tmp !== undefined) {
        _this.FS_BQ_NURSE_DISPLAY = tmp.Value
      }

      tmp = NurseDict.find(x => x.Key === _this.MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.XH_NURSE)
      if (tmp !== null && tmp !== undefined) {
        _this.PACU_XH_NURSE_DISPLAY = tmp.Value
      }

      tmp = NurseDict.find(x => x.Key === _this.MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.BQ_NURSE)
      if (tmp !== null && tmp !== undefined) {
        _this.PACU_BQ_NURSE_DISPLAY = tmp.Value
      }
    },
    PrintDoc () {
      this.SetNurseDisplay()
      setTimeout(() => {
        this.$print(this.$refs.print)
      }, 500)
    },
    WatchDocChanged () {
      setTimeout(() => {
        this.unwatchM = this.$watch('MedicalBasicDoc', function (val, oldVal) {
          this.IsModify = true
        }, { deep: true })
      }, 1000)
    },
    GetDiaplayValue (tmp) {
      if (tmp !== null && tmp !== undefined) {
        this.INQUIRY_DOCTOR_NAME = tmp.Value
      }
    },
    GetTableDiaplayValue (tmp) {
      this.MedicalBasicDoc.MED_NURSING_TOUR.forEach(function (item) {
        if (item.NURSE !== null && item.NURSE !== undefined && item.NURSE === tmp.Key) {
          item.NURSE_NAME = tmp.Value
        }
      })
    }

  }
}
