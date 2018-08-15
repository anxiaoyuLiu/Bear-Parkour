using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalkeeper : People {

    private int speed_fly = 400;
    new Rigidbody  rigidbody;

    protected override void Awake()
    {
        //effectParent = GameObject.Find("Effects").transform;//需要特效再加上
        anim = transform.GetComponentInChildren<Animation>();
        anim.Play(Const.standard);
        //isHit = false;
        rigidbody = GetComponent<Rigidbody>();
        transform.localPosition = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    protected override void Update()
    {
        
    }

    public override void SetInfo()
    {
        //isHit = false;
        anim.Play(Const.standard);
        gameObject.SetActive(true);
    }

    public override void ClearInfo()
    {
        //isHit = false;
        transform.localPosition = new Vector3(0, 0, -0.5f);
    }

    public override void HitPlayer()
    {
        GameSetting.Instance.objectPool.GetObject(Const.FX_ZhuangJi, effectParent);
        Fly();
    }

    public override void Move()
    {
        
    }

    public void Flutter()
    {
        int index = UnityEngine.Random.Range(0, 3);
        switch (index)
        {
            case 0:
                anim.Play(Const.left_flutter);
                transform.Translate(new Vector3(-1.3f, 0, 0));
                break;
            case 1:
                anim.Play(Const.flutter);
                break;
            case 2:
                anim.Play(Const.right_flutter);
                transform.Translate(new Vector3(1.3f, 0, 0));
                break;
            default:
                break;
        }
    }

    public override void Fly()
    {
        //isHit = true;
        //transform.Translate(new Vector3(0, speed * Time.deltaTime, -speed * Time.deltaTime * 5));
        rigidbody.velocity = new Vector3(0, speed_fly * Time.deltaTime, speed_fly * Time.deltaTime * 5);
        anim.Play(Const.fly);
        StartCoroutine(ReturnGoalkeeper());
    }

    IEnumerator ReturnGoalkeeper()
    {
        yield return new WaitForSeconds(1.2f);
        gameObject.SetActive(false);
    }

}
