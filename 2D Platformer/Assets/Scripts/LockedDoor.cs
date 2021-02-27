using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LockedDoor : MonoBehaviour
{
    public LevelManager levelManager;
    public float unlockSpeed;
    public float startTime;
    public int keysRequired;

    //Virtual Camera
    public CinemachineVirtualCamera virtualCamera1;
    public CinemachineVirtualCamera virtualCamera2;

    public bool canPlayCo = true;
    public bool moveDoor = false;

    //Audio
    public AudioSource stoneOpen;

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(levelManager.keyCount >= keysRequired)
        {
            if(moveDoor)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - (unlockSpeed * Time.deltaTime));
            }

            if (canPlayCo)
            {
                StartCoroutine(UnlockDoorCo());
            }

        }        

        if (transform.position.y <= -12)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + (unlockSpeed * Time.deltaTime));
            stoneOpen.Stop();
        }
    }

    void PlayStoneSound()
    {
        if(stoneOpen)
        {
            if (!stoneOpen.isPlaying)
            {
                stoneOpen.Play();
            }
        }

    }

    public IEnumerator ChangeCamera()
    {
        /*coPlayOnce = true;
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

        levelManager.invincible = false;*/

        yield return null;
    }

    public IEnumerator UnlockDoorCo()
    {
        canPlayCo = false;

        levelManager.invincible = true;

        PlayStoneSound();

        virtualCamera1.gameObject.SetActive(false);
        virtualCamera2.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(startTime);

        moveDoor = true;

        yield return new WaitForSecondsRealtime(4f);

        virtualCamera2.gameObject.SetActive(false);
        virtualCamera1.gameObject.SetActive(true);

        levelManager.invincible = false;

        yield return null;
    }
}
