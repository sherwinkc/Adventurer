using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    private void Awake()
    {

    }

    void Start()
    {
        if (VirtualCamera != null)
        {
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        }

        
        //Debug.Log("VirtualCamera =" + VirtualCamera);
        //Debug.Log("virtualCameraNoise = " + virtualCameraNoise);
    }

    void Update()
    {
        //Debug.Log("VirtualCamera =" + VirtualCamera);
        //Debug.Log("virtualCameraNoise null" + VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>());
        //Debug.Log("virtualCameraNoise.m_AmplitudeGain =" + virtualCameraNoise.m_AmplitudeGain);
        //Debug.Log("virtualCameraNoise.m_FrequencyGain =" + virtualCameraNoise.m_FrequencyGain);

    }   

    public IEnumerator Shake (float ShakeDuration, float ShakeAmplitude, float ShakeFrequency)
    {
        virtualCameraNoise.m_AmplitudeGain = ShakeAmplitude;
        virtualCameraNoise.m_FrequencyGain = ShakeFrequency;

        yield return new WaitForSeconds(ShakeDuration);

        virtualCameraNoise.m_AmplitudeGain = 0f;
        virtualCameraNoise.m_FrequencyGain = 0f;

        yield return 0;
    }
}