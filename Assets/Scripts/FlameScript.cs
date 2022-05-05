using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameScript : MonoBehaviour
{
    public float time = 5f;
    public GameObject flame;
    public Rigidbody player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(time);
        time -= Time.deltaTime;

        if(time <= 0)
        {
            time = 5.0f;
            

            if(flame.GetComponent<MeshRenderer>().enabled == true)
            {
                
                flame.GetComponent<MeshRenderer>().enabled = false;
                flame.GetComponent<BoxCollider>().enabled = false;

            }
            else
            {
               
                flame.GetComponent<MeshRenderer>().enabled = true;
                flame.GetComponent<BoxCollider>().enabled = true;
            }
        }

  

        
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
