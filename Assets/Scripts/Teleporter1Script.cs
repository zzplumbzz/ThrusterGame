using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Teleporter1Script : MonoBehaviour
{
    public GameObject player;
    public GameObject Teleporter1Pos;
    public GameObject Teleporter2Pos;
    public bool atT1;
    public float speed;
    public float angularSpeed;
    protected Rigidbody rb;
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public string assist = "Press E";
    public bool dialogueActive;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dialogueBox.SetActive(false);
    }

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.E) && atT1 == true)
            {
                player.transform.position = Teleporter2Pos.transform.position;
                
            }
            
    }

    void FixedUpdate()
    {
        //sets the speed and velocity of torque trap
        speed = rb.velocity.magnitude;
        angularSpeed = rb.angularVelocity.magnitude;
        rb.maxAngularVelocity = 1f;
        rb.AddTorque(Vector3.down);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            dialogueText.text = assist;
            atT1 = true;
            Debug.Log("Player in range");
            dialogueActive = true;
            dialogueBox.SetActive(true);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            atT1 = false;
            dialogueActive = false;
            dialogueBox.SetActive(false);
            
        }
    }
    
}
