using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextAutoFiller : MonoBehaviour
{
    public Text textData;
    public string sentenceData;

    private void Awake() => textData = GetComponent<Text>();

    public void StartFilling(string sentence)
    {
        sentenceData = sentence;
        StartCoroutine(FillTimer());
    }

    public void ClearText()
    {
        textData.text = "";
        sentenceData = "";
    }

    IEnumerator FillTimer()
    {
        for (int nameSentenceIndex = 0; nameSentenceIndex < sentenceData.Length; nameSentenceIndex++)
        {
            yield return new WaitForSeconds(0.03f);
            textData.text += sentenceData[nameSentenceIndex];
        }
    }
}