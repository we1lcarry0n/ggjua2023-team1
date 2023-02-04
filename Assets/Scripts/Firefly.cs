using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefly : MonoBehaviour
{
    public Transform pointsContainer;
    public List<Transform> points;
    public GameObject fireFlyMiniGame;

    public float speed;
    public int curentPoint = 0;

    private Transform playerTransform;
    private GameObject canvas;

    
    private void Start()
    {
        canvas = GameObject.Find("Canvas");
        pointsContainer = transform.parent;

        for (int i = 0; i < pointsContainer.childCount; i++)
        {
            points.Add(pointsContainer.GetChild(i));
        }
    }

    private void Update()
    {

        if (playerTransform)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed*Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, points[curentPoint].position, speed*Time.deltaTime);

            if (transform.position == points[curentPoint].position)
            {
                curentPoint++;

                if (curentPoint == points.Count)
                {
                    curentPoint = 0;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTransform = collision.transform;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(fireFlyMiniGame, canvas.transform);
            Destroy(gameObject);
        }
    }
}
