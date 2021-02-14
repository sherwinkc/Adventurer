using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    //Components
    private LevelManager theLevelManager;
    public PlayerMovement thePlayer;

    public int damageToGive;

    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        thePlayer = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        
    }

    //Original Enemy collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //theLevelManager.Respawn();
            theLevelManager.HurtPlayer(damageToGive);
            thePlayer.animator.SetTrigger("isHurt");
            thePlayer.Knockback();
        }
    }
}
