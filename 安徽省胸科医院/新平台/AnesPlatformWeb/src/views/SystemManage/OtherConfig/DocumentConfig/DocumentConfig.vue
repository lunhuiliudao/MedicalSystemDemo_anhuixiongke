<template>
  <div class="documentConfigDiv">
    <div class="documentConfigDivTitle">
      <el-button type="primary" class="documentConfigDivAdd" @click="Save">保存配置</el-button>
    </div>
    <div style="background-color: #fff;min-height:600px;">
      <div class="documentConfigDivTitle" style="padding-top:20px;">文书导航菜单配置</div>
      <div class="documentConfigDivOperStatus">
        <div class="documentConfigDivOperStatus_1">手术状态：</div>
        <div class="documentConfigDivOperStatus_2 mdsdRadioSingle">
          <el-radio-group v-model="rdoOperStatus" @change="OperStatusChange">
            <el-radio :label="1">术前</el-radio>
            <el-radio :label="2">术中</el-radio>
            <el-radio :label="3">术后</el-radio>
          </el-radio-group>
        </div>
      </div>
      <div class="documentConfigDivOperDoc">
        <div class="documentConfigDivOperDocTop">
          <div class="documentConfigDivOperDocTop_1">文书：</div>
          <div class="documentConfigDivOperDocTop_2 mdsdCheckBoxNoBorder">
            <el-checkbox-group style="width:90%;" v-model="checkList">
              <el-checkbox
                style="width:140px;margin-bottom:20px;"
                v-for="doc in allDocs"
                :label="doc"
                :key="doc"
              >{{doc}}</el-checkbox>
            </el-checkbox-group>
          </div>
          <div class="documentConfigDivOperDocTop_3">
            <el-button
              type="primary"
              class="documentConfigDivAdd"
              style="margin-left:30px;display:none; "
              @click="SaveConfig"
            >保存配置</el-button>
          </div>
        </div>
        <div class="documentConfigDivOperDocBottom mdsdCheckBoxNoBorder">
          <el-transfer v-model="checkList" :titles="titles" :data="data"></el-transfer>
        </div>
      </div>
      <div class="documentConfigDivOperFunc">
        <div class="documentConfigDivOperFuncTop">
          <div class="documentConfigDivOperFuncTop_1">功能：</div>
          <div class="documentConfigDivOperFuncTop_2 mdsdCheckBoxNoBorder">
            <el-checkbox-group style="width:90%;" v-model="checkMenuList">
              <el-checkbox
                style="width:140px;margin-bottom:20px;"
                v-for="doc in allMenus"
                :label="doc"
                :key="doc"
              >{{doc}}</el-checkbox>
            </el-checkbox-group>
          </div>
          <div class="documentConfigDivOperFuncTop_3">
            <el-button
              type="primary"
              class="documentConfigDivAdd"
              style="margin-left:30px;display:none;"
              @click="SaveMenuConfig"
            >保存配置</el-button>
          </div>
        </div>
        <div class="documentConfigDivOperFuncBottom mdsdCheckBoxNoBorder">
          <el-transfer v-model="checkMenuList" :titles="Menutitles" :data="menudata"></el-transfer>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import DocumentConfig from './DocumentConfig.js'
export default DocumentConfig
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

.documentConfigDiv {
  margin-top: 5px;
  padding: 10px 0px;
  background-color: #f5f9fb;
  font-size: 14px;
  color: #606266;
  min-height: 768px;
  width: 100%;
  .documentConfigDivAdd {
    width: 99px;
    height: 28px;
    background: rgba(61, 209, 138, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 10px;
  }
  .documentConfigDivTitle {
    margin-top: 30px;
    margin-left: 30px;
    margin-bottom: 20px;
  }
  .documentConfigDivOperStatus {
    display: flex;
    flex-direction: row;
    height: 30px;
    margin-left: 30px;
    line-height: 30px;
    .documentConfigDivOperStatus_1 {
      width: 100px;
    }
    .documentConfigDivOperStatus_2 {
      margin-left: 10px;
    }
  }
  .documentConfigDivOperDoc {
    display: flex;
    flex-direction: column;
    margin-left: 30px;
    margin-top: 20px;
    width: 100%;
    .documentConfigDivOperDocTop {
      display: flex;
      flex-direction: row;
      .documentConfigDivOperDocTop_1 {
        width: 100px;
      }
      .documentConfigDivOperDocTop_2 {
        margin-left: 65px;
      }
    }
    .documentConfigDivOperDocBottom {
      margin-left: 130px;
      margin-top: 10px;
    }
  }

  .documentConfigDivOperFunc {
    display: flex;
    flex-direction: column;
    margin-left: 30px;
    margin-top: 20px;
    .documentConfigDivOperFuncTop {
      display: flex;
      flex-direction: row;
      .documentConfigDivOperFuncTop_1 {
        width: 100px;
      }
      .documentConfigDivOperFuncTop_2 {
        margin-left: 65px;
      }
    }
    .documentConfigDivOperFuncBottom {
      margin-left: 130px;
      margin-top: 10px;
    }
  }
}

@media screen and (min-aspect-ratio: 1001/1000) {
  // 横屏
}

@media screen and (max-aspect-ratio: 1000/1000) {
  // 竖屏
  .documentConfigDiv {
    .documentConfigDivOperDoc {
      .documentConfigDivOperDocTop {
        .documentConfigDivOperDocTop_2 {
          margin-left: 25px;
        }
      }
      .documentConfigDivOperDocBottom {
        margin-left: 60px;
        margin-top: 10px;
      }
    }

    .documentConfigDivOperFunc {
      .documentConfigDivOperFuncTop {
        .documentConfigDivOperFuncTop_2 {
          margin-left: 25px;
        }
      }
      .documentConfigDivOperFuncBottom {
        margin-left: 60px;
        margin-top: 10px;
      }
    }
  }
}
</style>
<style >
.documentConfigDivAdd.el-button {
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

.documentConfigDiv .el-radio__input {
  padding-left: 15px;
}

.documentConfigDiv .el-button--primary.is-active,
.el-button--primary:active {
  background-color: #4ac773;
}

.documentConfigDiv .el-button--primary:focus,
.el-button--primary:hover {
  background-color: #4ac773;
}

.documentConfigDiv .el-transfer__button {
  background-color: #4ac773;
  border-color: #4ac773;
  color: #fff;
}

.documentConfigDiv .el-transfer__button.is-disabled,
.el-transfer__button.is-disabled:hover {
  border: 1px solid #dcdfe6;
  background-color: #f5f7fa;
  color: #c0c4cc;
}

.documentConfigDiv .el-transfer-panel__item:hover {
  color: #4ac773;
}

.documentConfigDiv .mdsdCheckBoxNoBorder .el-checkbox__inner {
  width: 16px;
  height: 16px;
}

.documentConfigDiv .mdsdCheckBoxNoBorder .el-checkbox__inner::after {
  height: 9px;
  left: 5px;
}

.documentConfigDiv
  .mdsdCheckBoxNoBorder
  .el-checkbox__input.is-indeterminate
  .el-checkbox__inner::before {
  top: 6px;
}
</style>
