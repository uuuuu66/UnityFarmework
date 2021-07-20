using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MsgDispatcher : MonoBehaviour
{

    static Dictionary<string, Action<object>> mRegisteredMsgs = new Dictionary<string, Action<object>>();

    public static void Register(string msgName, Action<object> onMessageReceived)
    {
        if (!mRegisteredMsgs.ContainsKey(msgName))
        {
            mRegisteredMsgs.Add(msgName, onMessageReceived);
        }
        mRegisteredMsgs[msgName] += onMessageReceived;
    }

    public static void UnRegisterAll(string msgName)
    {
        mRegisteredMsgs.Remove(msgName);
    }

    public static void UnRegister(string msgName,Action<object> onMsgReceived)
    {
        if (mRegisteredMsgs.ContainsKey(msgName))
        {
            mRegisteredMsgs[msgName] -= onMsgReceived;
        }
    }

    public static void Send(string msgName, object data)
    {
        if (mRegisteredMsgs.ContainsKey(msgName))
        {
            mRegisteredMsgs[msgName](data);
        }
    }


    //示例
#if UNITY_EDITOR
    [UnityEditor.MenuItem("example/messageExample")]
#endif
    private static void MenuClicked()
    {
        Register("消息1", OnMsgReceived);
        Register("消息1", OnMsgReceived);
        Send("消息1", "hello world");
        UnRegister("消息1", OnMsgReceived);
        Send("消息1", "注销了1个");
    }

    static void OnMsgReceived(object data)
    {
        Debug.LogFormat("消息：{0}", data);
    }
}

