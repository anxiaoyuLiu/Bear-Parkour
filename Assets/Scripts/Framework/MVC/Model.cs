using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Model : MonoBehaviour
{
    public abstract string Name { get;}

    protected void SendEvent(string eventName,object data)
    {
        MVC.SendEvent(eventName, data);
    }
}
