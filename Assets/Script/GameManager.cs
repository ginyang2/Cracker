using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//인게임과 관련된 것들을 게임 씬에서 관할한다.
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<GameManager>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newSingleton = new GameObject("GameManager").AddComponent<GameManager>();
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
    public int score;//점수
    public bool gameOver;
    public List<Weapon> weapons;
    public int weaponIdx;
    //던전 관련 변수
    public int enemyNum;
    public MapEvent mapEvent;
    public bool inRoom = false;//방안인가?
    public int currentFloor;
    //UI 관련 변수
    public Text floorText;
    //스킬 관련 변수
    public List<Skill> skills;
    public List<Image> images;
    /*void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
        {
            Debug.Log(score);
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }*/

    private void Start()
    {
        DontDestroyOnLoad(this);
        Debug.Log("Manager Start");
        for (int i = 0; i < skills.Count; i++)
        {
            skills[i].ImageSetting(images[i]);
        }
        StartCoroutine(FloorApear());
    }
    private void Update()
    {
        if (gameOver)
            Invoke("GameOver",1f);
        if (inRoom)
            RoomCheck();
    }
    private void GameOver()
    {
        Time.timeScale = 0;
    }

    //던전 관련 함수
    private void RoomCheck()
    {
        if(enemyNum == 0)
        {
            mapEvent.OpenDoor();
        }
    }

    IEnumerator FloorApear()
    {
        //게임오브젝트 중복을 막기위한 임시 처리 나중에 선배에게 물어보고 고치기
        if (floorText != true)
        {
            Debug.Log("UnTouch Text");
            Destroy(this);
        }
        floorText.gameObject.SetActive(true);
        floorText.text = currentFloor + "층";
        yield return new WaitForSeconds(3f);
        floorText.gameObject.SetActive(false);
    }
}
