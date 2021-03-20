using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float lifetime;
    public bool isOn = false;

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            lifetime -= Time.deltaTime;

            if (lifetime <= 0f)
            {
                //Destroy(gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}
