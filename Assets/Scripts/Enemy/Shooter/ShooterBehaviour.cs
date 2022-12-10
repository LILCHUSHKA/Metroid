using System.Collections;
using UnityEngine;

public class ShooterBehaviour : PlayerSearcher
{
    [SerializeField] protected float coolDownValue;

    [SerializeField] Animator animatorController;

    public override void FindPlayer()
    {
        base.FindPlayer();
        StartCoroutine(ShootTimer());
    }

    public virtual void Shoot()
    {
    }

    protected IEnumerator ShootTimer()
    {
        yield return new WaitForSeconds(coolDownValue);
        animatorController.Play("Shoot");
    }
}