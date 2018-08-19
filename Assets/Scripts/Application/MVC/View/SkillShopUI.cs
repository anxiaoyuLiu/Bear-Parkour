using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillShopUI : View
{
    GameModel gameModel;
    public Text coinText;

    private void Awake()
    {
        gameModel = GetModel<GameModel>();
        coinText.text = gameModel.Coin_Total.ToString();
    }

    public override string Name
    {
        get
        {
            return Const.V_SkillShopUI;
        }
    }

    public void BuyRandom()
    {
        int index = Random.Range(0, 3);
        switch (index)
        {
            case 0:
                BuyDoubleCoin();
                break;
            case 1:
                BuySpeedUp();
                break;
            case 3:
                BuyMagnet();
                break;
            default:
                break;
        }
    }

    public void BuyDoubleCoin()
    {
        SendEvent(Const.E_BuySkill, "DoubleCoin");
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
        //Debug.Log(gameModel.Coin_Total);
    }

    public void BuySpeedUp()
    {
        SendEvent(Const.E_BuySkill, "SpeedUp");
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
        //Debug.Log(gameModel.Coin_Total);
    }

    public void BuyMagnet()
    {
        SendEvent(Const.E_BuySkill, "Magnet");
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
        //Debug.Log(gameModel.Coin_Total);
    }

    public void AddCoinButtonClick()
    {
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public void AddChocolateButtonClick()
    {
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public void HomeButtonClick()
    {
        GameSetting.Instance.LoadScene(1);
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public void SettingButtonClick()
    {
        GameSetting.Instance.LoadScene(2);
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public void StartGameButtonClick()
    {
        GameSetting.Instance.LoadScene(4);
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public void UpdateCoin()
    {
        coinText.text = gameModel.Coin_Total.ToString();
    }

    public override void RegisterEventList()
    {
        base.RegisterEventList();
        eventList.Add(Const.E_UpdateCoin);
    }

    public override void HandleEvent(string eventName, object data)
    {
        switch (eventName)
        {
            case Const.E_UpdateCoin:
                UpdateCoin();
                break;
            default:
                break;
        }
    }
}
