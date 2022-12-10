using UnityEngine;

public class FallingType : ProjectileBehaviour
{
    [HideInInspector] public Vector3 endPos;

    [SerializeField] float speed;
    [SerializeField] protected float impulseValue;

    private void Start()
    {
        StartCoroutine(DestroyTimer(5));
        AddForceToProjectile();
    }

    public override void FlyToPoint()
    {
        transform.position += (endPos - transform.position).normalized * speed * Time.deltaTime;
        if (Vector2.Distance(transform.position, endPos) < 1f) Destroy(gameObject);
    }

    public virtual void AddForceToProjectile() =>
        GetComponent<Rigidbody2D>().AddForce(transform.up * impulseValue, ForceMode2D.Impulse);
}