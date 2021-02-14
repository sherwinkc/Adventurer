using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DetectBirds : MonoBehaviour
{
    public float detectRange;
    public LayerMask birdLayer;

    public PlayerMovement playerMovement;

    public AIPath aiPath;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        aiPath = GetComponentInParent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectOtherBirds();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

    }

    void DetectOtherBirds()
    {

        Collider2D[] otherBirds = Physics2D.OverlapCircleAll(transform.position, detectRange, birdLayer);

        foreach (Collider2D enemy in otherBirds)
        {
            Debug.Log("We hit " + enemy.name);

            if(Vector2.Distance(enemy.transform.position, playerMovement.transform.position) < (Vector2.Distance(transform.position, playerMovement.transform.position)))
            {
                aiPath.maxSpeed = aiPath.maxSpeed / 4f;
                Debug.Log("aiPath.maxSpeed :" + aiPath.maxSpeed);
            }
            


            /*if (enemy.GetComponentInParent<Enemy>() != null)
            {
                enemy.GetComponentInParent<Enemy>().TakeDamage(attackDamage);
                //StartCoroutine(SlowTimeCo());
            }*/

        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}
