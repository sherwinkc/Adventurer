using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    public bool playerOpen;
    public Animator animator;
    public GameObject orbPrefab;
    public AudioSource chestOpen, chestJingle, orbSFX;

    private bool playOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerOpen)
        {
            StartCoroutine(OrbShowerCo());
            if(!playOnce)
            {
                ChestSounds();
                playOnce = true;
            }
        }
    }

    public IEnumerator OrbShowerCo()
    {
        OrbShower();

        yield return new WaitForSeconds(10f * Time.deltaTime);        

        playerOpen = false;

        yield return null;
    }

    void OrbShower()
    {
        Instantiate(orbPrefab, new Vector2(transform.position.x, transform.position.y + 1.6f), transform.rotation);
        orbSFX.Play();
    }

    void ChestSounds()
    {
        chestOpen.Play();
        chestJingle.Play();
    }

    

}
