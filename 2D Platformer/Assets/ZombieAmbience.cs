using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAmbience : MonoBehaviour
{
    public Skel_King_Script skel_King_Script;
    public AudioSource ambience;

    private void Awake()
    {
        ambience = GetComponent<AudioSource>();

        skel_King_Script = FindObjectOfType<Skel_King_Script>();

    }
    // Start is called before the first frame update
    void Start()
    {
        ambience.volume = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (skel_King_Script.currentHealth <= skel_King_Script.maxHealth * 0.75f && skel_King_Script.currentHealth > skel_King_Script.maxHealth * 0.25f)
        {
            ambience.volume = 0.075f;
        }

        if (skel_King_Script.currentHealth <= skel_King_Script.maxHealth * 0.25f)
        {
            ambience.volume = 0.1f;
        }

        if (skel_King_Script.currentHealth <= 0)
        {
            ambience.Stop();
        }

        //Debug.Log(skel_King_Script.currentHealth);
    }
}
