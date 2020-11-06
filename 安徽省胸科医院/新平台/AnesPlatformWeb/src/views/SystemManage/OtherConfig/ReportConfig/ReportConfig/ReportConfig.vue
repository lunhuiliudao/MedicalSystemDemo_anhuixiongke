<template>
  <div class="reportconfig-wrapper">
    <el-dialog title="查询条件" :close-on-click-modal="false" :visible.sync="dialogConditionVisible">
      <ConditionConfig ref="ConditionConfig" :ReportCondition="ReportCondition"></ConditionConfig>
      <div slot="footer" class="dialog-footer">
        <el-button type="primary" class="reportconfig-wrapperSave" @click="saveReportCondition">确 定</el-button>
        <el-button
          type="primary"
          class="reportconfig-wrapperSave"
          @click="dialogConditionVisible = false"
        >取 消</el-button>
      </div>
    </el-dialog>
    <el-dialog title="表头信息" :close-on-click-modal="false" :visible.sync="dialogtColumnVisible">
      <ColumnConfig
        ref="ColumnConfig"
        :ReportColumn="ReportColumn"
        :reportInformation="reportInformation"
        :SubReportInformationList="reportInformation.SubReportInformationList"
        :isSubReport="isSubReport"
        :pkey="MainReportInformation.ReportTitle.ReportName"
      ></ColumnConfig>
      <div slot="footer">
        <el-button type="primary" class="reportconfig-wrapperSave" @click="saveReportColumn">确 定</el-button>
        <el-button
          type="primary"
          class="reportconfig-wrapperSave"
          @click="dialogtColumnVisible = false"
        >取 消</el-button>
      </div>
    </el-dialog>
    <div style="margin-left:20px;margin-bottom:5px;">
      <label style="font-weight: bolder">报表：</label>
      <el-cascader
        :options="navMenu"
        v-model="selectReport"
        clearable
        :props="cascaderProps"
        @change="changeReport"
        placeholder="请选择需要修改的报表"
        style="width:240px"
      ></el-cascader>
      <label style="font-weight: bolder">&nbsp;子报表：</label>
      <el-select v-model="selectSubReport" @change="changeSubReport" clearable>
        <el-option
          :label="item.ReportTitle.ReportName"
          :value="item.ReportTitle.ReportName"
          :key="index"
          v-for="(item,index) in MainReportInformation.SubReportInformationList"
        ></el-option>
      </el-select>
    </div>
    <div>
      <div class="report-main-top-wrapper"></div>
      <el-row style="margin: 5px 0px">
        <el-col :span="12">
          <label
            style="font-size: 14px;color: #48576a;"
          >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;是否子报表&nbsp;&nbsp;</label>
          <el-switch active-text="是" inactive-text="否" v-model="isSubReport"></el-switch>
        </el-col>
        <el-col :span="12" style="text-align:right;">
          <el-button
            type="primary"
            @click="submitReport"
            size="small"
            style="margin-right: 10px"
            class="reportconfig-wrapperAdd"
          >保 存</el-button>
          <el-button
            type="warning"
            class="reportconfig-wrapperAdd"
            @click="clearReport"
            size="small"
            style="margin-right: 10px"
          >置 空</el-button>
        </el-col>
      </el-row>
      <el-form
        style="width:80%"
        :inline="true"
        :rules="rulesReportTitle"
        ref="formReportTitle"
        :model="reportInformation.ReportTitle"
        label-width="100px"
      >
        <el-form-item label="报表名称" prop="ReportName">
          <el-input style="width:400px" v-model="reportInformation.ReportTitle.ReportName"></el-input>
        </el-form-item>
        <el-form-item label="所属菜单" prop="Menu" v-show="this.isSubReport === false">
          <el-select v-model="reportInformation.ReportTitle.Menu" placeholder="请选择所属菜单">
            <el-option
              :label="item.Key"
              :value="item.Key"
              :key="index"
              v-for="(item,index) in comStatisticsMenu()"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="排序编号">
          <el-input-number v-model="reportInformation.ReportTitle.SortNumber" :min="0" :max="100"></el-input-number>
        </el-form-item>
        <el-form-item label="每页条数">
          <el-input-number
            v-model="reportInformation.ReportTitle.PageSize"
            :min="10"
            :max="50"
            :step="5"
          ></el-input-number>
        </el-form-item>
        <el-form-item label="显示连接跳转">
          <el-switch
            active-text="是"
            inactive-text="否"
            v-model="reportInformation.ReportTitle.IsLinkButton"
          ></el-switch>
        </el-form-item>
        <el-form-item label="是否合计">
          <el-switch
            active-text="是"
            inactive-text="否"
            v-model="reportInformation.ReportTitle.ShowSummary"
          ></el-switch>
        </el-form-item>
        <el-form-item label="导出模板">
          <el-select
            size="small"
            ref="selectExeclM"
            style="width:400px;"
            v-model="execleOptions.Value"
            filterable
            clearable
            @change="changeExceleM"
            placeholder="请选择"
          >
            <el-option
              v-for="(item, index) in execleOptions"
              :key="index"
              :label="item.Key"
              :value="item.Key"
            >
              <span style="width:100%">
                {{item.Key}}
                <i
                  class="el-icon-delete el-icon--right"
                  justify-content="right"
                  v-on:click="iFun(item.Key)"
                ></i>
              </span>
            </el-option>
          </el-select>
          <el-upload
            class="upload-demo"
            action
            multiple
            :show-file-list="false"
            :on-exceed="handleExceed"
            :http-request="upLoadTemplate"
          >
            <el-button
              slot="trigger"
              class="reportconfig-wrapperAdd"
              size="small"
              type="primary"
            >点击模板上传</el-button>
            <el-button
              style="margin-left: 10px;"
              size="small"
              type="success"
              class="reportconfig-wrapperAdd"
              @click="downLoad()"
            >点击模板下载</el-button>
          </el-upload>
        </el-form-item>
        <el-form-item label="SQL语句" prop="StrSql">
          <el-input
            type="textarea"
            style="width:100%;min-width:700px;"
            :rows="4"
            v-model="reportInformation.ReportTitle.StrSql"
          ></el-input>
        </el-form-item>
      </el-form>
    </div>
    <div>
      <div class="report-main-top-wrapper"></div>
      <el-row style="text-align:right;margin: 5px 0px" v-if="isSubReport===false">
        <el-button
          type="primary"
          style="margin-right: 10px"
          class="reportconfig-wrapperAdd"
          size="small"
          @click="showDialogCondition(0,null)"
        >添加查询条件</el-button>
      </el-row>
      <el-table
        :data="reportInformation.ReportConditionList"
        border
        v-if="isSubReport===false"
        style="width: 100%;margin-bottom: 5px"
      >
        <el-table-column type="expand">
          <template slot-scope="props">
            <el-form class="demo-table-expand">
              <el-form-item label="字典类型：">
                <span>{{ props.row.DictType }}</span>
                <span>（表名：{{ props.row.DynamicDictDes==null?'':props.row.DynamicDictDes.TableName }}、&nbsp; 值：{{ props.row.DynamicDictDes==null?'':props.row.DynamicDictDes.KeyColumn }}、&nbsp; 显示文本：{{ props.row.DynamicDictDes==null?'':props.row.DynamicDictDes.ValColumn }}、&nbsp; 查询条件：{{props.row.DynamicDictDes==null?'':props.row.DynamicDictDes.Condition }}）&nbsp;</span>
              </el-form-item>
              <el-form-item label="时间控件类型：">
                <span>{{ props.row.DateControlType }}、&nbsp; 时间控件默认值：{{ props.row.DateDefaultVal }}&nbsp;</span>
              </el-form-item>
              <el-form-item label="自定义字典数据：">
                <span
                  :key="index"
                  v-for="(item,index) in props.row.BindDict"
                >{{ item.Key+' —— '+ item.Value }}&nbsp;</span>
              </el-form-item>
            </el-form>
          </template>
        </el-table-column>
        <el-table-column label="标题" prop="Title"></el-table-column>
        <el-table-column label="控件类型" prop="ControlType"></el-table-column>
        <el-table-column label="字段名" prop="FieldName"></el-table-column>
        <el-table-column label="数据类型" prop="DataType"></el-table-column>
        <el-table-column label="默认值" prop="Value"></el-table-column>
        <el-table-column label="操作">
          <template slot-scope="scope">
            <el-button
              size="small"
              type="primary"
              icon="el-icon-edit"
              class="reportconfig-wrapperEdit"
              @click="showDialogCondition(scope.$index, scope.row)"
            ></el-button>
            <el-button
              size="small"
              type="danger"
              icon="el-icon-minus"
              class="reportconfig-wrapperDelete"
              @click="deleteReportCondition(scope.$index, scope.row)"
            ></el-button>
          </template>
        </el-table-column>
      </el-table>
    </div>
    <div>
      <div class="report-main-top-wrapper"></div>
      <el-row style="text-align:right;margin: 5px 0px">
        <el-button
          type="primary"
          style="margin-right: 10px"
          class="reportconfig-wrapperAdd"
          size="small"
          @click="addReportSubCondition"
        >添加附属条件</el-button>
      </el-row>
      <el-table
        :data="reportInformation.ReportSubConditionList"
        border
        style="width: 100%;margin-bottom: 5px"
      >
        <el-table-column label="字段名" v-if="isSubReport">
          <template slot-scope="scope">
            <el-select v-model="scope.row.FieldName">
              <el-option
                :label="item.value"
                :value="item.key"
                :key="index"
                v-for="(item,index) in comParentReportColumnList"
              ></el-option>
            </el-select>
          </template>
        </el-table-column>
        <el-table-column label="参数名称">
          <template slot-scope="scope">
            <el-input v-model="scope.row.ParamName"></el-input>
          </template>
        </el-table-column>
        <el-table-column label="数据类型">
          <template slot-scope="scope">
            <el-select v-model="scope.row.DataType">
              <el-option label="String" value="String"></el-option>
              <el-option label="DateTime" value="DateTime"></el-option>
              <el-option label="Int" value="Int"></el-option>
              <el-option label="Double" value="Double"></el-option>
              <el-option label="Bool" value="Bool"></el-option>
            </el-select>
          </template>
        </el-table-column>
        <el-table-column label="值">
          <template slot-scope="scope">
            <el-input v-model="scope.row.Value"></el-input>
          </template>
        </el-table-column>
        <el-table-column label="操作">
          <template slot-scope="scope">
            <el-button
              size="small"
              type="danger"
              icon="el-icon-minus"
              class="reportconfig-wrapperDelete"
              @click="deleteReportSubCondition(scope.$index, scope.row)"
            ></el-button>
          </template>
        </el-table-column>
      </el-table>
    </div>
    <div>
      <div class="report-main-top-wrapper"></div>
      <el-row style="text-align:right;margin: 5px 0px">
        <el-button
          type="primary"
          style="margin-right: 10px"
          class="reportconfig-wrapperAdd"
          size="small"
          @click="showDialogColumn(null,null)"
        >添加表头</el-button>
      </el-row>
      <el-tree
        :data="reportInformation.ReportColumnList"
        class="treeReportConfig"
        draggable
        :props="defaultProps"
        node-key="Title"
        default-expand-all
        :expand-on-click-node="false"
        :render-content="renderContent"
      ></el-tree>
    </div>
    <div>
      <div class="report-main-top-wrapper"></div>
      <el-row style="margin: 10px 10px;">
        <el-col :span="3" style="line-height:30px;height:30px;text-align:center;">图表类型：</el-col>
        <el-col :span="17">
          <el-select
            v-model="reportInformation.ReportChartInfo.ChartType"
            clearable
            placeholder="请选择图表类型"
          >
            <el-option label="柱状" value="Bar"></el-option>
            <el-option label="折线" value="Line"></el-option>
            <el-option label="饼图" value="Pie"></el-option>
          </el-select>
        </el-col>
        <el-col :span="4" style="text-align:right;">
          <el-button
            type="primary"
            class="reportconfig-wrapperAdd"
            size="small"
            @click="addReportChartSeriesDataSet"
          >添加图表数据</el-button>
        </el-col>
      </el-row>
      <el-table
        :data="reportInformation.ReportChartInfo.SeriesData"
        border
        style="width: 100%;margin-bottom: 5px;"
      >
        <el-table-column label="字段名">
          <template slot-scope="scope">
            <el-select v-model="scope.row.Field">
              <el-option
                :label="item.value"
                :value="item.key"
                :key="index"
                v-for="(item,index) in comReportColumnList"
              ></el-option>
            </el-select>
          </template>
        </el-table-column>
        <el-table-column label="名称">
          <template slot-scope="scope">
            <el-input v-model="scope.row.Title"></el-input>
          </template>
        </el-table-column>
        <el-table-column label="操作">
          <template slot-scope="scope">
            <el-button
              size="small"
              type="danger"
              icon="el-icon-minus"
              class="reportconfig-wrapperDelete"
              @click="deleteReportChartSeriesDataSet(scope.$index, scope.row)"
            ></el-button>
          </template>
        </el-table-column>
      </el-table>
      <el-row class="X轴Class" style="margin-bottom: 10px;margin-top:10px;">
        <el-col :span="3" style="line-height:40px;height:40px;text-align:center;">X轴配置：</el-col>
        <el-col :span="2" style="margin-right:20px;">
          <el-select v-model="reportInformation.ReportChartInfo.XAxisInfo.Type" placeholder="请选择">
            <el-option label="数字" value="value"></el-option>
            <el-option label="文字" value="category"></el-option>
          </el-select>
        </el-col>
        <el-col :span="4" style="margin-right:20px;">
          <el-select v-model="reportInformation.ReportChartInfo.XAxisInfo.DataColumn" clearable>
            <el-option
              :label="item.value"
              :value="item.key"
              :key="index"
              v-for="(item,index) in comReportColumnList"
            ></el-option>
          </el-select>
        </el-col>
        <el-col :span="13">
          <el-select
            v-model="reportInformation.ReportChartInfo.XAxisInfo.Data"
            style="width:98%;"
            filterable
            default-first-option
            multiple
            allow-create
          ></el-select>
        </el-col>
      </el-row>
      <el-row class="Y轴Class" style="margin-bottom: 10px;margin-top:10px;">
        <el-col :span="3" style="line-height:40px;height:40px;text-align:center;">Y轴配置：</el-col>
        <el-col :span="2" style="margin-right:20px;">
          <el-select v-model="reportInformation.ReportChartInfo.YAxisInfo.Type" placeholder="请选择">
            <el-option label="数字" value="value"></el-option>
            <el-option label="文字" value="category"></el-option>
          </el-select>
        </el-col>
        <el-col :span="4" style="margin-right:20px;">
          <el-select v-model="reportInformation.ReportChartInfo.YAxisInfo.DataColumn" clearable>
            <el-option
              :label="item.value"
              :value="item.key"
              :key="index"
              v-for="(item,index) in comReportColumnList"
            ></el-option>
          </el-select>
        </el-col>
        <el-col :span="13">
          <el-select
            v-model="reportInformation.ReportChartInfo.YAxisInfo.Data"
            style="width:98%"
            filterable
            default-first-option
            multiple
            allow-create
          ></el-select>
        </el-col>
      </el-row>
    </div>
  </div>
