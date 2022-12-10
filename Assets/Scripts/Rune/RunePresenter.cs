using UnityEngine;
using UnityEngine.UI;

public class RunePresenter : MonoBehaviour
{
    public Rune runeData;

    Image icon;

    public string name, description;

    public void RenderRune(Rune rune)
    {
        runeData = rune;

        icon.sprite = runeData.runeIcon;
        name = runeData.runeName;
        description = runeData.runeDescription;
    }
}