using UnityEngine;
using UnityEngine.Events;

public class DamageHandler : MonoBehaviour
{
    [HideInInspector] public UnityEvent<Transform> OnGiveDamage;

    Character character;

    [Header("Объект от которого будет передаваться урон")]
    [SerializeField] Transform damageTrigger;

    int damageValue;

    [Header("Размер области урона")]
    [SerializeField] Vector2 damageAreaSize;

    private void Awake()
    {
        character = GetComponent<Character>();
        damageValue = character.damageValue;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(damageTrigger.position, new Vector3(damageAreaSize.x, damageAreaSize.y, 0));
    }

    public void Move(float moveForce)
    {
        if (transform.localScale.x < 0)
            transform.position = new Vector3(transform.position.x - moveForce, transform.position.y, transform.position.z);
        else transform.position = new Vector3(transform.position.x + moveForce, transform.position.y, transform.position.z);
    }

    public void GiveDamage()
    {
        Collider2D[] hitObjects = Physics2D.OverlapBoxAll(damageTrigger.position, damageAreaSize, 0);

        foreach (Collider2D hitObject in hitObjects)
        {
            if (character.characterType == Character.CharacterTypes.hero)
            {
                if (hitObject.GetComponent<EnemyHealthHandler>())
                    hitObject.GetComponent<EnemyHealthHandler>().TakeDamage(damageValue);

                if (hitObject.GetComponent<Chest>()) hitObject.GetComponent<Chest>().OpenChest();
            }

            if (character.characterType == Character.CharacterTypes.enemy)
            {
                if (hitObject.GetComponent<PlayerHealthHandler>())
                {
                    OnGiveDamage.Invoke(hitObject.transform);
                    hitObject.GetComponent<PlayerHealthHandler>().TakeDamage(damageValue);
                }
            }
        }
    }
}