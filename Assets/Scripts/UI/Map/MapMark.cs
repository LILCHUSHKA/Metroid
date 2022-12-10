using UnityEngine;

public class MapMark : MonoBehaviour
{
    public string markName, markDescription;

    public enum markTypes
    {
        defaultMark,
        bonfire,
        hero
    }
    public markTypes markType;
}