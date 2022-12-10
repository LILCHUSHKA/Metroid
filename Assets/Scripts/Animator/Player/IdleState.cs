using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) =>
        PlayerInput.input.canReceiveInput = true;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PlayerInput.input.inputReceived)
        {
            animator.SetTrigger("AttackA");
            PlayerInput.input.ManageInput(true);
            PlayerInput.input.inputReceived = false;
        }

        if (PlayerInput.input.isBlocking) animator.Play("BlockSet");
    }
}