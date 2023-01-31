using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerItemAndConstructController : MonoBehaviour
{
    #region Fields

    public float distanceToObject;
    public bool isItemInDistance;
    private bool isCanTakeItem;
    public int countOfRoots;
    private int countOfPuppet;
    private int countOfUpgratedPuppet;
    public TMP_Text textCountOfRoots;
    public TMP_Text textCountOfPuppets;
    public TMP_Text textCountOfUpPuppets;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isItemInDistance)
        {
            if (Input.GetKey(KeyCode.E))
            {
                countOfRoots++;
                textCountOfRoots.text = countOfRoots.ToString();
                isItemInDistance = false;
            }
        }
    }
}
