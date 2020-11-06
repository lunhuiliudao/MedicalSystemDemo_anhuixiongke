<template>
  <div class="vitalSignsConfigDiv">
    <div style="margin-top:20px;margin-bottom:20px;">
      <el-button
        type="primary"
        class="vitalSignsConfigDivAdd"
        v-on:click="addInfos()"
        v-if="!editFlag"
      >
        <i class="el-icon-add el-icon--left"></i>新增
      </el-button>
    </div>
    <el-dialog
      :title="dialogEditTitle"
      :visible.sync="dialogEditVisible"
      v-model="dialogEditVisible"
      :close-on-click-modal="false"
    >
      <el-form :model="formData" :rules="rules" ref="formView" :inline="true">
        <el-form-item label="名称" prop="CurveCode">
          <el-select
            v-model="formData.CurveCode"
            :disabled="dialogEditTitle=='新增'?false:true"
            placeholder="请下拉选择"
            @change="setCurveName(formData)"
            filterable
            clearable
            allow-create
            remote
            :remote-method="remoteCurveName"
          >
            <el-option
              style="font-size:14px;padding:0 5px;"
              v-for="(item,index) in MonitorFunctionCodeList"
              :key="index"
              :label="item.ITEM_NAME"
              :value="item.ITEM_CODE"
            >
              <span style="float: left">{{ item.ITEM_NAME }}</span>
              <span style="float: right; font-size: 13px">{{ item.ITEM_CODE }}</span>
            </el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="是否显示" prop="Visible" class="mdsdCheckBoxNoBorder">
          <el-checkbox v-model="formData.Visible" true-label="True" false-label="False"></el-checkbox>
        </el-form-item>
        <el-form-item label="显示类型" prop="ShowType">
          <el-select v-model="formData.ShowType" placeholder="请选择">
            <el-option
              style="font-size:14px;padding:0 5px;"
              v-for="item in ShowTypeList"
              :key="item.value"
              :label="item.label"
              :value="item.value"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="图标" prop="SymbolType">
          <el-select v-model="formData.SymbolType" placeholder="请选择">
            <el-option
              style="font-size:14px;padding:0 5px;"
              v-for="item in SymbolTypeList"
              :key="item.value"
              :label="item.label"
              :value="item.value"
            >
              <span style="float: left">{{ item.label }}</span>
              <span style="float: right; font-size: 13px">{{ item.value }}</span>
            </el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="颜色" prop="Color">
          <el-select v-model="formData.Color" placeholder="请选择">
            <el-option
              style="font-size:14px;padding:0 5px;"
              v-for="(item,index) in ColorItemList"
              :key="index"
              :label="item"
              :value="item"
            >
              <span style="float: left; font-size: 13px">{{ item }}</span>
              <span
                :style="{'background-color':item,float: 'right'}"
              >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
            </el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="时间间隔" prop="ShowTimeInterval">
          <el-select v-model="formData.ShowTimeInterval" placeholder="请选择">
            <el-option
              style="font-size:14px;padding:0 5px;"
              v-for="item in ShowTimeIntervalList"
              :key="item.value"
              :label="item.label"
              :value="item.value"
            ></el-option>
          </el-select>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button type="primary" class="vitalSignsConfigDivSave" @click="onSubmit('formView')">保 存</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
        <el-button
          type="primary"
          class="vitalSignsConfigDivSave"
          @click="dialogEditVisible = false"
        >取 消</el-button>
      </div>
    </el-dialog>
    <div style="background-color: #fff;min-height:600px;">
      <div class="report-main-top-wrapper"></div>
      <el-table :data="tableData" border style="width: 100%;">
        <el-table-column prop="CurveName" label="名称" min-width="10%" align="center">
          <template slot-scope="scope">
            <span>{{ scope.row.CurveName }}</span>
          </template>
        </el-table-column>
        <el-table-column prop="Visible" label="是否显示" min-width="10%" align="center">
          <template slot-scope="scope">
            <span>{{ convertIsShow(scope.row.Visible) }}</span>
          </template>
        </el-table-column>
        <el-table-column prop="ShowType" label="显示类型" min-width="10%">
          <template slot-scope="scope">
            <span>{{ convertShowType(scope.row.ShowType) }}</span>
          </template>
        </el-table-column>
        <el-table-column prop="SymbolType" label="图标" min-width="10%">
          <template slot-scope="scope">
            <span>{{ convertSymbolType(scope.row.SymbolType) }}</span>
          </template>
        </el-table-column>
        <el-table-column prop="Color" label="颜色" min-width="10%">
          <template slot-scope="scope">
            <div
              :style="{'background-color':scope.row.Color,'width':'50%'}"
            >&nbsp;&nbsp;&nbsp;&nbsp;</div>
          </template>
        </el-table-column>
        <el-table-column prop="ShowTimeInterval" label="时间间隔" min-width="10%">
          <template slot-scope="scope">
            <span>{{ convertShowTimeInterval(scope.row.ShowTimeInterval) }}</span>
          </template>
        </el-table-column>
        <el-table-column label="操作" align="center" min-width="10%">
          <template slot-scope="scope">
            <span class="czCss">
              <el-button
                class="vitalSignsConfigDivEdit"
                @click="editInfos(scope.$index, scope.row)"
              >编辑</el-button>

              <el-button
                class="vitalSignsConfigDivDelete"
                type="danger"
                @click="deleteInfos(scope.$index, scope.row)"
              >删除</el-button>
            </span>
          </template>
        </el-table-column>
      </el-table>
    </div>
  </div>
</template>

<script>
import VitalSignsConfig from './VitalSignsConfig.js'
export default VitalSignsConfig
</script>
<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

.vitalSignsConfigDiv {
  margin-top: 5px;
  padding: 10px 0px;
  background-color: #f5f9fb;
  font-size: 14px;
  color: #606266;
  min-height: 768px;
  .vitalSignsConfigDivAdd {
    width: 99px;
    height: 28px;
    background: rgba(61, 209, 138, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 0px 0px 10px;
  }

  .vitalSignsConfigDivEdit {
    width: 59px;
    height: 28px;
    //background: #d0dfe6;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .vitalSignsConfigDivDelete {
    width: 59px;
    height: 28px;
    background: #f56c6c;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .vitalSignsConfigDivSave {
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
    margin-left: 15px;
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
  .vitalSignsConfigDiv {
    .vitalSignsConfigDivEdit {
      margin: 5px 2px;
    }
    .vitalSignsConfigDivDelete {
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
</style>
<style>
.vitalSignsConfigDiv .el-input__inner {
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
.vitalSignsConfigDiv .el-input__icon {
  line-height: 25px;
}
.vitalSignsConfigDiv .el-button {
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

.vitalSignsConfigDiv .el-table th {
  padding: 6px 0;
}

.vitalSignsConfigDiv .el-table td {
  padding: 4px 0;
}

.vitalSignsConfigDiv .el-input-number {
  line-height: 24px;
}

.vitalSignsConfigDiv .el-select-dropdown__list {
  padding: 0px 10px;
}

.vitalSignsConfigDiv ::-webkit-input-placeholder {
  font-style: italic;
}

@media screen and (min-aspect-ratio: 1001/1000) {
  /* 横屏 */
  .vitalSignsConfigDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 200px;
  }
}

@media screen and (max-aspect-ratio: 1000/1000) {
  /* 竖屏 */
  .vitalSignsConfigDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 110px;
  }
}
</style>
