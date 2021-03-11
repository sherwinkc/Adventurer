using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region Variables
    public PlayerController thePlayer;
    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;
    public CinemachineVirtualCamera virtualCamera;
    public Upgrades upgrades;
    public Canvas worldCanvas;
    public TextFlashManager textFlashMan;

    //Game Objects
    public GameObject deathSplosion;
    public GameObject gameOverScreen;

    public int coinCount;
    private int coinBonusLifeCount;
    public int bonusLifeThreshold;

    public int keyCount;
    public Text coinText;
    public Text keyCountText;
    public Text superText;    

    // variables for the heart/Player health UI
    public Image heart1, heart2, heart3;
    public Sprite heartFull, heartHalf, heartEmpty;
    public int maxHealth, healthCount;

    //Respawn
    public float waitToRespawn;
    private bool respawning;
    public ResetOnRespawn[] objectsToReset;
    public bool respawnCoActive;

    public bool invincible = false;

    //Lives
    public Text livesText;
    public int startingLives, currentLives;

    //Skill Points
    public Text skillPointsText;
    public int skillPoints, startingSkillPoints;

    //Locked Door
    public LockedDoor lockedDoor;

    // Audio
    public AudioSource coinSound, gameOverMusic, hurtSound, levelUpSound, deathSound, keySound;

    #endregion

    private void Awake()
    {
        lockedDoor = FindObjectOfType<LockedDoor>();
        //Delete - this is so the player starts with 0 skill points
        skillPoints = 3;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Find Components
        thePlayer = FindObjectOfType<PlayerController>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerCombat = FindObjectOfType<PlayerCombat>();
        upgrades = FindObjectOfType<Upgrades>();
        textFlashMan = GetComponent<TextFlashManager>();

        //check if player prefs has been set
        PlayerPrefsChecks();
        PlayerPrefChecksUpgrades();

        //start game with full health
        healthCount = maxHealth;

        //set up an array to put all objects that need to reset on respawn
        objectsToReset = FindObjectsOfType<ResetOnRespawn>();

        superText.text = "Super %: " + playerCombat.superAmount;

        if (lockedDoor != null)
        {
            keyCountText.text = "KEYS REQUIRED: " + lockedDoor.keysRequired; //get keys required from the locked door script
            keyCount = lockedDoor.keysRequired;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (healthCount <= 0)
        {
            Respawn();
        }

        //add an extra life when bonus coin count is greater than bonusLifeThreshold
        if (coinBonusLifeCount >= bonusLifeThreshold)
        {
            currentLives += 1;            
            coinBonusLifeCount -= bonusLifeThreshold; // reset the bonus life count to zero
            skillPoints += 1;
            StartCoroutine(textFlashMan.FlashText_Skill());
            levelUpSound.Play();
        }
        
        // TODO gain extra life, when it's double the amount of coins

        //update UI every frame
        livesText.text = "LIVES x" + currentLives;
        skillPointsText.text = "SKILL POINTS: " + skillPoints;
        superText.text = "Super %: " + playerCombat.superAmount;

        if (lockedDoor != null)
        {
            keyCountText.text = "KEYS REQUIRED: " + keyCount;
        }
    }

    //Check Player Prefs
    public void PlayerPrefsChecks()
    {
        if (PlayerPrefs.HasKey("OrbCount"))
        {
            coinCount = PlayerPrefs.GetInt("OrbCount");
        }
        //starting coin count is 0
        coinText.text = "ORBS: " + coinCount;

        //Player Lives
        if (PlayerPrefs.HasKey("PlayerLives"))
        {
            currentLives = PlayerPrefs.GetInt("PlayerLives");
        }
        else
        {
            //sets the amount of starting lives and updates the UI.
            currentLives = startingLives;
        }
        //starting lives = 5
        livesText.text = "LIVES x" + currentLives;

        //skill points
        if (PlayerPrefs.HasKey("SkillPoints"))
        {
            skillPoints = PlayerPrefs.GetInt("SkillPoints");
        }
        //starting skill points is 0
        skillPointsText.text = "SKILL POINTS: " + skillPoints;
    }

    public void PlayerPrefChecksUpgrades()
    {
        /*if(PlayerPrefs.HasKey("PlayerMoveSpeed"))
        {
            playerMovement.moveSpeed = PlayerPrefs.GetInt("PlayerMoveSpeed");
        }*/

    }

    //Created function
    public void Respawn()
    {
        if (!respawning)
        {
            //minus one life and update UI        
            currentLives -= 1;
            livesText.text = "LIVES x" + currentLives;

            //check if lives is greater that to call respawn coroutine function. Else the player is inactive and the game overs screen shows
            if (currentLives >= 0)
            {
                respawning = true;
                StartCoroutine(RespawnCo());
            }
            else
            {
                currentLives = 0;
                livesText.text = "LIVES x" + currentLives;
                deathSound.Play(); // not playing because game object is deactivated
                thePlayer.gameObject.SetActive(false);
                gameOverScreen.SetActive(true);

                //stop level music audio, and play game over music
                //levelMusic_1_1.Stop();
                //gameOverMusic.Play();
            }
        }
    }

    //Coroutine can run seperate from the main loop. Bit like Alarm?
    public IEnumerator RespawnCo()
    {
        respawnCoActive = true;

        worldCanvas.enabled = false;

        //sets player inactive in the world
        thePlayer.gameObject.SetActive(false);

        //Create explosion particle effect after deactivating/killing the player
        Instantiate(deathSplosion, thePlayer.transform.position, thePlayer.transform.rotation);
        deathSound.Play();

        //delays the respawn by an amount of seconds
        yield return new WaitForSeconds(waitToRespawn);

        respawnCoActive = false;

        //sets health back to max, after death
        healthCount = maxHealth;

        //respawning loop prevention
        respawning = false;

        //Call the Update the heart UI function
        UpdateHeartMeter();

        //key
        //keyCount = 0; //Keys shouldn't reset upon death
        keyCountText.text = "KEYS REQUIRED: " + keyCount;

        //reset orb count and bonus life count to zero and update UI
        coinCount /= 2; // Do we need to divide the count count on death ???
        coinText.text = "ORBS: " + coinCount;
        coinBonusLifeCount = 0;

        //reset player position and reset camera
        thePlayer.transform.position = thePlayer.respawnPosition;
        virtualCamera.enabled = false;
        virtualCamera.enabled = true;

        //sets player active in the world
        thePlayer.gameObject.SetActive(true);
        worldCanvas.enabled = true;

        //reset knockback counter
        playerMovement.knockbackCounter = 0;

        //For loop - going through each array element and resets them (function) and sets each one to active
        /*for (int i = 0; i < objectsToReset.Length; i++)
        {
            objectsToReset[i].gameObject.SetActive(false);
            objectsToReset[i].gameObject.SetActive(true);
            objectsToReset[i].ResetObject();
        }*/
    }

    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;

        //Adds to bonus coin count too
        coinBonusLifeCount += coinsToAdd; 

        //update UI when collecting a coin
        coinText.text = "ORBS: " + coinCount;
        StartCoroutine(textFlashMan.FlashText_Orb());

        //play coin sound
        coinSound.pitch = Random.Range(0.95f, 1.05f);
        coinSound.Play();

        playerCombat.superAmount += 0.33f;
    }

    public void AddKeys(int keysToAdd)
    {
        keyCount -= keysToAdd;

        keyCountText.text = "KEYS REQUIRED " + keyCount;
        StartCoroutine(textFlashMan.FlashText_Key());

        //TODO change to a different sound
        keySound.Play();
    }

    //hurt player function
    public void HurtPlayer(int damageToTake)
    {
        if (!invincible) //if player isn't invincible the player can take damage
        {
            healthCount -= damageToTake;

            //Call the Update the heart UI function
            UpdateHeartMeter();

            //as the level manager knows the player use thePlayer.hurtSound.play here
            HurtSound();

            //call knock back function when colliding with the enemy
            //playerMovement.Knockback();
        }
    }

    //health pick
    public void GiveHealth(int healthToGive)
    {
        healthCount += healthToGive;

        //can't go above 6 or max health
        if(healthCount > maxHealth)
        {
            healthCount = maxHealth;
        }
        //play coin sound
        coinSound.Play();

        //update UI
        UpdateHeartMeter();
    }

    //Swtich Statement to change the heart sprite configuration depending on player health count.
    public void UpdateHeartMeter()
    {
        switch(healthCount)
        {
            case 6:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                return;
            case 5:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;
                return;
            case 4:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                return;
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                heart3.sprite = heartEmpty;
                return;
            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;
            case 1:
                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;
            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;

            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;
        }
    }

    public void AddLives(int livesToAdd)
    {
        //add lives and update UI
        currentLives += livesToAdd;
        livesText.text = "Lives x" + currentLives;

        //play coin sound
        //coinSound.Play();
    }

    void HurtSound()
    {
        hurtSound.pitch = (Random.Range(0.9f, 1f));
        hurtSound.Play();
    }
}
