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
    Wand,
    Dagger
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
public class Weapon
{
    public Weapon(string name, int power, WeaponType weaponType, float range, GameObject attackPrefab)
    {
        this.name = name;
        this.power = power;
        this.weaponType = weaponType;
        this.attackType = weaponType == WeaponType.Bow ? AttackType.Long : AttackType.Short;
        this.range = range;
        this.attackPrefab = attackPrefab;
    }
    readonly public string name;
    readonly public int power;
    readonly public AttackType attackType;
    readonly public WeaponType weaponType;
    readonly public ElementType elementType;
    readonly public GameObject attackPrefab;
    readonly public float range;
    public Sprite image;
    public Rune rune;
}
