using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public GameObject upgrades, settings, HUD;
    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;

    public string mainMenu;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerCombat = FindObjectOfType<PlayerCombat>();

        upgrades.SetActive(false);
        settings.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (upgrades.activeSelf == false && settings.activeSelf == false)
            {
                upgrades.SetActive(true);
                settings.SetActive(false);
                if (SceneManager.GetActiveScene().name != "Prologue" && SceneManager.GetActiveScene().name != "Village")
                {
                    HUD.SetActive(false);
                }
                Time.timeScale = 0f;
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
                if (SceneManager.GetActiveScene().name != "Prologue" && SceneManager.GetActiveScene().name != "Village")
                {
                    HUD.SetActive(true);
                }
            }
        }

        Debug.Log(SceneManager.GetActiveScene().name);

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            if (upgrades.activeSelf == true || settings.activeSelf == true)
            {
                upgrades.SetActive(false);
                settings.SetActive(true);
            }            
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            if (upgrades.activeSelf == true || settings.activeSelf == true)
            {
                upgrades.SetActive(true);
                settings.SetActive(false);
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

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);
    }
}