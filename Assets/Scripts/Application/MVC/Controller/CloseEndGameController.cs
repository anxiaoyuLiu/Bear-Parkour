using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEndGameController : Controller {

    public override void Execute(object data)
    {
        FinalScoreUI finalScoreUI = GetView<FinalScoreUI>();
        finalScoreUI.gameObject.SetActive(true);
        finalScoreUI.UpdateUIMessage();
    }

}
