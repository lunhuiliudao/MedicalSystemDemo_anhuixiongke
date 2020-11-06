using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.ViewModel
{
    /// <summary>
    /// GC资源释放的扩展方法类
    /// </summary>
    public static class GCExtension
    {
        /// <summary>
        /// 析构方法中调用，清空当前类型的所有的引用类型的指。
        /// </summary>
        /// <param name="cls">类的实例</param>
        /// <param name="declaredOnly">是否当前自身定义的属性</param>
        public static void Destroy(this object cls, bool declaredOnly = false)
        {
            try
            {
                Type t = cls.GetType();
                if (t.IsClass)
                {
                    System.Reflection.BindingFlags bindingFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public;
                    if (declaredOnly)
                    {
                        bindingFlags = bindingFlags | System.Reflection.BindingFlags.DeclaredOnly;
                    }
                    var pros = t.GetProperties(bindingFlags);
                    foreach (System.Reflection.PropertyInfo pi in pros)
                    {
                        if (pi.CanWrite && pi.PropertyType.IsClass)
                        {
                            try
                            {
                                object obj = pi.GetValue(cls, null);
                                if (obj != null)
                                {
                                    //如果是集合对象，则调用方法清空所有对象。
                                    //System.Reflection.MethodInfo m;
                                    //if ((m = pi.PropertyType.GetMethod("Clear")) != null && m.GetParameters().Length == 0)
                                    //{
                                    //    m.Invoke(obj, null);
                                    //}
                                    pi.SetValue(cls, null, null);
                                }
                            }
                            catch (Exception ex)
                            {
                                MedicalSystem.Services.Logger.Info("释放资源错误", ex);
                            }
                        }
                    }

                    var fields = t.GetFields(bindingFlags);
                    foreach (System.Reflection.FieldInfo pi in fields)
                    {
                        if (pi.FieldType.IsClass)
                        {
                            try
                            {
                                object obj = pi.GetValue(cls);
                                if (obj != null)
                                {
                                    //如果是集合对象，则调用方法清空所有对象。
                                    //System.Reflection.MethodInfo m;
                                    //if ((m = pi.FieldType.GetMethod("Clear")) != null && m.GetParameters().Length == 0)
                                    //{
                                    //    m.Invoke(obj, null);
                                    //}
                                    pi.SetValue(cls, null);
                                }
                            }
                            catch (Exception ex)
                            {
                                MedicalSystem.Services.Logger.Info("释放资源错误", ex);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //屏蔽错误，不能影响主要功能，不许出错。
                MedicalSystem.Services.Logger.Info("释放资源错误", ex);
            }
        }
    }
}
