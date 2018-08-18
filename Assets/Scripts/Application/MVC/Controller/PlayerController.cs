using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : View {

    //private CharacterController controller;
    public int currentRoad = 1;
    private int targetRoad = 1;
    private float offsets = 0;
    private int changeSpeed = 10;
    public bool isChanging = false;
    public float times = 1.2f;
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
        //gameModel.IsOver = false;
        //gameModel.IsPause = false;
        //ball_fly.SetActive(false);
    }

    private void Start()
    {
        //gameModel.IsPause = true;
        //SendEvent(Const.E_PauseGame);
    }

    private void Update()
    {
        if (!(gameModel.IsOver || gameModel.IsPause)) // && !run.isInHit
        {
            //GetInput(); //键盘输入（移动端取消）
            MoveControl();
            //Move(); //键盘测试方法
            UpdatePosition();
        }

        //运动状态判断是基于AnimationController中动画播放进度进行判断的，
        //当动画因角色死亡等因数意外提前结束，就会使得isChange一直为true，
        //导致控制输入失效。此处是对isChange值进行安全校验
        if (isChanging)
        {
            times -= Time.deltaTime;
            if (times < 0)
            {
                isChanging = false;
                times = 1.2f;
            }
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

    //触屏输入
    //enum slideVector { nullVector, up, down, left, right };
    private Vector2 touchFirst = Vector2.zero; //手指开始按下的位置
    private Vector2 touchSecond = Vector2.zero; //手指拖动的位置
    //private slideVector currentVector = slideVector.nullVector;//当前滑动方向
    private InputDirection input = InputDirection.Null;
    private float timer;//时间计数器  
    public float offsetTime = 0.1f;//判断的时间间隔 
    public float SlidingDistance = 80f;

    void OnGUI()   // 滑动方法
    {
        if (Event.current.type == EventType.MouseDown)
        //判断当前手指是按下事件 
        {
            touchFirst = Event.current.mousePosition;//记录开始按下的位置
        }
        if (Event.current.type == EventType.MouseDrag)
        //判断当前手指是拖动事件
        {
            touchSecond = Event.current.mousePosition;

            timer += Time.deltaTime;  //计时器

            if (timer > offsetTime)
            {
                touchSecond = Event.current.mousePosition; //记录结束下的位置
                Vector2 slideDirection = touchFirst - touchSecond;
                float x = slideDirection.x;
                float y = slideDirection.y;

                if (y + SlidingDistance < x && y > -x - SlidingDistance)
                {

                    if (input == InputDirection.Left)
                    {
                        return;
                    }

                    //Debug.Log("right");

                    input = InputDirection.Left;
                }
                else if (y > x + SlidingDistance && y < -x - SlidingDistance)
                {
                    if (input == InputDirection.Right)
                    {
                        return;
                    }

                    //Debug.Log("left");

                    input = InputDirection.Right;
                }
                else if (y > x + SlidingDistance && y - SlidingDistance > -x)
                {
                    if (input == InputDirection.Up)
                    {
                        return;
                    }

                    //Debug.Log("up");

                    input = InputDirection.Up;
                }
                else if (y + SlidingDistance < x && y < -x - SlidingDistance)
                {
                    if (input == InputDirection.Down)
                    {
                        return;
                    }

                    //Debug.Log("Down");

                    input = InputDirection.Down;
                }

                timer = 0;
                touchFirst = touchSecond;
            }
            if (Event.current.type == EventType.MouseUp)
            {//滑动结束  
                input = InputDirection.Null;
            }
        }
    }

    //键盘输入
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

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.A) && !isChanging)
        {
            targetRoad = currentRoad - 1;
            offsets = -2;
            SendMessage("AnimaController", input);
            GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
        }
        else if (Input.GetKeyDown(KeyCode.D) && !isChanging)
        {
            targetRoad = currentRoad + 1;
            offsets = 2;
            SendMessage("AnimaController", input);
            GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
        }
        else if (Input.GetKeyDown(KeyCode.W) && !isChanging)
        {
            run.upSpeed = 5.8f;
            isJumping = true;
            SendMessage("AnimaController", input);
            GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Jump);
        }
        else if (Input.GetKeyDown(KeyCode.S) && !isChanging)
        {
            isRolling = true;
            SendMessage("AnimaController", input);
            GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Huadong);
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
                if (currentRoad > 0 && !isChanging)
                {
                    //Debug.Log("a");
                    targetRoad = currentRoad - 1;
                    offsets = -2;
                    SendMessage("AnimaController", input);
                    GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
                }
                break;
            case InputDirection.Right:
                if (currentRoad < 2 && !isChanging)
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
            if (!(gameModel.IsOver || gameModel.IsPause))
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
            if (!(gameModel.IsOver || gameModel.IsPause))
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
            if (!(gameModel.IsOver || gameModel.IsPause))
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
            if (!(gameModel.IsOver || gameModel.IsPause))
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