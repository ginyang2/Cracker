using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Character : MonoBehaviour
{
    public Status status;
    public Stat hp;

    protected virtual void Start()
    {
        hp.Initialize(status.healthPoint, status.healthPoint);  //HP UI 초기화
    }
    //HP감수 함수
    public virtual void MHP(int damage)
    {
        //Debug.Log("-" + damage);
        hp.MyCurrentValue -= damage;
        StartCoroutine(Hit());
    }
    protected IEnumerator Hit()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetBool("Hit", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Hit", false);
        yield return new WaitForEndOfFrame();
    }
}
