using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointActivatorScript : MonoBehaviour
{
    public Color red;
   public Color green;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Renderer>().material.color = red;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            transform.GetComponent<Renderer>().material.color = green;
        }
        
    }

    
}
