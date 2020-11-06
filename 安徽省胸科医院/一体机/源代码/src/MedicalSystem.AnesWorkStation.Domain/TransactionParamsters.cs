//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//
//文件名称(File Name)：      TransactionParamsters.cs
//功能描述(Description)：    使用事务批量处理数据时，将所有数据整合到一个字典子类中，在webapi中去解析
//                           该类在反解析时有个问题，不能动态的反序列化数据
//数据表(Tables)：		      
//作者(Author)：             许文龙
//日期(Create Date)：        2017-12-27 10:49:12
// 
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.AnesWorkStation.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MedicalSystem.AnesWorkStation.Model
{
    /// <summary>
    /// 使用事务批量处理数据时，将所有数据整合到一个字典子类中
    /// </summary>
    [Serializable]
    public class TransactionParamsters : Dictionary<Type, string>
    {
        /// <summary>
        /// 静态方法创建对象
        /// </summary>
        public static TransactionParamsters Create()
        {
            return new TransactionParamsters();
        }

        /// <summary>
        /// 追加数据到字典：只能是之前不存在的数据类型，同一种类型的数据只能传一次
        /// </summary>
        public TransactionParamsters Append(BaseModel child)
        {
            if (child != null)
            {
                Type t = child.GetType();
                if (!this.ContainsKey(t))
                {
                    List<BaseModel> tempList = new List<BaseModel>();
                    tempList.Add(child);
                    this[t] = JsonConvert.SerializeObject(tempList);
                }
            }

            return this;
        }

        /// <summary>
        /// 追加数据到字典：只能是之前不存在的数据类型，同一种类型的数据只能传一次
        /// </summary>
        public TransactionParamsters Append(params IEnumerable<BaseModel>[] pars)
        {
            if (pars != null)
            {
                foreach (var p in pars)
                {
                    Type t = p.GetType();
                    // 获取类型
                    if (t.IsGenericType)
                    {
                        t = t.GetGenericArguments()[0];
                    }

                    // 对应的数据插入字典中 
                    if (!this.ContainsKey(t))
                    {
                        this[t] = JsonConvert.SerializeObject(p);
                    }
                }
            }

            return this;
        }

        /// <summary>
        /// 根据传入的参数创建对象
        /// 传入的参数列表，同一种类型的数据只能传一次
        /// </summary>
        public static TransactionParamsters Create(params IEnumerable<BaseModel>[] pars)
        {
            TransactionParamsters transParams = Create();

            if (pars != null)
            {
                foreach (var p in pars)
                {
                    Type t = p.GetType();
                    // 获取类型
                    if (t.IsGenericType)
                    {
                        t = t.GetGenericArguments()[0];
                    }

                    // 对应的数据插入字典中 
                    if (!transParams.ContainsKey(t))
                    {
                        transParams[t] = JsonConvert.SerializeObject(p);
                    }
                }
            }

            return transParams;
        }

        /// <summary>
        /// 根据传入的参数创建对象
        /// 传入的参数列表，同一种类型的数据只能传一次
        /// </summary>
        public static TransactionParamsters Create(params BaseModel[] pars)
        {
            TransactionParamsters transParams = Create();

            if (pars != null)
            {
                foreach (var p in pars)
                {
                    Type t = p.GetType();
                    // 获取类型
                    if (t.IsGenericType)
                    {
                        t = t.GetGenericArguments()[0];
                    }

                    // 对应的数据插入字典中 
                    if (!transParams.ContainsKey(t))
                    {
                        transParams[t] = JsonConvert.SerializeObject(p);
                    }
                }
            }

            return transParams;
        }

        /// <summary>
        /// 重写ToString方法，返回对象序列化后的字符串
        /// </summary>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
