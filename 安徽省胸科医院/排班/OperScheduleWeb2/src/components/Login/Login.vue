<template>
  <div v-bind:style="winsize">
    <div v-bind:style="formoffset" style="background-color:rgba(255,255,255,0.7);border-radius: 15px;">
      <div style="margin: 130px 140px 30px 80px;">
        <el-form v-bind:model="acount" label-width="75px" ref="acount" v-bind:rules="rules2">
          <el-form-item label="用户名：" prop="loginname" class="lbl">
            <el-input v-model="acount.loginname" placeholder="请输入用户名" ></el-input>
          </el-form-item>
          <el-form-item label="密 码：" prop="password" class="lbl">
            <el-input type="password" v-model="acount.password" v-focus="true"  @keyup.enter.native="login('acount')"  placeholder="请输入密码"></el-input>
          </el-form-item>
          <el-form-item>
            <el-checkbox v-model="remeberme">记住用户名</el-checkbox>
            <label style="color:red;">{{message}}</label>
          </el-form-item>
          <el-form-item>
            <el-button type="primary" size="large" class="btn" v-on:click="login('acount')" v-loading.fullscreen.lock="fullscreenloading">登 录</el-button>
            <el-button size="large" class="btn" v-on:click="reset('acount')">重 置</el-button>
          </el-form-item>
        </el-form>
      </div>
      <div style="width:245px; margin:0px auto;color:#48576a; font-size:11px;">Copyright &copy; 2005 - 2017 麦迪斯顿医疗科技</div>
    </div>
  </div>
</template>

<script>
import Login from './Login.js'
export default Login
</script>
<style scoped>
.lbl {
  font-weight: bolder;
}

.btn {
  width: 100px;
  margin-left: 50px;
}
</style>
