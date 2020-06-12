using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private LevelManager theLevelManager;
    public Rigidbody2D rb;
    public Transform playerTrans;
    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;

    public int coinValue;
    public bool triggerActive;
    public bool moveTowardPlayer;
    private float coinLifetime;

    // Start is called before the first frame update
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        rb = GetComponent<Rigidbody2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerCombat = FindObjectOfType<PlayerCombat>();

        StartCoroutine(CoinBehaviour());

        triggerActive = false;
        moveTowardPlayer = false;

        coinLifetime = 20;
    }

    // Update is called once per frame
    void Update()
    {
        //checking distance and moving toward player if close enough
        if(moveTowardPlayer && Vector2.Distance(transform.position, playerMovement.transform.position) < 6f)
        {
            rb.transform.position = Vector3.MoveTowards(transform.position, playerCombat.attackPoint.transform.position, Random.Range(20f, 30f) * Time.deltaTime);
        }

        //destroys object over a period of time
        coinLifetime -= 1 * Time.deltaTime;
        if(coinLifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && triggerActive == false)
        {
            triggerActive = true;

            //stop Audio in child component
            //playDistance.audioSource.enabled = false;

            //Debug.Log("Coin trigger");
            theLevelManager.AddCoins(coinValue);

            //TODO coins are cloning themselves in the hierachy
            //Instead of destroying the object we are setting it to inactive
            Destroy(gameObject);
            //gameObject.SetActive(false);

            triggerActive = false;

            moveTowardPlayer = false;
        }
    }

    public IEnumerator CoinBehaviour()
    {
        rb.velocity = new Vector2(Random.Range(2f,5f),Random.Range(2f,5f));

        yield return new WaitForSeconds(2f);

        moveTowardPlayer = true;

        yield return null; 
    }
}
