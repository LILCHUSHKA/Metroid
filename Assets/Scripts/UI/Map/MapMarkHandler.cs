using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class MapMarkHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    MapMark mark;

    [SerializeField] UnityEvent OnMarkHover;
    [SerializeField] MarkDescription descriptionPanel;

    [SerializeField] Transform descriptionParent;

    private void Awake() => mark = GetComponent<MapMark>();

    public void OnPointerEnter(PointerEventData g)
    {
        OnMarkHover.Invoke();

        if (g.pointerEnter.GetComponent<MapMark>().markType != MapMark.markTypes.hero)
        {
            Instantiate(descriptionPanel, descriptionParent);
            descriptionPanel.markName = mark.markName;
            descriptionPanel.markDescription = mark.markDescription;
        }

        transform.localScale *= 1.1f;
    }

    public void OnPointerExit(PointerEventData g)
    {
        transform.localScale /= 1.1f;
        foreach (RectTransform child in descriptionParent) Destroy(child.gameObject);
    }
}