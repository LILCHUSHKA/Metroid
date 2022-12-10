using UnityEngine;

public class RunerBehaviour : PlayerSearcher
{
    RunerController controller;

    void Awake() => controller = GetComponent<RunerController>();

    private void FixedUpdate()
    {
        if (player != null) RunToPlayer();
    }

    void RunToPlayer()
    {
        if (Vector2.Distance(transform.position, controller.point) < 0.1f)
        {
            controller.battleState = false;
            player = null;

            StartCoroutine(controller.PointCoroutine());
        }
    }

    void ChangeMoveCoordinates(Vector3 newVector) => controller.point.x = newVector.x;

    public override void FindPlayer()
    {
        ChangeMoveCoordinates(player.transform.position);

        //controller.speed /= 1.5f;
        controller.battleState = true;
    }
}