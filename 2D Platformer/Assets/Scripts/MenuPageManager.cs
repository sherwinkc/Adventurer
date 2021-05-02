using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPageManager : MonoBehaviour
{
    public GameObject main, jumpTo, credits;

    public AudioSource selectSound;

    public Button newGameFirstButton, jumpToFirstButton, creditsFirstButton;

    void Start()
    {
        main.gameObject.SetActive(true);
        jumpTo.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
        newGameFirstButton.Select();
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
        newGameFirstButton.Select();
        selectSound.Play();
    }

    public void JumpTo()
    {
        main.gameObject.SetActive(false);
        jumpTo.gameObject.SetActive(true);
        credits.gameObject.SetActive(false);
        jumpToFirstButton.Select();
        selectSound.Play();
    }

    public void Credits()
    {
        main.gameObject.SetActive(false);
        jumpTo.gameObject.SetActive(false);
        credits.gameObject.SetActive(true);
        creditsFirstButton.Select();
        selectSound.Play();
    }
}
