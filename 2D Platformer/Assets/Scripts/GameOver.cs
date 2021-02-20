using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public LevelManager levelManager;
    public string levelToLoad;

    public AudioSource gameOverMusic;
    public bool playingMusic = false;
    public bool playingCo = false;


    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf == true)
        {
            if(!playingCo)
            {
                StartCoroutine(GameOverCO());
                playingCo = true;
            }
        }
    }

    public void Restart()
    {

    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void QuitGame()
    {
        gameOverMusic.Stop();
        Application.Quit();
    }

    public IEnumerator GameOverCO()
    {
        if (!playingMusic)
        {
            gameOverMusic.Play();
            playingMusic = true;
        }

        yield return new WaitForSeconds(0.5f);

        levelManager.gameObject.SetActive(false);

        yield return null;
    }
}
