using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayingUI : View {

    public Text DistanceText;
    GameModel gameModel;

    private void Awake()
    {
        gameModel = GetModel<GameModel>();
    }

    private void Update()
    {
        DistanceText.text = gameModel.Distance.ToString();
    }

    public override string Name
    {
        get
        {
            return Const.V_GamePlayingUI;
        }
    }

    public override void HandleEvent(string eventName, object data)
    {
        throw new System.NotImplementedException();
    }

}
