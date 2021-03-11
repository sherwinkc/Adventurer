using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sludge_Script : MonoBehaviour
{
    //Components
    public Animator animator;
    public PlayerCombat playerCombat;
    public Rigidbody2D rb;
    public Sludge_Controller sludgeController;

    public Transform squibTransform;
    public GameObject squib;
    public GameObject swordSwipeVFX;

    public GameObject deathSplosion;
    public GameObject orbsOnDeath;
    public DestroyOverTime destroyOverTime;
    public Upgrades upgrades; //kills add to super amount

    public int maxHealth;
    public int currentHealth;

    //Audio
    public AudioSource grunt;

    void Awake()
    {
        //Get Components
        animator = GetComponent<Animator>();
        destroyOverTime = GetComponentInParent<DestroyOverTime>();
        rb = GetComponent<Rigidbody2D>();
        sludgeController = GetComponent<Sludge_Controller>();

        playerCombat = FindObjectOfType<PlayerCombat>();
        upgrades = FindObjectOfType<Upgrades>();
    }

    void Start()
    {
        //set currentHealth to max health
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Instantiate(swordSwipeVFX, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));

        if (currentHealth >= 0)
        {
            animator.SetTrigger("Hurt");
            Instantiate(squib, squibTransform.transform.position, squibTransform.transform.rotation);
        }

        if (currentHealth <= 0)
        {
            sludgeController.idle.Stop();
            Die();

            Instantiate(deathSplosion, squibTransform.transform.position, squibTransform.transform.rotation);

            for (int i = 0; i < Random.Range(2f, 4f); i++)
            {
                Instantiate(orbsOnDeath, new Vector2(squibTransform.transform.position.x, squibTransform.transform.position.y + 1), squibTransform.transform.rotation);
            }

            playerCombat.superAmount += upgrades.superAmountReturned; // returns the upgraded amount of super energy
        }

        //SFX        
        if (grunt != null)
        {
            grunt.pitch = Random.Range(0.95f, 1.05f);
            grunt.Play();
        }
    }

    void Die()
    {
        animator.SetBool("isDead", true);

        //Disable Rigidbody
        rb.simulated = false;

        //Disable Circle Collider
        GetComponent<CircleCollider2D>().enabled = false;

        //Disable this Spider_Script component
        this.enabled = false;

        //Destroy Parent object over time
        destroyOverTime.isOn = true;
    }
}
