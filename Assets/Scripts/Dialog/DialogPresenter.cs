using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//Ñêðèïò öåïëÿåòñÿ ê ñàìîé ðîäèòåëüñêîé ÏÀÍÅËÈ ÄÈÀËÎÃÀ
public class DialogPresenter : MonoBehaviour
{
    MainControler controler;

    public DialogData[] dialogs;
    public DialogSystem npc;

    public Text DialogPanelText, DialogPanelName;

    private void Awake() => controler = new MainControler();
    
    private void OnEnable()
    {
        controler.Enable();

        StartCoroutine(LineWriter());
        RemoveSentence(ref dialogs, dialogs.Length - 1); //ÊÀÑÒÛËÜ!!!

        controler.UI.PassSentence.performed += pass => FillSentence();
    }

    private void OnDisable()
    {
        controler.Disable();

        DialogPanelName.text = "";
        DialogPanelText.text = "";

        currentSentence = 0;
    }

    void FillSentence()
    {
        if (DialogPanelText.text != dialogs[currentSentence].sentenceText)
        {
            StopCoroutine(LineWriter());
            DialogPanelText.text = dialogs[currentSentence].sentenceText;
        }

        else NextDialogStep();
    }

    void RemoveSentence(ref DialogData[] dialogArray, int index)
    {
        DialogData[] newDialogArray = new DialogData[dialogArray.Length - 1];

        for (int i = 0; i < index; i++)
            newDialogArray[i] = dialogArray[i];

        for (int i = index + 1; i < dialogArray.Length; i++)
            newDialogArray[i - 1] = dialogArray[i];

        dialogArray = newDialogArray;
    }

    private void NextDialogStep()
    {
        if (dialogs[currentSentence].removeSentence == true)
        {
            RemoveSentence(ref dialogs, currentSentence);
            currentSentence--;
        }

        if (currentSentence == dialogs.Length - 1) CloseDialogPanel();
        else
        {
            currentSentence++;
            DialogPanelText.text = "";
            StartCoroutine("LineWriter");
        }

        if (dialogs[currentSentence + 1].activeFightMode == true)
        {
            CloseDialogPanel();
            npc.ActiveFightMode();
        }
    }

    void CloseDialogPanel() => gameObject.SetActive(false);

    string sentence;
    int currentSentence = 0;
    IEnumerator LineWriter()
    {
        sentence = "";
        sentence = dialogs[currentSentence].sentenceText;

        for (int i = 0; i < sentence.Length; i++)
        {
            yield return new WaitForSeconds(0.05f);
            DialogPanelText.text += sentence[i];
        }
    }
}