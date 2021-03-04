using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    public FadeToBlack fade;
    
    public string firstLevel;
    public float timeToLoad;

    //public AudioSource levelMusic;
    public bool turnDownMusic = false;
    public float volumeRate; 

    //audio
    public AudioSource menuMusic, selectSound;    

    // Start is called before the first frame update
    void Start()
    {
        //fade = FindObjectOfType<FadeToBlack>();
        menuMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (turnDownMusic)
        {
            menuMusic.volume -= volumeRate * Time.deltaTime;
        }

    }
    public void NewGame()
    {
        StartCoroutine(NewGameCo());
        fade.fadeToBlack = true;

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

    public void FloatingIsles()
    {
        menuMusic.Stop();
        selectSound.Play();
        SceneManager.LoadScene("Level1_2");
    }

    public void LandOfTheDead()
    {
        menuMusic.Stop();
        selectSound.Play();
        SceneManager.LoadScene("Level1_3");
    }

    public void TheSkeletonKing()
    {
        menuMusic.Stop();
        selectSound.Play();
        SceneManager.LoadScene("Boss_Level");
    }

    public IEnumerator NewGameCo()
    {
        turnDownMusic = true;
        selectSound.Play();

        yield return new WaitForSeconds(timeToLoad);

        menuMusic.Stop();
        SceneManager.LoadScene(firstLevel);

        yield return null;
    }
}
