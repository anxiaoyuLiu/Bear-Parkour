using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class EnterScenesController : Controller
{
    public override void Execute(object data)
    {
        ScenesInfo info = data as ScenesInfo;
        //GameModel gameModel = GetModel<GameModel>();
        switch (info.scenesIndex)
        {
            case 1:
                RegisterView(GameObject.Find("MainMenuUI").GetComponent<MainMenuUI>());
                GameSetting.Instance.playSound.PlayBgAudio(Const.Bgm_JieMian);
                break;
            case 2:
                RegisterView(GameObject.Find("ChangeLookingUI").GetComponent<ChangeLookingUI>());
                GameSetting.Instance.playSound.PlayBgAudio(Const.Bgm_JieMian);
                break;
            case 3:
                RegisterView(GameObject.Find("Canvas").GetComponentInChildren<SkillShopUI>());
                GameSetting.Instance.playSound.PlayBgAudio(Const.Bgm_JieMian);
                break;
            case 4:
                //PlayerController playerController = GameObject.FindWithTag(Tags.test).GetComponent<PlayerController>();
                RegisterView(GameObject.FindWithTag(Tags.test).GetComponent<PlayerController>());
                RegisterView(GameObject.FindWithTag(Tags.test).GetComponent<AnimationController>());
                RegisterView(GameObject.FindWithTag(Tags.test).GetComponent<Run>());
                RegisterView(GameObject.FindWithTag(Tags.canvas).GetComponentInChildren<PlayingUI>());
                RegisterView(GameObject.Find(Tags.canvas).GetComponentInChildren<PauseGameUI>());
                RegisterView(GameObject.Find(Tags.canvas).GetComponentInChildren<ContinueGameUI>());
                RegisterView(GameObject.Find(Tags.canvas).GetComponentInChildren<FinalScoreUI>());
                RegisterView(GameObject.Find(Tags.canvas).GetComponentInChildren<GameOverUI>());
                RegisterView(GameObject.FindWithTag(Tags.test).transform.Find("Ball_fly").GetComponent<BollHit>());
                GameModel gameModel = GetModel<GameModel>();
                gameModel.IsOver = false; 
                gameModel.IsPause = false;
                gameModel.Coin = 0;
                gameModel.Distance = 0;
                GameSetting.Instance.playSound.PlayBgAudio(Const.Bgm_ZhanDou);
                GameSetting.Instance.playSound.PlayStepAudio();

                //PauseGameUI pauseGameUI = GetView<PauseGameUI>();
                //if (pauseGameUI != null)
                //{
                //    pauseGameUI.Hide();
                //}
                //ContinueGameUI continueGameUI = GetView<ContinueGameUI>();
                //if (continueGameUI != null)
                //{
                //    continueGameUI.Hide();
                //}
                //FinalScoreUI finalScoreUI = GetView<FinalScoreUI>();
                //if (finalScoreUI != null)
                //{
                //    finalScoreUI.Hide();
                //}
                //GameOverUI gameOverUI = GetView<GameOverUI>();
                //if (gameOverUI != null)
                //{
                //    gameOverUI.Hide();
                //}
                break;
            default:
                break;
        }

    }
}
