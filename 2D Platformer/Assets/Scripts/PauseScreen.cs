using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public GameObject upgrades, settings;
    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;

    public bool inMenu;
    public string mainMenu;


    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerCombat = FindObjectOfType<PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (upgrades.activeSelf == false && settings.activeSelf == false)
            {
                upgrades.SetActive(true);
                settings.SetActive(false);
                Time.timeScale = 0.01f;
                playerMovement.enabled = false;
                playerCombat.enabled = false;
            }
            else if (upgrades.activeSelf == true || settings.activeSelf == true)
            {
                upgrades.SetActive(false);
                settings.SetActive(false);
                Time.timeScale = 1f;
                playerMovement.enabled = true;
                playerCombat.enabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            if (upgrades.activeSelf == true || settings.activeSelf == true)
            {
                upgrades.SetActive(false);
                settings.SetActive(true);
                //Time.timeScale = 0f;
            }            
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            if (upgrades.activeSelf == true || settings.activeSelf == true)
            {
                upgrades.SetActive(true);
                settings.SetActive(false);
                //Time.timeScale = 0f;
            }
        }
    }

    public void ResumeGame()
    {
        upgrades.SetActive(false);
        settings.SetActive(false);
        Time.timeScale = 1f;
        playerMovement.enabled = true;
        playerCombat.enabled = true;
    }

    public void LevelSelect()
    {

    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);
    }
}
