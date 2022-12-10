using UnityEngine;

public class RuneTreasurePresenter : MonoBehaviour
{
    [HideInInspector] public Rune runeData;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = runeData.runeIcon;
    }
}