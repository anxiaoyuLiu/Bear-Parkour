using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EndGameController : Controller
{
    public override void Execute(object data)
    {
        GameModel gameModel = GetModel<GameModel>();
        gameModel.IsPlay = false;
        GameSetting.Instance.playSound.PauseBgAudio();
        GameSetting.Instance.playSound.PauseStepAudio();
        GameOverUI gameOverUI = GetView<GameOverUI>();
        gameOverUI.Show();
        //TODO:结束UI显示
    }

}
