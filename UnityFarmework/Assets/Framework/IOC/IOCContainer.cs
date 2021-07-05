
using System.Collections.Generic;
using System;

/// <summary>
/// IOC容器对比单例可以让外界不获得单例实例，使项目更整洁
/// </summary>
public class IOCContainer
{
    Dictionary<Type, object> mInstance = new Dictionary<Type, object>();
    /// <summary>
    /// 注册
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="instance"></param>
    public void Register<T>(T instance)
    {
        var key = typeof(T);
        if (mInstance.ContainsKey(key))
        {
            mInstance[key] = instance;
        }
        else
        {
            mInstance.Add(key, instance);
        }
    }
    /// <summary>
    /// 获取
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T Get<T>() where T : class
    {
        var key = typeof(T);

        object retInstance;
        if (mInstance.TryGetValue(key ,out retInstance))
        {
            return retInstance as T;
        }
        return null;
    }
}
