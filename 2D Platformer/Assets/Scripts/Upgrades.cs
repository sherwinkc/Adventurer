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

    //upgrades
    public float moveUpgradeDefault, moveUpgradeT1, moveUpgradeT2, moveUpgradeT3;
    public float jumpUpgradeDefault, jumpUpgradeT1, jumpUpgradeT2, jumpUpgradeT3;
    public float dashSpeedUpgradeDefault, dashSpeedUpgradeT1, dashSpeedUpgradeT2, dashSpeedUpgradeT3;
    public float dashCooldownUpgradeDefault, dashCooldownUpgradeT1, dashCooldownUpgradeT2, dashCooldownUpgradeT3;


    public float superAmountReturned;

    // Start is called before the first frame update

    private void Awake()
    {
        //movement
        moveUpgradeDefault = 5f;
        moveUpgradeT1 = moveUpgradeDefault * 1.1f;
        moveUpgradeT2 = moveUpgradeDefault * 1.2f;
        moveUpgradeT3 = moveUpgradeDefault * 1.3f;

        //jump
        jumpUpgradeDefault = 10f;
        jumpUpgradeT1 = jumpUpgradeDefault * 1.05f;
        jumpUpgradeT2 = jumpUpgradeDefault * 1.1f;
        jumpUpgradeT3 = jumpUpgradeDefault * 1.15f;

        //dash speed
        dashSpeedUpgradeDefault = 11f;
        dashSpeedUpgradeT1 = dashSpeedUpgradeDefault * 1.1f;
        dashSpeedUpgradeT2 = dashSpeedUpgradeDefault * 1.2f;
        dashSpeedUpgradeT3 = dashSpeedUpgradeDefault * 1.3f;

        //dash cooldown
        dashCooldownUpgradeDefault = 3f;
        dashCooldownUpgradeT1 = dashCooldownUpgradeDefault * 0.8f;
        dashCooldownUpgradeT2 = dashCooldownUpgradeDefault * 0.5f;
        dashCooldownUpgradeT3 = dashCooldownUpgradeDefault * 0.33f;
    }

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerCombat = GetComponent<PlayerCombat>();
        levelManager = FindObjectOfType<LevelManager>();

        //jump
        playerMovement.jumpSpeed = jumpUpgradeDefault; //10 Default

        //canDoubleJump
        doubleJumpUnlocked = false;

        //movement
        playerMovement.moveSpeed = moveUpgradeDefault; // 5f Default

        //dash
        playerMovement.dashSpeed = dashSpeedUpgradeDefault; //11 Default
        playerMovement.dashCooldownAmount = dashCooldownUpgradeDefault; //3 default
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
        if (levelManager.skillPoints >= 1)
        {
            doubleJumpUnlocked = true;
            levelManager.skillPoints -= 1;
        }
    }

    public void UnlockNextMovementSpeed()
    {
        if (levelManager.skillPoints >= 1 && playerMovement.moveSpeed == moveUpgradeDefault)
        {
            playerMovement.moveSpeed = moveUpgradeT1;
            levelManager.skillPoints -= 1;
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.moveSpeed == moveUpgradeT1)
        {
            playerMovement.moveSpeed = moveUpgradeT2;
            levelManager.skillPoints -= 1;
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.moveSpeed == moveUpgradeT2)
        {
            playerMovement.moveSpeed = moveUpgradeT3;
            levelManager.skillPoints -= 1;
        }
    }

    public void UnlockNextJumpSpeed()
    {
        if (levelManager.skillPoints >= 1 && playerMovement.jumpSpeed == jumpUpgradeDefault)
        {
            playerMovement.jumpSpeed = jumpUpgradeT1;
            levelManager.skillPoints -= 1;
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.jumpSpeed == jumpUpgradeT1)
        {
            playerMovement.jumpSpeed = jumpUpgradeT2;
            levelManager.skillPoints -= 1;
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.jumpSpeed == jumpUpgradeT2)
        {
            playerMovement.jumpSpeed = jumpUpgradeT3;
            levelManager.skillPoints -= 1;
        }
    }

    public void UnlockNextDashSpeed()
    {
        if (levelManager.skillPoints >= 1 && playerMovement.dashSpeed == dashSpeedUpgradeDefault)
        {
            playerMovement.dashSpeed = dashSpeedUpgradeT1;
            levelManager.skillPoints -= 1;
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.dashSpeed == dashSpeedUpgradeT1)
        {
            playerMovement.dashSpeed = dashSpeedUpgradeT2;
            levelManager.skillPoints -= 1;
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.dashSpeed == dashSpeedUpgradeT2)
        {
            playerMovement.dashSpeed = dashSpeedUpgradeT3;
            levelManager.skillPoints -= 1;
        }
    }

    public void UnlockNextDashCooldown()
    {
        if (levelManager.skillPoints >= 1 && playerMovement.dashCooldownAmount == dashCooldownUpgradeDefault)
        {
            playerMovement.dashCooldownAmount = dashCooldownUpgradeT1;
            playerMovement.dashCounter = dashCooldownUpgradeT1;
            levelManager.skillPoints -= 1;
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.dashCooldownAmount == dashCooldownUpgradeT1)
        {
            playerMovement.dashCooldownAmount = dashCooldownUpgradeT2;
            playerMovement.dashCounter = dashCooldownUpgradeT2;
            levelManager.skillPoints -= 1;
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.dashCooldownAmount == dashCooldownUpgradeT3)
        {
            playerMovement.dashCooldownAmount = dashCooldownUpgradeT3;
            playerMovement.dashCounter = dashCooldownUpgradeT3;
            levelManager.skillPoints -= 1;
        }
    }

}
