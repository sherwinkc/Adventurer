using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Player_Anim_Controller : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Run()
    {
        anim.SetTrigger("Run");
    }

    public void Jump()
    {
        anim.SetTrigger("Jump");
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
    }
}
