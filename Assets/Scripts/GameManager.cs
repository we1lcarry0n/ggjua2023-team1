using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject poludnitsa;
    public GameObject player;

    public Vector3 offsetSpawnPoludnitsa = new(0,0,10);
    // Start is called before the first frame update
    void Start()
    {
        //PoludnitsaLife();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PoludnitsaLife()
    {
        Instantiate(poludnitsa);
        poludnitsa.transform.position = player.transform.position + offsetSpawnPoludnitsa;
        //Vector3 spawnPos = player.transform.position + offsetSpawnPoludnitsa;
    }
}
