using UnityEngine;

//������ ��������� � ������������� ������ ������ ���������
public class DialogStarter : MonoBehaviour
{
    public DialogSystem sys;

    private void Update()
    {
        if (sys.GetComponent<Character>().characterType != Character.CharacterTypes.enemy && Input.GetKeyDown(KeyCode.E))
            sys.OpenDialogPanel();

        /*
        if (sys.GetComponent<Character>().characterType == Character.CharacterTypes.trader
            && sys.GetComponent<Dialog>().dialog.Length == 0
            && Input.GetKeyDown(KeyCode.E))
        {
            sys.OpenTradePanel();
        }
        */
    }
}