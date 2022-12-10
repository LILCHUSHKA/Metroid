using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    public enum States
    {
        charging,
        fly,
        die
    };

    public States AnimStates;

    public Animator AnimatorController;

    Vector3 StartPoz;

    [SerializeField] float MinMovingDistance, Speed;
    public bool BattleState;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, MaxDistanceCreatingPoint);
    }

    private void Start()
    {
        StartPoz = transform.position;
        CreatePoint();
    }

    void Update() => PlayAnimation();

    private void FixedUpdate()
    {
        if (BattleState == false) Fly();
    }

    void Fly()
    {
        transform.position += (Point - transform.position).normalized * Speed * Time.deltaTime;

        if (Point.x < transform.position.x)
            transform.rotation = new Quaternion(0, 180, 0, 0);
        else
            transform.rotation = new Quaternion(0, 0, 0, 0);

    }

    [SerializeField] float MaxDistanceCreatingPoint;
    public Vector3 Point;

    void CreatePoint()
    {
        Point.x = Random.Range(StartPoz.x - MaxDistanceCreatingPoint, StartPoz.x + MaxDistanceCreatingPoint);
        Point.y = Random.Range(StartPoz.y - MaxDistanceCreatingPoint, StartPoz.y + MaxDistanceCreatingPoint);
        Point.z = StartPoz.z;

        if (Point.x < StartPoz.x)
            transform.rotation = new Quaternion(0, 180, 0, 0);
        else
            transform.rotation = new Quaternion(0, 0, 0, 0);
        StartCoroutine(PointCoroutine());
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
            case "isCharge":
                AnimatorController.Play("Charge");
                break;
            case "isFly":
                AnimatorController.Play("Fly");
                break;
            case "isDie":
                AnimatorController.Play("Die");
                break;
        }
    }

    private void PlayAnimation() //Этот метод должен вызываться каждый кадр, тк он решает, какое состояние принимает персонаж 
    {
        switch (AnimStates)
        {
            case States.charging:
                ActiveState("isCharge");
                break;
            case States.fly:
                ActiveState("isFly");
                break;
            case States.die:
                ActiveState("isDie");
                break;
        }
    }
}