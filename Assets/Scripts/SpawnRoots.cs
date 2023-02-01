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
        var rndIndices = new HashSet<int>();
        var rng = new System.Random();
        int iter = 0;
        while(rndIndices.Count != sizeOfArray)
        {
            int index = rng.Next(sizeOfArray);
            rndIndices.Add(index);
            iter++;
        }

        foreach (int currentPoint in rndIndices)
        {
            Instantiate(rootToSpawn, spawnPoints[currentPoint], Quaternion.identity);
        }
    }
}
