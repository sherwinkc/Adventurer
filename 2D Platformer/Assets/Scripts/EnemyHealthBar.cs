using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    public Spider_Script health;
    //public SquibTransform enemyTransform;

    void Start()
    {
        slider = GetComponent<Slider>();
        health = GetComponentInParent<Spider_Script>();        
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = health.maxHealth;
        slider.value = health.currentHealth;

        transform.position = new Vector3(health.transform.position.x, health.transform.position.y + 2f, health.transform.position.z);

        if (health.transform.localScale.x > 0)
        {
            //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        
        if (health.transform.localScale.x < 0)
        {
            //transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        //Debug.Log("health bar transform - transform.localScale: " + transform.localScale); // health bar transform
        //Debug.Log("spider script transform - health.transform.localScale: " + health.transform.localScale); //spider script transform
    }
}
