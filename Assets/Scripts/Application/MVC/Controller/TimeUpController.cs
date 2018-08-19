using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUpController : Controller {

    public override void Execute(object data = null)
    {
        GameModel gameModel = GetModel<GameModel>();
        FinalScoreUI finalScoreUI = GetView<FinalScoreUI>();
        gameModel.IsOver = true;
        finalScoreUI.gameObject.SetActive(true);
        finalScoreUI.UpdateUIMessage();
    }

}
