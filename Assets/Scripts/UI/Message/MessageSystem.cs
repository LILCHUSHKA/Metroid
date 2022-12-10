using UnityEngine;
using UnityEngine.UI;

public class MessageSystem : MonoBehaviour
{
    [SerializeField] Text messageText;
    [SerializeField] Transform parent;

    public void CreateMessage(string message)
    {
        messageText.text = message;
        Instantiate(messageText, parent);
    }
}