using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBarScript : MonoBehaviour
{
    PlayerMovement playerMovement;
    Upgrades upgrades;
    public Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        upgrades = FindObjectOfType<Upgrades>();
    }

    void Update()
    {
        slider.maxValue = upgrades.playerMovement.dashCooldownAmount;
        slider.value = upgrades.playerMovement.dashCounter;

        transform.position = new Vector3(playerMovement.transform.position.x, playerMovement.transform.position.y + (float)1.9f, playerMovement.transform.position.z);
    }
}
