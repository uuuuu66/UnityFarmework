using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AddCountCommand : ICommand
{

    public void Execute()
    {
        CounterApp.Get<CounterModel>().Count.Value++;
    }
}
