using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCries : MonoBehaviour
{
    public AudioSource zombieSFX;
    public float timerCount, interval;

    // Start is called before the first frame update
    void Start()
    {
        zombieSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timerCount += Time.deltaTime;

        if(timerCount > interval)
        {
            timerCount = 0;
            zombieSFX.pitch = Random.Range(0.7f, 1.2f);
            zombieSFX.panStereo = Random.Range(-0.5f, 0.5f);
            zombieSFX.Play();
        }
    }
}
