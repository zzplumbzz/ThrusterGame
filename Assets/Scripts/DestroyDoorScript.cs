using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DestroyDoorScript : MonoBehaviour
{
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public string assist = "Press E";
    public bool dialogueActive;
    public bool inRange;
    public GameObject Door;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange == true)
            {
                Destroy(Door);
                dialogueActive = false;
            dialogueBox.SetActive(false);
                
            }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            dialogueText.text = assist;
            inRange = true;
            Debug.Log("Player in range");
            dialogueActive = true;
            dialogueBox.SetActive(true);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            inRange = false;
            dialogueActive = false;
            dialogueBox.SetActive(false);
            
        }
    }
}
