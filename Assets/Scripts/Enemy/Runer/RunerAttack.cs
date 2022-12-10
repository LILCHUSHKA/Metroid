using UnityEngine;

public class RunerAttack : MonoBehaviour
{
    int damageValue;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        damageValue = GetComponent<Character>().damageValue;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealthHandler>())
            GiveDamage(collision);
    }

    public virtual void GiveDamage(Collision2D col)
    {
        //if (col.gameObject.GetComponent<PlayerInput>().isBlocking) animator.Play(имя анимации при парировании игроком); else 

        col.gameObject.GetComponent<PlayerHealthHandler>().TakeDamage(damageValue);
    }
}