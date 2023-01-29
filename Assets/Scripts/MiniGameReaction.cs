using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameReaction : MonoBehaviour
{
    public Slider miniGameSlider;
    public RectTransform pointer;
    public RectTransform reactionBar;
    public float pointerAngle;
    public float reactionBarAngle;
    public float checkReaction;

    void Start()
    {
        RandomSpawnReactionBar();
    }

    // Update is called once per frame
    void Update()
    {
        miniGameSlider.value = 0.2f;
        PointerMove();

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (pointerAngle > reactionBarAngle && pointerAngle < (reactionBarAngle + 64f))
            {
                RepeatSpawnReactionBar();
                if (reactionBarAngle > 360)
                {
                    reactionBarAngle -= 360;
                }
            }
        }
    }

    private void PointerMove()
    {
        float angleSpeed = Time.deltaTime / 2 * 360;
        pointerAngle += angleSpeed;
        pointer.localEulerAngles = new Vector3 (0,0, -pointerAngle);
        if (pointerAngle > 360f)
        {
            pointerAngle = 0;
        }
    }

    private void RandomSpawnReactionBar()
    {
        reactionBarAngle = Random.Range(0, 296f);
        reactionBar.localEulerAngles = new Vector3(0, reactionBar.localEulerAngles.y, -reactionBarAngle);
    }

    private void RepeatSpawnReactionBar()
    {
        reactionBarAngle += Random.Range(90, 270);
        reactionBar.localEulerAngles = new Vector3(0, reactionBar.localEulerAngles.y, -reactionBarAngle);
    }
}
