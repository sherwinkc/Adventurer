using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class LevelEnd : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerCombat playerCombat;
    public CinemachineVirtualCamera virtualCamera;
    private LevelManager theLevelManager;
    public Animator animator;
    public FadeToBlack fadeToBlack;


    public string levelToLoad;
    public float waitToMove, waitToLoad;
    private bool movePlayer;
    public bool coActive;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerCombat = FindObjectOfType<PlayerCombat>();
        theLevelManager = FindObjectOfType<LevelManager>();
        animator = GetComponent<Animator>();
        //virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();

        fadeToBlack = FindObjectOfType<FadeToBlack>();

        coActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(movePlayer)
        {
            playerMovement.myRigidbody.velocity = new Vector2(playerMovement.moveSpeed, playerMovement.myRigidbody.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && coActive == false)
        {
            animator.SetBool("isFlagOpen", true);
            StartCoroutine("LevelEndCo");
        }
    }

    public IEnumerator LevelEndCo()
    {
        //Debug.Log("LevelEndCo Started");
        coActive = true;
        playerMovement.canMove = false;
        playerCombat.canMove = false;

        //TODO - Not working now, the camera is now following the player on exit
        virtualCamera.Follow = null;
        //Debug.Log("camera = " + virtualCamera);

        //theCamera.followTarget = false; //Needs to change to the new camera

        theLevelManager.invincible = true;

        if (theLevelManager != null)
        {
            theLevelManager.levelMusic.Stop();
            theLevelManager.gameOverMusic.Play();
        }

        playerMovement.myRigidbody.velocity = Vector3.zero;

        //Set Player Prefs here
        SetPlayerPrefs();

        yield return new WaitForSeconds(waitToMove);

        movePlayer = true;

        if (fadeToBlack != null) //checking if there is a black screen game object
        {
            fadeToBlack.fadeToBlack = true;
        }

        yield return new WaitForSeconds(waitToLoad);

        coActive = false;
        SceneManager.LoadScene(levelToLoad);

        yield return null;
    }

    public void SetPlayerPrefs()
    {
        //Orb Count
        PlayerPrefs.SetInt("OrbCount", theLevelManager.coinCount);
        //Lives
        PlayerPrefs.SetInt("PlayerLives", theLevelManager.currentLives);
        //skill points
        PlayerPrefs.SetInt("SkillPoints", theLevelManager.skillPoints);
        //Upgrades

    }
}
