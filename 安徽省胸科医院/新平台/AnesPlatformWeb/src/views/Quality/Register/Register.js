import QualityApi from '@/api/QualityApi.js'
import ScrollBar from '../components/ScrollBar/ScrollBar.vue'
import MedSelect from '@/components/MedSelect/MedSelect.vue'
import InputSelect from '@/components/InputSelect/InputSelect.vue'
// import AnesDatePicker from '@/components/anes-date-picker'

export default {
  name: 'Register',
  data () {
    return {
      dialogVisible: false,
      patientBaseDataAll: [],
      patientBaseData: this.getOutPatInfo(),
      medAnesthesiaInputData: this.getInputData(),
      anesMethodData: [],
      asaGradeData: [
        { ASA_CODE: 'Ⅰ级' },
        { ASA_CODE: 'Ⅱ级' },
        { ASA_CODE: 'Ⅲ级' },
        { ASA_CODE: 'Ⅳ级' },
        { ASA_CODE: 'Ⅴ级' },
        { ASA_CODE: 'Ⅵ级' }
      ],
      deptList: [],
      formData: new FormData(),
      fileList: [],
      key: this.$route + +new Date(), // 重置页面
      steps: [
        { lable: '基本信息' },
        { lable: '注意事项' },
        { lable: '发生经过' },
        { lable: '事件选择' },
        { lable: '事件分级' },
        { lable: '发生原因' },
        { lable: '预防措施' },
        { lable: '附件管理' }
      ],
      MaxOperId: 0,
      isOutRoomOper: '室内',
      isdisabled: true,
      isUpload: false // 是否该患者已经上报
    }
  },
  components: { ScrollBar, MedSelect, InputSelect },
  methods: {
    getOutPatInfo () {
      return {
        INP_NO: '',
        PATIENT_ID: '',
        VISIT_ID: 0,
        OPER_ID: 0,
        NAME: '',
        SEX: '',
        DATE_OF_BIRTH: null,
        BODY_HEIGHT: 0,
        BODY_WEIGHT: 0,
        EMERGENCY_IND: 0,
        DEPT_CODE: '',
        OPERATION_NAME: '',
        ANES_METHOD: '',
        ASA_GRADE: '',
        DIAG_OPERATION: '',
        ANES_START_TIME: null,
        ANES_END_TIME: null
      }
    },
    getInputData () {
      return {
        CANCELED_TYPE: '',
        PACU_3H: '',
        PACU_TEMPERATURE: -1,
        NO_PLAN_IN_ICU: -1,
        TRACHEA_6H: -1,
        ANES_START_24H_DEATH: -1,
        ANES_START_24H_STOP: -1,
        ANES_ANAPHYLAXIS: -1,
        SPINAL_ANES_COMP: -1,
        CENTRAL_VENOUS: -1,
        TRACHEA_HOARSE: -1,
        AFTER_ANES_COMA: -1,
        EVENT_GRADE: -1,
        OPER_EVENT: -1,
        ANES_EVENT: -1,
        PAT_INDETIFICATION: -1,
        PREVENT_STEP: '',
        EVENT_COURSE: '',
        PATIENT_ID: '',
        VISIT_ID: 0,
        OPER_ID: 0
      }
    },
    getMaxOperId (inpNo) {
      if (this.isOutRoomOper === '室内') {
        QualityApi.getPatientBaseInfo({
          inpNo: inpNo
        })
          .then(respose => {
            var data = respose.data.Data

            if (data !== null && data.length > 0) {
              var maxNo = 0

              data.forEach(element => {
                if (parseInt(element.OPER_ID) > maxNo) {
                  maxNo = parseInt(element.OPER_ID)
                }
              })
              this.MaxOperId = maxNo
            }
          })
          .catch(error => {
            console.log(error)
          })
      } else {
        QualityApi.getPatientBaseInfoOut({
          inpNo: inpNo
        })
          .then(respose => {
            var data = respose.data.Data

            if (data !== null && data.length > 0) {
              var maxNo = 0

              data.forEach(element => {
                if (parseInt(element.OPER_ID) > maxNo) {
                  maxNo = parseInt(element.OPER_ID)
                }
              })
              this.MaxOperId = maxNo
            }
          })
          .catch(error => {
            console.log(error)
          })
      }
    },
    clickitemOut (e) {
      e === this.isOutRoomOper
        ? (this.isOutRoomOper = '')
        : (this.isOutRoomOper = e)
      this.isUpload = false

      this.ClearForm()
      if (this.isOutRoomOper === '室外') {
        this.isdisabled = false
      } else {
        this.isdisabled = true
      }
    },
    clickitemSex (e) {
      e === this.patientBaseData.SEX
        ? (this.patientBaseData.SEX = '')
        : (this.patientBaseData.SEX = e)
    },
    clickitemEventGrade (e) {
      if (this.isUpload === false) {
        e === this.medAnesthesiaInputData.EVENT_GRADE
          ? (this.medAnesthesiaInputData.EVENT_GRADE = '')
          : (this.medAnesthesiaInputData.EVENT_GRADE = e)
      }
    },
    // 获取患者基本信息
    getPatientBaseInfo (val) {
      var _this = this
      if (val === undefined || val === '') {
        _this.$message({
          message: '该住院号未查询到患者住院记录',
          type: 'warning'
        })
      } else {
        if (this.isOutRoomOper === '室内') {
          QualityApi.getPatientBaseInfo({
            inpNo: val
          })
            .then(respose => {
              _this.patientBaseDataAll = respose.data.Data
              _this.getMaxOperId(this.patientBaseData.INP_NO)
              if (_this.patientBaseDataAll.length > 1) {
                _this.dialogVisible = true
              } else if (_this.patientBaseDataAll.length === 1) {
                _this.patientBaseData = _this.patientBaseDataAll[0]
                _this.radioSelectValuesSex = _this.patientBaseData.SEX
                _this.getAnesthesiaInputData(
                  _this.patientBaseData.PATIENT_ID,
                  _this.patientBaseData.VISIT_ID,
                  _this.patientBaseData.OPER_ID
                )
              } else {
                _this.$message({
                  message: '该住院号未查询到患者住院记录',
                  type: 'warning'
                })
              }
            })
            .catch(error => {
              console.log(error)
            })
        } else {
          QualityApi.getPatientBaseInfoOut({
            inpNo: val
          })
            .then(respose => {
              _this.patientBaseDataAll = respose.data.Data
              _this.getMaxOperId(this.patientBaseData.INP_NO)
              if (_this.patientBaseDataAll.length > 1) {
                _this.dialogVisible = true
              } else if (_this.patientBaseDataAll.length === 1) {
                _this.patientBaseData = _this.patientBaseDataAll[0]
                _this.radioSelectValuesSex = _this.patientBaseData.SEX
                _this.getAnesthesiaInputData(
                  _this.patientBaseData.PATIENT_ID,
                  _this.patientBaseData.VISIT_ID,
                  _this.patientBaseData.OPER_ID
                )
              } else {
                _this.$message({
                  message: '该住院号未查询到患者住院记录',
                  type: 'warning'
                })
              }
            })
            .catch(error => {
              console.log(error)
            })
        }
      }
    },
    // 获取患者基本信息
    getPatientBaseInfo2 (patientId, visitId, operId) {
      var _this = this
      if (
        typeof patientId === 'undefined' ||
        visitId === 'undefined' ||
        operId === 'undefined'
      ) {
        _this.$message({
          message: '该住院号未查询到患者住院记录',
          type: 'warning'
        })
      } else {
        if (this.isOutRoomOper === '室内') {
          QualityApi.getPatientBaseInfo2({
            patientId: patientId,
            visitId: visitId,
            operId: operId
          })
            .then(respose => {
              _this.patientBaseDataAll = respose.data.Data
              _this.getMaxOperId(this.patientBaseData.INP_NO)
              if (_this.patientBaseDataAll.length > 1) {
                _this.dialogVisible = true
              } else if (_this.patientBaseDataAll.length === 1) {
                _this.patientBaseData = _this.patientBaseDataAll[0]
                _this.radioSelectValuesSex = _this.patientBaseData.SEX
                _this.getAnesthesiaInputData(
                  _this.patientBaseData.PATIENT_ID,
                  _this.patientBaseData.VISIT_ID,
                  _this.patientBaseData.OPER_ID
                )
              } else {
                _this.$message({
                  message: '该住院号未查询到患者住院记录',
                  type: 'warning'
                })
              }
            })
            .catch(error => {
              console.log(error)
            })
        } else {
          QualityApi.getPatientBaseInfoOut2({
            patientId: patientId,
            visitId: visitId,
            operId: operId
          })
            .then(respose => {
              _this.patientBaseDataAll = respose.data.Data
              _this.getMaxOperId(this.patientBaseData.INP_NO)
              if (_this.patientBaseDataAll.length > 1) {
                _this.dialogVisible = true
              } else if (_this.patientBaseDataAll.length === 1) {
                _this.patientBaseData = _this.patientBaseDataAll[0]
                _this.radioSelectValuesSex = _this.patientBaseData.SEX
                _this.getAnesthesiaInputData(
                  _this.patientBaseData.PATIENT_ID,
                  _this.patientBaseData.VISIT_ID,
                  _this.patientBaseData.OPER_ID
                )
              } else {
                _this.$message({
                  message: '该住院号未查询到患者住院记录',
                  type: 'warning'
                })
              }
            })
            .catch(error => {
              console.log(error)
            })
        }
      }
    },
    // 选择患者
    selectPatient (row) {
      if (row != null) {
        if (row.UPLOAD === 1) {
          this.dialogVisible = false
          this.patientBaseData = row
          this.getAnesthesiaInputData(
            this.patientBaseData.PATIENT_ID,
            this.patientBaseData.VISIT_ID,
            this.patientBaseData.OPER_ID
          )
        } else {
          this.$message({
            message: '请选择患者',
            type: 'warning'
          })
        }
      }
    },
    // 获取指控数据
    getAnesthesiaInputData (pId, vId, oId) {
      if (this.isOutRoomOper === '室内') {
        QualityApi.getAnesInputData({
          patientId: pId,
          visitId: vId,
          operId: oId
        })
          .then(respose => {
            this.medAnesthesiaInputData = respose.data.Data[0]
          })
          .catch(error => {
            console.log(error)
          })
      } else {
        QualityApi.getAnesInputDataOut({
          patientId: pId,
          visitId: vId,
          operId: oId
        })
          .then(respose => {
            this.medAnesthesiaInputData = respose.data.Data[0]
          })
          .catch(error => {
            console.log(error)
          })
      }
    },
    // 保存数据
    saveAnesthesiaInputData () {
      if (this.isOutRoomOper === '室内') {
        QualityApi.saveAnesInputData(this.medAnesthesiaInputData)
          .then(respose => {
            if (respose.data.Data === 1) {
              this.$message({
                message: '保存成功',
                type: 'success'
              })
            } else {
              this.$message.error('保存失败')
            }
          })
          .catch(error => {
            console.log(error)
          })
      } else if (this.isOutRoomOper === '室外') {
        QualityApi.saveOutAnesInputData({
          patInfo: this.patientBaseData,
          InputData: this.medAnesthesiaInputData
        })
          .then(respose => {
            if (respose.data.Data === 1) {
              this.$message({
                message: '保存成功',
                type: 'success'
              })
            } else {
              this.$message.error('保存失败')
            }
          })
          .catch(error => {
            console.log(error)
          })
      }
    },
    // 重置页面
    ClearForm () {
      this.patientBaseData = this.getOutPatInfo()
      this.patientBaseDataAll = []
      this.medAnesthesiaInputData = this.getInputData()
      this.key = this.$route + +new Date() // 重置页面
    },
    rowIndex (index) {
      if (index % 2 === 0) {
        return { tableDoubleRow: true }
      } else {
        return { tableSingleRow: true }
      }
    },

    selectDocChanged (file, fileList) {
      // console.log(file, fileList)
      if (file !== null) {
        // this.ShowSubmit = true
      }
    },
    // 移除文件
    handleRemove (file, fileList) {
      this.fileList.splice(file, 1)
      if (this.fileList.length === 0) {
        // this.ShowSubmit = false
      }
      // console.log(file, fileList)
    },
    // 预览已上传文件
    handlePreview (file) {
      // console.log(file)
    },
    // 上传成功后的回调
    uploadSuccess (response, file, fileList) {},
    // 上传错误
    uploadError (response, file, fileList) {},
    // 上传前对文件的大小、格式的判断
    beforeAvatarUpload (file) {
      var _THIS = this

      const extension = file.name.split('.')[1] === 'xls'
      const extension2 = file.name.split('.')[1] === 'xlsx'
      const extension3 = file.name.split('.')[1] === 'doc'
      const extension4 = file.name.split('.')[1] === 'docx'
      const extension5 = file.name.split('.')[1] === 'pdf'
      const extension6 = file.name.split('.')[1] === 'txt'
      const isLt2M = file.size / 1024 / 1024 < 100
      if (
        !extension &&
        !extension2 &&
        !extension3 &&
        !extension4 &&
        !extension5 &&
        !extension6
      ) {
        _THIS.$message({
          message: '上传模板只能是 xls、xlsx、doc、docx、pdf、txt 格式!',
          type: 'warning'
        })
      }
      if (!isLt2M) {
        _THIS.$message({
          message: '上传模板大小不能超过 100MB!',
          type: 'warning'
        })
      }

      if (
        (extension ||
          extension2 ||
          extension3 ||
          extension4 ||
          extension5 ||
          extension6) &&
        isLt2M
      ) {
        this.formData.append(file.name, file) // 随文件上传的其他参数
        this.formData.append('PATIENT_ID', this.patientBaseData.PATIENT_ID) // 随文件上传的其他参数
        this.formData.append('VISIT_ID', this.patientBaseData.VISIT_ID) // 随文件上传的其他参数
        this.formData.append('OPER_ID', this.patientBaseData.OPER_ID) // 随文件上传的其他参数

        this.submitFileData(this.formData)
        return false // 返回false不会自动上传
      }

      return (
        (extension ||
          extension2 ||
          extension3 ||
          extension4 ||
          extension5 ||
          extension6) &&
        isLt2M
      )
    },
    // 上传附件
    submitFileData (formData) {
      var _this = this

      if (
        _this.medAnesthesiaInputData.length > 0 ||
        _this.medAnesthesiaInputData != null
      ) {
        QualityApi.submitFileData(formData)
          .then(respose => {
            if (respose.data.Data === 1) {
              _this.$message({
                message: '上传文件成功',
                type: 'success'
              })
            } else {
              _this.$message.error('上传文件失败')
            }
          })
          .catch(error => {
            console.log(error)
          })
      } else {
        _this.$message({
          message: '请先选择一个患者登记！',
          type: 'warning'
        })
      }
      _this.formData = new FormData()
      _this.fileList = []
    }
  },
  mounted () {},
  created () {
    if (
      typeof this.$route.query.patientId !== 'undefined' &&
      typeof this.$route.query.visitId !== 'undefined' &&
      typeof this.$route.query.operId !== 'undefined' &&
      typeof this.$route.query.isOutRoomOper !== 'undefined'
    ) {
      var patientId = this.$route.query.patientId
      var visitId = this.$route.query.visitId
      var operId = this.$route.query.operId
      this.isOutRoomOper = this.$route.query.isOutRoomOper
      this.isUpload = this.$route.query.isUpload
      this.getPatientBaseInfo2(patientId, visitId, operId)
    }
  }
}
