using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{
    private Rigidbody2D rb;

    public float dashSpeed, startDashTime;
    private float dashTime;
    private int direction;

    public Animator animator;

    private BoxCollider2D boxCollider;
    private CircleCollider2D circleCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponentInParent<BoxCollider2D>();
        circleCollider = GetComponentInParent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 0)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = 1;
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = 2;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
                boxCollider.enabled = true;
                circleCollider.enabled = true;
            }
            else
            {
                dashTime -= Time.deltaTime;
                boxCollider.enabled = false;
                circleCollider.enabled = false;

                if (direction == 1)
                {
                    animator.SetTrigger("Roll");
                    rb.velocity = Vector2.right * dashSpeed;
                }
                else if(direction == 2)
                {
                    animator.SetTrigger("Roll");
                    rb.velocity = Vector2.right * dashSpeed;
                }
            }
        }
    }
}
