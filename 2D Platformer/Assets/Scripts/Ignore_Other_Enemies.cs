using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignore_Other_Enemies : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(10, 10); // enemy layer
        Physics2D.IgnoreLayerCollision(17, 17); // coins layer
    }

    // Update is called once per frame
    void Update()
    {

    }
}
