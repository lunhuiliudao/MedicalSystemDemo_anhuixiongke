<template>
  <div class="quanlityUploadConfig">
    <el-dialog
      :title="dialogEditTitle"
      :visible.sync="dialogEditVisible"
      v-model="dialogEditVisible"
      :close-on-click-modal="false"
    >
      <el-form :model="formData" :rules="rules" ref="formView" :inline="true">
        <el-form-item label="质控平台级别定义主键" prop="Key">
          <el-input
            v-model="formData.Key"
            placeholder="请输入质控平台级别定义主键"
            :disabled="wayType==0?false:true"
            style="width:175px;"
          ></el-input>
        </el-form-item>
        <el-form-item label="质控平台级别定义名称" prop="KeyName">
          <el-input
            v-model="formData.KeyName"
            placeholder="请输入质控平台级别定义名称"
            :disabled="wayType==0?false:true"
            style="width:175px;"
          ></el-input>
        </el-form-item>
        <el-form-item label="适配值定义主键" prop="Value">
          <el-input v-model="formData.Value" placeholder="请输入适配值定义主键" style="width:175px;"></el-input>
        </el-form-item>
        <el-form-item label="适配值定义名称" prop="ValueName">
          <el-input v-model="formData.ValueName" placeholder="请输入适配值定义名称" style="width:175px;"></el-input>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button type="primary" class="quanlityUploadConfigSave" @click="saveInfos()">保 存</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
        <el-button
          type="primary"
          class="quanlityUploadConfigSave"
          @click="dialogEditVisible = false"
        >取 消</el-button>
      </div>
    </el-dialog>
    <div>
      <span style="margin-left:10px;">分类选择：</span>
      <el-select
        style="width:300px;"
        v-model="selected"
        clearable
        placeholder="请选择"
        @change="searchInfos()"
      >
        <el-option
          style="font-size:14px;line-height:20px;padding:0px 0px 0px 6px;"
          v-for="(item, index) in groupNameList"
          :key="index"
          :label="item.GroupName"
          :value="item.GroupName"
        ></el-option>
      </el-select>
      <el-button
        type="primary"
        @click="addData()"
        v-show="(selected!==null && selected!=='')"
        class="quanlityUploadConfigAdd"
      >新增</el-button>
    </div>
    <div style="background-color: #fff;min-height:600px;">
      <div class="report-main-top-wrapper"></div>
      <div>
        <el-table
          :data="tableData"
          v-loading="loading"
          element-loading-text="拼命加载中"
          border
          style="width: 100%"
        >
          <el-table-column
            prop="Key"
            header-align="center"
            align="center"
            label="质控平台级别定义主键"
            style="width: 20%"
            :show-overflow-tooltip="true"
          ></el-table-column>
          <el-table-column
            prop="KeyName"
            header-align="center"
            align="center"
            label="质控平台级别定义名称"
            style="width: 20%"
            :show-overflow-tooltip="true"
          ></el-table-column>
          <el-table-column
            prop="Value"
            header-align="center"
            align="center"
            label="适配值定义主键"
            style="width: 20%"
            :show-overflow-tooltip="true"
          ></el-table-column>
          <el-table-column
            prop="ValueName"
            header-align="center"
            align="center"
            label="适配值定义名称"
            style="width: 20%"
            :show-overflow-tooltip="true"
          ></el-table-column>
          <el-table-column label="操作" align="center" style="width: 20%;">
            <template slot-scope="scope">
              <span class="czCss">
                <el-button
                  size="small"
                  class="quanlityUploadConfigEdit"
                  @click="editData(scope.$index, scope.row)"
                >编辑</el-button>
                <el-button
                  size="small"
                  type="danger"
                  class="quanlityUploadConfigDelete"
                  @click="deleteData(scope.$index, scope.row)"
                >删除</el-button>
              </span>
            </template>
          </el-table-column>
        </el-table>
      </div>
    </div>
  </div>
</template>

<script>
import QuanlityUploadConfig from './QuanlityUploadConfig.js'
export default QuanlityUploadConfig
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

