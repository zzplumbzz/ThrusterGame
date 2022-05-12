using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float LevelTimer;
    
    public TMP_Text TimeText;

    // Start is called before the first frame update
    void Start()
    {
        

        LevelTimer = 0;
       

    }

    // Update is called once per frame
    void Update()
    {

        LevelTimer += Time.deltaTime;//starts the count down
        

        TimeText.text = (LevelTimer).ToString("0");//turns countdown to text
        





    }
}
