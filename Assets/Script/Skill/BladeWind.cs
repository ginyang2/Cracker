using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeWind : Skill
{
    public float damage;
    public GameObject attack;
    public override IEnumerator UseSkill(Player player, Vector3 target)
    {
        StartCoroutine(base.UseSkill(player));
        GameObject made = Instantiate(attack, GameObject.Find("Player").transform.position, Quaternion.identity);
        LongAttack longAttack = made.GetComponent<LongAttack>();
        longAttack.targetPos = target;
        longAttack.damage = (int)damage;
        longAttack.pass = true;
        yield return new WaitForEndOfFrame();
    }
}
