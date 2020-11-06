<template>
  <div class="monitorDictDiv">
    <el-dialog
      width="60%"
      :title="dialogEditTitle"
      :visible.sync="dialogEditVisible"
      :close-on-click-modal="false"
    >
      <el-form :model="formData" :rules="rules" ref="formView" :inline="true">
        <el-form-item label="监护仪标识" prop="MONITOR_LABEL">
          <el-input
            v-model="formData.MONITOR_LABEL"
            placeholder="请输入监护仪标识"
            :disabled="wayType===1?true:false"
            style="width:200px"
          ></el-input>
        </el-form-item>
        <el-form-item label="厂家">
          <el-input
            v-model="formData.MANU_FIRM_NAME"
            :disabled="wayType===1?true:false"
            style="width:200px"
          ></el-input>
        </el-form-item>
        <el-form-item label="型号">
          <el-input v-model="formData.MODEL" :disabled="wayType===1?true:false" style="width:200px"></el-input>
        </el-form-item>
        <el-form-item label="接口类型">
          <!-- <el-input v-model="formData.INTERFACE_TYPE"></el-input> -->
          <el-select
            v-model="formData.INTERFACE_TYPE"
            clearable
            placeholder="请选择接口类型"
            :disabled="wayType===1?true:false"
            style="width:200px"
          >
            <el-option
              style="font-size:14px;padding:0px 5px;"
              v-for="(item, index) in comTypeList"
              :key="index"
              :label="item.label"
              :value="item.value"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="IP地址">
          <el-input
            v-model="formData.IP_ADDR"
            @blur="IpValidate(formData.IP_ADDR)"
            style="width:200px"
          ></el-input>
        </el-form-item>
        <el-form-item label="通讯串口">
          <el-input v-model="formData.COMM_PORT" style="width:200px"></el-input>
        </el-form-item>
        <el-form-item label="采集程序">
          <el-input v-model="formData.DRIVER_PROG" style="width:200px"></el-input>
        </el-form-item>
        <el-form-item label="仪器分类">
          <!-- <el-input v-model="formData.ITEM_TYPE"></el-input> -->
          <el-select
            v-model="formData.ITEM_TYPE"
            clearable
            placeholder="请选择仪器分类"
            :disabled="wayType===1?true:false"
            style="width:200px"
          >
            <el-option
              style="font-size:14px;padding:0px 5px;"
              v-for="(item, index) in mathionTypeList"
              :key="index"
              :label="item.label"
              :value="item.value"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="必采项">
          <el-input v-model="formData.CURRENT_RECV_ITEMS" style="width:200px"></el-input>
        </el-form-item>
        <el-form-item label="科室代码">
          <el-input v-model="formData.WARD_CODE" style="width:200px"></el-input>
        </el-form-item>
        <el-form-item label="科室类型" v-show="false">
          <!-- <el-input v-model="formData.WARD_TYPE"></el-input> -->
          <el-select
            v-model="formData.WARD_TYPE"
            clearable
            placeholder="请选择科室类型"
            style="width:200px"
          >
            <el-option
              style="font-size:14px;padding:0px 5px;"
              v-for="(titem, tindex) in deptTypeList"
              :key="tindex"
              :label="titem.ITEM_NAME"
              :value="titem.ITEM_NAME"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="床号(手术间)">
          <el-select
            v-model="formData.BED_NO"
            clearable
            filterable
            remote
            placeholder="请选择床号(手术间)"
            :remote-method="roomNoRemoteMethod"
            style="width:200px"
          >
            <el-option
              style="font-size:14px;padding:0px 5px;"
              v-for="(item, index) in roomNoList"
              :key="index"
              :label="item.ROOM_NO"
              :value="item.ROOM_NO"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="PC端口号">
          <el-input v-model="formData.PC_PORT" style="width:200px"></el-input>
        </el-form-item>
        <el-form-item label="默认采集频率">
          <el-input v-model="formData.DEFAULT_RECV_FREQUENCY" style="width:200px"></el-input>
        </el-form-item>
        <el-form-item label="当前采集频率">
          <el-input v-model="formData.CURRENT_RECV_FREQUENCY" style="width:200px"></el-input>
        </el-form-item>
        <el-form-item label="状态">
          <el-select
            v-model="formData.DATALOG_STATUS"
            clearable
            placeholder="请选择状态"
            style="width:200px"
          >
            <el-option
              style="font-size:14px;padding:0px 5px;"
              v-for="(item, index) in statusList"
              :key="index"
              :label="item.label"
              :value="item.value"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="备注">
          <el-input v-model="formData.MEMO" style="width:200px"></el-input>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button type="primary" class="monitorDictDivSave" @click="onSubmit('formView')">保 存</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
        <el-button type="primary" class="monitorDictDivSave" @click="dialogEditVisible = false">取 消</el-button>
      </div>
    </el-dialog>
    <div id="conditionView">
      <div style="margin:10px 10px 0px;height:36px">
        <div class="conditionName">设备名称：</div>
        <div style="width:220px;float:left">
          <el-select
            v-model="monitorName"
            clearable
            filterable
            remote
            placeholder="请选择设备名称"
            :remote-method="monitorNameRemoteMethod"
            style="width:220px"
          >
            <el-option
              style="font-size:14px;padding:0px 5px;"
              v-for="(item, index) in monitorNameList"
              :key="index"
              :label="item.MODEL"
              :value="item.MONITOR_LABEL"
            >
              <span style="float: left">{{ item.MODEL }}</span>
              <span
                style="float: right; color: #8492a6; font-size: 13px;margin-left:10px;"
              >{{ item.MONITOR_LABEL }}</span>
            </el-option>
          </el-select>
        </div>
        <div>
          <el-button type="primary" class="monitorDictDivAdd" @click="searchData(1)">查询</el-button>
          <el-button type="primary" class="monitorDictDivAdd" v-show="false" @click="addData">新增</el-button>
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
          <el-table-column
            prop="MONITOR_LABEL"
            header-align="center"
            align="center"
            label="监护仪标识"
            show-overflow-tooltip
          ></el-table-column>
          <el-table-column
            prop="MANU_FIRM_NAME"
            header-align="center"
            align="center"
            label="厂家"
            width="180"
            show-overflow-tooltip
          ></el-table-column>
          <el-table-column
            prop="MODEL"
            header-align="center"
            align="center"
            label="型号"
            width="180"
            show-overflow-tooltip
          ></el-table-column>
          <el-table-column
            prop="INTERFACE_TYPE"
            header-align="center"
            align="center"
            label="接口类型"
            show-overflow-tooltip
          ></el-table-column>
          <el-table-column
            prop="IP_ADDR"
            header-align="center"
            align="center"
            label="IP地址"
            width="180"
            show-overflow-tooltip
          ></el-table-column>
          <el-table-column
            prop="COMM_PORT"
            header-align="center"
            align="center"
            label="通讯串口"
            show-overflow-tooltip
          ></el-table-column>
          <el-table-column
            prop="DRIVER_PROG"
            header-align="center"
            align="center"
            label="采集程序"
            width="180"
            show-overflow-tooltip
          ></el-table-column>
          <el-table-column
            prop="ITEM_TYPE"
            header-align="center"
            align="center"
            label="仪器分类"
            show-overflow-tooltip
          ></el-table-column>
          <el-table-column
            prop="CURRENT_RECV_ITEMS"
            header-align="center"
            align="center"
            label="必采项"
            show-overflow-tooltip
          ></el-table-column>
          <el-table-column
            prop="WARD_CODE"
            header-align="center"
            align="center"
            label="科室代码"
            show-overflow-tooltip
          ></el-table-column>
          <el-table-column
            prop="WARD_TYPE"
            header-align="center"
            align="center"
            label="科室类型"
            show-overflow-tooltip
          ></el-table-column>
          <el-table-column
            prop="BED_NO"
            header-align="center"
            align="center"
            label="床号(手术间)"
            show-overflow-tooltip
          ></el-table-column>
          <el-table-column
            prop="PC_PORT"
            header-align="center"
            align="center"
            label="PC端口号"
            show-overflow-tooltip
          ></el-table-column>
          <el-table-column
            prop="DEFAULT_RECV_FREQUENCY"
            header-align="center"
            align="center"
            label="默认采集频率"
            show-overflow-tooltip
          ></el-table-column>
          <el-table-column
            prop="CURRENT_RECV_FREQUENCY"
            header-align="center"
            align="center"
            label="当前采集频率"
            show-overflow-tooltip
          ></el-table-column>
          <el-table-column
            prop="DATALOG_STATUS"
            header-align="center"
            align="center"
            label="状态"
            show-overflow-tooltip
          ></el-table-column>
          <el-table-column
            prop="MEMO"
            header-align="center"
            align="center"
            label="备注"
            show-overflow-tooltip
          ></el-table-column>
          <el-table-column label="操作" width="140" align="center" fixed="right">
            <template slot-scope="scope">
              <span class="czCss">
                <el-button
                  size="small"
                  class="monitorDictDivEdit"
                  @click="editData(scope.$index, scope.row)"
                >编辑</el-button>
              </span>
              <span v-show="false">
                <el-button
                  size="small"
                  class="monitorDictDivDelete"
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
import MonitorDict from './MonitorDict.js'
export default MonitorDict
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

