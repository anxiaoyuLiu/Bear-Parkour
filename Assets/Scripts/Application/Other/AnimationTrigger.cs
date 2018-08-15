using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour {

    private Goalkeeper goalkeeper;

    private void Awake()
    {
        goalkeeper = transform.GetComponentInChildren<Goalkeeper>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.ball)
        {
            //int index = (int)other.transform.position.x;
            goalkeeper.Flutter();
        }
    }
}
