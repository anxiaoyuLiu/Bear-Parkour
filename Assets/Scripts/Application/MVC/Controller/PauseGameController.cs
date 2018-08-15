using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameController : Controller
{

    public override void Execute(object data)
    {
        GameSetting.Instance.playSound.PauseBgAudio();
        GameSetting.Instance.playSound.PauseStepAudio();

        GameModel gameModel = GetModel<GameModel>();
        gameModel.IsPause = true;
        ShowPauseGameUI();
    }

    private void ShowPauseGameUI()
    {
        GameModel gameModel = GetModel<GameModel>();
        PauseGameUI pauseGameUI = GetView<PauseGameUI>();
        pauseGameUI.Distance = gameModel.Distance;
        pauseGameUI.Coin = gameModel.Coin;
        pauseGameUI.Goal = gameModel.Goal;
        pauseGameUI.Show();
    }


}
