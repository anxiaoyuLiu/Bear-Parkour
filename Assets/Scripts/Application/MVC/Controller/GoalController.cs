using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : Controller {

    public override void Execute(object data)
    {
        //1.分数增加
        GameModel gameModel = GetModel<GameModel>();
        gameModel.Goal++;

        //2.停止运动足球的协程
        //3.将足球位置还原(playerController中处理)
        PlayerController playerController = GetView<PlayerController>();
        playerController.StopIShootBall();

        //4.播放特效
        GameSetting.Instance.objectPool.GetObject(Const.FX_Goal, data as Transform);

        //5.播放进球音效
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Goal);
    }

}
