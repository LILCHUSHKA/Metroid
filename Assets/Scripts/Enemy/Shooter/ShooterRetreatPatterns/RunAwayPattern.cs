using UnityEngine;

public class RunAwayPattern : RetreatPatterns
{
    [SerializeField] protected Vector2 direction;
    Vector3 runAwayPoint;

    private void FixedUpdate()
    {
        if (walk.isRetreat == true) Run(direction);
    }

    public override void ActivePattern() =>
        RunAway();

    protected void RunAway()
    {
        walk.isRetreat = true;

        runAwayPoint.y = transform.localPosition.y;

        if (transform.rotation.y == 0) runAwayPoint.x = transform.localPosition.x - 40;
        else runAwayPoint.x = transform.localPosition.x + 40;
    }

    protected void Run(Vector2 direction)
    {
        if (transform.position.x > runAwayPoint.x) transform.rotation = new Quaternion(0, 180, 0, 0);
        else transform.rotation = new Quaternion(0, 0, 0, 0);

        if (Vector2.Distance(transform.localPosition, runAwayPoint) > 1f)
        {
            anim.Play("Run");
            transform.Translate(direction * Time.deltaTime);
        }
        else
        {
            walk.isRetreat = false;
            anim.Play("Shoot");
        }
    }
}