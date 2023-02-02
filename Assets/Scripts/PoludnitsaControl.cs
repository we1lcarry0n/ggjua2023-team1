using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoludnitsaControl : MonoBehaviour
{
    public GameObject spiritMiniGame;
    private GameObject player;
    private GameObject canvas;
    public float speed;

    private PlayerItemStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        player = FindObjectOfType<Player>().gameObject;
        playerStats = player.GetComponent<PlayerItemStats>();
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);

        if (playerStats.countOfUpgratedPuppet == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(spiritMiniGame, canvas.transform);
            Destroy(gameObject);
        }
    }
}
