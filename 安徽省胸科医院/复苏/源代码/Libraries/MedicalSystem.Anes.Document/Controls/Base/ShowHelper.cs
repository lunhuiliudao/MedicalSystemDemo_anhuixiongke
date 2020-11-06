using MedicalSystem.Anes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Document.Controls.Base
{
    public class ShowHelper
    {

        static ShowHelper()
        {
            MED_ANESTHESIA_EVENT anesEvent = new MED_ANESTHESIA_EVENT();

            //反射获取该类的信息
            System.Reflection.PropertyInfo[] properties = anesEvent.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            foreach (System.Reflection.PropertyInfo item in properties)
            {
                _propertyNames.Add(item.Name);
            }
        }

        // 用于记录MED_ANESTHESIA_EVENT所有属性的名字
        private static List<string> _propertyNames = new List<string>();
        public static List<string> PropertyNames
        {
            get
            {
                return _propertyNames;
            }
            set
            {
                _propertyNames = value;
            }
        }

        /// <summary>
        /// 通过传过来的字符串（用药显示包含用药和格式） 获取用药显示字符串
        /// </summary>
        /// <param name="passedDrugPointFormat">0、1、3、4、6、7、9</param>
        /// <returns></returns>
        public static string GetDrugPointShowFormat(string passedDrugPointFormat)
        {
            string[] passedDrugPointFormatArray = passedDrugPointFormat.Split(',');

            string[] drugPointShowFormatArray = new string[] { passedDrugPointFormatArray[0], passedDrugPointFormatArray[1], passedDrugPointFormatArray[3], passedDrugPointFormatArray[4], passedDrugPointFormatArray[6], passedDrugPointFormatArray[7], passedDrugPointFormatArray[9] };
            return string.Join(";", drugPointShowFormatArray);
        }
        /// <summary>
        /// 通过传过来的字符串（用药显示包含用药和格式） 获取用药显示的格式字符串
        /// </summary>
        /// <param name="passedDrugPointFormat">2、10、5、8</param>
        /// <returns></returns>
        public static string GetDrugPointMarkFormat(string passedDrugPointFormat)
        {
            string[] passedDrugPointFormatArray = passedDrugPointFormat.Split(',');

            string[] drugPointMarkFormatArray = new string[] { passedDrugPointFormatArray[2], passedDrugPointFormatArray[10], passedDrugPointFormatArray[5], passedDrugPointFormatArray[8] };
            return string.Join(";", drugPointMarkFormatArray);
        }
        /// <summary>
        /// 通过传过来的字符串（用药名字、名字格式） 获取用药名字
        /// </summary>
        /// <param name="passedDrugNameFormat">0、2、4、5、6---->0、2、5、8、11 </param>
        /// <returns></returns>
        public static string GetDrugNameShowFormat(string passedDrugNameFormat)
        {
            string[] passedDrugNameFormatArray = passedDrugNameFormat.Split(',');

            string[] drugNameShowFormatArray = new string[] { passedDrugNameFormatArray[0], passedDrugNameFormatArray[2], passedDrugNameFormatArray[5], passedDrugNameFormatArray[8], passedDrugNameFormatArray[11] };
            return string.Join(";", drugNameShowFormatArray);
        }
        /// <summary>
        /// 通过传过来的字符串（用药名字、名字格式） 获取用药名字格式字符串
        /// </summary>
        /// <param name="passedDrugNameFormat">1、3</param>
        /// <returns></returns>
        public static string GetDrugNameMarkFormat(string passedDrugNameFormat)
        {
            string[] passedDrugNameFormatArray = passedDrugNameFormat.Split(',');

            string[] drugNameMarkFormatArray = new string[] { passedDrugNameFormatArray[1], passedDrugNameFormatArray[3] };
            return string.Join(";", drugNameMarkFormatArray);
        }


        public static Dictionary<string, string> GetDrugDictionary<T>(T drug)
        {
            Dictionary<string, string> drugPoinDictionary = new Dictionary<string, string>();
            if (drug.GetType() == typeof(MedDrugPoint))
            {
                var point = drug as MedDrugPoint;

                drugPoinDictionary.Add("DOSAGE", point.Value == null ? string.Empty : point.Value.ToString());
                drugPoinDictionary.Add("DOSAGE_UNITS", string.IsNullOrEmpty(point.Unit) ? string.Empty : point.Unit.ToString());
                drugPoinDictionary.Add("PERFORM_SPEED", point.Speed.ToString());
                drugPoinDictionary.Add("SPEED_UNIT", string.IsNullOrEmpty(point.SpeedUnit) ? string.Empty : point.SpeedUnit.ToString());
                drugPoinDictionary.Add("CONCENTRATION", point.ThickNess.ToString());
                drugPoinDictionary.Add("CONCENTRATION_UNIT", string.IsNullOrEmpty(point.ThickNessUnit) ? string.Empty : point.ThickNessUnit.ToString());
                drugPoinDictionary.Add("ADMINISTRATOR", string.IsNullOrEmpty(point.Route) ? string.Empty : point.Route.ToString());
            }
            else if (drug.GetType() == typeof(MedDrugCurve))
            {
                var curve = drug as MedDrugCurve;
                MedDrugPoint point = curve.Points.FirstOrDefault(x => !string.IsNullOrEmpty(x.ThickNessUnit));//取出第一个浓度单位不为空的点

                drugPoinDictionary.Add("EVENT_ITEM_NAME", string.IsNullOrEmpty(curve.Text) ? string.Empty : curve.Text.ToString());
                drugPoinDictionary.Add("DOSAGE_UNITS", string.IsNullOrEmpty(curve.Unit) ? string.Empty : curve.Unit.ToString());
                drugPoinDictionary.Add("SPEED_UNIT", string.IsNullOrEmpty(curve.SpeedUnit) ? string.Empty : curve.SpeedUnit.ToString());
                drugPoinDictionary.Add("CONCENTRATION_UNIT", point == null ? string.Empty : point.ThickNessUnit);
                drugPoinDictionary.Add("ADMINISTRATOR", string.IsNullOrEmpty(curve.Route) ? string.Empty : curve.Route.ToString());
            }
            return drugPoinDictionary;
        }

        public static string GetDrugItemText<T>(T drug, string item, Dictionary<string, string> dictionary)
        {
            string value = string.Empty;
            string unit = string.Empty;
            if (drug.GetType() == typeof(MedDrugPoint))
            {
                if (item.Contains("DOSAGE"))
                {
                    double tempDos;
                    if (!string.IsNullOrEmpty(dictionary["DOSAGE"]) &&
                        double.TryParse(dictionary["DOSAGE"], out tempDos) &&
                        Convert.ToDouble(dictionary["DOSAGE"]) != 0)
                    {
                        value = dictionary["DOSAGE"];
                    }
                    if (item.Contains("DOSAGE_UNITS"))
                    {
                        unit = dictionary["DOSAGE_UNITS"];
                    }
                }
                else if (item.Contains("PERFORM_SPEED"))
                {
                    double tempSpeed;
                    if (!string.IsNullOrEmpty(dictionary["PERFORM_SPEED"]) &&
                        double.TryParse(dictionary["PERFORM_SPEED"], out tempSpeed) &&
                        Convert.ToDouble(dictionary["PERFORM_SPEED"]) != 0)
                    {
                        value = dictionary["PERFORM_SPEED"];
                    }
                    if (item.Contains("SPEED_UNIT"))
                    {
                        unit = dictionary["SPEED_UNIT"];
                    }
                }
                else if (item.Contains("CONCENTRATION"))
                {
                    double tempCon;
                    if (!string.IsNullOrEmpty(dictionary["CONCENTRATION"]) &&
                        double.TryParse(dictionary["CONCENTRATION"], out tempCon) &&
                        Convert.ToDouble(dictionary["CONCENTRATION"]) != 0)
                    {
                        value = dictionary["CONCENTRATION"];
                    }
                    if (item.Contains("CONCENTRATION_UNIT"))
                    {
                        unit = dictionary["CONCENTRATION_UNIT"];
                    }
                }
                else if (item.Contains("ADMINISTRATOR"))
                {
                    if (!string.IsNullOrEmpty(dictionary["ADMINISTRATOR"]))
                    {
                        value = dictionary["ADMINISTRATOR"];
                    }
                }
            }
            else if (drug.GetType() == typeof(MedDrugCurve))
            {
                if (item.Contains("EVENT_ITEM_NAME") && !string.IsNullOrEmpty(dictionary["EVENT_ITEM_NAME"]))
                {
                    value = dictionary["EVENT_ITEM_NAME"];
                }
                else if (item.Contains("DOSAGE_UNITS") && !string.IsNullOrEmpty(dictionary["DOSAGE_UNITS"]))
                {
                    unit = dictionary["DOSAGE_UNITS"];
                }
                else if (item.Contains("SPEED_UNIT") && !string.IsNullOrEmpty(dictionary["SPEED_UNIT"]))
                {
                    unit = dictionary["SPEED_UNIT"];
                }
                else if (item.Contains("CONCENTRATION_UNIT") && !string.IsNullOrEmpty(dictionary["CONCENTRATION_UNIT"]))
                {
                    unit = dictionary["CONCENTRATION_UNIT"];
                }
                else if (item.Contains("ADMINISTRATOR") && !string.IsNullOrEmpty(dictionary["ADMINISTRATOR"]))
                {
                    unit = dictionary["ADMINISTRATOR"];
                }
            }

            return value + unit;
        }




        public static string DrugName { get; set; }
        public static string FirstItem { get; set; }
        public static string SecondItem { get; set; }
        public static string ThirdItem { get; set; }
        public static string FourthItem { get; set; }//途径
        public static string LeftBracket { get; set; }//外围左括号
        public static string RightBracket { get; set; }//外围右括号
        public static string InnerMark { get; set; }//内部分割符
        public static string RouteIndentifier { get; set; }//途径位置标识符


        /// <summary>
        /// 用药显示的处理 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="passedMarkFormatText">标记分割字符串</param>
        /// <param name="passedContentFormatText">内容字符串</param>
        /// <returns></returns>
        public static string GetPointDrugShowText(MedDrugPoint point, String passedMarkFormatText, string passedContentFormatText)
        {
            //对单位和数值进行划分，划分成4个部分
            string[] contentArray = passedContentFormatText.Split(';');//7个(必定的)
            List<string> contentList = new List<string>();
            for (int i = 0; i < contentArray.Length; i++)
            {
                foreach (string name in PropertyNames)
                {
                    if (string.IsNullOrEmpty(contentArray[i]))//为空也加入
                    {
                        contentList.Add(string.Empty);
                        break;//同一个属性名为空，只计算一次
                    }
                    if (contentArray[i] == name)//字段名加入
                    {
                        contentList.Add(contentArray[i]);
                    }
                }
            }
            FirstItem = contentList[0] + contentList[1];
            SecondItem = contentList[2] + contentList[3];
            ThirdItem = contentList[4] + contentList[5];
            FourthItem = contentList[6];

            //对分割标识进行划分
            string[] markArray = passedMarkFormatText.Split(';');//必定是4个
            LeftBracket = markArray[0];
            RightBracket = markArray[1];
            InnerMark = markArray[2];

            //根据平台上的传值,确定途径标识符
            //RouteIndentifier = markArray[3];
            switch (markArray[3])
            {
                case "C1"://括号内
                    RouteIndentifier = string.Empty;
                    break;
                case "C2"://括号外
                    RouteIndentifier = RightBracket;
                    break;
                case "C3"://换行
                    RouteIndentifier = "\r\n";
                    break;
                case ""://没有值的话默认在括号内
                    RouteIndentifier = string.Empty;
                    break;

            }



            Dictionary<string, string> drugPoinDictionary = GetDrugDictionary(point);

            FirstItem = GetDrugItemText(point, FirstItem, drugPoinDictionary);
            SecondItem = GetDrugItemText(point, SecondItem, drugPoinDictionary);
            ThirdItem = GetDrugItemText(point, ThirdItem, drugPoinDictionary);
            FourthItem = GetDrugItemText(point, FourthItem, drugPoinDictionary);


            int flag = 0;//用于判断全在括号里的情况
            if (!string.IsNullOrEmpty(SecondItem)) flag++;
            if (!string.IsNullOrEmpty(ThirdItem)) flag++;
            if (!string.IsNullOrEmpty(FourthItem)) flag++;






            string text = string.Empty;
            if (RouteIndentifier == "\r\n")//途径需要换行的时候（2、3在括号里）
            {
                if (string.IsNullOrEmpty(FirstItem))//第一项为空，之后的括号不需要
                {
                    LeftBracket = string.Empty;
                    RightBracket = string.Empty;
                }
                if (!string.IsNullOrEmpty(SecondItem) && !string.IsNullOrEmpty(ThirdItem))//都不为空
                {
                    text = FirstItem + LeftBracket + SecondItem + InnerMark + ThirdItem + RightBracket + "\r\n" + FourthItem;
                }
                else if (string.IsNullOrEmpty(SecondItem) && string.IsNullOrEmpty(ThirdItem))//全为空
                {
                    text = FirstItem + "\r\n" + FourthItem;
                }
                else//其中之一为空
                {
                    text = FirstItem + LeftBracket + SecondItem + ThirdItem + RightBracket + "\r\n" + FourthItem;
                }
            }

            else if (RouteIndentifier.Equals(RightBracket))//途径在括号外围的时候
            {
                if (string.IsNullOrEmpty(FirstItem))//第一项为空，之后的括号不需要
                {
                    LeftBracket = string.Empty;
                    RightBracket = string.Empty;
                }
                if (!string.IsNullOrEmpty(SecondItem) && !string.IsNullOrEmpty(ThirdItem))//都不为空
                {
                    text = FirstItem + LeftBracket + SecondItem + InnerMark + ThirdItem + RightBracket + FourthItem;
                }
                else if (string.IsNullOrEmpty(SecondItem) && string.IsNullOrEmpty(ThirdItem))//全为空
                {
                    text = FirstItem + (string.IsNullOrEmpty(FourthItem) ? FourthItem : " " + FourthItem);//当途径不为空 在前面加个空格
                }
                else//其中之一为空
                {
                    text = FirstItem + LeftBracket + SecondItem + ThirdItem + RightBracket + FourthItem;
                }
            }
            else if (RouteIndentifier.Equals(string.Empty))//途径在括号里
            {
                if (string.IsNullOrEmpty(FirstItem))//第一项为空，之后的括号不需要
                {
                    LeftBracket = string.Empty;
                    RightBracket = string.Empty;
                }
                if (flag == 3)
                {
                    text = FirstItem + LeftBracket + SecondItem + InnerMark + ThirdItem + InnerMark + FourthItem + RightBracket;
                }
                else if (flag == 0)
                {
                    text = FirstItem;
                }
                else if (flag == 2)
                {
                    text = FirstItem + LeftBracket + (string.IsNullOrEmpty(SecondItem) ? SecondItem : SecondItem + InnerMark) + ThirdItem + (string.IsNullOrEmpty(FourthItem) ? FourthItem : InnerMark + FourthItem) + RightBracket;
                }
                else//i=1
                {
                    text = FirstItem + LeftBracket + SecondItem + ThirdItem + FourthItem + RightBracket;
                }
            }
            return text;
        }


        /// <summary>
        /// 药名显示的处理
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="passedMarkFormatText"></param>
        /// <param name="passedNameFormatText"></param>
        /// <returns></returns>
        public static string GetDrugNameShowText(MedDrugCurve curve, String passedMarkFormatText, string passedNameFormatText)
        {
            string[] nameArray = passedNameFormatText.Split(';');//5个必定
            List<string> nameList = new List<string>();
            for (int i = 0; i < nameArray.Length; i++)
            {
                foreach (string name in PropertyNames)
                {
                    if (string.IsNullOrEmpty(nameArray[i]))//为空也加入
                    {
                        nameList.Add(string.Empty);
                        break;//同一个属性名为空，只计算一次
                    }
                    if (nameArray[i] == name)//字段名加入
                    {
                        nameList.Add(nameArray[i]);
                    }
                }
            }
            DrugName = nameList[0];
            FirstItem = nameList[1];
            SecondItem = nameList[2];
            ThirdItem = nameList[3];
            FourthItem = nameList[4];


            //对分割标识进行划分
            string[] markArray = passedMarkFormatText.Split(';');//必定是2个
            LeftBracket = markArray[0];
            RightBracket = markArray[1];


            Dictionary<string, string> drugPoinDictionary = GetDrugDictionary(curve);
            DrugName = GetDrugItemText(curve, DrugName, drugPoinDictionary);
            FirstItem = GetDrugItemText(curve, FirstItem, drugPoinDictionary);
            SecondItem = GetDrugItemText(curve, SecondItem, drugPoinDictionary);
            ThirdItem = GetDrugItemText(curve, ThirdItem, drugPoinDictionary);
            FourthItem = GetDrugItemText(curve, FourthItem, drugPoinDictionary);

            string text = string.Empty;
            if (!string.IsNullOrEmpty(FirstItem))
            {
                FirstItem = LeftBracket + FirstItem + RightBracket;
            }
            if (!string.IsNullOrEmpty(SecondItem))
            {
                SecondItem = LeftBracket + SecondItem + RightBracket;
            }
            if (!string.IsNullOrEmpty(ThirdItem))
            {
                ThirdItem = LeftBracket + ThirdItem + RightBracket;
            }
            if (!string.IsNullOrEmpty(FourthItem))
            {
                FourthItem = LeftBracket + FourthItem + RightBracket;
            }
            return text = DrugName + FirstItem + SecondItem + ThirdItem + FourthItem;

        }

    }
}
