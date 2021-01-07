using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//시작화면
public class MainPage : MonoBehaviour
{
    public Text currentFloorText;
    private void Start()
    {
        DataController.Load();
    }
    private void Update()
    {
        currentFloorText.text = "최고 층수 : " + DataController.floorData.highFloor.ToString();
    }
}
