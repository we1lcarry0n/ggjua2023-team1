using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflySpawner : MonoBehaviour
{
    [SerializeField] private GameObject fireflyPrefab;
    void Start()
    {
        Instantiate(fireflyPrefab, transform.position, Quaternion.identity, transform);
    }

}
