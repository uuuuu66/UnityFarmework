﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOCExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //创建一个IOC容器
        var container = new IOCContainer();
        //注册一个蓝牙管理器的实例
        container.Register<IBluetoothManager>(new BluetoothManager());
        //根据类型获取蓝牙管理器的实例
        var bluetoothManager = container.Get<IBluetoothManager>();
        //调用实例方法
        bluetoothManager.Connect();
    }

}

public interface IBluetoothManager
{
    void Connect();
}


public class BluetoothManager:IBluetoothManager
{
    public void Connect()
    {
        Debug.Log("蓝牙连接成功");
    }
}