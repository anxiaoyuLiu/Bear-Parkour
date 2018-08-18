using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinulGameController : Controller
{
    public override void Execute(object data)
    {
        GameSetting.Instance.playSound.PlayBgAudio(Const.Bgm_ZhanDou);
        GameModel gameModel = GetModel<GameModel>();
        PauseGameUI pauseGameUI = GetView<PauseGameUI>();
        ContinueGameUI continueGameUI = GetView<ContinueGameUI>();

        if ((bool)data)
        {
            gameModel.IsPause = false;
            GameSetting.Instance.playSound.PlayStepAudio();
        }
        else
        {
            pauseGameUI.Hide();
            continueGameUI.Show("continue");
        }

    }
}
