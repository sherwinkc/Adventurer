using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    public Slider slider;
    public Skel_King_Script skel_King_Script;

    public void Awake()
    {
        slider = GetComponent<Slider>();
        skel_King_Script = FindObjectOfType<Skel_King_Script>(); 
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(skel_King_Script != null)
        {
            slider.value = skel_King_Script.currentHealth;
        }
    }
}
