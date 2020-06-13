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
        if (playerMovement.moveSpeed == upgrades.moveUpgradeT3 || upgrades.doubleJumpUnlocked == true)
        {
            button.enabled = false;
        }
        
        if(levelManager.skillPoints <= 0)
        {
            errorSFX.Play();
        }
    }
}
