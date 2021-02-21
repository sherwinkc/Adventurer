using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    [SerializeField] public TMP_Text text;

    public float delay;
    public float timeToLoad;
    public string levelToLoad;
    public string fullText;
    private string currentText = "";

    public AudioSource textSFX, levelMusic;

    public FadeToBlack fade;

    public bool decreasingVol = false;

    private bool coActive = false;

    void Start()
    {
        fade = FindObjectOfType<FadeToBlack>();
        levelMusic.Play();
        StartCoroutine(ShowText());
        StartCoroutine(LoadNextLevel());
    }


    void Update()
    {
        if(decreasingVol)
        {
            levelMusic.volume -= Time.deltaTime / 2;
        }

        if(levelMusic.volume <= 0)
        {
            levelMusic.volume = 0f;
            decreasingVol = false;
        }
    }

    IEnumerator ShowText()
    {
        coActive = true;

        fullText = text.text;

        for (int i = 0; i < fullText.Length + 1; i++)
        {
            currentText = fullText.Substring(0, i);
            text.text = currentText;

            if (!textSFX.isPlaying && coActive)
            {
                textSFX.pitch = Random.Range(0.8f, 1f);
                textSFX.Play();
            }

            yield return new WaitForSeconds(delay);
        }

        coActive = false;
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(timeToLoad);
        decreasingVol = true;

        //fade.fadeToBlack = true;

        yield return new WaitForSeconds(fade.fadeTime * 2f);

        levelMusic.Stop();

        SceneManager.LoadScene(levelToLoad);

        yield return null;
    }
}
