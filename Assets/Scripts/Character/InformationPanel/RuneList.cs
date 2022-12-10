using System.Collections.Generic;
using UnityEngine;

//Пересмотреть
public class RuneList : MonoBehaviour
{
    //Тут вообще непонятно что происходит
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