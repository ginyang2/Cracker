using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//플레이어
public class Player : Character
{
    //이동관련
    public Vector2 targetPos;
    private Camera mainCamera;
    //벽 접촉여부 확인
    public bool isTouchRight;
    public bool isTouchLeft;
    public bool isTouchUp;
    public bool isTouchDown;
    //애니메이션
    public Animator animator;
    //공격관련
    public GameObject attackPrefab;
    public Transform attackTarget;
    public bool isAttack;
    public GameObject attackRangeCirecle;
    //UI관련
    public Stat mp;
    protected override void Start()
    {
        Debug.Log("Start");
        base.Start();
        status.weapon = GameManager.Instance.weapon;
        attackRangeCirecle.SetActive(false);
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        status.attackPower = status.weapon.Power;
        //HP,MPUI 초기화
        mp.Initialize(status.manaPoint, status.manaPoint);
        Time.timeScale = 1;
    }
    void Update()
    {
        if (hp.MyCurrentValue <= 0)
        {
            GameManager.Instance.gameOver = true;
            animator.SetTrigger("Dead");
        }
        else
        {
            InputKey();
            Move(); 
        }
    }

    void InputKey()
    {
        //이동
        if (Input.GetMouseButtonDown(1))
        {
            targetPos = Input.mousePosition;
            targetPos = mainCamera.ScreenToWorldPoint(targetPos);
        }
        //공격
        if (Input.GetKey(KeyCode.A))
        {
            AttackReady(new Vector3(status.weapon.range, status.weapon.range));
            if (Input.GetMouseButtonDown(0) && !isAttack) {
                if (status.weapon.AttackType == 0)
                    StartCoroutine(Attack(mainCamera.ScreenToWorldPoint(Input.mousePosition)));
                else
                {
                    if (Vector2.Distance(transform.position, mainCamera.ScreenToWorldPoint(Input.mousePosition)) < status.weapon.range)
                    {   //공격 범위 안이라면
                        StartCoroutine(Attack(mainCamera.ScreenToWorldPoint(Input.mousePosition)));
                    }
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
            attackRangeCirecle.SetActive(false);
        //스킬 사용
        UseSkill(KeyCode.Q, 0);
        UseSkill(KeyCode.W, 1);
        UseSkill(KeyCode.E, 2);
        UseSkill(KeyCode.R, 3);
    }

    void UseSkill(KeyCode key, int skillIndex)
    {
        Skill skill = GameManager.Instance.skills[skillIndex];
        if (Input.GetKey(key) && skill.targetting)
        {
            AttackReady(new Vector3(skill.range, skill.range));
            if (Input.GetMouseButtonDown(0) && skill.Check(this))
            {
                if (Vector2.Distance(transform.position, mainCamera.ScreenToWorldPoint(Input.mousePosition)) < skill.range)
                {
                    StartCoroutine(skill.UseSkill(this, mainCamera.ScreenToWorldPoint(Input.mousePosition)));
                }
            }
        }
        else if (Input.GetKeyDown(key) && skill.Check(this))
            StartCoroutine(skill.UseSkill(this));
        if (Input.GetKeyUp(key))
            attackRangeCirecle.SetActive(false);
    }

    void Move()
    {
        float dis = Vector2.Distance(transform.position, targetPos);
        //벽과의 충돌 판정
        Vector2 currentTPos = targetPos;
        if (isTouchLeft && targetPos.x < transform.position.x)
            currentTPos.x = transform.position.x;
        if (isTouchRight && targetPos.x > transform.position.x)
            currentTPos.x = transform.position.x;
        if (isTouchDown && targetPos.y < transform.position.y)
            currentTPos.y = transform.position.y;
        if (isTouchUp && targetPos.y > transform.position.y)
            currentTPos.y = transform.position.y;

        if (dis >= 0.01f) // 차이가 아직 있다면
        {
            transform.localPosition = Vector2.MoveTowards(transform.position, currentTPos, status.moveSpeed * Time.deltaTime);
        }
    }

    void AttackReady(Vector3 size)
    {
        attackRangeCirecle.SetActive(true);
        attackRangeCirecle.transform.localScale = size;
    }

    IEnumerator Attack(Vector2 targetPos)
    {
        isAttack = true;
        float angle = Mathf.Atan2(targetPos.y - transform.position.y, targetPos.x - transform.position.x) * Mathf.Rad2Deg;
        GameObject attackPrefab = Instantiate(status.weapon.attackPrefab, transform.position, Quaternion.identity);
        if (status.weapon.AttackType == 0)
        {
            angle -= 45;
            attackPrefab.transform.localScale = new Vector3(status.weapon.range, status.weapon.range);
        }
        else if (status.weapon.AttackType == 1)
        {
            LongAttack longAttack = attackPrefab.GetComponent<LongAttack>();
            longAttack.targetPos = targetPos;
        }
        attackPrefab.GetComponent<Attack>().damage = (int)status.attackPower;
        attackPrefab.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        yield return new WaitForSeconds(status.attackSpeed);
        isAttack = false;
    }
    public void MMP(float spend)
    {
        mp.MyCurrentValue -= spend;
    }

    public void TP(Vector3 position)
    {
        transform.position = position;
        targetPos = transform.position;
    }

    void InitialzeStatus()
    {
        //status = GameManager.Instance.status;
    }
}
