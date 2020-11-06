
namespace MedicalSystem.AnesIcuQuery.Models
{
    public class QueryParamsType
    {
        public QueryParamsType()
        {
        }
        public QueryParamsType(string fieldName, OperationEnum operationEnum, object obj)
        {
            _fieldName = fieldName;
            _operationEnum = operationEnum;
            _obj = obj;

        }
        object _obj;
        OperationEnum _operationEnum = OperationEnum.Equal;
        string _fieldName = "";

        /// <summary>
        /// 数据类型
        /// </summary>
        public object obj
        {
            set { _obj = value; }
            get { return _obj; }
        }
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName
        {
            set { _fieldName = value; }
            get { return _fieldName; }
        }

        /// <summary>
        /// 枚举操作符
        /// </summary>
        public OperationEnum operationEnum
        {
            set { _operationEnum = value; }
            get { return _operationEnum; }
        }


    }
}
