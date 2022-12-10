using UnityEngine;

public class GetPoint : MonoBehaviour
{
    public Transform point;
    [HideInInspector] public Vector2 pointPosition;

    private void Start() => pointPosition = point.transform.position;
}