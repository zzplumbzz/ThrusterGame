using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoThrustScript : MonoBehaviour
{
    public PlayerScript ps;
    


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))//when the player collides with the deathplane spawns them back at the spawn point
        {
            
            ps.thrust = 0;
            ps.isThrusting = true;

            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))//when the player collides with the deathplane spawns them back at the spawn point
        {
            
            ps.thrust = 50;
            ps.isThrusting = true;

            
        }
    }
}
