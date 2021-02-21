using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign_Script : MonoBehaviour
{
    public Text text;
    public bool textShowing = false;
    public float waitTime;

    public Dialogue_Manager dialogueMan;

    private void Awake()
    {
        //text.enabled = false;
    }

    void Start()
    {

    }

    void Update()
    {
        if(textShowing)
        {
            dialogueMan.startCo = true;
            StartCoroutine(TextTimer());
            textShowing = false;
        }
    }

    public IEnumerator TextTimer()
    {

        yield return new WaitForSeconds(waitTime);

        text.enabled = false;

        yield return null;
    }
}
