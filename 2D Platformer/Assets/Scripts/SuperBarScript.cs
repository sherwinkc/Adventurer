﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperBarScript : MonoBehaviour
{
    public Slider slider;
    public PlayerCombat playerCombat;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = playerCombat.superAmount;
    }
}
