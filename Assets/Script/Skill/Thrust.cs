using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrust : Skill
{
    public float damage;
    public GameObject attack;
    public override IEnumerator UseSkill(Player player, Vector3 target)
    {
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        StartCoroutine(base.UseSkill(player));
        
        float angle = Mathf.Atan2(target.y - playerPos.y, target.x - playerPos.x) * Mathf.Rad2Deg;
        angle -= 45;
        GameObject made = Instantiate(attack, playerPos, Quaternion.identity);
        made.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        ShortAttack longAttack = made.GetComponent<ShortAttack>();
        longAttack.damage = (int)damage;
        yield return new WaitForEndOfFrame();
    }
}
