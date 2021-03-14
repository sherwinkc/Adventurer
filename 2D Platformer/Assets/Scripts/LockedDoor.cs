using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LockedDoor : MonoBehaviour
{
    public LevelManager levelManager;
    public PlayerMovement playerMov;
    public PlayerCombat playerCom;
    public Rigidbody2D playerRB;

    public GameObject mountain;

    public float unlockSpeed;
    public float startTime;
    public int keysRequired;

    //Virtual Camera
    public CinemachineVirtualCamera virtualCamera1;
    public CinemachineVirtualCamera virtualCamera2;

    public bool canPlayCo = true;
    public bool moveDoor = false;

    //Find all enemies
    public Bird_Controller[] birds;
    public SpiderController[] spiders;
    public Fire_Skel_Controller[] redSkeletons;
    public Enemy_Behaviour[] whiteSkeletons;

    //Audio
    public AudioSource stoneOpen;

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        playerMov = FindObjectOfType<PlayerMovement>();
        playerCom = FindObjectOfType<PlayerCombat>();
        
        if(mountain != null)
        {
            mountain.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(levelManager.keyCount <= 0)
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

        //Find all enemies and turn them off briefly
        birds = FindObjectsOfType<Bird_Controller>();
        spiders = FindObjectsOfType<SpiderController>();
        redSkeletons = FindObjectsOfType<Fire_Skel_Controller>();
        whiteSkeletons = FindObjectsOfType<Enemy_Behaviour>();

        //Iterate through Birds
        for (int i = 0; i < birds.Length; i++)
        {
            birds[i].canMoveAndAttack = false;
        }

        //Iterate through Spiders
        for (int i = 0; i < spiders.Length; i++)
        {
            spiders[i].canMoveAndAttack = false;
        }

        //iterate through red skeletons
        for (int i = 0; i < redSkeletons.Length; i++)
        {
            redSkeletons[i].canMoveAndAttack = false;
        }

        //iterate through white skeletons
        for (int i = 0; i < whiteSkeletons.Length; i++)
        {
            whiteSkeletons[i].canMoveAndAttack = false;
        }

        //stop player from moving
        if (playerRB != null)
        {
            playerRB.velocity = Vector3.zero;
        }

        playerMov.canMove = false;
        playerCom.canMove = false;

        PlayStoneSound();

        virtualCamera1.gameObject.SetActive(false);
        virtualCamera2.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(startTime);

        moveDoor = true;

        yield return new WaitForSecondsRealtime(2f);

        virtualCamera2.gameObject.SetActive(false);
        virtualCamera1.gameObject.SetActive(true);

        levelManager.invincible = false;

        if (playerRB != null)
        {
            playerRB.velocity = Vector3.zero;
        }

        playerMov.canMove = true;
        playerCom.canMove = true;

        yield return new WaitForSecondsRealtime(2f);

        //turn on birds
        for (int i = 0; i < birds.Length; i++)
        {
            birds[i].canMoveAndAttack = true;
        }

        //turn on spiders
        for (int i = 0; i < spiders.Length; i++)
        {
            spiders[i].canMoveAndAttack = true;
        }

        //turn on red skeletons
        for (int i = 0; i < redSkeletons.Length; i++)
        {
            redSkeletons[i].canMoveAndAttack = true;
        }

        for (int i = 0; i < whiteSkeletons.Length; i++)
        {
            whiteSkeletons[i].canMoveAndAttack = true;
        }

        yield return new WaitForSecondsRealtime(2f);

        if (mountain != null)
        {
            mountain.SetActive(false);
        }

        yield return null;
    }
}
