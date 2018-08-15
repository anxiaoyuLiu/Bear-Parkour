using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleTrigger : MonoBehaviour {

    public bool isTrigger = false;

    public void Trigger()
    {
        isTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.player)
        {
            //GameSetting.Instance.objectPool.ReturnObject(transform.parent.gameObject);
        }
    }
}
