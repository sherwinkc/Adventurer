using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Level_End_Boss : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerCombat playerCombat;
    public ZombieAmbience zombAm;
    //private LevelManager theLevelManager;
    //public LevelMusicManager levelMusicMan;

    public CinemachineVirtualCamera virtualCamera1, virtualCamera2;

    public GameObject HUD_GO, bars_GO, dashBar, radialBar;

    public bool playing = false;

    public string levelToLoad;
    public float waitToLoad;
    public bool coActive = false;


    //public AudioSource zombieAmbience;

    private void Awake()
    {
        zombAm = FindObjectOfType<ZombieAmbience>();
        virtualCamera2.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerCombat = FindObjectOfType<PlayerCombat>();
        //theLevelManager = FindObjectOfType<LevelManager>();
        //upgrades = FindObjectOfType<Upgrades>();
        //levelMusicMan = FindObjectOfType<LevelMusicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (movePlayer)
        {
            playerMovement.myRigidbody.velocity = new Vector2(playerMovement.moveSpeed, playerMovement.myRigidbody.velocity.y);
        }*/

        /*if (fadingOutMusic)
        {
            theLevelManager.gameOverMusic.volume -= Time.deltaTime / 5f;
        }*/

        if(playing)
        {
            zombAm.ambience.volume += Time.deltaTime / 100f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && coActive == false)
        {
            StartCoroutine(LevelEndCo());
        }
    }

    public IEnumerator LevelEndCo()
    {
        coActive = true;

        HUD_GO.SetActive(false);
        bars_GO.SetActive(false);
        dashBar.SetActive(false);
        radialBar.SetActive(false);

        playerMovement.canMove = false;
        playerCombat.canMove = false;

        playerMovement.myRigidbody.velocity = Vector3.zero;

        virtualCamera1.gameObject.SetActive(false);
        virtualCamera2.gameObject.SetActive(true);

        zombAm.ambience.volume = 0f;
        playing = true;
        zombAm.ambience.Play();

        yield return new WaitForSeconds(waitToLoad);

        coActive = false;

        zombAm.ambience.Stop();
        SceneManager.LoadScene(levelToLoad);

        yield return null;
    }
}
