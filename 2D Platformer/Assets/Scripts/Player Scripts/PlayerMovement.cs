using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    //Components
    public Animator animator;
    public Rigidbody2D myRigidbody;
    public LevelManager levelManager;
    public Upgrades upgrades;
    public PlayerCombat playerCombat;

    //checks
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;
    public bool canMove;
    public bool chestNear;
    public bool limitMovement = false;
    public bool canCancelJump = true;

    //Jump
    public float jumpSpeed;
    private bool canDoubleJump;
    public float jumpHangTime = 0.2f;
    private float hangCounter;

    //Dodge
    public float dashSpeed;
    private bool canDash = true;
    private bool canSetZero = true;
    public float dashCooldownAmount;
    public float dashCounter;

    //Movement
    //float horizontalMove = 0f; //??
    public float moveSpeed;

    //knockback
    public float knockbackForce, knockbackLength;
    public float knockbackCounter;

    //Footsteps particle system
    public ParticleSystem footsteps;
    private ParticleSystem.EmissionModule footEmission;
    public ParticleSystem impactEffect;
    private bool wasOnGround;

    //Controller Movement
    PlayerControls controls;
    public Vector2 move;

    //Dialogues
    public bool isTalking = false;
    public bool signIsNear = false;
    public Sign_Script signScript;

    //Camera shake
    //TODO

    //movement costs for stamina
    public float jumpCost, rollCost;

    //chests
    public ChestScript chest;

    //Audio
    public AudioSource runSound, jumpSound, rollSound, jumpRollDud;
    #endregion

    void Awake()
    {
        //Initialise control scheme
        controls = new PlayerControls();

        //Jump
        controls.PlayerGameplay.Jump.performed += ctx => PlayerJump();
        controls.PlayerGameplay.Jump.canceled += ctx => PlayerJumpCancel();

        //Stick Movement
        controls.PlayerGameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.PlayerGameplay.Move.canceled += ctx => move = Vector2.zero;

        //Dodge/Roll
        controls.PlayerGameplay.Dodge.performed += ctx => Dodge();

        //interact
        controls.PlayerGameplay.Interact.performed += ctx => Interact();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Get Component
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerCombat = GetComponent<PlayerCombat>();

        //Find Component
        levelManager = FindObjectOfType<LevelManager>();
        upgrades = FindObjectOfType<Upgrades>();
        //playerCombat = FindObjectOfType<PlayerCombat>();

        footEmission = footsteps.emission;
        canMove = true;

        dashCounter = dashCooldownAmount;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (knockbackCounter <= 0 && canMove)
        {
            //check if the attack animation is playing, limit the player's x velocity to 1/3
            if ((animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Attack1")) || (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Attack2")))
            {
                myRigidbody.velocity = new Vector2((move.x * moveSpeed) / 3, myRigidbody.velocity.y);
                limitMovement = true; // limiting player left and right movement whena attacking
            }
            else if ((!animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Attack1")) || (!animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Attack2")))
            {
                myRigidbody.velocity = new Vector2(move.x * moveSpeed, myRigidbody.velocity.y);
                limitMovement = false;
            }

            //Dodge Roll - when roll anim is playing increase velocity by dash speed
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Roll"))
            {
                myRigidbody.velocity = new Vector2(move.x * dashSpeed, myRigidbody.velocity.y);
            }

            //Trying to make the jump small if the player releases the button early
            /*if(Input.GetButtonUp("Jump") && myRigidbody.velocity.y > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, myRigidbody.velocity.y * 0.5f);
            }*/

            //If moving left or right change the direction of the scale
            if (move.x > 0.3 && !limitMovement) // limiting player left and right movement whena attacking
            {
                transform.localScale = new Vector3(5f, 5f, 1f);
                //RunningSound();
            }
            else if (move.x < -0.3 && !limitMovement) // limiting player left and right movement whena attacking
            {
                transform.localScale = new Vector3(-5f, 5f, 1f);
                //playerCombat.attackPoint.transform.localScale = new Vector3(0f, 180f, 0f);
                //RunningSound();
            }
            else
            {
                myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
            }

            //player hang time check
            if (isGrounded)
            {
                hangCounter = jumpHangTime; 
            }
            else
            {
                hangCounter -= Time.deltaTime;
            }

            //Dash logic and cooldown
            if (!canDash)
            {
                if(canSetZero)
                {
                    dashCounter = 0;
                    canSetZero = false;
                }
                dashCounter += Time.deltaTime;
            }

            if (dashCounter > dashCooldownAmount)
            {
                dashCounter = dashCooldownAmount;
                canDash = true;
                canSetZero = true;
            }

            //set invincible to false as knockback is false
            levelManager.invincible = false; //TODO this is overwriting Locked Door script as it's in update loop
        } // end of knockback
        
        if (knockbackCounter > 0)
        {
            //time it counts down
            knockbackCounter -= Time.deltaTime;

            //if statement to change the direction of the knockback
            if (transform.localScale.x > 0)
            {
                //knock direction - diagonally
                //myRigidbody.velocity = new Vector3(-knockbackForce, knockbackForce, 0f);
                myRigidbody.velocity = new Vector3(-knockbackForce, 0f, 0f);
            }
            else
            {
                //myRigidbody.velocity = new Vector3(knockbackForce, knockbackForce, 0f);
                myRigidbody.velocity = new Vector3(knockbackForce, 0f, 0f);
            }
        }

        //Set animator parameters. mathf ensures the value is always positive
        animator.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
        animator.SetBool("Grounded", isGrounded);
        animator.SetFloat("YSpeed", (myRigidbody.velocity.y));

        /*if(canDoubleJump && !isGrounded)
        {
            canCancelJump = true;
        } else 
        if(canDoubleJump && isGrounded)
        {
            canCancelJump = false;
        }*/

        //showing impact particles
        if(!wasOnGround && isGrounded)
        {
            impactEffect.gameObject.SetActive(true);
            impactEffect.Stop();
            impactEffect.transform.position = footsteps.transform.position;
            impactEffect.Play();
        }
        wasOnGround = isGrounded;

        //footsteps Particle System
        if (Input.GetAxisRaw("Horizontal") != 0 && isGrounded && (Mathf.Abs(myRigidbody.velocity.x) > 0.01))
        {
            footEmission.rateOverTime = Random.Range(40, 50);
        }
        else
        {
            footEmission.rateOverTime = 0;
        }
    }

    void PlayerJump()
    {
        //play dud sound if there's not enough stamina
        if (playerCombat.currentStamina < jumpCost && (!animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Jump")))
        {
            jumpRollDud.Play();
        }

        //check if hang counter 
        if (hangCounter >= 0f && knockbackCounter <= 0 && canMove && (!animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Jump")) && playerCombat.currentStamina >= jumpCost)
        {
            if(upgrades.doubleJumpUnlocked)
            {
                canDoubleJump = true;
            }            
                myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
                JumpSound();
                playerCombat.currentStamina -= jumpCost;
        }
        else
        {
            if (canDoubleJump && knockbackCounter <= 0)
            {
                myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
                animator.SetTrigger("Flip");
                canDoubleJump = false;
                JumpSound();
                playerCombat.currentStamina -= jumpCost;
            }
        }
    }

    void PlayerJumpCancel()
    {
        /*if(!isGrounded && canCancelJump)
        {
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed * 0.5f, 0f);
        }*/
    }

    void Dodge()
    {
        if (isGrounded && canDash && Mathf.Abs(myRigidbody.velocity.x) >= 3 && canMove && playerCombat.currentStamina >= rollCost)
        {
            animator.SetTrigger("Roll");
            canDash = false;
            rollSound.Play();
            playerCombat.currentStamina -= rollCost;
        }

        //play dud sound if there's not enough stamina
        if (isGrounded && canDash && Mathf.Abs(myRigidbody.velocity.x) >= 3 && canMove && playerCombat.currentStamina < rollCost)
        {
            jumpRollDud.Play();
        }
    }
    public void Knockback()
    {
        knockbackCounter = knockbackLength;
        //invincibilityCounter = invincibilityLength;

        //sets the invincibility in the level manager script
        levelManager.invincible = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Chest")
        {
            chest = other.GetComponent<ChestScript>();
            chestNear = true;
        } else
        {
            chestNear = false;
            chest = null;
        }

        if(other.tag == "Signs")
        {
            signScript = other.GetComponent<Sign_Script>();
            signIsNear = true;
        }
        else
        {
            signIsNear = false;
            signScript = null;
        }
    }

    void Interact()
    {
        if(isGrounded && chestNear)
        {
            animator.SetTrigger("isInteract");
            chest.animator.SetTrigger("isOpen");            
            chest.openTheChest = true;
        }

        if (isGrounded && signIsNear)
        {
            //animator.SetTrigger("isInteract");
            signScript.textShowing = true;
        }
    }


    void RunningSound()
    {
        runSound.pitch = (Random.Range(0.5f, 1f));
        runSound.Play();
    }

    void JumpSound()
    {
        jumpSound.pitch = (Random.Range(0.95f, 1f));
        jumpSound.Play();
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
