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

        playerCombat = FindObjectOfType<PlayerCombat>();
        upgrades = FindObjectOfType<Upgrades>();

        fireVFX.SetActive(true);
        //fireVFX = GetComponentInChildren<ParticleSystem>();
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
        animator.SetBool("isDead", true);

        rb.simulated = false;

        //TODO disable particle systems
        //GetComponentInChildren<ParticleSystem>().emission.enabled = false;
        fireVFX.SetActive(false);

        //Disable Box Colliders
        GetComponent<BoxCollider2D>().enabled = false;

        //Disable any capsule collders
        GetComponent<CapsuleCollider2D>().enabled = false;

        //Destroy Parent object over time
        destroyOverTime.isOn = true;

        //Disable this Enemy Script component
        this.enabled = false;
    }
}
