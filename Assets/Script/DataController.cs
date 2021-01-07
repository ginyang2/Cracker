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

public class PlayerSetting
{
    public string[] skillsId = new string[4];
    public string weaponId;
}

public class DataController
{
    public static FloorData floorData; //   //최고 층수
    public static List<Weapon> weapons;//    //보유무기정보
    public static List<Skill> skills; //      //보유스킬정보
    public static InventoryData itemInventory; //아이템 인벤토리 
    public static InventoryData skillInventory; //스킬 인벤토리 
    public static InventoryData weaponInventory; //무기 인벤토리
    public static PlayerSetting playerSetting;
    public static void SaveData()
    {
        //JsonUtility.ToJson(Resources.)
        //File.WriteAllText(Application.dataPath + "/Skills.json", JsonUtility.ToJson(skills));
        //File.WriteAllText(Application.dataPath + "/Weapons.json", JsonUtility.ToJson(weapons));
        //File.WriteAllText(Application.dataPath + "/Floor.json", JsonUtility.ToJson(floorData));
        //File.WriteAllText(Application.dataPath + "/ItemInventory.json", JsonUtility.ToJson(itemInventory));
        //File.WriteAllText(Application.dataPath + "/SkillInventory.json", JsonUtility.ToJson(skillInventory));
        //File.WriteAllText(Application.dataPath + "/WeaponInventory.json", JsonUtility.ToJson(weaponInventory));
        //File.WriteAllText(Application.dataPath + "/PlayerSetting.json", JsonUtility.ToJson(playerSetting));
        Debug.Log("저장 완료");
    }
    public static void Load()
    {
        TextAsset temp = Resources.Load("ItemInventory") as TextAsset;
        itemInventory = JsonUtility.FromJson<InventoryData>(temp.ToString());

        temp = Resources.Load("Floor") as TextAsset;
        floorData = JsonUtility.FromJson<FloorData>(temp.ToString());

        temp = Resources.Load("SkillInventory") as TextAsset;
        itemInventory = JsonUtility.FromJson<InventoryData>(temp.ToString());

        temp = Resources.Load("WeaponInventory") as TextAsset;
        weaponInventory = JsonUtility.FromJson<InventoryData>(temp.ToString());

        temp = Resources.Load("PlayerSetting") as TextAsset;
        playerSetting = JsonUtility.FromJson<PlayerSetting>(temp.ToString());
        //Debug.Log("불러오기 완료");
    }

    public static InventoryData FindInvetory(string InventoryName)
    {
        switch (InventoryName)
        {
            case "ItemInventory":
            case "Item":
                return itemInventory;
            case "SkillInventory":
            case "Skill":
                return skillInventory;
            case "WeaponInventory":
            case "Weapon":
                return weaponInventory;
            default:
                Debug.Log("잘못된 인벤토리 이름입니다");
                return null;
        }
    }
}
