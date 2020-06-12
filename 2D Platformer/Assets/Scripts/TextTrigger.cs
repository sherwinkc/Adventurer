using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTrigger : MonoBehaviour
{
    public Text text;
    public bool coActive;
    // Start is called before the first frame update
    void Start()
    {
        //text = GetComponentInParent<Text>();   
        coActive = false;
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

        yield return new WaitForSeconds(2f);

        text.enabled = false;

        coActive = false;
        yield return null;
    }    
}
