<template>
  <div class="hisuserdictdiv">
    <el-dialog
      :title="dialogEditTitle"
      :visible.sync="dialogEditVisible"
      :close-on-click-modal="false"
    >
      <el-form :model="formData" :rules="rules" ref="formView" :inline="true">
        <el-form-item label="用户工号" prop="USER_JOB_ID">
          <el-input
            v-model="formData.USER_JOB_ID"
            :maxlength="10"
            placeholder="请输入用户工号"
            :disabled="wayType===1?true:false"
            style="width:175px"
          ></el-input>
        </el-form-item>
        <el-form-item label="用户姓名" prop="USER_NAME">
          <el-input
            v-model="formData.USER_NAME"
            :maxlength="20"
            placeholder="请输入用户姓名"
            style="width:175px"
          ></el-input>
        </el-form-item>
        <el-form-item label="所在科室">
          <el-select
            v-model="formData.USER_DEPT_CODE"
            clearable
            filterable
            placeholder="请选择"
            style="width:175px"
          >
            <el-option
              style="font-size:14px;padding:0px 5px;"
              v-for="(item, index) in medDeptDictList"
              :key="index"
              :label="item.DEPT_NAME"
              :value="item.DEPT_CODE"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="用户类别">
          <el-select v-model="formData.USER_JOB" placeholder="请选择" style="width:175px">
            <el-option
              style="font-size:14px;padding:0px 5px;"
              v-for="(uitem, uindex) in userTypeList"
              :key="uindex"
              :label="uitem.ITEM_NAME"
              :value="uitem.ITEM_NAME"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="输入码">
          <el-input v-model="formData.INPUT_CODE" style="width:175px"></el-input>
        </el-form-item>
        <el-form-item label="是否启用">
          <el-switch
            v-model="formData.USER_STATUS"
            :active-value="1"
            :inactive-value="0"
            active-color="#13ce66"
            inactive-color="#ff4949"
            active-text="已启用"
            inactive-text="未启用"
            style="width:175px;line-height:26px;"
          ></el-switch>
        </el-form-item>
        <el-form-item label="排序">
          <el-input-number v-model="formData.SORT_NO" :min="0" :max="10000" style="width:175px"></el-input-number>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button type="primary" class="hisuserdictdivSave" @click="onSubmit('formView')">保 存</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
        <el-button type="primary" class="hisuserdictdivSave" @click="dialogEditVisible = false">取 消</el-button>
      </div>
    </el-dialog>
    <div class="conditionView">
      <div class="condition">
        <div class="conditionDiv">
          <div class="conditionName">用户姓名：</div>
          <div style="width:140px;float:left">
            <el-input v-model="userName" style="width:140px"></el-input>
          </div>
        </div>
        <div class="conditionDiv">
          <div class="conditionDept">科室：</div>
          <div style="width:140px;float:left">
            <el-select
              v-model="DEPT_NAME"
              clearable
              filterable
              remote
              placeholder="请输入科室"
              :remote-method="deptNameRemoteMethod"
            >
              <el-option
                style="font-size:14px;padding:0px 0px 0px 5px;"
                v-for="(item, index) in deptNameList"
                :key="index"
                :label="item.Value"
                :value="item.Value"
              ></el-option>
            </el-select>
          </div>
        </div>
        <div
          class="conditionDiv mdsdCheckBoxNoBorder"
          style="line-height:24px;margin-left:15px;margin-right:5px;"
        >
          <el-checkbox
            v-model="userStatus"
            :true-label="1"
            :false-label="0"
            @change="userStatusChanged()"
          >是否启用</el-checkbox>
        </div>
        <div class="conditionDiv">
          <el-button type="primary" class="hisuserdictdivAdd" @click="searchData(1)">查询</el-button>
          <el-button type="primary" class="hisuserdictdivAdd" @click="addData">新增</el-button>
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
          <el-table-column prop="USER_JOB_ID" header-align="center" align="center" label="用户工号"></el-table-column>
          <el-table-column prop="USER_NAME" header-align="center" align="center" label="用户姓名"></el-table-column>
          <el-table-column prop="USER_DEPT_NAME" header-align="center" align="center" label="所在科室"></el-table-column>
          <el-table-column prop="USER_JOB" header-align="center" align="center" label="用户类别"></el-table-column>
          <el-table-column prop="INPUT_CODE" header-align="center" align="center" label="输入码"></el-table-column>
          <el-table-column prop="SORT_NO" header-align="center" align="center" label="排序"></el-table-column>
          <el-table-column label="操作" align="center" min-width="120px">
            <template slot-scope="scope">
              <span class="czCss">
                <el-button
                  size="small"
                  class="hisuserdictdivEdit"
                  @click="editData(scope.$index, scope.row)"
                >编辑</el-button>
                <el-button
                  size="small"
                  type="danger"
                  class="hisuserdictdivDelete"
                  v-show="userStatus===1"
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
import HisUserDict from './HisUserDict.js'
export default HisUserDict
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

.hisuserdictdiv {
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

  .hisuserdictdivAdd {
    width: 99px;
    height: 28px;
    background: rgba(61, 209, 138, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 0px 0px 10px;
  }

  .hisuserdictdivEdit {
    width: 59px;
    height: 28px;
    //background: #d0dfe6;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .hisuserdictdivDelete {
    width: 59px;
    height: 28px;
    background: #f56c6c;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .hisuserdictdivSave {
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

  .condition {
    margin: 10px 10px 10px;
    height: 26px;
    display: flex;
    flex-wrap: wrap;
  }

  .conditionDiv {
    margin: 5px 0;
  }

  .conditionName {
    width: 70px;
    float: left;
    text-align: right;
    height: 26px;
    line-height: 26px;
    font-weight: bolder;
    margin-left: 40px;
  }

  .conditionDept {
    width: 50px;
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
  .hisuserdictdiv {
    .hisuserdictdivEdit {
      margin: 5px 2px;
    }
    .hisuserdictdivDelete {
      margin: 5px 2px;
    }
    .czCss {
      margin-left: 0px;
    }
    .conditionName {
      margin-left: 10px;
    }
    .conditionDept {
      margin-left: 10px;
    }
    .conditionView {
      height: 60px;
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
.hisuserdictdiv .el-input__inner {
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
.hisuserdictdiv .el-input__icon {
  line-height: 25px;
}
.hisuserdictdiv .el-button {
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

.hisuserdictdiv .el-table th {
  padding: 6px 0;
}

.hisuserdictdiv .el-table td {
  padding: 4px 0;
}

.hisuserdictdiv .el-input-number {
  line-height: 24px;
}

.hisuserdictdiv .el-form-item__label {
  font-size: 12px;
  font-family: MicrosoftYaHei;
  font-weight: 400;
  color: rgba(101, 101, 101, 1);
}

.hisuserdictdiv ::-webkit-input-placeholder {
  font-style: italic;
}

@media screen and (min-aspect-ratio: 1001/1000) {
  /* 横屏 */
  .hisuserdictdiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 200px;
  }
}

@media screen and (max-aspect-ratio: 1000/1000) {
  /* 竖屏 */
  .hisuserdictdiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 110px;
  }
}
</style>
