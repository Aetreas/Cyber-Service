using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThirdPersonMovement : MonoBehaviour
{
    public static ThirdPersonMovement Instance;

    public CharacterController controller;
    public Animator miloAnimator;
    public GameObject Melee;
    public GameObject loseUI;
    

    public float speed = 6f;
    public float rotationSpeed;
    public float jumpSpeed;
    [SerializeField] private float jumpButtonGracePeriod;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    public float AttackCooldown = 1.0f;
    public bool isJumping;
    public bool isHovering;
    public bool isGrounded;
    public bool hasHovering = false;
    public bool CanAttack = true;
    public bool isAttacking = false;
    public int honor = 0;
    public int totalbots = 0;
    
    private Animator miloAnim;
    public float ySpeed;
    private float originalStepOffset;
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip hoverSound;

    //test code for HP
   // public int maxHP = 100;





    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        miloAnimator = GetComponent<Animator>();
        originalStepOffset = controller.stepOffset;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        loseUI.SetActive(false);
        UnFreezePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        //player movement inputs (using input management to prepare for controller support)
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        float magnitude = Mathf.Clamp01(direction.magnitude) * speed;

        direction = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * direction;

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (controller.isGrounded)
        {
            lastGroundedTime = Time.time;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpButtonPressedTime = Time.time;
        }

        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {
            controller.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            miloAnimator.SetBool("isGrounded", true);
            isGrounded = true;
            miloAnimator.SetBool("isJumping", false);
            isJumping = false;
            miloAnimator.SetBool("isFalling", false);
            
            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                ySpeed = jumpSpeed;
                SoundEffectScripts.instance.PlaySoundClip(jumpSound, transform, 1f);
                miloAnimator.SetBool("isJumping", true);
                isJumping = true;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }
        }
        else
        {
            controller.stepOffset = 0;
            miloAnimator.SetBool("isGrounded", false);
            isGrounded = false;

            if ((isJumping && ySpeed < 0) || ySpeed < -2)
            {
                miloAnimator.SetBool("isFalling", true);
            }
        }

        Vector3 velocity = direction * magnitude;
        velocity.y = ySpeed;

        controller.Move(velocity * Time.deltaTime);

        if(Input.GetButtonDown("Ability") && isJumping == true && hasHovering == true)
        {
            StartCoroutine(Hovering());
        }

        if(Input.GetButtonUp("Ability") && isHovering == true)
        {
            ySpeed = -0.5f;
            isHovering = false;
            Physics.gravity = new Vector3(0, -19, 0);
        }











        if (direction != Vector3.zero)//checks movement and smooth rotation
        {
            miloAnimator.SetBool("isMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            miloAnimator.SetBool("isMoving", false);
        }

        if(Input.GetButtonDown("Melee") && isGrounded)
        {
            if (CanAttack)
            {
                MeleeAttack();
                SoundEffectScripts.instance.PlaySoundClip(attackSound, transform, 1f);
                //Debug.Log("Attack Executed.");
            }
        }
        

        //Shop Input
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    RaycastHit hit = Physics.Raycast(rb.position + Vector3.up * 0.2f, direction, 1.5f, LayerMask.GetMask("Shop"));
        //    if (hit.collider != null)
        //   {
        //        Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
        //    }
        //        }

        //if (Input.GetKeyDown(KeyCode.K))//dmg test
        //{
            //PlayerTakeDamage(20);
            //Debug.Log(GameManager.gameManager.playerHP.Health);
        //}

        if (GameManager.gameManager.playerHP.Health <= 0)// death function
        {
            controller.enabled = false;
            loseUI.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void FreezePlayer()
    {
        speed = 0f;
   }
   public void UnFreezePlayer()
    {
        speed = 9f;
    }

    public void PlayerTakeDamage(int dmg)
    {
        GameManager.gameManager.playerHP.DamageUnit(dmg);

    }

        public void PlayerHeal(int healing)
    {
        GameManager.gameManager.playerHP.HealUnit(healing);
    }

    IEnumerator Hovering()//to do: implement cooldown so if player reaches ground early, they cannot hover until coroutine ends.
    {
        SoundEffectScripts.instance.PlaySoundClip(hoverSound, transform, 1f);
        ySpeed = 0.5f;
        isHovering = true;
        Physics.gravity = new Vector3(0, 0, 0);
        

        yield return new WaitForSeconds (3f);

        ySpeed = -0.5f;
        isHovering = false;
        Physics.gravity = new Vector3(0, -19, 0);
    }

    public void HoverObtained()
    {
        hasHovering = true;
    }

    public void AddHonor()
    {
        StartCoroutine(HonorDelay());
        //Debug.Log(honor);
    }

    public void AddTotalBots()
    {
        StartCoroutine(TotalBotDelay());
    }

    public void MeleeAttack()
    {
        isAttacking = true;
        CanAttack = false;
        Animator colliderAnim = Melee.GetComponent<Animator>();
        colliderAnim.SetTrigger("Attack");
        miloAnimator.SetBool("isAttacking", true);
        speed = 5f;
        //AudioSource as = GetComponent<AudioSource>();
        //as.PlayOneShot(AttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
        miloAnimator.SetBool("isAttacking", false);
        speed = 10f;
    }

    IEnumerator HonorDelay()
    {
        yield return new WaitForSeconds(1);
        honor += 1;
    }

    IEnumerator TotalBotDelay()
    {
        yield return new WaitForSeconds(1);
        totalbots += 1;
    }
}


