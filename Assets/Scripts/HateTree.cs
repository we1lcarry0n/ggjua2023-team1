using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HateTree : MonoBehaviour
{
    public Slider hateBar;
    public TMP_Text hateNum;
    public ClockOfGame clockBox;
    public float maxHateTree;
    public float hateSpeed;

    private float currentHate;

    void Start()
    {
        hateBar.maxValue = maxHateTree;
    }

    void Update()
    {
        if (clockBox.canPlay)
        {
            hateBar.value += Time.deltaTime * hateSpeed;
            currentHate = hateBar.value;
            hateNum.text = currentHate.ToString("F0") + " / " + maxHateTree;
        }

        if (hateBar.value == hateBar.maxValue)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("LoseGame");
        }
    }
}
