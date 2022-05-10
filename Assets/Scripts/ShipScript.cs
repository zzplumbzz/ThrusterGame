using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
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
    

    
}
