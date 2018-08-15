using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : Controller {

    public override void Execute(object data=null)
    {
        GameObject go = GameSetting.Instance.objectPool.GetObject(Const.Ball_fly, data as Transform);

        PlayerController playerController = GetView<PlayerController>();
        playerController.Getball_fly(go);
        playerController.ShootBall();

        //GameSetting.Instance.objectPool.GetObject(Const.Item_Goal,data as Transform)
    }

}
