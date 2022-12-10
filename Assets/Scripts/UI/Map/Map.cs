using UnityEngine;
using UnityEngine.Events;

public class Map : MonoBehaviour
{
    [SerializeField] UnityEvent TeleportModeOn;

    [SerializeField] Transform mapCamera;

    bool teleportMode = false;

    public void ActiveTeleportMode()
    {
        if (teleportMode) TeleportModeOn.Invoke();
    }

    public void ChangeMode(bool state) => teleportMode = state;

    public void TeleportCamera(Transform player) =>
        mapCamera.position = new Vector3(player.position.x, player.position.y, -1);
}