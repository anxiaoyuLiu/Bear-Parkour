using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ReusableObject
{
    //protected float time = 10;
    private int rotateSpeed = 80;

    protected override void Awake()
    {
        base.Awake();
    }

    protected virtual void Update()
    {
        //转动
        transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
    }

    public override void SetInfo()
    {
        //StartCoroutine(IReturn());
        //int z = Random.Range(100, 111);
        //posZ = player.position.z + z;
        //int x = nums[Random.Range(0, nums.Length)];
        //posX = x;
        //transform.position = new Vector3(posX, 0, posZ);
    }

    public override void ClearInfo()
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }

    public override void HitPlayer()
    {
        //发消息
        //创建特效
        //GameSetting.Instance.objectPool.GetObject(Const.FX_ZhuangJi, effectParent);
        //播放撞击音效
        //GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Hit);//转到碰撞判断处播放
        //回收
        GameSetting.Instance.objectPool.ReturnObject(gameObject);
    }

    //IEnumerator IReturn()
    //{
    //    yield return new WaitForSeconds(time);
    //    GameSetting.Instance.objectPool.ReturnObject(gameObject);
    //}

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.player)
        {
            HitPlayer();
        }
    }
}
