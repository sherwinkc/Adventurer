using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class ParallaxNew : MonoBehaviour
{
    //public Transform cam;
    //public Transform cam2;

    public CinemachineVirtualCamera cam;
    public LevelBegin levelBegin;

    public float relativeMove = 0f;
    public bool lockY = false;
    private float offset;

    private void Awake()
    {

    }

    private void Start()
    {
        offset = transform.position.x;
        levelBegin = FindObjectOfType<LevelBegin>();
    }

    // Update is called once per frame
    void Update()
    {
        if(levelBegin) //check if level begin exists
        {
            //setting the camera
            if (levelBegin.virtualCamera3.gameObject.activeSelf == true)
            {
                cam = levelBegin.virtualCamera3;
            }
            else if ((levelBegin.virtualCamera2.gameObject.activeSelf == true))
            {
                cam = levelBegin.virtualCamera2;
            }
            else if ((levelBegin.virtualCamera1.gameObject.activeSelf == true))
            {
                cam = levelBegin.virtualCamera1;
            }
            else
            {
                return;
            }

            if (lockY)
            {
                transform.position = new Vector3((cam.transform.position.x * relativeMove) + offset, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3((cam.transform.position.x * relativeMove) + offset, transform.position.y, transform.position.z);
            }
        }
    }
}
