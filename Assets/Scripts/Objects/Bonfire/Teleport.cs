using UnityEngine;

public class Teleport : MonoBehaviour
{
    public void TeleportToBonfire(Transform selectedBonfire)
    {
        transform.position = new Vector2(selectedBonfire.position.x - 2, selectedBonfire.position.y + 1);
    }
}