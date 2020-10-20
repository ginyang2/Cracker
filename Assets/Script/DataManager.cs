using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    static List<Dictionary<string, object>> itemData = CSVReader.Read("ItemData");
    static List<Dictionary<string, object>> skillData = CSVReader.Read("ItemData");

    public static object FindPath(string id, string dataset)
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
            default:
                Debug.Log("잘못된 데이터셋 이름입니다");
                return null;
        }

        foreach (Dictionary<string, object> entry in data)
        {
            if (entry["id"].ToString() == id.ToString())
            {
                Debug.Log("id : " + entry["id"] + "  entry : " + entry["path"]);
                return entry["path"];
            }
        }
        return null;
    }
}
