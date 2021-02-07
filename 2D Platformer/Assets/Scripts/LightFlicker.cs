using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    public Light2D light2D;

    // Start is called before the first frame update
    void Start()
    {
        light2D = GetComponent<Light2D>();

        InvokeRepeating("Flicker", 0, 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Flicker()
    {
        StartCoroutine(FlickerCo());
    }

    public IEnumerator FlickerCo()
    {
        light2D.intensity = Random.Range(1.7f,1.8f);

        yield return new WaitForSeconds(Random.Range(0.01f,0.3f));

        light2D.intensity = 1.6f;

        yield return null;
    }
}
