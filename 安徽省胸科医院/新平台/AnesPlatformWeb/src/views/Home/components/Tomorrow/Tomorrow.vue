<template>
  <div class="tomorrow">
    <div class="tomorrow_Top">&nbsp;</div>
    <div class="tomorrow_Header">明日统计</div>
    <div class="tomorrow_Main">
      <img class="tomorrow_Main_Left_Img" src="@/assets/images/mrtjct.png" alt>
      <div class="tomorrow_Main_Right">
        <div class="tomorrow_Main_Right_up">已预约手术</div>
        <div class="tomorrow_Main_Right_Down">
          <div class="tomorrow_Main_Right_Down_Left">{{OperInfos.TomorrowTotalCount}}</div>
          <div class="tomorrow_Main_Right_Down_Right">台</div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Tomorrow from './Tomorrow.js'
export default Tomorrow
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

@media screen and (min-aspect-ratio: 1001/1000) {
  //横板
  .tomorrow {
    width: 100%;
    height: 100%;
    background: rgba(255, 255, 255, 1);
    box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
    display: flex;
    flex-direction: column;
    .tomorrow_Top {
      height: 6px;
      background: rgba(24, 150, 202, 1);
    }
    .tomorrow_Header {
      font-size: 14px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(115, 115, 115, 1);
      margin: 17px 94px 0px 35px;
    }
    .tomorrow_Main {
      display: inline-flex;
      flex-direction: row;
      .tomorrow_Main_Left_Img {
        width: 40px;
        height: 41px;
        margin: 22px 99px 19px 46px;
      }
      .tomorrow_Main_Right {
        flex-direction: column;
        .tomorrow_Main_Right_up {
          font-size: 12px;
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(58, 58, 58, 1);
        }
        .tomorrow_Main_Right_Down {
          display: inline-flex;
          flex-direction: row;
          .tomorrow_Main_Right_Down_Left {
            font-size: 20px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(96, 96, 96, 1);
            margin: 27px 20px 24px 4px;
          }
          .tomorrow_Main_Right_Down_Right {
            font-size: 12px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(163, 170, 181, 1);
            margin: 32px 13px 24px 0px;
          }
        }
      }
    }
  }
}
@media screen and (max-aspect-ratio: 1000/1000) {
  //竖版
  .tomorrow {
    width: 100%;
    height: 100%;
    background: rgba(255, 255, 255, 1);
    box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
    display: flex;
    flex-direction: column;
    .tomorrow_Top {
      height: 6px;
      background: linear-gradient(
        90deg,
        rgba(49, 78, 117, 1),
        rgba(24, 150, 202, 1)
      );
    }
    .tomorrow_Header {
      font-size: px2rem(16);
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(115, 115, 115, 1);
      margin: 17px 94px 0px 35px;
    }
    .tomorrow_Main {
      display: inline-flex;
      flex-direction: row;
      .tomorrow_Main_Left_Img {
        width: px2rem(40);
        height: px2rem(41);
        margin: 22px 0px 19px 46px;
      }
      .tomorrow_Main_Right {
        flex-direction: column;
        .tomorrow_Main_Right_up {
          font-size: px2rem(15);
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(58, 58, 58, 1);
          margin-left: 34px;
        }
        .tomorrow_Main_Right_Down {
          display: inline-flex;
          flex-direction: row;
          .tomorrow_Main_Right_Down_Left {
            font-size: px2rem(30);
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(96, 96, 96, 1);
            margin: px2rem(34) px2rem(20) px2rem(24) px2rem(54);
          }
          .tomorrow_Main_Right_Down_Right {
            font-size: px2rem(12);
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(163, 170, 181, 1);
            margin: px2rem(44) px2rem(12) px2rem(24) 0px;
          }
        }
      }
    }
  }
}
</style>
