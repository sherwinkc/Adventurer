using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMusicManager : MonoBehaviour
{
    public bool fadingOutMusic = false;

    public AudioSource prologue_Music, village_Music, forestDark_Music, floatingIsles_Music, land_Music, level_BossMusic;

    public Skel_King_Script skel_King_Script;

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

        if (SceneManager.GetActiveScene().name == "Level1_2")
        {
            floatingIsles_Music.Play();
        }

        if (SceneManager.GetActiveScene().name == "Level1_3")
        {
            land_Music.Play();
        }

        /*if (SceneManager.GetActiveScene().name == "Boss_Level")
        {
            level_BossMusic.Play();
        }*/

        skel_King_Script = FindObjectOfType<Skel_King_Script>();
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

            if (floatingIsles_Music != null)
            {
                floatingIsles_Music.volume -= Time.deltaTime / 25f;
            }

            if (land_Music != null)
            {
                land_Music.volume -= Time.deltaTime / 25f;
            }

            if (level_BossMusic != null)
            {
                level_BossMusic.volume -= Time.deltaTime / 25f;
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

        if (floatingIsles_Music.volume <= 0f && SceneManager.GetActiveScene().name == "Level1_2")
        {
            floatingIsles_Music.volume = 0f;
            fadingOutMusic = false;
        }

        if (land_Music.volume <= 0f && SceneManager.GetActiveScene().name == "Level1_3")
        {
            land_Music.volume = 0f;
            fadingOutMusic = false;
        }

        if (level_BossMusic.volume <= 0f && SceneManager.GetActiveScene().name == "Boss_Level")
        {
            level_BossMusic.volume = 0f;
            fadingOutMusic = false;
        }

        if(skel_King_Script != null)
        {
            if(skel_King_Script.currentHealth <= 0)
            {
                level_BossMusic.Stop();
            }
        }
        else
        {
            return;
        }
    }

    public void PlayBossMusic()
    {
        if(!level_BossMusic.isPlaying)
        {
            level_BossMusic.Play();
        }
    }
}
