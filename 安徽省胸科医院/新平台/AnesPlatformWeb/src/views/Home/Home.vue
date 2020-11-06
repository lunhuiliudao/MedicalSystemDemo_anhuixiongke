<template>
  <div class="divHome">
    <div class="divHeader"></div>
    <div class="divTop">
      <Search></Search>
    </div>

    <div v-show="showfull" class="divSearchList">
      <SearchList></SearchList>
    </div>
    <div v-show="!showfull" class="divMain">
      <div class="divMainLeft">
        <div class="TYMColumn">
          <Tomorrow class="tomorrowCss"></Tomorrow>
          <Yesteday class="yestedayCss"></Yesteday>
          <Month class="monthCss"></Month>
        </div>
      </div>
      <div class="divMainRight">
        <div class="divMainRightTop">
          <Today></Today>
        </div>
        <div class="divMainRightBottom">
          <div class="TYMVisible">
            <div class="TYMRow">
              <div class="rowTomorrowCss">
                <Tomorrow></Tomorrow>
              </div>
              <div class="rowYestedayCss">
                <Yesteday></Yesteday>
              </div>
            </div>
            <div class="TYMRow2">
              <div class="rowMonthCss">
                <Month></Month>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Home from './Home.js'
export default Home
</script>

<style lang="scss" scoped>
.divHome {
  width: 100%;
  display: inline-flex;
  flex-direction: column;
  margin-top:2px;
  .divHeader {
    height: 32px;
    background: rgba(24, 150, 202, 1);
  }

  .divTop {
    height: 101px;
    background: rgba(255, 255, 255, 1);
    box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
  }

  .divMain {
    width: 100%;
    display: inline-flex;
    flex-direction: row;
  }
}
.divSearchList {
  margin-top: 10px;
}
.divMainLeft {
  width: 307px;
}

.divMainRight {
  width: 1025px;
  display: inline-flex;
  flex-direction: column;
  margin-left: 25px;
  margin-top: 10px;
  .divMainRightTop {
    width: 100%;
    height: 736;
    background: rgba(255, 255, 255, 1);
    box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
  }
  .divMainRightBottom {
    margin-top: 32px;
  }
}
.TYMColumn {
  width: 100%;
  display: flex;
  margin-top: 10px;
  flex-direction: column;

  .tomorrowCss {
    height: 114px;
  }
  .yestedayCss {
    height: 204px;
    margin-top: 16px;
  }
  .monthCss {
    height: 301px;
    margin-top: 14px;
  }
}

.TYMRow {
  display: inline-flex;
  flex-direction: row;
  width: 100%;
  height: 123px;
  max-width: 1080px;
  .rowTomorrowCss {
    width: 30%;
  }
  .rowYestedayCss {
    width: 70%;
    margin-left: 14px;
  }
}

.TYMRow2 {
  width: 100%;
  height: 123px;
  max-width: 1080px;
  margin-top: 20px;
}
@media screen and (min-aspect-ratio: 1001/1000) {
  //横版
  .TYMVisible {
    display: none;
  }
}

@media screen and (max-aspect-ratio: 1000/1000) {
  //竖版
  .TYMColumn {
    display: none;
  }

  .divMainLeft {
    width: 0px;
  }
  .divMainRight {
    width: 100%;
    margin-left: 0px;
    .divMainRightTop {
      height: 70%;
      max-height: 774px;
    }
    .divMainRightBottom {
      margin-top: 32px;
    }
  }
}
</style>
