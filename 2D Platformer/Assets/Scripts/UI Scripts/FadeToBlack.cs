using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    private Image blackScreen;
    //private LevelEnd levelEnd;
    public float fadeTime;

    public bool fadeToBlack = false;

    // Start is called before the first frame update
    void Start()
    {
        blackScreen = GetComponent<Image>();

        blackScreen.canvasRenderer.SetAlpha(0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeToBlack)
        {
            blackScreen.CrossFadeAlpha(1.2f, fadeTime, false);
        }

        if (blackScreen.color.a == 1.2f)
        {
            gameObject.SetActive(false);
        }
    }
}
