using UnityEngine;

public class Dialog : MonoBehaviour
{
    public DialogData[] dialog;
}

[System.Serializable]
public class DialogData
{
    [Space(5)][Header("�������� �������")] public string sentenceName;

    public enum sentenceConditions
    {
        standart,
        heroHaveItem,
    }
    [Header("��� ������� ��������� �����������")] public sentenceConditions conditions;

    [TextArea(3,10)]
    [Header("����� �����������")] public string sentenceText;
    [Header("������� ������� ����� �� ������������")] public bool removeSentence;
    [Header("������������ ������ ����� � �����")] public bool activeFightMode;

    [Header("��� ��������")] public string itemCode;
}