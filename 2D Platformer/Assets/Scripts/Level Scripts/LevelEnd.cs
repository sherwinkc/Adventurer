using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class LevelEnd : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerCombat playerCombat;
    private LevelManager theLevelManager;
    public LevelMusicManager levelMusicMan;

    public CinemachineVirtualCamera virtualCamera;
    public Animator animator;
    //public FadeToBlack fadeToBlack;
    public Upgrades upgrades;

    public string levelToLoad;
    public float waitToMove, waitToLoad;
    private bool movePlayer;
    public bool coActive = false;
    
    //public bool fadingOutMusic = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerCombat = FindObjectOfType<PlayerCombat>();
        theLevelManager = FindObjectOfType<LevelManager>();
        upgrades = FindObjectOfType<Upgrades>();
        //fadeToBlack = FindObjectOfType<FadeToBlack>();
        levelMusicMan = FindObjectOfType<LevelMusicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movePlayer)
        {
            playerMovement.myRigidbody.velocity = new Vector2(playerMovement.moveSpeed, playerMovement.myRigidbody.velocity.y);
        }

        /*if(fadingOutMusic)
        {
            theLevelManager.levelMusic_1_1.volume -= Time.deltaTime / 25f; 
            theLevelManager.prologue_Music.volume -= Time.deltaTime / 25f;
            theLevelManager.village_music.volume -= Time.deltaTime / 25f;
        }

        if(theLevelManager.levelMusic_1_1.volume <= 0f)
        {
            theLevelManager.levelMusic_1_1.volume = 0f;
            fadingOutMusic = false;
        }

        if (theLevelManager.prologue_Music.volume <= 0f)
        {
            theLevelManager.prologue_Music.volume = 0f;
            fadingOutMusic = false;
        }

        if (theLevelManager.village_music.volume <= 0f)
        {
            theLevelManager.village_music.volume = 0f;
            fadingOutMusic = false;
        }*/
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
        coActive = true;
        playerMovement.canMove = false;
        playerCombat.canMove = false;

        //TODO - Not working now, the camera is now following the player on exit
        virtualCamera.Follow = null;

        theLevelManager.invincible = true;

        if (theLevelManager != null)
        {
            //theLevelManager.levelMusic.Stop();
            levelMusicMan. fadingOutMusic = true;
            theLevelManager.gameOverMusic.Play();
        }

        playerMovement.myRigidbody.velocity = Vector3.zero;

        //Set Player Prefs here
        SetPlayerPrefs();

        yield return new WaitForSeconds(waitToMove);

        movePlayer = true;

        /*if (fadeToBlack != null) //checking if there is a black screen game object
        {
            //fadeToBlack.fadeToBlack = true;
        }*/

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
        //double jump
        //PlayerPrefs.SetInt("DoubleJump", 0);

        //Move speed
        PlayerPrefs.SetFloat("PlayerMoveSpeed", playerMovement.moveSpeed);
        //Debug.Log("PP - PlayerMoveSpeed (Level End Script) = " + PlayerPrefs.GetFloat("PlayerMoveSpeed"));

        //jump speed
        PlayerPrefs.SetFloat("PlayerJumpSpeed", playerMovement.jumpSpeed);

        //dash speed
        PlayerPrefs.SetFloat("PlayerDashSpeed", playerMovement.dashSpeed);

        //dash cooldown
        PlayerPrefs.SetFloat("PlayerDashCooldown", playerMovement.dashCooldownAmount);

        //Attack damage
        PlayerPrefs.SetInt("PlayerAttackDamage", playerCombat.attackDamage);

        //attack time
        PlayerPrefs.SetFloat("PlayerAttackTime", playerCombat.attackRate);

        //attack range
        PlayerPrefs.SetFloat("PlayerAttackRange", playerCombat.attackRange);

        //super recharge rate
        PlayerPrefs.SetFloat("PlayerSuperRecharge", playerCombat.superRechargeRate);

        //super amount returned
        PlayerPrefs.SetFloat("PlayerSuperReturned", upgrades.superAmountReturned);

        //stamina max
        PlayerPrefs.SetFloat("StaminaMax", playerCombat.staminaMax);

        //stamina recharge rate
        PlayerPrefs.SetFloat("StaminaRechargeRate", playerCombat.staminaRechargeRate);

        //stamina attack cost
        PlayerPrefs.SetFloat("StaminaAttackCost", playerCombat.attackCost);

        //stamina jump cost
        PlayerPrefs.SetFloat("StaminaJumpCost", playerMovement.jumpCost);

        //stamina dash cost
        PlayerPrefs.SetFloat("StaminaDashCost", playerMovement.rollCost);
    }
}
