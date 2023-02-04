using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject poludnitsa;
    public GameObject player;
    private PlayerItemStats playerStats;

    public Vector3 offsetSpawnPoludnitsa = new(0,0,10);

    private bool isSpawnSpirit;
    void Start()
    {
        playerStats = player.GetComponent<PlayerItemStats>();
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (playerStats.countOfUpgratedPuppet == 1 && !isSpawnSpirit)
            {
                Instantiate(poludnitsa);
                PoludnitsaLife();
                isSpawnSpirit = true;
            }
            else if (playerStats.countOfUpgratedPuppet == 0)
            {
                isSpawnSpirit = false;
            }
        }
    }

    private void PoludnitsaLife()
    {
        poludnitsa.transform.position = player.transform.position + offsetSpawnPoludnitsa;
    }
}
