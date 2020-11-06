<template>
  <div class="outLiquidEditDiv">
    <el-dialog
      :title="dialogEditTitle"
      :visible.sync="dialogEditVisible"
      :close-on-click-modal="false"
    >
      <el-form :model="formData" :rules="rules" ref="formView" :inline="true">
        <el-form-item label="代码" prop="EVENT_ITEM_CODE">
          <el-input v-model="formData.EVENT_ITEM_CODE" :disabled="true" style="width:175px;"></el-input>
        </el-form-item>
        <el-form-item label="名称" prop="EVENT_ITEM_NAME">
          <el-input
            v-model="formData.EVENT_ITEM_NAME"
            :maxlength="30"
            placeholder="请输入出液名称"
            style="width:175px;"
          ></el-input>
        </el-form-item>
        <el-form-item label="规格">
          <el-input v-model="formData.EVENT_ITEM_SPEC" style="width:175px;"></el-input>
        </el-form-item>
        <el-form-item label="默认剂量">
          <el-input-number v-model="formData.DOSAGE" style="width:175px;"></el-input-number>
        </el-form-item>
        <el-form-item label="剂量单位">
          <el-select
            v-model="formData.DOSAGE_UNITS"
            filterable
            placeholder="请选择"
            style="width:175px"
          >
            <el-option
              style="font-size:14px;padding:0px 5px;"
              v-for="(item,index) in medUnitsList"
              :key="index"
              :label="item.UNIT_NAME"
              :value="item.UNIT_NAME"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="属性">
          <el-select
            v-model="formData.EVENT_ATTR"
            filterable
            placeholder="请选择属性"
            style="width:175px"
          >
            <el-option
              style="font-size:14px;padding:0px 5px;"
              v-for="item in eventAttrList"
              :key="item.ITEM_CODE"
              :label="item.ITEM_NAME"
              :value="item.ITEM_CODE"
            ></el-option>
          </el-select>
          <!-- <el-input v-model="formData.EVENT_ATTR" :maxlength="20" placeholder="请输入属性"></el-input> -->
        </el-form-item>
        <el-form-item label="排序">
          <el-input-number v-model="formData.SORT_NO" :min="0" :max="10000" style="width:175px;"></el-input-number>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button type="primary" class="outLiquidEditDivSave" @click="onSubmit('formView')">保 存</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
        <el-button
          type="primary"
          class="outLiquidEditDivSave"
          @click="dialogEditVisible = false"
        >取 消</el-button>
      </div>
    </el-dialog>
    <div id="conditionView">
      <div style="margin:10px 10px 0px;height:26px">
        <div class="conditionName">名称：</div>
        <div style="width:200px;float:left">
          <el-input v-model="itemName" style="width:200px"></el-input>
        </div>
        <div>
          <el-button type="primary" class="outLiquidEditDivAdd" @click="searchData(1)">查询</el-button>
          <el-button type="primary" class="outLiquidEditDivAdd" @click="addData">新增</el-button>
        </div>
      </div>
    </div>
    <div style="background-color: #fff;min-height:600px;">
      <div class="report-main-top-wrapper"></div>
      <div>
        <el-table
          :data="paginationInfo.currentData"
          v-loading="loading"
          element-loading-text="拼命加载中"
          border
          style="width: 100%"
        >
          <el-table-column prop="EVENT_ITEM_CODE" header-align="center" align="center" label="代码"></el-table-column>
          <el-table-column prop="EVENT_ITEM_NAME" header-align="center" align="center" label="名称"></el-table-column>
          <el-table-column prop="EVENT_ITEM_SPEC" header-align="center" align="center" label="规格"></el-table-column>
          <el-table-column prop="DOSAGE" header-align="center" align="center" label="默认剂量"></el-table-column>
          <el-table-column prop="DOSAGE_UNITS" header-align="center" align="center" label="剂量单位"></el-table-column>
          <el-table-column prop="EVENT_ATTR" header-align="center" align="center" label="属性"></el-table-column>
          <el-table-column prop="SORT_NO" header-align="center" align="center" label="排序"></el-table-column>
          <el-table-column label="操作" align="center" min-width="120px">
            <template slot-scope="scope">
              <span class="czCss">
                <el-button
                  size="small"
                  class="outLiquidEditDivEdit"
                  @click="editData(scope.$index, scope.row)"
                >编辑</el-button>
                <el-button
                  size="small"
                  class="outLiquidEditDivDelete"
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
import OutLiquidEdit from './OutLiquidEdit.js'
export default OutLiquidEdit
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

.outLiquidEditDiv {
  margin-top: 5px;
  padding: 10px 0px;
  background-color: #f5f9fb;
  font-size: 14px;
  color: #606266;
  min-height: 768px;
  .outLiquidEditDivAdd {
    width: 99px;
    height: 28px;
    background: rgba(61, 209, 138, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 0px 0px 10px;
  }

  .outLiquidEditDivEdit {
    width: 59px;
    height: 28px;
    //background: #d0dfe6;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .outLiquidEditDivDelete {
    width: 59px;
    height: 28px;
    background: #f56c6c;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .outLiquidEditDivSave {
    width: 99px;
    height: 28px;
    background: rgba(0, 188, 241, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 0px 0px 10px;
  }

  .report-main-top-wrapper {
    height: 2px;
    margin-top: 15px;
    background: linear-gradient(
      90deg,
      rgba(36, 197, 240, 1),
      rgba(103, 245, 184, 1)
    );
  }

  .czCss {
    display: flex;
    flex-direction: row;
    margin-left: 0px;
  }

  .conditionName {
    width: 50px;
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
  .outLiquidEditDiv {
    .outLiquidEditDivEdit {
      margin: 5px 2px;
    }
    .outLiquidEditDivDelete {
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
.outLiquidEditDiv .el-input__inner {
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
.outLiquidEditDiv .el-input__icon {
  line-height: 25px;
}
.outLiquidEditDiv .el-button {
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

.outLiquidEditDiv .el-table th {
  padding: 6px 0;
}

.outLiquidEditDiv .el-table td {
  padding: 4px 0;
}

.outLiquidEditDiv .el-input-number {
  line-height: 24px;
}

.outLiquidEditDiv .el-select-dropdown__list {
  padding: 0px 10px;
}

.outLiquidEditDiv ::-webkit-input-placeholder {
  font-style: italic;
}

@media screen and (min-aspect-ratio: 1001/1000) {
  /* 横屏 */
  .outLiquidEditDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 200px;
  }
}

@media screen and (max-aspect-ratio: 1000/1000) {
  /* 竖屏 */
  .outLiquidEditDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 110px;
  }
}
</style>
