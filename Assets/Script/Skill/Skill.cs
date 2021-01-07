using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
abstract public class Skill:MonoBehaviour
{
    public bool targetting = false;
    public Image skillImage;
    public Sprite skillImageSetting;
    public float spendMana;
    public float coolTime;
    public bool cooldown = false;
    public int range;

    virtual public IEnumerator UseSkill(Player player)
    {
        skillImage.fillAmount = 0;
        player.MMP(spendMana);
        CoolDown();
        StartCoroutine(CoolTime(coolTime));
        yield return null;
    }
    virtual public IEnumerator UseSkill(Player player, Vector3 target)
    {
        skillImage.fillAmount = 0;
        player.MMP(spendMana);
        CoolDown();
        StartCoroutine(CoolTime(coolTime));
        yield return null;
    }

    public bool Check(Player player)
    {
        //쿨타임중인가?
        if (cooldown)
            return false;
        //사용 가능 조건 검사
        if (player.mp.MyCurrentValue < spendMana)
            return false;
        return true;
    }

    protected void Initialize(float setSpendMana,float setCoolTIme)
    {
        spendMana = setSpendMana;
        coolTime = setCoolTIme;
    }

    protected void CoolDown()
    {
        cooldown = true;
    }

    IEnumerator CoolTime(float cool)
    {
        cooldown = true;
        while (cool > 0f)
        {
            cool -= Time.deltaTime;
            skillImage.fillAmount = ((coolTime-cool) /coolTime);
            yield return new WaitForFixedUpdate();
        }
        cooldown = false;
    }

    public void ImageSetting(Image image)
    {
        skillImage = image; 
        skillImage.sprite = skillImageSetting;
    }
}
