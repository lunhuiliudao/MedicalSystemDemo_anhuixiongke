<template>
  <div class="monitorFunctionCodeDiv">
    <el-dialog
      :title="dialogEditTitle"
      :visible.sync="dialogEditVisible"
      :close-on-click-modal="false"
    >
      <el-form :model="formData" :rules="rules" ref="formView" :inline="true">
        <el-form-item label="生命体征代码" prop="ITEM_CODE">
          <el-input
            v-model="formData.ITEM_CODE"
            :maxlength="10"
            placeholder="请输入生命体征代码"
            :disabled="wayType===1?true:false"
          ></el-input>
        </el-form-item>
        <el-form-item label="生命体征名称" prop="ITEM_NAME">
          <el-input
            v-model="formData.ITEM_NAME"
            :maxlength="20"
            placeholder="请输入生命体征名称"
            :disabled="wayType===1?true:false"
          ></el-input>
        </el-form-item>
        <el-form-item label="单位">
          <el-input v-model="formData.ITEM_UNIT"></el-input>
        </el-form-item>
        <!-- <el-form-item label="显示颜色">
                    <el-input v-model="formData.DIS_COLOR"></el-input>
                    <el-color-picker v-model="formData.DIS_COLOR" style="width:200px;"></el-color-picker>
                </el-form-item>
                <el-form-item label="显示图标">
                    <el-input v-model="formData.DRAW_ICON"></el-input>
        </el-form-item>-->
        <el-form-item label="备注">
          <el-input v-model="formData.MEMO"></el-input>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button
          type="primary"
          class="monitorFunctionCodeDivSave"
          @click="onSubmit('formView')"
        >保 存</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
        <el-button
          type="primary"
          class="monitorFunctionCodeDivSave"
          @click="dialogEditVisible = false"
        >取 消</el-button>
      </div>
    </el-dialog>
    <div id="conditionView">
      <div style="margin:10px 10px 0px;height:26px">
        <div class="conditionName">生命体征名称：</div>
        <div style="width:180px;float:left">
          <el-input v-model="itemName" style="width:180px"></el-input>
          <!-- <el-select v-model="itemName" clearable filterable remote placeholder="请选择生命体征" :remote-method="itemNameRemoteMethod">
                        <el-option v-for="(item, index) in itemNameList" :key="index" :label="item.ITEM_NAME" :value="item.ITEM_CODE">
                            <span style="float: left">{{ item.ITEM_NAME }}</span>
                            <span style="float: right; color: #8492a6; font-size: 13px;margin-left:10px;">{{ item.ITEM_CODE }}</span>
                        </el-option>
          </el-select>-->
        </div>
        <div>
          <el-button type="primary" class="monitorFunctionCodeDivAdd" @click="searchData(1)">查询</el-button>
          <el-button type="primary" class="monitorFunctionCodeDivAdd" @click="addData">新增</el-button>
        </div>
      </div>
    </div>
    <div style="background-color: #fff;">
      <div class="report-main-top-wrapper"></div>
      <div>
        <el-table
          :data="paginationInfo.currentData"
          v-loading="loading"
          element-loading-text="拼命加载中"
          border
          style="width: 100%"
        >
          <el-table-column prop="ITEM_CODE" header-align="center" align="center" label="诊断代码"></el-table-column>
          <el-table-column prop="ITEM_NAME" header-align="center" align="center" label="诊断名称"></el-table-column>
          <el-table-column prop="ITEM_UNIT" header-align="center" align="center" label="诊断单位"></el-table-column>
          <!-- <el-table-column prop="DIS_COLOR" header-align="center" align="center" label="显示颜色">
                    <el-color-picker v-model="paginationInfo.currentData.DIS_COLOR"></el-color-picker>
                </el-table-column>
          <el-table-column prop="DRAW_ICON" header-align="center" align="center" label="显示图标"></el-table-column>-->
          <el-table-column prop="MEMO" header-align="center" align="center" label="备注"></el-table-column>
          <el-table-column label="操作" align="center">
            <template slot-scope="scope">
              <span class="czCss">
                <el-button
                  size="small"
                  class="monitorFunctionCodeDivEdit"
                  @click="editData(scope.$index, scope.row)"
                >编辑</el-button>
                <el-button
                  size="small"
                  class="monitorFunctionCodeDivDelete"
                  type="danger"
                  @click="deleteData(scope.$index, scope.row)"
                >删除</el-button>
              </span>
            </template>
          </el-table-column>
        </el-table>
      </div>
      <div id="PaginationView">
        <el-pagination
          :current-page="paginationInfo.currentPage"
          :page-size="paginationInfo.pageSize"
          layout="total, prev, pager, next"
          :total="paginationInfo.total"
          @current-change="handleCurrentChange"
        ></el-pagination>
      </div>
    </div>
  </div>
</template>

<script>
import MonitorFunctionCode from './MonitorFunctionCode.js'
export default MonitorFunctionCode
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

.monitorFunctionCodeDiv {
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
  .monitorFunctionCodeDivAdd {
    width: 99px;
    height: 28px;
    background: rgba(61, 209, 138, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 0px 0px 10px;
  }

  .monitorFunctionCodeDivEdit {
    width: 59px;
    height: 28px;
    //background: #d0dfe6;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .monitorFunctionCodeDivDelete {
    width: 59px;
    height: 28px;
    background: #f56c6c;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .monitorFunctionCodeDivSave {
    width: 99px;
    height: 28px;
    background: rgba(0, 188, 241, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 0px 0px 10px;
  }
  .czCss {
    display: flex;
    flex-direction: row;
    margin-left: 50px;
  }

  .conditionName {
    width: 100px;
    float: left;
    text-align: right;
    height: 26px;
    line-height: 26px;
    font-weight: bolder;
  }
}

@media screen and (min-aspect-ratio: 1001/1000) {
  // 横屏
}

@media screen and (max-aspect-ratio: 1000/1000) {
  // 竖屏
  .monitorFunctionCodeDiv {
    .monitorFunctionCodeDivEdit {
      margin: 5px 2px;
    }
    .monitorFunctionCodeDivDelete {
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
.monitorFunctionCodeDiv .el-input__inner {
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
.monitorFunctionCodeDiv .el-input__icon {
  line-height: 25px;
}
.monitorFunctionCodeDiv .el-button {
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

.monitorFunctionCodeDiv .el-table th {
  padding: 6px 0;
}

.monitorFunctionCodeDiv .el-table td {
  padding: 4px 0;
}

.monitorFunctionCodeDiv .el-input-number {
  line-height: 24px;
}

.monitorFunctionCodeDiv .el-form-item__label {
  font-size: 12px;
  font-family: MicrosoftYaHei;
  font-weight: 400;
  color: rgba(101, 101, 101, 1);
}

.monitorFunctionCodeDiv ::-webkit-input-placeholder {
  font-style: italic;
}

@media screen and (min-aspect-ratio: 1001/1000) {
  /* 横屏 */
  .monitorFunctionCodeDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 210px;
  }
}

@media screen and (max-aspect-ratio: 1000/1000) {
  /* 竖屏 */
  .monitorFunctionCodeDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 120px;
  }
}
</style>
