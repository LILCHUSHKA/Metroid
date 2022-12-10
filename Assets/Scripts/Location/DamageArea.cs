using UnityEngine;

public class DamageArea : MonoBehaviour
{
    [Header("�� ����� �������� �������� ������������ �����")]
    [SerializeField] int damageValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHealthHandler>())
            collision.GetComponent<PlayerHealthHandler>().TakeDamage(damageValue);
    }
}