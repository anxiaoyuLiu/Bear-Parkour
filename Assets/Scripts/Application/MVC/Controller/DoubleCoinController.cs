using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCoinController : Controller
{
    public override void Execute(object data)
    {
        GameModel gameModel = GetModel<GameModel>();
        PlayingUI playingUI = GetView<PlayingUI>();
        PlayerController playerController = GetView<PlayerController>();

        gameModel.IsDoubleCoin = true;
        playingUI.ShowDoubleCoinCooling();
        playerController.ChangeMultiple();
    }
}
