using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Item {

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

    public override void HitPlayer()
    {
        //声音
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Magnet);

        //回收
        GameSetting.Instance.objectPool.ReturnObject(gameObject);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        //发消息
        other.SendMessage("HitMagnet", SendMessageOptions.DontRequireReceiver);
    }

}
