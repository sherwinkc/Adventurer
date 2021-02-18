using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Player_Anim_Controller : MonoBehaviour
{
    //public Animator anim;
    public GameObject img_Idle,img_Run, img_Jump, img_Attack;

    public Image img;

    void Start()
    {
        //anim = GetComponent<Animator>();
        img = GetComponent<Image>();
    }

    public void Run()
    {
        //anim.SetTrigger("Run");
        img.sprite = Resources.Load<Sprite>("adventurer-cast-loop-01");
    }

    public void Jump()
    {
        //anim.SetTrigger("Jump");

        img.sprite = Resources.Load<Sprite>("adventurer-jump-03");
    }

    public void Attack()
    {
        //anim.SetTrigger("Attack");
        img.sprite = Resources.Load<Sprite>("adventurer-attack2-04");
    }
}
