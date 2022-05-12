using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShipDoorScript : MonoBehaviour
{
    public GameObject player;
    public GameObject upperDoorPos;
    public GameObject lowerDoorPos;
    public bool isUpstairs;
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public string assist = "Press E";
    public bool dialogueActive;
    

   

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.E) && isUpstairs == true)
            {
                player.transform.position = lowerDoorPos.transform.position;
                isUpstairs = false;
            }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.CompareTag("Player"))
        {
            isUpstairs = true;
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
            isUpstairs = false;
            Debug.Log("Player Out Of Range");
            dialogueActive = false;
            dialogueBox.SetActive(false);
            
        }
    }
}
