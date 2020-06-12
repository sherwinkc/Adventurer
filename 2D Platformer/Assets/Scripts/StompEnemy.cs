using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompEnemy : MonoBehaviour
{
    //for the bounce up after bouncing on enemy
    private Rigidbody2D playerRigidboy;
    public float bounceForce;

    public GameObject deathSplosion;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidboy = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            //Instead of destroying the object we are setting it to inactive
            //Destroy(gameObject);
            other.gameObject.SetActive(false);

            Instantiate(deathSplosion, other.transform.position, other.transform.rotation);

            playerRigidboy.velocity = new Vector3(playerRigidboy.velocity.x, bounceForce, 0f);
        }
    }
}
