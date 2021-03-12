using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelBegin_Land : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;
    //public Canvas canvasWorld; //canvasMain;
    public GameObject HUD_GO, bars_GO, dashBar, radialBar;

    public CinemachineVirtualCamera virtualCamera1, virtualCamera2; // virtualCamera3;

    public float cameraHoldTime_1, cameraHoldTime_2, cameraHoldTime_3;
    public bool movePlayer;
    public bool coUsed;

    private void Awake()
    {
        virtualCamera1.gameObject.SetActive(false);
        virtualCamera2.gameObject.SetActive(true);

        HUD_GO.SetActive(false);
        bars_GO.SetActive(false);
        dashBar.SetActive(false);
        radialBar.SetActive(false);
    }

    void Start()
    {

    }

    void Update()
    {
        if (!coUsed)
        {
            StartCoroutine(LevelBeginCo());
            coUsed = true;
        }

        if (movePlayer)
        {
            playerMovement.myRigidbody.velocity = new Vector2(4f, playerMovement.myRigidbody.velocity.y);
        }
    }

    public IEnumerator LevelBeginCo()
    {
        virtualCamera1.gameObject.SetActive(false);
        virtualCamera2.gameObject.SetActive(true);

        movePlayer = true;

        playerMovement.canMove = false;
        playerCombat.canMove = false;

        yield return new WaitForSeconds(cameraHoldTime_1);

        virtualCamera1.gameObject.SetActive(true);
        virtualCamera2.gameObject.SetActive(false);

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
}
