using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
                    var newSingleton = new GameObject("GameManager").AddComponent<DataController>();
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
    }

    public int highFloor;   //최고 층수
    public Status status;   //스테이터스
    public List<Weapon> Weapons;    //무기정보
    public List<Skill> Skills;      //스킬정보
    
}
