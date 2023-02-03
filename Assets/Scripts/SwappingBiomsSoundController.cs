using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwappingBiomsSoundController : MonoBehaviour
{
    [SerializeField] private AudioSource forest;
    [SerializeField] private AudioSource swamp;

    private bool isInForest;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (isInForest)
            {
                swamp.mute = false;
                isInForest = false;
            }
            else if (!isInForest)
            {
                swamp.mute = true;
                isInForest = true;
            }
        }
    }
}
