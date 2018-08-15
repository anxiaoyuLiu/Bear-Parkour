using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayingUI : View
{
    private int coin = 0;
    private int distance = 0;
    private int minute = 0;
    private int second = 0;
    private int speedUpSkillCount = 0;
    private int doubleCoinSkillCount = 0;
    private int magnetSkillCount = 0;

    public Text CoinText;
    public Text DistanceText;
    public Slider TimeSlider;
    public Text TimeText;

    public Button SpeedUpButton;
    public Button DoubleCoinButton;
    public Button MagnetButton;
    private Slider SpeedUpSlider;
    private Slider DoubleCoinSlider;
    private Slider MagnetSlider;
    public Text SpeedUpCountText;
    public Text DoubleCoinCountText;
    public Text MagnetCountText;

    public Button ShootButton;
    public Slider ShootSlider;

    private GameModel gameModel;

    private Transform effectParent;

    private void Awake()
    {
        SpeedUpSlider = transform.Find("SpeedUpSlider").GetComponent<Slider>();
        DoubleCoinSlider = transform.Find("DoubleCoinSlider").GetComponent<Slider>();
        MagnetSlider = transform.Find("MagnetSlider").GetComponent<Slider>();
        gameModel = GetModel<GameModel>();
        effectParent = GameObject.FindWithTag(Tags.player).transform;
        SetButton();
        SetSlider();
    }

    private void Update()
    {
        if (gameModel.IsPlay && !gameModel.IsPause)
        {
            Times -= Time.deltaTime;
        }
    }

    //属性
    public override string Name
    {
        get
        {
            return Const.V_PlayingUI;
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

    public float Times
    {
        get
        {
            return gameModel.Times;
        }

        set
        {
            gameModel.Times = value;
            UpdateTimes();
        }
    }

    public int MagnetSkillCount
    {
        get
        {
            return magnetSkillCount;
        }

        set
        {
            magnetSkillCount = value;
            MagnetCountText.text = "x" + magnetSkillCount.ToString();
            UpdateButton();
        }
    }

    public int DoubleCoinSkillCount
    {
        get
        {
            return doubleCoinSkillCount;
        }

        set
        {
            doubleCoinSkillCount = value;
            DoubleCoinCountText.text = "x" + doubleCoinSkillCount.ToString();
            UpdateButton();
        }
    }

    public int SpeedUpSkillCount
    {
        get
        {
            return speedUpSkillCount;
        }

        set
        {
            speedUpSkillCount = value;
            SpeedUpCountText.text = "x" + speedUpSkillCount.ToString();
            UpdateButton();
        }
    }

    //时间条更新
    private void UpdateTimes()
    {
        minute = ((int)gameModel.Times / 60);
        second = ((int)gameModel.Times % 60);
        if (second > 9)
        {
            TimeText.text = minute.ToString() + ":" + second.ToString();
        }
        else
        {
            TimeText.text = minute.ToString() + ":0" + second.ToString();
        }
        TimeSlider.value = Times / 120;
    }

    //游戏按键初始化
    private void SetButton()
    {
        SpeedUpCountText.text = "x" + gameModel.SpeedUpSkillCount.ToString();
        DoubleCoinCountText.text = "x" + gameModel.DoubleCoinSkillCount.ToString();
        MagnetCountText.text = "x" + gameModel.MagnetSkillCount.ToString();

        UpdateButton();
    }

    //技能冷却图标初始化
    private void SetSlider()
    {
        DoubleCoinSlider.gameObject.SetActive(false);
        SpeedUpSlider.gameObject.SetActive(false);
        MagnetSlider.gameObject.SetActive(false);
        //DoubleCoinSlider.SetActive(false);
        //SpeedUpSlider.SetActive(false);
        //MagnetSlider.SetActive(false);
    }

    //技能按键更新
    public void UpdateButton()
    {
        if (gameModel.SpeedUpSkillCount > 0)
        {
            SpeedUpButton.interactable = true;
            transform.Find("SpeedUpButton/SpeedUpButtonMask").gameObject.SetActive(false);
        }
        else
        {
            SpeedUpButton.interactable = false;
            transform.Find("SpeedUpButton/SpeedUpButtonMask").gameObject.SetActive(true);
        }

        if (gameModel.DoubleCoinSkillCount > 0)
        {
            DoubleCoinButton.interactable = true;
            transform.Find("DoubleCoinButton/DoubleCoinButtonMask").gameObject.SetActive(false);
        }
        else
        {
            DoubleCoinButton.interactable = false;
            transform.Find("DoubleCoinButton/DoubleCoinButtonMask").gameObject.SetActive(true);
        }

        if (gameModel.MagnetSkillCount > 0)
        {
            MagnetButton.interactable = true;
            transform.Find("MagnetButton/MagnetButtonMask").gameObject.SetActive(false);
        }
        else
        {
            MagnetButton.interactable = false;
            transform.Find("MagnetButton/MagnetButtonMask").gameObject.SetActive(true);
        }
    }

    //射门Button和Slider更新
    //1.射门Button激活
    //2.射门Slider开始计时
    private void UpdateShootButtonAndSlider()
    {
        ShootButton.interactable = true;
        StartCoroutine(IShootTime());
    }

    IEnumerator IShootTime()
    {
        ShootSlider.value = 1;
        while (ShootSlider.value > 0)
        {
            if (gameModel.IsPlay && !gameModel.IsPause)
            {
                ShootSlider.value -= Time.deltaTime * 0.25f;
            }
            yield return 0;
        }
        ShootButton.interactable = false;
    }

    //按键处理
    public void PauseButtonClick()
    {
        SendEvent(Const.E_PauseGame);
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public void SpeedUpButtonClick()
    {
        if (gameModel.IsSpeedUp)
        {
            return;
        }
        SendEvent(Const.E_UpdateSkill_SpeedUp);
        gameModel.SpeedUpSkillCount--;
        SpeedUpSkillCount = gameModel.SpeedUpSkillCount;
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public void DoubleCoinButtonClick()
    {
        if (gameModel.IsDoubleCoin)
        {
            return;
        }
        SendEvent(Const.E_UpdateSkill_DoubleCoin);
        gameModel.DoubleCoinSkillCount--;
        DoubleCoinSkillCount = gameModel.DoubleCoinSkillCount;
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public void MagnetButtonClick()
    {
        if (gameModel.IsMagnet)
        {
            return;
        }
        SendEvent(Const.E_UpdateSkill_Magnet);
        gameModel.MagnetSkillCount--;
        MagnetSkillCount = gameModel.MagnetSkillCount;
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public void ShootButtonClick()
    {
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Kicked);
        ShootButton.interactable = false;
        ShootSlider.value = 0;
        SendEvent(Const.E_Shoot,effectParent);
        //SendEvent(Const.E_Shoot);
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    //技能冷却图标处理
    public void ShowDoubleCoinCooling()
    {
        DoubleCoinSlider.gameObject.SetActive(true);
        StartCoroutine(IShowDoubleCoinCooling());
    }

    IEnumerator IShowDoubleCoinCooling()
    {
        float timer = gameModel.StarsTime;
        while (timer > 0)
        {
            if (gameModel.IsPlay && !gameModel.IsPause)
            {
                timer -= Time.deltaTime;
                DoubleCoinSlider.GetComponent<Slider>().value = timer / gameModel.StarsTime;
            }
            yield return 0;
        }
        DoubleCoinSlider.gameObject.SetActive(false);
    }

    public void ShowSpeedUpCooling()
    {
        SpeedUpSlider.gameObject.SetActive(true);
        StartCoroutine(IShowSpeedUpCooling());
    }

    IEnumerator IShowSpeedUpCooling()
    {
        float timer = gameModel.SpeedUpTime - 2;
        while (timer > 0)
        {
            if (gameModel.IsPlay && !gameModel.IsPause)
            {
                timer -= Time.deltaTime;
                SpeedUpSlider.GetComponent<Slider>().value = timer / (gameModel.SpeedUpTime - 2);
            }
            yield return 0;
        }
        SpeedUpSlider.gameObject.SetActive(false);
    }

    public void ShowMagnetCooling()
    {
        MagnetSlider.gameObject.SetActive(true);
        StartCoroutine(IShowMagnetCooling());
    }

    IEnumerator IShowMagnetCooling()
    {
        float timer = gameModel.MagnetTime;
        while (timer > 0)
        {
            if (gameModel.IsPlay && !gameModel.IsPause)
            {
                timer -= Time.deltaTime;
                MagnetSlider.GetComponent<Slider>().value = timer / gameModel.MagnetTime;
            }
            yield return 0;
        }
        MagnetSlider.gameObject.SetActive(false);
    }

    //添加与UI界面有交互的事件
    public override void RegisterEventList()
    {
        base.RegisterEventList();
        eventList.Add(Const.E_UpdateDistance);
        eventList.Add(Const.E_UpdateCoin);
        eventList.Add(Const.E_UpdateTime);
        eventList.Add(Const.E_ReadyShoot);
    }

    //处理事件
    public override void HandleEvent(string eventName, object data)
    {
        switch (eventName)
        {
            case Const.E_UpdateDistance:
                Distance = gameModel.Distance;
                break;
            case Const.E_UpdateCoin:
                Coin = gameModel.Coin;
                break;
            case Const.E_UpdateTime:
                Times = gameModel.Times;
                break;
            case Const.E_ReadyShoot:
                UpdateShootButtonAndSlider();
                break;
            //case Const.E_UpdateSkill_Magnet:
            //    //Coin = gameModel.Coin;
            //    break;
            //case Const.E_UpdateSkill_SpeedUp:
            //    //Times = gameModel.Times;
            //    break;
            default:
                break;
        }
    }
}
