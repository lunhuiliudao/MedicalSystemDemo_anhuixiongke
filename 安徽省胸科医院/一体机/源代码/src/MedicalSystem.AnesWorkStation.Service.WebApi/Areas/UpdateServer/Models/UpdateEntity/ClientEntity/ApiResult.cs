using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateEntity
{
    public class ApiResult<T>
    {
        private string _Msg;

        /// <summary>
        /// 消息
        /// </summary>
        public string Msg
        {
            get { return _Msg; }
            set { _Msg = value; }
        }

        private T _Data;

        public T Data
        {
            get { return _Data; }
            set { _Data = value; }
        }

    }
}
