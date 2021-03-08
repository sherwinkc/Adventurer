using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Parallax2 : MonoBehaviour
{
    public CinemachineVirtualCamera cam;

    public float relativeMove;
    public bool lockY;
    public float offsetX, offsetY;

    // Start is called before the first frame update
    void Start()
    {
        offsetX = transform.position.x - cam.transform.position.x;
        offsetY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (lockY)
        {
            transform.position = new Vector3((cam.transform.position.x * relativeMove) + offsetX, transform.position.y, transform.position.z);
        }
        else*/
        {
            //transform.position = new Vector3((cam.transform.position.x * relativeMove) + offsetX, (cam.transform.position.y + offsetY) / 2f, transform.position.z);
            //transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, transform.position.z);
            transform.position = new Vector3((cam.transform.position.x * relativeMove) + offsetX, transform.position.y, transform.position.z);
        }

        Debug.Log("OffsetX : " + offsetX);
        Debug.Log("transform.position.x : " + transform.position.x);
        Debug.Log("cam.transform.position.x : " + cam.transform.position.x);
        Debug.Log("transform.position.x - cam.transform.position.x : " + (transform.position.x - cam.transform.position.x));
    }
}
