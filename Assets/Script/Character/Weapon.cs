using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AttackType
{
    Short,
    Long
}

public enum WeaponType
{
    Sword,
    Lance,
    Bow,
    Wand
}

public enum ElementType
{
    None,
    Fire,
    Water,
    Wind,
    Earth
}
//무기의 능력치를 다룬다
[System.Serializable]
public struct Weapon
{   
    readonly public string name;
    readonly public int power;
    readonly public AttackType attackType;
    readonly public WeaponType weaponType;
    readonly public ElementType elementType;
    readonly public GameObject attackPrefab;
    readonly public float range;
    readonly public Sprite image;
    public Rune rune;
}
