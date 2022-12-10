using UnityEngine;
using UnityEngine.UI;

public class DeathPanel : MonoBehaviour
{
    [SerializeField] AnimationCurve blackOut;

    Image panel;
    Text label;

    float currentTime;

    private void Start()
    {
        if (gameObject.GetComponent<Image>()) panel = gameObject.GetComponent<Image>();

        if (gameObject.GetComponent<Text>()) label = gameObject.GetComponent<Text>();
    }

    private void FixedUpdate() => BlackOut();

    private void OnDisable() => currentTime = 0;

    private void BlackOut()
    {
        currentTime += Time.deltaTime;

        if (gameObject.GetComponent<Image>())
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, blackOut.Evaluate(currentTime));

        if (gameObject.GetComponent<Text>()) 
            label.color = new Color(label.color.r, label.color.g, label.color.b, blackOut.Evaluate(currentTime));
    }
}