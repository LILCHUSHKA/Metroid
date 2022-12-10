using System.Collections;
using UnityEngine;

//Run or Die
public class RunerController : MonoBehaviour
{
    enum States
    {
        idle,
        run,
        die
    };

    States State;

    public Animator animator;

    public float speed;
    Vector3 startPoz;

    [SerializeField] float minMovingDistance;
    public bool battleState;

    private void Start()
    {
        startPoz = transform.position;
        CreatePoint();
    }

    void Update() => PlayAnimation();

    private void FixedUpdate() => Run();

    void Run()
    {
        if (Vector2.Distance(transform.position, point) < minMovingDistance)
        {
            State = States.idle;
            transform.position = transform.position;
        }
        else
        {
            State = States.run;
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
        point.x = Random.Range(startPoz.x - maxDistanceCreatingPoint, startPoz.x + maxDistanceCreatingPoint);

        point.y = startPoz.y;
        point.z = startPoz.z;

        if (point.x < startPoz.x)
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

    private void ActiveState(string StateName)
    {
        switch (StateName)
        {
            case "isIdle":
                animator.Play("Idle");
                break;
            case "isRun":
                animator.Play("Run");
                break;
            case "isDie":
                animator.Play("Die");
                break;
        }
    }

    private void PlayAnimation()
    {
        switch (State)
        {
            case States.idle:
                ActiveState("isIdle");
                break;
            case States.run:
                ActiveState("isRun");
                break;
            case States.die:
                ActiveState("isDie");
                break;
        }
    }
}