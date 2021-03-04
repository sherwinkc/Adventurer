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
    public LevelBegin_Prologue levelBegin_P;
    public LevelBegin_Village levelBegin_V;
    public LevelBegin_Floating levelBegin_F;
    public LevelBegin_Boss levelBegin_Boss;
    public LevelBegin_Land levelBegin_Land;

    public float relativeMove;
    public bool lockY;
    public float offsetX, offsetY;

    private void Awake()
    {
        levelBegin = FindObjectOfType<LevelBegin>();
        levelBegin_P = FindObjectOfType<LevelBegin_Prologue>();
        levelBegin_V = FindObjectOfType<LevelBegin_Village>();
        levelBegin_F = FindObjectOfType<LevelBegin_Floating>();
        levelBegin_Boss = FindObjectOfType<LevelBegin_Boss>();
        levelBegin_Land = FindObjectOfType<LevelBegin_Land>();
    }

    private void Start()
    {
        offsetX = transform.position.x;
        offsetY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelBegin) //check if level begin exists
        {
            //setting the camera
            if (levelBegin.virtualCamera3.gameObject.activeSelf == true)
            {
                cam = levelBegin.virtualCamera3;
            }
            else if (levelBegin.virtualCamera2.gameObject.activeSelf == true)
            {
                cam = levelBegin.virtualCamera2;
            }
            else if (levelBegin.virtualCamera1.gameObject.activeSelf == true)
            {
                cam = levelBegin.virtualCamera1;
            }
            else
            {
                return;
            }

            if (lockY)
            {
                transform.position = new Vector3((cam.transform.position.x * relativeMove) + offsetX, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3((cam.transform.position.x * relativeMove) + offsetX, (cam.transform.position.y + offsetY) / 2f, transform.position.z);
            }
        }

        if (levelBegin_P) //check if level begin exists
        {
            //setting the camera
            /*if (levelBegin_P.virtualCamera2.gameObject.activeSelf == true)
            {
                cam = levelBegin_P.virtualCamera2;
            }
            else if (levelBegin_P.virtualCamera1.gameObject.activeSelf == true)
            {
                cam = levelBegin_P.virtualCamera1;
            }
            else
            {
                return;
            }*/

            cam = levelBegin_P.virtualCamera1;
            //offset = cam.transform.position.x - transform.position.x;

            if (lockY)
            {
                //transform.position = new Vector3((cam.transform.position.x * relativeMove) + offset, transform.position.y, transform.position.z);
                transform.position = new Vector3((cam.transform.position.x * relativeMove) + offsetX, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3((cam.transform.position.x * relativeMove) + offsetX, (cam.transform.position.y + offsetY) / 2f, transform.position.z);
            }
        }

        if (levelBegin_V) //check if level begin exists
        {
            //setting the camera
            /*if (levelBegin_P.virtualCamera2.gameObject.activeSelf == true)
            {
                cam = levelBegin_P.virtualCamera2;
                //cam = levelBegin_P.virtualCamera1;
            }
            else if (levelBegin_P.virtualCamera1.gameObject.activeSelf == true)
            {
                cam = levelBegin_P.virtualCamera1;
            }
            else
            {
                return;
            }*/

            cam = levelBegin_V.virtualCamera1;

            if (lockY)
            {
                transform.position = new Vector3((cam.transform.position.x * relativeMove) + offsetX, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3((cam.transform.position.x * relativeMove) + offsetX, (cam.transform.position.y + offsetY) / 2f, transform.position.z);
            }
        }

        if (levelBegin_F) //check if level begin exists
        {
            //setting the camera
            /*if (levelBegin_P.virtualCamera2.gameObject.activeSelf == true)
            {
                cam = levelBegin_P.virtualCamera2;
                //cam = levelBegin_P.virtualCamera1;
            }
            else if (levelBegin_P.virtualCamera1.gameObject.activeSelf == true)
            {
                cam = levelBegin_P.virtualCamera1;
            }
            else
            {
                return;
            }*/

            cam = levelBegin_F.virtualCamera1;

            if (lockY)
            {
                transform.position = new Vector3((cam.transform.position.x * relativeMove) + offsetX, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3((cam.transform.position.x * relativeMove) + offsetX, (cam.transform.position.y + offsetY) / 2f, transform.position.z);
            }
        }

        if (levelBegin_Boss) //check if level begin exists
        {
            //setting the camera
            /*if (levelBegin_P.virtualCamera2.gameObject.activeSelf == true)
            {
                cam = levelBegin_P.virtualCamera2;
                //cam = levelBegin_P.virtualCamera1;
            }
            else if (levelBegin_P.virtualCamera1.gameObject.activeSelf == true)
            {
                cam = levelBegin_P.virtualCamera1;
            }
            else
            {
                return;
            }*/

            cam = levelBegin_Boss.virtualCamera1;

            if (lockY)
            {
                transform.position = new Vector3((cam.transform.position.x * relativeMove) + offsetX, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3((cam.transform.position.x * relativeMove) + offsetX, (cam.transform.position.y + offsetY) / 2f, transform.position.z);
            }
        }

        if (levelBegin_Land) //check if level begin exists
        {
            //setting the camera
            /*if (levelBegin_P.virtualCamera2.gameObject.activeSelf == true)
            {
                cam = levelBegin_P.virtualCamera2;
                //cam = levelBegin_P.virtualCamera1;
            }
            else if (levelBegin_P.virtualCamera1.gameObject.activeSelf == true)
            {
                cam = levelBegin_P.virtualCamera1;
            }
            else
            {
                return;
            }*/

            cam = levelBegin_Land.virtualCamera1;

            if (lockY)
            {
                transform.position = new Vector3((cam.transform.position.x * relativeMove) + offsetX, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3((cam.transform.position.x * relativeMove) + offsetX, (cam.transform.position.y + offsetY) / 2f, transform.position.z);
            }
        }
    }
}
