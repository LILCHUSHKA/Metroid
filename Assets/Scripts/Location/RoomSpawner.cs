using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] GameObject newRoom, lastRoom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMover>())
        {
            newRoom.SetActive(true);
            lastRoom.SetActive(false);
        }
    }
}