using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClockOfGame : MonoBehaviour
{
    public Slider clockSlider;
    public TMP_Text timeOfClock;
    public float clockMax;

    private float minute;
    private float hour;
    private float colorMinute;

    private bool isPlay;

    [SerializeField] private Light globalLight;
    [SerializeField] private Color32 colorToMix;

    void Start()
    {
        clockSlider.maxValue = clockMax;
        clockSlider.value = clockMax;
        isPlay = true;
    }

    void Update()
    {
        PlayTime();

        if (hour == 7)
        {
            isPlay = false;
        }
    }

    private void PlayTime()
    {
        if (isPlay)
        {
            clockSlider.value -= Time.deltaTime;
            minute += Time.deltaTime * 0.7f;
            colorMinute += Time.deltaTime;

            if (minute >= 59)
            {
                minute = 0;
                hour++;
                AdjustColor();
            }

            if (colorMinute >= 30)
            {
                colorMinute = 0;
                AdjustColor();
            }

            if (minute >= 9.5f)
            {
                timeOfClock.text = "0" + hour.ToString("F0") + ":" + minute.ToString("F0");
            }
            else if (minute < 9.5f)
            {
                timeOfClock.text = "0" + hour.ToString("F0") + ":0" + minute.ToString("F0");
            }
        }

        if (!isPlay)
        {
            Debug.Log("The night is over");
        }
    }

    private void AdjustColor()
    {
        globalLight.color += colorToMix;
    }
}
