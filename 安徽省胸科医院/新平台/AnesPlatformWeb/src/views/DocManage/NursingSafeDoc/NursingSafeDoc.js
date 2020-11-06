import DocUploadBtn from '@/components/DocUploadBtn/DocUploadBtn.vue'
import InputSelect from '@/components/InputSelect/InputSelect.vue'
import DocManageApi from '@/api/DocManageApi.js'
import MedSelect from '@/components/MedSelect/MedSelect.vue'
import CommonApi from '@/api/CommonApi.js'

export default {
  name: 'NursingSafeDoc',
  data: function () {
    return {
      docName: '手术安全核查单',
      patientID: this.MedicalBasicDoc.PatientDetail.PATIENT_ID,
      visitID: this.MedicalBasicDoc.PatientDetail.VISIT_ID,
      operID: this.MedicalBasicDoc.PatientDetail.OPER_ID,
      IsModify: false,
      pdfInfo: {
        PATIENT_ID: this.MedicalBasicDoc.PATIENT_ID,
        VISIT_ID: this.MedicalBasicDoc.VISIT_ID,
        OPER_ID: this.MedicalBasicDoc.OPER_ID,
        docName: '手术安全核查单'
      },
      SURGEON_DISPLAY: '',
      OPER_DOCTOR3_DISPLAY: '',
      ANES_DOCTOR3_DISPLAY: '',
      NURSE3_DISPLAY: ''
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
    },
    SaveData () {
      var _this = this
      _this.$confirm('确认保存该文书吗？', '提示', { confirmButtonText: '确定', cancelButtonText: '取消', type: 'warning' })
        .then(() => {
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

    PrintDoc () {
      var _this = this
      var surgeonDict = JSON.parse(sessionStorage.getItem('SurgeonDict'))
      var tmp = surgeonDict.find(x => x.Key === _this.MedicalBasicDoc.MED_OPERATION_MASTER.SURGEON)
      if (tmp !== null && tmp !== undefined) {
        _this.SURGEON_DISPLAY = tmp.Value
      }

      tmp = surgeonDict.find(x => x.Key === _this.MedicalBasicDoc.MED_SAFETY_CHECKS.OPER_DOCTOR3)
      if (tmp !== null && tmp !== undefined) {
        _this.OPER_DOCTOR3_DISPLAY = tmp.Value
      }

      var AnesDoctorDict = JSON.parse(sessionStorage.getItem('AnesDoctorDict'))
      tmp = AnesDoctorDict.find(x => x.Key === _this.MedicalBasicDoc.MED_SAFETY_CHECKS.ANES_DOCTOR3)
      if (tmp !== null && tmp !== undefined) {
        _this.ANES_DOCTOR3_DISPLAY = tmp.Value
      }

      var NurseDict = JSON.parse(sessionStorage.getItem('NurseDict'))
      tmp = NurseDict.find(x => x.Key === _this.MedicalBasicDoc.MED_SAFETY_CHECKS.NURSE3)
      if (tmp !== null && tmp !== undefined) {
        _this.NURSE3_DISPLAY = tmp.Value
      }

      setTimeout(() => {
        this.$print(this.$refs.print)
      }, 1000)
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
    }
  }
}
