using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterApp : Architecture<CounterApp>
{
    protected override void Init()
    {
        RegisterUtility<IStorage>(new PlayerPrefsStorage());
        RegisterModel(new CounterModel());
    }
}
