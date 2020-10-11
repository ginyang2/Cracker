using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    public int score = 0;//점수
    public bool gameOver;
    public Weapon weapon;
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
    //게임 오버 관련
    public GameObject gameOverPannel;
    public Text scoreText;
    public Text finalScoreText;
    private void Start()
    {
        //Debug.Log("Manager Start");
        for (int i = 0; i < skills.Count; i++)
        {
            skills[i].ImageSetting(images[i]);
        }
        gameOverPannel.SetActive(false);
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
        gameOverPannel.SetActive(true);
        scoreText.text = "답파계층 : " + score + "층";
        finalScoreText.text = "최종계층 : " + currentFloor + "층";
        if (currentFloor > DataController.floorData.highFloor)
            DataController.floorData.highFloor = currentFloor;
        DataController.SaveData();
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
        floorText.gameObject.SetActive(true);
        floorText.text = currentFloor + "층";
        yield return new WaitForSeconds(3f);
        floorText.gameObject.SetActive(false);
    }

    void LoadGamedData()
    {
         //DataController.Instance.status
    }

    public void MoveMain()
    {
        SceneManager.LoadScene("MainScene");
        Destroy(this.gameObject);
    }

    public void ChangeNextStage()
    {
        LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.RemoveAllMap();
        levelManager.MakeLevel();
        Player player = GameObject.FindObjectOfType<Player>();
        player.TP(new Vector3(0, 0));
        currentFloor++;
        score++;
        StartCoroutine(FloorApear());
    }
}
