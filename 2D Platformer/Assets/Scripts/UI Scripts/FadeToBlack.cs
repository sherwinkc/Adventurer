using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    private Image blackScreen;
    private LevelEnd levelEnd;
    //public float fadeTime;

    public bool fadeToBlack;

    // Start is called before the first frame update
    void Start()
    {
        blackScreen = GetComponent<Image>();
        levelEnd = FindObjectOfType<LevelEnd>();

        blackScreen.canvasRenderer.SetAlpha(0.0f);
        fadeToBlack = false;
}

    // Update is called once per frame
    void Update()
    {
        if (fadeToBlack)
        {
            blackScreen.CrossFadeAlpha(1.2f, levelEnd.waitToLoad/2f, false);
        }

        //Debug.Log("blackScreen.color.a =" + blackScreen.color.a);
        //Debug.Log("levelEnd.waitToLoad =" + levelEnd.waitToLoad);

        /*if (blackScreen.color.a == 0)
        {
            gameObject.SetActive(false);
        }*/
    }
}
