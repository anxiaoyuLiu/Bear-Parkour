using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ReusableObject : MonoBehaviour, IReusable
{
    protected Transform effectParent;
    protected float posX;
    protected float posZ;
    protected int[] nums = { -2, 0, 2 };

    public abstract void SetInfo();
    public abstract void ClearInfo();

    protected Transform player;

    protected virtual void Awake()
    {
        effectParent = GameObject.Find("Effects").transform;
        player = GameObject.FindWithTag(Tags.test).transform;
    }

    public virtual void HitPlayer()
    {
        //创建特效
        //播放撞击音效
        //回收
    }
}
