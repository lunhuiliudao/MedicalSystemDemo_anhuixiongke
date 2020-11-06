<template>
  <div class="head-wrapper">
    <el-dialog title="修改密码" :visible.sync="dialogUpdatePwdVisible" :close-on-click-modal="false" width="30%">
      <el-form :model="pwdObj" :rules="rulesPwd" ref="PwdForm" label-width="120px">
        <el-form-item style="margin-bottom:22px" label="原密码" prop="OLD_LOGIN_PWD">
          <el-input type="password" v-model="pwdObj.OLD_LOGIN_PWD" auto-complete="off"></el-input>
        </el-form-item>
        <el-form-item style="margin-bottom:22px" label="新密码" prop="LOGIN_PWD">
          <el-input type="password" v-model="pwdObj.LOGIN_PWD" auto-complete="off"></el-input>
        </el-form-item>
        <el-form-item label="确认新密码" prop="SURE_LOGIN_PWD">
          <el-input type="password" v-model="pwdObj.SURE_LOGIN_PWD" auto-complete="off"></el-input>
        </el-form-item>
      </el-form>
      <div slot="footer">
        <el-button @click="dialogUpdatePwdVisible = false;resetForm('PwdForm')">取 消</el-button>
        <el-button type="primary" @click="submitPwdForm('PwdForm')">确 定</el-button>
      </div>
    </el-dialog>
    <div class="nav-bar">
      <div class="logo-wrapper">
        <img class="logo" src="@/assets/images/logo.svg" alt>
        <div class="title-name">麻醉信息平台</div>
      </div>
      <div class="menu-bar-wrapper">
        <MenuBar class="menu1"></MenuBar>
      </div>
      <div class="loginInfo-wrapper">
        <span class="mdsd-iconfont mdsd-icon-tixing tixing-icon"></span>
        <div style="display:inline-block" @mouseenter="optionHover()" @mouseleave="optionOut()">
          <span class="mdsd-iconfont mdsd-icon-user user-icon"></span>
          <span class="user-Name">{{userInfo.USER_NAME}}</span>
        </div>
        <ul class="user-option animated fadeIn" v-show="useroption" @mouseenter="optionHover()" @mouseleave="optionOut()">
          <li @click="dialogUpdatePwdVisible = true">修改密码</li>
          <li @click="logout">安全登出</li>
        </ul>
      </div>
    </div>
    <MenuBar class="menu2"></MenuBar>
  </div>
</template>

<script>
import MenuBar from './MenuBar.vue'
import { changePwd } from '@/api/loginApi.js'
export default {
  data () {
    return {
      userInfo: this.$store.getters.user,
      useroption: false,
      dialogUpdatePwdVisible: false,
      pwdObj: this.createPwdObj(),
      rulesPwd: {
        OLD_LOGIN_PWD: [
          { required: true, message: '请输入原密码', trigger: 'blur' }
        ],
        LOGIN_PWD: [
          { required: true, message: '请输入新密码', trigger: 'blur' },
          { validator: this.validatePwd, trigger: 'blur' }
        ],
        SURE_LOGIN_PWD: [
          { required: true, message: '请确认新密码', trigger: 'blur' },
          { validator: this.validatePwd2, trigger: 'blur' }
        ]
      },
      resetForm (formName) {
        this.$refs[formName].resetFields()
      }
    }
  },
  components: { MenuBar },
  methods: {
    optionHover () {
      this.useroption = true
    },
    optionOut () {
      this.useroption = false
    },
    logout () {
      this.$confirm('确认退出吗?', '提示', {
        type: 'info'
      }).then(() => {
        sessionStorage.removeItem('user')
        this.$router.push('/login')
        // this.$ajax.post('/Api/Account/LoginOut', this.userInfo).then((respose) => {
        //   window.clearInterval(this.msgIntObj)
        //   sessionStorage.removeItem('user')
        //   this.$store.commit('SET_ROUTERS_OUTLOGIN')
        //   this.$router.options.routes[1].children = []
        //   this.$router.push('/login')
        // }).catch((error) => {
        //   console.log(error)
        // })
      }).catch(() => {})
    },
    createPwdObj () {
      var tempUser = JSON.parse(sessionStorage.getItem('user'))
      return {
        USER_ID: tempUser.USER_ID,
        LOGIN_NAME: tempUser.LOGIN_NAME,
        OLD_LOGIN_PWD: '',
        LOGIN_PWD: '',
        SURE_LOGIN_PWD: ''
      }
    },
    validatePwd: function (rule, value, callback) {
      if (value === '') {
        callback(new Error('请输入密码'))
      } else {
        if (this.pwdObj.SURE_LOGIN_PWD !== '') {
          this.$refs.PwdForm.validateField('SURE_LOGIN_PWD')
        }
        callback()
      }
    },
    validatePwd2: function (rule, value, callback) {
      if (value === '') {
        callback(new Error('请再次输入密码'))
      } else if (value !== this.pwdObj.LOGIN_PWD) {
        callback(new Error('两次输入密码不一致!'))
      } else {
        callback()
      }
    },
    submitPwdForm (formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          changePwd(this.pwdObj).then((respose) => {
            if (respose.data.Result === 1) {
              this.$message.success(respose.data.Message)
              sessionStorage.removeItem('user')
              this.$router.push('/login')
            } else {
              this.$message.error(respose.data.Message)
            }
          }).catch((error) => {
            console.log(error)
          })
        } else {
          return false
        }
      })
    }
  }
}
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";
.head-wrapper {
  width: 100%;
  .nav-bar {
    display: flex;
    width: 100%;
    height: px2rem(40);
    align-items: center;
    background: #0f6588;
    .logo-wrapper {
      display: flex;
      align-items: center;
      margin-left: px2rem(78);
      .logo {
        width: px2rem(206);
        height: px2rem(60);
        color: white;
      }
      .title-name {
        width: px2rem(199);
        height: px2rem(17);
        font-size: px2rem(16);
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: #ffffff;
        margin-left: px2rem(24);
      }
    }
    .menu-bar-wrapper {
      flex-grow: 1;
    }
    .loginInfo-wrapper {
      margin-right: px2rem(94);
      min-width: 95px;
      position: relative;
      height: 100%;
      line-height: 200%;
      .tixing-icon {
        @extend .user-icon;
        margin-right: px2rem(29);
      }
      .user-icon {
        color: white;
        width: px2rem(15);
        height: px2rem(16);
      }
      .user-Name {
        font-size: 12px;
        font-weight: 400;
        color: #ffffff;
        margin-left: px2rem(4);
      }
      .user-option {
        position: absolute;
        font-size:px2rem(13);
        color:#ffffff;
        background:rgba(48,71,88,0.91);
        border:1px solid rgba(255, 255, 255,0.18);
        box-shadow:0px 0px 9px 0px rgba(34,48,63,0.13);
        z-index: 10100;
        right: px2rem(-16);
        top: px2rem(35);
        li {
          width: 80px;
          text-align: center;
          height: 30px;
          line-height: 30px;
          cursor: pointer;
          &:hover {
            background:rgba(0,188,241,0.3);
            color:rgb(246, 250, 252);
            cursor: pointer;
          }
        }
      }
    }
  }
}
@media screen and (min-aspect-ratio: 1001/1000) {
  .menu2 {
    display: none;
  }
}
@media screen and (max-aspect-ratio: 1000/1000) {
  .menu1 {
    display: none;
  }
}
</style>
