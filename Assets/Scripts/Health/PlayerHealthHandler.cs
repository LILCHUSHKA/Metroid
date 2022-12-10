using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealthHandler : MonoBehaviour
{
    [SerializeField] UnityEvent OnHealthChanged, OnDeath;

    [SerializeField] Slider healthbar;

    Character character;

    Animator animator;

    private void Awake()
    {
        character = GetComponent<Character>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        healthbar.maxValue = character.maxHealth;
        healthbar.value = character.health;
    }

    public void TakeDamage(int damage)
    {
        animator.Play("TakeDamage");
        character.health -= damage;

        HandleHealth();
    }

    public void HandleHealth()
    {
        OnHealthChanged.Invoke();

        healthbar.value = character.health;

        if (character.health <= 0) Die();
    }

    public void HandleMaxHealth()
    {
        healthbar.maxValue = character.maxHealth;
        if (character.maxHealth < character.health) character.health = character.maxHealth;
    }

    public void RestoreHP()
    {
        character.health = character.maxHealth;
        HandleHealth();
    }

    public void Die()
    {
        animator.Play("Death");
        OnDeath.Invoke();
    }
}