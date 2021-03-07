using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScript : MonoBehaviour
{
    public GameObject shadow;

    public Transform groundCheckTrans;
    public float groundCheckRadius = 0.3f;

    public LayerMask whatIsGround;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        shadow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckTrans.position, groundCheckRadius, whatIsGround);

        if(isGrounded)
        {
            shadow.SetActive(true);
        }
        else
        {
            shadow.SetActive(false);
        }
    }
}
