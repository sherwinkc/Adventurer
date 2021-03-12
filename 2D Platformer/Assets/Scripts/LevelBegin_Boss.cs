using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelBegin_Boss : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;
    //public Canvas canvasWorld;
    public GameObject HUD_GO, bars_GO, dashBar, radialBar;
    public LevelMusicManager levelMusicMan;

    public Skel_King_Script skel_King_Script;
    public GameObject collider_L, collider_R;

    public GameObject bossBar;
    public bool functionUsed = false;

    public CinemachineVirtualCamera virtualCamera1, virtualCamera2, virtualCamera3;

    public float cameraHoldTime_1, cameraHoldTime_2, cameraHoldTime_3;
    public bool movePlayer;
    public bool levelBeginCoUsed;

    private void Awake()
    {
        skel_King_Script = FindObjectOfType<Skel_King_Script>();
        levelMusicMan = FindObjectOfType<LevelMusicManager>();

        virtualCamera1.gameObject.SetActive(false);
        virtualCamera3.gameObject.SetActive(true);
        virtualCamera2.gameObject.SetActive(false); // Boss Cam

        HUD_GO.SetActive(false);
        bars_GO.SetActive(false);
        dashBar.SetActive(false);
        radialBar.SetActive(false);

        collider_L.SetActive(false);
        collider_R.SetActive(false);
        bossBar.SetActive(false);
    }


    void Start()
    {

    }

    void Update()
    {
        if (!levelBeginCoUsed)
        {
            StartCoroutine(LevelBeginCo());
            levelBeginCoUsed = true;
        }

        if (movePlayer)
        {
            playerMovement.myRigidbody.velocity = new Vector2(3f, playerMovement.myRigidbody.velocity.y);
        }

        if (skel_King_Script.currentHealth <= 0 && !functionUsed)
        {
            OnBossDeath();
            functionUsed = true;
        }
    }

    public IEnumerator LevelBeginCo()
    {
        movePlayer = true;

        virtualCamera1.gameObject.SetActive(false);
        virtualCamera3.gameObject.SetActive(true);
        virtualCamera2.gameObject.SetActive(false); // Boss Cam

        playerMovement.canMove = false;
        playerCombat.canMove = false;

        yield return new WaitForSeconds(cameraHoldTime_1);

        virtualCamera1.gameObject.SetActive(true);
        virtualCamera2.gameObject.SetActive(false); // Boss Cam
        virtualCamera3.gameObject.SetActive(false);

        yield return new WaitForSeconds(cameraHoldTime_2);

        movePlayer = false;

        playerMovement.canMove = true;
        playerCombat.canMove = true;

        yield return new WaitForSeconds(cameraHoldTime_3);

        HUD_GO.SetActive(true);
        bars_GO.SetActive(true);
        dashBar.SetActive(true);
        radialBar.SetActive(true);

        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(skel_King_Script.currentHealth > 0) //check if boss has been killed or not
            {
                virtualCamera1.gameObject.SetActive(false);
                virtualCamera2.gameObject.SetActive(true);
                collider_L.SetActive(true);
                collider_R.SetActive(true);
                bossBar.SetActive(true);
                levelMusicMan.PlayBossMusic();
            }
        }
    }

    public void OnBossDeath()
    {
        virtualCamera1.gameObject.SetActive(true);
        virtualCamera2.gameObject.SetActive(false);
        collider_L.SetActive(false);
        collider_R.SetActive(false);
        bossBar.SetActive(false);
    }
}
