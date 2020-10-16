﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDistance : MonoBehaviour
{
    public AudioSource audioSource;
    public PlayerMovement playerMovement;

    public float distanceFromSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerMovement= FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, playerMovement.transform.position) < distanceFromSound)
        {
            Debug.Log("less than 6");
        }
        else
        {
            Debug.Log("greater than 6");
        }

        //Debug.Log(playerNew.transform.position.x - transform.position.x);
        //Debug.Log(Mathf.Abs(playerNew.transform.position.x - transform.position.x));
    }
}
