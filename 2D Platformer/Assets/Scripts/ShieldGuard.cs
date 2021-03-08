using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGuard : MonoBehaviour
{
    public Transform blockTransform;
    public GameObject block;
    public AudioSource blockSFX;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InstantBlockVFX()
    {
        Instantiate(block, blockTransform.transform.position, blockTransform.transform.rotation);
        blockSFX.Play();
    }
}
