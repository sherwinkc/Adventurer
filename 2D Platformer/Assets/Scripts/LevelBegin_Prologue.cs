using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelBegin_Prologue : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerCombat playerCombat;
    //public Canvas canvasMain, canvasWorld;

    public CinemachineVirtualCamera virtualCamera1, virtualCamera2;

    public float cameraHoldTime_1, cameraHoldTime_2;
    public bool levelBeginCoUsed = false;

    private void Awake()
    {
        virtualCamera1.gameObject.SetActive(false);
        virtualCamera2.gameObject.SetActive(true);

        playerMovement = FindObjectOfType<PlayerMovement>();
        playerCombat = FindObjectOfType<PlayerCombat>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!levelBeginCoUsed)
        {
            levelBeginCoUsed = true;
            StartCoroutine(LevelBeginCo());
        }
    }

    public IEnumerator LevelBeginCo()
    {
        virtualCamera1.gameObject.SetActive(false);
        virtualCamera2.gameObject.SetActive(true);

        //canvasMain.enabled = false;
        //canvasWorld.enabled = false;

        playerMovement.canMove = false;
        playerCombat.canMove = false;

        yield return new WaitForSeconds(cameraHoldTime_1);

        virtualCamera1.gameObject.SetActive(true);
        virtualCamera2.gameObject.SetActive(false);

        yield return new WaitForSeconds(cameraHoldTime_2);

        //yield return new WaitForSeconds(cameraHoldTime_2);

        //virtualCamera1.gameObject.SetActive(true);
        //virtualCamera2.gameObject.SetActive(false);       

        //movePlayer = false;

        playerMovement.canMove = true;
        playerCombat.canMove = true;

        //canvasMain.enabled = true;
        //canvasWorld.enabled = true;

        yield return null;
    }
}
