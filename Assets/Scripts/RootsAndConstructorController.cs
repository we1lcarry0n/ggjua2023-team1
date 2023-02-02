using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RootsAndConstructorController : MonoBehaviour
{
    private PlayerItemStats player;
    private GameObject canvas;

    public GameObject craftMiniGame;
    public GameObject blessMiniGame;
    public Slider hateBar;

    private Outline outline;
        
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItemStats>();
        canvas = GameObject.Find("Canvas");
        outline = GetComponent<Outline>();
    }

    void Update()
    {
        OutlineOn();

        if (Vector3.Distance(transform.position, player.transform.position) < player.distanceToObject)
        {
            if (Input.GetKey(KeyCode.E) && this.gameObject.CompareTag("Root") && player.countOfRoots == 0)
            {
                player.countOfRoots++;
                this.gameObject.GetComponentInParent<SpawnRoots>().ChangePosition();
                Destroy(this.gameObject);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (this.gameObject.CompareTag("Constructor"))
                {
                    if (player.countOfRoots > 0)
                    {
                        Instantiate(craftMiniGame, canvas.transform);
                    }
                } else if (this.gameObject.CompareTag("BlessingAltar"))
                {
                    if (player.countOfPuppet > 0)
                    {
                        Instantiate(blessMiniGame, canvas.transform);
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

    private void OutlineOn()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < player.distanceToObject)
        {
            this.outline.OutlineWidth = 2;
        }else
        {
            this.outline.OutlineWidth = 0;
        }
    }
}
