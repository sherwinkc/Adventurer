using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackBarScript : MonoBehaviour
{
    public Slider slider;
    private PlayerMovement playerMovement;
    private PlayerCombat playerCombat;
    private Upgrades upgrades;

    void Start()
    {
        slider = GetComponent<Slider>();

        playerMovement = FindObjectOfType<PlayerMovement>();
        playerCombat = FindObjectOfType<PlayerCombat>();
        upgrades = FindObjectOfType<Upgrades>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = upgrades.playerCombat.staminaMax;
        slider.value = playerCombat.currentStamina;

        transform.position = new Vector3(playerMovement.transform.position.x, playerMovement.transform.position.y + 2, playerMovement.transform.position.z);
    }
}
