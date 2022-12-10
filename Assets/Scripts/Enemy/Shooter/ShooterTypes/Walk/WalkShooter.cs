using UnityEngine;

public class WalkShooter : ShooterBehaviour
{
    WalkShooterController walkController;
    [SerializeField] ArrowType arrow;
    [SerializeField] public Transform parent;

    Vector3 direction;

    public bool isRetreat = false;

    private void Start()
    {
        StartCoroutine(CheckPlayerTimer());
        walkController = GetComponent<WalkShooterController>();

        direction.x = 3;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookDistance);
    }

    public override void FindPlayer()
    {
        base.FindPlayer();
        walkController.battleState = true;
        walkController.animator.Play("Idle");
    }

    private void FixedUpdate() => SpinForHero();

    public override void Shoot()
    {
        if (isRetreat == true)
        {
            Instantiate(arrow, new Vector3(parent.position.x, parent.position.y, 0), transform.rotation);
            StartCoroutine(ShootTimer());
        }
    }

    protected void SpinForHero()
    {
        if (isRetreat == false && walkController.battleState == true)
        {
            if (transform.position.x > player.transform.position.x)
                transform.rotation = new Quaternion(0, 180, 0, 0);
            else transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}