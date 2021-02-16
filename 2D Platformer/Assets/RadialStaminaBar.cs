using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialStaminaBar : MonoBehaviour
{
    public Image image;

    private PlayerMovement playerMovement;
    private PlayerCombat playerCombat;
    private Upgrades upgrades;

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

        image.fillAmount = (playerCombat.currentStamina / upgrades.playerCombat.staminaMax);

        //Debug.Log("current stam = " + playerCombat.currentStamina);
        //Debug.Log("max stam = " + upgrades.playerCombat.staminaMax);

        transform.position = new Vector3(playerMovement.transform.position.x, playerMovement.transform.position.y + (float)2.25, playerMovement.transform.position.z);

        if (playerCombat.currentStamina >= upgrades.playerCombat.staminaMax)
        {
            image.color = new Color(1f, 0f, 0f, 0.5f);
        }
        else
        {
            image.color = new Color(1f, 0f, 0f, 1f);
        }




    }
}
