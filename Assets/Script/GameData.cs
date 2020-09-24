using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    static List<Dictionary<string, object>> itemData = CSVReader.Read("ItemData");
    static List<Dictionary<string, object>> weaponData = CSVReader.Read("WeaponData");

    public static object FindData(int id,string dataSetName)
    {
        List<Dictionary<string, object>> data;
        if (dataSetName == "itemData")
            data = itemData;
        else if (dataSetName == "weaponData")
            data = weaponData;
        else
        {
            Debug.LogError("잘못된 데이터 셋 이름입니다.");
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
