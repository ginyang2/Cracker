using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Skill
{
    public float healPower;
    public GameObject healAffect;
    Animator animator;
    public override IEnumerator UseSkill(Player player)
    {
        StartCoroutine(base.UseSkill(player));
        player.MHP((int)(-1*(healPower)));
        GameObject healObject = Instantiate(healAffect, GameObject.FindObjectOfType<Player>().transform.position, Quaternion.identity);

        healObject.transform.SetParent(GameObject.FindObjectOfType<Player>().transform);
        animator = healObject.GetComponent<Animator>();
        while (false == animator.IsInTransition(0))
        {
            yield return new WaitForEndOfFrame();
        }
        GameObject.Destroy(animator.gameObject);
        yield return new WaitForEndOfFrame();
    }
}
