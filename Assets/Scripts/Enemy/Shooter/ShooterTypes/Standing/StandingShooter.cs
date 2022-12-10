using UnityEngine;

public class StandingShooter : ShooterBehaviour
{
    [SerializeField] FallingType fallingProjectile;

    public override void Shoot()
    {
        fallingProjectile.endPos = player.transform.position;
        Instantiate(fallingProjectile, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        StartCoroutine(ShootTimer());
    }
}