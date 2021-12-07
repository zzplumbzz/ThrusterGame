using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneScript : MonoBehaviour
{
    public Transform CheckPoint;
    //public Transform CheckPoint2;
    // public Transform CheckPoint3;
    //public Transform CheckPoint4;
   // public Transform CheckPoint5;

    public Rigidbody player;





    void Start()
    {
       // player.transform.position = CheckPoint5.transform.position;//puts player at the spawn point when level starts THIS IS FOR TESTING PURPOSES!




    }


    void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Player"))//when the player collides with the deathplane spawns them back at the spawn point
        {
            
            player.transform.position = CheckPoint.position;

        }


    }
}
