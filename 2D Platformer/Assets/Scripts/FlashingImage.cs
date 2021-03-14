using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingImage : MonoBehaviour
{
    public Image img;
    public float transparency;
    public bool decreasing;
    public bool increasing;
    public bool coInUse = false;

    public float flashTime;

    public void Awake()
    {
        img = GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        transparency = 0f;
        img.color = new Color(1, 1, 1, 0);
        
        decreasing = false;
        increasing = true;

        StartCoroutine(FlashingCo());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(img.color.a);
        //Debug.Log(transparency);
        
        if(increasing && !decreasing)
        {
            transparency += Time.deltaTime;
        }

        if(!increasing && decreasing)
        {
            transparency -= Time.deltaTime;
        }        
        
        img.color = new Color(1, 1, 1, transparency);

        if(!coInUse)
        {
            StartCoroutine(FlashingCo());
        }
    }

    public IEnumerator FlashingCo()
    {
        coInUse = true;
        increasing = true;
        decreasing = false;

        yield return new WaitForSeconds(flashTime);

        increasing = false;
        decreasing = true;

        yield return new WaitForSeconds(flashTime);

        increasing = true;
        decreasing = false;
        coInUse = false;
    }
}
