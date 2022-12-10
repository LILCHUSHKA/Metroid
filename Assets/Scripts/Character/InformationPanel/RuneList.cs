using System.Collections.Generic;
using UnityEngine;

//������������
public class RuneList : MonoBehaviour
{
    //��� ������ ��������� ��� ����������
    public List<Rune> runes;
    [SerializeField] RuneTreasurePresenter runeTreasurePresenter;

    private void Start()
    {
        DropRunes();
    }

    public void DropRunes()
    {
        for (int i = 0; i < runes.Count; i++)
        {
            runeTreasurePresenter.runeData = runes[i];
            Instantiate(runeTreasurePresenter, transform);
        }
    }
}