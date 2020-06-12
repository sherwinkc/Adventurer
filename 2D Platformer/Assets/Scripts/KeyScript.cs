using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private LevelManager theLevelManager;
    //public PlayDistance playDistance;

    public int keyValue;
    public bool triggerActive;
    // Start is called before the first frame update
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        //playDistance = GetComponentInChildren<PlayDistance>();

        triggerActive = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && triggerActive == false)
        {
            triggerActive = true;

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
