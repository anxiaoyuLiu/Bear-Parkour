using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : Item {

    private Animation anim_Goal;
    private Animation anim_Goalkeeper;
    public GameObject goalkeeper;
    //public GameObject ShouMenYuan;
    public GameObject QiuMen;
    //private bool isGoal = false;

    protected override void Awake()
    {
        //base.Awake();
        anim_Goal = transform.Find("Root/QiuMen").GetComponent<Animation>();
        anim_Goalkeeper = goalkeeper.transform.Find("root/ShouMenYuan").GetComponent<Animation>();
        goalkeeper.SetActive(true);
        anim_Goal.Play(Const.goal_static);
        player = GameObject.FindWithTag(Tags.player).transform;
        //isGoal = false;
    }

    protected override void Update()
    {

    }

    public override void SetInfo()
    {
        base.SetInfo();
        QiuMen.transform.rotation = Quaternion.Euler(0, 0, 0);
        goalkeeper.SetActive(true);
        anim_Goal.Play(Const.goal_static);
        anim_Goalkeeper.Play(Const.standard);
        goalkeeper.transform.localPosition = new Vector3(0, 0, -0.5f);
        //ShouMenYuan.transform.position = Vector3.zero;
    }

    public override void ClearInfo()
    {
        base.ClearInfo();
    }

    public void PlayerHit(object data=null)
    {
        int index = (int)data;
        switch (index)
        {
            case 0:
                anim_Goal.Play(Const.goal_left);
                break;
            case 1:
                anim_Goal.Play(Const.goal_static);
                break;
            case 2:
                anim_Goal.Play(Const.goal_right);
                break;
            default:
                break;
        }
        //StartCoroutine(IReturn());//暂时无法回收
    }

    //public void GoalRecive()
    //{
    //    isGoal = true;
    //}

    //protected override void OnTriggerEnter(Collider other)
    //{
    //    base.OnTriggerEnter(other);
    //}

    IEnumerator IReturn()
    {
        yield return new WaitForSeconds(1);
        GameSetting.Instance.objectPool.ReturnObject(gameObject);
    }

}
