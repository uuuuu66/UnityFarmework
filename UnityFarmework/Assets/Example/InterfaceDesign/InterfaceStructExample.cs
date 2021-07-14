using UnityEngine;



public class InterfaceStructExample : MonoBehaviour
{
    public interface ICustomScript
    {
        void Start();
        void Update();
        void Destroy();
    }


    public abstract class CustomSctipt : ICustomScript
    {
        //防止循环调用，所以借口显示调用
        void ICustomScript.Destroy()
        {
            OnDestroy();
        }

        void ICustomScript.Start()
        {
            OnStart();
        }

        void ICustomScript.Update()
        {
            OnUpdate();
        }

        protected abstract void OnStart();
        protected abstract void OnUpdate();
        protected abstract void OnDestroy();
    }

    public class MyScript : CustomSctipt
    {
        protected override void OnDestroy()
        {
            Debug.Log("On Start");
        }

        protected override void OnStart()
        {
            Debug.Log("On Update");
        }

        protected override void OnUpdate()
        {
            Debug.Log("On Destroy");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ICustomScript myScript = new MyScript();
        myScript.Start();
        myScript.Update();
        myScript.Destroy();
    }

}
