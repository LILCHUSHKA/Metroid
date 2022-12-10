using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlyBehaviour : MonoBehaviour
{
    FlyController controller;

    [SerializeField] Text nameText;
    [SerializeField] int attackSpeed;
    [SerializeField] float chargingTime;

    public bool isAttack = false;
    public int lookDistance;
    public Collider2D player;

    bool isCharge = false;

    Vector3 attackPoint;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lookDistance);
    }

    private void FixedUpdate()
    {
        if (isAttack == true)
            FlyToPoint();
    }

    void Start()
    {
        controller = GetComponent<FlyController>();
        StartCoroutine(CheckPlayerTimer());
    }

    public void FindPlayer()
    {
        controller.BattleState = true;

        StartCoroutine(ChargingTimer());

        nameText.gameObject.SetActive(true);
        nameText.text = GetComponent<Character>().name;
    }

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

    private void FlyToPoint()
    {
        transform.position += (attackPoint - transform.position).normalized * attackSpeed * Time.deltaTime;

        if (attackPoint.x < transform.position.x)
            transform.rotation = new Quaternion(0, 180, 0, 0);
        else
            transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    void Charge()
    {
        controller.AnimStates = FlyController.States.charging;
        attackPoint = player.transform.position;

    }

    IEnumerator ChargingTimer()
    {
        Charge();

        yield return new WaitForSeconds(chargingTime);

        //controller.AnimatorController.Play("Attack");
        isAttack = true;
    }

    IEnumerator CheckPlayerTimer()
    {
        yield return new WaitForSeconds(0.2f);
        CheckPlayer();
    }
}