<template>
    <div class="operCancelView">
        <div class="operCancelSearch">
            <span>日期 &nbsp;&nbsp;</span>
            <el-date-picker v-model="scheduledate"
                            type="date"
                            placeholder="选择日期"
                            picker-options="pickerOptions0"
                            v-bind:editable="false"
                            v-bind:clearable="false"
                            v-on:change="search">
            </el-date-picker>
            <el-button type="primary" v-on:click="search">查 询</el-button>
            <el-button type="primary" v-on:click="reback">撤 销</el-button>
            <div class="operCancelInfo">
                共{{tmptableData.length}}条手术取消记录
            </div>
        </div>
        <div class="operCancelBody" v-bind:style="{width:ocCancelWith+'px',height:ocCancelHeight+'px'}">
            <el-table v-bind:data="tmptableData" border v-on:selection-change="handleSelectionChange" v-loading="loading" v-bind:height="ocCancelHeight-10" >
                <el-table-column fixed type="selection" v-model="selectedrows">
                </el-table-column>
                <el-table-column v-for="column in columns"
                                    v-bind:prop="column.fieldname"
                                    v-bind:label="column.columnname"
                                    v-if="column.visible"
                                    v-bind:key="column.fieldname"
                                    v-bind:show-overflow-tooltip="true"
                                    v-bind="column.width"
                                    v-bind:fixed="column.fixed"
                                    header-align="center">
                </el-table-column>
            </el-table>
        </div>
    </div>
</template>

<script>
import OperCancel from './OperCancel.js'
export default OperCancel
</script>

<style scoped>
.operCancelView{
    font-size: 13px;
    color: #349DF1;
 }

.operCancelSearch {
    padding-left: 50px;
    background-color: white;
    height: 50px;
    line-height: 50px;
    font-weight: bold;
 }

.operCancelInfo {
    font-weight: bold;
    padding-right: 100px;
    float: right;
    clear: both;
}

.operCancelBody {
    margin:0 auto;
}
</style>
