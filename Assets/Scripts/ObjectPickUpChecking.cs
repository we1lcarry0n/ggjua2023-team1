using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickUpChecking : MonoBehaviour
{
    public PlayerItemAndConstructController player;

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
            player.isItemInDistance = true;
            if (Input.GetKey(KeyCode.E))
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            player.isItemInDistance = false;
        }
    }
}
