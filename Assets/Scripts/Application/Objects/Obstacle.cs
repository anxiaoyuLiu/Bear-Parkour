using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : ReusableObject {

    protected float time = 8;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void SetInfo()
    {
        StartCoroutine(IReturn());
        int z = Random.Range(100, 110);
        posZ = player.position.z + z;
        //Debug.Log("Distance: " + gameModel.Distance);
        int x = nums[Random.Range(0, nums.Length)];
        posX = x;
        transform.position = new Vector3(posX, 0, posZ);
    }

    public override void ClearInfo()
    {
        
    }

    public override void HitPlayer()
    {
        //创建特效
        GameSetting.Instance.objectPool.GetObject(Const.FX_ZhuangJi, effectParent);
        //播放撞击音效
        //GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Hit);//转到碰撞判断处播放
        //回收
        GameSetting.Instance.objectPool.ReturnObject(gameObject);
    }

    IEnumerator IReturn()
    {
        yield return new WaitForSeconds(time);
        GameSetting.Instance.objectPool.ReturnObject(gameObject);
    }
}
