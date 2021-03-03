using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;
    public Upgrades upgrades;
    public LevelManager levelManager;
    public Button button;
    public Text text;

    /*public Text maxStamina, staminaRecharge, staminaAttackCost, staminaJumpCost, staminaDashCost, doubleJump, moveSpeed, jumpSpeed,
        dashSpeed, dashCool, attackDmg, attackRate, attackRange, superRecharge, superFromKills;*/

    public AudioSource errorSFX;

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerCombat = FindObjectOfType<PlayerCombat>();
        upgrades = FindObjectOfType<Upgrades>();
    }


    void Start()
    {

    }


    void Update()
    {
        /*//double jump
        if (upgrades.doubleJumpUnlocked == true)
        {
            //text.text = "MAX";
            errorSFX.Play();
        }
        else
        {
            //text.text = "UPGRADE";
        }

        //move speed
        if (playerMovement.moveSpeed == upgrades.moveUpgradeT3)
        {
            //text.text = "MAX";
            errorSFX.Play();
        }
        else
        {
            text.text = "UPGRADE";
        }*/
    }

    public void UpdateButton()
    {
        //no skill points
        if(levelManager.skillPoints <= 0)
        {
            if(!upgrades.upgradeSFX.isPlaying) //TODO not the most elegant way as the upgrade sfx has a long tail
            {
                errorSFX.Play();
            }
        }

        if (upgrades.doubleJumpUnlocked == true)
        {
            //doubleJump.text = "MAX";
            //errorSFX.Play();
        }
        else
        {
            //doubleJump.text = "UPGRADE";
        }

        if (playerMovement.moveSpeed == upgrades.moveUpgradeT3)
        {
            //moveSpeed.text = "MAX";
            //errorSFX.Play();
        }
        else
        {
            //moveSpeed.text = "UPGRADE";
        }

        /*

        //jump speed
        if (playerMovement.jumpSpeed == upgrades.jumpUpgradeT3)
        {
            button.enabled = false;
        }

        if (playerMovement.dashSpeed == upgrades.dashSpeedUpgradeT3)
        {
            button.enabled = false;
        }

        if (playerMovement.dashCooldownAmount == upgrades.dashCooldownUpgradeT3)
        {
            button.enabled = false;
        }*/
    }
}
