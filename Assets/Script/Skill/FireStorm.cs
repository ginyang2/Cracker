using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStorm : Skill
{

    public float damage;
    public GameObject attack;
    public override IEnumerator UseSkill(Player player, Vector3 targetPos)
    {
        Debug.Log("useskill");
        StartCoroutine(base.UseSkill(player));
        GameObject made = Instantiate(attack, GameObject.Find("Player").transform.position, Quaternion.identity);
        float angle = Mathf.Atan2(targetPos.y - made.transform.position.y, targetPos.x - made.transform.position.x) * Mathf.Rad2Deg;
        angle -= 180;
        ShortAttack shortAttack = made.GetComponentInChildren<ShortAttack>();
        made.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        shortAttack.damage = (int)damage;
        yield return new WaitForEndOfFrame();
    }
}
