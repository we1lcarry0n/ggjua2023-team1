using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnRoots : MonoBehaviour
{
    public Vector3[] spawnPoints;
    public GameObject rootToSpawn;
    public Dictionary<int, int> scenesValueRoots = new()
    {
        {1, 2},
        {2, 3},
        {3, 4},
        {4, 3},
        {5, 4}
    };

    void Start()
    {
        //int currentScene = SceneManager.GetActiveScene().buildIndex;
        int currentScene = 5;
        Debug.Log(currentScene);
        if (scenesValueRoots.TryGetValue(currentScene, out int numberOfRootsOnScene))
        {
            SetRandomPoints(numberOfRootsOnScene);
        }
        Destroy(rootToSpawn);
    }

    /// <summary>
    /// Повертає масив рандомних значень розмірністю n 
    /// </summary>
    /// <param name="sizeOfArray">Розмірність масиву</param>
    private void SetRandomPoints(int sizeOfArray)
    {
        int currentPoint;
        int i = 0;

        while (i < sizeOfArray){
            currentPoint = NewRandomNumber();
            if (Physics.CheckSphere(spawnPoints[currentPoint], 1))
            {
                currentPoint = NewRandomNumber();
            }
            else
            {
                Instantiate(rootToSpawn, spawnPoints[currentPoint], Quaternion.identity);
                i++;
            }
        }
    }

    private int randomNumber;
    private int lastNumber;
    /// <summary>
    /// Генерує рандомне неповторюване число
    /// </summary>
    private int NewRandomNumber()
    {
        randomNumber = Random.Range(0, spawnPoints.Length-1);
        if (randomNumber == lastNumber)
        {
            randomNumber = Random.Range(0, spawnPoints.Length-1);
        }
        lastNumber = randomNumber;

        return lastNumber;
    }

}
