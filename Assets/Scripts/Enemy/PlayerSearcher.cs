using System.Collections;
using UnityEngine;

public class PlayerSearcher : MonoBehaviour
{
    [SerializeField] protected int lookDistance;
    [HideInInspector] public Collider2D player;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookDistance);
    }

    void Start() =>
        StartCoroutine(CheckPlayerTimer());

    void CheckPlayer()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, lookDistance);

        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].GetComponent<PlayerMover>() == true && player == null)
            {
                player = objects[i];
                FindPlayer();
            }
        }

        StartCoroutine(CheckPlayerTimer());
    }

    //ћетод пуст. ѕотому что, у каждого типа врагов свое представление, что делать при нахождении игрока
    public virtual void FindPlayer()
    {
    }

    protected IEnumerator CheckPlayerTimer()
    {
        yield return new WaitForSeconds(0.2f);
        CheckPlayer();
    }
}