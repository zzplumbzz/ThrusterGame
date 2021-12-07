using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float countDownTimer;
    public Text TimeText;

    // Start is called before the first frame update
    void Start()
    {
        TimeText = GetComponent<Text>();

        countDownTimer = 120;

    }

    // Update is called once per frame
    void Update()
    {

        countDownTimer -= Time.deltaTime;//starts the count down


        TimeText.text = (countDownTimer).ToString("0");//turns countdown to text

        if (countDownTimer <= 0)//loads game over scene when countdown reaches 0
        {
            SceneManager.LoadScene("GameOverScene");
        }





    }
}
