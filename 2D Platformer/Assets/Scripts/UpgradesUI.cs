using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesUI : MonoBehaviour
{
    public LevelManager levelManager;
    public Text skillPointsUI;

    void Start()
    {

    }

    void Update()
    {
        skillPointsUI.text = "Skill Points Available: " + levelManager.skillPoints;
    }
}
