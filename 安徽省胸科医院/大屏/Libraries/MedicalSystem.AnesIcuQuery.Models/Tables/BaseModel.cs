using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using Dapper.Data;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 基类索引
    /// </summary>
    [Serializable]
    public class BaseModel
    {
        /// <summary>
        /// 数据存储的字典
        /// </summary>
        private readonly IDictionary<string, object> dic
            = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// 检查是否存在字段名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ContainsFeild(string name)
        {
            return dic.ContainsKey(name);
        }

        /// <summary>
        /// this索引
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        //[Write(false)]
        public object this[string name]
        {
            get
            {
                if (ContainsFeild(name))
                    return dic[name];
                else
                {
                    return null;
                    /*throw new ArgumentException(string.Format("在该实体[{0}]不存在属性[{1}]。",
                        this.GetType().Name, name));*/
                }
            }
            set { dic[name] = value; }
        }

        #region 获取主键的HashCode,便于快速比较匹配。

        protected int hashCode = 0;

        /// <summary>
        /// 获取主键的HashCode,便于快速比较匹配。
        /// </summary>
        /// <returns></returns>
        public virtual int GetKeyHashCode()
        {
            return GetHashCode();
        }

        #endregion
    }
}
