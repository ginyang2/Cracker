using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingScene : ObjectScene
{
    public GameObject invetory;
    public GameObject inventoryPannel;
    public Image[] skillsButton = new Image[4];
    protected override void Start()
    {
        base.Start();
        usingDataset = "Skill";
        inventoryMaker.Initialize("Skill");
        Close();
        for (int i = 0; i < 4; i++)
        {
            Texture2D texture = Resources.Load(DataManager.Find(DataController.playerSetting.skillsId[i], usingDataset, "path").ToString()) as Texture2D;
            Rect rect = new Rect(0, 0, texture.width, texture.height);
            skillsButton[i].sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
        }
    }

    public void PickChangingItem(GameObject chosen) //아이템 클릭시 호출되는 함수
    {
        selectedItem = chosen;
        selectedItemImage = chosen.GetComponent<Image>();
        invetory.SetActive(true);
    }

    public override void Affect(string id)  //세팅한 스킬 선택시 호출
    {
        base.Affect(id);
        Close();
        DataController.playerSetting.skillsId[int.Parse(selectedItem.name) - 1] = id;
        DataController.SaveData();
    }

    public void Close()
    {
        invetory.SetActive(false);
    }
}
