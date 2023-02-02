using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoludnitsaControl : MonoBehaviour
{
    public GameObject spiritMiniGame;
    private GameObject player;
    private GameObject canvas;
    public float speed;

    private Rigidbody enemyRb;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        canvas = GameObject.Find("Canvas");
        player = FindObjectOfType<Player>().gameObject;
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookDirection * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(spiritMiniGame, canvas.transform);
            Destroy(gameObject);
        }
    }
}
