using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMusicManager : MonoBehaviour
{
    public bool fadingOutMusic = false;

    public AudioSource prologue_Music, village_Music, forestDark_Music;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Prologue")
        {
            prologue_Music.Play();
        }

        if (SceneManager.GetActiveScene().name == "Village")
        {
            village_Music.Play();
        }

        if (SceneManager.GetActiveScene().name == "Level1_1")
        {
            forestDark_Music.Play();
        }
    }

    void Start()
    {

    }

    void Update()
    {
        if (fadingOutMusic)
        {
            if(prologue_Music != null)
            {
                prologue_Music.volume -= Time.deltaTime / 2f;
            }

            if(village_Music != null)
            {
                village_Music.volume -= Time.deltaTime / 2f;
            }

            if(forestDark_Music != null)
            {
                forestDark_Music.volume -= Time.deltaTime / 25f;
            }
        }

        if (prologue_Music.volume <= 0f && SceneManager.GetActiveScene().name == "Prologue")
        {
            prologue_Music.volume = 0f;
            fadingOutMusic = false;
        }
        
        if (village_Music.volume <= 0f && SceneManager.GetActiveScene().name == "Village")
        {
            village_Music.volume = 0f;
            fadingOutMusic = false;
        }

        if (forestDark_Music.volume <= 0f && SceneManager.GetActiveScene().name == "Level1_1")
        {
            forestDark_Music.volume = 0f;
            fadingOutMusic = false;
        }
    }
}
