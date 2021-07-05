using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class BindableProperty<T> where T:IEquatable<T>
{
    private T mValue = default(T);
    public T Value
    {
        get => mValue;
        set
        {
            if (!value.Equals(mValue))
            {
                mValue = value;
                OnValueChanged?.Invoke(value);
            }
        }
    }

    public Action<T> OnValueChanged;
}
