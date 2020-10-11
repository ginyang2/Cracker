using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//데이터 세이브, 로드, 관리를 맏는다.

public class FloorData
{
    public int highFloor; //최고 층수
    public int currentFloor;
}

public class InventoryData{
    public string inventoryName;
    public int maxCount;
    public List<string> itemIds;
}

public class PlayerSkills
{
    public Skill skill1;
    public Skill skill2;
    public Skill skill3;
    public Skill skill4;
}

public class DataController
{
    public static FloorData floorData; //   //최고 층수
    public static List<Weapon> weapons;//    //보유무기정보
    public static List<Skill> skills; //      //보유스킬정보
    public static InventoryData itemInventory; //인벤토리 아이템

    public static void SaveData()
    {
        File.WriteAllText(Application.dataPath + "/Skills.json", JsonUtility.ToJson(skills));
        File.WriteAllText(Application.dataPath + "/Weapons.json", JsonUtility.ToJson(weapons));
        File.WriteAllText(Application.dataPath + "/Floor.json", JsonUtility.ToJson(floorData));
        File.WriteAllText(Application.dataPath + "/ItemInventory.json", JsonUtility.ToJson(itemInventory));
        Debug.Log("저장 완료");
    }
    public static void Load()
    {
        string temp = File.ReadAllText(Application.dataPath + "/ItemInventory.json");
        itemInventory = JsonUtility.FromJson<InventoryData>(temp.ToString());
        temp = File.ReadAllText(Application.dataPath + "/Floor.json");
        floorData = JsonUtility.FromJson<FloorData>(temp.ToString());
        Debug.Log("불러오기 완료");
    }
}
