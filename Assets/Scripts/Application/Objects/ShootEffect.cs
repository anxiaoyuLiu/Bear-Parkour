using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEffect : Effect {

    private void Start()
    {
        
    }

    public override void SetInfo()
    {
        //Debug.Log("get message");
        transform.position = GameObject.FindWithTag(Tags.test).transform.position;
        transform.localPosition = new Vector3(0.58f, 0.88f, 1.82f);
        transform.localScale = new Vector3(3.33f, 3.33f, 3.33f);
        //Debug.Log(transform.localPosition);
    }
    public override void ClearInfo()
    {
        base.ClearInfo();
    }
}
