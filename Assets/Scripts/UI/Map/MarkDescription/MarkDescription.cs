using UnityEngine;
using UnityEngine.UI;

public class MarkDescription : MonoBehaviour
{
    [HideInInspector] public string markName, markDescription;

    [SerializeField] Text markNameText, markDescriptionText;

    public void RenderMarkInfo()
    {
        markNameText.text = markName;
        markDescriptionText.text = markDescription;
    }
}