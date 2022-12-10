using UnityEngine;
using UnityEngine.Events;

public class Enabler : MonoBehaviour
{
    [SerializeField] UnityEvent OnEnabled;

    private void OnEnable() => OnEnabled.Invoke();
}