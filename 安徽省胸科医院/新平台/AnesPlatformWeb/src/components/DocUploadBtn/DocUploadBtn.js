import html2canvas from 'html2canvas'
import JsPDF from 'jspdf'
import DocManageApi from '@/api/DocManageApi.js'

export default {
  name: 'DocUploadBtn',
  data: function () {
    return {
      btnLoading: false
    }
  },
  computed: {
    userInfo: function () {
      return JSON.parse(sessionStorage.user)
    }
  },
  props: ['pdfEle', 'pdfInfo'],
  methods: {
    uploadPDF () {
      this.btnLoading = true
      this.$print(this.pdfEle.print, { isprint: false })
      setTimeout(() => {
        var selectPrintobj = document
          .getElementById('myIframe')
          .contentWindow.document.querySelector('#printaArea')
        html2canvas(selectPrintobj, { allowTaint: true })
          .then(canvas => {
            let contentWidth = canvas.width
            let contentHeight = canvas.height
            let pageHeight = (contentWidth / 592.28) * 841.89 + 100
            let leftHeight = contentHeight
            let position = 10
            let imgWidth = 595.28
            let imgHeight = (592.28 / contentWidth) * contentHeight
            let pageData = canvas.toDataURL('image/jpeg', 1.0)
            let PDF = new JsPDF('', 'pt', 'a4')
            if (leftHeight < pageHeight) {
              PDF.addImage(
                pageData,
                'JPEG',
                10,
                position,
                imgWidth - 20,
                imgHeight - 40
              )
            } else {
              while (leftHeight > 0) {
                PDF.addImage(
                  pageData,
                  'JPEG',
                  10,
                  position,
                  imgWidth - 20,
                  imgHeight - 40
                )
                leftHeight -= pageHeight
                position -= 841.89
                if (leftHeight > 0) {
                  PDF.addPage()
                }
              }
            }
            // this.$ajax
            //   .post('/Api/PlatformNurseManage/PDFUpload', {
            //     content: PDF.output('datauristring'),
            //     pdfInfo: this.pdfInfo,
            //     UserId: this.userInfo.USER_JOB_ID
            //   })
            DocManageApi.PDFUpload({
              content: PDF.output('datauristring'),
              pdfInfo: this.pdfInfo,
              UserId: this.userInfo.USER_JOB_ID
            })
              .then(respose => {
                this.btnLoading = false
                if (respose.data.Data > 0) {
                  this.$message.success('上传成功')
                } else {
                  this.$message.error('上传失败')
                }
              })
              .catch(error => {
                this.btnLoading = false
                this.$message.error('上传失败')
                console.log(error)
              })
          })
          .catch(error => {
            console.log(error)
            this.btnLoading = false
          })
      }, 100)
    }
  }
}
