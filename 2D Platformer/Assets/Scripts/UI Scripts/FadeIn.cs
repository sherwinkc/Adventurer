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

    public GameObject blackScreen_GO;

    public bool usedCo = false;

    // Start is called before the first frame update
    void Start()
    {
        blackScreen = GetComponent<Image>();

        Invoke("KillGameObject", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //blackScreen.CrossFadeAlpha(0f, fadeTime, false);

        //blackScreen.color = new Color(1, 1, 1, 1 - Time.deltaTime);

        //blackScreen.color.a = alpha;
        //Debug.Log(blackScreen.color.a);

        if(!usedCo)
        {
            StartCoroutine(FadeInCo());
        }

        //Debug.Log(blackScreen.color.a);
    }
    IEnumerator FadeInCo()
    {
        usedCo = true;

        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            blackScreen.color = new Color(0, 0, 0, i);

            yield return null;

            /*if (i <= 0)
            {
                blackScreen_GO.SetActive(false);
            }*/
        }

        yield return null;
    }

    void KillGameObject()
    {
        blackScreen_GO.SetActive(false);
    }
}
    

