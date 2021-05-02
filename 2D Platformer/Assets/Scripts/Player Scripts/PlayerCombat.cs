using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class PlayerCombat : MonoBehaviour
{
    //Components
    public Rigidbody2D myRigidbody;
    public PlayerController thePlayer;
    public PlayerMovement playerMovement;
    public Upgrades upgrades;

    //chunk bar
    public RadialChunkBar radialChunkBar;

    //Animations
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    //Attack
    public int attackDamage = 40;
    public float attackRate = 2.25f;
    public float nextAttackTime = 0f;

    //cinemachine
    public CinemachineImpulseSource m_impulseSource;

    //Audio
    public AudioSource swordSwipe, superSFX, attackDud;

    //Camera Shake
    //TODO

    //Controller Movement
    PlayerControls controls;

    //Choose a random attack
    string randomAttack;
    string[] attackTriggers = { "Attack1", "Attack2"};
    //string[] attackTriggers = { "Attack1", "Attack2", "Attack3" };

    //super
    public float superAmount, superStartAmount, superMax, superRechargeRate;
    public GameObject superBullet;
    public GameObject superReadyText;
    //public bool superTextActive = false;

    //checks
    public bool canMove;
    bool playSuperOnce;

    //stamina
    public float staminaMax, currentStamina, staminaRechargeRate, attackCost;

    void Awake()
    {
        //initialise control scheme
        controls = new PlayerControls();

        //Attack
        controls.PlayerGameplay.Attack.performed += ctx => Attack();

        controls.PlayerGameplay.Super.performed += ctx => SuperAttack();
    }

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        upgrades = GetComponent<Upgrades>();        
        m_impulseSource = FindObjectOfType<CinemachineImpulseSource>();
        radialChunkBar = FindObjectOfType<RadialChunkBar>();

        canMove = true;
        playSuperOnce = false;

        superStartAmount = 0;
        superMax = 100;
        superReadyText.SetActive(false);
    }

    void Update()
    {
        superAmount += superRechargeRate * Time.deltaTime;

        if (superAmount >= superMax)
        {
            superAmount = superMax;
            PlaySuperSFX();

            // increase movement speed when super is full?
            //upgrades.playerMovement.moveSpeed += 1f;
            //upgrades.playerMovement.jumpSpeed += 1f;
        }

        if(currentStamina < staminaMax)
        {
            currentStamina += staminaRechargeRate * Time.deltaTime;
        } 
        
        if(currentStamina >= staminaMax)
        {
            currentStamina = staminaMax;
        }

        if(superAmount >= superMax)
        {
            superReadyText.SetActive(true);
        }
        else if (superAmount < superMax)
        {
            superReadyText.SetActive(false);
        }
    }

    void Attack()
    {
        // Play attack dud sound if not enough stamina
        if (playerMovement.knockbackCounter <= 0 && canMove && currentStamina < attackCost && Time.time > nextAttackTime)
        {
            attackDud.Play();
        }

        //randomize attack animation
        randomAttack = attackTriggers[Random.Range(0, attackTriggers.Length)];

        if (playerMovement.knockbackCounter <= 0 && canMove && currentStamina >= attackCost)
        {
            if ((Time.time >= nextAttackTime && playerMovement.isGrounded))
            {
                //play an attack animation
                animator.SetTrigger(randomAttack);
                nextAttackTime = Time.time + 1f / attackRate;
                currentStamina -= attackCost;
                //radialChunkBar.barFillAmount =+ attackCost/100; // TODO
                SwordSipe();
            }
            else if ((Time.time >= nextAttackTime && !playerMovement.isGrounded))
            {
                //play an attack animation
                animator.SetTrigger("airAttack");
                nextAttackTime = Time.time + 1f / attackRate;
                currentStamina -= attackCost;
                //radialChunkBar.barFillAmount =+ attackCost/100; // TODO
                SwordSipe();
            }

            //m_impulseSource.GenerateImpulse(1f); // impulse on every sword swipe
        }
    }

    void SwordAttackLogic()
    {
        //detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            //Debug.Log("We hit " + enemy.name);

            //Checking if the enemy script is on the same object as the enemy or the hitBox
            if(enemy.GetComponentInParent<Enemy>() != null)
            {
                enemy.GetComponentInParent<Enemy>().TakeDamage(attackDamage);
                StartCoroutine(SlowTimeCo());
            }
            else if(enemy.GetComponent<Enemy>() != null)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                StartCoroutine(SlowTimeCo());
            }
            //Check if we hit spider script
            else if(enemy.GetComponentInParent<Spider_Script>() != null)
            {
                enemy.GetComponentInParent<Spider_Script>().TakeDamage(attackDamage);
                StartCoroutine(SlowTimeCo());
            }
            else if (enemy.GetComponent<ShieldGuard>() != null)
            {
                enemy.GetComponent<ShieldGuard>().InstantBlockVFX();
                StartCoroutine(SlowTimeCo());
            }
            else if(enemy.GetComponentInParent<Fire_Skel_Script>() != null)
            {
                enemy.GetComponentInParent<Fire_Skel_Script>().TakeDamage(attackDamage);
                StartCoroutine(SlowTimeCo());
            }
            else if(enemy.GetComponentInParent<Sludge_Script>() !=null)
            {
                enemy.GetComponentInParent<Sludge_Script>().TakeDamage(attackDamage);
                StartCoroutine(SlowTimeCo());
            }
            else if (enemy.GetComponentInParent<Bird_Script>() != null)
            {
                enemy.GetComponentInParent<Bird_Script>().TakeDamage(attackDamage);
                StartCoroutine(SlowTimeCo());
            }
            else if (enemy.GetComponentInParent<Scarecrow_Script>() != null)
            {
                enemy.GetComponentInParent<Scarecrow_Script>().TakeDamage(attackDamage);
                StartCoroutine(SlowTimeCo());
            }
            else if (enemy.GetComponentInParent<Skel_King_Script>() != null)
            {
                enemy.GetComponentInParent<Skel_King_Script>().TakeDamage(attackDamage);
                StartCoroutine(SlowTimeCo());
            }
        }
    }

    public IEnumerator SlowTimeCo()
    {
        Time.timeScale = 0.01f;

        yield return new WaitForSeconds(0.00075f);

        Time.timeScale = 1f;

        yield return null;           
    }

    void SuperAttack()
    {
        if(superAmount >= superMax)
        {
            StartCoroutine(SuperAttackSequence());
            playSuperOnce = false; //for UI sfx
            //m_impulseSource.GenerateImpulse(1f);
        }
    }

    //draws the overlap circle when selecting it
    void OnDrawGizmosSelected()
    {
        //returns null if there is not sphere. Prevents errors
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void SwordSipe()
    {
        swordSwipe.pitch = (Random.Range(0.92f, 1f));
        swordSwipe.Play();
        //m_impulseSource.GenerateImpulse(0.1f);
    }


    public IEnumerator SuperAttackSequence()
    {
        superAmount = superStartAmount;
        Time.timeScale = 0.5f;
        animator.SetTrigger("isSuper");
        //SwordSipe();        

        yield return new WaitForSeconds(0.2f);

        Instantiate(superBullet, attackPoint.position, attackPoint.rotation);

        Time.timeScale = 1f;        

        //Return player movement to normal // TODO change hard values to variables
        //upgrades.playerMovement.moveSpeed = 5f;
        //upgrades.playerMovement.jumpSpeed = 10f;

        yield return null;
    }

    void PlaySuperSFX()
    {
        if(!playSuperOnce)
        {
            superSFX.Play();
            playSuperOnce = true;
        }        
    }

    private void OnEnable()
    {
        controls.PlayerGameplay.Enable();
    }

    private void OnDisable()
    {
        controls.PlayerGameplay.Disable();
    }
}







