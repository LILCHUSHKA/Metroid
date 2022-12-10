using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    [SerializeField] Image[] otherSigns;
    [SerializeField] Sprite disable, enable;

    public void SelectThisSign()
    {
        GetComponent<Image>().sprite = enable;

        foreach (Image signImage in otherSigns)
            signImage.sprite = disable;
    }
}