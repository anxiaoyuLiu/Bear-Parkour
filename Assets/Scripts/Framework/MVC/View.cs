using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class View : MonoBehaviour {

	public abstract string Name { get; }
    [HideInInspector]
    public List<string> eventList = new List<string>();

    public virtual void RegisterEventList() { }

    public abstract void HandleEvent(string eventName, object data);

    protected void SendEvent(string eventName, object data=null)
    {
        MVC.SendEvent(eventName, data);
    }

    protected T GetModel<T>()
        where T : Model
    {
        return MVC.GetModel<T>() as T;
    }
}
