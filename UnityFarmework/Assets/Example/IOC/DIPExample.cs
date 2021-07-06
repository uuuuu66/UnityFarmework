﻿#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;



public class DIPExample : MonoBehaviour
{
    public interface IStorage
    {
        void SaveString(string key, string value = "");
        string LoadString(string key, string defaultValue = "");
    }

    public class PlayerPrefsStorage : IStorage
    {
        

        public void SaveString(string key, string value = "")
        {
            PlayerPrefs.SetString(key, value);
        }

        public string LoadString(string key, string defaultValue = "")
        {
            return PlayerPrefs.GetString(key, defaultValue);
        }
    }

    public class EditorPrefsStorage : IStorage
    {
        public string LoadString(string key, string defaultValue = "")
        {
#if UNITY_EDITOR
            return EditorPrefs.GetString(key, defaultValue);
#else
            return "";
#endif
        }

        public void SaveString(string key, string value = "")
        {
#if UNITY_EDITOR
            EditorPrefs.SetString(key, value);
#endif
        }
    }

    void Start()
    {
        var container = new IOCContainer();
        container.Register<IStorage>(new PlayerPrefsStorage());
        var storage = container.Get<IStorage>();
        storage.SaveString("name", "运行时储存");
        Debug.Log(storage.LoadString("name"));

        container.Register<IStorage>(new EditorPrefsStorage());
        storage = container.Get<IStorage>();
        Debug.Log(storage.LoadString("name"));
    }

}
