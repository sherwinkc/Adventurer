using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour    
{
    //public Sprite flagClosed;
    //public Sprite flagOpen;

    private SpriteRenderer theSpriteRenderer;

    public bool checkpointActive;
    //public bool isFlagOpen;

    public AudioSource checkpointSound;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        theSpriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        //isFlagOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //checks if player walked into flag collider and changes the flag sprite. Also, sets checkpoint check to true.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && checkpointActive == false)
        {
            //theSpriteRenderer.sprite = flagOpen;
            //anim = anim.
            anim.SetBool("isFlagOpen", true);
            checkpointActive = true;
            checkpointSound.Play();
        }
    }
}
