using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RootsAndConstructorController : MonoBehaviour
{
    public PlayerItemStats player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItemStats>();    
    }

    void Update()
    {
        if (Vector3.Distance(transform.position,
            player.transform.position) < player.distanceToObject)
        {
            if (Input.GetKey(KeyCode.E) && this.gameObject.CompareTag("Root") && player.countOfRoots == 0)
            {
                player.countOfRoots++;
                this.gameObject.GetComponentInParent<SpawnRoots>().ChangePosition();
                Destroy(this.gameObject);
            }

            if (Input.GetKey(KeyCode.F))
            {
                if (this.gameObject.CompareTag("Constructor"))
                {
                    if (player.countOfRoots > 0)
                    {
                        player.countOfRoots--;
                        player.countOfPuppet++;
                    }
                } else if (this.gameObject.CompareTag("BlessingAltar"))
                {
                    if (player.countOfPuppet > 0)
                    {
                        player.countOfPuppet--;
                        player.countOfUpgratedPuppet++;
                    }
                } else if (this.gameObject.CompareTag("GiftAltar"))
                {
                    if (player.countOfPuppet > 0)
                    {
                        player.countOfPuppet--;
                    }
                }
            }

        }
    }
}
