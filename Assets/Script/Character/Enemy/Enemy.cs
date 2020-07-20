using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//적의 부모객체
abstract public class Enemy : Character
{
    [SerializeField]
    protected CanvasGroup healthGroup;
    protected virtual void Update()
    {
        if (hp.MyCurrentValue <= 0)
            Destroy(gameObject);
    }    

    protected IEnumerator HPApply()
    {
        healthGroup.alpha = 1;
        yield return new WaitForSeconds(5);
        healthGroup.alpha = 0;
    }

    public override void MHP(int damage)
    {
        base.MHP(damage);
        StartCoroutine(HPApply());
    }
}
