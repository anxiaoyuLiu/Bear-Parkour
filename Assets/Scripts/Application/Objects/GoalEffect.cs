using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalEffect : Effect {

    //Transform Player;

    //private void Awake()
    //{
    //    Player = GameObject.FindWithTag(Tags.player).transform;
    //}

    public override void SetInfo()
    {
        //transform.position = Player.position + new Vector3(0, 3, 12);
        //transform.position = new Vector3(0, 0.5f, 3.6f);
        StartCoroutine(Return());
    }

    IEnumerator Return()
    {
        yield return new WaitForSeconds(time);
        GameSetting.Instance.objectPool.ReturnObject(gameObject);
    }
}
