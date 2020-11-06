using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace MedicalSytem.Soft.Model
{
    public class ModelBase
    {
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
 

        /// <summary>
        /// 获取自身信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override string ToString()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(this);
        }
    }
}
