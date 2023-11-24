using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float speed;


    // Update is called once per frame
    void LateUpdate()
    {

        if(player.position.x<=6.5 && player.position.x>=-6.25)transform.position = Vector3.Lerp(transform.position, player.position + offset, speed);
    }
}
