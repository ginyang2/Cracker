using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//무기의 능력치를 다룬다
[System.Serializable]
public class Weapon
{
    public string name;
    private int power;
    public int Power
    {
        get
        {
            return power;
        }
    }
    [SerializeField]
    private string attackType;
    public int AttackType
    {
        get
        {
            switch (attackType)
            {
                case "Short":
                    return 0;
                case "Long":
                    return 1;
                default:
                    return -1;
            }
        }
        set
        {
            switch (weaponType)
            {
                case "Sword":
                case "Sphere":
                    attackType = "Short";
                    break;
                case "Bow":
                case "wand":
                    attackType = "Long";
                    break;
            }
        }
    }
    [SerializeField]
    private string weaponType;
    public int WeaponType
    {
        get
        {
            switch (weaponType)
            {
                case "Sword":
                    return 0;
                case "Bow":
                    return 1;
                case "wand":
                    return 2;
                case "Sphere":
                    return 3;
                default:
                    return -1;
            }
        }
        set {
            switch (value)
            {
                case 0:
                    weaponType = "Sword";
                    break;
                case 1:
                    weaponType = "Bow";
                    break;
                case 2:
                    weaponType = "wand";
                    break;
                case 3:
                    weaponType = "Sphere";
                    break;
            }
        }
    }

    [SerializeField]
    private string elementType;
    public int ElementType
    {
        get
        {
            switch (elementType)
            {
                case "None":
                    return 0;
                case "Fire":
                    return 1;
                case "Water":
                    return 2;
                case "Wind":
                    return 3;
                case "Earth":
                    return 4;
                default:
                    return -1;
            }
        }
        set
        {
            switch (value)
            {
                case 0:
                    elementType = "None";
                    break;
                case 1:
                    elementType = "Fire";
                    break;
                case 2:
                    elementType = "Wind";
                    break;
                case 3:
                    elementType = "Earth";
                    break;
            }
        }
    }

    public GameObject attackPrefab;

    public float range;
    public Sprite image;
}
