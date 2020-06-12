using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Cheats : MonoBehaviour
{
    public LevelManager levelManager;
    public Upgrades upgrades;
    public PlayerCombat playerCombat;


    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        upgrades = FindObjectOfType<Upgrades>();
        playerCombat = GetComponent<PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        //increase/decrease orbs/coins
        if (Input.GetKeyDown(KeyCode.P))
        {
            levelManager.AddCoins(50);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            levelManager.AddCoins(-50);
        }

        //coinCount does not go below 0
        if (levelManager.coinCount < 0)
        {
            levelManager.coinCount = 0;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            levelManager.AddKeys(1);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            levelManager.AddKeys(-1);
        }

        //coinCount does not go below 0
        if (levelManager.keyCount < 0)
        {
            levelManager.keyCount = 0;
        }

        //unlock double jump
        if(Input.GetKeyDown(KeyCode.J))
        {
            if (upgrades.doubleJumpUnlocked == false)
            {
                upgrades.doubleJumpUnlocked = true;
            }
            else if (upgrades.doubleJumpUnlocked == true)
            {
                upgrades.doubleJumpUnlocked = false;
            }
        }

        //super
        if(Input.GetKeyDown(KeyCode.B))
        {
            upgrades.playerCombat.superAmount = 100f;
        }

        //super recharge rate -/+
        if (Input.GetKeyDown(KeyCode.M))
        {
            upgrades.playerCombat.superRechargeRate += 1f;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            upgrades.playerCombat.superRechargeRate = 15f;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            upgrades.playerCombat.superRechargeRate = 0.5f;
        }

        //Dodge Speed -/+
        if (Input.GetKeyDown(KeyCode.I))
        {
            upgrades.playerMovement.dashSpeed += 1f;
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            upgrades.playerMovement.dashSpeed -= 1f;
        }

        //dash cooldown
        if (Input.GetKeyDown(KeyCode.Y))
        {
            upgrades.playerMovement.dashCooldownAmount += 0.25f;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            upgrades.playerMovement.dashCooldownAmount -= 0.25f;
        }
    }
}
