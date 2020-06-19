using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Upgrades : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;
    public LevelManager levelManager;

    public AudioSource upgradeSFX; 

    //public Button button;

    //jump
    public bool doubleJumpUnlocked;

    //upgrades
    public float moveUpgradeDefault, moveUpgradeT1, moveUpgradeT2, moveUpgradeT3;
    public float jumpUpgradeDefault, jumpUpgradeT1, jumpUpgradeT2, jumpUpgradeT3;
    public float dashSpeedUpgradeDefault, dashSpeedUpgradeT1, dashSpeedUpgradeT2, dashSpeedUpgradeT3;
    public float dashCooldownUpgradeDefault, dashCooldownUpgradeT1, dashCooldownUpgradeT2, dashCooldownUpgradeT3;
    public int attackDamageUpgradeDefault, attackDamageT1, attackDamageT2, attackDamageT3, attackDamageT4, attackDamageT5;
    public float attackTimeUpgradeDefault, attackTimeT1, attackTimeT2, attackTimeT3;
    public float attackRangeUpgradeDefault, attackRangeT1, attackRangeT2, attackRangeT3;
    public float superRechargeRateDefault, superRechargeT1, superRechargeT2, superRechargeT3;
    public float superAmountReturned, superAmountReturnedDefault, superAmountReturnedT1, superAmountReturnedT2, superAmountReturnedT3;

    // Start is called before the first frame update

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerCombat = GetComponent<PlayerCombat>();
        levelManager = FindObjectOfType<LevelManager>();

        //delete existing player prefs in the first level
        if (SceneManager.GetActiveScene().name == "Level1_1")
        {
            Debug.Log("Deleting existing player prefs");
            PlayerPrefs.DeleteAll();
        }

        //movement
        if (PlayerPrefs.HasKey("PlayerMoveSpeed"))
        {
            Debug.Log("Setting Player Move from player pref");
            playerMovement.moveSpeed = PlayerPrefs.GetFloat("PlayerMoveSpeed");
        }
        else
        {
            moveUpgradeDefault = 5f;
            playerMovement.moveSpeed = moveUpgradeDefault;
            Debug.Log("Setting Player Move from default");
        }
            
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
        dashCooldownUpgradeT3 = dashCooldownUpgradeDefault * 0.2f;

        //Attack Damage
        attackDamageUpgradeDefault = 40;
        attackDamageT1 = attackDamageUpgradeDefault + 10;
        attackDamageT2 = attackDamageUpgradeDefault + 20;
        attackDamageT3 = attackDamageUpgradeDefault + 30;
        attackDamageT4 = attackDamageUpgradeDefault + 40;
        attackDamageT5 = attackDamageUpgradeDefault + 50;

        //attack time
        attackTimeUpgradeDefault = 1.75f;
        attackTimeT1 = attackTimeUpgradeDefault * 1.25f;
        attackTimeT2 = attackTimeUpgradeDefault * 1.5f;
        attackTimeT3 = attackTimeUpgradeDefault * 1.75f;

        //attack range
        attackRangeUpgradeDefault = 0.8f;
        attackRangeT1 = attackRangeUpgradeDefault * 1.1f;
        attackRangeT2 = attackRangeUpgradeDefault * 1.2f;
        attackRangeT3 = attackRangeUpgradeDefault * 1.3f;

        //Super recharge
        superRechargeRateDefault = 0.5f;
        superRechargeT1 = superRechargeRateDefault * 1.5f;
        superRechargeT2 = superRechargeRateDefault * 2f;
        superRechargeT3 = superRechargeRateDefault * 3f;

        //Super Amount returned
        superAmountReturnedDefault = 10f;
        superAmountReturnedT1 = superAmountReturnedDefault * 1.25f;
        superAmountReturnedT2 = superAmountReturnedDefault * 1.5f;
        superAmountReturnedT3 = superAmountReturnedDefault * 1.8f;
    }

    void Start()
    {
        //jump
        playerMovement.jumpSpeed = jumpUpgradeDefault; //10 Default

        //canDoubleJump
        doubleJumpUnlocked = false;

        //movement
        /*if (PlayerPrefs.HasKey("PlayerMoveSpeed"))
        {
            playerMovement.moveSpeed = PlayerPrefs.GetInt("PlayerMoveSpeed");
        } 
        else
        {
            playerMovement.moveSpeed = moveUpgradeDefault; // 5f Default
        }*/

        //dash
        playerMovement.dashSpeed = dashSpeedUpgradeDefault; //11 Default
        playerMovement.dashCooldownAmount = dashCooldownUpgradeDefault; //3 default
        //playerMovement.dashCounter; // 1.5 default

        //attack
        playerCombat.attackRange = attackRangeUpgradeDefault; //0.8 default
        playerCombat.attackDamage = attackDamageUpgradeDefault; //40 default
        playerCombat.attackRate = attackTimeUpgradeDefault; //1.75 default // the higher the quicker between attacks
        //playerCombat.nextAttackTime;

        //super
        playerCombat.superAmount = 0;
        playerCombat.superRechargeRate = superRechargeRateDefault;

        //amount of super energy returned from killing enemies
        superAmountReturned = superAmountReturnedDefault;

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

    public void DeductSkillPointsAndAudio()
    {
        levelManager.skillPoints -= 1;
        PlayUpgradeSound();
    }

    public void PlayUpgradeSound()
    {
        upgradeSFX.Play();
    }

    public void UnlockDoubleJump()
    {
        if (levelManager.skillPoints >= 1)
        {
            doubleJumpUnlocked = true;
            DeductSkillPointsAndAudio();
        }
    }

    public void UnlockNextMovementSpeed()
    {
        if (levelManager.skillPoints >= 1 && playerMovement.moveSpeed == moveUpgradeDefault)
        {
            playerMovement.moveSpeed = moveUpgradeT1;
            DeductSkillPointsAndAudio();
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.moveSpeed == moveUpgradeT1)
        {
            playerMovement.moveSpeed = moveUpgradeT2;
            DeductSkillPointsAndAudio();
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.moveSpeed == moveUpgradeT2)
        {
            playerMovement.moveSpeed = moveUpgradeT3;
            DeductSkillPointsAndAudio();
        }
    }

    public void UnlockNextJumpSpeed()
    {
        if (levelManager.skillPoints >= 1 && playerMovement.jumpSpeed == jumpUpgradeDefault)
        {
            playerMovement.jumpSpeed = jumpUpgradeT1;
            DeductSkillPointsAndAudio();
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.jumpSpeed == jumpUpgradeT1)
        {
            playerMovement.jumpSpeed = jumpUpgradeT2;
            DeductSkillPointsAndAudio();
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.jumpSpeed == jumpUpgradeT2)
        {
            playerMovement.jumpSpeed = jumpUpgradeT3;
            DeductSkillPointsAndAudio();
        }
    }

    public void UnlockNextDashSpeed()
    {
        if (levelManager.skillPoints >= 1 && playerMovement.dashSpeed == dashSpeedUpgradeDefault)
        {
            playerMovement.dashSpeed = dashSpeedUpgradeT1;
            DeductSkillPointsAndAudio();
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.dashSpeed == dashSpeedUpgradeT1)
        {
            playerMovement.dashSpeed = dashSpeedUpgradeT2;
            DeductSkillPointsAndAudio();
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.dashSpeed == dashSpeedUpgradeT2)
        {
            playerMovement.dashSpeed = dashSpeedUpgradeT3;
            DeductSkillPointsAndAudio();
        }
    }

    public void UnlockNextDashCooldown()
    {
        if (levelManager.skillPoints >= 1 && playerMovement.dashCooldownAmount == dashCooldownUpgradeDefault)
        {
            playerMovement.dashCooldownAmount = dashCooldownUpgradeT1;
            playerMovement.dashCounter = dashCooldownUpgradeT1;
            DeductSkillPointsAndAudio();
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.dashCooldownAmount == dashCooldownUpgradeT1)
        {
            playerMovement.dashCooldownAmount = dashCooldownUpgradeT2;
            playerMovement.dashCounter = dashCooldownUpgradeT2;
            DeductSkillPointsAndAudio();
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.dashCooldownAmount == dashCooldownUpgradeT2)
        {
            playerMovement.dashCooldownAmount = dashCooldownUpgradeT3;
            playerMovement.dashCounter = dashCooldownUpgradeT3;
            DeductSkillPointsAndAudio();
        }
    }

    public void UnlockNextAttackDamage()
    {
        if (levelManager.skillPoints >= 1 && playerCombat.attackDamage == attackDamageUpgradeDefault)
        {
            playerCombat.attackDamage = attackDamageT1;
            DeductSkillPointsAndAudio();
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.attackDamage == attackDamageT1)
        {
            playerCombat.attackDamage = attackDamageT2;
            DeductSkillPointsAndAudio();
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.attackDamage == attackDamageT2)
        {
            playerCombat.attackDamage = attackDamageT3;
            DeductSkillPointsAndAudio();
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.attackDamage == attackDamageT3)
        {
            playerCombat.attackDamage = attackDamageT4;
            DeductSkillPointsAndAudio();
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.attackDamage == attackDamageT4)
        {
            playerCombat.attackDamage = attackDamageT5;
            DeductSkillPointsAndAudio();
        }
    }

    public void UnlockNextAttackTime()
    {
        if (levelManager.skillPoints >= 1 && playerCombat.attackRate == attackTimeUpgradeDefault)
        {
            playerCombat.attackRate = attackTimeT1;
            DeductSkillPointsAndAudio();
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.attackRate == attackTimeT1)
        {
            playerCombat.attackRate = attackTimeT2;
            DeductSkillPointsAndAudio();
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.attackRate == attackTimeT2)
        {
            playerCombat.attackRate = attackTimeT3;
            DeductSkillPointsAndAudio();
        }
    }

    public void UnlockNextAttackRange()
    {
        if (levelManager.skillPoints >= 1 && playerCombat.attackRange == attackRangeUpgradeDefault)
        {
            playerCombat.attackRange = attackRangeT1;
            DeductSkillPointsAndAudio();
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.attackRange == attackRangeT1)
        {
            playerCombat.attackRange = attackRangeT2;
            DeductSkillPointsAndAudio();
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.attackRange == attackRangeT2)
        {
            playerCombat.attackRange = attackRangeT3;
            DeductSkillPointsAndAudio();
        }
    }

    public void UnlockNextSuperRechargeRate()
    {
        if (levelManager.skillPoints >= 1 && playerCombat.superRechargeRate == superRechargeRateDefault)
        {
            playerCombat.superRechargeRate = superRechargeT1;
            DeductSkillPointsAndAudio();
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.superRechargeRate == superRechargeT1)
        {
            playerCombat.superRechargeRate = superRechargeT2;
            DeductSkillPointsAndAudio();
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.superRechargeRate == superRechargeT2)
        {
            playerCombat.superRechargeRate = superRechargeT3;
            DeductSkillPointsAndAudio();
        }
    }

    public void UnlockNextSuperReturnedValue()
    {
        if (levelManager.skillPoints >= 1 && superAmountReturned == superAmountReturnedDefault)
        {
            superAmountReturned = superAmountReturnedT1;
            DeductSkillPointsAndAudio();
        }
        else if (levelManager.skillPoints >= 1 && superAmountReturned == superAmountReturnedT1)
        {
            superAmountReturned = superAmountReturnedT2;
            DeductSkillPointsAndAudio();
        }
        else if (levelManager.skillPoints >= 1 && superAmountReturned == superAmountReturnedT2)
        {
            superAmountReturned = superAmountReturnedT3;
            DeductSkillPointsAndAudio();
        }
    }
}
