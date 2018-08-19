using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BollHit : View {

    Transform effectParent;
    GameModel gameModel;

    private void Awake()
    {
        effectParent = GameObject.FindWithTag(Tags.test).transform;
        gameModel = GetModel<GameModel>();
    }

    private void Start()
    {
        
    }

    public override string Name
    {
        get
        {
            return Const.V_BollHit;
        }
    }

    public override void HandleEvent(string eventName, object data)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        if (other.tag == Tags.goal)
        {
            gameModel.IsBallFlying = false;
            SendEvent(Const.E_Goal, effectParent);
            //other.SendMessage("GoalRecive");
            GameSetting.Instance.objectPool.ReturnObject(gameObject);
            //GameSetting.Instance.objectPool.ReturnObject(other.transform.parent.parent.gameObject);
            //other.transform.parent.parent.gameObject.SetActive(false);//暂时代替
            GameSetting.Instance.objectPool.ReturnObject(gameObject);
            other.transform.parent.parent.SendMessage("Return",SendMessageOptions.DontRequireReceiver);
        }
        else if (other.tag == Tags.goalkeeper)
        {
            gameModel.IsBallFlying = false;
            //Debug.Log("send message to fly");
            other.SendMessage("HitPlayer", SendMessageOptions.DontRequireReceiver);
            GameSetting.Instance.objectPool.ReturnObject(gameObject);
            GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Zhuang);
        }
        else if(other.tag!=Tags.beforeTrigger && other.tag!=Tags.item && other.tag!=Tags.animationTrigger)
        {
            gameModel.IsBallFlying = false;
            GameSetting.Instance.objectPool.ReturnObject(gameObject);
            GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Zhuang);
        }
    }
}
