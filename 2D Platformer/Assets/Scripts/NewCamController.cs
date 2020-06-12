using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NewCamController : MonoBehaviour
{
    public bool followTarget;
    public CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        //virtualCamera = GetComponent<CinemachineVirtualCamera>();
        //followTarget = true;
    }

    void Update()
    {
        if(!followTarget)
        {
            //virtualCamera.Follow = null;
            //virtualCamera.enabled = true;
        }
    }
}
