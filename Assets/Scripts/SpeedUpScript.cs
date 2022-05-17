using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpScript : MonoBehaviour
{

    PlayerScript ps;
    public Rigidbody player;
    
    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         Debug.Log("FASST!!!!!!!");
    //         player = other.GetComponent<Rigidbody>();
    //        ps.playerSpeed = 50;
    //         ps.maxPlayerSpeed = 50;
    //     }
    // }

    //void OnTriggerExit(Collider other)
   // {
        // if (other.CompareTag("Player"))
        // {
        // ps.playerSpeed = 25.0f;
        //     ps.maxPlayerSpeed = 50.0f;
        // }
    //}
}
