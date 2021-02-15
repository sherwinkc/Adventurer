using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float fadeTime;
    public Image blackScreen;    

    // Start is called before the first frame update
    void Start()
    {
        blackScreen = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        blackScreen.CrossFadeAlpha(0f, fadeTime, false);

        Debug.Log(blackScreen.color.a);

        if (blackScreen.color.a == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
