using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScenesController : Controller {

    public override void Execute(object data = null)
    {
        ScenesInfo info = data as ScenesInfo;
        //GameModel gameModel = GetModel<GameModel>();
        switch (info.scenesIndex)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                GameSetting.Instance.playSound.PauseBgAudio();
                break;
            case 4:
                GameSetting.Instance.objectPool.ClearPools();
                GameSetting.Instance.playSound.PauseBgAudio();
                GameSetting.Instance.playSound.PauseStepAudio();
                break;
            default:
                break;
        }
    }

}
