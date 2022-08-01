using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float countTimer;
    public bool IsTimerRunning = false;

    public Text timeText;   

    private void Update()
    {
        if(IsTimerRunning)
        {
            RunCountTimer();
            DisplayTime(countTimer);
        }
    }

    private void RunCountTimer()
    {
        countTimer += Time.deltaTime;
    }

    public void DisplayTime(float displayTime)
    {
        float minutes = Mathf.FloorToInt(displayTime / 60);
        float seconds = Mathf.FloorToInt(displayTime % 60);
        float milliSeconds = (displayTime % 1) * 1000;
        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }
}