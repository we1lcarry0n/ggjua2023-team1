using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RootsAndConstructorController : MonoBehaviour
{
    private PlayerItemStats player;
    private bool isInterracted;
    private GameObject canvas;
    
    public TMP_Text HintButton;

    public GameObject craftMiniGame;
    public GameObject blessMiniGame;
    public Slider hateBar;

    private Outline outline;

    private AudioSource gameManager;
    [SerializeField] private AudioClip pickUpClip;
        
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItemStats>();
        canvas = GameObject.Find("Canvas");
        outline = GetComponent<Outline>();
        HintButton.gameObject.SetActive(false);
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
    }

    void Update()
    {
        OutlineOn();
        

        if (Vector3.Distance(transform.position, player.transform.position) < player.distanceToObject)
        {
            

            if (this.gameObject.CompareTag("Root"))
            {
                HintButton.text = "Press E\nto pick up root";
                isInterracted = true;
            }
            if (this.gameObject.CompareTag("Constructor") 
                || this.gameObject.CompareTag("BlessingAltar"))
            {
                HintButton.text = "Press F\nto create a puppet";
                isInterracted = true;
            }
            if (this.gameObject.CompareTag("GiftAltar"))
            {
                HintButton.text = "Press F\nto gift a puppet";
                isInterracted = true;
            }

            HintButton.gameObject.SetActive(true);

            PickUpRoot();

            InteractionWithAltar();

            GiftToTree();

            
        }
        else
        {
            if (isInterracted)
            {
                HintButton.gameObject.SetActive(false);
                isInterracted = false;
            }
        }
    }

    private void PickUpRoot()
    {
        if (Input.GetKey(KeyCode.E) && player.countOfRoots == 0)
        {
            gameManager.clip = pickUpClip;
            gameManager.Play();
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
                    gameManager.clip = pickUpClip;
                    gameManager.Play();
                    Instantiate(craftMiniGame, canvas.transform);
                }
            }
            else if (this.gameObject.CompareTag("BlessingAltar"))
            {
                if (player.countOfPuppet > 0)
                {
                    gameManager.clip = pickUpClip;
                    gameManager.Play();
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
                    gameManager.clip = pickUpClip;
                    gameManager.Play();
                    player.countOfPuppet--;
                    hateBar.value -= 10f;
                }

                if (player.countOfUpgratedPuppet > 0)
                {
                    gameManager.clip = pickUpClip;
                    gameManager.Play();
                    player.countOfUpgratedPuppet--;
                    hateBar.value -= 20f;
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
