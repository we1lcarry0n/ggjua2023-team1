using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardMiniGame : MonoBehaviour
{
    public Slider miniGameSlider;
    public Slider reactionCountSlider;
    public RectTransform pointerContainer;
    public RectTransform reactionBar;
    public GameObject repeatTab;
    public GameObject winningTab;
    public GameObject miniGameBox;
    private PlayerItemStats player;

    public int reactionCount;

    public float reactionLength;
    public float pointerSpeed;

    private float pointerAngle;
    private float currentPointerAngle;
    private float reactionBarAngle;
    private float currentReactionBarAngle;
    private float checkReaction;
    private int checkCount;

    private bool isReverse;
    private bool stopGame = true;
    private bool canRestart;
    public bool isPoludnitsa;
    public bool isBless;

    void Start()
    {
        StartCoroutine(StartMiniGame());
        player = GameObject.Find("Player").GetComponent<PlayerItemStats>();
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
                    checkCount++;

                    if (checkCount == reactionCount)
                    {
                        WinGame();
                    }

                    reactionCountSlider.value++;
                    isReverse = !isReverse;
                    reactionBarAngle = pointerAngle;
                    currentReactionBarAngle = currentPointerAngle;
                    SpawnReactionBar();
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
        }

        if (Input.GetKeyDown(KeyCode.R) && stopGame && canRestart)
        {
            RestartGame();
            canRestart = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isBless)
        {
            Destroy(miniGameBox);
        }
    }

    private void PointerMove()
    {
        if (!isReverse)
        {
            float angleSpeed = Time.deltaTime / pointerSpeed * 360;
            pointerAngle += angleSpeed;
            currentPointerAngle += angleSpeed;
            pointerContainer.localEulerAngles = new Vector3(0, 0, -currentPointerAngle);
        }else if (isReverse)
        {
            float angleSpeed = Time.deltaTime / pointerSpeed * 360;
            pointerAngle += angleSpeed;
            currentPointerAngle -= angleSpeed;
            pointerContainer.localEulerAngles = new Vector3(0, 0, -currentPointerAngle);
        }
    }


    private void SpawnReactionBar()
    {
        float randomRangeRotate = Random.Range(90, 270);
        if (!isReverse)
        {
            reactionBar.localScale = new(1, 1, 1);
            reactionBarAngle += randomRangeRotate;
            currentReactionBarAngle += randomRangeRotate;
            reactionBar.localEulerAngles = new Vector3(0, 0, -currentReactionBarAngle);
            checkReaction = reactionBarAngle + reactionLength;
        }else if (isReverse)
        {
            reactionBar.localScale = new(-1, 1, 1);
            reactionBarAngle += randomRangeRotate;
            currentReactionBarAngle -= randomRangeRotate;
            reactionBar.localEulerAngles = new Vector3(0, 0, -currentReactionBarAngle);
            checkReaction = reactionBarAngle + reactionLength;
        }
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
        StartCoroutine(HideRepeatTable());
    }

    private void GameOver()
    {
        StartCoroutine(HideMiniGame());
        if (!isPoludnitsa)
        {
            StartCoroutine(ShowRepeatTable());
            canRestart = true;
        }
        if (isPoludnitsa)
        {
            player.countOfUpgratedPuppet--;
        }
        pointerAngle = 0;
        currentPointerAngle = 0;
        currentReactionBarAngle = 0;
        reactionBarAngle = 0;
        checkCount = 0;
        isReverse = false;
        stopGame = true;
        Debug.Log("You lose");
    }

    private void WinGame()
    {
        StartCoroutine(HideMiniGame());
        if (isBless)
        {
            player.countOfPuppet--;
            player.countOfUpgratedPuppet++;
        }
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
        if (isPoludnitsa)
        {
            Destroy(miniGameBox, 2f);
        }
    }

    private IEnumerator ShowRepeatTable()
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

    private IEnumerator HideRepeatTable()
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
        Destroy(miniGameBox, 2f);
    }
}
