<template>
  <div class="menu-bar">
    <div class="menu-item-wrapper">
      <template v-for="(item) in userInfo.MenuList.filter((x)=>{return x.permission})">
        <router-link
          v-if="item.haveLevel===1"
          class="menu-wrapper"
          active-class="menu-wrapper-selected"
          :key="item.menuKey"
          :to="item.path"
          tag="div"
        >
          <span :class="['mdsd-iconfont','mdsd-icon-'+ item.icon,'menuicon']"></span>
          <span class="menu-item-name">{{item.name}}</span>
        </router-link>
        <router-link
          v-if="item.haveLevel > 1"
          class="menu-wrapper"
          active-class="menu-wrapper-selected"
          :key="item.menuKey"
          :to="item.path"
          tag="div"
          @mouseenter.native="menuHover($event, item)"
          @mouseleave.native="menuOut($event, item)"
        >
          <span :class="['mdsd-iconfont','mdsd-icon-'+ item.icon,'menuicon']"></span>
          <span class="menu-item-name">{{item.name}}</span>
        </router-link>
      </template>
    </div>
    <div
      class="animated fadeIn"
      :class="{'submenu-bar':currentMenu.haveLevel===3,'submenu-column-bar':currentMenu.haveLevel===2}"
      v-if="subMenuList.length > 0"
      @mouseenter="subMenuHover($event)"
      @mouseleave="subMenuOut($event)"
    >
      <template v-if="currentMenu.haveLevel===3">
        <div
          class="item-wrapper"
          :key="item.menuKey"
          v-for="(item) in subMenuList.filter((x)=>{return x.permission})"
        >
          <div class="item-title">{{item.name}}</div>
          <ul class="subitem-wrapper">
            <router-link
              class="subitem-title"
              active-class="subitem-title-selected"
              :key="item2.menuKey"
              v-for="(item2) in item.childMenuList.filter((x)=>{return x.permission})"
              :to="item2.path"
              tag="li"
            >{{item2.name}}</router-link>
          </ul>
        </div>
      </template>
      <template v-if="currentMenu.haveLevel===2">
        <ul class="subitem-column-wrapper">
          <router-link
            class="subitem-column-title"
            active-class="subitem-column-title-selected"
            :key="subitem.menuKey"
            v-for="(subitem) in subMenuList.filter((x)=>{return x.permission})"
            :to="subitem.path"
            tag="li"
          >{{subitem.name}}</router-link>
        </ul>
      </template>
    </div>
  </div>
</template>

