using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnterScenesController : Controller
{
    public override void Execute(object data)
    {
        ScenesInfo info = data as ScenesInfo;
        //GameModel gameModel = GetModel<GameModel>();
        switch (info.scenesIndex)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                RegisterView(GameObject.FindWithTag(Tags.player).GetComponent<PlayerController>());
                RegisterView(GameObject.FindWithTag(Tags.player).GetComponent<AnimationController>());
                RegisterView(GameObject.Find("Canvas").GetComponentInChildren<PlayingUI>());
                RegisterView(GameObject.Find("Canvas").GetComponentInChildren<PauseGameUI>());
                RegisterView(GameObject.Find("Canvas").GetComponentInChildren<ContinueGameUI>());
                RegisterView(GameObject.Find("Canvas").GetComponentInChildren<FinalScoreUI>());
                RegisterView(GameObject.Find("Canvas").GetComponentInChildren<GameOverUI>());
                RegisterView(GameObject.FindWithTag(Tags.player).transform.Find("Ball_fly").GetComponent<BollHit>());
                break;
            default:
                break;
        }
        PauseGameUI pauseGameUI = GetView<PauseGameUI>();
        pauseGameUI.Hide();
        ContinueGameUI continueGameUI = GetView<ContinueGameUI>();
        continueGameUI.Hide();
        FinalScoreUI finalScoreUI = GetView<FinalScoreUI>();
        finalScoreUI.Hide();
        GameOverUI gameOverUI = GetView<GameOverUI>();
        gameOverUI.Hide();
    }
}
