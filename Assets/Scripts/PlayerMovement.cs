using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed;
    private float defaultSpeed;
    private float jumpingPower;
    private float jumpingPowerBig;
    private float defaultJumpOffset;

    internal Rigidbody2D rb;
    internal BallController playerController;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private LayerMask rubberLayer;

    private float raycastLength = 0.6f;
    private float raycastLengthBigBall = 0.9f;

    private bool isGrounded;
    private bool isRubber;
    private bool isGroundedFlag;

    internal bool isPowerJump = false;
    internal bool isPowerGravity = false;
    internal bool isPowerSpeed = false;
    float jumpOffset = 0;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerController = gameObject.GetComponent<BallController>();
        speed = GameManager.instance.defaultSpeed;

        defaultSpeed = GameManager.instance.defaultSpeed;
        jumpingPower = GameManager.instance.jumpingPower;
        jumpingPowerBig = GameManager.instance.jumpingPowerBig;
        defaultJumpOffset = GameManager.instance.defaultJumpOffset;
    }

    public void ChangePowerJump(bool value)
    {
        isPowerJump = value;
        if (value)
        {
            isPowerGravity = false;
            isPowerSpeed = false;
        }
    }

    public void ChangePowerGravity(bool value)
    {
        isPowerGravity = value;
        if (value)
        {
            isPowerJump = false;
            isPowerSpeed = false;
        }

        if ((value && rb.gravityScale > 0) || (!value && rb.gravityScale < 0))
        {
            rb.gravityScale = -rb.gravityScale;
            jumpingPower = -jumpingPower;
            jumpingPowerBig = -jumpingPowerBig;
            defaultJumpOffset = -defaultJumpOffset;
        }
    }

    public void ChangePowerSpeed(bool value)
    {
        isPowerSpeed = value;
        if (value)
        {
            isPowerJump = false;
            isPowerGravity = false;

            speed = defaultSpeed + 2f;
        }
        else
        {
            speed = defaultSpeed - 2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrounded();
        CheckJumpad();
        isGroundedFlag = isGrounded | isRubber;
        if (Time.timeScale == 0) return;

        horizontal = Input.GetAxisRaw("Horizontal");

        bool isJump = Input.GetButtonDown("Jump") || Input.GetButton("Jump");
        if (!isGroundedFlag) return;

        float jumpPower = playerController.ballState == BallState.Big ? jumpingPowerBig : jumpingPower;
        if (isJump && isRubber)
        {
            isGroundedFlag = true;
            Debug.Log("isRubber");
            jumpOffset += defaultJumpOffset;
        }
        else if (!isPowerJump)
        {
            jumpOffset = 0;
        }

        if (isJump && isGroundedFlag)
        {
            Debug.Log("isGrounded");
            isGroundedFlag = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower + jumpOffset);
        }
        
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void CheckGrounded()
    {
        float raycast = playerController.ballState == BallState.Big ? raycastLengthBigBall : raycastLength;
        Vector2 dir = isPowerGravity ? Vector2.up : Vector2.down;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, raycast, groundLayer);
        isGrounded = hit.collider != null;

        Debug.DrawRay(transform.position, dir * raycast, isGrounded ? Color.green : Color.red);
    }


    private void CheckJumpad()
    {
        float raycast = playerController.ballState == BallState.Big ? raycastLengthBigBall : raycastLength;
        Vector2 dir = isPowerGravity ? Vector2.up : Vector2.down;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, raycast, rubberLayer);
        isRubber = hit.collider != null;

        Debug.DrawRay(transform.position, dir * raycast, isRubber ? Color.green : Color.red);
    }
}
