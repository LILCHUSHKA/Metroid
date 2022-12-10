using UnityEngine;

//Перегнать сюда ComeToLife
public class PlayerInputActions : MonoBehaviour
{
    Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayOneAnimation(string animationName) => animator.Play(animationName);

    public void Heal() 
    {

    }
}