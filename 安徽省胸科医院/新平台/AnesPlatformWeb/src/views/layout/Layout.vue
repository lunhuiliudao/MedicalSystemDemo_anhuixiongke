<template>
  <div class="layout-wrapper">
    <NavBar></NavBar>
    <div class="main-wrapper">
      <transition enter-active-class="animated bounceInLeft">
        <div class="main-content">
          <div v-show="breadcrumbdata.length > 1" class="mbs-wrapper">
            <el-breadcrumb separator-class="el-icon-arrow-right">
              <el-breadcrumb-item :key="index" v-for="(item, index) in  breadcrumbdata">{{item}}</el-breadcrumb-item>
            </el-breadcrumb>
          </div>
          <!-- <router-view class="animated bounceInLeft" /> -->
          <transition enter-active-class="animated bounceInLeft">
            <router-view />
          </transition>
        </div>
      </transition>
    </div>
  </div>
</template>

<script>
import NavBar from './components/NavBar.vue'
export default {
  data () {
    return {
      breadcrumbdata: []
    }
  },
  components: { NavBar },
  beforeRouteUpdate (to, from, next) {
    if (!to.meta.hasOwnProperty('nonext')) {
      this.breadcrumbdata = []
      this.breadcrumbdata.push(to.meta.key)
      if (to.params.hasOwnProperty('pname')) {
        this.breadcrumbdata.push(to.params.pname)
        this.breadcrumbdata.push(to.params.name)
      } else if (to.meta.hasOwnProperty('pname')) {
        this.breadcrumbdata.push(to.meta.pname)
        this.breadcrumbdata.push(to.meta.name)
      }
      next()
    }
  },
  beforeRouteEnter (to, from, next) {
    next(vm => {
      vm.breadcrumbdata = []
      vm.breadcrumbdata.push(to.meta.key)
      if (to.params.hasOwnProperty('pname')) {
        vm.breadcrumbdata.push(to.params.pname)
        vm.breadcrumbdata.push(to.params.name)
      } else if (to.meta.hasOwnProperty('pname')) {
        vm.breadcrumbdata.push(to.meta.pname)
        vm.breadcrumbdata.push(to.meta.name)
      }
    })
  }
}
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";
.layout-wrapper {
  .main-wrapper {
    .main-content {
      margin: 0 auto;
    }
  }
}

@media screen and (min-aspect-ratio: 1001/1000) {
  .layout-wrapper {
    min-width: 1340px;
    .main-wrapper {
      padding-top: 9px;
      background: #f5f9fb url(../../assets/images/zjtaqt-r.png) no-repeat;
      background-size: 100% 43px;
      .main-content {
        width: 1300px;
        .mbs-wrapper {
          font-size:12px;
          display:inline-block;
          padding:0px 20px;
          height:26px;
          line-height:26px;
          background:rgba(0,109,154,0.46);
          border-radius:19px;
        }
      }
    }
  }
}
@media screen and (max-aspect-ratio: 1000/1000) {
  .layout-wrapper {
    min-width: 738px;
    max-width: 1080px;
    .main-wrapper {
      padding-top: px2rem(35);
      background: #f5f9fb url(../../assets/images/zjtaqt.png) no-repeat;
      background-size: 100% px2rem(142);
      .main-content {
        width: 98%;
      }
    }
  }
}
</style>

<style>
.el-breadcrumb__inner {
  color: #fff
}
.el-breadcrumb__item:last-child .el-breadcrumb__inner {
  color: #fff
}
.el-breadcrumb__separator {
  color: #fff
}
.el-breadcrumb__item:last-child .el-breadcrumb__inner,.el-breadcrumb__item:last-child .el-breadcrumb__inner:hover {
  color: #fff;
}
</style>
