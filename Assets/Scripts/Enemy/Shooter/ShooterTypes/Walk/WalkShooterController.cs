using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkShooterController : MonoBehaviour
{
    public enum States
    {
        idle,
        run,
        die
    };

    public States state;

    public Animator animator;

    public float speed;
    Vector3 startPos;

    [SerializeField] float minMovingDistance;
    public bool battleState;

    private void Start()
    {
        startPos = transform.position;
        CreatePoint();
    }

    private void FixedUpdate()
    {
        if (!battleState) Run();
    }

    void Run()
    {
        if (Vector2.Distance(transform.position, point) < minMovingDistance)
        {
            animator.Play("Idle");
            transform.position = transform.position;
        }
        else
        {
            animator.Play("Run");
            transform.Translate(0 + (speed * Time.deltaTime), 0, 0);
        }


        if (point.x < transform.position.x)
            transform.rotation = new Quaternion(0, 180, 0, 0);
        else
            transform.rotation = new Quaternion(0, 0, 0, 0);

    }

    [SerializeField] float maxDistanceCreatingPoint;
    [HideInInspector] public Vector3 point;

    void CreatePoint()
    {
        point.x = Random.Range(startPos.x - maxDistanceCreatingPoint, startPos.x + maxDistanceCreatingPoint);

        point.y = startPos.y;
        point.z = startPos.z;

        if (point.x < startPos.x)
            transform.rotation = new Quaternion(0, 180, 0, 0);
        else
            transform.rotation = new Quaternion(0, 0, 0, 0);
        if (battleState == false) StartCoroutine(PointCoroutine());
    }

    public IEnumerator PointCoroutine()
    {
        yield return new WaitForSeconds(3);
        CreatePoint();
    }
}