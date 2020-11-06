<template>
  <div id="app">
    <el-row>
      <router-view></router-view>
    </el-row>
  </div>
</template>

<script>
export default {
  name: 'App'
}
</script>

<style>
body {
    margin: 0px;
}
a {
    text-decoration: none;
}
* {
    font-family: 'Microsoft YaHei';
}
#app {
   font-family: 'Microsoft YaHei';
   background: -webkit-gradient(linear,0% 0%, 0% 100%, from(#E3E3E8), to(#E2E6E7), color-stop(0.5,#ECF0F1));
   background-color: #E3E3E8;
}
div {
   padding: 0px;
   margin: 0px;
}
table {
    margin: 0px;
    padding: 0px;
    border: 0px;
}
</style>
