using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    PlayerScript ps;
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

    public void LoadMenuScene(string sceneName)//takes player to menu scene
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SaveGame()
    {
        PlayerPrefs.SetFloat("money", ps.money);
        PlayerPrefs.SetFloat("lives", ps.lives);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }

    public void LoadGame()
    {
	
		ps.money = PlayerPrefs.GetFloat("money");
		ps.lives = PlayerPrefs.GetFloat("lives");
        SceneManager.LoadScene("ShipScene");
		Debug.Log("Game data loaded!");

   
    }
}
