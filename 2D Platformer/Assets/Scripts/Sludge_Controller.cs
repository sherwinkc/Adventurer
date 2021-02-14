using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sludge_Controller : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator animator;
    private LevelManager levelManager;

    public float attackCooldown;
    public float attackCounter;

    public bool startCooldown = false;

    //audio
    public AudioSource swipe;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        levelManager = FindObjectOfType<LevelManager>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        attackCounter = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, playerMovement.transform.position) < 2f && attackCounter <= 0 && levelManager.healthCount > 0)
        {
            if (playerMovement.transform.position.x < transform.position.x)
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

        if (attackCounter >= attackCooldown)
        {
            attackCounter = 0f;
            startCooldown = false;
        }

        if (startCooldown)
        {
            attackCounter += Time.deltaTime;
        }
    }

    public void SwipeSFX()
    {
        swipe.Play();
    }
}
