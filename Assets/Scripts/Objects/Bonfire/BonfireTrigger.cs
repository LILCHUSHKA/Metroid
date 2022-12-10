using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BonfireTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent OnBonfireTriggerEnter, OnBonfireTriggerExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMover>()) OnBonfireTriggerEnter.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMover>()) OnBonfireTriggerExit.Invoke();
    }
}