using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform player;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;



    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.position + offset;//camera follows target on update( target should be player)

    }
}
