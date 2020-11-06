<template>
  <div class="month">
    <div class="month_Top"></div>
    <div class="month_Header">本月统计</div>
    <div class="month_Main">
      <img class="month_Main_Left_Img" src="@/assets/images/bytjct.png" alt>
      <div class="month_Main_Right">
        <div class="month_Main_Right_Up">本月累计手术</div>
        <div class="month_Main_Right_Down">
          <div class="month_Main_Right_Down_Left">{{OperInfos.MonthTotalCount}}</div>
          <div class="month_Main_Right_Down_Right">台</div>
        </div>
      </div>
      <div class="month_Main_Center"></div>
      <img class="month_Main_Right2_Img" src="@/assets/images/ljscct.png" alt>
      <div class="month_Main_Right2">
        <div class="month_Main_Right2_Up">累计时长</div>
        <div class="month_Main_Right2_Down">
          <div class="month_Main_Right2_Down_Left">{{OperInfos.MonthTotalTime}}</div>
          <div class="month_Main_Right2_Down_Right">小时</div>
        </div>
      </div>
      <div class="month_Main_Right3">
        <div class="month_Main_Right3_Left">
          <div class="month_Main_Right3_Circle"></div>
          <div class="month_Main_Right3_Rescu">抢救台数</div>
          <div class="month_Main_Right3_Rescu2">
            <div class="month_Main_Right3_Rescu2_Left">{{OperInfos.RescueCount}}</div>
            <div class="month_Main_Right3_Rescu2_Right">台</div>
          </div>
        </div>
        <div class="month_Main_Right3_Right">
          <div class="month_Main_Right3_Circle2"></div>
          <div class="month_Main_Right3_Emergency">急诊台数</div>
          <div class="month_Main_Right3_Emergency2">
            <div class="month_Main_Right3_Emergency2_Left">{{OperInfos.EmergencyCount}}</div>
            <div class="month_Main_Right3_Emergency2_Right">台</div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Month from './Month.js'
export default Month
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

@media screen and (min-aspect-ratio: 1001/1000) {
  //横板
  .month {
    width: 100%;
    height: 100%;
    background: rgba(255, 255, 255, 1);
    box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
    display: flex;
    flex-direction: column;
    .month_Top {
      height: 6px;
      background: rgba(95, 194, 227, 1);
    }
    .month_Header {
      font-size: px2rem(14);
      font-family: MicrosoftYaHei;
      font-weight: px2rem(400);
      color: rgba(58, 58, 58, 1);
      margin: 17px 94px 0px 35px;
    }
    .month_Main {
      display: inline-flex;
      flex-direction: row;
      flex-wrap: wrap;
      .month_Main_Left_Img {
        width: 34px;
        height: 25px;
        margin: 22px 99px 19px 46px;
      }
      .month_Main_Right {
        flex-direction: column;
        .month_Main_Right_Up {
          height: 12px;
          font-size: 12px;
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(58, 58, 58, 1);
        }
        .month_Main_Right_Down {
          display: inline-flex;
          flex-direction: row;
          .month_Main_Right_Down_Left {
            font-size: 20px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(96, 96, 96, 1);
            margin: 20px 20px 24px 4px;
          }
          .month_Main_Right_Down_Right {
            font-size: 12px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(163, 170, 181, 1);
            margin: 26px 13px 24px 0px;
          }
        }
      }
      .month_Main_Center {
        width: 307px;
        height: 1px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(202, 202, 202, 1);
        border-top: 1px dashed rgba(202, 202, 202, 1);
        margin: 0px 22px 0px 22px;
        //display: inline;
      }
      .month_Main_Right2_Img {
        width: 43px;
        height: 44px;
        margin: 26px 0px 0px 41px;
      }
      .month_Main_Right2 {
        flex-direction: column;
        .month_Main_Right2_Up {
          font-size: 12px;
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(58, 58, 58, 1);
          margin: 22px 0px 0px 92px;
        }
        .month_Main_Right2_Down {
          display: inline-flex;
          flex-direction: row;
          .month_Main_Right2_Down_Left {
            font-size: 20px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(96, 96, 96, 1);
            margin: 21px 0px 0px 100px;
          }
          .month_Main_Right2_Down_Right {
            font-size: 12px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(163, 170, 181, 1);
            margin: 25px 0px 0px 15px;
          }
        }
      }
      .month_Main_Right3 {
        display: flex;
        flex-direction: row;
        .month_Main_Right3_Left {
          display: inline-flex;
          flex-direction: row;
          .month_Main_Right3_Circle {
            width: 10px;
            height: 10px;
            background: rgba(219, 86, 90, 1);
            border: 1px solid rgba(252, 127, 169, 1);
            border-radius: 50%;
            margin: 34px 0px 10px 15px;
          }
          .month_Main_Right3_Rescu {
            font-size: 11px;
            width: 58px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);
            margin: 34px 0px 10px 5px;
          }
          .month_Main_Right3_Rescu2 {
            font-size: 11px;
            width: 50px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);
            display: inline-flex;
            flex-direction: row;
            .month_Main_Right3_Rescu2_Left {
              width: 30px;
              height: 16px;
              font-size: 11px;
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: 34px 0px 0px 0px;
            }
            .month_Main_Right3_Rescu2_Right {
              width: 5px;
              height: 16px;
              font-size: 11px;
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: 34px 0px 0px 0px;
            }
          }
        }
        .month_Main_Right3_Right {
          display: inline-flex;
          flex-direction: row;
          .month_Main_Right3_Circle2 {
            width: 10px;
            height: 10px;
            background: rgba(252, 159, 185, 1);
            border: 1px solid rgba(252, 127, 169, 1);
            border-radius: 50%;
            margin: 34px 0px 10px 10px;
          }
          .month_Main_Right3_Emergency {
            font-size: 11px;
            width: 78px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);
            margin: 34px 0px 10px 9px;
          }
          .month_Main_Right3_Emergency2 {
            font-size: 11px;
            width: 50px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);
            display: inline-flex;
            flex-direction: row;
            .month_Main_Right3_Emergency2_Left {
              width: 30px;
              height: 16px;
              font-size: 11px;
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: 34px 0px 0px 0px;
            }
            .month_Main_Right3_Emergency2_Right {
              width: 5px;
              height: 16px;
              font-size: 11px;
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: 34px 0px 0px 0px;
            }
          }
        }
      }
    }
  }
}

