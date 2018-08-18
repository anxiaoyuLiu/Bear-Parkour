using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySkillController : Controller {

    public override void Execute(object data = null)
    {
        GameModel gameModel = GetModel<GameModel>();
        SkillShopUI skillShopUI = GetView<SkillShopUI>();
        switch (data as string)
        {
            case "DoubleCoin":
                if (gameModel.Coin_Total >= 20)
                {
                    gameModel.Coin_Total -= 20;
                    gameModel.DoubleCoinSkillCount++;
                    skillShopUI.UpdateCoin();
                }
                break;
            case "SpeedUp":
                if (gameModel.Coin_Total >= 25)
                {
                    gameModel.Coin_Total -= 25;
                    gameModel.SpeedUpSkillCount++;
                    skillShopUI.UpdateCoin();
                }
                break;
            case "Magnet":
                if (gameModel.Coin_Total >= 15)
                {
                    gameModel.Coin_Total -= 15;
                    gameModel.MagnetSkillCount++;
                    skillShopUI.UpdateCoin();
                }
                break;
            default:
                break;
        }
    }

}
