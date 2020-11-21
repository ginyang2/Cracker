using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    static List<Dictionary<string, object>> itemData = CSVReader.Read("ItemData");
    static List<Dictionary<string, object>> skillData = CSVReader.Read("SkillData");
    static List<Dictionary<string, object>> weaponData = CSVReader.Read("WeaponData");

    public static object Find(string id, string dataset, string findThing)  //경로 찾아주는 함수
    {
        List<Dictionary<string, object>> data;

        switch (dataset)
        {
            case "ItemData":
            case "Item":
                data = itemData;
                break;
            case "SkillData":
            case "Skill":
                data = skillData;
                break;
            case "WeaponData":
            case "Weapon":
                data = weaponData;
                break;
            default:
                Debug.Log("잘못된 데이터셋 이름입니다");
                return null;
        }

        foreach (Dictionary<string, object> entry in data)
        {
            if (entry["Id"].ToString() == id.ToString())
            {
                Debug.Log("Id : " + entry["Id"] + "  " + findThing + " : " + entry[findThing]);
                return entry[findThing];
            }
        }
        return null;
    }
}
