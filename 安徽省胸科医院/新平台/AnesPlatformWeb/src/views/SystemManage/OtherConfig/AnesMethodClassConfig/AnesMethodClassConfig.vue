<template>
  <div class="anesMethodClassConfigDiv">
    <el-dialog title="添加项目" :close-on-click-modal="false" :visible.sync="dialogVisible">
      <el-form :model="formData" ref="formView">
        <el-form-item label="类别码" prop="ITEM_TYPE">
          <el-input
            v-model="formData.ITEM_TYPE"
            :disabled="formData.ITEM_PARENTID!==0?true:false"
            class="inputCss"
          ></el-input>
        </el-form-item>
        <el-form-item label="名称填写">
          <el-switch
            v-model="dialogHasSelect"
            inactive-text="手动输入"
            active-text="下拉选择"
            active-color="#13ce66"
            inactive-color="#ff4949"
            :disabled="dialogIsSwitch"
            class="inputCss"
            style="line-height:20px;"
          ></el-switch>
        </el-form-item>
        <el-form-item label="名称" prop="ITEM_VALUE" v-if="!dialogHasSelect">
          <el-input v-model="formData.ITEM_VALUE" class="inputCss"></el-input>
        </el-form-item>
        <el-form-item label="名称" prop="TEMP_ITEM_VALUE" v-if="dialogHasSelect">
          <el-select
            v-model="formData.TEMP_ITEM_VALUE"
            multiple
            filterable
            class="inputCss"
            placeholder="请选择"
          >
            <el-option
              style="font-size:14px;line-height:20px;padding:0px 0px 0px 6px;"
              v-for="item in dialogSelectOptions"
              :key="item"
              :label="item"
              :value="item"
            ></el-option>
          </el-select>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button type="primary" class="anesMethodClassConfigDivSave" @click="saveReportColumn">确 定</el-button>
        <el-button
          type="primary"
          class="anesMethodClassConfigDivSave"
          @click="dialogVisible = false"
        >取 消</el-button>
      </div>
    </el-dialog>
    <el-row style="margin-top: 5px;margin-bottom: 15px;">
      <el-button
        type="primary"
        class="anesMethodClassConfigDivAdd"
        style="margin-right: 10px;width:150px;"
        @click="showDialog(newData())"
      >添加顶层类别</el-button>
    </el-row>
    <div style="background-color: #fff;min-height:600px;">
      <div class="report-main-top-wrapper"></div>
      <el-tree
        class="treeClass"
        :data="ConfigList"
        :highlight-current="true"
        :accordion="true"
        :props="defaultProps"
        node-key="id"
        :default-expand-all="false"
        :expand-on-click-node="true"
        :render-content="renderContent"
      ></el-tree>
    </div>
  </div>
</template>

<script>
import AnesMethodClassConfig from './AnesMethodClassConfig.js'
export default AnesMethodClassConfig
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

.anesMethodClassConfigDiv {
  margin-top: 5px;
  padding: 10px 0px;
  background-color: #f5f9fb;
  font-size: 14px;
  color: #606266;
  min-height: 768px;
  .anesMethodClassConfigDivAdd {
    width: 99px;
    height: 28px;
    background: rgba(61, 209, 138, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 10px;
  }

  .anesMethodClassConfigDivSave {
    width: 99px;
    height: 28px;
    background: rgba(0, 188, 241, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 10px;
  }

  .inputCss {
    width: 60%;
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
  .anesMethodClassConfigDiv {
    .inputCss {
      width: 250px;
    }
  }
}

.dialog-footer {
  text-align: center;
}
</style>

<style >
.anesMethodClassConfigDiv .el-input__inner {
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
.anesMethodClassConfigDiv .el-input__icon {
  line-height: 25px;
}
.anesMethodClassConfigDiv .el-button {
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

.treeClass .el-tree-node__content:hover {
  background-color: #e0e4e6;
}

.treeClass .el-button--small {
  background: rgba(61, 209, 138, 1);
  width: 50px;
}

.treeClass .el-button--danger {
  color: #fff;
  background-color: #f56c6c;
  border-color: #f56c6c;
  width: 50px;
  margin-right: 5px;
}

.treeClass .el-button--success.is-active,
.el-button--success:active {
  background: rgba(61, 209, 138, 1);
  border-color: rgba(61, 209, 138, 1);
  color: #fff;
}

.anesMethodClassConfigDiv .el-tree-node__content {
  height: 35px;
  line-height: 35px;
  margin-left: 2%;
  cursor: hand;
}

.anesMethodClassConfigDiv .el-tree-node__expand-icon {
  content: url(../../../../assets/images/yjt.png);
}

.anesMethodClassConfigDiv .el-input-number {
  line-height: 24px;
}

.anesMethodClassConfigDiv .el-select-dropdown__list {
  padding: 0px 10px;
}

.anesMethodClassConfigDiv ::-webkit-input-placeholder {
  font-style: italic;
}

@media screen and (min-aspect-ratio: 1001/1000) {
  /* 横屏 */
  .anesMethodClassConfigDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 20%;
  }
}

@media screen and (max-aspect-ratio: 1000/1000) {
  /* 竖屏 */
  .anesMethodClassConfigDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 60px;
  }
}
</style>
