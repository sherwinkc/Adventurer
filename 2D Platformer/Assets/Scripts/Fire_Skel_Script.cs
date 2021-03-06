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

    public Transform squibTransform;
    public GameObject deathSplosion, squib;
    public GameObject swordSwipeVFX;
    public GameObject orbsOnDeath;

    //public GameObject fireVFX;

    public int maxHealth;
    public int currentHealth;

    //Audio
    public AudioSource enemyGrunt1, bloodSquelch, dead;

    void Awake()
    {
        animator = GetComponent<Animator>();
        destroyOverTime = GetComponentInParent<DestroyOverTime>();
        rb = GetComponent<Rigidbody2D>();
        fire_Skel_Controller = GetComponent<Fire_Skel_Controller>();
        playerCombat = FindObjectOfType<PlayerCombat>();
        upgrades = FindObjectOfType<Upgrades>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        //fireVFX.gameObject.SetActive(true);
    }

    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Instantiate(swordSwipeVFX, squibTransform.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360))); //Instantiate Swipe VFX 

        if (currentHealth >= 0)
        {
            animator.SetTrigger("Hurt");
            Instantiate(squib, squibTransform.transform.position, squibTransform.transform.rotation);
        }

        if (enemyGrunt1 != null)
        {
            enemyGrunt1.pitch = Random.Range(0.95f, 1.05f);
            enemyGrunt1.Play();
        }

        bloodSquelch.pitch = Random.Range(0.95f, 1.05f);
        bloodSquelch.Play();

        if (currentHealth <= 0)
        {
            fire_Skel_Controller.idle.Stop();
            dead.Play();
            Instantiate(deathSplosion, squibTransform.transform.position, squibTransform.transform.rotation);

            for (int i = 0; i < Random.Range(2f, 6f); i++)
            {
                Instantiate(orbsOnDeath, new Vector2(squibTransform.transform.position.x, squibTransform.transform.position.y), squibTransform.transform.rotation);
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

        //fireVFX.gameObject.SetActive(false);

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
