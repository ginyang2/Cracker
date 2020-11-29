using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSetting : ObjectScene
{
    public GameObject weaponInventroy;
    public GameObject weaponInventoryPannel;
    public Image weaponImage;
    public Text weaponName;
    public Text weaponPower;
    protected override void Start()
    {
        base.Start();
        //무기 인벤토리
        inventoryMaker.basePannel = weaponInventoryPannel;
        usingDataset = "Weapon";
        inventoryMaker.Initialize("Weapon",this);
        Texture2D texture = Resources.Load(DataManager.Find(DataController.playerSetting.weaponId, usingDataset, "Path").ToString()) as Texture2D;
        Rect rect = new Rect(0, 0, texture.width, texture.height);
        weaponImage.sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
        weaponPower.text = "공격력 : " + DataManager.Find(DataController.playerSetting.weaponId, usingDataset, "Power").ToString();
        weaponName.text = DataManager.Find(DataController.playerSetting.weaponId, usingDataset, "Name").ToString();
        Close();
    }

    public void PickChangingItem(GameObject chosen) //아이템 클릭시 호출되는 함수
    {
        selectedItem = chosen;
        selectedItemImage = chosen.GetComponent<Image>();
        weaponInventroy.SetActive(true);
    }

    public override void Affect(string id)  //세팅한 스킬 선택시 호출
    {
        base.Affect(id);
        Close();
        DataController.playerSetting.weaponId = id;
        weaponPower.text = "공격력 : " + DataManager.Find(DataController.playerSetting.weaponId, usingDataset, "Power").ToString();
        weaponName.text = DataManager.Find(DataController.playerSetting.weaponId, usingDataset, "Name").ToString();
        DataController.SaveData();
    }

    public void Close()
    {
        weaponInventroy.SetActive(false);
    }
}
