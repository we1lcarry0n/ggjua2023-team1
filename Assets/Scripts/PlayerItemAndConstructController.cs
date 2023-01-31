using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemAndConstructController : MonoBehaviour
{
    #region Fields

    public float distanceToObject;
    public bool isItemInDistance;
    private bool isCanTakeItem;
    public int countOfRoots;
    private int countOfPuppet;
    private int countOfUpgratedPuppet;

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
                isItemInDistance = false;
            }
            if (Input.GetKey(KeyCode.F))
            {
                
            }
        }
    }
}
