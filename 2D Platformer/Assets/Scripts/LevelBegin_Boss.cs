using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelBegin_Boss : MonoBehaviour
{
    //private PlayerMovement playerMovement;
    //private PlayerCombat playerCombat;
    public Canvas canvasWorld; //canvasMain;
    public GameObject HUD_GO, bars_GO;

    public Skel_King_Script skel_King_Script;
    public GameObject collider_L, collider_R;

    public GameObject bossBar;
    public bool functionUsed = false;

    public CinemachineVirtualCamera virtualCamera1, virtualCamera2; // virtualCamera3;

    public float cameraHoldTime_1, cameraHoldTime_2, cameraHoldTime_3;
    public bool movePlayer;
    public bool levelBeginCoUsed;

    private void Awake()
    {
        skel_King_Script = FindObjectOfType<Skel_King_Script>();

        virtualCamera1.gameObject.SetActive(true);
        virtualCamera2.gameObject.SetActive(false);

        collider_L.SetActive(false);
        collider_R.SetActive(false);
        bossBar.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        //playerMovement = FindObjectOfType<PlayerMovement>();
        //playerCombat = FindObjectOfType<PlayerCombat>();

        //virtualCamera2.gameObject.SetActive(true);
        //virtualCamera3.gameObject.SetActive(false);

        //runInTime = 1.8f;
        //movePlayer = true;
        //levelBeginCoUsed = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!levelBeginCoUsed)
        {
            levelBeginCoUsed = true;
            StartCoroutine(LevelBeginCo());
        }

        if (movePlayer)
        {
            playerMovement.myRigidbody.velocity = new Vector2(playerMovement.moveSpeed, playerMovement.myRigidbody.velocity.y);
        }*/

        if (skel_King_Script.currentHealth <= 0 && !functionUsed)
        {
            OnBossDeath();
            functionUsed = true;
        }
    }

    public IEnumerator LevelBeginCo()
    {
        /*virtualCamera1.gameObject.SetActive(false);
        virtualCamera2.gameObject.SetActive(true);
        virtualCamera3.gameObject.SetActive(false);

        canvasMain.enabled = false;
        canvasWorld.enabled = false;

        playerMovement.canMove = false;
        playerCombat.canMove = false;

        yield return new WaitForSeconds(cameraHoldTime_1);

        virtualCamera1.gameObject.SetActive(false);
        virtualCamera2.gameObject.SetActive(false);
        virtualCamera3.gameObject.SetActive(true);

        yield return new WaitForSeconds(cameraHoldTime_2);

        virtualCamera1.gameObject.SetActive(true);
        virtualCamera2.gameObject.SetActive(false);
        virtualCamera3.gameObject.SetActive(false);

        yield return new WaitForSeconds(cameraHoldTime_3);

        movePlayer = false;

        playerMovement.canMove = true;
        playerCombat.canMove = true;

        canvasMain.enabled = true;
        canvasWorld.enabled = true; */

        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            virtualCamera1.gameObject.SetActive(false);
            virtualCamera2.gameObject.SetActive(true);
            collider_L.SetActive(true);
            collider_R.SetActive(true);
            bossBar.SetActive(true);
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
