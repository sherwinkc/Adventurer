using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesUI : MonoBehaviour
{
    public LevelManager levelManager;
    public Text skillPointsUI;

    // Start is called before the first frame update
    void Start()
    {
        //levelManager = FindObjectOfType<LevelManager>();
        //skillPointsUI = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        skillPointsUI.text = "Skill Points Available: " + levelManager.skillPoints;
    }
}
