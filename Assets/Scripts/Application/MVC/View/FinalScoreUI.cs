using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreUI : View {

    GameModel gameModel;
    public Text scoreText;
    public Text distanceText;
    public Text coinText;
    public Text goalText;
    public Text lvText;
    public Text expText;
    public Slider expSlider;

    private float value;

    private void Awake()
    {
        gameModel = GetModel<GameModel>();

        value = (float)gameModel.Exp / (float)gameModel.Exp_Up;
        lvText.text = "Lv." + gameModel.Lv.ToString();
        expText.text = gameModel.Exp.ToString() + "/" + gameModel.Exp_Up.ToString();
        expSlider.value = value;
    }

    private void Start()
    {
        Hide();
    }

    public override string Name
    {
        get
        {
            return Const.V_FinalScoreUI;
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

    public void UpdateUIMessage()
    {
        distanceText.text = gameModel.Distance.ToString();
        coinText.text = gameModel.Coin.ToString();
        goalText.text = gameModel.Goal.ToString();
        gameModel.Score = gameModel.Distance * 6 + gameModel.Coin * 50 + gameModel.Goal * 200;
        scoreText.text = gameModel.Score.ToString();
        gameModel.Exp = gameModel.Score / 50;
        StartCoroutine(IShowExpSliderUp());
        gameModel.Coin_Total += gameModel.Coin;
    }

    IEnumerator IShowExpSliderUp()
    {
        while (gameModel.Exp >= gameModel.Exp_Up)
        {
            gameModel.Lv ++;
            gameModel.Exp = gameModel.Exp - gameModel.Exp_Up;
            gameModel.Exp_Up += 500;
            expText.text = gameModel.Exp.ToString() + "/" + gameModel.Exp_Up.ToString();
            while (expSlider.value < 1)
            {
                expSlider.value += 0.05f;
                yield return new WaitForSeconds(0.05f);
            }
            lvText.text = "Lv." + gameModel.Lv.ToString();
            expSlider.value = 0;
        }
        expText.text = gameModel.Exp.ToString() + "/" + gameModel.Exp_Up.ToString();
        value = (float)gameModel.Exp / (float)gameModel.Exp_Up;
        while (expSlider.value < value)
        {
            expSlider.value += 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
        lvText.text = "Lv." + gameModel.Lv.ToString();
    }

    public void HomeButtonClick()
    {
        SendEvent(Const.E_BackHome);
    }

    public void ShopButtonClick()
    {
        SendEvent(Const.E_GoShopping);
        //GameSetting.Instance.LoadScene(3);
    }

    public void RestartButtonClick()
    {
        SendEvent(Const.E_Restart);
        //GameSetting.Instance.LoadScene(4);
    }

    public void QuitButtonClick()
    {
        Application.Quit();
    }

    public override void HandleEvent(string eventName, object data)
    {
        throw new System.NotImplementedException();
    }
}
