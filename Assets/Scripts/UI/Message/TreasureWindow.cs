using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TreasureWindow : MonoBehaviour
{
    public Text nameText, descriptionText;
    public Image iconImage;

    private void OnEnable() => StartCoroutine(DestroyTimer());

    public void SpawnWindow(string name, string description, Sprite iconSprite)
    {
        nameText.text = name;
        descriptionText.text = description;
        iconImage.sprite = iconSprite;
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}