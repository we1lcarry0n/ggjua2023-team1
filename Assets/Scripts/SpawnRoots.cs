using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoots : MonoBehaviour
{
    public Vector3[] spawnPoints;
    public int numberOfRootsOnScene;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void SetRandomPoints(int n)
    {
        int currentPoint;
        for (int i = 0; i <=n; i++)
        {
            currentPoint = NewRandomNumber();
        }
    }

    private int randomNumber;
    private int lastNumber;
    private int NewRandomNumber()
    {
        randomNumber = Random.Range(0, spawnPoints.Length);
        if (randomNumber == lastNumber)
        {
            randomNumber = Random.Range(0, spawnPoints.Length);
        }
        lastNumber = randomNumber;

        return lastNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
