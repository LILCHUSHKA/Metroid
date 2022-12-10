using UnityEngine;
using UnityEngine.Events;

public class InteractionWithBonfire : MonoBehaviour
{
    MainControler controler;

    [SerializeField] UnityEvent BonfireAction;

    private void Awake()
    {
        controler = new MainControler();
        controler.PlayerActions.Interact.performed += interactWithBonfire => BonfireAction.Invoke();
    }

    private void OnEnable() => controler.Enable();
    private void OnDisable() => controler.Disable();
}