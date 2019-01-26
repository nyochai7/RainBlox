using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DigitalRuby.RainMaker;
using FMOD.Studio;
using System;

public class TimesUpEvent : UnityEvent
{
    //
}

public class Timer : MonoBehaviour
{
    public string EVENT_NAME = "event:/New Event";

    bool isCoolingDown = false;
    bool isRaining = false;

    int coolDownTimes = 1;
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

    [SerializeField] 
     private Transform liightnings;

     [SerializeField] 
     private Transform[] liightningAnchors;

    public event Action OnRain;

    private EventInstance audioEvent;
    private ParameterInstance fmodEvent;

    public void RestartTimer(int timeLeft)
    {
        isCoolingDown = true;
        this.timeLeft = timeLeft;
    }
    public IEnumerator ShowLightning(){
    int rand = UnityEngine.Random.Range(0,liightningAnchors.Length);
    liightnings.gameObject.SetActive(true);
    liightnings.position = liightningAnchors[rand].position;
    liightnings.rotation = liightningAnchors[rand].rotation;
    yield return new WaitForSeconds (0.4f);
    liightnings.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        isCoolingDown = true;
        timeLeft = rainStartInterval;
        rainScript.RainIntensity = 0;
        Debug.Log("TimerStart " + timeLeft.ToString());
        audioEvent = FMODUnity.RuntimeManager.CreateInstance(EVENT_NAME);
        audioEvent.getParameter("MusicChange", out fmodEvent);
        audioEvent.start();

        fmodEvent.setValue(0);
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
                fmodEvent.setValue(1);

               StartCoroutine(ShowLightning());
            }
        }

        if (isRaining)
        {
            coolDownTimes ++;
            timerFg.sizeDelta = new Vector2(timerBg.rect.width - (timerBg.rect.width * (timeLeft / rainDuration)), timerBg.rect.height);

            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                isRaining = false;
                isCoolingDown = true;
                timeLeft = rainStartInterval;
                rainScript.RainIntensity = 0;
                fmodEvent.setValue(0);

            }
        }
    }
}
