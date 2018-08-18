using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : Item {

    private Animation anim_Goal;
    private Animation anim_Goalkeeper;
    private GameObject goalkeeper;
    //public GameObject ShouMenYuan;
    public GameObject QiuMen;
    //private bool isGoal = false;

    protected override void Awake()
    {
        //base.Awake();
        goalkeeper = transform.Find("Root/goalkeeperRoot/goalkeeper").gameObject;
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
        QiuMen.transform.rotation = Quaternion.Euler(0, 0, 0);
        goalkeeper = transform.Find("Root/goalkeeperRoot/goalkeeper").gameObject;
        goalkeeper.SetActive(true);
        goalkeeper.transform.localPosition = new Vector3(0, 0, -0.5f);
        anim_Goal.Play(Const.goal_static);
        anim_Goalkeeper.Play(Const.standard);
        //ShouMenYuan.transform.position = Vector3.zero;
    }

    public override void ClearInfo()
    {
        base.ClearInfo();
        goalkeeper.SetActive(true);
        goalkeeper.transform.localPosition = new Vector3(0, 0, -0.5f);
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
        //StartCoroutine(IReturn());
    }

    //public void GoalRecive()
    //{
    //    isGoal = true;
    //}

    //protected override void OnTriggerEnter(Collider other)
    //{
    //    base.OnTriggerEnter(other);
    //}

    //IEnumerator IReturn()
    //{
    //    yield return new WaitForSeconds(1);
    //    GameSetting.Instance.objectPool.ReturnObject(gameObject);
    //}

}
