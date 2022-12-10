using UnityEngine;

public class Ledge : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Hands>())
        {
            collision.GetComponent<Hands>().Grab(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Hands>())
        {
            collision.GetComponent<Hands>().Unhook();
        }
    }

}