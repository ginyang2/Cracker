using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMDestroy : Skill
{
    Enemy[] enemys;
    public override IEnumerator UseSkill(Player player)
    {
        StartCoroutine(base.UseSkill(player));
        enemys = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemys)
        {
            enemy.MHP(999999);
        }
        yield return new WaitForEndOfFrame();
    }
}
