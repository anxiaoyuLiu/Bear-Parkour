using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : Obstacle {

    private PeopleTrigger peopleTrigger;
    private int speed_move = 8;
    private bool isHit = false;
    protected Animation anim;

    protected override void Awake()
    {
        base.Awake();
        peopleTrigger = GetComponentInChildren<PeopleTrigger>();
        anim = transform.GetComponentInChildren<Animation>();
    }

    protected virtual void Update()
    {
        Move();
        Fly();
    }

    public override void SetInfo()
    {
        base.SetInfo();
        isHit = false;
    }

    public override void ClearInfo()
    {
        base.ClearInfo();
        peopleTrigger.isTrigger = false;
        isHit = false;
    }

    public override void HitPlayer()
    {
        GameSetting.Instance.objectPool.GetObject(Const.FX_ZhuangJi, effectParent);
        isHit = true;
        StartCoroutine(Return());
    }

    public virtual void Move()
    {
        if (peopleTrigger.isTrigger)
        {
            transform.Translate(new Vector3(0, 0, speed_move * Time.deltaTime));
            anim.Play(Const.run);
        }
    }

    public virtual void Fly()
    {
        if (isHit)
        {
            transform.Translate(new Vector3(0, speed_move * Time.deltaTime, -speed_move * Time.deltaTime*5));
            anim.Play(Const.fly);
        }
    }

    IEnumerator Return()
    {
        yield return new WaitForSeconds(1.2f);
        GameSetting.Instance.objectPool.ReturnObject(gameObject);
    }
}
