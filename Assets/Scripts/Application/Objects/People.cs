using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : Obstacle {

    private PeopleTrigger peopleTrigger;
    protected int speed_move = 8;
    protected bool isHit = false;
    protected Animation anim;
    GameModel gameModel;

    protected override void Awake()
    {
        base.Awake();
        peopleTrigger = GetComponentInChildren<PeopleTrigger>();
        anim = transform.GetComponentInChildren<Animation>();
        gameModel = MVC.GetModel<GameModel>();
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
        StartCoroutine(IReturn());
    }

    public virtual void Move()
    {
        if (peopleTrigger.isTrigger && !gameModel.IsOver && !gameModel.IsPause)
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

    IEnumerator IReturn()
    {
        yield return new WaitForSeconds(1.2f);
        isHit = false;
        GameSetting.Instance.objectPool.ReturnObject(gameObject);
    }
}
