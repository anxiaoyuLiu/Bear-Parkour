using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Obstacle {

    public bool canMove;
    private CarTrigger carTrigger;
    private int speed = 8;

    protected override void Awake()
    {
        base.Awake();
        carTrigger = GetComponentInChildren<CarTrigger>();
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
        base.HitPlayer();
    }

    public override void SetInfo()
    {
        base.SetInfo();
    }

    public void Move()
    {
        if (canMove && carTrigger.isTrigger)
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
    }
}
