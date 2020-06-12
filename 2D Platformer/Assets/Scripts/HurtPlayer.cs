using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    //Components
    private LevelManager theLevelManager;
    //public Animator animator;
    public PlayerMovement thePlayer;

    public int damageToGive;


    // Start is called before the first frame update
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        thePlayer = FindObjectOfType<PlayerMovement>();
        //animator = FindObjectOfType<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //For Spider Collision
    /*private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider)
        {
            //theLevelManager.Respawn();
            Debug.Log("Collision detected");
            theLevelManager.HurtPlayer(damageToGive);
            thePlayer.animator.SetTrigger("isHurt");
            thePlayer.Knockback();
        }
    }*/

    //Original Enemy collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //theLevelManager.Respawn();
            //Debug.Log("Collision detected");
            theLevelManager.HurtPlayer(damageToGive);
            thePlayer.animator.SetTrigger("isHurt");
            thePlayer.Knockback();
        }
    }
}
