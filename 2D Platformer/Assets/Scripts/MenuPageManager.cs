using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPageManager : MonoBehaviour
{
    public GameObject main, jumpTo, credits;

    public AudioSource selectSound;

    void Start()
    {
        main.gameObject.SetActive(true);
        jumpTo.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Main()
    {
        main.gameObject.SetActive(true);
        jumpTo.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
        selectSound.Play();
    }

    public void JumpTo()
    {
        main.gameObject.SetActive(false);
        jumpTo.gameObject.SetActive(true);
        credits.gameObject.SetActive(false);
        selectSound.Play();
    }

    public void Credits()
    {
        main.gameObject.SetActive(false);
        jumpTo.gameObject.SetActive(false);
        credits.gameObject.SetActive(true);
        selectSound.Play();
    }


}
