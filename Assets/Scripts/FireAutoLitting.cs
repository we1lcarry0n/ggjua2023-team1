using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAutoLitting : MonoBehaviour
{
    [SerializeField] private GameObject[] lights;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            foreach (GameObject light in lights)
            {
                light.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (GameObject light in lights)
            {
                light.SetActive(false);
            }
        }
    }
}
