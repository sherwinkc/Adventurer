using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMP_TimeOnScreen : MonoBehaviour
{
    public GameObject prologue_Text;
    public float displayTime;

    public AudioSource display;

    private void Awake()
    {
        prologue_Text.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(DisplayTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator DisplayTime()
    {
        yield return new WaitForSeconds(1f);

        prologue_Text.SetActive(true);
        display.Play();

        yield return new WaitForSeconds(displayTime);

        prologue_Text.SetActive(false);

        yield return null;
    }
}
