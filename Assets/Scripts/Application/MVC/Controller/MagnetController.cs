using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : Controller
{
    public override void Execute(object data)
    {
        GameModel gameModel = GetModel<GameModel>();
        PlayingUI playingUI = GetView<PlayingUI>();
        PlayerController playerController = GetView<PlayerController>();

        gameModel.IsMagnet = true;
        playingUI.ShowMagnetCooling();
        playerController.AttractCoin();
    }
}
