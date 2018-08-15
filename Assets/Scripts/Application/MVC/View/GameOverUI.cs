using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : View {

    private GameModel gameModel;
    public Text coinText;
    public GameObject showMessage;
    private bool wait = false;

    public override string Name
    {
        get
        {
            return Const.V_GameOverUI;
        }
    }

    private void Awake()
    {
        gameModel = GetModel<GameModel>();
        showMessage.SetActive(false);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        coinText.text = gameModel.PayCoin.ToString();
        gameObject.SetActive(true);
    }

    public void PayButtonClick()
    {
        if (gameModel.Coin_Total >= gameModel.PayCoin)
        {
            gameModel.Coin_Total -= 500;
            gameModel.PayCoin += 500;
            SendEvent(Const.E_PayContinueGame,wait);
        }
        else
        {
            StartCoroutine(IShowMessage());
        }
    }

    IEnumerator IShowMessage()
    {
        showMessage.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        showMessage.SetActive(false);
    }

    public void CloseButtonClick()
    {
        Hide();
        SendEvent(Const.E_CloseEndGame);
    }

    public override void RegisterEventList()
    {
        base.RegisterEventList();
        eventList.Add(Const.E_EndGame);
    }

    public override void HandleEvent(string eventName, object data)
    {
        switch (eventName)
        {
            case Const.E_EndGame:
                Show();
                break;
            default:
                break;
        }
    }
}
