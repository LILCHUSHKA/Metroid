using UnityEngine;
using System.Collections.Generic;

public class InventoryNew : MonoBehaviour
{
    [SerializeField] List<Transform> inventoryCells;

    [SerializeField] ItemPresenter itemPresenter;

    public void RenderItems(Character character)
    {
        DestroyChild(inventoryCells);

        for (int i = 0; i < character.inventory.Count; i++)
        {
            var item = Instantiate(itemPresenter, inventoryCells[i].transform);
            item.RenderItem(character.inventory[i], inventoryCells[i].transform);
        }
    }

    public void DestroyChild(List<Transform> parentCells)
    {
        foreach (Transform child in parentCells)
        {
            foreach (Transform cellChild in child) Destroy(cellChild.gameObject);
        }
    }
}