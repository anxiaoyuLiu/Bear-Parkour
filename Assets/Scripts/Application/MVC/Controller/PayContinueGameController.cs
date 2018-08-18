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
            gameModel.IsOver = false;
            //gameModel.IsPause = false;
            GameSetting.Instance.playSound.PlayStepAudio();
        }
        else
        {
            gameModel.IsOver = true;
            //Time.timeScale = 1;
            gameOverUI.Hide();
            continueGameUI.Show("payContinue");
        }
    }

}
