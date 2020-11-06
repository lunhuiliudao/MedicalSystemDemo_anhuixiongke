import DocUploadBtn from '@/components/DocUploadBtn/DocUploadBtn.vue'
import InputSelect from '@/components/InputSelect/InputSelect.vue'
import DocManageApi from '@/api/DocManageApi.js'
import MedSelect from '@/components/MedSelect/MedSelect.vue'

export default {
  name: 'NursingVisitDoc',
  data: function () {
    return {
      docName: '手术访视记录单',
      patientID: this.MedicalBasicDoc.PatientDetail.PATIENT_ID,
      visitID: this.MedicalBasicDoc.PatientDetail.VISIT_ID,
      operID: this.MedicalBasicDoc.PatientDetail.OPER_ID,
      IsModify: false,
      pdfInfo: {
        PATIENT_ID: this.MedicalBasicDoc.PATIENT_ID,
        VISIT_ID: this.MedicalBasicDoc.VISIT_ID,
        OPER_ID: this.MedicalBasicDoc.OPER_ID,
        docName: '手术访视记录单'
      },
      INQUIRY_DOCTOR_NAME: ''
    }
  },
  props: ['MedicalBasicDoc'],
  components: { DocUploadBtn, InputSelect, MedSelect },
  created: function () {
    this.LoadData()
  },
  mounted: function () {
    this.WatchDocChanged()
  },
  methods: {
    LoadData () {
      var _this = this
      var list = JSON.parse(sessionStorage.getItem('AnesDoctorDict'))
      var tmp = list.find(x => x.Key === this.MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.INQUIRY_DOCTOR)
      if (tmp !== null && tmp !== undefined) {
        _this.INQUIRY_DOCTOR_NAME = tmp.Value
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
      this.$print(this.$refs.print)
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
