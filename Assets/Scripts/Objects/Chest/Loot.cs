using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] Treasure treasurePresenter;

    public void SpawnItem(List<Item> treasureList)
    {
        for (int i = 0; i < treasureList.Count; i++)
        {
            treasurePresenter.icon = treasureList[i].itemIcon;
            treasurePresenter.itemData = treasureList[i];
            
            Instantiate(treasurePresenter, transform);
        }
    }
}