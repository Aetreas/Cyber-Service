using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThirdPersonMovement : MonoBehaviour
{
    public static ThirdPersonMovement Instance;

    public CharacterController controller;
    

    public float speed = 6f;
    public float rotationSpeed;
    public float jumpSpeed;
    public bool isJumping;
    public bool isHovering;
    public bool hasHovering = false;
    
    private float ySpeed;
    private float originalStepOffset;
    [SerializeField] private Transform cameraTransform;

    
    


    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        originalStepOffset = controller.stepOffset;
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
            controller.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            Physics.gravity = new Vector3(0, -19, 0);
            isJumping = false;
            isHovering = false;
            if(Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
                isJumping = true;
            }

        }
        else
        {
            controller.stepOffset = 0;
        }

        Vector3 velocity = direction * magnitude;
        velocity.y = ySpeed;

        controller.Move(velocity * Time.deltaTime);

        if(Input.GetButtonDown("Ability") && isJumping == true && hasHovering == true)
        {
            StartCoroutine(Hovering());
        }











        if (direction != Vector3.zero)//smooth rotation
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
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

        //if (Input.GetKeyDown(KeyCode.Q)) (player damage tester)
        //{
           // PlayerTakeDamage(20);
           // Debug.Log(GameManager.gameManager.playerHP.Health);
        //}

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

    private void PlayerTakeDamage(int dmg)
    {
        GameManager.gameManager.playerHP.DamageUnit(dmg);
    }

        private void PlayerHeal(int healing)
    {
        GameManager.gameManager.playerHP.HealUnit(healing);
    }

    IEnumerator Hovering()//to do: implement cooldown so if player reaches ground early, they cannot hover until coroutine ends.
    {
        isHovering = true;
        Physics.gravity = new Vector3(0, -0.5f, 0);

        yield return new WaitForSeconds (6f);

        isHovering = false;
        Physics.gravity = new Vector3(0, -19, 0);
    }

    public void HoverObtained()
    {
        hasHovering = true;
    }
}

