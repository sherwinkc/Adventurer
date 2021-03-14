using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackCardScript : MonoBehaviour
{
    public float waitTime;
    public string levelToLoad;
    public AudioSource sfx1, sfx2, sfx3;
    public bool play1, play2, play3;
    public float volumeRate;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BlackCardCo());
    }

    // Update is called once per frame
    void Update()
    {
        if(play3)
        {
            sfx3.volume -= Time.deltaTime / volumeRate;

            if(sfx3.volume <= 0f)
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }

    }

    public IEnumerator BlackCardCo()
    {
        if(play1)
        {
            sfx1.Play();
        }

        if(play2)
        {
            sfx2.Play();
        }

        if(play3)
        {
            sfx3.Play();
        }

        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(levelToLoad);
    }
}
