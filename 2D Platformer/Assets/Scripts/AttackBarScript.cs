using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackBarScript : MonoBehaviour
{
    public Slider slider;
    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;
    public Upgrades upgrades;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = upgrades.playerCombat.staminaMax;
        slider.value = playerCombat.currentStamina;
    }
}
