using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    public Image blackScreen;
    public float fadeTime;
    public bool fadeToBlack = false;

    void Awake()
    {
        blackScreen = GetComponent<Image>();
        blackScreen.canvasRenderer.SetAlpha(0.0f);
        blackScreen.enabled = false;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fadeToBlack)
        {
            blackScreen.enabled = true;
            StartCoroutine(FadeOutCo());            
        }
    }

    IEnumerator FadeOutCo()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime / 3)
        {
            // set color with i as alpha
            blackScreen.color = new Color(0, 0, 0, i);

            yield return null;

            /*if (i >= 1)
            {
                gameObject.SetActive(false);
            }*/
        }

        yield return null;
    }
}
