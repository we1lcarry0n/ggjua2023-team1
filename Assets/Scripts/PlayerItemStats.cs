using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerItemStats : MonoBehaviour
{
    public float distanceToObject;

    public int countOfRoots;
    public int countOfPuppet;
    public int countOfUpgratedPuppet;

    public Image root;
    public Image puppet;
    public Image upgPuppet;

    private void Update()
    {
        if (countOfRoots == 1)
        {
            root.gameObject.SetActive(true);
        }else
        {
            root.gameObject.SetActive(false);
        }

        if (countOfPuppet == 1)
        {
            puppet.gameObject.SetActive(true);
        }
        else
        {
            puppet.gameObject.SetActive(false);
        }

        if (countOfUpgratedPuppet == 1)
        {
            upgPuppet.gameObject.SetActive(true);
        }
        else
        {
            upgPuppet.gameObject.SetActive(false);
        }
    }
}
