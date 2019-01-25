﻿using System.Collections;
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
    bool isCoolingDown = false;
    bool isRaining = false;

    float timeLeft = 0;
    [SerializeField]
    private RainScript2D rainScript;

    [SerializeField]
    private RectTransform timerFg; 

    [SerializeField]
    private RectTransform timerBg;

    [SerializeField]
    private float rainStartInterval;
    [SerializeField]
    private float rainDuration;

    public event Action OnRain;

    public void RestartTimer(int timeLeft)
    {
        isCoolingDown = true;
        this.timeLeft = timeLeft;
    }

    // Start is called before the first frame update
    void Start()
    {
        isCoolingDown = true;
        timeLeft = rainStartInterval;
        rainScript.RainIntensity = 0;
        Debug.Log("TimerStart " + timeLeft.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(timerFg.sizeDelta.ToString());
        if (isCoolingDown)
        {
            timerFg.sizeDelta = new Vector2(timerBg.rect.width * (timeLeft / rainStartInterval), timerBg.rect.height);

            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                //LET IT RAINNNNN
                isCoolingDown = false;
                isRaining = true;
                timeLeft = rainDuration;
                rainScript.RainIntensity = 1;
            }
        }

        if (isRaining)
        {
            timerFg.sizeDelta = new Vector2(timerBg.rect.width - (timerBg.rect.width * (timeLeft / rainDuration)), timerBg.rect.height);

            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                isRaining = false;
                isCoolingDown = true;
                timeLeft = rainStartInterval;
                rainScript.RainIntensity = 0;
            }
        }
    }
}
