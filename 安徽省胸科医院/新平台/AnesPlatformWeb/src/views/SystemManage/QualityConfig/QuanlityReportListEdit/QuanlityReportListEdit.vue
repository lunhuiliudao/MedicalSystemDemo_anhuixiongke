<template>
  <div class="quanlityReportListEdit">
    <el-dialog
      :title="dialogEditTitle"
      :visible.sync="dialogEditVisible"
      v-model="dialogEditVisible"
      :close-on-click-modal="false"
    >
      <el-form :model="formData" :rules="rules" ref="formView" :inline="true">
        <el-form-item label="报表编号" prop="REPORT_NO">
          <el-input
            v-model="formData.REPORT_NO"
            :disabled="dialogEditTitle=='新增'?false:true"
            placeholder="请输入报表编号"
            style="width:175px;"
          ></el-input>
        </el-form-item>
        <el-form-item label="项目名称" prop="REPORT_NAME">
          <el-input
            v-model="formData.REPORT_NAME"
            :disabled="dialogEditTitle=='新增'?false:true"
            placeholder="请输入项目名称"
            style="width:175px;"
          ></el-input>
        </el-form-item>
        <el-form-item label="分子编码" prop="NMRTR_CODE">
          <el-select
            v-model="formData.NMRTR_CODE"
            :clearable="true"
            :filterable="true"
            placeholder="请选择"
            style="width:175px;"
          >
            <el-option
              v-for="(item, index) in options"
              :key="index"
              :label="item.QC_NAME"
              :value="item.QC_CODE"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="分子编辑" prop="NMRTR_EDIT_MARK">
          <div>
            <el-switch
              v-model="formData.NMRTR_EDIT_MARK"
              :inactive-value="0"
              inactive-text="否"
              :active-value="1"
              active-text="是"
              active-color="#13ce66"
              inactive-color="#ff4949"
              style="width:175px;line-height: 20px;"
            ></el-switch>
          </div>
        </el-form-item>
        <el-form-item label="分母编码" prop="DNMTR_CODE">
          <el-select
            v-model="formData.DNMTR_CODE"
            :clearable="true"
            :filterable="true"
            placeholder="请选择"
            style="width:175px;"
          >
            <el-option
              v-for="(item, index) in options"
              :key="index"
              :label="item.QC_NAME"
              :value="item.QC_CODE"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="分母编辑" prop="DNMTR_EDIT_MARK">
          <div>
            <el-switch
              v-model="formData.DNMTR_EDIT_MARK"
              :inactive-value="0"
              inactive-text="否"
              :active-value="1"
              active-text="是"
              active-color="#13ce66"
              inactive-color="#ff4949"
              style="width:175px;line-height: 20px;"
            ></el-switch>
          </div>
        </el-form-item>
        <el-form-item label="项目分组" prop="GROUP_NO">
          <el-input
            v-model="formData.GROUP_NO"
            :maxlength="20"
            placeholder="请输入项目分组号"
            style="width:175px;"
          ></el-input>
        </el-form-item>
        <el-form-item label="是否父级" prop="FATHER_CHILD">
          <div>
            <el-switch
              v-model="formData.FATHER_CHILD"
              :inactive-value="0"
              inactive-text="否"
              :active-value="1"
              active-text="是"
              active-color="#13ce66"
              inactive-color="#ff4949"
              style="width:175px;line-height: 20px;"
            ></el-switch>
          </div>
        </el-form-item>
        <el-form-item label="项目描述" prop="DESCRIBE">
          <el-input
            type="textarea"
            :rows="2"
            v-model="formData.DESCRIBE"
            :maxlength="200"
            placeholder="请输入项目描述"
            style="width:175px;"
          ></el-input>
        </el-form-item>
        <el-form-item label="单位" prop="UNIT">
          <el-input
            v-model="formData.UNIT"
            :maxlength="20"
            placeholder="请输入项目单位"
            style="width:175px;"
          ></el-input>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button
          type="primary"
          class="quanlityReportListEditSave"
          @click="onSubmit('formView')"
        >保 存</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
        <el-button
          type="primary"
          class="quanlityReportListEditSave"
          @click="dialogEditVisible = false"
        >取 消</el-button>
      </div>
    </el-dialog>
    <div>
      <el-button type="primary" @click="addData()" class="quanlityReportListEditAdd">新增</el-button>
    </div>
    <div style="background-color: #fff;">
      <div class="report-main-top-wrapper"></div>
      <div id="dataView">
        <el-table
          :data="tableData"
          v-loading="loading"
          element-loading-text="拼命加载中"
          border
          style="width: 100%"
        >
          <el-table-column
            prop="REPORT_NO"
            header-align="center"
            align="center"
            label="报表编号"
            style="width: 5%"
            :show-overflow-tooltip="true"
          ></el-table-column>
          <el-table-column
            prop="REPORT_NAME"
            header-align="center"
            align="left"
            label="项目名称"
            style="width: 20%"
            :show-overflow-tooltip="true"
          >
            <template slot-scope="scope">
              <span
                :style="scope.row.FATHER_CHILD ===0?'margin-left:20%':'margin-left:0px'"
              >{{ scope.row.REPORT_NAME }}</span>
            </template>
          </el-table-column>
          <el-table-column
            prop="NMRTR_CODE"
            header-align="center"
            align="center"
            label="分子编码"
            style="width: 10%"
            :show-overflow-tooltip="true"
          ></el-table-column>
          <el-table-column
            prop="NMRTR_EDIT_MARK"
            header-align="center"
            align="center"
            label="分子编辑标记"
            style="width: 5%"
            :show-overflow-tooltip="true"
          >
            <template slot-scope="scope">
              <span>{{ scope.row.NMRTR_EDIT_MARK==1?"是":"否" }}</span>
            </template>
          </el-table-column>
          <el-table-column
            prop="DNMTR_CODE"
            header-align="center"
            align="center"
            label="分母编码"
            style="width: 5%"
            :show-overflow-tooltip="true"
          ></el-table-column>
          <el-table-column
            prop="DNMTR_EDIT_MARK"
            header-align="center"
            align="center"
            label="分母编辑标记"
            style="width: 5%"
            :show-overflow-tooltip="true"
          >
            <template slot-scope="scope">
              <span>{{ scope.row.DNMTR_EDIT_MARK==1?"是":"否" }}</span>
            </template>
          </el-table-column>
          <el-table-column
            prop="GROUP_NO"
            header-align="center"
            align="center"
            label="项目分组"
            style="width: 5%"
            :show-overflow-tooltip="true"
          ></el-table-column>
          <el-table-column
            prop="FATHER_CHILD"
            header-align="center"
            align="center"
            label="是否父级"
            style="width: 5%"
            :show-overflow-tooltip="true"
          >
            <template slot-scope="scope">
              <span>{{ scope.row.FATHER_CHILD==1?"是":"否" }}</span>
            </template>
          </el-table-column>
          <el-table-column
            prop="DESCRIBE"
            header-align="center"
            align="center"
            label="项目描述"
            style="width: 5%"
            :show-overflow-tooltip="true"
          ></el-table-column>
          <el-table-column
            prop="UNIT"
            header-align="center"
            align="center"
            label="单位"
            style="width: 5%"
            :show-overflow-tooltip="true"
          ></el-table-column>
          <el-table-column label="操作" align="center" fixed="right" min-width="120px">
            <template slot-scope="scope">
              <span class="czCss">
                <el-button
                  size="small"
                  class="quanlityReportListEditEdit"
                  @click="editData(scope.$index, scope.row)"
                >编辑</el-button>

                <el-button
                  size="small"
                  type="danger"
                  class="quanlityReportListEditDelete"
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
import QuanlityReportListEdit from './QuanlityReportListEdit.js'
export default QuanlityReportListEdit
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

