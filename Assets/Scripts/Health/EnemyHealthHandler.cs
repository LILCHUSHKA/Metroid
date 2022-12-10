using UnityEngine;
using UnityEngine.Events;

public class EnemyHealthHandler : MonoBehaviour
{
    public UnityEvent<int> OnHealthChange;
    public UnityEvent<bool> OnDeath;

    Character enemyCharacter;

    private void Awake() => enemyCharacter = GetComponent<Character>();

    public void TakeDamage(int damage)
    {
        OnHealthChange.Invoke(enemyCharacter.health);

        enemyCharacter.health -= damage;
        if (enemyCharacter.health <= 0) OnDeath.Invoke(true);
    }
}