.monitorDictDiv {
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
  .monitorDictDivAdd {
    width: 99px;
    height: 28px;
    background: rgba(61, 209, 138, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 0px 0px 10px;
  }

  .monitorDictDivSave {
    width: 99px;
    height: 28px;
    background: rgba(0, 188, 241, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 0px 0px 10px;
  }

  .monitorDictDivEdit {
    width: 50px;
    height: 28px;
    //background: #d0dfe6;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 0px;
  }

  .monitorDictDivDelete {
    width: 50px;
    height: 28px;
    background: #f56c6c;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 0px;
  }
  .czCss {
    display: flex;
    flex-direction: row;
    margin-left: 35px;
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
  .monitorDictDiv {
    .monitorDictDivEdit {
      margin: 5px 1px;
    }
    .monitorDictDivDelete {
      margin: 5px 1px;
    }
    .czCss {
      margin-left: 40px;
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
.monitorDictDiv .el-input__inner {
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
.monitorDictDiv .el-input__icon {
  line-height: 25px;
}
.monitorDictDiv .el-button {
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

.monitorDictDiv .el-table th {
  padding: 6px 0;
}

.monitorDictDiv .el-table td {
  padding: 4px 0;
}

.monitorDictDiv .el-input-number {
  line-height: 24px;
}

.monitorDictDiv .el-form-item__label {
  font-size: 12px;
  font-family: MicrosoftYaHei;
  font-weight: 400;
  color: rgba(101, 101, 101, 1);
}

.monitorDictDiv ::-webkit-input-placeholder {
  font-style: italic;
}

@media screen and (min-aspect-ratio: 1001/1000) {
  /* 横屏 */
  .monitorDictDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 140px;
  }
}

@media screen and (max-aspect-ratio: 1000/1000) {
  /* 竖屏 */
  .monitorDictDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 120px;
  }
}
</style>
