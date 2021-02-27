using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn_V2 : MonoBehaviour
{
    private Image blackScreen;
    public GameObject blackScreenGameObject;
    public float fadeTime;

    void Awake()
    {
        blackScreen = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        blackScreen.CrossFadeAlpha(0f, fadeTime, false);

        if (blackScreen.color.a == 0)
        {

            //gameObject.SetActive(false);
        }
    }
}
