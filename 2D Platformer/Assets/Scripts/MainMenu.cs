using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    public string firstLevel;

    //audio
    public AudioSource menuMusic, selectSound;    

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
    
    public void QuitGame()
    {
        selectSound.Play();
        menuMusic.Stop();
        Application.Quit();
    }

    public void Prologue()
    {
        menuMusic.Stop();
        selectSound.Play();
        SceneManager.LoadScene("Prologue");
    }

    public void Village()
    {
        menuMusic.Stop();
        selectSound.Play();
        SceneManager.LoadScene("Village");
    }

    public void TheForest()
    {
        menuMusic.Stop();
        selectSound.Play();
        SceneManager.LoadScene("Level1_1");
    }
}
