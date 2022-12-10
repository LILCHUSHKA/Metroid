using UnityEngine;

[CreateAssetMenu(menuName = "Create new rune")]
public class Rune : ScriptableObject
{
    public string runeName, runeDescription;
    public Sprite runeIcon;
}