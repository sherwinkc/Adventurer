using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private LevelManager theLevelManager;
    public Rigidbody2D rb;
    public PlayerCoin_Trans playerTransform;
    //public CoinScript coinScript;
    public CircleCollider2D cCollider;

    public int coinValue;
    public bool triggerActive;
    public bool moveTowardPlayer;
    private float coinLifetime;
    private bool canBeCollected;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //coinScript = GetComponentInChildren<CoinScript>();
        theLevelManager = FindObjectOfType<LevelManager>();
        playerTransform = FindObjectOfType<PlayerCoin_Trans>();

        StartCoroutine(CoinBehaviour());

        triggerActive = false;
        moveTowardPlayer = false;
        canBeCollected = false;

        coinLifetime = 20;
    }

    void Update()
    {
        //checking distance and move toward player if close enough
        if(moveTowardPlayer && Vector2.Distance(transform.position, playerTransform.transform.position) < 6f)
        {
            rb.transform.position = Vector3.MoveTowards(transform.position, playerTransform.transform.position, Random.Range(10f, 15f) * Time.deltaTime);

            cCollider.enabled = false;
            
            //Ignore collisions while moving toward player
            /*Physics2D.IgnoreCollision(coinScript.GetComponentInChildren<CircleCollider2D>(), GetComponent<BoxCollider2D>());
            Physics2D.IgnoreCollision(coinScript.GetComponentInChildren<CircleCollider2D>(), GetComponent<CircleCollider2D>());
            Physics2D.IgnoreCollision(coinScript.GetComponentInChildren<CircleCollider2D>(), GetComponent<CapsuleCollider2D>());*/
        }

        //destroys object over a period of time
        coinLifetime -= Time.deltaTime;
        if(coinLifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && triggerActive == false && canBeCollected)
        {
            triggerActive = true;

            //stop Audio in child component
            //playDistance.audioSource.enabled = false;

            theLevelManager.AddCoins(coinValue);

            triggerActive = false;
            moveTowardPlayer = false;

            Destroy(gameObject);
        }
    }

    public IEnumerator CoinBehaviour()
    {
        rb.velocity = new Vector2(Random.Range(-1f,2f),Random.Range(1f,3f));

        yield return new WaitForSeconds(0.25f);

        canBeCollected = true;

        yield return new WaitForSeconds(2f);

        moveTowardPlayer = true;

        yield return null; 
    }
}
