using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RootsAndConstructorController : MonoBehaviour
{
    public PlayerItemStats player;
    public TMP_Text textCountOfRoots;
    public TMP_Text textCountOfPuppets;
    public TMP_Text textCountOfUpPuppets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position,
            player.transform.position) < player.distanceToObject)
        {
            if (Input.GetKey(KeyCode.E) && this.gameObject.CompareTag("Root") && player.countOfRoots == 1)
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

        textCountOfRoots.text = player.countOfRoots.ToString();
        textCountOfPuppets.text = player.countOfPuppet.ToString();
        textCountOfUpPuppets.text = player.countOfUpgratedPuppet.ToString();
    }
}
