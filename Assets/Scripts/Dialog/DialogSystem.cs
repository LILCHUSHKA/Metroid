using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//Разделить это на 2 класса
//Скрипт цепляется к персонажу с которым можно будет поговорить
public class DialogSystem : MonoBehaviour
{
    [SerializeField] UnityEvent OnTrigger, OnActiveEnemyMode;

    [SerializeField] GameObject dialogPanel, tradePanel;
    [SerializeField] Text triggerText, nameText;

    DialogData[] emptyArray = new DialogData[1];

    DialogData[] standartDialog = new DialogData[1];
    DialogData[] dialogAboutItem = new DialogData[1];

    Dialog dialog;

    private void Awake() => dialog = GetComponent<Dialog>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMover>())
        {
            if (dialog.dialog.Length > 0)
            {
                nameText.text = GetComponent<Character>().name;
                dialogPanel.GetComponent<DialogPresenter>().npc = GetComponent<DialogSystem>();

                HandOverDialog(collision);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMover>()) standartDialog = emptyArray;
    }

    void RewriteArray(ref DialogData[] array, ref DialogData[] whatArrayRewrite) => array = whatArrayRewrite;

    void AddNewElement(ref DialogData[] array, DialogData value, int index)
    {
        DialogData[] newDialogArray = new DialogData[array.Length + 1];
        newDialogArray[index] = value;

        for (int i = 0; i < index; i++)
            newDialogArray[i] = array[i];

        for (int i = index; i < array.Length; i++)
            newDialogArray[i + 1] = array[i];

        array = newDialogArray;
    }

    void HandOverDialog(Collider2D col)
    {
        for (int i = 0; i < GetComponent<Dialog>().dialog.Length; i++)
        {
            if (GetComponent<Dialog>().dialog[i].conditions == DialogData.sentenceConditions.standart)
            {
                AddNewElement(ref standartDialog, GetComponent<Dialog>().dialog[i], standartDialog.Length - 1);
                RewriteArray(ref dialogPanel.GetComponent<DialogPresenter>().dialogs, ref standartDialog);
            }

            for (int j = 0; j < col.GetComponent<Character>().inventory.Count; j++)
            {
                if (GetComponent<Dialog>().dialog[i].itemCode == col.GetComponent<Character>().inventory[j].itemCode)
                {
                    if (GetComponent<Dialog>().dialog[i].conditions == DialogData.sentenceConditions.heroHaveItem)
                    {
                        AddNewElement(ref dialogAboutItem, GetComponent<Dialog>().dialog[i], dialogAboutItem.Length - 1);
                        RewriteArray(ref dialogPanel.GetComponent<DialogPresenter>().dialogs, ref dialogAboutItem);
                    }
                }
            }
        }
    }

    public void ActiveFightMode()
    {
        OnActiveEnemyMode.Invoke();
        gameObject.AddComponent(typeof(Rigidbody2D));
    }

    public void OpenDialogPanel()
    {
        if (dialogPanel.GetComponent<DialogPresenter>().dialogs.Length > 0)
        {
            dialogPanel.GetComponent<DialogPresenter>().DialogPanelName.text = GetComponent<Character>().name;
            dialogPanel.SetActive(true);
        }
    }
}