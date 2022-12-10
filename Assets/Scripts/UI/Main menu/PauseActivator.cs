using UnityEngine;

public class PauseActivator : MonoBehaviour
{
    MainControler controler;
    [SerializeField] GameObject mainMenu;

    private void Awake()
    {
        controler = new MainControler();
        controler.PlayerActions.Pause.performed += pause => Pause();
    }

    private void OnEnable() => controler.Enable();
    private void OnDisable() => controler.Disable();

    void Pause()
    {
        if (mainMenu.activeSelf == false) mainMenu.SetActive(true);
        else mainMenu.SetActive(false);
    }
}