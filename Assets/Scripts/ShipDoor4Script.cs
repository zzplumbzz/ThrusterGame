using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShipDoor4Script : MonoBehaviour
{
    public GameObject player;
    public GameObject Door3Pos;
    public GameObject Door4Pos;
    public bool isInRoom;
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public string assist = "Press E";
    public bool dialogueActive;
    

   

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.E) && isInRoom == true)
            {
                player.transform.position = Door3Pos.transform.position;
                isInRoom = false;
            }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.CompareTag("Player"))
        {
            isInRoom = true;
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
            isInRoom = false;
            Debug.Log("Player Out Of Range");
            dialogueActive = false;
            dialogueBox.SetActive(false);
            
        }
    }
}
