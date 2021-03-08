using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float lifetime;


    void Start()
    {
        
    }


    void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime <= 0f)
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
    }
}
