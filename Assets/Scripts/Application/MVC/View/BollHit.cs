﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BollHit : View {

    Transform effectParent;

    private void Awake()
    {
        effectParent = GameObject.Find("Effects").transform;
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
            SendEvent(Const.E_Goal, effectParent);
            //other.SendMessage("GoalRecive");
            GameSetting.Instance.objectPool.ReturnObject(gameObject);
            //GameSetting.Instance.objectPool.ReturnObject(other.transform.parent.parent.gameObject);
            other.transform.parent.parent.gameObject.SetActive(false);//暂时代替
        }
        else if (other.tag == Tags.goalkeeper)
        {
            //Debug.Log("send message to fly");
            other.SendMessage("Fly");
            GameSetting.Instance.objectPool.ReturnObject(gameObject);
            GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Zhuang);
        }
        else
        {

        }
    }
}
