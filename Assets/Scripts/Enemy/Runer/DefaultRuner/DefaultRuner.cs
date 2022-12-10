using System.Collections;
using UnityEngine;

public class DefaultRuner : RunerAttack
{
    [SerializeField] int stanTime;

    float formerSpeed;
    RunerController controller;

    private void Start()
    {
        controller = GetComponent<RunerController>();
        formerSpeed = controller.speed;
    }

    public override void GiveDamage(Collision2D col)
    {
        base.GiveDamage(col);

        controller.speed = 0;

        StartCoroutine(StanTimer());
    }

    IEnumerator StanTimer()
    {
        yield return new WaitForSeconds(stanTime);
        controller.speed = formerSpeed;
    }
}