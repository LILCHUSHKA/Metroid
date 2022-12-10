using UnityEngine;
using UnityEngine.Events;

public class ComeToLife : MonoBehaviour
{
    public UnityEvent lifeAgain;

    Transform lastBonfire;
    Animator animator;

    [Header("Отступ по Х и Y от костра для телепортации")]
    [SerializeField] float X_Offset = 2;
    [SerializeField] float Y_Offset = 1;

    private void Awake() => animator = GetComponent<Animator>();
    
    public void ResurrectPlayer()
    {
        transform.position = new Vector2(lastBonfire.position.x - X_Offset, lastBonfire.position.y + Y_Offset);

        animator.SetBool("isDie", false);
        animator.SetBool("isIdle", true);

        animator.Play("Idle");
    }

    public void SetLastBonfire(Transform bonfire) => lastBonfire = bonfire;
}