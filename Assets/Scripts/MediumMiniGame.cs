using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediumMiniGame : MonoBehaviour
{
    public Slider miniGameSlider;
    public Slider reactionCountSlider;
    public RectTransform pointerContainer;
    public RectTransform reactionBar;
    public GameObject repeatTab;
    public GameObject winningTab;

    public int reactionCount;

    public float reactionLength;
    public float pointerSpeed;

    public float pointerAngle;
    public float reactionBarAngle;
    public float checkReaction;
    public int checkCount;

    private bool stopGame = true;
    private bool canRestart;

    void Start()
    {
        StartCoroutine(ShowMiniGame());
        StartCoroutine(StartMiniGame());
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopGame)
        {
            miniGameSlider.value = (reactionLength * 1) / 360;
            PointerMove();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (pointerAngle > reactionBarAngle && pointerAngle < checkReaction)
                {
                    SpawnReactionBar();
                    checkCount++;
                    reactionCountSlider.value++;
                    if (checkCount == reactionCount)
                    {
                        WinGame();
                    }
                }
                else
                {
                    GameOver();
                }
            }

            if (pointerAngle > checkReaction)
            {
                GameOver();
            }
        }else if (stopGame && canRestart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
                canRestart = false;
            }
        }
    }

    private void PointerMove()
    {
        float angleSpeed = Time.deltaTime / pointerSpeed * 360;
        pointerAngle += angleSpeed;
        pointerContainer.localEulerAngles = new Vector3 (0,0, pointerAngle);
    }

    private void SpawnReactionBar()
    {
        reactionBarAngle += Random.Range(90, 270);
        reactionBar.localEulerAngles = new Vector3(0, reactionBar.localEulerAngles.y, -reactionBarAngle);
        checkReaction = reactionBarAngle + reactionLength;
    }

    private IEnumerator StartMiniGame()
    {
        StartCoroutine(ShowMiniGame());
        pointerContainer.localEulerAngles = Vector3.zero;
        SpawnReactionBar();
        reactionCountSlider.maxValue = reactionCount;
        yield return new WaitForSeconds(1.5f);
        stopGame = false;
    }

    public void RestartGame()
    {
        reactionCountSlider.value = 0;
        miniGameSlider.value = 0;
        StartCoroutine(StartMiniGame());
        StartCoroutine(HideRepeatButton());
    }

    private void GameOver()
    {
        StartCoroutine(HideMiniGame());
        StartCoroutine(ShowRepeatButton());
        pointerAngle = 0;
        reactionBarAngle = 0;
        checkCount = 0;
        stopGame = true;
        canRestart = true;
        Debug.Log("You lose");
    }

    private void WinGame()
    {
        StartCoroutine(HideMiniGame());
        checkCount = 0;
        stopGame = true;
        Debug.Log("You win");
        StartCoroutine(ShowWinningTable());
    }

    private IEnumerator ShowMiniGame()
    {
        transform.localScale = Vector3.zero;
        for (float i = 0; i < 1f; i += Time.deltaTime)
        {
            transform.localScale = Vector3.one * i;
            yield return null;
        }
        transform.localScale = Vector3.one;
    }

    private IEnumerator HideMiniGame()
    {
        transform.localScale = Vector3.one;
        for (float i = 0; i < 1f; i += Time.deltaTime)
        {
            transform.localScale = Vector3.one * (1f - i);
            yield return null;
        }
        transform.localScale = Vector3.zero;
    }

    private IEnumerator ShowRepeatButton()
    {
        repeatTab.SetActive(!repeatTab.activeSelf);
        repeatTab.transform.localScale = Vector3.zero;
        for (float i = 0; i < 1f; i += Time.deltaTime)
        {
            repeatTab.transform.localScale = Vector3.one * i;
            yield return null;
        }
        repeatTab.transform.localScale = Vector3.one;
    }

    private IEnumerator HideRepeatButton()
    {
        repeatTab.transform.localScale = Vector3.one;
        for (float i = 0; i < 1f; i += Time.deltaTime)
        {
            repeatTab.transform.localScale = Vector3.one * (1f - i);
            yield return null;
        }
        repeatTab.transform.localScale = Vector3.zero;
        repeatTab.SetActive(!repeatTab.activeSelf);
    }

    private IEnumerator ShowWinningTable()
    {
        winningTab.SetActive(!winningTab.activeSelf);
        winningTab.transform.localScale = Vector3.zero;
        for (float i = 0; i < 1f; i += Time.deltaTime)
        {
            winningTab.transform.localScale = Vector3.one * i;
            yield return null;
        }
        winningTab.transform.localScale = Vector3.one;

        for (float i = 0; i < 1f; i += Time.deltaTime)
        {
            winningTab.transform.localScale = Vector3.one * (1f - i);
            yield return null;
        }
        winningTab.transform.localScale = Vector3.zero;
        winningTab.SetActive(!winningTab.activeSelf);
    }
}
