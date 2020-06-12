using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerDetect : MonoBehaviour
{
    public Text text;
       
    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string[] names = Input.GetJoystickNames();
        //Debug.Log(names[0]);

        if (names[0] != null)
        {
            text.enabled = true;
        }

        if (names[0].Length > 0)
        {
            text.enabled = false;
        }
    }
}
