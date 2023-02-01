using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnRoots : MonoBehaviour
{
    public RootController[] rootControllers;
    public GameObject rootToSpawn;

    public int currentPoint;
    public Vector3 currentPosition;

    private void Start()
    {
        currentPoint = Random.Range(0, 4);
        SpawnRootOnPoint();
    }
    private void Update()
    {
        while (!rootControllers[currentPoint].isFree)
        {
            currentPoint = Random.Range(0, 4);
            Debug.Log(currentPoint);
        }

        //SpawnTime();
        SpawnRootOnPoint();
    }

    private void SpawnRootOnPoint()
    {
        currentPosition = rootControllers[currentPoint].transform.position;
        Instantiate(rootToSpawn, currentPosition, Quaternion.identity);
        rootControllers[currentPoint].isFree = false;
    }

    private IEnumerator SpawnTime()
    {
        yield return new WaitForSeconds(0.5f);
    }


    /*public Vector3[] spawnPoints;
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
    }*/
}
