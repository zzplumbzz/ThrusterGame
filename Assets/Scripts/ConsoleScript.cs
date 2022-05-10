using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ConsoleScript : MonoBehaviour
{
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public string assist = "Press E";
    public bool dialogueActive;
    void Start()
    {
        dialogueActive = false;
        dialogueBox.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && dialogueActive)
        {
            if (dialogueBox.activeInHierarchy)
            {
                dialogueBox.SetActive(true);
                SceneManager.LoadScene("LevelSelect");
            }
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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
            Debug.Log("Player Out Of Range");
            dialogueActive = false;
            dialogueBox.SetActive(false);
            
        }
    }
}
