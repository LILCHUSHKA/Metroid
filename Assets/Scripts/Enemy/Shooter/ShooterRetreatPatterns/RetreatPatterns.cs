using UnityEngine;

public class RetreatPatterns : MonoBehaviour
{
    protected Animator anim;
    protected WalkShooter walk;

    private void Awake()
    {
        walk = GetComponent<WalkShooter>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMover>())
        {
            ActivePattern();
        }
    }

    public virtual void ActivePattern()
    {
    }

    int GenerateSolution()
    {
        System.Random rand = new System.Random();

        return rand.Next(0, 2);
    }
}