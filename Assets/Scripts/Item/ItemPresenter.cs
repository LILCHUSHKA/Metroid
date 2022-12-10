using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemPresenter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image icon;

    string name, description;

    InformationPanelMoth infoMoth;

    private void Awake() => infoMoth = FindObjectOfType<InformationPanelMoth>();

    public void OnPointerEnter(PointerEventData eventData)
    {
        infoMoth.ShowItemInfo(name, description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        infoMoth.CloseItemInfo();
    }

    public void RenderItem(Item item, Transform targetCell)
    {
        icon.sprite = item.itemIcon;
        description = item.description;
        name = item.itemName;

        transform.position = targetCell.position;
    }
}