</template>

<script>
import ReportConfig from './ReportConfig.js'
export default ReportConfig
</script>

<style lang="scss" scoped>
.reportconfig-wrapper {
  margin-top: 5px;
  padding: 10px 0px;
  background-color: #ffffff;
  font-size: 14px;
  color: #606266;
  .report-main-top-wrapper {
    height: 2px;
    background: linear-gradient(
      90deg,
      rgba(36, 197, 240, 1),
      rgba(103, 245, 184, 1)
    );
  }
  .reportconfig-wrapperAdd {
    width: 99px;
    height: 28px;
    background: rgba(61, 209, 138, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 0px 0px 10px;
  }

  .reportconfig-wrapperEdit {
    width: 59px;
    height: 28px;
    background: rgba(0, 188, 241, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .reportconfig-wrapperDelete {
    width: 59px;
    height: 28px;
    background: #f56c6c;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .reportconfig-wrapperSave {
    width: 99px;
    height: 28px;
    background: rgba(0, 188, 241, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 0px 0px 10px;
  }
  .dialog-footer {
    text-align: center;
  }
}
</style>
<style>
.treeReportConfig .el-tree-node__content {
  height: 35px;
}

.reportconfig-wrapper .el-input__inner {
  height: 30px;
}

.reportconfig-wrapper .el-input__icon {
  line-height: 26px;
}

.reportconfig-wrapper .el-cascader-menu__item:focus:not(:active),
.el-cascader-menu__item:hover {
  background-color: #e0e1e4;
}

.reportconfig-wrapper .el-select-dropdown__item.hover,
.el-select-dropdown__item:hover {
  background-color: #e0e1e4;
}

.reportconfig-wrapper .el-input-number {
  line-height: 28px;
}

.reportconfig-wrapper .el-select {
  height: 30px;
}

.reportconfig-wrapper .el-table th {
  padding: 6px 0;
}

.reportconfig-wrapper .el-table td {
  padding: 4px 0;
}

.X轴Class .el-input__inner {
  height: 40px;
}

.Y轴Class .el-input__inner {
  height: 40px;
}

.reportconfig-wrapper .el-button {
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

.treeReportConfig .el-button {
  background: rgba(0, 188, 241, 1);
  min-width: 59px;
}

.reportconfig-wrapper .el-input__inner {
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
  padding: 0 30px;
  -webkit-transition: border-color 0.2s cubic-bezier(0.645, 0.045, 0.355, 1);
  transition: border-color 0.2s cubic-bezier(0.645, 0.045, 0.355, 1);
  width: 100%;
  font-size: 12px;
}

.reportconfig-wrapper .el-textarea__inner {
  background-color: #f7f7f7;
  font-size: 12px;
}

.reportconfig-wrapper ::-webkit-input-placeholder {
  font-style: italic;
}
</style>
