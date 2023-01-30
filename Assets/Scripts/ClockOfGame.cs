using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockOfGame : MonoBehaviour
{
    public Slider clockSlider;
    public float clockMax;

    void Start()
    {
        clockSlider.maxValue = clockMax;
        clockSlider.value = clockMax;
    }

    void Update()
    {
        clockSlider.value -= Time.deltaTime;
    }
}
