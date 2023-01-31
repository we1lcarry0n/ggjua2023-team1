using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HateTree : MonoBehaviour
{
    public Slider hateBar;
    public TMP_Text hateNum;
    public float maxHateTree;
    public float hateSpeed;

    private float currentHate;

    void Start()
    {
        hateBar.maxValue = maxHateTree;
    }

    void Update()
    {
        hateBar.value += Time.deltaTime * hateSpeed;
        currentHate = hateBar.value;
        hateNum.text = currentHate.ToString("F0") + " / " + maxHateTree;

        if (hateBar.value == hateBar.maxValue)
        {
            Debug.Log("LoseGame");
        }
    }
}