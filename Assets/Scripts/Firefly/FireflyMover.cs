using UnityEngine;
using System.Collections;

public class FireflyMover : MonoBehaviour
{
    [SerializeField] private Transform hero;
    private Vector3 fireFlyDirection;
    [SerializeField] float Speed;

    private void Start()
    {
        fireFlyDirection.x = Random.Range((int)hero.position.x + 1, (int)hero.position.x - 1);
        fireFlyDirection.y = Random.Range((int)hero.position.y + 1, (int)hero.position.y + 3);

        StartCoroutine(CreateMovingPoint());
    }

    private void FixedUpdate() =>
        Move();

    void Move() =>
        transform.position = Vector3.Lerp(transform.position, fireFlyDirection, Time.deltaTime * Speed);
    
    IEnumerator CreateMovingPoint()
    {
        yield return new WaitForSeconds(0.2f);

        fireFlyDirection.x = Random.Range((int)hero.position.x + 5, (int)hero.position.x - 5);
        fireFlyDirection.y = Random.Range((int)hero.position.y + 3, (int)hero.position.y + 5);
        fireFlyDirection.z = 0;

        StartCoroutine(CreateMovingPoint());
    }
}