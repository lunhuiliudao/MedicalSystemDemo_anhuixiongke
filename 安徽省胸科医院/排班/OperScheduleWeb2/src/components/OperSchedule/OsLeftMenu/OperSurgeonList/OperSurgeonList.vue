<template>
    <draggable element="div" v-model="comOperListGroupSurgeon"  :options="dragOptions" :move="onMove" v-bind:style="{height:surgeonBodyHeight,width:'335px','margin-left': '15px',overflow: 'auto', position: 'relative'}">
    <!-- <div v-bind:style="{height:surgeonBodyHeight,width:'335px','margin-left': '15px',overflow: 'auto', position: 'relative'}"> -->
      <div  :key='index' v-for="(item,index) in comOperListGroupSurgeon">
        <div class="surgeonTitle" v-on:click="openList(index)">
            <img style="vertical-align: middle" src="../../../../assets/expan.png" alt="" />
            <span class="deptNameSpan">
              {{item.deptName}}
             </span>
            <span class="surgeonNameSpan">
              {{item.surgeonName===null || item.surgeonName===''? '待定' : item.surgeonName}}
            </span>
            <span class="operCountSpan">
                {{item.data.length}}
            </span>
        </div>
        <ul class="operItemUl" v-show="dataIsOpen[index].isOpen">
            <li  :key='operIndex' v-for="(operInfo,operIndex) in item.data">
                <div class="personInfoDiv">
                    <ul class="ul1">
                    <li>{{operInfo.NAME}}</li>
                    <li>
                        <img v-if="operInfo.SEX==='男'?true:false" src="../../../../assets/man.png" alt="" />
                        <img v-if="operInfo.SEX==='女'?true:false" src="../../../../assets/woman.png" alt="" />
                    </li>
                    <li>
                        {{operInfo.PATIENT_ID}}
                    </li>
                    <li>
                        {{operInfo.SEX}}&nbsp;{{operInfo.AGE}}
                    </li>
                    </ul>
                    <ul class="ul2">
                    <li v-bind:title="operInfo.DIAG_BEFORE_OPERATION">{{operInfo.DIAG_BEFORE_OPERATION}}</li>
                    <li v-bind:title="operInfo.OPERATION_NAME">
                        {{operInfo.OPERATION_NAME}}
                    </li>
                    <li>
                        <span class="zhuSpan">注</span> {{operInfo.NOTES_ON_OPERATION}}
                    </li>
                    </ul>
                </div>
            </li>
        </ul>
      </div>
    <!-- </div> -->
    </draggable>
</template>

<script>
import OperSurgeonList from './OperSurgeonList.js'
export default OperSurgeonList
</script>

<style scoped>
.surgeonTitle {
  color: #296299;
  font-weight: 600;
  font-size: 13px;
  height: 40px;
  line-height: 40px;
  cursor: pointer;
}

.deptNameSpan {
    display: inline-block;
    width: 150px;
    text-align: left;
    margin-left: 20px;
}

.surgeonNameSpan {
    display: inline-block;
    width: 90px;
    text-align: left;
}

.operCountSpan {
    display: inline-block;
    height: 16px;
    width: 16px;
    background-color: #2695F2;
    text-align: center;
    line-height: 16px;
    color: white;
    font-size: 11px;
}

.operItemUl {
    list-style: none;
    margin: 0px;
    padding: 0px;
}

.operItemUl .personInfoDiv {
    height: 85px;
    border-bottom: 1px solid #E5E6EA;
    margin-top:5px;
}

.operItemUl .personInfoDiv .ul1 {
  list-style: none;
  margin: 0px 0px;
  padding: 0px;
  float: left;
  border-right: 1px dashed #C1C1C1;
}

.operItemUl .personInfoDiv .ul1 li {
  width: 60px;
  text-align: center;
  font-size: 11px;
  height: 20px;
  line-height: 20px;
}

.operItemUl .personInfoDiv .ul2 {
  list-style: none;
  margin: 0px 0px 0px 10px;
  padding: 0px;
  float: left;
}

.operItemUl .personInfoDiv .ul2 li {
  width: 225px;
  font-size: 11px;
  height: 25px;
  line-height: 25px;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
  text-align: left;
}

.zhuSpan {
  background-color: #3295D1;
  width:20px;
  height:20px;
  display:inline-block;
  text-align:center;
  line-height: 20px;
}

.ghost {
  opacity: .1;
  color: white;
  height: 0PX;
  width: 0PX;
}
</style>
