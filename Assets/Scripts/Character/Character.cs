using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHealth, health, heroDensity = 0;

    public int damageValue;

    public int physicResist, magicResist;

    public string name;

    public enum CharacterTypes
    {
        hero,
        enemy,
        NPC
    }
    public CharacterTypes characterType;

    public List<Item> inventory;
}