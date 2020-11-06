<template>
  <div class="operatingRoomDiv">
    <el-dialog
      :title="dialogEditTitle"
      :visible.sync="dialogEditVisible"
      :close-on-click-modal="false"
    >
      <el-form :model="formData" :rules="rules" ref="formView" :inline="true">
        <el-form-item label="手术间号" prop="ROOM_NO">
          <el-input
            v-model="formData.ROOM_NO"
            :maxlength="10"
            placeholder="请输入手术间号"
            :disabled="wayType===1?true:false"
            style="width:175px;"
          ></el-input>
        </el-form-item>
        <el-form-item label="所属科室">
          <el-select
            v-model="formData.DEPT_CODE"
            filterable
            :filter-method="filterDept"
            placeholder="请选择"
            style="width:175px"
          >
            <el-option
              style="font-size:14px;padding:0px 5px;"
              v-for="item in medDeptDictList"
              :key="item.DEPT_CODE"
              :label="item.DEPT_NAME"
              :value="item.DEPT_CODE"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="手术间所在地" prop="LOCATION">
          <el-input
            v-model="formData.LOCATION"
            :maxlength="20"
            placeholder="请输入简称"
            style="width:175px;"
          ></el-input>
        </el-form-item>
        <el-form-item label="床位标号">
          <el-input v-model="formData.BED_LABEL" style="width:175px;"></el-input>
        </el-form-item>
        <el-form-item label="床位类型">
          <!-- <el-input v-model="formData.BED_TYPE"></el-input> -->
          <el-select v-model="formData.BED_TYPE" placeholder="请选择" style="width:175px">
            <el-option
              style="font-size:14px;padding:0px 5px;"
              v-for="item in bedTypeName"
              :key="item.value"
              :label="item.label"
              :value="item.value"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="状态">
          <!-- <el-input v-model="formData.STATUS"></el-input> -->
          <el-select v-model="formData.STATUS" placeholder="请选择" style="width:175px">
            <el-option
              style="font-size:14px;padding:0px 5px;"
              v-for="item in statusName"
              :key="item.value"
              :label="item.label"
              :value="item.value"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="排序">
          <el-input-number v-model="formData.SORT_NO" :min="0" :max="10000" style="width:175px;"></el-input-number>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button type="primary" class="operatingRoomDivSave" @click="onSubmit('formView')">保 存</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
        <el-button
          type="primary"
          class="operatingRoomDivSave"
          @click="dialogEditVisible = false"
        >取 消</el-button>
      </div>
    </el-dialog>
    <div id="conditionView">
      <div style="margin:10px 10px 0px;height:26px">
        <div class="conditionName">手术间号：</div>
        <div style="width:180px;float:left">
          <!-- <el-input v-model="roomNo" style="width:150px"></el-input> -->
          <el-select
            v-model="roomNo"
            clearable
            filterable
            remote
            placeholder="请输入手术间号"
            :remote-method="roomNoRemoteMethod"
            style="width:180px;"
          >
            <el-option
              style="font-size:14px;padding:0px 10px;"
              v-for="(item, index) in roomNoList"
              :key="index"
              :label="item.ROOM_NO"
              :value="item.ROOM_NO"
            ></el-option>
          </el-select>
        </div>
        <div>
          <el-button type="primary" class="operatingRoomDivAdd" @click="searchData(1)">查询</el-button>
          <el-button type="primary" class="operatingRoomDivAdd" @click="addData">新增</el-button>
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
          <el-table-column prop="ROOM_NO" header-align="center" align="center" label="手术间号"></el-table-column>
          <el-table-column prop="DEPT_NAME" header-align="center" align="center" label="所属科室"></el-table-column>
          <el-table-column prop="LOCATION" header-align="center" align="center" label="手术间所在地"></el-table-column>
          <el-table-column prop="BED_LABEL" header-align="center" align="center" label="床位标号"></el-table-column>
          <el-table-column prop="BED_TYPE_NAME" header-align="center" align="center" label="床位类型"></el-table-column>
          <el-table-column prop="STATUS_NAME" header-align="center" align="center" label="状态"></el-table-column>
          <el-table-column prop="SORT_NO" header-align="center" align="center" label="排序"></el-table-column>
          <el-table-column label="操作" align="center" min-width="120px">
            <template slot-scope="scope">
              <span class="czCss">
                <el-button
                  size="small"
                  class="operatingRoomDivEdit"
                  @click="editData(scope.$index, scope.row)"
                >编辑</el-button>
                <el-button
                  size="small"
                  type="danger"
                  class="operatingRoomDivDelete"
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
import OperatingRoom from './OperatingRoom.js'
export default OperatingRoom
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

.operatingRoomDiv {
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
  .operatingRoomDivAdd {
    width: 99px;
    height: 28px;
    background: rgba(61, 209, 138, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 0px 0px 10px;
  }

  .operatingRoomDivEdit {
    width: 59px;
    height: 28px;
    //background: #d0dfe6;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .operatingRoomDivDelete {
    width: 59px;
    height: 28px;
    background: #f56c6c;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .operatingRoomDivSave {
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
    margin-left: 5px;
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
  .operatingRoomDiv {
    .operatingRoomDivEdit {
      margin: 5px 1px;
    }
    .operatingRoomDivDelete {
      margin: 5px 1px;
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

#funView {
  clear: both;
  text-align: right;
}

#dataView {
  margin-top: 5px;
}

#PaginationView {
  text-align: center;
}
</style>
<style>
.operatingRoomDiv .el-input__inner {
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
.operatingRoomDiv .el-input__icon {
  line-height: 25px;
}
.operatingRoomDiv .el-button {
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

.operatingRoomDiv .el-table th {
  padding: 6px 0;
}

.operatingRoomDiv .el-table td {
  padding: 4px 0;
}

.operatingRoomDiv .el-input-number {
  line-height: 24px;
}

.operatingRoomDiv .el-form-item__label {
  font-size: 12px;
  font-family: MicrosoftYaHei;
  font-weight: 400;
  color: rgba(101, 101, 101, 1);
}

.operatingRoomDiv ::-webkit-input-placeholder {
  font-style: italic;
}

@media screen and (min-aspect-ratio: 1001/1000) {
  /* 横屏 */
  .operatingRoomDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 200px;
  }
}

@media screen and (max-aspect-ratio: 1000/1000) {
  /* 竖屏 */
  .operatingRoomDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 110px;
  }
}
</style>
