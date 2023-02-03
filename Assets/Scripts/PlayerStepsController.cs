using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStepsController : MonoBehaviour
{
    [SerializeField] private AudioClip[] steps;
    private AudioSource stepSound;

    private void Start()
    {
        stepSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Heel")
        {
            Debug.Log("Step");
            stepSound.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Swamp")
        {
            stepSound.clip = steps[0];
        }
        if (other.gameObject.tag == "Sand")
        {
            stepSound.clip = steps[1];
        }
        if (other.gameObject.tag == "Forest")
        {
            stepSound.clip = steps[2];
        }
    }
}
