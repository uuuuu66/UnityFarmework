using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanSayHello
{
    void SayHello();
    void SayOther();
}

public class InterfaceDesignExample : MonoBehaviour,ICanSayHello
{
    public void SayHello()
    {
        Debug.Log("Hello");
    }

    void ICanSayHello.SayOther()
    {
        Debug.Log("Other");
    }



    // Start is called before the first frame update
    void Start()
    {
        this.SayHello();
        (this as ICanSayHello).SayOther();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
