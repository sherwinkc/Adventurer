using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skel_King_Controller : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public PlayerMovement playerMovement;
    public LevelManager levelManager;
    public Skel_King_Script skel_King_Script;
    public FlameManager flameMan;
    public BoxCollider2D boxCollider2D;

    public float moveSpeed;
    public bool canMove = false;

    public bool attacking = false;
    //public bool guarding = false;

    //basic attack variables
    public float attackCooldown;
    public float attackCounter;
    public bool startCooldown = false;
    public bool isBasicAttacking = true;

    //major attack variables
    public float attackStateCounter, attackStateCooldown;
    public bool startAttackStateCooldown = false;
    public GameObject majorAttackPosition;
    public GameObject platform_L, platform_R, platform_C;
    public bool startMajorCo = false;
    public bool isForceFieldActive = false;
    public bool activatedForceFieldOnce = false;
    public bool canMoveToPosition = false;
    public bool canMoveToPositionUsed = false;
    public bool canStopMajorAttack = true;
    public bool majorAttackUsed_1 = false;
    public bool majorAttackUsed_2 = false;

    public float waitTime_plat, waitTime_1, waitTime_2, waitTime_3;
    public GameObject forceField;
    public ForceFieldScript forceFieldScript;
    public bool canPlay = true;

    public GameObject flameHolder;

    //flames
    public bool startFlamesOnce = false;

    public bool pushBackTimerActive = false;
    public float pushBackCounter = 0f;

    public float distanceToPlayer;

    //choose a state/anim
    string state;
    string[] stateList = { "Attack1", "Attack2" };

    //Audio
    public AudioSource swipe, forceFieldActivate, forceFieldLoop, platformCreation; // idle, skel_steps;

    void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        animator = GetComponentInParent<Animator>();
        skel_King_Script = GetComponent<Skel_King_Script>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        levelManager = FindObjectOfType<LevelManager>();
        flameMan = GetComponent<FlameManager>();

        platform_L.SetActive(false); platform_R.SetActive(false); platform_C.SetActive(false);

        //forceField.gameObject.SetActive(true);
        boxCollider2D.gameObject.SetActive(false);
    }

    void Start()
    {

    }

    void Update()
    {
        if(skel_King_Script.currentHealth < skel_King_Script.maxHealth * 0.75f && !majorAttackUsed_1 /*&& skel_King_Script.currentHealth > skel_King_Script.maxHealth / 4f*/) // health is 50% move to attack position
        {
            isBasicAttacking = false;
            if(!canMoveToPositionUsed)
            {
                canMoveToPosition = true;
                canMoveToPositionUsed = true;
            }
        }

        if (skel_King_Script.currentHealth < skel_King_Script.maxHealth * 0.25f && !majorAttackUsed_2 /*&& skel_King_Script.currentHealth > skel_King_Script.maxHealth / 4f*/) // health is 50% move to attack position
        {
            isBasicAttacking = false;
            if (!canMoveToPositionUsed)
            {
                canMoveToPosition = true;
                canMoveToPositionUsed = true;
            }
        }

        if (canMoveToPosition && !isBasicAttacking)
        {
            MoveToPosition();
        }
        
        if(startMajorCo) // Start Major Attack once reached position
        {
            StartCoroutine(MajorAttackSequence());
            startMajorCo = false;
        }

        if (isBasicAttacking && !canMoveToPosition)
        {
            BasicBehaviour();
        }

        //Animator checks
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        
        if(forceFieldScript != null)
        {
            forceFieldScript = FindObjectOfType<ForceFieldScript>();
        }

        //push back timer TODO
        /*if(pushBackTimerActive)
        {
            pushBackCounter += Time.deltaTime * 10f;

            if (pushBackCounter > 1f)
            {
                pushBackTimerActive = false;
                boxCollider2D.size = new Vector2(0.1f, 0.1f);
                boxCollider2D.gameObject.SetActive(false);
            }

            if(pushBackCounter < 1f)
            {
                boxCollider2D.size = new Vector2(pushBackCounter, 0.1f);
                boxCollider2D.gameObject.SetActive(true);
            }
        }*/
    }

    private void OnBecameVisible()
    {
        canMove = true;
    }

    //destroy enemy if colliding with the Kill Plane
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillPlane")
        {
            gameObject.SetActive(false);
        }
    }

    public void BasicBehaviour()
    {
        Debug.Log("Basic Behaviour");
        // Move towards the player
        if (playerMovement.transform.position.x < transform.position.x && canMove && !attacking && levelManager.healthCount > 0)
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0f);
            transform.localScale = new Vector3((float)3.5f, transform.localScale.y, transform.localScale.y);
        }
        else if (playerMovement.transform.position.x > transform.position.x && canMove && canMove && !attacking && levelManager.healthCount > 0)
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0f);
            transform.localScale = new Vector3((float)-3.5, transform.localScale.y, transform.localScale.y);
        }
        else
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.y);
            //animator.SetTrigger("Idle");
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Hurt"))
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }

        //check if player is in close proximity and attack
        if (Vector2.Distance(transform.position, playerMovement.transform.position) < distanceToPlayer && attackCounter <= 0 && canMove)
        {
            if (levelManager.healthCount > 0)
            {
                state = stateList[Random.Range(0, stateList.Length)];
                animator.SetTrigger(state);
                swipe.Play();
                rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
                startCooldown = true;
            }
        }

        if (attackCounter >= attackCooldown)
        {
            attackCounter = 0f;
            startCooldown = false;
        }

        if (startCooldown)
        {
            attackCounter += Time.deltaTime;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") || animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
        {
            attacking = true;
        }
        else
        {
            attacking = false;
        }
    }

    public void MoveToPosition()
    {
        Debug.Log("Move to position");

        //activate force field
        if(!activatedForceFieldOnce)
        {
            ActivateForceField();
            activatedForceFieldOnce = true;
            pushBackTimerActive = true;
        }

        //isForceFieldActive = true;

        if ((transform.position.x - majorAttackPosition.transform.position.x) < 0.1f && (transform.position.x - majorAttackPosition.transform.position.x) > -0.1f)
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
            canMoveToPosition = false;
            startMajorCo = true;
        } 
        else if (transform.position.x < majorAttackPosition.transform.position.x)
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0f);
            transform.localScale = new Vector3((float)-3.5f, transform.localScale.y, transform.localScale.y);
        } 
        else if (transform.position.x > majorAttackPosition.transform.position.x)
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0f);
            transform.localScale = new Vector3((float)3.5f, transform.localScale.y, transform.localScale.y);
        }
    }


    private void OnEnable()
    {
        canMove = false;
    }

    public IEnumerator MajorAttackSequence()
    {
        Debug.Log("Major Co Started");
        animator.SetTrigger("Cast1");

        yield return new WaitForSeconds(waitTime_plat);

        platform_L.SetActive(true);
        platformCreation.Play();

        yield return new WaitForSeconds(waitTime_plat);

        platform_R.SetActive(true);
        platformCreation.Play();

        yield return new WaitForSeconds(waitTime_plat);

        platform_C.SetActive(true);
        platformCreation.Play();

        if (!startFlamesOnce)
        {
            StartCoroutine(flameMan.CreateFlamesCo());
        }

        startFlamesOnce = true;

        yield return new WaitForSeconds(20f);

        StopMajorAttack();
        Debug.Log("call stop major attack");

        yield return null;
    }

    public void ActivateForceField()
    {
        Instantiate(forceField, skel_King_Script.squibTransform.position, skel_King_Script.squibTransform.rotation);
        forceFieldActivate.Play();
        forceFieldLoop.Play();
    }

    public void PlayPlatformSFX()
    {
        if(!platformCreation.isPlaying)
        {
            if(canPlay)
            {
                platformCreation.Play();
            }
        }
    }

    public void StopMajorAttack()
    {
        animator.SetTrigger("Idle");

        //deactivat flames
        flameHolder.SetActive(false);

        //deactivate platforms
        platform_L.SetActive(false);
        platform_R.SetActive(false);
        platform_C.SetActive(false);

        //force field
        //Destroy(forceField);
        forceFieldScript = FindObjectOfType<ForceFieldScript>();
        forceFieldScript.isOn = true;

        //forceField.SetActive(false);
        activatedForceFieldOnce = false;
        forceFieldActivate.Stop();
        forceFieldLoop.Stop();

        // restart basic loop
        isBasicAttacking = true;
        canMoveToPosition = false;
        canMoveToPositionUsed = false;
        startFlamesOnce = false;
        startMajorCo = false;

        //check which major attack - major attack 1 or 2
        if (majorAttackUsed_1 && !majorAttackUsed_2)
        {
            majorAttackUsed_2 = true;
        }

        if (!majorAttackUsed_1 && !majorAttackUsed_2)
        {
            majorAttackUsed_1 = true;
        }
    }

    public void CircleColliderFunction()
    {

    }

    public IEnumerator PushBackCo()
    {
        pushBackTimerActive = true;

        yield return null;
    }
    
    //Animator SFX
    public void Skel_SwipeSFX()
    {
        //swipe.Play();
    }
    public void Skel_FootstepSFX()
    {
        //skel_steps.pitch = (Random.Range(0.7f, 1.2f));
        //skel_steps.Play();
    }
}
