using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{

    public void LoadSampleScene(string sceneName)//takes player to game scene
    {
        SceneManager.LoadScene("SampleScene");
       
    }

    public void LoadLevel1(string sceneName)//takes player to game scene
    {
        SceneManager.LoadScene("Level1");

    }

    public void LoadLevel2(string sceneName)//takes player to game scene
    {
        SceneManager.LoadScene("Level2");

    }

    public void LoadLevel3(string sceneName)//takes player to game scene
    {
        SceneManager.LoadScene("Level3");

    }

    public void LoadLevelSelect(string sceneName)
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void LoadInstructionScene(string sceneName)//takes player to instructions scene
    {
        SceneManager.LoadScene("InstructionScene");
    }

    public void LoadMenuScene(string sceneName)//takes player to menu scene
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadWinScene(string sceneName)//takes player to win scene
    {
        SceneManager.LoadScene("WinScene");
    }

    public void LoadGameOverScene(string sceneName)//takes player to gameover scene
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void ResetLevel(string sceneName)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void Quit()//quits the game
    {
        Application.Quit();
    }
}
