<template>
  <div class="anesInputDictDiv">
    <el-dialog
      :title="dialogEditTitle"
      :visible.sync="dialogEditVisible"
      :close-on-click-modal="false"
    >
      <el-form :model="formData" :rules="rules" ref="formView" :inline="true">
        <el-form-item label="项目类别" prop="ITEM_CLASS">
          <el-input
            v-model="formData.ITEM_CLASS"
            :maxlength="10"
            placeholder="请输入项目类别"
            :disabled="wayType===1?true:false"
            style="width:175px"
          ></el-input>
        </el-form-item>
        <el-form-item label="项目名称" prop="ITEM_NAME">
          <el-input
            v-model="formData.ITEM_NAME"
            :maxlength="20"
            placeholder="请输入项目名称"
            :disabled="wayType===1?true:false"
            style="width:175px"
          ></el-input>
        </el-form-item>
        <el-form-item label="项目代码">
          <el-input v-model="formData.ITEM_CODE" style="width:175px"></el-input>
        </el-form-item>
        <el-form-item label="输入码">
          <el-input v-model="formData.INPUT_CODE" style="width:175px"></el-input>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button type="primary" class="anesInputDictDivSave" @click="onSubmit('formView')">保 存</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
        <el-button
          type="primary"
          class="anesInputDictDivSave"
          @click="dialogEditVisible = false"
        >取 消</el-button>
      </div>
    </el-dialog>
    <div id="conditionView">
      <div style="margin:10px 10px 0px;height:26px">
        <div class="conditionName">项目类别：</div>
        <div style="width:180px;float:left">
          <el-select v-model="itemClass" clearable filterable placeholder="请选择" style="width:180px">
            <el-option
              style="font-size:14px;padding:0px 0px 0px 5px;"
              v-for="item in anesInputDictItemClassList"
              :key="item"
              :label="item"
              :value="item"
            ></el-option>
          </el-select>
        </div>
        <div>
          <el-button type="primary" @click="searchData(1)" class="anesInputDictDivAdd">查询</el-button>
          <el-button type="primary" @click="addData" class="anesInputDictDivAdd">新增</el-button>
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
          <el-table-column prop="ITEM_CLASS" header-align="center" align="center" label="项目类别"></el-table-column>
          <el-table-column prop="ITEM_NAME" header-align="center" align="center" label="项目名称"></el-table-column>
          <el-table-column prop="ITEM_CODE" header-align="center" align="center" label="项目代码"></el-table-column>
          <el-table-column prop="INPUT_CODE" header-align="center" align="center" label="输入码"></el-table-column>
          <el-table-column label="操作" align="center">
            <template slot-scope="scope">
              <span class="czCss">
                <el-button
                  size="small"
                  class="anesInputDictDivEdit"
                  @click="editData(scope.$index, scope.row)"
                >编辑</el-button>
                <el-button
                  size="small"
                  class="anesInputDictDivDelete"
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
import AnesInputDict from './AnesInputDict.js'
export default AnesInputDict
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

.anesInputDictDiv {
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
  .anesInputDictDivAdd {
    width: 99px;
    height: 28px;
    background: rgba(61, 209, 138, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 0px 0px 10px;
  }

  .anesInputDictDivEdit {
    width: 59px;
    height: 28px;
    //background: #d0dfe6;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .anesInputDictDivDelete {
    width: 59px;
    height: 28px;
    background: #f56c6c;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .anesInputDictDivSave {
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
  .anesInputDictDiv {
    .anesInputDictDivEdit {
      margin: 5px 2px;
    }
    .anesInputDictDivDelete {
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
.anesInputDictDiv .el-input__inner {
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
.anesInputDictDiv .el-input__icon {
  line-height: 25px;
}
.anesInputDictDiv .el-button {
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

.anesInputDictDiv .el-table th {
  padding: 6px 0;
}

.anesInputDictDiv .el-table td {
  padding: 4px 0;
}

.anesInputDictDiv .el-input-number {
  line-height: 24px;
}

.anesInputDictDiv .el-select-dropdown__list {
  padding: 0px 10px;
}

.anesInputDictDiv .el-form-item__label {
  font-size: 12px;
  font-family: MicrosoftYaHei;
  font-weight: 400;
  color: rgba(101, 101, 101, 1);
}

.anesInputDictDiv ::-webkit-input-placeholder {
  font-style: italic;
}

@media screen and (min-aspect-ratio: 1001/1000) {
  /* 横屏 */
  .anesInputDictDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 200px;
  }
}

@media screen and (max-aspect-ratio: 1000/1000) {
  /* 竖屏 */
  .anesInputDictDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 110px;
  }
}
</style>
