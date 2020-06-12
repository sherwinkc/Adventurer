using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintTrigger : MonoBehaviour
{
    public Text text;
    public bool coActive;

    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        //text = GetComponentInParent<Text>();   
        coActive = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && coActive == false && levelManager.coinCount < 1)
        {
            StartCoroutine(TextDisplay());
        }
    }

    public IEnumerator TextDisplay()
    {
        coActive = true;

        yield return new WaitForSeconds(2f);
        
        text.enabled = true;

        yield return new WaitForSeconds(10f);

        text.enabled = false;

        coActive = false;
        yield return null;
    }
}
