<template>
    <el-form :model="ReportColumn" :rules="rules" ref="formColumnConfig" label-width="100px">
        <el-form-item label="标题" prop="Title">
            <el-input v-model="ReportColumn.Title"></el-input>
        </el-form-item>
        <!--<el-form-item label="字段名" prop="FieldName">
            <el-input v-model="ReportColumn.FieldName"></el-input>
        </el-form-item>-->
        <el-form-item label="字段名" prop="FieldName">
            <!--<el-input v-model="ReportColumn.FieldName"></el-input>-->
            <el-select  size="small" ref="selectExeclM" style="width:80%" v-model="ReportColumn.FieldName" filterable clearable @change="changeSelect" placeholder="请选择">
                <el-option v-for="(item, index) in dataList" :key="index" :label="item" :value="item">
                </el-option>
            </el-select>
        </el-form-item>

        <el-form-item label="宽度">
            <el-input-number v-model="ReportColumn.Width" :min="0" :max="200"></el-input-number>
        </el-form-item>
        <el-form-item label="对齐方式">
            <el-select v-model="ReportColumn.Align">
                <el-option label="left" value="left"></el-option>
                <el-option label="center" value="center"></el-option>
                <el-option label="right" value="right"></el-option>
            </el-select>
        </el-form-item>
        <el-form-item label="">
            <el-checkbox v-model="ReportColumn.IsSHow">显示表头</el-checkbox>
        </el-form-item>
        <el-form-item label="">
            <el-checkbox v-model="ReportColumn.IsSort">是否可排序</el-checkbox>
        </el-form-item>
        <el-form-item label="">
            <el-checkbox v-model="ReportColumn.IsSum">是否合计列</el-checkbox>
        </el-form-item>
        <el-form-item label="">
            <el-checkbox v-model="ReportColumn.IsSubReportCondition">是否子报表查询条件</el-checkbox>
        </el-form-item>
        <el-form-item label="子报表" v-if="ReportColumn.IsSubReportCondition===true" prop="SubReportName">
            <el-select v-model="ReportColumn.SubReportName" clearable>
                <el-option :label="item.ReportTitle.ReportName" :value="item.ReportTitle.ReportName" :key="index" v-for="(item,index) in SubReportInformationList"></el-option>
            </el-select>
        </el-form-item>
        <el-form-item label="">
            <el-checkbox v-model="ReportColumn.IsExport">是否需要导出该列</el-checkbox>
        </el-form-item>
    </el-form>
</template>

<script>
import ColumnConfig from './ColumnConfig.js'
export default ColumnConfig
</script>

<style scoped>

</style>
