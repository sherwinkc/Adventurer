using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    public Animator animator;
    public GameObject orbPrefab;

    public bool openTheChest;
    public bool openedByPlayer;
    private bool playOnce = false;

    //Audio
    public AudioSource chestOpen, chestJingle, orbSFX;


    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        openedByPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(openTheChest && !openedByPlayer)
        {
            StartCoroutine(OrbShowerCo());

            if (!playOnce)
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

        openedByPlayer = true;
        openTheChest = false;

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
