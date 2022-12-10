using UnityEngine;

public class ChurchDefender : BossBehaviour
{
    [Header("Размер области, в которой босс будет доджить")]
    [SerializeField] Vector2 dodgeAraeSize;

    [Header("Аниматор главной камеры")]
    [SerializeField] Animator cameraAnimator;

    float speed = 0;

    [Header("Основная скорость передвижения")]
    [SerializeField] float movingSpeed;

    [Header("Скорость бега")]
    [SerializeField] float runSpeed;

    [HideInInspector] public bool isRun;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isRun = false;
        animator.SetBool("run", false);
        animator.SetBool("p2_prepare", false);

        bossTrigger.isTrigger = false;

        if (collision.GetComponent<PlayerHealthHandler>())
        {
            HitPlayer(playerTransform);
            CreateSolution("p2_1");
        }
    }

    private void FixedUpdate()
    {
        Move();

        if (isRun) Run();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, attackAreaSize);

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, dodgeAraeSize);
    }

    public void ShakeCamera(string shakeName) => cameraAnimator.Play(shakeName);

    void Move()
    {
        if (playerTransform != null)
        {
            if (Vector2.Distance(transform.position, playerTransform.transform.position) < attackAreaSize.x / 1.5f)
            {
                animator.SetBool("walk", false);
                animator.SetBool("p1_prepare", true);
            }

            else
            {
                animator.SetBool("walk", true);
                animator.SetBool("p1_prepare", false);
                transform.Translate(0 + (speed * Time.deltaTime), 0, 0);
            }
        }

        else
        {
            if (Vector2.Distance(transform.position, startPosition) < 0.1f)
            {
                animator.SetBool("walk", false);
                this.enabled = false;
            }

            else
            {
                animator.SetBool("walk", true);
                animator.SetBool("p1_prepare", false);

                transform.Translate(0 + (speed * Time.deltaTime), 0, 0);

                if (transform.position.x > startPosition.x) transform.localScale = new Vector3(characterScale.x, characterScale.y, characterScale.z);

                else transform.localScale = new Vector3(-characterScale.x, characterScale.y, characterScale.z);
            }
        }
    }

    public void StopMoving() => speed = 0;

    public void ContinueMoving() => RotateToPlayer();

    public void RotateToPlayer()
    {
        if (playerTransform.position.x < transform.position.x)
        {
            speed = -movingSpeed;
            transform.localScale = new Vector3(characterScale.x, characterScale.y, characterScale.z);
        }
        else
        {
            speed = movingSpeed;
            transform.localScale = new Vector3(-characterScale.x, characterScale.y, characterScale.z);
        }
    }

    protected override void ActiveNextFaze(string fazeName)
    {
        base.ActiveNextFaze(fazeName);
        speed = 0;
    }

    protected override void HitPlayer(Transform player)
    {
        player.GetComponent<Rigidbody2D>().AddForce(transform.up * 4, ForceMode2D.Impulse);
        player.GetComponent<Rigidbody2D>().AddForce(transform.right * -3, ForceMode2D.Impulse);
    }

    Vector2 dodgePoint;

    public void CreateDodgeSolution()
    {
        int solution = Random.Range(1, 10);

        if (solution > 4)
        {
            if (CheckPlayerPosition(dodgeAraeSize))
            {
                animator.SetBool("walk", false);
                animator.SetBool("run", true);
                animator.SetBool("p2_prepare", true);

                if (playerTransform.position.x < transform.position.x)
                    dodgePoint = new Vector2(playerTransform.position.x - 2, transform.position.y);
                else dodgePoint = new Vector2(playerTransform.position.x + 2, transform.position.y);
            }
            else return;
        }
        else return;
    }

    void Run()
    {
        if (Vector2.Distance(transform.position, dodgePoint) > 0.1f)
        {
            if (dodgePoint.x < transform.position.x)
                transform.Translate(0 + (-runSpeed * Time.deltaTime), 0, 0);
            else transform.Translate(0 + (runSpeed * Time.deltaTime), 0, 0);
        }

        else
        {
            animator.SetBool("p2_prepare", false);
            animator.SetBool("run", false);
            isRun = false;
        }
    }
}