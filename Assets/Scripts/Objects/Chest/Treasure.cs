using UnityEngine;

public class Treasure : MonoBehaviour
{
    [HideInInspector] public Item itemData;

    [SerializeField] Rigidbody2D itemPhys;
    [HideInInspector] public Sprite icon;
    [SerializeField] Animator treasureAnimator;

    [SerializeField] TreasureWindow window;
    Canvas parent;

    int xForce, yForce;

    private void Start()
    {
        parent = GameObject.FindObjectOfType<Canvas>();
        RenderItem();
    }

    public void RenderItem()
    {
        GetComponent<SpriteRenderer>().sprite = icon;

        xForce = Random.Range(-4, 4);
        yForce = Random.Range(5, 10);

        itemPhys.AddForce(transform.right * xForce, ForceMode2D.Impulse);
        itemPhys.AddForce(transform.up * yForce, ForceMode2D.Impulse);
    }

    bool itemInInventory;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMover>())
        {
            for (int i = 0; i < collision.gameObject.GetComponent<Character>().inventory.Count; i++)
            {
                if (collision.gameObject.GetComponent<Character>().inventory[i].itemCode == itemData.itemCode)
                {
                    collision.gameObject.GetComponent<Character>().inventory[i].itemAmount++;
                    itemInInventory = true;
                }
            }

            if (!itemInInventory) collision.gameObject.GetComponent<Character>().inventory.Add(itemData);

            window.SpawnWindow(itemData.itemName, itemData.description, itemData.itemIcon);
            Instantiate(window, parent.transform);

            treasureAnimator.enabled = true;
        }
    }

    void DestroyTreasure() => Destroy(gameObject);
}