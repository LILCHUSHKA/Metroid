using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

class RuneHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] UnityEvent handleEvent;

    [SerializeField] RuneDescription runeDescription;
    RunePresenter runePresenter;

    Canvas parent;

    private void Awake()
    {
        parent = GameObject.FindObjectOfType<Canvas>();
        runePresenter = GetComponent<RunePresenter>();
    }

    GameObject descriptionObject;
    public void OnPointerEnter(PointerEventData eventData)
    {
        handleEvent.Invoke();

        transform.position = new Vector2(transform.position.x, transform.position.y + 20);

        runeDescription.nameText.text = runePresenter.name;
        runeDescription.descriptionText.text = runePresenter.description;
        descriptionObject = Instantiate(runeDescription.gameObject, parent.transform);
    }

    public void OnPointerExit(PointerEventData g)
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 20);
        Destroy(descriptionObject);
    }
}