using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataManager
{
    static List<Dictionary<string, object>> data = CSVReader.Read("ItemData");

    public static object FindPath(string id)
    {
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
