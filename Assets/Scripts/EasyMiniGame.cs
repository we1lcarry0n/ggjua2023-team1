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
                    stopGame = true;
                }
            }

            if (pointerAngle > checkReaction)
            {
                stopGame = true;
                Debug.Log("You lose");
            }

            if (checkCount == reactionCount)
            {
                checkCount = 0;
                stopGame = true;
                Debug.Log("You win");
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
}
