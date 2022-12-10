using UnityEngine;
using System.Collections.Generic;

public class Chest : MonoBehaviour
{
    [HideInInspector] bool isOpen = false;

    Loot loot;
    [SerializeField] List<Item> treasure;

    Animator chestAnimator;
    Collider2D chestCollider;

    private void Awake()
    {
        chestAnimator = GetComponent<Animator>();
        chestCollider = GetComponent<Collider2D>();
        loot = GetComponent<Loot>();
    }

    public void OpenChest()
    {
        if (isOpen == false)
        {
            chestAnimator.enabled = true;
            chestCollider.enabled = false;

            loot.SpawnItem(treasure);
        }

        isOpen = true;
    }
}