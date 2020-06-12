using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public bool facingLeft;
    public bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
        facingRight = true;
        facingLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerMovement.transform.localScale.x);
        //checking which way the player sprite is facing and flipping the attack point to match

        if (playerMovement.transform.localScale.x < -1f && facingRight == true)
        {
            facingLeft = true;
            transform.Rotate(0f, 180f, 0);
            facingRight = false;
        }
        else if (playerMovement.transform.localScale.x > 1f && facingLeft == true)
        {
            facingRight = true;
            transform.Rotate(0f, 180f, 0);            
            facingLeft = false;
        }
    }
}

