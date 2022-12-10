using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] Hands hands;
    [SerializeField] Transform legs;

    public float speed;
    [SerializeField] float dashDistance, jumpForce;
    public float moveInput;

    bool isGrounded;
    [HideInInspector] public bool isDash;

    Vector2 dashTarget;
    Vector3 characterScale;

    Rigidbody2D playerPhys;
    [HideInInspector] public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerPhys = GetComponent<Rigidbody2D>();

        characterScale = transform.localScale;
    }

    private void FixedUpdate()
    {
        if (isDash) Dash();

        CheckGround();
        MoveCharacter();
    }

    void MoveCharacter()
    {
        if (moveInput != 0) Run();
        else animator.SetBool("isIdle", true);
    }

    void Run()
    {
        if (isGrounded)
        {
            isDash = false;

            animator.SetBool("isIdle", false);
            animator.Play("Run");

            if (moveInput > 0)
            {
                transform.Translate(0 + (speed * Time.deltaTime), 0, 0);
                transform.localScale = new Vector3(characterScale.x, characterScale.y, characterScale.z);
            }

            else
            {
                transform.Translate(0 + (-speed * Time.deltaTime), 0, 0);
                transform.localScale = new Vector3(-characterScale.x, characterScale.y, characterScale.z);
            }
        }

        else
        {
            if (moveInput > 0)
                ControllFlight(characterScale.x, speed);
            else
                ControllFlight(-characterScale.x, -speed);
        }
    }

    void ControllFlight(float xRotate, float speedValue)
    {
        transform.localScale = new Vector3(xRotate, characterScale.y, characterScale.z);
        transform.Translate(0 + (speedValue * Time.deltaTime), 0, 0);
    }

    public void Jump()
    {
        if (hands.isHange || isGrounded && !isDash)
        {
            playerPhys.constraints = RigidbodyConstraints2D.FreezeRotation;

            animator.SetBool("isIdle", false);
            animator.Play("Jump");

            playerPhys.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    //Изменить на физику
    public void Dash()
    {
        if (Vector2.Distance(transform.position, dashTarget) > 0.2f)
            transform.Translate(0 + ((dashDistance * 5) * Time.deltaTime), 0, 0);
    }

    public void CreateDashTarget()
    {
        dashTarget.y = transform.position.y;

        if (transform.rotation.y == 0)
            dashTarget.x = transform.position.x + dashDistance;
        else dashTarget.x = transform.position.x - dashDistance;
    }

    void CheckGround()
    {
        Collider2D[] ground = Physics2D.OverlapCircleAll(legs.position, 0.1f);

        //Сделать проверку по слоям
        isGrounded = ground.Length > 2;

        if (!isGrounded && !hands.isHange)
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isFall", true);
        }
        else animator.SetBool("isFall", false);
    }
}