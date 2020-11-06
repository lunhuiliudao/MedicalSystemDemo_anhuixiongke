<template>
    <el-form :model="ReportCondition" :rules="rules" ref="formConditionConfig" label-width="100px">
        <el-form-item label="标题"  prop="Title">
            <el-input v-model="ReportCondition.Title"></el-input>
        </el-form-item>
        <el-form-item label="控件类型" prop="ControlType">
            <el-select v-model="ReportCondition.ControlType">
                <el-option label="DatePick" value="DatePick"></el-option>
                <el-option label="TextBox" value="TextBox"></el-option>
                <el-option label="CheckBox" value="CheckBox"></el-option>
                <el-option label="DropDownList" value="DropDownList"></el-option>
            </el-select>
        </el-form-item>
        <el-form-item v-if="ReportCondition.ControlType==='DatePick'">
            <el-row>
                <el-col :span="4">时间类型：</el-col>
                <el-col :span="4">
                    <el-select v-model="ReportCondition.DateControlType">
                        <el-option label="date" value="date"></el-option>
                        <el-option label="year" value="year"></el-option>
                        <el-option label="month" value="month"></el-option>
                        <!-- edit by 20181116 -->
                        <el-option label="datetime" value="datetime"></el-option>
                    </el-select>
                </el-col>
                <el-col :offset="1" :span="4">时间默认值：</el-col>
                <el-col :span="4">
                    <el-select v-model="ReportCondition.DateDefaultVal">
                        <el-option label="当前日期" value="CurrentDate"></el-option>
                        <el-option label="当前月第一天" value="CurrentFirstDate"></el-option>
                        <el-option label="当前月最后一天" value="CurrentLastDate"></el-option>
                        <el-option label="固定值" value="FixedVal"></el-option>
                    </el-select>
                </el-col>
            </el-row>
        </el-form-item>
        <el-form-item label="字典类型" prop="DictType" v-if="ReportCondition.ControlType ==='DropDownList'">
            <el-select v-model="ReportCondition.DictType">
                <el-option label="护士字典" value="NurseDict"></el-option>
                <el-option label="医生字典" value="DoctorDict"></el-option>
                <el-option label="科室字典" value="DeptDict"></el-option>
                <el-option label="动态字典" value="DynamicDict"></el-option>
                <el-option label="自定义" value="DiyDict"></el-option>
            </el-select>
            <el-button type="primary" size="small" icon="el-icon-plus" @click="addBindDict" v-if="ReportCondition.DictType ==='DiyDict'"></el-button>
        </el-form-item>
        <el-form-item v-if="ReportCondition.ControlType ==='DropDownList' && ReportCondition.DictType ==='DiyDict'">
            <div style="height:45px" :key="index" v-for="(item,index) in ReportCondition.BindDict">
                <el-col :span="4">显示文本：</el-col>
                <el-col :span="6">
                    <el-input v-model="item.Value"></el-input>
                </el-col>
                <el-col :offset="1" :span="2">值：</el-col>
                <el-col :span="6">
                    <el-input v-model="item.Key"></el-input>
                </el-col>
                <el-col :offset="1" :span="4">
                    <el-button type="danger" size="small" icon="el-icon-minus" @click="deleteBindDict(index)"></el-button>
                </el-col>
            </div>
        </el-form-item>
        <el-form-item v-if="ReportCondition.ControlType ==='DropDownList' && ReportCondition.DictType==='DynamicDict'">
            <el-row style="height:45px">
                <el-col :span="2">表名：</el-col>
                <el-col :span="4">
                    <el-input v-model="ReportCondition.DynamicDictDes.TableName"></el-input>
                </el-col>
                <el-col :offset="1" :span="2">值：</el-col>
                <el-col :span="4">
                    <el-input v-model="ReportCondition.DynamicDictDes.KeyColumn"></el-input>
                </el-col>
                <el-col :offset="1" :span="4">显示文本：</el-col>
                <el-col :span="4">
                    <el-input v-model="ReportCondition.DynamicDictDes.ValColumn"></el-input>
                </el-col>
            </el-row>
            <el-row>
                <el-col :span="2">条件：</el-col>
                <el-col :span="20">
                    <el-input v-model="ReportCondition.DynamicDictDes.Condition"></el-input>
                </el-col>
            </el-row>
        </el-form-item>
        <el-form-item label="字段名" prop="FieldName">
            <el-input v-model="ReportCondition.FieldName"></el-input>
        </el-form-item>
        <el-form-item label="数据类型" prop="DataType">
            <el-select v-model="ReportCondition.DataType">
                <el-option label="String" value="String"></el-option>
                <el-option label="DateTime" value="DateTime"></el-option>
                <el-option label="Int" value="Int"></el-option>
                <el-option label="Double" value="Double"></el-option>
                <el-option label="Bool" value="Bool"></el-option>
            </el-select>
        </el-form-item>
        <el-form-item label="默认值">
            <el-input v-model="ReportCondition.Value"></el-input>
        </el-form-item>
    </el-form>
</template>

<script>
import ConditionConfig from './ConditionConfig.js'
export default ConditionConfig
</script>

<style scoped>

</style>
