using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText;

    public Text Gameover;

    public float totalTime;
    
    int seconds;

    private void Start()
    {
        
    }
    private void Update()
    {
        totalTime -= Time.deltaTime;
        seconds = (int)totalTime;
        timeText.text = seconds.ToString();

        if(seconds == 0)
        {
            Gameover.text = ("GAMEOVER");
        }
    }
}
