using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBarScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public PlayerMovement playerMovement;
    public Upgrades upgrades;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = upgrades.playerMovement.dashCooldownAmount;
        slider.value = upgrades.playerMovement.dashCounter;
    }
}
