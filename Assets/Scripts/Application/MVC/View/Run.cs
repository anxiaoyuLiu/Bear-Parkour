using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : View {

    private CharacterController controller;
    private PlayerController playerController;
    //private float speed = 15;
    //private float maxSpeed = 40;
    private float targetSpeed;
    private float distance = 0;
    //public bool isInHit = false;
    private int addSpeed = 8;
    private GameModel gameModel;
    //Transform Blocks;
    public float upSpeed = 0;
    //private float gravity = -9.8f;
    private float gravity = -14;
    private IEnumerator SpeedIEnumerator;

    public override string Name
    {
        get
        {
            return Const.V_Run;
        }
    }

    //public float Speed
    //{
    //    get
    //    {
    //        return speed;
    //    }

    //    set
    //    {
    //        speed = value;
    //        if (speed > maxSpeed)
    //            speed = maxSpeed;
    //    }
    //}

    private void Awake()
    {
        controller = this.GetComponent<CharacterController>();
        playerController = this.GetComponent<PlayerController>();
        gameModel = GetModel<GameModel>();
        //Blocks = GameObject.Find("Blocks").transform;
    }

    void Update()
    {
        if (!(gameModel.IsOver || gameModel.IsPause))
        {
            controller.Move(Vector3.forward * gameModel.Speed * Time.deltaTime);
            gameModel.Distance = (int)transform.position.z;
            SendEvent(Const.E_UpdateDistance);
            AddSpeed();
        }

        JumpAndDrop();

        //if (jumpHit)
        //{
        //    playerController.JumpAndDrop();
        //}

        //ForTest
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    GameObject go = GameSetting.Instance.objectPool.GetObject(Const.Block_People, Blocks);
        //    go.transform.position = transform.position + new Vector3(0, 0, 100);
        //}
    }

    //public void ChangeSpeed()
    //{
    //    if (SpeedIEnumerator != null)
    //    {
    //        StopCoroutine(SpeedIEnumerator);
    //    }
    //    SpeedIEnumerator = IReduceSpeed();
    //    StartCoroutine(IReduceSpeed());
    //}

    //IEnumerator IChangeSpeed()
    //{
    //    float currenSpeed = gameModel.Speed;
    //    gameModel.Speed += 10;
    //    yield return new WaitForSeconds(gameModel.SpeedUpTime);
    //    gameModel.Speed = currenSpeed;
    //    gameModel.IsSpeedUp = false;
    //}

    public override void HandleEvent(string eventName, object data)
    {
        
    }

    private void AddSpeed()
    {
        if (transform.position.z - distance > 600)
        {
            distance = transform.position.z;
            gameModel.Speed += 2;
            gameModel.TargetSpeed += 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (playerController.isJumping)
        //{
        //    jumpHit = true;
        //}

        if (other.tag == Tags.smallBlock) //小路障
        {
            other.SendMessage("HitPlayer", SendMessageOptions.DontRequireReceiver);

            GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Hit);
            //isInHit = true;
            if (SpeedIEnumerator != null)
            {
                StopCoroutine(SpeedIEnumerator);
            }
            SpeedIEnumerator = IReduceSpeed();
            StartCoroutine(SpeedIEnumerator);
            //StartCoroutine(IReduceSpeed());
            //if (isInHit)
            //{
            //    GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_End);
            //    SendEvent(Const.E_EndGame);
            //}
            //else
            //{
            //    GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Hit);
            //    isInHit = true;
            //    StartCoroutine(IReduceSpeed());
            //}
        }
        else if (other.tag == Tags.bigBlock) //中大路障做相同处理
        {
            if (playerController.isRolling) return;
            other.SendMessage("HitPlayer", SendMessageOptions.DontRequireReceiver);

            GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Hit);
            //isInHit = true;
            if (SpeedIEnumerator != null)
            {
                StopCoroutine(SpeedIEnumerator);
            }
            SpeedIEnumerator = IReduceSpeed();
            StartCoroutine(SpeedIEnumerator);
            //StartCoroutine(IReduceSpeed());
            //if (isInHit)
            //{
            //    GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_End);
            //    SendEvent(Const.E_EndGame);
            //}
            //else
            //{
            //    GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Hit);
            //    isInHit = true;
            //    StartCoroutine(IReduceSpeed());
            //}
        }
        else if (other.tag == Tags.deathBlock) //死亡障碍物
        {
            SendEvent(Const.E_EndGame);
            other.SendMessage("HitPlayer", SendMessageOptions.DontRequireReceiver);
            GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_End);
        }
        else if (other.tag == Tags.car) //汽车
        {
            SendEvent(Const.E_EndGame);
            other.SendMessage("HitPlayer", SendMessageOptions.DontRequireReceiver);
            GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_End);
        }
        else if (other.tag == Tags.beforeTrigger) //汽车和人移动触发器
        {
            other.SendMessage("Trigger", SendMessageOptions.DontRequireReceiver);
            //other.transform.parent.SendMessage("Move")
        }
        else if (other.tag == Tags.people) //人物
        {
            other.SendMessage("HitPlayer", SendMessageOptions.DontRequireReceiver);
            GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Hit);
            //isInHit = true;
            if (SpeedIEnumerator != null)
            {
                StopCoroutine(SpeedIEnumerator);
            }
            SpeedIEnumerator = IReduceSpeed();
            StartCoroutine(SpeedIEnumerator);
            //StartCoroutine(IReduceSpeed());
            //if (isInHit)
            //{
            //    GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_End);
            //    SendEvent(Const.E_EndGame);
            //}
            //else
            //{
            //    other.SendMessage("HitPlayer", SendMessageOptions.DontRequireReceiver);
            //    GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Hit);
            //    isInHit = true;
            //    StartCoroutine(IReduceSpeed());
            //}
        }
        else if (other.tag == Tags.shootTrigger) //进入射门范围
        {
            //other.SendMessage("HitPlayer", SendMessageOptions.DontRequireReceiver);
            GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Revival);
            SendEvent(Const.E_ReadyShoot);
            //other.transform.parent.Find("goalkeeperRoot/goalkeeper").GetComponent<Goalkeeper>().Flutter();
        }
        else if (other.tag == Tags.goal) //球门
        {
            other.transform.parent.parent.SendMessage("PlayerHit", playerController.currentRoad);
            GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Hit);
            //isInHit = true;
            if (SpeedIEnumerator != null)
            {
                StopCoroutine(SpeedIEnumerator);
            }
            SpeedIEnumerator = IReduceSpeed();
            StartCoroutine(SpeedIEnumerator);
            //StartCoroutine(IReduceSpeed());
            //if (isInHit)
            //{
            //    GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_End);
            //    SendEvent(Const.E_EndGame);
            //}
            //else
            //{
            //    other.transform.parent.parent.SendMessage("PlayerHit", playerController.currentRoad);
            //    GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Hit);
            //    isInHit = true;
            //    StartCoroutine(IReduceSpeed());
            //}
        }
        else if (other.tag == Tags.goalkeeper) //守门员
        {
            other.SendMessage("HitPlayer", SendMessageOptions.DontRequireReceiver);
            GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Hit);
            //isInHit = true;
            if (SpeedIEnumerator != null)
            {
                StopCoroutine(SpeedIEnumerator);
            }
            SpeedIEnumerator = IReduceSpeed();
            StartCoroutine(SpeedIEnumerator);
            //StartCoroutine(IReduceSpeed());
            //if (isInHit)
            //{
            //    GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_End);
            //    SendEvent(Const.E_EndGame);
            //}
            //else
            //{
            //    other.SendMessage("HitPlayer", SendMessageOptions.DontRequireReceiver);
            //    GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Hit);
            //    isInHit = true;
            //    StartCoroutine(IReduceSpeed());
            //}
        }
    }

    IEnumerator IReduceSpeed()
    {
        targetSpeed = gameModel.TargetSpeed;
        gameModel.Speed = 3;
        while (gameModel.Speed < targetSpeed)
        {
            gameModel.Speed += Time.deltaTime * addSpeed;
            yield return 0;
        }
        //isInHit = false;
    }

    public void JumpAndDrop()
    {
        if (transform.position.y < 0.01f)
        {
            if (upSpeed < 0)
            {
                upSpeed = 0;
            }
            transform.position = new Vector3(transform.position.x, 0.01f, transform.position.z);
            return;
        }
        else if (transform.position.y > 0.02f)
        {
            upSpeed += gravity * Time.deltaTime;
        }
        controller.Move(new Vector3(0, upSpeed, 0) * Time.deltaTime);
    }
}
