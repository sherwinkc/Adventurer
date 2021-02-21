using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarecrow_Script : MonoBehaviour
{
    public Animator animator;
    public GameObject deathSplosion;
    public SquibTransform squibTransform;
    public DestroyOverTime destroyOverTime;

    public int maxHealth;
    public int currentHealth;

    public AudioSource squelch;


    void Start()
    {
        animator = GetComponent<Animator>();
        destroyOverTime = GetComponent<DestroyOverTime>();
        squibTransform = GetComponentInChildren<SquibTransform>();

        //set currentHealth to max health
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth >= 0)
        {
            animator.SetTrigger("Hurt");
            //Instantiate(squib, squibTransform.transform.position, squibTransform.transform.rotation);
        }

        if (currentHealth <= 0)
        {
            Die();
            Instantiate(deathSplosion, squibTransform.transform.position, squibTransform.transform.rotation);

            /*for (int i = 0; i < Random.Range(2f, 4f); i++)
            {
                //Instantiate(orbsOnDeath, new Vector2(squibTransform.transform.position.x, squibTransform.transform.position.y + 1), squibTransform.transform.rotation);
            }*/
        }

        squelch.Play();
    }

    void Die()
    {
        //animator.SetBool("isDead", true);
        //spiderController.churp.Stop();
        //spiderController.scurry.Stop();

        //spiderController.canMove = false;

        //Disable Rigidbody  
        //rb.simulated = false;

        //Disable Circle Collider in Children 
        //GetComponentInChildren<BoxCollider2D>().enabled = false;

        destroyOverTime.isOn = true;

        //Disable this Spider_Script component
        this.enabled = false;
        this.gameObject.SetActive(false);


    }
}
