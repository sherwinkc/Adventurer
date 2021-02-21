using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTrigger : MonoBehaviour
{
    public Text text;
    public bool coActive;
    public float timeOnScreen;

    private void Awake()
    {
        text.enabled = false;
    }


    void Start()
    {
        coActive = false;
        timeOnScreen = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && coActive == false)
        {
             StartCoroutine(TextDisplay());
        }
    }
        
    public IEnumerator TextDisplay()
    {
        coActive = true;
        text.enabled = true;

        yield return new WaitForSeconds(timeOnScreen);

        text.enabled = false;

        coActive = false;
        yield return null;
    }    
}
