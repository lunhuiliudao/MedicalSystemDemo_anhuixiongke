<template>
  <div id="login-wrapper" element-loading-background="rgba(0, 0, 0, 0.8)" element-loading-text="拼命加载中" v-loading.fullscreen="fullscreenloading">
    <div class="content-wrapper animated fadeInDown">
      <div class="loginForm-wrapper">
        <div class="logo-wrapper"><img src="@/assets/images/logo-l.svg" width="200" height="74" alt=""></div>
        <div class="form-wrapper">
          <div class="form-title">
            <img src="@/assets/images/login-icon.png" width="32" height="32" alt="">
            <div class="form-title-name">麻醉信息平台</div>
          </div>
          <div class="form-userName">
            <div class="userName-text">用户名</div>
            <div class="userName-wrapper">
              <span class="mdsd-iconfont mdsd-icon-renxiang fix-icon"></span>
              <input type="text" maxlength="20" autofocus class="userName-input" v-model="acount.loginName" placeholder="用户名" @keyup.enter="focusPwd">
            </div>
          </div>
          <div class="form-userPwd">
            <div class="userPwd-text">密码</div>
            <div class="userPwd-wrapper">
              <span class="mdsd-iconfont mdsd-icon-suo fix-icon"></span>
              <input type="password" ref="pwd" maxlength="20" class="userPwd-input" v-model="acount.passWord" placeholder="密码" @keyup.enter="login">
            </div>
          </div>
          <div class="form-remember">
            <span class="mdsd-iconfont mdsd-icon-choose remember-check" @click="isRemember = !isRemember" :style="{'color': isRemember? '#9ae1b1': '#b2adad8a'}"></span>
            <span style="cursor:pointer" @click="isRemember = !isRemember" >记住用户名</span>
            <span style="color:red;margin-left:80px">{{errorMessage}}</span>
          </div>
          <div class="form-button-wrapper">
            <button type="button" class="button-login" @click="login">登 录</button>
          </div>
        </div>
      </div>
    </div>
    <div class="footer">
      版权所有@2005-2017 麦迪科技 Copyright Reserved 2005-2017 Medicalsystem Co.,Ltd.
    </div>
  </div>
</template>

<script>
import Login from './Login.js'
export default Login
</script>

<style lang="scss" scoped>
 %form-input {
   border: 0px;
   height: 35px;
   margin-left: 20px;
   font-size:18px;
   font-family:STYuanti-SC-Regular;
   font-weight:400;
   color:#808387;
   background-color: #eeeeee;
   width:275px;
 }
  #login-wrapper {
    width: 100%;
    height: 100%;
    .content-wrapper {
      width:100%;
      background-size:100% 100%;
      display: flex;
      .loginForm-wrapper {
        .form-wrapper {
          .form-title {
            display: flex;
            align-items: center;
            .form-title-name {
              margin-left: 13px;
              font-size:24px;
              font-family:PingFangSC-Regular;
              font-style:italic;
              color:#353535;
            }
          }
          .form-userName {
            margin-top: 39px;
            .userName-text {
              height:39px;
              line-height: 39px;
              font-size:15px;
              font-family:MicrosoftYaHei;
              font-weight:bold;
              font-style:italic;
              color:#353535;
            }
            .userName-wrapper {
              width:329px;
              height:45px;
              background:#eeeeee;
              border-radius:5px;
              display: flex;
              align-items: center;
              .fix-icon {
                margin-left: 12px;
              }
              .userName-input {
                @extend %form-input
              }
            }
          }
          .form-userPwd {
            margin-top: 38px;
            .userPwd-text {
              height:27px;
              font-size:15px;
              font-family:MicrosoftYaHei;
              font-weight:bold;
              font-style:italic;
              color:#353535;
            }
            .userPwd-wrapper {
              width:329px;
              height:45px;
              background:#eeeeee;
              border-radius:5px;
              display: flex;
              align-items: center;
              .fix-icon {
                margin-left: 12px;
                color: #808387;
              }
              .userPwd-input {
                @extend %form-input
              }
            }
          }
          .form-remember {
            margin-top: 32px;
            height: 20px;
            line-height: 20px;
            font-size:13px;
            font-family:MicrosoftYaHei;
            font-weight:400;
            color: #717171;
            .remember-check {
              font-size: 20px;
              margin-right: 8px;
              cursor: pointer;
            }
          }
          .form-button-wrapper {
            margin-top: 29px;
            .button-login {
              cursor: pointer;
              background: #00bcf1;
              border: 0px;
              color: #ffffff;
              text-align: center;
              box-sizing: border-box;
              padding: 12px 146px;
              border-radius: 4px;
              font-size:16px;
              font-weight: 500;
              font-family:MicrosoftYaHei;
              &:hover {
                background: #00bdf1e0;
                border-color: #00bdf1e0;
                color: #fff;
              }
            }
          }
        }
      }
    }
    .footer {
      display: flex;
      align-items: center;
      justify-content: center;
      background:#0f6588;
      font-size:12px;
      font-family:MicrosoftYaHei;
      font-weight:400;
      color:rgba(255,255,255,1);
    }
  }
@media screen and (min-aspect-ratio: 1001/1000) {
  #login-wrapper {
    .content-wrapper {
      height: 96.8%;
      background:  url(../../assets/images/login-bg-r.png) no-repeat;
      justify-content: flex-end;
      .loginForm-wrapper {
        padding-top: 36px;
        padding-right: 85px;
        min-width: 330px;
        width: 32.34%; // 621px;
        .logo-wrapper {
          text-align: right;
        }
        .form-wrapper {
          margin-top: 74px;
        }
      }
    }
    .footer {
      height: 3.2%;
    }
  }
}
@media screen and (max-aspect-ratio: 1000/1000) {
  #login-wrapper {
    min-height: 850px;
    .content-wrapper {
      height: 96%;
      background: url(../../assets/images/login-bg.png) no-repeat;
      justify-content: center;
      .loginForm-wrapper {
        padding-top: 71px;
        .logo-wrapper {
          text-align: right;
          margin-right: 13px;
        }
        .form-wrapper {
          margin-top: 29px;
          box-shadow:0px 0px 27px 0px #70848e69;
          border-radius:10px;
          width: 438px;
          height:511px;
          padding-left: 93px;
          padding-top: 87px;
        }
      }
    }
    .footer {
      height: 4%;
    }
  }
}
</style>
