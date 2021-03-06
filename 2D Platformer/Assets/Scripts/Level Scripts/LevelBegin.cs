﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelBegin : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerCombat playerCombat;
    public Canvas canvasWorld; //canvasMain;

    public GameObject HUD_GO, bars_GO;

    public CinemachineVirtualCamera virtualCamera1, virtualCamera2, virtualCamera3;

    public float cameraHoldTime_1, cameraHoldTime_2, cameraHoldTime_3;
    public bool movePlayer;
    public bool levelBeginCoUsed;

    void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerCombat = FindObjectOfType<PlayerCombat>();

        virtualCamera1.gameObject.SetActive(false);
        virtualCamera2.gameObject.SetActive(true);
        virtualCamera3.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        //runInTime = 1.8f;
        movePlayer = true;
        levelBeginCoUsed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelBeginCoUsed)
        {
            levelBeginCoUsed = true;
            StartCoroutine(LevelBeginCo());
        }

        if (movePlayer)
        {
            playerMovement.myRigidbody.velocity = new Vector2(playerMovement.moveSpeed, playerMovement.myRigidbody.velocity.y);
        }
    }

    public IEnumerator LevelBeginCo()
    {   
        virtualCamera1.gameObject.SetActive(false);
        virtualCamera2.gameObject.SetActive(true);
        virtualCamera3.gameObject.SetActive(false);

        //canvasMain.enabled = false;
        canvasWorld.enabled = false;
        HUD_GO.SetActive(false);
        bars_GO.SetActive(false);

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

        //canvasMain.enabled = true;
        canvasWorld.enabled = true;
        HUD_GO.SetActive(true);
        bars_GO.SetActive(true);

        yield return null;
    }
}
