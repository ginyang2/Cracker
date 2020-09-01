using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//데이터 세이브, 로드, 관리를 맏는다.
public class DataController : MonoBehaviour
{
    
    private static DataController instance;
    public static DataController Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<DataController>();
                if (obj != null)

                {
                    instance = obj;
                }
                else
                {
                    var newSingleton = new GameObject("DataController").AddComponent<DataController>();
                    instance = newSingleton;
                }
            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SaveData();
    }

    private void Start()
    {
        SetWeapon();
    }

    public int highFloor;   //최고 층수
    public Status status;   //스테이터스
    public Skill[] setSkill = new Skill[4]; // 세팅된 스킬
    public string setWeaponName;
    public List<Weapon> Weapons;    //보유무기정보
    public List<Skill> Skills;      //보유스킬정보

    private void SaveData()
    {
        File.WriteAllText(Application.dataPath + "/Skills.json", JsonUtility.ToJson(Skills));
        File.WriteAllText(Application.dataPath + "/Weapons.json", JsonUtility.ToJson(Weapons));
        Debug.Log("저장 완료");
    }

    private void SetWeapon()
    {
        Weapon weapon = null;
        foreach (Weapon target in Weapons)
        {
            if (target.name == setWeaponName)
                weapon = target;
        }
        if(weapon == null)
        {
            Debug.LogError("옳바르지 않은 이름 혹은 없는 무기입니다.");
            return;
        }
        status.weapon = weapon;
    }
}
