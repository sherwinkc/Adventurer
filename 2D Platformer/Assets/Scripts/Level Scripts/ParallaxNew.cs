using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ParallaxNew : MonoBehaviour
{
    //public Transform cam;
    //public Transform cam2;

    public CinemachineVirtualCamera cam, cam2, cam3;

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

        //this is for setting the cam pos in start
        if (levelBegin_P)
        {
            cam = levelBegin_P.virtualCamera1;
        }

        if (levelBegin_V)
        {
            cam = levelBegin_V.virtualCamera1;
        }

        if (levelBegin)
        {
            cam = levelBegin.virtualCamera2;
        }

        if (levelBegin_F)
        {
            cam = levelBegin_F.virtualCamera1;
        }

        if (levelBegin_Land)
        {
            cam = levelBegin_Land.virtualCamera1;
        }

        if (levelBegin_Boss)
        {
            cam = levelBegin_Boss.virtualCamera1;
        }
    }

    void Start()
    {
        offsetX = transform.position.x - cam.transform.position.x; // Cam pos is not set here 
        offsetY = transform.position.y - cam.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Prologue
        if (levelBegin_P) //check if level begin exists
        {
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

        //Village
        if (levelBegin_V) //check if level begin exists
        {
            if (levelBegin_V.virtualCamera2.gameObject.activeSelf == true)
            {
                cam = levelBegin_V.virtualCamera2;
            }
            
            if (levelBegin_V.virtualCamera1.gameObject.activeSelf == true)
            {
                cam = levelBegin_V.virtualCamera1;
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

        //Level1_1 Forest Dark
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

        //Level1_2 Floating Isles
        if (levelBegin_F) //check if level begin exists
        {
            if (lockY)
            {
                transform.position = new Vector3((cam.transform.position.x * relativeMove) + offsetX, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3((cam.transform.position.x * relativeMove) + offsetX, (cam.transform.position.y + offsetY) / 2f, transform.position.z);
            }
        }

        //Level1_3 Land of the Dead
        if (levelBegin_Land) //check if level begin exists
        {
            if (lockY)
            {
                transform.position = new Vector3((cam.transform.position.x * relativeMove) + offsetX, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3((cam.transform.position.x * relativeMove) + offsetX, (cam.transform.position.y + offsetY) / 2f, transform.position.z);
            }
        }

        //Boss Level
        if (levelBegin_Boss) //check if level begin exists
        {
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
    }
}
