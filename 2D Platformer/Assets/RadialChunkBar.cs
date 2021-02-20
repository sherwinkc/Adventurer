using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialChunkBar : MonoBehaviour
{
    public Image image;

    private PlayerMovement playerMovement;
    private PlayerCombat playerCombat;
    private Upgrades upgrades;
    private LevelManager levelManager;

    public float barFillAmount;

    void Start()
    {
        image = GetComponent<Image>();

        playerMovement = FindObjectOfType<PlayerMovement>();
        playerCombat = FindObjectOfType<PlayerCombat>();
        upgrades = FindObjectOfType<Upgrades>();
    }

    // Update is called once per frame
    void Update()
    {
        //slider.maxValue = upgrades.playerCombat.staminaMax;
        //slider.value = playerCombat.currentStamina;

        //image.fillAmount = (playerCombat.currentStamina / upgrades.playerCombat.staminaMax);

        barFillAmount = (playerCombat.currentStamina / 100);
        image.fillAmount = barFillAmount;

        //Debug.Log("current stam = " + playerCombat.currentStamina);
        //Debug.Log("max stam = " + upgrades.playerCombat.staminaMax);

        transform.position = new Vector3(playerMovement.transform.position.x, playerMovement.transform.position.y + (float)2.25, playerMovement.transform.position.z);
    }

    public void WhiteBar()
    {
        //barFillAmount = (playerCombat.currentStamina / 100);
        //image.fillAmount = barFillAmount;
    }
}
