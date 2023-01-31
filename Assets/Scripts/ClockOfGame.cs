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

    private bool isPlay;

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
            minute += Time.deltaTime;

            if (minute >= 60)
            {
                minute = 0;
                hour++;
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
}
