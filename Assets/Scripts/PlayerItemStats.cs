using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerItemStats : MonoBehaviour
{
    public float distanceToObject;

    public int countOfRoots;
    public int countOfPuppet;
    public int countOfUpgratedPuppet;

    public TMP_Text textCountOfRoots;
    public TMP_Text textCountOfPuppets;
    public TMP_Text textCountOfUpPuppets;

    private void Update()
    {
        textCountOfRoots.text = countOfRoots.ToString();
        textCountOfPuppets.text = countOfPuppet.ToString();
        textCountOfUpPuppets.text = countOfUpgratedPuppet.ToString();
    }
}
