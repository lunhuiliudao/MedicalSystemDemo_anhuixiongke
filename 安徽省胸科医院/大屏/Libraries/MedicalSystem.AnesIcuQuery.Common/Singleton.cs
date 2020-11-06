
namespace MedicalSystem.AnesIcuQuery.Common
{
    /// <summary>
    /// 泛型单例模式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> where T : new()
    {
        private static T instance;

        /// <summary>
        /// 唯一实例
        /// </summary>
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (typeof(T))
                    {
                        if (instance == null)
                        {
                            instance = new T();
                            //需要非公共的无参构造函数，不能使用new T() ,new不支持非公共的无参构造函数 
                            //instance = (T)Activator.CreateInstance(typeof(T), true); //第二个参数防止异常：“没有为该对象定义无参数的构造函数。”
                        }
                    }
                }
                return instance;
            }
        }
    }
}
