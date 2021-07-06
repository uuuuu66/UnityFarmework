using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterApp : Architecture<CounterApp>
{
    protected override void Init()
    {
        Register (new CounterModel());
    }
}
