using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stam_Bar_Location : MonoBehaviour
{
    PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }


    void Update()
    {
        transform.position = new Vector3(playerMovement.transform.position.x, playerMovement.transform.position.y, playerMovement.transform.position.z);
        //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        /*if (playerMovement.transform.localScale.x == -5)
        {
            //rectTransform.localScale.x == -001;
        }*/
    }
}
