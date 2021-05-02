using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDistance : MonoBehaviour
{
    public AudioSource audioSource;
    public PlayerMovement playerMovement;

    public float distanceFromSound;

    public float maxVolume;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, playerMovement.transform.position) < distanceFromSound)
        {
            audioSource.volume += Time.deltaTime / 4;

            if (audioSource.volume >= maxVolume)
            {
                audioSource.volume = maxVolume;
            }
        }
        else
        {
            if (audioSource.volume > 0)
            {
                audioSource.volume -= Time.deltaTime / 4;
            }

            if (audioSource.volume <= 0)
            {
                audioSource.volume = 0f;
            }
        }
    }
}
