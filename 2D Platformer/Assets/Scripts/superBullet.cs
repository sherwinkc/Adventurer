using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superBullet : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;
    public Enemy enemy;

    //Attack
    public int attackDamage = 200;

    // Start is called before the first frame update
    void Start()
    {
        playerCombat = FindObjectOfType<PlayerCombat>();
        rb.velocity = transform.right * speed;        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 1, playerCombat.enemyLayers);

        //damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            //Debug.Log("We hit " + enemy.name);
            //Checking if the enemy script is on the same object as the enemy or the hitBox
            if (enemy.GetComponentInParent<Enemy>() != null)
            {
                enemy.GetComponentInParent<Enemy>().TakeDamage(attackDamage);
            }
            else if (enemy.GetComponent<Enemy>() != null)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
