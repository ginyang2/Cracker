using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    static List<Dictionary<string, object>> itemData = CSVReader.Read("ItemData");
    static List<Dictionary<string, object>> weaponData = CSVReader.Read("WeaponData");

    public static object FindData(string id,string dataSetName,string findDataset = "path")
    {
        List<Dictionary<string, object>> data;
        switch (dataSetName)
        {
            case "ItemData":
                data = itemData;
                break;
            case "WeaponData":
                data = weaponData;
                break;
            default:
                Debug.LogError("잘못된 데이터 셋 이름입니다.");
                return null;
        }
        foreach (Dictionary<string, object> entry in data)
        {
            if (entry["id"].ToString() == id.ToString())
            {
                return entry[findDataset];
            }
        }
        return null;
    }
}
