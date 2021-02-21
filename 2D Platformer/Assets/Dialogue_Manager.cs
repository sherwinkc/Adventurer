using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager : MonoBehaviour
{
    //[SerializeField] public TMP_Text text;
    [SerializeField] public Text text;

    public float delay;
    public string fullText;
    private string currentText = "";

    public bool startCo = false;
    public AudioSource textSFX;


    private void Awake()
    {
        text = GetComponent<Text>();
        text.enabled = false;
    }

    void Start()
    {

    }

    void Update()
    {
        if (startCo)
        {
            text.enabled = true;
            StartCoroutine(ShowText());
            startCo = false;   
        }
    }

    IEnumerator ShowText()
    {
        fullText = text.text;

        for (int i = 0; i < fullText.Length + 1; i++)
        {
            currentText = fullText.Substring(0, i);
            text.text = currentText;

            if (!textSFX.isPlaying)
            {
                textSFX.pitch = Random.Range(0.8f, 1f);
                textSFX.Play();
            }

            yield return new WaitForSeconds(delay);
        }
    }
}
