/*******************************
 * 文件名称：VitalSignLasterModel.cs
 * 文件说明：正在进行手术的患者的实时体征实体类
 * 作    者：许文龙
 * 日    期：2017-04-11
 * *****************************/
using GalaSoft.MvvmLight;
using MedicalSystem.AnesWorkStation.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MedicalSystem.AnesWorkStation.Model.WorkListModel
{
    /// <summary>
    /// 患者当前体征数据
    /// </summary>
    public class SignInfoModel : ObservableObject
    {
        private string itemCode;             // 体征编号
        private string itemName;             // 体征名称
        private string itemValue;            // 体征数值

        /// <summary>
        /// 体征编号
        /// </summary>
        public string ItemCode
        {
            get { return this.itemCode; }
            set
            {
                this.itemCode = value;
                this.RaisePropertyChanged("ItemCode");
            }
        }

        /// <summary>
        /// 体征名称
        /// </summary>
        public string ItemName
        {
            get { return this.itemName; }
            set
            {
                this.itemName = value;
                this.RaisePropertyChanged("ItemName");
            }
        }

        /// <summary>
        /// 体征数值
        /// </summary>
        public string ItemValue
        {
            get { return this.itemValue; }
            set
            {
                this.itemValue = value;
                this.RaisePropertyChanged("ItemValue");
            }
        }

        /// <summary>
        /// 静态方法：将表结构数据转换成实体类
        /// </summary>
        public static SignInfoModel CreateModel(MED_VITAL_SIGN vitalSign)
        { 
            SignInfoModel infoModel = null;
            if(null != vitalSign)
            {
                infoModel = new SignInfoModel();
                infoModel.ItemCode = vitalSign.ITEM_CODE;
                infoModel.ItemName = vitalSign.ITEM_NAME;
                infoModel.ItemValue = vitalSign.ITEM_VALUE;
            }

            return infoModel;
        }

        /// <summary>
        /// 将MED_VITAL_SIGN列表转换成 SignInfoModel列表
        /// </summary>
        public static IEnumerable<SignInfoModel> CreateListModel(IEnumerable<MED_VITAL_SIGN> vitalSignList)
        {
            List<SignInfoModel> list = new List<SignInfoModel>();
            if (vitalSignList != null)
            {
                foreach (MED_VITAL_SIGN item in vitalSignList.Where<MED_VITAL_SIGN>(x => !x.ITEM_CODE.Equals("89") && !x.ITEM_CODE.Equals("90")))
                {
                    list.Add(CreateModel(item));
                }

                AssembleBloodPressure(vitalSignList, ref list);
            }

            return list;
        }

        /// <summary>
        /// 根据舒张压和舒缩压组合血压
        /// </summary>
        public static SignInfoModel AssembleBloodPressure(IEnumerable<MED_VITAL_SIGN> vitalSignList, ref List<SignInfoModel> list)
        {
            SignInfoModel infoModel = null;

            if (null != vitalSignList)
            { 
                // 收缩压
                IEnumerable<MED_VITAL_SIGN> ssSign = vitalSignList.Where<MED_VITAL_SIGN>(x => x.ITEM_CODE.Equals("89"));
                // 舒张压
                IEnumerable<MED_VITAL_SIGN> szSign = vitalSignList.Where<MED_VITAL_SIGN>(x => x.ITEM_CODE.Equals("90"));

                if (szSign.Count<MED_VITAL_SIGN>() > 0 && ssSign.Count<MED_VITAL_SIGN>() > 0)
                {
                    infoModel = new SignInfoModel();
                    infoModel.ItemCode = string.Format("{0}/{1}", ssSign.First<MED_VITAL_SIGN>().ITEM_CODE, szSign.First<MED_VITAL_SIGN>().ITEM_CODE);
                    infoModel.ItemName = "血压";
                    infoModel.ItemValue = string.Format("{0}/{1}", ssSign.First<MED_VITAL_SIGN>().ITEM_VALUE, szSign.First<MED_VITAL_SIGN>().ITEM_VALUE);
                    list.Add(infoModel);
                }
            }

            return infoModel;
        }
    }
}
