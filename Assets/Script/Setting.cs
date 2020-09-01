using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    //스테이터스
    public Text healthPoint;
    public Text manaPoint;
    public Text attackPower;
    public Text attackSpeed;
    public Text moveSpeed;
    Image weaponImage;
    Image weaponType;
    Image elimentalType;
    List<Image>weaponTypes;
    List<Image> elimentalTypes;
    Text weaponPower;

    private void Update()
    {
        
    }

    public void settingWeapon()
    {
        Weapon weapon = GameManager.Instance.weapon;
        weaponPower.text = "무기 공격력 : " + weapon.Power;

    }

    public void settingStatus()
    {
        healthPoint.text = DataController.Instance.status.healthPoint.ToString();
        manaPoint.text = DataController.Instance.status.manaPoint.ToString();
    }
}
