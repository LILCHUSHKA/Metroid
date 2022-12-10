using UnityEngine;

public class Dialog : MonoBehaviour
{
    public DialogData[] dialog;
}

[System.Serializable]
public class DialogData
{
    [Space(5)][Header("Название реплики")] public string sentenceName;

    public enum sentenceConditions
    {
        standart,
        heroHaveItem,
    }
    [Header("Тип условия появления предложения")] public sentenceConditions conditions;

    [TextArea(3,10)]
    [Header("Текст предложения")] public string sentenceText;
    [Header("Удалить реплику после ее высказывания")] public bool removeSentence;
    [Header("Активировать боевой режим у врага")] public bool activeFightMode;

    [Header("Код предмета")] public string itemCode;
}