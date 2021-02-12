using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sludge_Script : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator animator;

    public float attackCooldown;
    public float attackCounter;

    public bool startCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        attackCounter = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector2.Distance(transform.position, playerMovement.transform.position) < 2f && attackCounter <= 0)
        {
            if(playerMovement.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(4, transform.localScale.y, transform.localScale.y);
                animator.SetTrigger("Attack1");
                startCooldown = true;                
            }
            else if (playerMovement.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-4, transform.localScale.y, transform.localScale.y);
                animator.SetTrigger("Attack1");
                startCooldown = true;
            }
        }

        if(attackCounter >= attackCooldown)
        {
            attackCounter = 0f;
            startCooldown = false;
        }

        if(startCooldown)
        {
            attackCounter += Time.deltaTime;
        }        
    }
}
