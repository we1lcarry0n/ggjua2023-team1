using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel.Design;

public class ClockOfGame : MonoBehaviour
{
    public Slider clockSlider;
    public TMP_Text timeOfClock;
    public Image endNight;
    public Image welcomeWindow;
    public float clockMax;

    private float minute;
    private float hour;
    private float colorMinute;

    public bool canPlay;

    private bool isPlay;
    private bool nightIsOver;

    [SerializeField] private Light globalLight;
    [SerializeField] private Color32 colorToMix;

    void Start()
    {
        clockSlider.maxValue = clockMax;
        clockSlider.value = clockMax;
        isPlay = true;
        StartCoroutine(StartNight());
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
        if (isPlay && canPlay)
        {
            clockSlider.value -= Time.deltaTime;
            minute += Time.deltaTime * 0.7f ;
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

        if (!isPlay && !nightIsOver)
        {
            Debug.Log("The night is over");
            nightIsOver = true;
            StartCoroutine(NightOver());
        }
    }

    private void AdjustColor()
    {
        globalLight.color += colorToMix;
    }

    private IEnumerator NightOver()
    {
        endNight.gameObject.SetActive(!endNight.gameObject.activeSelf);
        endNight.gameObject.transform.localScale = Vector3.zero;
        for (float i = 0; i < 1f; i += Time.deltaTime)
        {
            endNight.gameObject.transform.localScale = Vector3.one * i;
            yield return null;
        }
        endNight.gameObject.transform.localScale = Vector3.one;
        yield return new WaitForSeconds(2f);
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(0);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator StartNight()
    {
        welcomeWindow.gameObject.SetActive(!welcomeWindow.gameObject.activeSelf);
        welcomeWindow.gameObject.transform.localScale = Vector3.zero;
        for (float i = 0; i < 1f; i += Time.deltaTime)
        {
            welcomeWindow.gameObject.transform.localScale = Vector3.one * i;
            yield return null;
        }
        welcomeWindow.gameObject.transform.localScale = Vector3.one;
    }

    public void CloseWelcomeWindow()
    {
        welcomeWindow.gameObject.SetActive(!welcomeWindow.gameObject.activeSelf);
        canPlay = true;
    }
}
