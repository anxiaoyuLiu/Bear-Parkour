using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGameUI : View {

    private bool wait = false;

    private int distance = 0;
    private int coin = 0;
    private int goal = 0;

    public Text DistanceText;
    public Text CoinText;
    public Text GoalText;

    private void Start()
    {
        Hide();
    }

    public override string Name
    {
        get
        {
            return Const.V_PauseGameUI;
        }
    }

    public int Distance
    {
        get
        {
            return distance;
        }

        set
        {
            distance = value;
            DistanceText.text = distance.ToString();
        }
    }

    public int Coin
    {
        get
        {
            return coin;
        }

        set
        {
            coin = value;
            CoinText.text = coin.ToString();
        }
    }

    public int Goal
    {
        get
        {
            return goal;
        }

        set
        {
            goal = value;
            GoalText.text = goal.ToString();
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void ContinueGameClick()
    {
        SendEvent(Const.E_ContinueGame,wait);
    }

    public override void RegisterEventList()
    {
        base.RegisterEventList();
        //eventList.Add(Const.E_UpdateDistance);
        //eventList.Add(Const.E_UpdateCoin);
        //eventList.Add(Const.E_UpdateBall);
    }

    public override void HandleEvent(string eventName, object data)
    {
        
    }
}
