using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RootsAndConstructorController : MonoBehaviour
{
    private PlayerItemStats player;
    private GameObject canvas;
    
    public TMP_Text HintButton;

    public GameObject craftMiniGame;
    public GameObject blessMiniGame;
    public Slider hateBar;

    private Outline outline;
        
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItemStats>();
        canvas = GameObject.Find("Canvas");
        outline = GetComponent<Outline>();
        HintButton.gameObject.SetActive(false);
    }

    void Update()
    {
        OutlineOn();

        if (Vector3.Distance(transform.position, player.transform.position) < player.distanceToObject)
        {
            if (this.gameObject.CompareTag("Root"))
            {
                HintButton.text = "Press E\nto pick up root";
            }
            if (this.gameObject.CompareTag("Constructor") 
                || this.gameObject.CompareTag("BlessingAltar"))
            {
                HintButton.text = "Press F\nto create a puppet";
            }
            if (this.gameObject.CompareTag("GiftAltar"))
            {
                HintButton.text = "Press F\nto gift a puppet";
            }

            PickUpRoot();

            InteractionWithAltar();

            GiftToTree();

            HintButton.gameObject.SetActive(true);
        } else
        {
            HintButton.gameObject.SetActive(false);
        }
    }

    private void PickUpRoot()
    {
        if (Input.GetKey(KeyCode.E) && player.countOfRoots == 0)
        {
            player.countOfRoots++;
            this.gameObject.GetComponentInParent<SpawnRoots>().ChangePosition();
            Destroy(this.gameObject);
        }
    }

    private void InteractionWithAltar()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (this.gameObject.CompareTag("Constructor"))
            {
                if (player.countOfRoots > 0)
                {
                    Instantiate(craftMiniGame, canvas.transform);
                }
            }
            else if (this.gameObject.CompareTag("BlessingAltar"))
            {
                if (player.countOfPuppet > 0)
                {
                    Instantiate(blessMiniGame, canvas.transform);
                }
            }
        }
    }

    private void GiftToTree()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (this.gameObject.CompareTag("GiftAltar"))
            {
                if (player.countOfPuppet > 0)
                {
                    player.countOfPuppet--;
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
