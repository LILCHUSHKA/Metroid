using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    [SerializeField] int damageValue;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.GetComponent<PlayerHealthHandler>())
            GiveDamage(collision);
    }

    public virtual void GiveDamage(Collision2D col)
    {
        col.gameObject.GetComponent<PlayerHealthHandler>().TakeDamage(damageValue);
        Destroy(gameObject);
    }
}