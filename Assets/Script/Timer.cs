using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timeText;



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

        


        if (seconds == 0)
        {

            SceneManager.LoadScene("GameoverScene");
            
        }
    }
}
