using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackCardScript : MonoBehaviour
{
    public float waitTime;
    public string levelToLoad;
    public AudioSource sfx1, sfx2;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BlackCardCo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator BlackCardCo()
    {
        //sfx1.Play();
        //sfx2.Play();

        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(levelToLoad);
    }
}
