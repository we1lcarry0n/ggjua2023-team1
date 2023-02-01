using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnRoots : MonoBehaviour
{
    public Vector3[] spawnPoints;
    public GameObject rootToSpawn;
    private readonly Dictionary<int, int> scenesValueRoots = new()
    {
        {1, 2},
        {2, 3},
        {3, 4},
        {4, 3},
        {5, 4}
    };

    void Start()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (scenesValueRoots.TryGetValue(currentScene, out int numberOfRootsOnScene))
        {
            SetRandomPointsViaHashSet(numberOfRootsOnScene);
        }
        Destroy(rootToSpawn);
    }

    /// <summary>
    /// Повертає масив рандомних значень розмірністю n 
    /// </summary>
    /// <param name="sizeOfArray">Розмірність масиву</param>
    private void SetRandomPointsViaHashSet(int sizeOfArray)
    {
        HashSet<int> randomPoints = new();
        System.Random randomizer = new();
        int iter = 0;
        while(randomPoints.Count != sizeOfArray)
        {
            int index = randomizer.Next(sizeOfArray);
            randomPoints.Add(index);
            iter++;
        }

        foreach (int currentPoint in randomPoints)
        {
            Instantiate(rootToSpawn, spawnPoints[currentPoint], Quaternion.identity);
        }
    }
}
