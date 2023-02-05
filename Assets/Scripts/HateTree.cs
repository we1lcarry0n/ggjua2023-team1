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
    public Image loseWindow;

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
            Debug.Log("LoseGame");
            StartCoroutine(LoseTimer());
        }
    }

    private IEnumerator LoseTimer()
    {
        loseWindow.gameObject.SetActive(true);
        loseWindow.gameObject.transform.localScale = Vector3.zero;
        for (float i = 0; i < 1f; i += Time.deltaTime)
        {
            loseWindow.gameObject.transform.localScale = Vector3.one * i;
            yield return null;
        }
        loseWindow.gameObject.transform.localScale = Vector3.one;
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
