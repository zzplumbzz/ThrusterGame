using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuCanvas.SetActive(false);
    }

    

    public void ResumeButtonPressed()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1;
    }
}
