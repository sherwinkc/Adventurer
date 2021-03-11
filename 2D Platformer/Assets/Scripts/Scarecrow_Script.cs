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

    public AudioSource hay;


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
        }

        if(hay)
        {
            hay.pitch = Random.Range(0.9f, 1.1f);
            hay.Play();
        }

        if (currentHealth <= 0)
        {
            Die();
            Instantiate(deathSplosion, squibTransform.transform.position, squibTransform.transform.rotation);
        }

    }

    void Die()
    {
        destroyOverTime.isOn = true;

        //Disable this Spider_Script component
        this.enabled = false;
        this.gameObject.SetActive(false);
    }
}
