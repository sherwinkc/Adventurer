using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Upgrades upgrades;
    public LevelManager levelManager;
    public Button button;

    public AudioSource errorSFX;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        upgrades = FindObjectOfType<Upgrades>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableButton()
    {
        //no skill points
        if(levelManager.skillPoints <= 0)
        {
            errorSFX.Play();
        }

        /*//double jump
        if (upgrades.doubleJumpUnlocked == true)
        {
            button.enabled = false;
        }

        //move speed
        if (playerMovement.moveSpeed == upgrades.moveUpgradeT3)
        {
            button.enabled = false;
        }

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
