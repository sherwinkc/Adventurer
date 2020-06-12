using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintTrigger_Help : MonoBehaviour
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
        if (other.tag == "Player" && coActive == false)
        {
            StartCoroutine(TextDisplay());
        }
    }

    public IEnumerator TextDisplay()
    {
        coActive = true;
        text.enabled = true;

        yield return new WaitForSeconds(5f);

        text.enabled = false;

        //coActive = false;
        yield return null;
    }
}
