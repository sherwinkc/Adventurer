using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintTrigger_3Orbs : MonoBehaviour
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
        if (other.tag == "Player" && coActive == false && levelManager.coinCount < 3)
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
