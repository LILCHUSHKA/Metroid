using UnityEngine;
using System.Collections;

public class FlyAttack : MonoBehaviour
{
    FlyController controller;
    FlyBehaviour behaviour;

    [SerializeField] float stanTime;
    int damageValue;

    public int formerLookDistance;

    private void Awake()
    {
        controller = GetComponent<FlyController>();
        behaviour = GetComponent<FlyBehaviour>();

        damageValue = GetComponent<Character>().damageValue;
    }

    private void Start() => formerLookDistance = behaviour.lookDistance;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Stan();

        if (collision.gameObject.GetComponent<Character>() == true)
        {
            GiveDamage(collision);
            Stan();
        }
    }

    public virtual void GiveDamage(Collision2D col) => col.gameObject.GetComponent<PlayerHealthHandler>().TakeDamage(damageValue);

    void Stan()
    {
        behaviour.lookDistance = 0;
        behaviour.player = null;
        controller.BattleState = false;
        behaviour.isAttack = false;

        controller.AnimStates = FlyController.States.fly;

        StartCoroutine(StanTimer());
    }

    IEnumerator StanTimer()
    {
        yield return new WaitForSeconds(stanTime);
        behaviour.lookDistance = formerLookDistance;
    }
}