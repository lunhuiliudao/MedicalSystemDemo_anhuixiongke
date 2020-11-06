<template>
  <div class="yesteday">
    <div class="yesteday_Top">&nbsp;</div>
    <div class="yesteday_Header">昨日统计</div>
    <div class="yesteday_Main">
      <img class="yesteday_Main_Left_Img" src="@/assets/images/zrtjct.png" alt>
      <div class="yesteday_Main_Right">
        <div class="yesteday_Main_Right_Up">完成手术</div>
        <div class="yesteday_Main_Right_Down">
          <div class="yesteday_Main_Right_Down_Left">{{OperInfos.YesterdayTotalCount}}</div>
          <div class="yesteday_Main_Right_Down_Right">台</div>
        </div>
      </div>
      <div class="yesteday_Main_Right2">
        <div class="yesteday_Main_Right2_Up">
          <div class="yesteday_Main_Right2_Up_Circle"></div>
          <div class="yesteday_Main_Right2_Up_Emergency">急诊台数</div>
          <div class="yesteday_Main_Right2_Up_Emergency2">
            <div class="yesteday_Main_Right2_Up_Emergency2_Left">{{OperInfos.YesterdayEmergencyCount}}</div>
            <div class="yesteday_Main_Right2_Up_Emergency2_Right">台</div>
          </div>
          <div class="yesteday_Main_Right2_Up_Circle2"></div>
          <div class="yesteday_Main_Right2_Up_Pacu">复苏时长≥2h</div>
          <div class="yesteday_Main_Right2_Up_Pacu2">
            <div class="yesteday_Main_Right2_Up_Pacu2_Left">{{OperInfos.YesterdayPacuCount}}</div>
            <div class="yesteday_Main_Right2_Up_Pacu2_Right">台</div>
          </div>
        </div>
        <div class="yesteday_Main_Right2_Down">
          <div class="yesteday_Main_Right2_Down_Circle"></div>
          <div class="yesteday_Main_Right2_Down_Icu">转ICU台数</div>
          <div class="yesteday_Main_Right2_Down_Icu2">
            <div class="yesteday_Main_Right2_Down_Icu2_Left">{{OperInfos.YesterdayToICUCount}}</div>
            <div class="yesteday_Main_Right2_Down_Icu2_Right">台</div>
          </div>
          <div class="yesteday_Main_Right2_Down_Circle2"></div>
          <div class="yesteday_Main_Right2_Down_UnExpected">非预期事件</div>
          <div class="yesteday_Main_Right2_Down_UnExpected2">
            <div class="yesteday_Main_Right2_Down_UnExpected2_Left">{{OperInfos.YesterdayUnExpectCount}}</div>
            <div class="yesteday_Main_Right2_Down_UnExpected2_Right">台</div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Yesteday from './Yesteday.js'
export default Yesteday
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

