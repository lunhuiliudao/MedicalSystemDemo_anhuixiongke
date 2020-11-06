<template>
  <el-button
    type="primary"
    :loading="btnLoading"
    @click="uploadPDF"
    size="small"
    icon="el-icon-upload"
  >上传</el-button>
</template>

<script>
import DocUploadBtn from './DocUploadBtn.js'
export default DocUploadBtn
</script>

<style scoped>
</style>
