using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item {

    //private float flySpeed = 0.002f;
    private float playerSpeed;
    private float flyTime = 1;
    Vector3 currentSpeed;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void SetInfo()
    {
        base.SetInfo();
    }

    public override void ClearInfo()
    {
        base.ClearInfo();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.test)
        {
            HitPlayer();
            //发消息
            other.SendMessage("HitCoin", SendMessageOptions.DontRequireReceiver);
        }
        else if (other.tag == Tags.magnetTrigger)
        {
            //playerSpeed = other.transform.parent.GetComponent<Run>().Speed;
            playerSpeed = other.transform.parent.GetComponent<PlayerController>().recordSpeed;
            currentSpeed = new Vector3(-playerSpeed, 0, 0);
            StartCoroutine(FlyToPlayer(other.transform));
        }
    }

    public override void HitPlayer()
    {
        //特效
        GameSetting.Instance.objectPool.GetObject(Const.FX_JinBi, effectParent);
        //声音
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_JinBi);
        //回收
        GameSetting.Instance.objectPool.ReturnObject(gameObject);
    }

    IEnumerator FlyToPlayer(Transform player)
    {
        bool isLoop = true;
        while (isLoop)
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.position, ref currentSpeed,flyTime*Time.deltaTime );
            if (Vector3.Distance(transform.position, player.position) < 0.5f)
            {
                isLoop = false;
            }
        }
        yield return 0;
    }

}
