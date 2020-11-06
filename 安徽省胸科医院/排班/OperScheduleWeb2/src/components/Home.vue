<template>
  <div>
    <HeadNav></HeadNav>
    <el-row>
      <transition name="fade" mode="out-in">
        <router-view></router-view>
      </transition>
    </el-row>
  </div>
</template>

<script>
import HeadNav from './HeadNav/HeadNav.vue'

export default {
  name: 'Home',
  components: {HeadNav},
  created: function () {
    this.webconfig = JSON.parse(sessionStorage.webconfig)
    this.$ajax.defaults.baseURL = this.webconfig.apiUrl
  }
}
</script>

<style scoped>
.fade-enter-active,
.fade-leave-active {
  transition: all .2s ease
}

.fade-enter,
.fade-leave-active {
  opacity: 0
}
</style>
