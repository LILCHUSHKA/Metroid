using UnityEngine;

public class InformationPanelMoth : MonoBehaviour
{
    [SerializeField] TextAutoFiller nameTextFiller, descriptionTextFiller;

    public void ShowItemInfo(string nameSentence, string descriptionSentence)
    {
        nameTextFiller.StartFilling(nameSentence);
        descriptionTextFiller.StartFilling(descriptionSentence);
    }

    public void CloseItemInfo()
    {
        nameTextFiller.ClearText();
        descriptionTextFiller.ClearText();
    }
}