.quanlityUploadConfig {
  margin-top: 5px;
  padding: 10px 0px;
  background-color: #f5f9fb;
  font-size: 14px;
  color: #606266;
  min-height: 768px;
  .report-main-top-wrapper {
    height: 2px;
    margin-top: 15px;
    background: linear-gradient(
      90deg,
      rgba(36, 197, 240, 1),
      rgba(103, 245, 184, 1)
    );
  }
  .quanlityUploadConfigAdd {
    width: 99px;
    height: 28px;
    background: rgba(61, 209, 138, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 10px 10px;
  }

  .quanlityUploadConfigEdit {
    width: 59px;
    height: 28px;
    //background: #d0dfe6;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 0px;
  }

  .quanlityUploadConfigDelete {
    width: 59px;
    height: 28px;
    background: #f56c6c;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 0px;
  }
  .quanlityUploadConfigSave {
    width: 99px;
    height: 28px;
    background: rgba(0, 188, 241, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 10px 10px;
  }
  .czCss {
    display: flex;
    flex-direction: row;
    margin-left: 60px;
  }

  .conditionName {
    width: 70px;
    float: left;
    text-align: right;
    height: 26px;
    line-height: 26px;
    font-weight: bolder;
    margin-left: 10px;
  }
}

@media screen and (min-aspect-ratio: 1001/1000) {
  // 横屏
}

@media screen and (max-aspect-ratio: 1000/1000) {
  // 竖屏
  .quanlityUploadConfig {
    .quanlityUploadConfigEdit {
      margin: 5px 2px;
    }
    .quanlityUploadConfigDelete {
      margin: 5px 2px;
    }
    .czCss {
      margin-left: 0px;
    }
    .conditionName {
      margin-left: 10px;
    }
  }
}
.dialog-footer {
  text-align: center;
}

#PaginationView {
  text-align: center;
}
</style>
<style>
.quanlityUploadConfig .el-input__icon {
  line-height: 25px;
}

.quanlityUploadConfig .el-button {
  display: inline-block;
  line-height: 1;
  white-space: nowrap;
  cursor: pointer;
  background: #fff;
  border: 1px solid #dcdfe6;

  -webkit-appearance: none;
  text-align: center;
  -webkit-box-sizing: border-box;
  box-sizing: border-box;
  outline: 0;
  margin: 0;
  -webkit-transition: 0.1s;
  transition: 0.1s;
  font-weight: 500;
  padding: 6px 0px;
  font-size: 14px;
  border-radius: 4px;
}

.quanlityUploadConfig .el-table th {
  padding: 6px 0;
}

.quanlityUploadConfig .el-table td {
  padding: 4px 0;
}

.quanlityUploadConfig .el-input__inner {
  -webkit-appearance: none;
  background-color: #f7f7f7;
  background-image: none;
  border-radius: 4px;
  border: 1px solid #dcdfe6;
  -webkit-box-sizing: border-box;
  box-sizing: border-box;
  color: #606266;
  display: inline-block;
  height: 26px;
  line-height: 20px;
  outline: 0;
  padding: 0 15px;
  -webkit-transition: border-color 0.2s cubic-bezier(0.645, 0.045, 0.355, 1);
  transition: border-color 0.2s cubic-bezier(0.645, 0.045, 0.355, 1);
  width: 100%;
  font-size: 12px;
}

.quanlityUploadConfig .el-textarea__inner {
  background-color: #f7f7f7;
  font-size: 12px;
}

.quanlityUploadConfig .el-form-item__label {
  font-size: 12px;
  font-family: MicrosoftYaHei;
  font-weight: 400;
  color: rgba(101, 101, 101, 1);
}

.quanlityUploadConfig ::-webkit-input-placeholder {
  font-style: italic;
}

@media screen and (min-aspect-ratio: 1001/1000) {
  /* 横屏 */
  .quanlityUploadConfig .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 220px;
  }
}

@media screen and (max-aspect-ratio: 1000/1000) {
  /* 竖屏 */
  .quanlityUploadConfig .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 145px;
  }
}
</style>
