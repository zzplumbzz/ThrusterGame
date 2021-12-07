using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameMasterScript gms;
    void Start()
    {
        gms = GameObject.FindGameObjectWithTag("GMS").GetComponent<GameMasterScript>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gms.lastCheckPointPos = transform.position;
        }
    }
}
