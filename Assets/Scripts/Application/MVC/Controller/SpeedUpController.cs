using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpController : Controller
{
    public override void Execute(object data)
    {
        GameModel gameModel = GetModel<GameModel>();
        PlayingUI playingUI = GetView<PlayingUI>();
        PlayerController playerController = GetView<PlayerController>();
        //Run run = GetView<Run>();

        gameModel.IsSpeedUp = true;
        playingUI.ShowSpeedUpCooling();
        //playerController.ChangeMultiple();
        //run.ChangeSpeed();
        playerController.ChangeSpeed();
        playerController.ShowEffect_speedUp();
    }
}
