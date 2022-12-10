using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class NewButton : Selectable, IPointerClickHandler, ISubmitHandler
{
    [SerializeField] ButtonParticleSystem buttonParticleSystem;

    [Serializable] public class ButtonClickedEvent : UnityEvent { }

    [UnityEngine.Serialization.FormerlySerializedAs("onClick")]
    [SerializeField] private ButtonClickedEvent m_OnClick = new ButtonClickedEvent();

    public ButtonClickedEvent OnClick
    {
        get { return m_OnClick; }
        set { m_OnClick = value; }
    }

    public override void OnSelect(BaseEventData eventData)
    {
        buttonParticleSystem.buttonParticles.SetActive(true);
        base.OnSelect(eventData);
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);
        buttonParticleSystem.buttonParticles.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;

        if (!IsActive() || !IsInteractable())
            return;

        UISystemProfilerApi.AddMarker("Button.onClick", this);
        m_OnClick.Invoke();
    }

    public virtual void OnSubmit(BaseEventData eventData)
    {
        if (!IsActive() || !IsInteractable())
            return;

        DoStateTransition(SelectionState.Pressed, false);

        UISystemProfilerApi.AddMarker("Button.onClick", this);
        m_OnClick.Invoke();
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        OnSelect(eventData);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        OnDeselect(eventData);
    }
}

[Serializable]
public class ButtonParticleSystem
{
    public GameObject buttonParticles;
}