@media screen and (min-aspect-ratio: 1001/1000) {
  //横板
  .yesteday {
    width: 100%;
    height: 100%;
    background: rgba(255, 255, 255, 1);
    box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
    display: flex;
    flex-direction: column;
    .yesteday_Top {
      height: 6px;
      background: rgba(246, 204, 93, 1);
    }
    .yesteday_Header {
      font-size: 14px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(58, 58, 58, 1);
      margin: 17px 94px 0px 35px;
    }
    .yesteday_Main {
      display: inline-flex;
      flex-direction: row;
      flex-wrap: wrap;
      .yesteday_Main_Left_Img {
        width: 39px;
        height: 42px;
        margin: 22px 99px 0px 46px;
      }
      .yesteday_Main_Right {
        //width: 122px;
        margin: 5px 0px 0px 0px;
        flex-direction: column;
        .yesteday_Main_Right_Up {
          font-size: 12px;
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(58, 58, 58, 1);
        }
        .yesteday_Main_Right_Down {
          display: inline-flex;
          flex-direction: row;
          .yesteday_Main_Right_Down_Left {
            font-size: 20px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(96, 96, 96, 1);
            margin: 25px 20px 0px 4px;
          }
          .yesteday_Main_Right_Down_Right {
            font-size: 12px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(163, 170, 181, 1);
            margin: 29px 13px 0px 0px;
          }
        }
      }
      .yesteday_Main_Right2 {
        display: flex;
        flex-direction: column;
        .yesteday_Main_Right2_Up {
          display: inline-flex;
          flex-direction: row;

          .yesteday_Main_Right2_Up_Circle {
            width: 10px;
            height: 10px;
            background: rgba(252, 159, 185, 1);
            border: 1px solid rgba(252, 127, 169, 1);
            border-radius: 50%;
            margin: 28px 0px 22px 15px;
          }
          .yesteday_Main_Right2_Up_Emergency {
            width: 58px;
            height: 16px;
            font-size: 11px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);
            margin: 28px 0px 0px 6px;
          }
          .yesteday_Main_Right2_Up_Emergency2 {
            width: 50px;
            height: 16px;
            font-size: 11px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);
            display: inline-flex;
            flex-direction: row;
            .yesteday_Main_Right2_Up_Emergency2_Left {
              width: 30px;
              height: 16px;
              font-size: 11px;
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: 28px 0px 0px 0px;
            }
            .yesteday_Main_Right2_Up_Emergency2_Right {
              width: 5px;
              height: 16px;
              font-size: 11px;
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: 28px 0px 0px 0px;
            }
          }
          .yesteday_Main_Right2_Up_Circle2 {
            width: 10px;
            height: 10px;
            background: rgba(246, 179, 127, 1);
            border: 1px solid rgba(242, 178, 95, 1);
            border-radius: 50%;
            margin: 28px 0px 22px 10px;
          }
          .yesteday_Main_Right2_Up_Pacu {
            width: 78px;
            height: 16px;
            font-size: 11px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);
            margin: 28px 0px 0px 6px;
          }
          .yesteday_Main_Right2_Up_Pacu2 {
            width: 50px;
            height: 16px;
            font-size: 11px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);
            display: inline-flex;
            flex-direction: row;
            .yesteday_Main_Right2_Up_Pacu2_Left {
              width: 30px;
              height: 16px;
              font-size: 11px;
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: 28px 0px 0px 0px;
            }
            .yesteday_Main_Right2_Up_Pacu2_Right {
              width: 5px;
              height: 16px;
              font-size: 11px;
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: 28px 0px 0px 0px;
            }
          }
        }
        .yesteday_Main_Right2_Down {
          display: inline-flex;
          flex-direction: row;

          .yesteday_Main_Right2_Down_Circle {
            width: 10px;
            height: 10px;
            background: rgba(197, 202, 255, 1);
            border: 1px solid rgba(137, 146, 249, 1);
            border-radius: 50%;
            margin: 18px 0px 24px 15px;
          }

          .yesteday_Main_Right2_Down_Icu {
            width: 58px;
            height: 16px;
            font-size: 11px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);
            margin: 18px 0px 0px 6px;
          }
          .yesteday_Main_Right2_Down_Icu2 {
            width: 50px;
            height: 16px;
            font-size: 11px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);
            display: inline-flex;
            flex-direction: row;
            .yesteday_Main_Right2_Down_Icu2_Left {
              width: 30px;
              height: 16px;
              font-size: 11px;
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: 18px 0px 0px 0px;
            }
            .yesteday_Main_Right2_Down_Icu2_Right {
              width: 5px;
              height: 16px;
              font-size: 11px;
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: 18px 0px 0px 0px;
            }
          }
          .yesteday_Main_Right2_Down_Circle2 {
            width: 10px;
            height: 10px;
            background: rgba(172, 64, 234, 1);
            border: 1px solid rgba(145, 36, 221, 1);
            border-radius: 50%;
            margin: 18px 0px 22px 10px;
          }
          .yesteday_Main_Right2_Down_UnExpected {
            width: 78px;
            height: 16px;
            font-size: 11px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);

            margin: 18px 0px 0px 6px;
          }
          .yesteday_Main_Right2_Down_UnExpected2 {
            width: 50px;
            height: 16px;
            font-size: 11px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);
            display: inline-flex;
            flex-direction: row;
            .yesteday_Main_Right2_Down_UnExpected2_Left {
              width: 30px;
              height: 16px;
              font-size: 11px;
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: 18px 0px 0px 0px;
            }
            .yesteday_Main_Right2_Down_UnExpected2_Right {
              width: 5px;
              height: 16px;
              font-size: 11px;
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: 18px 0px 0px 0px;
            }
          }
        }
      }
    }
  }
}
@media screen and (max-aspect-ratio: 1000/1000) {
  //竖版
  .yesteday {
    width: 100%;
    height: 100%;
    background: rgba(255, 255, 255, 1);
    box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
    display: flex;
    flex-direction: column;
    .yesteday_Top {
      height: 6px;
      background: rgba(31, 91, 142, 1);
    }
    .yesteday_Header {
      font-size: px2rem(16);
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(58, 58, 58, 1);
      margin: 17px 0px 0px 35px;
    }
    .yesteday_Main {
      display: inline-flex;
      flex-direction: row;
      flex-wrap: wrap;
      .yesteday_Main_Left_Img {
        width: px2rem(40);
        height: px2rem(41);
        margin: px2rem(38) 0px 0px px2rem(76);
      }
      .yesteday_Main_Right {
        width: 20%;
        margin: 5px 0px 0px px2rem(10);
        flex-direction: column;
        .yesteday_Main_Right_Up {
          font-size: px2rem(15);
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(58, 58, 58, 1);
          margin-left: px2rem(34);
        }
        .yesteday_Main_Right_Down {
          display: inline-flex;
          flex-direction: row;
          .yesteday_Main_Right_Down_Left {
            font-size: px2rem(30);
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(96, 96, 96, 1);
            margin: px2rem(28) px2rem(10) 0px px2rem(34);
          }
          .yesteday_Main_Right_Down_Right {
            font-size: px2rem(15);
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(163, 170, 181, 1);
            margin: px2rem(38) px2rem(13) 0px 5px;
          }
        }
      }
      .yesteday_Main_Right2 {
        width: 60%;
        display: flex;
        flex-direction: column;
        .yesteday_Main_Right2_Up {
          display: inline-flex;
          flex-direction: row;

          .yesteday_Main_Right2_Up_Circle {
            width: px2rem(14);
            height: px2rem(14);
            background: rgba(252, 159, 185, 1);
            border: px2rem(1) solid rgba(252, 127, 169, 1);
            border-radius: 50%;
            margin: px2rem(18) 0px px2rem(22) 0px;
          }
          .yesteday_Main_Right2_Up_Emergency {
            width: 69px;
            height: 16px;
            font-size: px2rem(15);
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);
            margin: px2rem(18) 0px 0px px2rem(16);
          }
          .yesteday_Main_Right2_Up_Emergency2 {
            width: 50px;
            height: 16px;
            font-size: px2rem(15);
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);
            display: inline-flex;
            flex-direction: row;
            .yesteday_Main_Right2_Up_Emergency2_Left {
              width: 30px;
              height: 16px;
              font-size: px2rem(15);
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: px2rem(18) 0px 0px px2rem(0);
            }
            .yesteday_Main_Right2_Up_Emergency2_Right {
              width: 5px;
              height: 16px;
              font-size: px2rem(15);
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: px2rem(18) 0px 0px px2rem(0);
            }
          }
          .yesteday_Main_Right2_Up_Circle2 {
            width: px2rem(14);
            height: px2rem(14);
            background: rgba(246, 179, 127, 1);
            border: px2rem(1) solid rgba(242, 178, 95, 1);
            border-radius: 50%;
            margin: px2rem(18) 0px px2rem(22) px2rem(32);
          }
          .yesteday_Main_Right2_Up_Pacu {
            width: 87px;
            height: 16px;
            font-size: px2rem(15);
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);
            margin: px2rem(18) 0px 0px px2rem(16);
          }
          .yesteday_Main_Right2_Up_Pacu2 {
            width: 50px;
            height: 16px;
            font-size: px2rem(15);
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);

            display: inline-flex;
            flex-direction: row;
            .yesteday_Main_Right2_Up_Pacu2_Left {
              width: 30px;
              height: 16px;
              font-size: px2rem(15);
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: px2rem(18) 0px 0px px2rem(0);
            }
            .yesteday_Main_Right2_Up_Pacu2_Right {
              width: 15px;
              height: 16px;
              font-size: px2rem(15);
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: px2rem(18) 0px 0px px2rem(0);
            }
          }
        }
        .yesteday_Main_Right2_Down {
          display: inline-flex;
          flex-direction: row;

          .yesteday_Main_Right2_Down_Circle {
            width: px2rem(14);
            height: px2rem(14);
            background: rgba(197, 202, 255, 1);
            border: px2rem(1) solid rgba(137, 146, 249, 1);
            border-radius: 50%;
            margin: 0px 0px px2rem(24) 0px;
          }

          .yesteday_Main_Right2_Down_Icu {
            width: 69px;
            height: 16px;
            font-size: px2rem(15);
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);
            margin: 0px 0px 0px px2rem(16);
          }
          .yesteday_Main_Right2_Down_Icu2 {
            width: 50px;
            height: 16px;
            font-size: px2rem(15);
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);
            display: inline-flex;
            flex-direction: row;
            .yesteday_Main_Right2_Down_Icu2_Left {
              width: 30px;
              height: 16px;
              font-size: px2rem(15);
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: 0px 0px 0px px2rem(0);
            }
            .yesteday_Main_Right2_Down_Icu2_Right {
              width: 5px;
              height: 16px;
              font-size: px2rem(15);
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: 0px 0px 0px 0;
            }
          }
          .yesteday_Main_Right2_Down_Circle2 {
            width: px2rem(14);
            height: px2rem(14);
            background: rgba(172, 64, 234, 1);
            border: px2rem(1) solid rgba(145, 36, 221, 1);
            border-radius: 50%;
            margin: 0px 0px px2rem(22) px2rem(32);
          }
          .yesteday_Main_Right2_Down_UnExpected {
            width: 87px;
            height: 16px;
            font-size: px2rem(15);
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);
            margin: 0px 0px 0px px2rem(16);
          }
          .yesteday_Main_Right2_Down_UnExpected2 {
            width: 50px;
            height: 16px;
            font-size: px2rem(15);
            font-family: MicrosoftYaHei;
            font-weight: 400;
            color: rgba(58, 58, 58, 1);

            display: inline-flex;
            flex-direction: row;
            .yesteday_Main_Right2_Down_UnExpected2_Left {
              width: 30px;
              height: 16px;
              font-size: px2rem(15);
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: 0px 0px 0px px2rem(0);
            }
            .yesteday_Main_Right2_Down_UnExpected2_Right {
              width: 15px;
              height: 16px;
              font-size: px2rem(15);
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(58, 58, 58, 1);
              text-align: right;
              margin: 0px 0px 0px 0px;
            }
          }
        }
      }
    }
  }
}
</style>
