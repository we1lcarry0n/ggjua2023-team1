using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefly : MonoBehaviour
{
    public Transform pointsContainer;
    public List<Transform> points;

    public float speed;
    public int curentPoint = 0;

    private SpriteRenderer spriteRenderer;

    private Transform playerTransform;
    private void Start()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();

        for (int i = 0; i < pointsContainer.childCount; i++)
        {
            points.Add(pointsContainer.GetChild(i));
        }
    }

    private void FixedUpdate()
    {

        if (playerTransform)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, points[curentPoint].position, speed);

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

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTransform = null;
        }
    }
}
