using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShipDoor2Script : MonoBehaviour
{
    public GameObject player;
    public GameObject upperDoorPos;
    public GameObject lowerDoorPos;
    public bool isDownStairs;
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public string assist = "Press E";
    public bool dialogueActive;
    

   

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.E) && isDownStairs == true)
            {
                player.transform.position = upperDoorPos.transform.position;
                isDownStairs = false;
            }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.CompareTag("Player"))
        {
            isDownStairs = true;
            dialogueText.text = assist;

            Debug.Log("Player in range");
            dialogueActive = true;
            dialogueBox.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isDownStairs = false;
            Debug.Log("Player Out Of Range");
            dialogueActive = false;
            dialogueBox.SetActive(false);
            
        }
    }
}
