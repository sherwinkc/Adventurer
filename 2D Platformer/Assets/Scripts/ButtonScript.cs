using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public LevelManager levelManager;
    public Button button;

    public AudioSource errorSFX;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableButton()
    {
        if(levelManager.skillPoints >= 1)
        {
            button.enabled = false;
        }
        
        if(levelManager.skillPoints <= 0)
        {
            errorSFX.Play();
        }
    }
}
