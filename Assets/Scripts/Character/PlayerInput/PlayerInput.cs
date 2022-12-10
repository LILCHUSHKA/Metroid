using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public  bool canReceiveInput = true, inputReceived;
    [HideInInspector] public bool isBlocking, isBlock;
    [HideInInspector] public bool canDash = true;

    public static PlayerInput input;
    MainControler controler;

    [SerializeField] InformationPanel informationPanelInput;
    [SerializeField] Mouse mouseInput;

    PlayerMover playerMover;
    PlayerInputActions inputActions;


    private void Awake()
    {
        controler = new MainControler();

        playerMover = GetComponent<PlayerMover>();
        input = GetComponent<PlayerInput>();
        inputActions = GetComponent<PlayerInputActions>();

        #region Information panel input
        controler.PlayerActions.OpenMap.performed += openMap =>
        informationPanelInput.OpenInformationPanel(informationPanelInput.OnMapOpen);

        controler.PlayerActions.OpenInvenotory.performed += openInventory =>
        informationPanelInput.OpenInformationPanel(informationPanelInput.OnInventoryOpen);
        #endregion

        #region Mouse input
        controler.PlayerActions.Punch.performed += punch =>
        {
            mouseInput.Punch();
        };

        controler.PlayerActions.Block.performed += block =>
        {
            if (canReceiveInput) isBlocking = true;
        };

        controler.PlayerActions.Block.canceled += block => isBlock = false;
        #endregion

        #region Keyboard input
        controler.PlayerActions.Jump.performed += jump =>
        {
            if (canReceiveInput) playerMover.Jump();
        };
        controler.PlayerActions.Heal.performed += heal => inputActions.PlayOneAnimation("Heal");

        controler.PlayerActions.Dash.performed += dash =>
        {
            if (canDash && canReceiveInput) playerMover.animator.Play("Dash");
        };


        #endregion
    }

    private void OnEnable() => controler.Enable();
    private void OnDisable() => controler.Disable();

    public void ManageInput(bool inputState) => canReceiveInput = inputState;

    private void FixedUpdate()
    {
        if (canReceiveInput) playerMover.moveInput = controler.PlayerActions.Move.ReadValue<float>();
    }
}

[System.Serializable]
public class InformationPanel
{
    public GameObject parentPanel;
    [Space(10)]
    public UnityEvent OnInventoryOpen, OnMapOpen, OnClose;

    public void OpenInformationPanel(UnityEvent selectEvent)
    {
        if (parentPanel.activeSelf) OnClose.Invoke();

        else
        {
            selectEvent.Invoke();
            parentPanel.SetActive(true);
        }
    }
}

[System.Serializable]
public class Mouse
{
    [SerializeField] PlayerInput playerInput;

    public void Punch()
    {
        if (playerInput.canReceiveInput)
        {
            playerInput.canReceiveInput = false;
            playerInput.inputReceived = true;
        }
        else return;
    }
}