.quanlityReportListEdit {
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

  .quanlityReportListEditAdd {
    width: 99px;
    height: 28px;
    background: rgba(61, 209, 138, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 10px 10px;
  }

  .quanlityReportListEditEdit {
    width: 59px;
    height: 28px;
    //background: #d0dfe6;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 0px;
  }

  .quanlityReportListEditDelete {
    width: 59px;
    height: 28px;
    background: #f56c6c;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 0px;
  }
  .quanlityReportListEditSave {
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
    margin-left: 30px;
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
  .quanlityReportListEdit {
    .quanlityReportListEditEdit {
      margin: 5px 2px;
    }
    .quanlityReportListEditDelete {
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
.quanlityReportListEdit .el-button {
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

.quanlityReportListEdit .el-table th {
  padding: 6px 0;
}

.quanlityReportListEdit .el-table td {
  padding: 4px 0;
}

.quanlityReportListEdit .el-input__inner {
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

.quanlityReportListEdit .el-textarea__inner {
  background-color: #f7f7f7;
  font-size: 12px;
}

.quanlityReportListEdit .el-form-item__label {
  font-size: 12px;
  font-family: MicrosoftYaHei;
  font-weight: 400;
  color: rgba(101, 101, 101, 1);
}

.quanlityReportListEdit ::-webkit-input-placeholder {
  font-style: italic;
}

@media screen and (min-aspect-ratio: 1001/1000) {
  /* 横屏 */
  .quanlityReportListEdit .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 110px;
  }
}

@media screen and (max-aspect-ratio: 1000/1000) {
  /* 竖屏 */
  .quanlityReportListEdit .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 110px;
  }
}
</style>
