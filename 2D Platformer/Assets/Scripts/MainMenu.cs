using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{

    public string firstLevel;
    //public string levelSelect;

    //audio
    public AudioSource menuMusic;
    public AudioSource selectSound;

    // Start is called before the first frame update
    void Start()
    {
        menuMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        menuMusic.Stop();
        selectSound.Play();
        SceneManager.LoadScene(firstLevel);
    }

    public void Continue()
    {

    }

    public void QuitGame()
    {
        selectSound.Play();
        menuMusic.Stop();
        Application.Quit();
    }
}
