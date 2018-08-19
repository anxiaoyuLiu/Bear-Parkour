using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    Transform player;
    Vector3 offsets;
    int speed_follow = 20;

    private void Awake()
    {
        player = GameObject.FindWithTag(Tags.test).transform;
        offsets = transform.position - player.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offsets, speed_follow * Time.deltaTime);
    }
}