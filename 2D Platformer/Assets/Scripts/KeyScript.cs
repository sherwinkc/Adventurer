using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private LevelManager theLevelManager;
    private CircleCollider2D circleColl;

    public int keyValue;
    public bool triggerActive = false;

    void Awake()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        circleColl = GetComponent<CircleCollider2D>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KeyCollider" && triggerActive == false)
        {
            triggerActive = true;

            circleColl.enabled = false;

            //stop Audio in child component
            //playDistance.audioSource.enabled = false;

            //Debug.Log("Coin trigger");
            theLevelManager.AddKeys(keyValue);

            //Instead of destroying the object we are setting it to inactive
            //Destroy(gameObject);
            gameObject.SetActive(false);
            triggerActive = false;
        }
    }
}
