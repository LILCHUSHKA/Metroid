using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class BonfireMark : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] UnityEvent OnClickBonfire;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickBonfire.Invoke();
    }
}