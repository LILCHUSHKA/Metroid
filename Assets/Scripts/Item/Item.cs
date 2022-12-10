using UnityEngine;

[CreateAssetMenu(menuName = "Create new item")]
public class Item : ScriptableObject
{
    public Sprite itemIcon;

    public string itemName, itemCode;
    public int itemAmount = 1;

    public string description;
}