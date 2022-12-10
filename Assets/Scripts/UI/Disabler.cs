using UnityEngine;
using UnityEngine.Events;

public class Disabler : MonoBehaviour
{
    [SerializeField] UnityEvent OnDisabled;

    private void OnDisable() => OnDisabled.Invoke();
}