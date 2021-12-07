using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{

    private GameMasterScript gms;

    // Start is called before the first frame update
    void Start()
    {
        gms = GameObject.FindGameObjectWithTag("GMS").GetComponent<GameMasterScript>();
        transform.position = gms.lastCheckPointPos;
    }

    

}
