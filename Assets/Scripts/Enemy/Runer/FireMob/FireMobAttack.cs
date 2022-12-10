using UnityEngine;

public class FireMobAttack : RunerAttack
{
    [Header("Область поражения взрыва")] [SerializeField] float explosionRange;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }

    public override void GiveDamage(Collision2D col)
    {
        base.GiveDamage(col);

        Collider2D[] lesionObjects = Physics2D.OverlapCircleAll(transform.position, explosionRange);

        for (int i = 0; i < lesionObjects.Length; i++)
        {
            if (lesionObjects[i].GetComponent<Character>())
            {
                
            }
        }

        Destroy(gameObject);
    }
}