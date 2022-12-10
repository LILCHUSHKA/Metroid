using UnityEngine;

public class TransitionState : StateMachineBehaviour
{
    [SerializeField] string triggerName;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) =>
        PlayerInput.input.canReceiveInput = true;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PlayerInput.input.inputReceived)
        {
            animator.SetTrigger(triggerName);
            PlayerInput.input.ManageInput(true);
            PlayerInput.input.inputReceived = false;
        }
    }
}