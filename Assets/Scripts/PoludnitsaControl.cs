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
    private AudioSource gameManager;
    [SerializeField] private AudioClip deathCry;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        player = FindObjectOfType<Player>().gameObject;
        playerStats = player.GetComponent<PlayerItemStats>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
        Invoke("DeathCry", 9.9f);
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);

        if (playerStats.countOfUpgratedPuppet == 0)
        {
            DeathCry();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(spiritMiniGame, canvas.transform);
            DeathCry();
            Destroy(gameObject);
        }
    }

    private void DeathCry()
    {
        gameManager.clip = deathCry;
        gameManager.Play();
    }
}
