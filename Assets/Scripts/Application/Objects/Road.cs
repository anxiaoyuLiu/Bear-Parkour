using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : ReusableObject {

    private Transform ItemParent;

    protected override void Awake()
    {
        ItemParent = transform.Find("Root").transform;
    }

    public override void SetInfo()
    {
        
    }

    public override void ClearInfo()
    {
        //处理路上所有未回收的物体
        if(ItemParent != null)
        {
            foreach (Transform item in ItemParent)
            {
                GameSetting.Instance.objectPool.ReturnObject(item.gameObject);
            }
        }
    }

}
