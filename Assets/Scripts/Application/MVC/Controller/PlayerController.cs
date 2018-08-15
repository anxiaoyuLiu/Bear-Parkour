using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : View {

    //private CharacterController controller;
    private InputDirection input;
    public int currentRoad = 1;
    private int targetRoad = 1;
    private float offsets = 0;
    private int changeSpeed = 10;
    public bool isChanging = false;
    public bool isJumping = false;
    public bool isRolling = false;
    private GameModel gameModel;
    private Run run;
    private int multiple = 1;//金币倍数
    private IEnumerator CoinIEnumerator;
    private IEnumerator MagnetIEnumerator;
    private SphereCollider magnetTrigger;
    public float recordSpeed;
    //public float currentSpeed;
    //public GameObject TestSlider;

    public GameObject ball_static;
    private GameObject ball_fly;
    public GameObject Effect_speedUp;

    //public bool isPlay;
    //public bool isPause;

    //private Vector3 localPosition;//记录足球的本地位置信息

    public override string Name
    {
        get
        {
            return Const.V_PlayerController;
        }
    }

    private void Awake()
    {
        //controller = GetComponent<CharacterController>();
        gameModel = GetModel<GameModel>();
        run = GetComponent<Run>();
        magnetTrigger = GetComponentInChildren<SphereCollider>();
        magnetTrigger.enabled = false;
        //ball_fly.SetActive(false);
    }

    private void Update()
    {
        if (gameModel.IsPlay && !gameModel.IsPause && !run.isInHit)
        {
            GetInput();
            MoveControl();
            UpdatePosition();
        }
        //isPause = gameModel.IsPause;
        //isPlay = gameModel.IsPlay;
        //currentSpeed = gameModel.Speed;

        //For Test
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SendEvent(Const.E_PauseGame);
        //}
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    SendEvent(Const.E_ContinueGame);
        //}

    }

    private void GetInput()
    {
        input = InputDirection.Null;
        if (Input.GetKeyDown(KeyCode.W))
        {
            input = InputDirection.Up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            input = InputDirection.Down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            input = InputDirection.Left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            input = InputDirection.Right;
        }
    }

    private void MoveControl()
    {
        switch (input)
        {
            case InputDirection.Null:
                break;
            case InputDirection.Up:
                if (!isChanging)
                {
                    //Debug.Log("w");
                    run.upSpeed = 5.8f;
                    isJumping = true;
                    SendMessage("AnimaController", input);
                    GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Jump);
                }
                break;
            case InputDirection.Down:
                if (!isChanging)
                {
                    //Debug.Log("s");
                    isRolling = true;
                    SendMessage("AnimaController", input);
                    GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Huadong);
                }
                break;
            case InputDirection.Left:
                if (currentRoad > 0&&!isChanging)
                {
                    //Debug.Log("a");
                    targetRoad = currentRoad - 1;
                    offsets = -2;
                    SendMessage("AnimaController", input);
                    GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
                }
                break;
            case InputDirection.Right:
                if (currentRoad < 2&&!isChanging)
                {
                    //Debug.Log("d");
                    targetRoad = currentRoad + 1;
                    offsets = 2;
                    SendMessage("AnimaController", input);
                    GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
                }
                break;
            default:
                break;
        }
    }

    private void UpdatePosition()
    {
        if (currentRoad != targetRoad)
        {
            float distance = Mathf.Lerp(0, offsets, changeSpeed * Time.deltaTime);
            transform.position += new Vector3(distance, 0, 0);
            offsets -= distance;
            if (Mathf.Abs(offsets) < 0.05f)
            {
                currentRoad = targetRoad;
                switch (currentRoad)
                {
                    case 0:
                        transform.position = new Vector3(-2, transform.position.y, transform.position.z);
                        break;
                    case 1:
                        transform.position = new Vector3(0, transform.position.y, transform.position.z);
                        break;
                    case 2:
                        transform.position = new Vector3(2, transform.position.y, transform.position.z);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    //获得金币
    public void HitCoin()
    {
        if (multiple == 1)
        {
            gameModel.Coin++;
        }
        else
        {
            gameModel.Coin += 2;
        }
        SendEvent(Const.E_UpdateCoin);
    }

    //获得星星（双倍金币）
    public void HitStars()
    {
        SendEvent(Const.E_UpdateSkill_DoubleCoin);
        ChangeMultiple();
        //gameModel.IsDoubleCoin = true;
        //TestSlider.SetActive(true);
    }

    public void ChangeMultiple()
    {
        if (CoinIEnumerator != null)
        {
            StopCoroutine(CoinIEnumerator);
        }
        CoinIEnumerator = DoubleCoin();
        StartCoroutine(CoinIEnumerator);
    }

    IEnumerator DoubleCoin()
    {
        multiple = 2;
        float timer = gameModel.StarsTime;
        while (timer > 0)
        {
            if (gameModel.IsPlay && !gameModel.IsPause)
            {
                timer -= Time.deltaTime;
            }
            yield return 0;
        }
        //yield return new WaitForSeconds(gameModel.StarsTime);
        multiple = 1;
        gameModel.IsDoubleCoin = false;
    }

    //获得吸铁石
    public void HitMagnet()
    {
        SendEvent(Const.E_UpdateSkill_Magnet);
        AttractCoin();
    }

    public void AttractCoin()
    {
        if (MagnetIEnumerator != null)
        {
            StopCoroutine(MagnetIEnumerator);
        }
        MagnetIEnumerator = IAttractCoin();
        StartCoroutine(MagnetIEnumerator);
    }

    IEnumerator IAttractCoin()
    {
        magnetTrigger.enabled = true;
        float timer = gameModel.StarsTime;
        while (timer > 0)
        {
            if (gameModel.IsPlay && !gameModel.IsPause)
            {
                timer -= Time.deltaTime;
            }
            yield return 0;
        }
        //yield return new WaitForSeconds(gameModel.MagnetTime);
        magnetTrigger.enabled = false;
        gameModel.IsMagnet = false;
    }

    //获得时钟
    public void HitClock()
    {
        gameModel.Times += 10;
        SendEvent(Const.E_UpdateTime);
    }


    public void ChangeSpeed()
    {
        StartCoroutine(IChangeSpeed());
    }

    IEnumerator IChangeSpeed()
    {
        GameSetting.Instance.playSound.StepAudioSpeedUp();
        recordSpeed = gameModel.Speed;
        gameModel.Speed += 10;
        float timer = gameModel.StarsTime;
        while (timer > 0)
        {
            if (gameModel.IsPlay && !gameModel.IsPause)
            {
                timer -= Time.deltaTime;
            }
            yield return 0;
        }
        //yield return new WaitForSeconds(gameModel.SpeedUpTime);
        gameModel.Speed = recordSpeed;
        gameModel.IsSpeedUp = false;
        GameSetting.Instance.playSound.StepAudioSpeedDown();
    }

    //射门

    public void Getball_fly(GameObject obj)
    {
        ball_fly = obj;
    }

    public void ShootBall()
    {
        ball_static.SetActive(false);
        ball_fly.SetActive(true);
        int num = UnityEngine.Random.Range(0,2);
        SendMessage("SendMessagePlayShoot",num);//向动画控制器发消息
        //localPosition = transform.localPosition;
        //Debug.Log(localPosition);
        StartCoroutine(IShootBall());
    }

    IEnumerator IShootBall()
    {
        while (true)
        {
            if (gameModel.IsPlay && !gameModel.IsPause)
            {
                ball_fly.transform.Translate(transform.forward * 20 * Time.deltaTime);
                yield return 0;
            }
        }
    }

    public void StopIShootBall()
    {
        StopCoroutine(IShootBall());
        ball_static.SetActive(true);
        //ball_fly.SetActive(false);
        //ball_fly.transform.localPosition = localPosition;
        //ball_fly.transform.Translate(Vector3.zero);
        //Debug.Log(localPosition);
    }

    //显示加速特效
    public void ShowEffect_speedUp()
    {
        Effect_speedUp.SetActive(true);
        StartCoroutine(IShowEffect_speedUp());
    }

    IEnumerator IShowEffect_speedUp()
    {
        yield return new WaitForSeconds(gameModel.SpeedUpTime-2);
        Effect_speedUp.SetActive(false);
    }

    public override void RegisterEventList()
    {
        base.RegisterEventList();
        //eventList.Add(Const.E_Shoot);
    }

    public override void HandleEvent(string eventName, object data)
    {
        switch (eventName)
        {
            //case Const.E_Shoot:
            //    ShootBall();
            //    break;
            default:
                break;
        }
    }
}