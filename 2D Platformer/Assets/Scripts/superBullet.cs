using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superBullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public PlayerCombat playerCombat;

    //Attack
    public int attackDamage;

    public AudioSource superSFX1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCombat = FindObjectOfType<PlayerCombat>();
        rb.velocity = transform.right * speed;

        superSFX1.Play();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, (float)2.5f, playerCombat.enemyLayers);

        //damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            //Debug.Log("We hit " + enemy.name);

            if (enemy.GetComponentInParent<Enemy>() != null)
            {
                enemy.GetComponentInParent<Enemy>().TakeDamage(attackDamage);
                //StartCoroutine(SlowTimeCo());
            }
            else if (enemy.GetComponent<Enemy>() != null)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                //StartCoroutine(SlowTimeCo());
            }
            //Check if we hit spider script
            else if (enemy.GetComponentInParent<Spider_Script>() != null)
            {
                enemy.GetComponentInParent<Spider_Script>().TakeDamage(attackDamage);
                //StartCoroutine(SlowTimeCo());
            }
            else if (enemy.GetComponentInParent<Fire_Skel_Script>() != null)
            {
                enemy.GetComponentInParent<Fire_Skel_Script>().TakeDamage(attackDamage);
                //StartCoroutine(SlowTimeCo());
            }
            else if (enemy.GetComponentInParent<Sludge_Script>() != null)
            {
                enemy.GetComponentInParent<Sludge_Script>().TakeDamage(attackDamage);
            }
            else if (enemy.GetComponentInParent<Bird_Script>() != null)
            {
                enemy.GetComponent<CircleCollider2D>().enabled = false;
                enemy.GetComponentInParent<CircleCollider2D>().enabled = false;
                enemy.GetComponentInParent<Bird_Script>().TakeDamage(attackDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, (float)2.5f);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
