using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IArchitecture
{
    void RegisterModel<T>(T model) where T : IModel;
    void RegisterUtility<T>(T utility);
    T GetUtility<T>() where T : class;
}

public abstract class Architecture<T>:IArchitecture where T : Architecture<T>, new()
{
    private static T mArchitecture;
    //是否初始化完成
    private bool mInited = false;
    private List<IModel> mModels = new List<IModel>();
    public static Action<T> OnRegisterPatch = architecture => { };
    static void MakeSureArchitecture()
    {
        if (mArchitecture == null)
        {
            mArchitecture = new T();
            //注册模块
            mArchitecture.Init();
            OnRegisterPatch?.Invoke(mArchitecture);
            foreach (var architectureModel in mArchitecture.mModels)
            {
                architectureModel.Init();
            }
            mArchitecture.mModels.Clear();
            mArchitecture.mInited = true;
        }
    }

    protected abstract void Init();

    private IOCContainer mContainer = new IOCContainer();

    public static T Get<T>()where T:class
    {
        MakeSureArchitecture();
        return mArchitecture.mContainer.Get<T>();
    }

    
    public static void Register<T>(T instance) 
    {
        MakeSureArchitecture();
        mArchitecture.mContainer.Register<T>(instance);

        
    }

    public void RegisterModel<T>(T model) where T : IModel
    {
        model.Architecture = this;
        mContainer.Register<T>(model);
        if (!mInited)
        {
            mModels.Add(model);
        }
        else
        {
            model.Init();
        }
    }
    public T GetUtility<T>() where T : class
    {
        return mContainer.Get<T>();
    }

    public void RegisterUtility<T>(T utility)
    {
        mContainer.Register<T>(utility);
    }
}
