using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Obstacle {

    public bool canMove;
    private CarTrigger carTrigger;
    private int speed = 8;
    GameModel gameModel;

    protected override void Awake()
    {
        base.Awake();
        carTrigger = GetComponentInChildren<CarTrigger>();
        gameModel = MVC.GetModel<GameModel>();
    }

    private void Update()
    {
        Move();
    }

    public override void ClearInfo()
    {
        base.ClearInfo();
        carTrigger.isTrigger = false;
    }

    public override void HitPlayer()
    {
        GameSetting.Instance.objectPool.ReturnObject(gameObject);
    }

    public override void SetInfo()
    {
        base.SetInfo();
    }

    public void Move()
    {
        if (canMove && carTrigger.isTrigger && !gameModel.IsOver && !gameModel.IsPause)
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
    }
}
