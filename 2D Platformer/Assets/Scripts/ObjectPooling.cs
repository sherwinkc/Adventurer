using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public PlayerMovement playerMov;
    public float distanceFromPlayer;
    public float absoluteDistance;

    void Awake()
    {
        playerMov = FindObjectOfType<PlayerMovement>();
    }


    void Start()
    {
        
    }


    void Update()
    {

        //absoluteDistance = Vector2.Distance(transform.position, playerMov.transform.position);

        //if greater than distance from player - deactivate
        if (Vector2.Distance(transform.position, playerMov.transform.position) > distanceFromPlayer)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }

        Debug.Log(absoluteDistance);
    }
}
