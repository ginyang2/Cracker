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
        status.attackPower = status.weapon.power;
        //HP,MPUI 초기화
        mp.Initialize(status.manaPoint, status.manaPoint);
        Time.timeScale = 1;
    }
    void Update()
    {
        //hp가 0 이하면 사망처리
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
    //키입력 관리 함수
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
                if (status.weapon.attackType == AttackType.Short)
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
    //스킬사용 함수
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
    //이동 함수
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
    //공격, 스킬 키입력 후 대기시 호출
    void AttackReady(Vector3 size)
    {
        attackRangeCirecle.SetActive(true);
        attackRangeCirecle.transform.localScale = size;
    }
    //공격 코루틴
    IEnumerator Attack(Vector2 targetPos)
    {
        isAttack = true;
        float angle = Mathf.Atan2(targetPos.y - transform.position.y, targetPos.x - transform.position.x) * Mathf.Rad2Deg;
        GameObject attackPrefab = Instantiate(status.weapon.attackPrefab, transform.position, Quaternion.identity);
        if (status.weapon.attackType == AttackType.Short)
        {
            angle -= 45;
            attackPrefab.transform.localScale = new Vector3(status.weapon.range, status.weapon.range);
        }
        else if (status.weapon.attackType == AttackType.Long)
        {
            LongAttack longAttack = attackPrefab.GetComponent<LongAttack>();
            longAttack.targetPos = targetPos;
        }
        attackPrefab.GetComponent<Attack>().damage = (int)status.attackPower;
        attackPrefab.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        yield return new WaitForSeconds(status.attackSpeed);
        isAttack = false;
    }
    //MP감소
    public void MMP(float spend)
    {
        mp.MyCurrentValue -= spend;
    }
    //좌표 직접적으로 변경 함수
    public void TP(Vector3 position)
    {
        transform.position = position;
        targetPos = transform.position;
    }
    //능력치 동기화 함수
    private void InitialzeStatus()
    {
        //status = GameManager.Instance.status;
    }
    public void WeaponUpdate(string weaponId)
    {
        string name = DataManager.Find(weaponId, "Weapon", "Name").ToString();
        int power = int.Parse(DataManager.Find(weaponId, "Weapon", "Power").ToString());
        AttackType attackType = (AttackType)System.Enum.Parse(typeof(AttackType),DataManager.Find(weaponId, "Weapon", "AttackType").ToString());
        //GameObject attackPrefab = Resources.Load(DataManager.Find(weaponId, "Weapon", "prefab") as string) as GameObject;
        GameObject attackPrefab;
        if (attackType == AttackType.Short)
        {
            attackPrefab = Resources.Load("Prefabs/Attack/ShortAttack") as GameObject;
        }
        else
        {
            attackPrefab = Resources.Load("Prefabs/Attack/LongAttck") as GameObject;
        }
    }
}
