using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatObjectController : Controller {

    public override void Execute(object data)
    {
        string name = data as string;
        GameSetting.Instance.objectPool.GetObject(name);
    }

}
