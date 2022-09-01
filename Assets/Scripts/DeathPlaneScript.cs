using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneScript : MonoBehaviour
{
    //public Transform CheckPoint;
    public float time = 1f;
    //public Transform CheckPoint2;
    // public Transform CheckPoint3;
    //public Transform CheckPoint4;
   // public Transform CheckPoint5;
    PlayerScript ps;
    public Rigidbody player;
    //public PlayerScript ps;




    void Start()
    {
       // player.transform.position = CheckPoint5.transform.position;//puts player at the spawn point when level starts THIS IS FOR TESTING PURPOSES!




    }


    void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Player"))//when the player collides with the deathplane spawns them back at the spawn point
        {
            
            player = other.GetComponent<Rigidbody>();
            
            player.transform.position = player.GetComponent<PlayerScript>().currentCheckpoint.position;
            StartCoroutine("DelayMovement");
            
        }


    }

    private IEnumerator DelayMovement()
    {
        
        
        player.constraints = RigidbodyConstraints.FreezeAll;
        
        yield return new WaitForSeconds(1.0f);
        
        player.constraints = RigidbodyConstraints.None;
        player.constraints = RigidbodyConstraints.FreezeRotation;
            
        
    }
}
