using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EndGameController : Controller
{
    public override void Execute(object data=null)
    {
        GameModel gameModel = GetModel<GameModel>();
        GameOverUI gameOverUI = GetView<GameOverUI>();

        gameOverUI.Show();
        gameModel.IsOver = true;
        //gameModel.IsPause = true;
        //Time.timeScale = 0;
        GameSetting.Instance.playSound.PauseBgAudio();
        GameSetting.Instance.playSound.PauseStepAudio();
    }

}
