using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Talker : MonoBehaviour
{
    [SerializeField] Text talkText;
    [HideInInspector] public List<string> talkArray;
    private int sentence = 0;

    public void Talk()
    {
        talkText.gameObject.SetActive(true);
        talkText.text = talkArray[sentence];

        StartCoroutine(NextTalkStep());
    }

    void EndTalk()
    {
        StopCoroutine(NextTalkStep());

        sentence = 0;
        talkText.gameObject.SetActive(false);
        GetComponent<FireflyMover>().enabled = true;
    }

    IEnumerator NextTalkStep()
    {
        sentence++;
        yield return new WaitForSeconds(2);

        talkText.text = talkArray[sentence];
        StartCoroutine(NextTalkStep());

        if (sentence == talkArray.Count) EndTalk();
    }
}