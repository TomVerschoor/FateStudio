using UnityEngine;

class DirectionalMovement
{
    public CharacterController controller; //needs to come from constructor and should stay public
    public Transform cam;
    private Transform transform;
    
    private float walkSpeed = 5.0f, runSpeed = 10.0f, moveSpeed = 10.0f;
    private float turnSmoothTime = 0.05f;
    
    private Transform groundCheck; //needs to come from constructor is child
    private float groundDistance = 0.1f;
    private LayerMask groundMask; //constructor public
    
    private float jumpForce = 0.15f, gravity = 0.5f;

    Vector3 moveDir, direction;
    float turnSmoothVelocity;
    float horizontal, vertical;
    float targetAngle, angle;
    bool isGrounded;

    private Animator animator;
    private int isWalkingHash = Animator.StringToHash("isWalking");
    private int isRunningHash = Animator.StringToHash("isRunning");
    private int isJumpingHash = Animator.StringToHash("isJumping");

    private GameObject player;

    //Constructor
    public DirectionalMovement(Animator animator, Transform transform, Transform cam, Transform groundCheck, LayerMask groundMask, CharacterController controller)
    {
        this.animator = animator;
        this.transform = transform;
        this.cam = cam;
        this.groundCheck = groundCheck;
        this.groundMask = groundMask;
        this.controller = controller;
    }

    public void PlayerMovement()
    {
        //Update

        if (!PauseMenu.gameIsPaused)
        {
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool(isJumpingHash, true);
            }

            if (Input.GetKey("left shift"))
            {
                moveSpeed = walkSpeed;
            }
            else
            {
                moveSpeed = runSpeed;
            }

            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            direction = new Vector3(horizontal, 0f, vertical).normalized;
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (direction.magnitude >= 0.1f)
            {
                if (!animator.GetBool(isWalkingHash))
                {
                    //start running animation
                    animator.SetBool(isRunningHash, true);
                }

                if (!animator.GetBool(isWalkingHash) && moveSpeed == walkSpeed)
                {
                    //start walking animation
                    animator.SetBool(isWalkingHash, true);
                }

                targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                moveDir = Quaternion.Euler(0f, targetAngle, 0f) * new Vector3(0, moveDir.y, 1);
                //UnityEngine.Debug.Log("moveing");
            }
            else
            {
                if (animator.GetBool(isRunningHash))
                {
                    //stop running animation
                    animator.SetBool(isRunningHash, false);
                }
            }

            if (animator.GetBool(isWalkingHash) && (!animator.GetBool(isRunningHash) || moveSpeed != walkSpeed))
            {
                //stop walking animation
                animator.SetBool(isWalkingHash, false);
            }
        }
    }

    public void PlayerJump()
    {
        //FixedUpdate
        if (!PauseMenu.gameIsPaused)
        {
            if (isGrounded)
            {
                if (animator.GetBool(isJumpingHash))
                {
                    moveDir.y = jumpForce;
                    animator.SetBool(isJumpingHash, false);
                }
                else
                {
                    moveDir.y = -0.001f;
                    animator.SetBool(isJumpingHash, false);
                }
            }
            else
            {
                moveDir.y -= gravity * Time.deltaTime;
                animator.SetBool(isJumpingHash, false);
            }

            moveDir.x = moveDir.x * moveSpeed * Time.deltaTime;
            moveDir.z = moveDir.z * moveSpeed * Time.deltaTime;
            controller.Move(moveDir);
        }
    }

    /*
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        //Can be used for 
        //if (GameObject.Find("ArenaModel"))
        //{
        //    inArena = true;
        //}
        //else
        //    inArena = false;

        if (!PauseMenu.gameIsPaused)
        {
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool(isJumpingHash, true);
            }

            if (Input.GetKey("left shift"))
            {
                moveSpeed = walkSpeed;
            }
            else
            {
                moveSpeed = runSpeed;
            }

            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            direction = new Vector3(horizontal, 0f, vertical).normalized;
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (direction.magnitude >= 0.1f)
            {
                if (!animator.GetBool(isWalkingHash))
                {
                    //start running animation
                    animator.SetBool(isRunningHash, true);
                }

                if (!animator.GetBool(isWalkingHash) && moveSpeed == walkSpeed)
                {
                    //start walking animation
                    animator.SetBool(isWalkingHash, true);
                }

                targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                moveDir = Quaternion.Euler(0f, targetAngle, 0f) * new Vector3(0, moveDir.y, 1);
                //UnityEngine.Debug.Log("moveing");
            }
            else
            {
                if (animator.GetBool(isRunningHash))
                {
                    //stop running animation
                    animator.SetBool(isRunningHash, false);
                }
            }

            if (animator.GetBool(isWalkingHash) && (!animator.GetBool(isRunningHash) || moveSpeed != walkSpeed))
            {
                //stop walking animation
                animator.SetBool(isWalkingHash, false);
            }
        }
    }


    void FixedUpdate()
    {
        if (!PauseMenu.gameIsPaused)
        {
            if (isGrounded)
            {
                if (animator.GetBool(isJumpingHash))
                {
                    moveDir.y = jumpForce;
                    animator.SetBool(isJumpingHash, false);
                }
                else
                {
                    moveDir.y = -0.001f;
                    animator.SetBool(isJumpingHash, false);
                }
            }
            else
            {
                moveDir.y -= gravity * Time.deltaTime;
                animator.SetBool(isJumpingHash, false);
            }

            moveDir.x = moveDir.x * moveSpeed * Time.deltaTime;
            moveDir.z = moveDir.z * moveSpeed * Time.deltaTime;
            controller.Move(moveDir);
        }

    }
    */
}


