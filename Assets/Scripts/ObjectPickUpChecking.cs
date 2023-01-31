using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectPickUpChecking : MonoBehaviour
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
            if (Input.GetKey(KeyCode.E))
            {
                player.countOfRoots++;
                textCountOfRoots.text = player.countOfRoots.ToString();
            }
        }
    }
}
