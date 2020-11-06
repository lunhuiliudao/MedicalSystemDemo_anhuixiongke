<template>
 <el-row>
    <el-col v-bind:span="9"  :style="{backgroundImage: 'url(' + head2 + ')', height:'73px'}">
        <img src="../../assets/head-1.png" width="510" height="73" alt="" />
    </el-col>
    <el-col  v-bind:span="1" :style="{backgroundImage: 'url(' + head2 + ')', height:'73px'}">
        &nbsp;
    </el-col>
    <el-col v-bind:span="12" :style="{backgroundImage: 'url(' + head2 + ')', height:'73px'}">
        <ul class="header_ul"  >
            <router-link v-for="(menu,index) in headMenu" class="header_ul_notselect_li"  :key="index"  v-bind:to="menu.path"  tag="li" exact>{{menu.name}}</router-link>
        </ul>
    </el-col>
    <el-col  v-bind:span="2" :style="{backgroundImage: 'url(' + head2 + ')', height:'73px'}">
        <div>
            <span style="display: inline-block;height:70px;vertical-align: middle">
            </span>
            <img style="vertical-align: middle;width:32px;height:32px" src="../../assets/user.png" />
            <el-dropdown trigger="click">
                <div style="color: white;width:70px;text-align: center;cursor:pointer;">
                   {{userInfo.USER_NAME}} <i class="el-icon-caret-bottom el-icon--right"></i>
                </div>
                <el-dropdown-menu  slot="dropdown" >
                    <el-dropdown-item @click.native="logout"><i class="el-icon-upload2"> 安全登出</i></el-dropdown-item>
                </el-dropdown-menu>
            </el-dropdown>
        </div>
    </el-col>
 </el-row>
 </template>

<script>
import HeadNavJs from './HeadNav.js'
export default HeadNavJs
</script>

<style>
.header_ul { display: inline-block; position:relative;margin:16px 0px 0px;}
li.router-link-active{
    float: left;
    list-style: none;
    height: 35px;
    font-size: 16px;
    color: white;
    border-bottom: 1.5px solid white;
    width: 160px;
    text-align: center;
    letter-spacing:2px;
    font-weight:600;
    margin-top:14px;
    cursor: default;
}
.header_ul_notselect_li {
    float: left;
    list-style: none;
    height: 35px;
    font-size: 16px;
    color: white;
    width: 160px;
    text-align: center;
    letter-spacing:2px;
    margin-top:14px;
    cursor: pointer;
}
/* .el-dropdown-menu {
    margin: 0px;
    padding: 0px;
}
.el-dropdown-menu__item {
    padding: 0px;
    text-align: center;
} */
</style>
