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

    //jump
    public bool doubleJumpUnlocked;
    public int doubleJumpInt;

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

    public float staminaMaxUpgradeDefault, staminaMaxT1, staminaMaxT2, staminaMaxT3;
    public float staminaRechargeRateDefault, staminaRechargeRateT1, staminaRechargeRateT2, staminaRechargeRateT3;
    public float staminaAttackCostDefault, staminaAttackCostT1, staminaAttackCostT2, staminaAttackCostT3;
    public float staminaJumpCostDefault, staminaJumpCostT1, staminaJumpCostT2, staminaJumpCostT3;
    public float staminaDashCostDefault, staminaDashCostT1, staminaDashCostT2, staminaDashCostT3;

    public Text maxStamina, staminaRecharge, staminaAttackCost, staminaJumpCost, staminaDashCost, doubleJump, moveSpeed, jumpSpeed,
    dashSpeed, dashCool, attackDmg, attackRate, attackRange, superRecharge, superFromKills;

    //Audio
    public AudioSource upgradeSFX;

    private void Awake()
    {
        DeleteExistingPlayerPrefs(); // deletes player prefs if level1_1

        playerMovement = GetComponent<PlayerMovement>();
        playerCombat = GetComponent<PlayerCombat>();
        levelManager = FindObjectOfType<LevelManager>();

        //double jump unlocked 0 = false, 1 = true;
        doubleJumpUnlocked = false;

        //move
        moveUpgradeDefault = 5f;
        moveUpgradeT1 = moveUpgradeDefault * 1.025f;
        moveUpgradeT2 = moveUpgradeDefault * 1.050f;
        moveUpgradeT3 = moveUpgradeDefault * 1.075f;

        //jump
        jumpUpgradeDefault = 10f;
        jumpUpgradeT1 = jumpUpgradeDefault * 1.025f;
        jumpUpgradeT2 = jumpUpgradeDefault * 1.05f;
        jumpUpgradeT3 = jumpUpgradeDefault * 1.075f;

        //dash speed
        dashSpeedUpgradeDefault = 11f;
        dashSpeedUpgradeT1 = dashSpeedUpgradeDefault * 1.1f;
        dashSpeedUpgradeT2 = dashSpeedUpgradeDefault * 1.2f;
        dashSpeedUpgradeT3 = dashSpeedUpgradeDefault * 1.3f;

        //dash cooldown
        dashCooldownUpgradeDefault = 3f;
        dashCooldownUpgradeT1 = dashCooldownUpgradeDefault * 0.9f;
        dashCooldownUpgradeT2 = dashCooldownUpgradeDefault * 0.8f;
        dashCooldownUpgradeT3 = dashCooldownUpgradeDefault * 0.7f;

        //Attack Damage
        attackDamageUpgradeDefault = 40;
        attackDamageT1 = attackDamageUpgradeDefault + 10;
        attackDamageT2 = attackDamageUpgradeDefault + 20;
        attackDamageT3 = attackDamageUpgradeDefault + 30;
        attackDamageT4 = attackDamageUpgradeDefault + 40;
        attackDamageT5 = attackDamageUpgradeDefault + 50;

        //attack time // the higher the quicker between attacks
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
        superRechargeT3 = superRechargeRateDefault * 2.5f;

        //Super Amount returned
        superAmountReturnedDefault = 10f;
        superAmountReturned = superAmountReturnedDefault;
        superAmountReturnedT1 = superAmountReturnedDefault * 1.25f;
        superAmountReturnedT2 = superAmountReturnedDefault * 1.5f;
        superAmountReturnedT3 = superAmountReturnedDefault * 1.8f;

        //stamina max
        staminaMaxUpgradeDefault = 100f;
        staminaMaxT1 = staminaMaxUpgradeDefault * 1.25f;
        staminaMaxT2 = staminaMaxUpgradeDefault * 1.5f;
        staminaMaxT3 = staminaMaxUpgradeDefault * 1.75f;

        //stamina recharge rate
        staminaRechargeRateDefault = 14f; // Originally 10f
        staminaRechargeRateT1 = staminaRechargeRateDefault * 1.25f;
        staminaRechargeRateT2 = staminaRechargeRateDefault * 1.5f;
        staminaRechargeRateT3 = staminaRechargeRateDefault * 1.75f;

        //stamina attack cost
        staminaAttackCostDefault = 30f;
        staminaAttackCostT1 = staminaAttackCostDefault * 0.9f;
        staminaAttackCostT2 = staminaAttackCostDefault * 0.8f;
        staminaAttackCostT3 = staminaAttackCostDefault * 0.7f;

        //stamina jump cost
        staminaJumpCostDefault = 25f;
        staminaJumpCostT1 = staminaJumpCostDefault * 0.9f;
        staminaJumpCostT2 = staminaJumpCostDefault * 0.8f;
        staminaJumpCostT3 = staminaJumpCostDefault * 0.7f;

        //stamina dash cost
        staminaDashCostDefault = 20f;
        staminaDashCostT1 = staminaDashCostDefault * 0.8f;
        staminaDashCostT2 = staminaDashCostDefault * 0.7f;
        staminaDashCostT3 = staminaDashCostDefault * 0.6f;

        PlayerPrefsLoadingFunction();
    }

    void Start()
    {
        //super
        playerCombat.superAmount = 0;

        //stamina       
        playerCombat.currentStamina = playerCombat.staminaMax; // setting the bar full

        //set the upgrade UI
        SetUIAtLevelStart();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DeleteExistingPlayerPrefs()
    {
        //delete existing player prefs in the first level
        if (SceneManager.GetActiveScene().name == "Prologue" || SceneManager.GetActiveScene().name == "Level1_1")
        {
            PlayerPrefs.DeleteAll();
        }
    }

    void PlayerPrefsLoadingFunction()
    {
        //Double Jump check
        if (PlayerPrefs.HasKey("DoubleJump"))
        {
            if (PlayerPrefs.GetInt("DoubleJump") == 1)
            {
                doubleJumpUnlocked = true;
            }
        }
        else
        {
            PlayerPrefs.SetInt("DoubleJump", 0);
            doubleJumpUnlocked = false;
        }

        //movement
        if (PlayerPrefs.HasKey("PlayerMoveSpeed"))
        {
            playerMovement.moveSpeed = PlayerPrefs.GetFloat("PlayerMoveSpeed");
            //Debug.Log("Setting Player Move from player pref");
        }
        else
        {
            playerMovement.moveSpeed = moveUpgradeDefault;
            PlayerPrefs.SetFloat("PlayerMoveSpeed", playerMovement.moveSpeed);
            // Debug.Log("Setting Player Move from default");
        }

        //jump speed
        if (PlayerPrefs.HasKey("PlayerJumpSpeed"))
        {
            playerMovement.jumpSpeed = PlayerPrefs.GetFloat("PlayerJumpSpeed");
        }
        else
        {
            playerMovement.jumpSpeed = jumpUpgradeDefault; 
            PlayerPrefs.SetFloat("PlayerJumpSpeed", playerMovement.jumpSpeed);
        }

        //dash speed
        if (PlayerPrefs.HasKey("PlayerDashSpeed"))
        {
            playerMovement.dashSpeed = PlayerPrefs.GetFloat("PlayerDashSpeed");
        }
        else
        {
            playerMovement.dashSpeed = dashSpeedUpgradeDefault; //11 Default
            PlayerPrefs.SetFloat("PlayerDashSpeed", playerMovement.dashSpeed);
        }

        //dash cooldown
        if (PlayerPrefs.HasKey("PlayerDashCooldown"))
        {
            playerMovement.dashCooldownAmount = PlayerPrefs.GetFloat("PlayerDashCooldown");
        }
        else
        {
            playerMovement.dashCooldownAmount = dashCooldownUpgradeDefault; //3 default
            PlayerPrefs.SetFloat("PlayerDashCooldown", playerMovement.dashCooldownAmount);
        }

        //Attack Damage
        if (PlayerPrefs.HasKey("PlayerAttackDamage"))
        {
            playerCombat.attackDamage = PlayerPrefs.GetInt("PlayerAttackDamage");
        }
        else
        {
            playerCombat.attackDamage = attackDamageUpgradeDefault; //40 default   
            PlayerPrefs.SetInt("PlayerAttackDamage", playerCombat.attackDamage);
        }

        //attack time
        if (PlayerPrefs.HasKey("PlayerAttackTime"))
        {
            playerCombat.attackRate = PlayerPrefs.GetFloat("PlayerAttackTime");
        }
        else
        {
            playerCombat.attackRate = attackTimeUpgradeDefault; 
            PlayerPrefs.SetFloat("PlayerAttackTime", playerCombat.attackRate);
        }

        //attack range
        if (PlayerPrefs.HasKey("PlayerAttackRange"))
        {
            playerCombat.attackRange = PlayerPrefs.GetFloat("PlayerAttackRange");
        }
        else
        {
            playerCombat.attackRange = attackRangeUpgradeDefault; //0.8 default
            PlayerPrefs.SetFloat("PlayerAttackRange", playerCombat.attackRange);
        }

        //Super recharge
        if (PlayerPrefs.HasKey("PlayerSuperRecharge"))
        {
            playerCombat.superRechargeRate = PlayerPrefs.GetFloat("PlayerSuperRecharge");
        }
        else
        {
            playerCombat.superRechargeRate = superRechargeRateDefault;
            PlayerPrefs.SetFloat("PlayerSuperRecharge", playerCombat.superRechargeRate);
        }

        //Super Amount returned
        if (PlayerPrefs.HasKey("PlayerSuperReturned"))
        {
            superAmountReturned = PlayerPrefs.GetFloat("PlayerSuperReturned");
        }
        else
        {
            superAmountReturned = superAmountReturnedDefault; 
            PlayerPrefs.SetFloat("PlayerSuperReturned", superAmountReturned);
        }

        //stamina max
        if (PlayerPrefs.HasKey("StaminaMax"))
        {
            playerCombat.staminaMax = PlayerPrefs.GetFloat("StaminaMax");
        }
        else
        {
            playerCombat.staminaMax = staminaMaxUpgradeDefault;
            PlayerPrefs.SetFloat("StaminaMax", playerCombat.staminaMax);
        }

        //stamina recharge rate
        if (PlayerPrefs.HasKey("StaminaRechargeRate"))
        {
            playerCombat.staminaRechargeRate = PlayerPrefs.GetFloat("StaminaRechargeRate");
        }
        else
        {
            playerCombat.staminaRechargeRate = staminaRechargeRateDefault;
            PlayerPrefs.SetFloat("StaminaRechargeRate", playerCombat.staminaRechargeRate);
        }

        //stamina attack cost
        if (PlayerPrefs.HasKey("StaminaAttackCost"))
        {
            playerCombat.attackCost = PlayerPrefs.GetFloat("StaminaAttackCost");
        }
        else
        {
            playerCombat.attackCost = staminaAttackCostDefault;
            PlayerPrefs.SetFloat("StaminaAttackCost", playerCombat.attackCost);
        }

        //stamina jump cost
        if (PlayerPrefs.HasKey("StaminaJumpCost"))
        {
            playerMovement.jumpCost = PlayerPrefs.GetFloat("StaminaJumpCost");
        }
        else
        {
            playerMovement.jumpCost = staminaJumpCostDefault;
            PlayerPrefs.SetFloat("StaminaJumpCost", playerMovement.jumpCost);
        }

        //stamina dash cost
        if (PlayerPrefs.HasKey("StaminaDashCost"))
        {
            playerMovement.rollCost = PlayerPrefs.GetFloat("StaminaDashCost");
        }
        else
        {
            playerMovement.rollCost = staminaDashCostDefault;
            PlayerPrefs.SetFloat("StaminaDashCost", playerMovement.rollCost);
        }

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
        if (levelManager.skillPoints >= 1 && !doubleJumpUnlocked)
        {
            doubleJumpUnlocked = true;
            DeductSkillPointsAndAudio();
            PlayerPrefs.SetInt("DoubleJump", 1);
            doubleJump.text = "MAX";
        }
    }

    public void UnlockNextMovementSpeed()
    {
        if (levelManager.skillPoints >= 1 && playerMovement.moveSpeed == moveUpgradeDefault)
        {
            playerMovement.moveSpeed = moveUpgradeT1;
            DeductSkillPointsAndAudio();
            moveSpeed.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.moveSpeed == moveUpgradeT1)
        {
            playerMovement.moveSpeed = moveUpgradeT2;
            DeductSkillPointsAndAudio();
            moveSpeed.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.moveSpeed == moveUpgradeT2)
        {
            playerMovement.moveSpeed = moveUpgradeT3;
            DeductSkillPointsAndAudio();
            moveSpeed.text = "MAX";
        }
    }

    public void UnlockNextJumpSpeed()
    {
        if (levelManager.skillPoints >= 1 && playerMovement.jumpSpeed == jumpUpgradeDefault)
        {
            playerMovement.jumpSpeed = jumpUpgradeT1;
            DeductSkillPointsAndAudio();
            jumpSpeed.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.jumpSpeed == jumpUpgradeT1)
        {
            playerMovement.jumpSpeed = jumpUpgradeT2;
            DeductSkillPointsAndAudio();
            jumpSpeed.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.jumpSpeed == jumpUpgradeT2)
        {
            playerMovement.jumpSpeed = jumpUpgradeT3;
            DeductSkillPointsAndAudio();
            jumpSpeed.text = "MAX";
        }
    }

    public void UnlockNextDashSpeed()
    {
        if (levelManager.skillPoints >= 1 && playerMovement.dashSpeed == dashSpeedUpgradeDefault)
        {
            playerMovement.dashSpeed = dashSpeedUpgradeT1;
            DeductSkillPointsAndAudio();
            dashSpeed.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.dashSpeed == dashSpeedUpgradeT1)
        {
            playerMovement.dashSpeed = dashSpeedUpgradeT2;
            DeductSkillPointsAndAudio();
            dashSpeed.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.dashSpeed == dashSpeedUpgradeT2)
        {
            playerMovement.dashSpeed = dashSpeedUpgradeT3;
            DeductSkillPointsAndAudio();
            dashSpeed.text = "MAX";
        }
    }

    public void UnlockNextDashCooldown()
    {
        if (levelManager.skillPoints >= 1 && playerMovement.dashCooldownAmount == dashCooldownUpgradeDefault)
        {
            playerMovement.dashCooldownAmount = dashCooldownUpgradeT1;
            playerMovement.dashCounter = dashCooldownUpgradeT1;
            DeductSkillPointsAndAudio();
            dashCool.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.dashCooldownAmount == dashCooldownUpgradeT1)
        {
            playerMovement.dashCooldownAmount = dashCooldownUpgradeT2;
            playerMovement.dashCounter = dashCooldownUpgradeT2;
            DeductSkillPointsAndAudio();
            dashCool.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.dashCooldownAmount == dashCooldownUpgradeT2)
        {
            playerMovement.dashCooldownAmount = dashCooldownUpgradeT3;
            playerMovement.dashCounter = dashCooldownUpgradeT3;
            DeductSkillPointsAndAudio();
            dashCool.text = "MAX";
        }
    }

    public void UnlockNextAttackDamage()
    {
        if (levelManager.skillPoints >= 1 && playerCombat.attackDamage == attackDamageUpgradeDefault)
        {
            playerCombat.attackDamage = attackDamageT1;
            DeductSkillPointsAndAudio();
            attackDmg.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.attackDamage == attackDamageT1)
        {
            playerCombat.attackDamage = attackDamageT2;
            DeductSkillPointsAndAudio();
            attackDmg.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.attackDamage == attackDamageT2)
        {
            playerCombat.attackDamage = attackDamageT3;
            DeductSkillPointsAndAudio();
            attackDmg.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.attackDamage == attackDamageT3)
        {
            playerCombat.attackDamage = attackDamageT4;
            DeductSkillPointsAndAudio();
            attackDmg.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.attackDamage == attackDamageT4)
        {
            playerCombat.attackDamage = attackDamageT5;
            DeductSkillPointsAndAudio();
            attackDmg.text = "MAX";
        }
    }

    public void UnlockNextAttackTime()
    {
        if (levelManager.skillPoints >= 1 && playerCombat.attackRate == attackTimeUpgradeDefault)
        {
            playerCombat.attackRate = attackTimeT1;
            DeductSkillPointsAndAudio();
            attackRate.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.attackRate == attackTimeT1)
        {
            playerCombat.attackRate = attackTimeT2;
            DeductSkillPointsAndAudio();
            attackRate.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.attackRate == attackTimeT2)
        {
            playerCombat.attackRate = attackTimeT3;
            DeductSkillPointsAndAudio();
            attackRate.text = "MAX";
        }
    }

    public void UnlockNextAttackRange()
    {
        if (levelManager.skillPoints >= 1 && playerCombat.attackRange == attackRangeUpgradeDefault)
        {
            playerCombat.attackRange = attackRangeT1;
            DeductSkillPointsAndAudio();
            attackRange.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.attackRange == attackRangeT1)
        {
            playerCombat.attackRange = attackRangeT2;
            DeductSkillPointsAndAudio();
            attackRange.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.attackRange == attackRangeT2)
        {
            playerCombat.attackRange = attackRangeT3;
            DeductSkillPointsAndAudio();
            attackRange.text = "MAX";
        }
    }

    public void UnlockNextSuperRechargeRate()
    {
        if (levelManager.skillPoints >= 1 && playerCombat.superRechargeRate == superRechargeRateDefault)
        {
            playerCombat.superRechargeRate = superRechargeT1;
            DeductSkillPointsAndAudio();
            superRecharge.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.superRechargeRate == superRechargeT1)
        {
            playerCombat.superRechargeRate = superRechargeT2;
            DeductSkillPointsAndAudio();
            superRecharge.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.superRechargeRate == superRechargeT2)
        {
            playerCombat.superRechargeRate = superRechargeT3;
            DeductSkillPointsAndAudio();
            superRecharge.text = "MAX";
        }
    }

    public void UnlockNextSuperReturnedValue()
    {
        if (levelManager.skillPoints >= 1 && superAmountReturned == superAmountReturnedDefault)
        {
            superAmountReturned = superAmountReturnedT1;
            DeductSkillPointsAndAudio();
            superFromKills.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && superAmountReturned == superAmountReturnedT1)
        {
            superAmountReturned = superAmountReturnedT2;
            DeductSkillPointsAndAudio();
            superFromKills.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && superAmountReturned == superAmountReturnedT2)
        {
            superAmountReturned = superAmountReturnedT3;
            DeductSkillPointsAndAudio();
            superFromKills.text = "MAX";
        }
    }

    public void UnlockNextStaminaMax()
    {
        if (levelManager.skillPoints >= 1 && playerCombat.staminaMax == staminaMaxUpgradeDefault)
        {
            playerCombat.staminaMax = staminaMaxT1;
            playerCombat.currentStamina = playerCombat.staminaMax;
            DeductSkillPointsAndAudio();
            maxStamina.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.staminaMax == staminaMaxT1)
        {
            playerCombat.staminaMax = staminaMaxT2;
            playerCombat.currentStamina = playerCombat.staminaMax;
            DeductSkillPointsAndAudio();
            maxStamina.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.staminaMax == staminaMaxT2)
        {
            playerCombat.staminaMax = staminaMaxT3;
            playerCombat.currentStamina = playerCombat.staminaMax;
            DeductSkillPointsAndAudio();
            maxStamina.text = "MAX";
        }
    }

    public void UnlockNextStaminaRechargeRate()
    {
        if (levelManager.skillPoints >= 1 && playerCombat.staminaRechargeRate == staminaRechargeRateDefault)
        {
            playerCombat.staminaRechargeRate = staminaRechargeRateT1;
            DeductSkillPointsAndAudio();
            staminaRecharge.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.staminaRechargeRate == staminaRechargeRateT1)
        {
            playerCombat.staminaRechargeRate = staminaRechargeRateT2;
            DeductSkillPointsAndAudio();
            staminaRecharge.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.staminaRechargeRate == staminaRechargeRateT2)
        {
            playerCombat.staminaRechargeRate = staminaRechargeRateT3;
            DeductSkillPointsAndAudio();
            staminaRecharge.text = "MAX";
        }
    }

    public void UnlockNextAttackCost()
    {
        if (levelManager.skillPoints >= 1 && playerCombat.attackCost == staminaAttackCostDefault)
        {
            playerCombat.attackCost = staminaAttackCostT1;
            DeductSkillPointsAndAudio();
            staminaAttackCost.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.attackCost == staminaAttackCostT1)
        {
            playerCombat.attackCost = staminaAttackCostT2;
            DeductSkillPointsAndAudio();
            staminaAttackCost.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerCombat.attackCost == staminaAttackCostT2)
        {
            playerCombat.attackCost = staminaAttackCostT3;
            DeductSkillPointsAndAudio();
            staminaAttackCost.text = "MAX";
        }
    }

    public void UnlockNextJumpCost()
    {
        if (levelManager.skillPoints >= 1 && playerMovement.jumpCost == staminaJumpCostDefault)
        {
            playerMovement.jumpCost = staminaJumpCostT1;
            DeductSkillPointsAndAudio();
            staminaJumpCost.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.jumpCost == staminaJumpCostT1)
        {
            playerMovement.jumpCost = staminaJumpCostT2;
            DeductSkillPointsAndAudio();
            staminaJumpCost.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.jumpCost == staminaJumpCostT2)
        {
            playerMovement.jumpCost = staminaJumpCostT3;
            DeductSkillPointsAndAudio();
            staminaJumpCost.text = "MAX";
        }
    }

    public void UnlockNextDashCost()
    {
        if (levelManager.skillPoints >= 1 && playerMovement.rollCost == staminaDashCostDefault)
        {
            playerMovement.rollCost = staminaDashCostT1;
            DeductSkillPointsAndAudio();
            staminaDashCost.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.rollCost == staminaDashCostT1)
        {
            playerMovement.rollCost = staminaDashCostT2;
            DeductSkillPointsAndAudio();
            staminaDashCost.text = "UPGRADE";
        }
        else if (levelManager.skillPoints >= 1 && playerMovement.rollCost == staminaDashCostT2)
        {
            playerMovement.rollCost = staminaDashCostT3;
            DeductSkillPointsAndAudio();
            staminaDashCost.text = "MAX";
        }
    }

    public void SetUIAtLevelStart()
    {
        if (doubleJump != null) // check to see if it exists in prologue and village
        {
            if (doubleJumpUnlocked)
            {
                doubleJump.text = "MAX";
            }
        }

        if (playerMovement.moveSpeed == moveUpgradeT3)
        {
            moveSpeed.text = "MAX";
        }

        if (playerMovement.jumpSpeed == jumpUpgradeT3)
        {
            jumpSpeed.text = "MAX";
        }

        if (playerMovement.dashSpeed == dashSpeedUpgradeT3)
        {
            dashSpeed.text = "MAX";
        }

        if (playerMovement.dashCooldownAmount == dashCooldownUpgradeT3)
        {
            dashCool.text = "MAX";
        }

        if (playerCombat.attackDamage == attackDamageT5)
        {
            attackDmg.text = "MAX";
        }

        if (playerCombat.attackRate == attackTimeT3)
        {
            attackRate.text = "MAX";
        }

        if (playerCombat.attackRange == attackRangeT3)
        {
            attackRange.text = "MAX";
        }

        if (playerCombat.superRechargeRate == superRechargeT3)
        {
            superRecharge.text = "MAX";
        }

        if (superAmountReturned == superAmountReturnedT2)
        {
            superFromKills.text = "MAX";
        }

        if (playerCombat.staminaMax == staminaMaxT3)
        {
            if(maxStamina != null)
            {
                maxStamina.text = "MAX";
            }
        }

        if (playerCombat.staminaRechargeRate == staminaRechargeRateT3)
        {
            if(staminaRecharge != null)
            {
                staminaRecharge.text = "MAX";
            }
        }

        if (playerCombat.attackCost == staminaAttackCostT3)
        {
            staminaAttackCost.text = "MAX";
        }

        if (playerMovement.jumpCost == staminaJumpCostT3)
        {
            staminaJumpCost.text = "MAX";
        }

        if (playerMovement.rollCost == staminaDashCostT3)
        {
            staminaDashCost.text = "MAX";
        }
    }
}
