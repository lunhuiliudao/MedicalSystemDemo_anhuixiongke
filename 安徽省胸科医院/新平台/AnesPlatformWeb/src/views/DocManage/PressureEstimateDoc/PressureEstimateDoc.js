import DocUploadBtn from '@/components/DocUploadBtn/DocUploadBtn.vue'
import InputSelect from '@/components/InputSelect/InputSelect.vue'
import DocManageApi from '@/api/DocManageApi.js'
import MedSelect from '@/components/MedSelect/MedSelect.vue'
import CommonApi from '@/api/CommonApi.js'

export default {
  name: 'PressureEstimateDoc',
  data: function () {
    return {
      docName: '压疮评估单',
      patientID: this.MedicalBasicDoc.PatientDetail.PATIENT_ID,
      visitID: this.MedicalBasicDoc.PatientDetail.VISIT_ID,
      operID: this.MedicalBasicDoc.PatientDetail.OPER_ID,
      IsModify: false,
      pdfInfo: {
        PATIENT_ID: this.MedicalBasicDoc.PATIENT_ID,
        VISIT_ID: this.MedicalBasicDoc.VISIT_ID,
        OPER_ID: this.MedicalBasicDoc.OPER_ID,
        docName: '压疮评估单'
      },
      NURSE_DISPLAY: ''
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
    this.ScoreChange(0)
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
      var tmp = NurseDict.find(x => x.Key === _this.MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.NURSE)
      if (tmp !== null && tmp !== undefined) {
        _this.NURSE_DISPLAY = tmp.Value
      }
    },
    PrintDoc () {
      this.SetNurseDisplay()
      setTimeout(() => {
        this.$print(this.$refs.print)
      }, 500)
    },
    ScoreChange (value) {
      if (value !== 0) {
        this.IsModify = true
      }
      var AGE_SCORE = this.MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AGE_SCORE
      var WEIGHT_SCORE = this.MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.WEIGHT_SCORE
      var SLD_SCORE = this.MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SLD_SCORE
      var POSITION_SCORE = this.MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POSITION_SCORE
      var SJWL_SCORE = this.MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SJWL_SCORE
      var SSSJ_SCORE = this.MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SSSJ_SCORE
      var SSCX_SCORE = this.MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SSCX_SCORE
      var OTHER_SCORE = this.MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.OTHER_SCORE
      this.MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AMOUNT_SCORE = AGE_SCORE + WEIGHT_SCORE + SLD_SCORE + POSITION_SCORE + SJWL_SCORE + SSSJ_SCORE + SSCX_SCORE + OTHER_SCORE
    },
    CheckboxChange (value) {
      if (this.MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_GOOD === '是') {
        this.MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_ONE = ''
        this.MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_TWO = ''
        this.MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_THREE = ''
        this.MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_FOUR = ''
        this.MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_NO = ''
        this.MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_SBZZ = ''
      }
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
