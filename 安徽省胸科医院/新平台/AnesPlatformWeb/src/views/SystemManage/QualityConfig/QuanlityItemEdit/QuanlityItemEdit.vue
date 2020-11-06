<template>
  <div class="quanlityItemEdit">
    <el-dialog
      :title="dialogEditTitle"
      :visible.sync="dialogEditVisible"
      v-model="dialogEditVisible"
      :close-on-click-modal="false"
    >
      <el-form :model="formData" :rules="rules" ref="formView" :inline="true">
        <el-form-item label="#" prop="SORT_NO">
          <el-input v-model="formData.SORT_NO" :disabled="true" style="width:175px;"></el-input>
        </el-form-item>
        <el-form-item label="项目编号" prop="QC_CODE">
          <el-input
            v-model="formData.QC_CODE"
            :disabled="dialogEditTitle=='新增'?false:true"
            placeholder="请输入项目编号"
            style="width:175px;"
          ></el-input>
        </el-form-item>
        <el-form-item label="项目名称" prop="QC_NAME">
          <el-input
            v-model="formData.QC_NAME"
            :maxlength="20"
            placeholder="请输入项目名称"
            style="width:175px;"
          ></el-input>
        </el-form-item>
        <el-form-item label="条件" prop="CONDITION">
          <el-input
            type="textarea"
            v-model="formData.CONDITION"
            placeholder="请输入条件"
            style="width:175px;"
          ></el-input>
        </el-form-item>

        <el-form-item label="上报编码" prop="REPORT_CODE">
          <el-input
            v-model="formData.REPORT_CODE"
            :maxlength="20"
            placeholder="请输入上报编码"
            style="width:175px;"
          ></el-input>
        </el-form-item>
        <el-form-item label="不良事件" prop="AE_MARK">
          <el-switch
            v-model="formData.AE_MARK"
            :inactive-value="0"
            inactive-text="否"
            :active-value="1"
            active-text="是"
            active-color="#13ce66"
            inactive-color="#ff4949"
            style="width:175px;line-height: 20px;"
          ></el-switch>
        </el-form-item>
        <el-form-item label="不良事件条件" prop="AE_CONDITION">
          <el-input
            type="textarea"
            v-model="formData.AE_CONDITION"
            placeholder="请输入不良事件条件"
            style="width:175px;"
          ></el-input>
        </el-form-item>
        <el-form-item label="项目名称简写" prop="SHORT_NAME">
          <el-input v-model="formData.SHORT_NAME" placeholder="请输入项目名称简写" style="width:175px;"></el-input>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button type="primary" class="quanlityItemEditSave" @click="onSubmit('formView')">保 存</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
        <el-button
          type="primary"
          class="quanlityItemEditSave"
          @click="dialogEditVisible = false"
        >取 消</el-button>
      </div>
    </el-dialog>
    <div>
      <el-button type="primary" @click="addData()" class="quanlityItemEditAdd" v-show="true">新增</el-button>
    </div>
    <div style="background-color: #fff;">
      <div class="report-main-top-wrapper"></div>
      <div>
        <el-table
          :data="tableData"
          v-loading="loading"
          element-loading-text="拼命加载中"
          border
          style="width: 100%"
          tooltip-effect="light"
        >
          <el-table-column
            prop="QC_CODE"
            header-align="center"
            align="center"
            label="项目编号"
            width="120px"
            :show-overflow-tooltip="true"
          ></el-table-column>
          <el-table-column
            prop="QC_NAME"
            header-align="center"
            align="left"
            label="项目名称"
            min-width="120px"
            :show-overflow-tooltip="true"
          ></el-table-column>
          <el-table-column
            prop="CONDITION"
            header-align="center"
            align="center"
            label="数据条件"
            min-width="120px"
            :show-overflow-tooltip="true"
          ></el-table-column>
          <el-table-column
            prop="REPORT_CODE"
            header-align="center"
            align="center"
            label="上报编码"
            width="120px"
            :show-overflow-tooltip="true"
          ></el-table-column>
          <el-table-column
            prop="AE_MARK"
            header-align="center"
            align="center"
            label="不良事件标识"
            width="80px"
            :show-overflow-tooltip="true"
          >
            <template slot-scope="scope">
              <span>{{ scope.row.AE_MARK==1?"是":"否" }}</span>
            </template>
          </el-table-column>
          <el-table-column
            prop="AE_CONDITION"
            header-align="center"
            align="center"
            label="不良事件条件"
            min-width="120px"
            :show-overflow-tooltip="true"
          ></el-table-column>
          <el-table-column
            prop="SHORT_NAME"
            header-align="center"
            align="center"
            label="项目名称简写"
            width="120px"
            :show-overflow-tooltip="true"
          ></el-table-column>
          <el-table-column label="操作" align="center" fixed="right" min-width="120px">
            <template slot-scope="scope">
              <span class="czCss">
                <el-button
                  size="small"
                  class="quanlityItemEditEdit"
                  @click="editData(scope.$index, scope.row)"
                >编辑</el-button>
                <el-button
                  size="small"
                  type="danger"
                  class="quanlityItemEditDelete"
                  @click="deleteData(scope.$index, scope.row)"
                  v-show="true"
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
import QuanlityItemEdit from './QuanlityItemEdit.js'
export default QuanlityItemEdit
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

.quanlityItemEdit {
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
  .quanlityItemEditAdd {
    width: 99px;
    height: 28px;
    background: rgba(61, 209, 138, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 10px 10px;
  }

  .quanlityItemEditEdit {
    width: 59px;
    height: 28px;
    //background: #d0dfe6;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 0px;
  }

  .quanlityItemEditDelete {
    width: 59px;
    height: 28px;
    background: #f56c6c;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 0px;
  }

  .quanlityItemEditSave {
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
    margin-left: 40px;
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
  .quanlityItemEdit {
    .quanlityItemEditEdit {
      margin: 5px 2px;
    }
    .quanlityItemEditDelete {
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
.quanlityItemEdit .el-button {
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

.quanlityItemEdit .el-table th {
  padding: 6px 0;
}

.quanlityItemEdit .el-table td {
  padding: 4px 0;
}

.quanlityItemEdit .el-input__inner {
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

.quanlityItemEdit .el-textarea__inner {
  background-color: #f7f7f7;
  font-size: 12px;
}

.quanlityItemEdit .el-form-item__label {
  font-size: 12px;
  font-family: MicrosoftYaHei;
  font-weight: 400;
  color: rgba(101, 101, 101, 1);
}
.el-tooltip__popper {
  width: 400px;
}

.quanlityItemEdit ::-webkit-input-placeholder {
  font-style: italic;
}

@media screen and (min-aspect-ratio: 1001/1000) {
  /* 横屏 */
  .quanlityItemEdit .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 100px;
  }
}

@media screen and (max-aspect-ratio: 1000/1000) {
  /* 竖屏 */
  .quanlityItemEdit .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 110px;
  }
}
</style>
