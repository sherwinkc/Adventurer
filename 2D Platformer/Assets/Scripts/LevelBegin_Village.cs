using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelBegin_Village : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;

    public CinemachineVirtualCamera virtualCamera1;
    public CinemachineVirtualCamera virtualCamera2;

    public float cameraHoldTime_1, cameraHoldTime_2;

    public bool movePlayer = false;

    public bool coUsed = false;

    public void Awake()
    {
        virtualCamera1.gameObject.SetActive(false);
        virtualCamera2.gameObject.SetActive(true);
    }

    void Start()
    {

    }


    void Update()
    {
        if(!coUsed)
        {
            StartCoroutine(LevelBeginCo());
        }

        if (movePlayer)
        {   
            playerMovement.myRigidbody.velocity = new Vector2(5f, playerMovement.myRigidbody.velocity.y);
        }
    }

    public IEnumerator LevelBeginCo()
    {
        coUsed = true;

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

        yield return null;
    }
}
