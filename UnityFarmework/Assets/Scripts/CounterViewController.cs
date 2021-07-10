using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterViewController : MonoBehaviour
{
    CounterModel mCounterModel;
    private void Start()
    {
        mCounterModel = CounterApp.Get<CounterModel>();
        mCounterModel.Count.OnValueChanged += OnCountChanged;
        OnCountChanged(mCounterModel.Count.Value);

        transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() => {
            new AddCountCommand().Execute();
        });

        transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
        {
            mCounterModel.Count.Value--;
        });

    }

    void OnCountChanged(int newCount)
    {
        transform.Find("CountText").GetComponent<Text>().text = newCount.ToString();
    }



    void OnDestroy()
    {
        mCounterModel.Count.OnValueChanged -= OnCountChanged;
        mCounterModel = null;
    }
}

public interface ICounterModel:IModel
{
    BindableProperty<int> Count
    {
        get;
    }
}

public class CounterModel:ICounterModel
{
    public CounterModel()
    {
        
    }

    public BindableProperty<int> Count { get; } = new BindableProperty<int>()
    {
        Value = 0
    };
    public IArchitecture Architecture
    {
        get;
        set;
    }

    public void Init()
    {
        var storage = Architecture.GetUtility<IStorage>();
        Count.Value = PlayerPrefs.GetInt("COUNTER_COUNT", 0);
        Count.OnValueChanged += count => { storage.SaveInt("COUNTER_COUNT", count); };
    }
}
