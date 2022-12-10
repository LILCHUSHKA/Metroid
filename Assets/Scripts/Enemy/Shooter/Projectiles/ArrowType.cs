using UnityEngine;
using System.Collections;

public class ArrowType : ProjectileBehaviour
{
    Vector2 direction;
    [Header("Скорость снаряда")] [SerializeField] float speed;

    private void Start()
    {
        StartCoroutine(DestroyTimer(3));
        direction.x = 1;
    }

    public override void FlyToPoint() => transform.Translate(direction * Time.deltaTime * speed);

}