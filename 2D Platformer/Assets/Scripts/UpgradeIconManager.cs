using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeIconManager : MonoBehaviour
{
    public Image img_MaxStamina_1, img_MaxStamina_2, img_MaxStamina_3;
    public Image img_StaminaRecharge_1, img_StaminaRecharge_2, img_StaminaRecharge_3;
    public Image img_StaminaAttackCost_1, img_StaminaAttackCost_2, img_StaminaAttackCost_3;
    public Image img_StaminaJumpCost_1, img_StaminaJumpCost_2, img_StaminaJumpCost_3;
    public Image img_StaminaDashCost_1, img_StaminaDashCost_2, img_StaminaDashCost_3;
    public Image img_DoubleJump;
    public Image img_MoveSpeed_1, img_MoveSpeed_2, img_MoveSpeed_3;
    public Image img_JumpSpeed_1, img_JumpSpeed_2, img_JumpSpeed_3;
    public Image img_DashSpeed_1, img_DashSpeed_2, img_DashSpeed_3;
    public Image img_DashCool_1, img_DashCool_2, img_DashCool_3;
    public Image img_AttackDmg_1, img_AttackDmg_2, img_AttackDmg_3, img_AttackDmg_4, img_AttackDmg_5;
    public Image img_AttackRate_1, img_AttackRate_2, img_AttackRate_3;
    public Image img_AttackRange_1, img_AttackRange_2, img_AttackRange_3;
    public Image img_SuperRecharge_1, img_SuperRecharge_2, img_SuperRecharge_3;
    public Image img_SuperFromKills_1, img_SuperFromKills_2, img_SuperFromKills_3;

    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;
    public Upgrades upgrades;

    void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerCombat = FindObjectOfType<PlayerCombat>();
        upgrades = FindObjectOfType<Upgrades>();
    }

    void Update()
    {
        //Max Stamina
        if (playerCombat.staminaMax == upgrades.staminaMaxT1)
        {
            img_MaxStamina_1.color = new Color(255, 255, 0);
        }
        else if (playerCombat.staminaMax == upgrades.staminaMaxT2)
        {
            img_MaxStamina_1.color = new Color(255, 255, 0);
            img_MaxStamina_2.color = new Color(255, 255, 0);
        }
        else if (playerCombat.staminaMax == upgrades.staminaMaxT3)
        {
            img_MaxStamina_1.color = new Color(255, 255, 0);
            img_MaxStamina_2.color = new Color(255, 255, 0);
            img_MaxStamina_3.color = new Color(255, 255, 0);
        }

        //Stamina Recharge Rate
        if (playerCombat.staminaRechargeRate == upgrades.staminaRechargeRateT1)
        {
            img_StaminaRecharge_1.color = new Color(255, 255, 0);
        }
        else if (playerCombat.staminaRechargeRate == upgrades.staminaRechargeRateT2)
        {
            img_StaminaRecharge_1.color = new Color(255, 255, 0);
            img_StaminaRecharge_2.color = new Color(255, 255, 0);
        }
        else if (playerCombat.staminaRechargeRate == upgrades.staminaRechargeRateT3)
        {
            img_StaminaRecharge_1.color = new Color(255, 255, 0);
            img_StaminaRecharge_2.color = new Color(255, 255, 0);
            img_StaminaRecharge_3.color = new Color(255, 255, 0);
        }

        //Stamina Attack Cost
        if (playerCombat.attackCost == upgrades.staminaAttackCostT1)
        {
            img_StaminaAttackCost_1.color = new Color(255, 255, 0);
        }
        else if (playerCombat.attackCost == upgrades.staminaAttackCostT2)
        {
            img_StaminaAttackCost_1.color = new Color(255, 255, 0);
            img_StaminaAttackCost_2.color = new Color(255, 255, 0);
        }
        else if (playerCombat.attackCost == upgrades.staminaAttackCostT3)
        {
            img_StaminaAttackCost_1.color = new Color(255, 255, 0);
            img_StaminaAttackCost_2.color = new Color(255, 255, 0);
            img_StaminaAttackCost_3.color = new Color(255, 255, 0);
        }

        //Stamina Jump Cost
        if (playerMovement.jumpCost == upgrades.staminaJumpCostT1)
        {
            img_StaminaJumpCost_1.color = new Color(255, 255, 0);
        }
        else if (playerMovement.jumpCost == upgrades.staminaJumpCostT2)
        {
            img_StaminaJumpCost_1.color = new Color(255, 255, 0);
            img_StaminaJumpCost_2.color = new Color(255, 255, 0);
        }
        else if (playerMovement.jumpCost == upgrades.staminaJumpCostT3)
        {
            img_StaminaJumpCost_1.color = new Color(255, 255, 0);
            img_StaminaJumpCost_2.color = new Color(255, 255, 0);
            img_StaminaJumpCost_3.color = new Color(255, 255, 0);
        }

        //Stamina Dash Cost
        if (playerMovement.rollCost == upgrades.staminaDashCostT1)
        {
            img_StaminaDashCost_1.color = new Color(255, 255, 0);
        }
        else if (playerMovement.rollCost == upgrades.staminaDashCostT2)
        {
            img_StaminaDashCost_1.color = new Color(255, 255, 0);
            img_StaminaDashCost_2.color = new Color(255, 255, 0);
        }
        else if (playerMovement.rollCost == upgrades.staminaDashCostT3)
        {
            img_StaminaDashCost_1.color = new Color(255, 255, 0);
            img_StaminaDashCost_2.color = new Color(255, 255, 0);
            img_StaminaDashCost_3.color = new Color(255, 255, 0);
        }

        //Double Jump
        if (upgrades.doubleJumpUnlocked)
        {
            img_DoubleJump.color = new Color(255, 255, 0);
        }

        //Movement Speed
        if (playerMovement.moveSpeed == upgrades.moveUpgradeT1)
        {
            img_MoveSpeed_1.color = new Color(255, 255, 0);
        }
        else if (playerMovement.moveSpeed == upgrades.moveUpgradeT2)
        {
            img_MoveSpeed_1.color = new Color(255, 255, 0);
            img_MoveSpeed_2.color = new Color(255, 255, 0);
        }
        else if (playerMovement.moveSpeed == upgrades.moveUpgradeT3)
        {
            img_MoveSpeed_1.color = new Color(255, 255, 0);
            img_MoveSpeed_2.color = new Color(255, 255, 0);
            img_MoveSpeed_3.color = new Color(255, 255, 0);
        }

        //Jump Speed
        if (playerMovement.jumpSpeed == upgrades.jumpUpgradeT1)
        {
            img_JumpSpeed_1.color = new Color(255, 255, 0);
        }
        else if (playerMovement.jumpSpeed == upgrades.jumpUpgradeT2)
        {
            img_JumpSpeed_1.color = new Color(255, 255, 0);
            img_JumpSpeed_2.color = new Color(255, 255, 0);
        }
        else if (playerMovement.jumpSpeed == upgrades.jumpUpgradeT3)
        {
            img_JumpSpeed_1.color = new Color(255, 255, 0);
            img_JumpSpeed_2.color = new Color(255, 255, 0);
            img_JumpSpeed_3.color = new Color(255, 255, 0);
        }

        //Dash Speed
        if (playerMovement.dashSpeed == upgrades.dashSpeedUpgradeT1)
        {
            img_DashSpeed_1.color = new Color(255, 255, 0);
        }
        else if (playerMovement.dashSpeed == upgrades.dashSpeedUpgradeT2)
        {
            img_DashSpeed_1.color = new Color(255, 255, 0);
            img_DashSpeed_2.color = new Color(255, 255, 0);
        }
        else if (playerMovement.dashSpeed == upgrades.dashSpeedUpgradeT3)
        {
            img_DashSpeed_1.color = new Color(255, 255, 0);
            img_DashSpeed_2.color = new Color(255, 255, 0);
            img_DashSpeed_3.color = new Color(255, 255, 0);
        }

        //Dash Cooldown
        if (playerMovement.dashCooldownAmount == upgrades.dashCooldownUpgradeT1)
        {
            img_DashCool_1.color = new Color(255, 255, 0);
        }
        else if (playerMovement.dashCooldownAmount == upgrades.dashCooldownUpgradeT2)
        {
            img_DashCool_1.color = new Color(255, 255, 0);
            img_DashCool_2.color = new Color(255, 255, 0);
        }
        else if (playerMovement.dashCooldownAmount == upgrades.dashCooldownUpgradeT3)
        {
            img_DashCool_1.color = new Color(255, 255, 0);
            img_DashCool_2.color = new Color(255, 255, 0);
            img_DashCool_3.color = new Color(255, 255, 0);
        }

        //Attack Damage
        if (playerCombat.attackDamage == upgrades.attackDamageT1)
        {
            img_AttackDmg_1.color = new Color(255, 255, 0);
        }
        else if (playerCombat.attackDamage == upgrades.attackDamageT2)
        {
            img_AttackDmg_1.color = new Color(255, 255, 0);
            img_AttackDmg_2.color = new Color(255, 255, 0);
        }
        else if (playerCombat.attackDamage == upgrades.attackDamageT3)
        {
            img_AttackDmg_1.color = new Color(255, 255, 0);
            img_AttackDmg_2.color = new Color(255, 255, 0);
            img_AttackDmg_3.color = new Color(255, 255, 0);
        }
        else if (playerCombat.attackDamage == upgrades.attackDamageT4)
        {
            img_AttackDmg_1.color = new Color(255, 255, 0);
            img_AttackDmg_2.color = new Color(255, 255, 0);
            img_AttackDmg_3.color = new Color(255, 255, 0);
            img_AttackDmg_4.color = new Color(255, 255, 0);
        }
        else if (playerCombat.attackDamage == upgrades.attackDamageT5)
        {
            img_AttackDmg_1.color = new Color(255, 255, 0);
            img_AttackDmg_2.color = new Color(255, 255, 0);
            img_AttackDmg_3.color = new Color(255, 255, 0);
            img_AttackDmg_4.color = new Color(255, 255, 0);
            img_AttackDmg_5.color = new Color(255, 255, 0);
        }

        //Attack Rate
        if (playerCombat.attackRate == upgrades.attackTimeT1)
        {
            img_AttackRate_1.color = new Color(255, 255, 0);
        }
        else if (playerCombat.attackRate == upgrades.attackTimeT2)
        {
            img_AttackRate_1.color = new Color(255, 255, 0);
            img_AttackRate_2.color = new Color(255, 255, 0);
        }
        else if (playerCombat.attackRate == upgrades.attackTimeT3)
        {
            img_AttackRate_1.color = new Color(255, 255, 0);
            img_AttackRate_2.color = new Color(255, 255, 0);
            img_AttackRate_3.color = new Color(255, 255, 0);
        }

        //Attack Range
        if (playerCombat.attackRange == upgrades.attackRangeT1)
        {
            img_AttackRange_1.color = new Color(255, 255, 0);
        }
        else if (playerCombat.attackRange == upgrades.attackRangeT2)
        {
            img_AttackRange_1.color = new Color(255, 255, 0);
            img_AttackRange_2.color = new Color(255, 255, 0);
        }
        else if (playerCombat.attackRange == upgrades.attackRangeT3)
        {
            img_AttackRange_1.color = new Color(255, 255, 0);
            img_AttackRange_2.color = new Color(255, 255, 0);
            img_AttackRange_3.color = new Color(255, 255, 0);
        }

        //Super Recharge Rate
        if (playerCombat.superRechargeRate == upgrades.superRechargeT1)
        {
            img_SuperRecharge_1.color = new Color(255, 255, 0);
        }
        else if (playerCombat.superRechargeRate == upgrades.superRechargeT2)
        {
            img_SuperRecharge_1.color = new Color(255, 255, 0);
            img_SuperRecharge_2.color = new Color(255, 255, 0);
        }
        else if (playerCombat.superRechargeRate == upgrades.superRechargeT3)
        {
            img_SuperRecharge_1.color = new Color(255, 255, 0);
            img_SuperRecharge_2.color = new Color(255, 255, 0);
            img_SuperRecharge_3.color = new Color(255, 255, 0);
        }

        //Super from kills
        if (upgrades.superAmountReturned == upgrades.superAmountReturnedT1)
        {
            img_SuperFromKills_1.color = new Color(255, 255, 0);
        }
        else if (upgrades.superAmountReturned == upgrades.superAmountReturnedT2)
        {
            img_SuperFromKills_1.color = new Color(255, 255, 0);
            img_SuperFromKills_2.color = new Color(255, 255, 0);
        }
        else if (upgrades.superAmountReturned == upgrades.superAmountReturnedT3)
        {
            img_SuperFromKills_1.color = new Color(255, 255, 0);
            img_SuperFromKills_2.color = new Color(255, 255, 0);
            img_SuperFromKills_3.color = new Color(255, 255, 0);
        }
    }
}
