using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DigitalRuby.RainMaker;
using System;

public class TimesUpEvent : UnityEvent
{
    //
}

public class Timer : MonoBehaviour
{
    bool isRunning = false;

    float timeLeft = 0;
    [SerializeField]
    private RainScript2D rainScript;

    [SerializeField]
    private RectTransform timerFg; 

    [SerializeField]
    private RectTransform timerBg;

    [SerializeField]
    private int timeInterval;

    public event Action OnRain;

    public void RestartTimer(int timeLeft)
    {
        isRunning = true;
        this.timeLeft = timeLeft;
    }

    // Start is called before the first frame update
    void Start()
    {
        isRunning = true;
        timeLeft = timeInterval;
        rainScript.RainIntensity = 0;
        Debug.Log("TimerStart " + timeLeft.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(timerFg.sizeDelta.ToString());
        timerFg.sizeDelta = new Vector2(timerBg.rect.width * (timeLeft / timeInterval), timerBg.rect.height);
        if (isRunning)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                isRunning = false;
                Debug.Log("Times up!");
                timeLeft = 0;
                //LET IT RAINNNNN
                rainScript.RainIntensity = 1;
            }
        }

    }
}
