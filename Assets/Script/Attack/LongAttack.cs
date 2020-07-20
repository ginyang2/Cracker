using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//원거리 공격 프레펩 관리
public class LongAttack : Attack
{
    public float speed;
    public bool pass;
    public Vector2 targetPos;
    private void Update()
    {
        float dis = Vector2.Distance(transform.position, targetPos);
        if (dis >= 0.01f) // 차이가 아직 있다면
        {
            transform.localPosition = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
        else
            Destroy(gameObject);
    }
    override protected void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.CompareTag("Enemy"))
        {
            if (!pass)
                Destroy(gameObject);
        }
        if (collision.CompareTag("Wall"))
            Destroy(gameObject);
    }
}
