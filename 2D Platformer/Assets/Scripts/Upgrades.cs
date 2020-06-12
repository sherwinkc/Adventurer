using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;
    public LevelManager levelManager;

    //public Button button;

    //jump
    public bool doubleJumpUnlocked;

    //movement


    public float superAmountReturned;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerCombat = GetComponent<PlayerCombat>();
        levelManager = FindObjectOfType<LevelManager>();

        //jump
        playerMovement.jumpSpeed = 10f; //10 Default

        //canDoubleJump
        doubleJumpUnlocked = false;

        //movement
        playerMovement.moveSpeed = 5f; // 5 Default

        //dash
        playerMovement.dashSpeed = 12f; //12 Default
        playerMovement.dashCooldownAmount = 3f;
        //playerMovement.dashCounter; // 1.5 default

        //attack
        playerCombat.attackRange = 0.8f; //0.8 default
        playerCombat.attackDamage = 40; //45 default
        playerCombat.attackRate = 1.75f; //2.75 default // the higher the quicker between attacks
        //playerCombat.nextAttackTime;

        //super
        playerCombat.superAmount = 0;
        playerCombat.superRechargeRate = 0.5f;

        //amount of super energy returned from killing enemies
        superAmountReturned = 10f;

        //stamina
        playerCombat.staminaMax = 100f;
        playerCombat.staminaRechargeRate = 15f;
        playerCombat.currentStamina = playerCombat.staminaMax;
        playerCombat.attackCost = 20f;

        playerMovement.jumpCost = 20f;
        playerMovement.rollCost = 10f;

        //Distance which orbs are drawn to the player??
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UnlockDoubleJump()
    {
        if(levelManager.skillPoints >= 1)
        {
            doubleJumpUnlocked = true;
            levelManager.skillPoints -= 1;      
        }        
    }

    public void UnlockMovementSpeedT1()
    {
        if (levelManager.skillPoints >= 1)
        {
            playerMovement.moveSpeed = 5.5f;
            levelManager.skillPoints -= 1;
        }
    }

    public void UnlockMovementSpeedT2()
    {
        if (levelManager.skillPoints >= 1)
        {
            playerMovement.moveSpeed = 6f;
            levelManager.skillPoints -= 1;
        }
    }

    public void UnlockMovementSpeedT3()
    {
        if (levelManager.skillPoints >= 1)
        {
            playerMovement.moveSpeed = 6.5f;
            levelManager.skillPoints -= 1;
        }
    }
}
