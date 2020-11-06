<template>
  <div class="deptdictdiv">
    <el-dialog
      :title="dialogEditTitle"
      :visible.sync="dialogEditVisible"
      :close-on-click-modal="false"
    >
      <el-form :model="formData" :rules="rules" ref="formView" :inline="true">
        <el-form-item label="科室代码" prop="DEPT_CODE">
          <el-input
            v-model="formData.DEPT_CODE"
            :maxlength="10"
            placeholder="请输入科室代码"
            :disabled="wayType===1?true:false"
            style="width:175px"
          ></el-input>
        </el-form-item>
        <el-form-item label="科室名称" prop="DEPT_NAME">
          <el-input
            v-model="formData.DEPT_NAME"
            :maxlength="20"
            placeholder="请输入科室名称"
            style="width:175px"
          ></el-input>
        </el-form-item>
        <el-form-item label="别名">
          <el-input v-model="formData.DEPT_ALIAS" style="width:175px"></el-input>
        </el-form-item>
        <el-form-item label="科室类别">
          <el-select v-model="formData.DEPT_TYPE" placeholder="请选择" style="width:175px">
            <el-option
              style="font-size:14px;padding:0px 5px;"
              v-for="(titem, tindex) in deptTypeList"
              :key="tindex"
              :label="titem.ITEM_NAME"
              :value="titem.ITEM_NAME"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="输入码">
          <el-input v-model="formData.INPUT_CODE" style="width:175px"></el-input>
        </el-form-item>
        <el-form-item label="排序">
          <el-input-number v-model="formData.SORT_NO" :min="0" :max="10000" style="width:175px"></el-input-number>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button type="primary" class="deptdictdivSave" @click="onSubmit('formView')">保 存</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
        <el-button type="primary" class="deptdictdivSave" @click="dialogEditVisible = false">取 消</el-button>
      </div>
    </el-dialog>
    <div id="conditionView">
      <div style="margin:10px 10px 0px 0px ;height:26px;">
        <div class="conditionDept">科室名称：</div>
        <div style="width:180px;float:left">
          <!-- <el-select v-model="deptName" clearable filterable remote placeholder="请输入科室" :remote-method="deptNameRemoteMethod">
            <el-option v-for="(item, index) in deptNameList" :key="index" :label="item.Value" :value="item.Value">
            </el-option>
          </el-select>-->
          <el-input v-model="deptName" style="width:180px;" placeholder="请输入科室"></el-input>
        </div>
        <div>
          <el-button type="primary" @click="searchData(1)" class="deptdictdivAdd">查询</el-button>
          <el-button type="primary" @click="addData" class="deptdictdivAdd">新增</el-button>
        </div>
      </div>
    </div>
    <div style="background-color: #fff;">
      <div class="report-main-top-wrapper"></div>

      <div id="dataView">
        <el-table
          :data="paginationInfo.currentData"
          v-loading="loading"
          element-loading-text="拼命加载中"
          border
          style="width: 100%"
        >
          <el-table-column prop="DEPT_CODE" header-align="center" align="center" label="科室代码"></el-table-column>
          <el-table-column prop="DEPT_NAME" header-align="center" align="center" label="科室名称"></el-table-column>
          <el-table-column prop="DEPT_ALIAS" header-align="center" align="center" label="别名"></el-table-column>
          <el-table-column prop="DEPT_TYPE" header-align="center" align="center" label="科室类别"></el-table-column>
          <el-table-column prop="INPUT_CODE" header-align="center" align="center" label="输入码"></el-table-column>
          <el-table-column prop="SORT_NO" header-align="center" align="center" label="排序"></el-table-column>
          <el-table-column label="操作" align="center" min-width="120px">
            <template slot-scope="scope">
              <span class="czCss">
                <el-button
                  size="small"
                  class="deptdictdivEdit"
                  @click="editData(scope.$index, scope.row)"
                >编辑</el-button>
                <el-button
                  size="small"
                  type="danger"
                  class="deptdictdivDelete"
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
import DeptDict from './DeptDict.js'
export default DeptDict
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

.deptdictdiv {
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
  .deptdictdivAdd {
    width: 99px;
    height: 28px;
    background: rgba(61, 209, 138, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 0px 0px 10px;
  }

  .deptdictdivEdit {
    width: 59px;
    height: 28px;
    //background: #d0dfe6;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .deptdictdivDelete {
    width: 59px;
    height: 28px;
    background: #f56c6c;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .deptdictdivSave {
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
    margin-left: 15px;
  }

  .conditionDept {
    width: 120px;
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
  .deptdictdiv {
    .deptdictdivEdit {
      margin: 5px 2px;
    }
    .deptdictdivDelete {
      margin: 5px 2px;
    }
    .czCss {
      margin-left: 0px;
    }
    .conditionDept {
      width: 70px;
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
.deptdictdiv .el-input__inner {
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
.deptdictdiv .el-input__icon {
  line-height: 25px;
}
.deptdictdiv .el-button {
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

.deptdictdiv .el-table th {
  padding: 6px 0;
}

.deptdictdiv .el-table td {
  padding: 4px 0;
}

.deptdictdiv .el-input-number {
  line-height: 24px;
}

.deptdictdiv .el-form-item__label {
  font-size: 12px;
  font-family: MicrosoftYaHei;
  font-weight: 400;
  color: rgba(101, 101, 101, 1);
}

.deptdictdiv ::-webkit-input-placeholder {
  font-style: italic;
}

@media screen and (min-aspect-ratio: 1001/1000) {
  /* 横屏 */
  .deptdictdiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    min-width: 200px;
  }
}

@media screen and (max-aspect-ratio: 1000/1000) {
  /* 竖屏 */
  .deptdictdiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 110px;
  }
}
</style>