@media screen and (max-aspect-ratio: 1000/1000) {
  //竖版
  .month {
    width: 100%;
    height: 100%;
    background: rgba(255, 255, 255, 1);
    box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
    display: flex;
    flex-direction: column;
    .month_Top {
      height: 6px;
      background: rgba(95, 194, 227, 1);
    }
    .month_Header {
      font-size: px2rem(16);
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(58, 58, 58, 1);
      margin: 17px 94px 0px 35px;
    }
    .month_Main {
      display: inline-flex;
      flex-direction: row;
      flex-wrap: wrap;
      .month_Main_Left_Img {
        width: px2rem(40);
        height: px2rem(41);
        margin: 30px 0px 19px 46px;
      }
      .month_Main_Right {
        flex-direction: column;
        .month_Main_Right_Up {
          height: 12px;
          font-size: px2rem(15);
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(58, 58, 58, 1);
          margin-left: 44px;
        }
        .month_Main_Right_Down {
          display: inline-flex;
          flex-direction: row;
          .month_Main_Right_Down_Left {
            font-size: px2rem(30);
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(96, 96, 96, 1);
            margin: 28px 20px 24px 44px;
          }
          .month_Main_Right_Down_Right {
            font-size: px2rem(15);
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(163, 170, 181, 1);
            margin: px2rem(45) 13px 24px 0px;
          }
        }
      }
      .month_Main_Center {
        width: 0px;
        height: 1px;
        font-size: px2rem(12);
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(202, 202, 202, 1);
        border-top: 1px dashed rgba(202, 202, 202, 1);
        margin: 0px 22px 0px 22px;
        display: none;
      }
      .month_Main_Right2_Img {
        width: px2rem(53);
        height: px2rem(54);
        margin: 11px 0px 0px 44px;
      }
      .month_Main_Right2 {
        flex-direction: column;
        .month_Main_Right2_Up {
          font-size: px2rem(15);
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(58, 58, 58, 1);
          margin: 0px 0px 0px 38px;
        }
        .month_Main_Right2_Down {
          display: inline-flex;
          flex-direction: row;
          .month_Main_Right2_Down_Left {
            font-size: px2rem(30);
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(96, 96, 96, 1);
            margin: 25px 0px 0px 38px;
          }
          .month_Main_Right2_Down_Right {
            font-size: px2rem(15);
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(163, 170, 181, 1);
            margin: px2rem(40) 0px 0px 10px;
          }
        }
      }
      .month_Main_Right3 {
        display: flex;
        flex-direction: column;
        .month_Main_Right3_Left {
          display: inline-flex;
          flex-direction: row;
          .month_Main_Right3_Circle {
            width: px2rem(14);
            height: px2rem(14);
            background: rgba(219, 86, 90, 1);
            border: 1px solid rgba(252, 127, 169, 1);
            border-radius: 50%;
            margin: 6px 0px 0px 22px;
          }
          .month_Main_Right3_Rescu {
            font-size: px2rem(15);
            width: 68px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);
            margin: 6px 0px 0px 18px;
          }
          .month_Main_Right3_Rescu2 {
            font-size: px2rem(15);

            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);
            display: inline-flex;
            flex-direction: row;
            .month_Main_Right3_Rescu2_Left {
              width: 30px;
              font-size: px2rem(15);
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: 6px 0px 0px 59px;
            }
            .month_Main_Right3_Rescu2_Right {
              width: 15px;

              font-size: px2rem(15);
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: 6px 0px 0px 0px;
            }
          }
        }
        .month_Main_Right3_Right {
          display: inline-flex;
          flex-direction: row;
          .month_Main_Right3_Circle2 {
            width: px2rem(14);
            height: px2rem(14);
            background: rgba(252, 159, 185, 1);
            border: 1px solid rgba(252, 127, 169, 1);
            border-radius: 50%;
            margin: 23px 0px 0px 22px;
          }
          .month_Main_Right3_Emergency {
            font-size: px2rem(15);
            width: 68px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);
            margin: 23px 0px 0px 18px;
          }
          .month_Main_Right3_Emergency2 {
            font-size: px2rem(15);

            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);
            display: inline-flex;
            flex-direction: row;
            .month_Main_Right3_Emergency2_Left {
              width: 30px;
              font-size: px2rem(15);
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: 23px 0px 0px 59px;
            }
            .month_Main_Right3_Emergency2_Right {
              width: 15px;
              font-size: px2rem(15);
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: 23px 0px 0px 0px;
            }
          }
        }
      }
    }
  }
}
</style>
