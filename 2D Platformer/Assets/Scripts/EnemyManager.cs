using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform radiusOrigin;
    public float range;
    public LayerMask enemyLayers;

    public bool isLockedDoorActive = false;

    // Start is called before the first frame update
    void Start()
    {
        radiusOrigin = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectEnemiesWithinRadius();
    }

    public void DetectEnemiesWithinRadius()
    {
        //detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(radiusOrigin.position, range, enemyLayers);

        //damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);

            if (enemy.GetComponent<Bird_Controller>() != null)
            {
                enemy.GetComponent<Bird_Controller>().canMoveAndAttack = false;
            }
            else
            {
                enemy.GetComponent<Bird_Controller>().canMoveAndAttack = true;
            }

            /*//Checking if the enemy script is on the same object as the enemy or the hitBox
            if (enemy.GetComponentInParent<Enemy>() != null)
            {
                enemy.GetComponentInParent<Enemy>().TakeDamage(attackDamage);
                StartCoroutine(SlowTimeCo());
            }
            else if (enemy.GetComponent<Enemy>() != null)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                StartCoroutine(SlowTimeCo());
            }
            //Check if we hit spider script
            else if (enemy.GetComponentInParent<Spider_Script>() != null)
            {
                enemy.GetComponentInParent<Spider_Script>().TakeDamage(attackDamage);
                StartCoroutine(SlowTimeCo());
            }
            else if (enemy.GetComponent<ShieldGuard>() != null)
            {
                enemy.GetComponent<ShieldGuard>().InstantBlockVFX();
                StartCoroutine(SlowTimeCo());
            }
            else if (enemy.GetComponentInParent<Fire_Skel_Script>() != null)
            {
                enemy.GetComponentInParent<Fire_Skel_Script>().TakeDamage(attackDamage);
                StartCoroutine(SlowTimeCo());
            }
            else if (enemy.GetComponentInParent<Sludge_Script>() != null)
            {
                enemy.GetComponentInParent<Sludge_Script>().TakeDamage(attackDamage);
                StartCoroutine(SlowTimeCo());
            }
            else if (enemy.GetComponentInParent<Bird_Script>() != null)
            {
                enemy.GetComponentInParent<Bird_Script>().TakeDamage(attackDamage);
                StartCoroutine(SlowTimeCo());
            }
            else if (enemy.GetComponentInParent<Scarecrow_Script>() != null)
            {
                enemy.GetComponentInParent<Scarecrow_Script>().TakeDamage(attackDamage);
                StartCoroutine(SlowTimeCo());
            }
            else if (enemy.GetComponentInParent<Skel_King_Script>() != null)
            {
                enemy.GetComponentInParent<Skel_King_Script>().TakeDamage(attackDamage);
                StartCoroutine(SlowTimeCo());
            }*/
        }
    }

    void OnDrawGizmosSelected()
    {
        //returns null if there is not sphere. Prevents errors
        if (radiusOrigin == null)
            return;

        Gizmos.DrawWireSphere(radiusOrigin.position, range);
    }

    private void OnTriggerExit2D(Collider2D enemy)
    {
        /*if (enemy.GetComponent<Bird_Controller>() != null)
        {
            enemy.GetComponent<Bird_Controller>().canMoveAndAttack = true;
        }*/
    }
}
