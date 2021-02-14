using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DetectBirds : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public AIPath aiPath;

    public LayerMask birdLayer;
    public float detectRange;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        aiPath = GetComponentInParent<AIPath>();
    }

    void Update()
    {
        DetectOtherBirds();
    }

    void DetectOtherBirds()
    {
        Collider2D[] otherBirds = Physics2D.OverlapCircleAll(transform.position, detectRange, birdLayer);

        foreach (Collider2D enemy in otherBirds)
        {
            //Debug.Log("We hit " + enemy.name);

            if(Vector2.Distance(enemy.transform.position, playerMovement.transform.position) < (Vector2.Distance(transform.position, playerMovement.transform.position)))
            {
                aiPath.maxSpeed = aiPath.maxSpeed / 4f;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}
