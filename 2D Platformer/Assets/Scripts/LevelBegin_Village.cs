using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelBegin_Village : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;

    public CinemachineVirtualCamera virtualCamera1, virtualCamera2;

    public float cameraHoldTime_1, cameraHoldTime_2;

    //public bool levelBeginCoUsed = false;
    public bool movePlayer;

    private void Awake()
    {
        virtualCamera1.gameObject.SetActive(true);
        //virtualCamera2.gameObject.SetActive(true);
    }

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerCombat = FindObjectOfType<PlayerCombat>();

        playerMovement.canMove = false;
        playerCombat.canMove = false;

        movePlayer = true;

        StartCoroutine(LevelBeginCo());
    }


    void Update()
    {
        if (movePlayer)
        {
            playerMovement.myRigidbody.velocity = new Vector2(playerMovement.moveSpeed, playerMovement.myRigidbody.velocity.y);
        }
    }

    public IEnumerator LevelBeginCo()
    {
        yield return new WaitForSeconds(cameraHoldTime_1);

        virtualCamera1.gameObject.SetActive(true);
        //virtualCamera2.gameObject.SetActive(false);

        yield return new WaitForSeconds(cameraHoldTime_2);

        movePlayer = false;

        playerMovement.canMove = true;
        playerCombat.canMove = true;

        yield return null;
    }
}