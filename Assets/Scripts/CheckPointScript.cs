using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckPointScript : MonoBehaviour
{
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerScript>().currentCheckpoint = gameObject.transform;
            
            
            
        }
    }
}
