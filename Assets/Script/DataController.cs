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
public class DataController
{
    public static FloorData floorData;   //최고 층수
    public static List<Weapon> weapons;    //보유무기정보
    public static List<Skill> skills;      //보유스킬정보
    public static List<int> itemIdData;

    public static void SaveData()
    {
        File.WriteAllText(Application.dataPath + "/Skills.json", JsonUtility.ToJson(skills));
        File.WriteAllText(Application.dataPath + "/Weapons.json", JsonUtility.ToJson(weapons));
        File.WriteAllText(Application.dataPath + "/Floor.json", JsonUtility.ToJson(floorData));
        Debug.Log("저장 완료");
    }
    public static void Load()
    {
        File.WriteAllText(Application.dataPath + "/Skills.json", JsonUtility.ToJson(skills));
        File.WriteAllText(Application.dataPath + "/Weapons.json", JsonUtility.ToJson(weapons));
        Debug.Log("불러오기 완료");
    }
}
