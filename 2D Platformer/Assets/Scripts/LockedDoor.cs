using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LockedDoor : MonoBehaviour
{
    public LevelManager levelManager;
    public float unlockSpeed;
    public int keysRequired;

    public AudioSource stoneOpen;

    //Camera Shake
    //public CameraShake cameraShake;

    //Virtual Camera
    public CinemachineVirtualCamera virtualCamera1;
    public CinemachineVirtualCamera virtualCamera2;

    public bool coPlayOnce;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        coPlayOnce = false;
        
        //cameraShake = FindObjectOfType<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        if(levelManager.keyCount >= keysRequired)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - (unlockSpeed * Time.deltaTime));
            PlayStoneSound();
            //StartCoroutine(cameraShake.Shake(12f, 1f, 50f));
            if (coPlayOnce == false)
            {
                StartCoroutine(ChangeCamera());
            }

        }        

        if (transform.position.y <= -12)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + (unlockSpeed * Time.deltaTime));
            stoneOpen.Stop();
            //StartCoroutine(cameraShake.Shake(0f, 0f, 0f));
        }

        //Debug.Log("orbs Required = " + orbsRequired);
        //Debug.Log("coinCount = " + levelManager.coinCount);
    }

    void PlayStoneSound()
    {
        if (!stoneOpen.isPlaying)
        {
            stoneOpen.Play();
        }
    }

    public IEnumerator ChangeCamera()
    {
        coPlayOnce = true;
        levelManager.invincible = true;

        virtualCamera1.gameObject.SetActive(false);
        //virtualCamera1.enabled = false;
        virtualCamera2.gameObject.SetActive(true);
        //virtualCamera2.enabled = true;


        yield return new WaitForSeconds(5);

        virtualCamera2.gameObject.SetActive(false);
        //virtualCamera2.enabled = false;

        virtualCamera1.gameObject.SetActive(true);
        //virtualCamera1.enabled = true;

        levelManager.invincible = false;

        yield return null;
    }
}
