using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float lifetime = 3f;

    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
