using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    //public float fadeTime;
    //public Color blackScreen
    public Image blackScreen;
    //public float alpha;
    //public Color alpha;

    // Start is called before the first frame update
    void Start()
    {
        blackScreen = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //blackScreen.CrossFadeAlpha(0f, fadeTime, false);

        //blackScreen.color = new Color(1, 1, 1, 1 - Time.deltaTime);

        //blackScreen.color.a = alpha;
        //Debug.Log(blackScreen.color.a);

        StartCoroutine(FadeInCo());

        //Debug.Log(blackScreen.color.a);
    }
    IEnumerator FadeInCo()
    {
        for (float i = 1; i >= 0; i -= Time.deltaTime / 3)
        {
            // set color with i as alpha
            blackScreen.color = new Color(0, 0, 0, i);

            yield return null;

            if (i <= 0)
            {
                gameObject.SetActive(false);
            }
        }

        yield return null;
    }
}
    

