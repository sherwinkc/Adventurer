using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Skel_Script : MonoBehaviour
{
    //Components
    public Rigidbody2D rb;
    public Animator animator;
    public PlayerCombat playerCombat;
    public Upgrades upgrades;
    public DestroyOverTime destroyOverTime;
    public Fire_Skel_Controller fire_Skel_Controller;

    public GameObject deathSplosion;
    public GameObject orbsOnDeath;

    public GameObject fireVFX;

    public int maxHealth;
    public int currentHealth;

    //Audio
    public AudioSource enemyGrunt1;
    public AudioSource bloodSquelch;

    void Start()
    {
        currentHealth = maxHealth;

        animator = GetComponent<Animator>();
        destroyOverTime = GetComponentInParent<DestroyOverTime>();
        rb = GetComponent<Rigidbody2D>();
        fire_Skel_Controller = GetComponent<Fire_Skel_Controller>();
        playerCombat = FindObjectOfType<PlayerCombat>();
        upgrades = FindObjectOfType<Upgrades>();

        fireVFX.gameObject.SetActive(true);
    }

    // Update is called once per frame
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

        if (enemyGrunt1 != null)
        {
            enemyGrunt1.Play();
        }

        bloodSquelch.Play();

        if (currentHealth <= 0)
        {
            Instantiate(deathSplosion, transform.position, transform.rotation);

            for (int i = 0; i < Random.Range(4f, 5f); i++)
            {
                Instantiate(orbsOnDeath, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            }

            Die();
            playerCombat.superAmount += upgrades.superAmountReturned; //???
        }
    }

    void Die()
    {
        animator.SetTrigger("isDead 0");

        fire_Skel_Controller.canMove = false;

        rb.simulated = false;

        fireVFX.gameObject.SetActive(false);

        //Disable Box Colliders
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponentInChildren<BoxCollider2D>().enabled = false;

        //Disable any capsule collders
        GetComponent<CapsuleCollider2D>().enabled = false;

        //Destroy Parent object over time
        destroyOverTime.isOn = true;

        //Disable this Enemy Script component
        this.enabled = false;
    }
}
