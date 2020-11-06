using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.Data;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Castle.Components.Binder;
using System.ComponentModel;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public class BaseModel : INotifyPropertyChanged
    {
        #region Get All Props Name

        public IEnumerable<string> GetPropsName()
        {
            foreach (var prop in GetProperties())
            {
                yield return prop.Name;
            }
        }

        #endregion
        /// <summary>
        /// 类型属性缓存
        /// </summary>
        private static Dictionary<Type, PropertyInfo[]> _cacheTypePropsDict = null;
        /// <summary>
        /// 值类型转换工具
        /// </summary>
        private static IConverter converter = null;
        /// <summary>
        /// 所有属性
        /// </summary>
        /// <returns></returns>
        private PropertyInfo[] GetProperties()
        {
            PropertyInfo[] propInfos = null;
            Type type = this.GetType();

            if (_cacheTypePropsDict == null)
            {
                _cacheTypePropsDict = new Dictionary<Type, PropertyInfo[]>();
            }

            if (!_cacheTypePropsDict.TryGetValue(type, out propInfos) || propInfos == null)
            {
                propInfos = type.GetProperties();
                _cacheTypePropsDict[type] = propInfos;
            }

            return propInfos;
        }
        /// <summary>
        /// 获取当前某一个名称的字段属性
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private PropertyInfo GetProperty(string name)
        {
            PropertyInfo[] propInfos = GetProperties();
            return propInfos.FirstOrDefault(x => x.Name.ToUpper() == name.ToUpper());
        }

        [NotMapped]
        public ModelStatus ModelStatus { get; set; }

        #region Get Set Value

        /// <summary>
        /// 取值
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <returns>当前值</returns>
        public object GetValue(string fieldName)
        {
            return GetProperty(fieldName).GetValue(this, null);
        }

        /// <summary>
        /// 取值
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <returns>当前值</returns>
        public T GetValue<T>(string fieldName)
        {
            return (T)GetValue(fieldName);
        }

        /// <summary>
        /// 赋值
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="value">当前值</param>
        public void SetValue(string fieldName, object value)
        {
            var prop = GetProperty(fieldName);

            bool conversionSucceeded = false;

            if (converter == null)
            {
                converter = new DefaultConverter();
            }
            if (prop.PropertyType == typeof(DateTime?))
            {
                value = null;
                conversionSucceeded = true;
            }
            else
            {
                value = converter.Convert(prop.PropertyType, typeof(string), value, out conversionSucceeded);

            }

            if (conversionSucceeded)
            {
                prop.SetValue(this, value, null);
            }
        }

        #endregion

        [NotMapped]
        public object UnifyDisplay { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string aa)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(aa));
                if (this.ModelStatus != ModelStatus.Add)
                {
                    this.ModelStatus = ModelStatus.Modeified;
                }
            }
        }

    }

    public enum ModelStatus
    {
        Default = 0,
        Add = 1,
        Modeified = 2,
        Deleted = 3
    }


}