<script>
export default {
  data () {
    return {
      userInfo: this.$store.getters.user,
      currentMenu: {},
      subMenuList: []
    }
  },
  methods: {
    menuHover (event, item) {
      this.currentMenu = item
      this.subMenuList = item.childMenuList ? item.childMenuList : []
      this.$nextTick(function () {
        if (item.childMenuList && this.subMenuList.length > 0) {
          event.target.parentNode.parentNode.lastChild.style.display = 'flex'

          // 判断横屏 竖屏
          var screenWidth = document.documentElement.clientWidth || document.body.clientWidth
          var screenHeight = document.documentElement.clientHeight || document.body.clientHeight

          if (screenWidth > screenHeight) { // 横屏
            if (this.subMenuList.length >= 3) {
              event.target.parentNode.parentNode.lastChild.style.width = '813px'
            } else if (this.subMenuList.length === 2) {
              event.target.parentNode.parentNode.lastChild.style.width = '542px'
            } else if (this.subMenuList.length === 1) {
              event.target.parentNode.parentNode.lastChild.style.width = '271px'
            }

            if (item.haveLevel === 2) {
              event.target.parentNode.parentNode.lastChild.style.left = (event.target.offsetLeft - 1) + 'px'
            } else if (item.haveLevel === 3) {
              let width = event.target.parentNode.parentNode.lastChild.clientWidth
              let temp = (event.target.offsetLeft - 1) + (event.target.clientWidth / 2) - (width / 2)
              event.target.parentNode.parentNode.lastChild.style.left = (temp < 0 ? 0 : temp) + 'px'
            } else {
              event.target.parentNode.parentNode.lastChild.style.left = ''
            }
          } else { // 竖屏
            if (this.subMenuList.length >= 2) {
              event.target.parentNode.parentNode.lastChild.style.width = '542px'
            } else if (this.subMenuList.length === 1) {
              event.target.parentNode.parentNode.lastChild.style.width = '271px'
            }

            if (item.haveLevel === 2) {
              event.target.parentNode.parentNode.lastChild.style.left = (event.target.offsetLeft - 40) + 'px'
            } else if (item.haveLevel === 3) {
              let width = event.target.parentNode.parentNode.lastChild.clientWidth
              let temp = (event.target.offsetLeft - 1) + (event.target.clientWidth / 2) - (width / 2)
              event.target.parentNode.parentNode.lastChild.style.left = (temp < 0 ? 0 : temp - 40) + 'px'
            } else {
              event.target.parentNode.parentNode.lastChild.style.left = ''
            }
          }
        }
      })
    },
    menuOut (event, item) {
      if (item.childMenuList) {
        event.target.parentNode.parentNode.lastChild.style.display = 'none'
      }
    },
    subMenuHover (event) {
      event.target.style.display = 'flex'
    },
    subMenuOut (event) {
      event.target.style.display = 'none'
    }
  }
}
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";
.menu-bar {
  width: 100%;
  position: relative;
  .menu-item-wrapper {
    width: 100%;
    height: 100%;
    display: flex;
    .menu-wrapper {
      height: 100%;
      color: white;
      font-size: px2rem(14);
      font-weight: 400;
      cursor: pointer;
      &:hover {
        background: #00bcf1;
        box-shadow: 0px 1px 7px 0px #22303f52;
      }
      @include center;
      .menu-item-name {
        margin-left: px2rem(9);
      }
    }
    .menu-wrapper-selected {
      background: #00bcf1;
      box-shadow: 0px 1px 7px 0px #22303f52;
      cursor: default;
    }
  }
  .submenu-bar {
    position: absolute;
    min-height: 150px;
    // width: 813px;
    z-index: 10100;
    background: rgba(48, 71, 88, 0.91);
    box-shadow: 0px 0px 9px 0px rgba(34, 48, 63, 0.13);
    border: 1px solid rgba(255, 255, 255, 0.18);
    display: none;
    flex-wrap: wrap;
    .item-wrapper {
      border-right: 1px solid rgba(255, 255, 255, 0.18);
      width: 270px;
      .item-title {
        border-bottom: 1px solid rgba(255, 255, 255, 0.18);
        font-size: 13px;
        font-family: MicrosoftYaHei;
        color: #ffffff;
        padding: 9px 0px;
        width: 100%;
        text-align: center;
      }
      .subitem-wrapper {
        display: flex;
        flex-wrap: wrap;
        margin: 10px 0px;
        .subitem-title {
          width: 110px;
          height: 23px;
          line-height: 23px;
          margin-left: 10px;
          font-size: 12px;
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(172, 189, 201, 1);
          padding-left: 10px;
          &:hover {
            background: rgba(0, 188, 241, 0.3);
            color: rgb(246, 250, 252);
            cursor: pointer;
            border-radius: 12px;
          }
        }
        .subitem-title-selected {
          background: rgba(0, 188, 241, 0.3);
          color: rgb(246, 250, 252);
          border-radius: 12px;
        }
      }
    }
  }
  .submenu-column-bar {
    position: absolute;
    width: px2rem(147);
    min-height: 100px;
    z-index: 10100;
    background: rgba(48, 71, 88, 0.91);
    box-shadow: 0px 0px 9px 0px rgba(34, 48, 63, 0.13);
    border: 1px solid rgba(255, 255, 255, 0.18);
    display: none;
    .subitem-column-wrapper {
      width: 100%;
      .subitem-column-title {
        height: 35px;
        line-height: 35px;
        text-align: center;
        font-size: px2rem(13);
        color: rgba(172, 189, 201, 1);
        &:hover {
          background: rgba(0, 188, 241, 0.3);
          color: rgb(246, 250, 252);
          cursor: pointer;
        }
      }
      .subitem-column-title-selected {
        background: rgba(0, 188, 241, 0.3);
        color: rgb(246, 250, 252);
      }
    }
  }
}
@media screen and (min-aspect-ratio: 1001/1000) {
  .menu-bar {
    height: px2rem(40);
    .menu-item-wrapper {
      .menu-wrapper {
        width: px2rem(147);
        .menuicon {
          font-size: px2rem(17);
        }
      }
    }
    .submenu-bar {
      top: px2rem(40);
    }
  }
}
@media screen and (max-aspect-ratio: 1000/1000) {
  .menu-bar {
    height: px2rem(56);
    background: #375364;
    .menu-item-wrapper {
      .menu-wrapper {
        width: px2rem(141);
        &:first-child {
          margin-left: px2rem(36);
        }
        .menuicon {
          font-size: px2rem(20);
        }
      }
    }
    .submenu-bar {
      top: px2rem(56);
    }
  }
}
</style>
