using UnityEngine;

public class BlockIdleState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerInput.input.isBlock = true;
        PlayerInput.input.isBlocking = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PlayerInput.input.isBlock == false) animator.Play("Idle");
    }
}