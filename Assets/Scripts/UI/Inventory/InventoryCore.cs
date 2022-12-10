using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryCore : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] TextAutoFiller nameText, descriptionText;

    [SerializeField] string name, description;

    public void OnPointerEnter(PointerEventData eventData)
    {
        nameText.StartFilling(name);
        descriptionText.StartFilling(description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        nameText.ClearText();
        descriptionText.ClearText();
    }
}