<template>
  <div class="reportconfig-wrapper">
    <div style="margin-bottom:10px;display:flex;flex-wrap:wrap;">
      <div style="display:flex;line-height:26px;">
        <span style="margin-left:20px;width:80px;">质控模板：</span>
        <el-select
          size="small"
          ref="selectExeclM"
          style="width:310px"
          v-model="execlName"
          clearable
          @change="changeExceleM"
          placeholder="请选择"
        >
          <el-option
            v-for="(item, index) in execleOptions"
            :key="index"
            :label="item.Key"
            :value="item.Key"
            clearable
          >
            <span>{{item.Key}}</span>
            <i
              class="el-icon-delete el-icon--right"
              style="text-align:right"
              justify-content="right"
              v-on:click.self="iFun(item.Key)"
            ></i>
          </el-option>
        </el-select>
      </div>
      <div style="display:flex;line-height:26px;">
        <span style="margin-left:20px;width:80px;">开始时间：</span>
        <el-date-picker
          size="small"
          v-model="startTime"
          type="date"
          :clearable="true"
          :editable="false"
          placeholder="选择日期时间"
          style="width:150px;"
        ></el-date-picker>
      </div>
      <div style="display:flex;line-height:26px;">
        <span style="margin-left:20px;width:80px;">结束时间：</span>
        <el-date-picker
          size="small"
          v-model="endTime"
          type="date"
          :clearable="true"
          :editable="false"
          placeholder="选择日期时间"
          style="width:150px;"
        ></el-date-picker>
      </div>
    </div>
    <div style="text-align: right;margin-bottom:10px; padding:0px 10px">
      <el-button type="primary" size="mini" class="reportconfig-wrapperAdd" v-on:click="upFile()">
        <i class="el-icon-upload el-icon--right"></i>上传模板
      </el-button>
      <el-button type="primary" size="mini" class="reportconfig-wrapperAdd" v-on:click="downFile()">
        <i class="el-icon-download el-icon--right"></i>下载模板
      </el-button>
      <el-button
        type="primary"
        size="mini"
        class="reportconfig-wrapperAdd"
        v-on:click="searchInfos()"
      >
        <i class="el-icon-search el-icon--left"></i>查询
      </el-button>
      <el-button type="primary" size="mini" class="reportconfig-wrapperAdd" v-on:click="preview()">
        <i class="el-icon-printer el-icon--left"></i>打印
      </el-button>
      <el-button
        type="primary"
        size="mini"
        class="reportconfig-wrapperAdd"
        v-on:click="showSqlDialog()"
        v-if="true"
      >
        <i class="el-icon-circle-check el-icon--left"></i>SQL执行
      </el-button>
      <el-button
        type="primary"
        size="mini"
        class="reportconfig-wrapperAdd"
        v-on:click="documentExplain()"
      >
        <i class="el-icon-document el-icon--left"></i>解释说明
      </el-button>
      <a id="hrefToExportTable" style="display: none;width: 0px;height: 0px;"></a>
    </div>
    <div style="text-align: center;">
      <div id="vhtml" class="vhtml" v-html="html" style="text-align: center;"></div>
    </div>
    <el-dialog
      title="SQL语句"
      :close-on-click-modal="false"
      :visible.sync="dialogSQLViewVisible"
      @close="closeDialog"
      custom-class="large"
    >
      <div>
        <p>单元格：</p>
        <el-select
          size="small"
          style="width:250px"
          ref="selectValue"
          v-model="Value"
          @change="selectChange"
          :editable="true"
          :filter-method="handleFilter"
          filterable
          placeholder="请选择"
        >
          <el-option
            :key="index"
            v-for="(item,index) in options"
            :label="item.Key"
            :value="item.Key"
          ></el-option>
        </el-select>
      </div>
      <div>
        <p>
          对应SQL：
          <font color="red">{0}: 开始时间, {1}: 结束时间. 例：START_DATE_TIME >= {0}</font>
        </p>
        <textarea
          id="sqlarea"
          style="width:632.5px"
          v-model="strSql"
          :editable="true"
          @change="textareaChange"
        ></textarea>
      </div>
      <div>
        <p>运行结果：</p>
        <textarea id="sqlResult" v-model="showResult" style="width:632.5px" :editable="true"></textarea>
      </div>
      <div slot="footer" class="dialog-footer">
        <el-button type="primary" @click="showSqlResult()">执行SQL</el-button>&nbsp;
        <el-button type="primary" @click="saveSqlDialog()">保 存</el-button>&nbsp;
        <el-button @click="closeSqlDialog()">取 消</el-button>
      </div>
    </el-dialog>
    <el-dialog
      title="Execle模板上传"
      :close-on-click-modal="false"
      :visible.sync="dialogExecleFileVisible"
      custom-class="large"
      @close="closeDocumentDialog"
    >
      <div>
        <el-upload
          class="image-uploader"
          :multiple="false"
          :auto-upload="true"
          list-type="text"
          :show-file-list="false"
          :before-upload="beforeUpload"
          :drag="true"
          action
          :on-exceed="handleExceed"
          :http-request="uploadFile4"
        >
          <i class="el-icon-upload"></i>
          <div class="el-upload__text">
            将文件拖到此处，或
            <em>点击上传</em>
          </div>
          <div class="el-upload__tip" slot="tip">仅限execle格式，单文件不超过5MB</div>
        </el-upload>
      </div>
    </el-dialog>
  </div>
</template>

<script>
import 'highlight.js/styles/vs.css'
import QualityControlConfig from './QualityControlConfig.js'
export default QualityControlConfig
</script>

<style lang="scss" scoped>
.reportconfig-wrapper {
  margin-top: 5px;
  padding: 10px 0px;
  background-color: #ffffff;
  font-size: 14px;
  color: #606266;

  .reportconfig-wrapperAdd {
    width: 99px;
    height: 28px;
    background: rgba(61, 209, 138, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 0px 0px 10px;
  }

  .vreportconfig-wrapperEdit {
    width: 59px;
    height: 28px;
    //background: #d0dfe6;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .reportconfig-wrapperDelete {
    width: 59px;
    height: 28px;
    background: #f56c6c;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .reportconfig-wrapperSave {
    width: 99px;
    height: 28px;
    background: rgba(0, 188, 241, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 0px 0px 10px;
  }
  .dialog-footer {
    text-align: center;
  }
}
</style>
