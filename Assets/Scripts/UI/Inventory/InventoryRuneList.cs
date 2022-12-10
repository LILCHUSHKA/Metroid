using UnityEngine;

public class InventoryRuneList : MonoBehaviour
{
    [SerializeField] RunePresenter runePresenter;
    [SerializeField] Transform runesBag;

    public void RenderRuneList(RuneList playerRuneList)
    {
        DestroyChild();

        playerRuneList.runes.ForEach(rune =>
        {
            Instantiate(runePresenter, runesBag);
            runePresenter.RenderRune(rune);
        });
    }


    public void DestroyChild()
    {
        foreach (Transform _child in runesBag) Destroy(_child.gameObject);
    }
}