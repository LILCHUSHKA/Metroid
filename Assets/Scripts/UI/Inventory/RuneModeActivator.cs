using UnityEngine;

public class RuneModeActivator : MonoBehaviour
{
    bool runeModeIsActice = false;
    [SerializeField] GameObject runePanel;

    public void ChangeRuneMode(bool state) => runeModeIsActice = state;

    public void ActiveRuneMode()
    {
        if (runeModeIsActice) runePanel.SetActive(true);
        else runePanel.SetActive(false);
    }
}