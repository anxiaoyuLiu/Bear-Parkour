using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayContinueGameController : Controller {

    public override void Execute(object data)
    {

        GameSetting.Instance.playSound.PlayBgAudio(Const.Bgm_ZhanDou);
        GameModel gameModel = GetModel<GameModel>();
        GameOverUI gameOverUI = GetView<GameOverUI>();
        ContinueGameUI continueGameUI = GetView<ContinueGameUI>();

        if ((bool)data)
        {
            gameModel.IsPlay = true;
            GameSetting.Instance.playSound.PlayStepAudio();
        }
        else
        {
            continueGameUI.Show("payContinue");
            gameOverUI.Hide();
        }
    }

}
