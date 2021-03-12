using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skel_King_Script : MonoBehaviour
{
    //Components
    public Skel_King_Controller skel_King_Controller;
    public Animator animator;
    public PlayerCombat playerCombat;
    public DestroyOverTime destroyOverTime;
    public Upgrades upgrades;
    public Rigidbody2D rb;

    public Transform squibTransform;
    public GameObject deathSplosion, squib;
    public GameObject swordSwipeVFX;
    public GameObject orbsOnDeath;

    public ForceFieldScript forceFieldScript;

    //public GameObject fireVFX;

    public int maxHealth;
    public int currentHealth;

    //Audio
    public AudioSource grunt, squelch, dead, loopingGrunt;

    void Awake()
    {
        animator = GetComponent<Animator>();
        destroyOverTime = GetComponent<DestroyOverTime>();
        playerCombat = FindObjectOfType<PlayerCombat>();
        upgrades = FindObjectOfType<Upgrades>();
        rb = GetComponent<Rigidbody2D>();
        skel_King_Controller = GetComponent<Skel_King_Controller>();

        skel_King_Controller.ebCollider.SetActive(true);
        skel_King_Controller.forceField.SetActive(true);
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Instantiate(swordSwipeVFX, squibTransform.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));

        if (currentHealth >= 0)
        {
            animator.SetTrigger("Hurt");
            Instantiate(squib, squibTransform.transform.position, squibTransform.transform.rotation);
        }

        if (currentHealth <= 0)
        {
            skel_King_Controller.ebCollider.SetActive(false);
            skel_King_Controller.forceField.SetActive(false);
            dead.Play();
            Instantiate(deathSplosion, squibTransform.transform.position, squibTransform.transform.rotation);

            for (int i = 0; i < Random.Range(10f, 20f); i++)
            {
                Instantiate(orbsOnDeath, new Vector2(squibTransform.transform.position.x, squibTransform.transform.position.y), squibTransform.transform.rotation);
            }

            Die();
            playerCombat.superAmount += upgrades.superAmountReturned;
        }

        if (grunt != null)
        {
            grunt.pitch = (Random.Range(0.9f, 1.1f));
            grunt.Play();
        }

        if(squelch != null)
        {
            squelch.pitch = (Random.Range(0.9f, 1.1f));
            squelch.Play();
        }
    }

    void Die()
    {
        animator.SetTrigger("isDead");
        loopingGrunt.Stop();

        //skel_King_Controller.forceField.SetActive(false); // this is disabling the prefab??? WTF
        forceFieldScript = FindObjectOfType<ForceFieldScript>();
        if(forceFieldScript != null)
        {
            forceFieldScript.isOn = true;
        }

        skel_King_Controller.canMove = false;

        rb.simulated = false;

        //Disable Box Colliders
        GetComponentInChildren<BoxCollider2D>().enabled = false;

        //Disable any capsule collders
        GetComponent<CapsuleCollider2D>().enabled = false;

        //Destroy Parent object over time
        destroyOverTime.isOn = true;

        //Disable this Enemy Script component
        this.enabled = false;
    }
}
