﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelBegin : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerCombat playerCombat;
    public CinemachineVirtualCamera virtualCamera1;
    public CinemachineVirtualCamera virtualCamera2;
    public Enemy enemy;

    //public ParallaxNew parralaxNew;
    //private LevelManager theLevelManager;

    public float runInTime;
    public bool movePlayer;
    public bool levelBeginCoUsed;


    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerCombat = FindObjectOfType<PlayerCombat>();
        enemy = FindObjectOfType<Enemy>();
        
        //parralaxNew = FindObjectOfType<ParallaxNew>();
        //theLevelManager = FindObjectOfType<LevelManager>();
        //virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();

        runInTime = 1.8f;
        movePlayer = true;
        levelBeginCoUsed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelBeginCoUsed)
        {
            StartCoroutine(LevelBeginCo());
        }

        if (movePlayer)
        {
            playerMovement.myRigidbody.velocity = new Vector2(playerMovement.moveSpeed, playerMovement.myRigidbody.velocity.y);
        }

        //Debug.Log("playerMovement.myRigidbody.velocity = " + playerMovement.myRigidbody.velocity);
        //Debug.Log("playerMovement.moveSpeed = " + playerMovement.moveSpeed);
        //Debug.Log("playerMovement.canMove = " + playerMovement.canMove);
        //Debug.Log("playerCombat.canMove = " + playerCombat.canMove);
    }

    public IEnumerator LevelBeginCo()
    {   
        virtualCamera1.gameObject.SetActive(false);        
        virtualCamera2.gameObject.SetActive(true);

        playerMovement.canMove = false;
        playerCombat.canMove = false;        

        yield return new WaitForSeconds(runInTime);

        movePlayer = false;

        //playerMovement.myRigidbody.velocity = Vector2.zero;

        playerMovement.canMove = true;
        playerCombat.canMove = true;

        virtualCamera1.gameObject.SetActive(true);
        virtualCamera2.gameObject.SetActive(false);

        //Camera on camerashake component need to be set again at the end of level begin
        playerCombat.cameraShake = FindObjectOfType<CameraShake>();
        playerMovement.cameraShake = FindObjectOfType<CameraShake>();
        enemy.cameraShake = FindObjectOfType<CameraShake>();        

        levelBeginCoUsed = true;

        yield return null;
    }
}
