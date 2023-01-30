using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasyMiniGame : MonoBehaviour
{
    public Slider miniGameSlider;
    public Slider reactionCountSlider;
    public RectTransform pointerContainer;
    public RectTransform reactionBar;

    public int reactionCount;

    public float reactionLength;
    public float pointerSpeed;

    private float pointerAngle;
    private float reactionBarAngle;
    private float checkReaction;
    private int checkCount;

    private bool stopGame = true;

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

            if (checkCount == reactionCount)
            {
                WinGame();
            }
        }
    }

    private void PointerMove()
    {
        float angleSpeed = Time.deltaTime / pointerSpeed * 360;
        pointerAngle += angleSpeed;
        pointerContainer.localEulerAngles = new Vector3 (0,0, -pointerAngle);
    }

    private void SpawnReactionBar()
    {
        reactionBarAngle += Random.Range(90, 270);
        reactionBar.localEulerAngles = new Vector3(0, reactionBar.localEulerAngles.y, -reactionBarAngle);
        checkReaction = reactionBarAngle + reactionLength;
    }

    private IEnumerator StartMiniGame()
    {
        pointerContainer.localEulerAngles = Vector3.zero;
        SpawnReactionBar();
        reactionCountSlider.maxValue = reactionCount;
        yield return new WaitForSeconds(1f);
        stopGame = false;
    }

    public void RestartGame()
    {
        pointerAngle = 0;
        reactionBarAngle = 0;
        miniGameSlider.value = 0;

        StartCoroutine(StartMiniGame());
    }

    private void GameOver()
    {
        StartCoroutine(HideMiniGame());
        stopGame = true;
        Debug.Log("You lose");
    }

    private void WinGame()
    {
        StartCoroutine(HideMiniGame());
        checkCount = 0;
        stopGame = true;
        Debug.Log("You win");
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
        transform.localScale = Vector3.zero;
        for (float i = 0; i < 1f; i += Time.deltaTime)
        {
            transform.localScale = Vector3.one * (1f - i);
            yield return null;
        }
        transform.localScale = Vector3.one;
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
