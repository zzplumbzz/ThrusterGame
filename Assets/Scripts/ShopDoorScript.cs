using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopDoorScript : MonoBehaviour
{
    public GameObject player;
    public GameObject playerSpawn;
     public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public string dialogue;
    public bool dialogueActive;

    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = playerSpawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("LevelSelect");
            
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
