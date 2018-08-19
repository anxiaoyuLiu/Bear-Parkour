using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : ReusableObject
{
    protected float time = 1.2f;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void SetInfo()
    {
        transform.position = GameObject.FindWithTag(Tags.test).transform.position;
        StartCoroutine(IReturn());
    }

    IEnumerator IReturn()
    {
        yield return new WaitForSeconds(time);
        GameSetting.Instance.objectPool.ReturnObject(gameObject);
    }

    public override void ClearInfo()
    {
        
    }
}
