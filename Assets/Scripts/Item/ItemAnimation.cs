using UnityEngine;
using UnityEngine.UI;

public class ItemAnimation : MonoBehaviour
{
    [HideInInspector] public Image cellImage;
    [SerializeField] AnimationCurve itemAnim;

    float currentTime;

    private void Awake() =>
        cellImage = GetComponent<Image>();

    private void Update() =>
        ChangeAlfa();

    void ChangeAlfa()
    {
        currentTime += Time.deltaTime;
        cellImage.color = new Color(cellImage.color.r, cellImage.color.g, cellImage.color.b, itemAnim.Evaluate(currentTime));
    }
}